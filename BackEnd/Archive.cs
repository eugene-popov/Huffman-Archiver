using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Packaging;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using BackEnd.Tree;

namespace BackEnd
{
    public class Archive
    {
        #region Constructors

        /// <summary>
        ///     Initializes an archive object physically located in the provided <paramref name="path" />.
        /// </summary>
        /// <param name="path">The path the archive is located in.</param>
        public Archive(string path)
        {
            _archive = Package.Open(path, FileMode.OpenOrCreate);
            _archiveName = Path.GetFileNameWithoutExtension(path);
        }

        #endregion

        #region Utility classes

        [Serializable]
        private class FileMetaData
        {
            #region Fields

            /// <summary>
            ///     The frequency table to restore the Huffman tree to decode the file.
            /// </summary>
            public FrequencyTable frequencyTable;

            /// <summary>
            ///     The hash of the uncompressed file.
            /// </summary>
            public byte[] uncompressedHash;

            /// <summary>
            ///     The hash of the compressed file.
            /// </summary>
            public byte[] compressedHash;

            /// <summary>
            ///     The compression ratio of the file.
            /// </summary>
            public double compressionRatio;

            /// <summary>
            ///     The size of the file before compression.
            /// </summary>
            public long uncompressedSize;

            /// <summary>
            ///     The size of the compressed file.
            /// </summary>
            public long compressedSize;

            /// <summary>
            ///     The original file name.
            /// </summary>
            public string filename;

            #endregion
        }

        #endregion

        #region Fields

        /// <summary>
        ///     The package that represents the archive.
        /// </summary>
        private readonly Package _archive;

        /// <summary>
        ///     The amount of bytes that should be buffered while performing I/O operations.
        /// </summary>
        private const int BufferSize = 1024 * 1024 * 4;

        /// <summary>
        ///     The name of the archive.
        /// </summary>
        private readonly string _archiveName;

        #endregion

        #region Properties

        #endregion

        #region Events

        public delegate void ReportStateChange(string newState);

        /// <summary>
        ///     Raises when the state (i. e. the task (or the file) being performed) changes
        /// </summary>
        public event ReportStateChange OnStateChange = delegate { };

        public delegate void ReportCurrentFileChange(string newFile);

        /// <summary>
        ///     Raises when the file being processed changes (should be like: current file index of total)
        /// </summary>
        public event ReportCurrentFileChange OnCurrentFileChange = delegate { };

        public delegate void ReportProgress(int progress);

        /// <summary>
        ///     Raises when progress (represented as percentage) changes
        /// </summary>
        public event ReportProgress OnProgressChange = delegate { };

        #endregion

        #region Methods

        #region Compression

        /// <summary>
        ///     Compresses and adds the file stored in the specified <paramref name="path" /> to the archive.
        /// </summary>
        /// <param name="path">The path the file to be added stored in.</param>
        /// <exception cref="IOException">The file does not exist or cannot be read.</exception>
        public void AddFile(string path)
        {
            OnStateChange("checking availability of the file");
            /* check if file exists and can be read */
            if (!File.Exists(path)) throw new IOException("The file does not exist or cannot be read.");

            var filename = Path.GetFileName(path);

            /* create path (relating to the archive root) where a compressed file will be stored */
            var fileUri = PackUriHelper.CreatePartUri(new Uri(".\\" + filename.Replace(" ", ""), UriKind.Relative));
            var filesCounter = 1;
            while (_archive.PartExists(fileUri))
            {
                var newFileName = filename + " (" + filesCounter++ + ")";
                fileUri = PackUriHelper.CreatePartUri(new Uri(".\\" + newFileName, UriKind.Relative));
                if (!_archive.PartExists(fileUri)) filename = newFileName;
            }

            /* create a package part in the path */
            var filePart = _archive.CreatePart(fileUri, "", CompressionOption.NotCompressed);
            OnStateChange("calculating the uncompressed file's checksum");
            /* calculate the file's hashsum and size */
            byte[] uncompressedHash;
            long uncompressedSize;
            using (var fileStream = File.OpenRead(path))
            {
                uncompressedSize = fileStream.Length;
                uncompressedHash = ComputeHashCode(fileStream);
            }

            /* compress the file and store the compressed file in the package part */
            CompressFile(path, filePart, out var frequencies);
            OnStateChange("calculating the compressed file's checksum");
            /* calculate the compressed file's hashsum and size */
            byte[] compressedHash;
            long compressedSize;
            using (var compressedPartStream = new BufferedStream(filePart.GetStream(), BufferSize))
            {
                compressedSize = compressedPartStream.Length;
                compressedHash = ComputeHashCode(compressedPartStream);
            }

            filePart.GetStream().Close();
            OnStateChange("storing metadata");
            /* store collected meta data of the added file in archive */
            StoreMetaData(filePart, frequencies, uncompressedHash, compressedHash
                , compressedSize * 1.0 / uncompressedSize, uncompressedSize, compressedSize, filename);
        }

        public void Close()
        {
            _archive.Close();
        }

        /// <summary>
        ///     Compresses the file stored in the <paramref name="path" /> and stores compressed file it the
        ///     <paramref name="filePart" />.
        /// </summary>
        /// <param name="path">The path to the file to be compressed.</param>
        /// <param name="filePart">The archive part to store the compressed file in.</param>
        /// <param name="frequencyTable">The frequency table to be saved to the archive.</param>
        private void CompressFile(string path, PackagePart filePart, out FrequencyTable frequencyTable)
        {
            /* open the file */
            var fileStream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read, BufferSize);
            /* find frequencies of bytes in the file */
            OnStateChange("counting up frequencies of bytes");
            frequencyTable = new FrequencyTable(fileStream);
            frequencyTable.SubscribeToUpdates(OnProgressChange);
            frequencyTable.CountFrequencies();
            /* rewind the position of the stream to use this stream once again */
            fileStream.Position = 0;
            /* build the Huffman tree based on the counted frequencies */
            OnStateChange("building the Huffman tree");
            var huffmanTree = new HuffmanTree(frequencyTable);
            /* get the Huffman code from the tree */
            OnStateChange("retrieving the Huffman code");
            var encodingTable = new EncodingTable(huffmanTree);
            /* get the file part's stream */
            var filePartStream = new BufferedStream(filePart.GetStream(), BufferSize);
            /* encode the file */
            OnStateChange("compressing the file");
            var encoder = new Encoder(fileStream, filePartStream, encodingTable);
            encoder.SubscribeToUpdates(OnProgressChange);
            encoder.Encode();
            /* dispose unused streams */
            fileStream.Close();
            filePartStream.Close();
        }

        #endregion

        #region Decompression

        /// <summary>
        ///     Extracts file from the archive.
        /// </summary>
        /// <param name="fileUri">The uri of the file to be extracted.</param>
        /// <param name="path">The path to extract file to.</param>
        public void ExtractFile(Uri fileUri, string path, bool messages)
        {
            /* get the package part in the path */
            var filePart = _archive.GetPart(fileUri);
            /* get metadata of the file */
            var meta = GetMetaData(filePart);
            /* create decompressed file's stream */
            using (var fileStream = new FileStream(path, FileMode.Create, FileAccess.Write,
                FileShare.Read, BufferSize))
            {
                using (var compressedStream = new BufferedStream(filePart.GetStream(), BufferSize))
                {
                    DecompressFile(compressedStream, fileStream, meta, messages);
                }
            }

            /* close unused streams */
            filePart.GetStream().Close();
        }

        /// <summary>
        ///     Extracts the archive to the selected <paramref name="path" />.
        /// </summary>
        /// <param name="path">The path to extract the archive to.</param>
        public void ExtractArchive(string path)
        {
            /* create a new directory that will contain all the archive contents */
            path = Path.Combine(path, _archiveName + " extracted");
            /* create a directory to extract the archive to */
            Directory.CreateDirectory(path);
            var files = GetFiles();
            var total = files.Count;
            var current = 1;
            foreach (var file in files)
            {
                OnCurrentFileChange("file " + current++ + " of " + total);
                var meta = GetMetaData(file);
                var filename = meta.filename;
                OnStateChange(filename);
                var filePath = Path.Combine(path, filename);
                ExtractFile(file.Uri, filePath, false);
            }
        }

        /// <summary>
        ///     Decompressed a compressed stream.
        /// </summary>
        /// <param name="compressed">The compressed stream to be decompressed.</param>
        /// <param name="decompressed">The stream to write decompressed data to.</param>
        /// <param name="meta">Metadata to retrieve the Huffman tree from.</param>
        private void DecompressFile(Stream compressed, Stream decompressed, FileMetaData meta, bool informOfProgress)
        {
            if (informOfProgress) OnStateChange("restoring the frequency table");

            var frequencies = meta.frequencyTable;
            var bytesCount = meta.uncompressedSize;
            if (informOfProgress) OnStateChange("building the Huffman tree");

            var decoder = new Decoder(compressed, decompressed, frequencies, bytesCount);
            decoder.SubscribeToUpdates(OnProgressChange);
            if (informOfProgress) OnStateChange("decoding the file");

            decoder.Decode();
        }

        #endregion

        #region Deletion

        public void DeleteFile(Uri uri)
        {
            /* check if the part exists */
            if (!_archive.PartExists(uri)) throw new FileNotFoundException("No file with the specified name exist.");

            /* delete meta */
            _archive.DeletePart(GetMetaPartUri(_archive.GetPart(uri)));
            /* delete the file */
            _archive.DeletePart(uri);
        }

        #endregion

        #region Test

        /// <summary>
        ///     Tests file.
        /// </summary>
        /// <param name="fileUri">The uri of the file to be tested.</param>
        /// <returns>Test result.</returns>
        public bool TestFile(Uri fileUri)
        {
            var part = _archive.GetPart(fileUri);
            var meta = GetMetaData(part);
            var storedHashSum = meta.compressedHash;
            byte[] calculatedHashSum;
            using (var stream = part.GetStream())
            {
                calculatedHashSum = ComputeHashCode(stream);
            }

            var result = true;

            for (var i = 0; i < storedHashSum.Length; i++) result = result && storedHashSum[i] == calculatedHashSum[i];

            return result;
        }

        /// <summary>
        ///     Tests all the compressed files in the archive.
        /// </summary>
        /// <param name="damagedFiles">List of damaged files' names.</param>
        /// <returns>If the archive contains at least one damaged file.</returns>
        public bool TestArchive(out List<string> damagedFiles)
        {
            damagedFiles = new List<string>();
            var result = true;
            var files = GetFiles();
            var number = 1;
            foreach (var filePart in files)
            {
                OnCurrentFileChange("file " + number++ + " of " + files.Count);
                var uri = filePart.Uri;
                var meta = GetMetaData(filePart);
                var fileTestResult = TestFile(uri);
                if (!fileTestResult) damagedFiles.Add(meta.filename);

                result = result && fileTestResult;
            }

            return result;
        }

        #endregion


        #region View

        /// <summary>
        ///     Returns the view of the archive.
        /// </summary>
        /// <returns></returns>
        public List<List<object>> GetView()
        {
            var info = new List<List<object>>();
            /* get all files */
            var files = GetFiles();
            foreach (var part in files)
            {
                /* get meta of the file */
                var meta = GetMetaData(part);
                /* now collect all the info about the file */
                var uri = part.Uri;
                var name = meta.filename;
                var compressedSizeValue = meta.compressedSize;
                string compressedSize;
                if (compressedSizeValue > 1024 * 1024)
                    compressedSize = ((double) compressedSizeValue / (1024 * 1024)).ToString("F2") + " MB";
                else if (compressedSizeValue > 1024)
                    compressedSize = ((double) compressedSizeValue / 1024).ToString("F2") + " kB";
                else
                    compressedSize = compressedSizeValue + " bytes";

                var uncompressedSizeValue = meta.uncompressedSize;
                string uncompressedSize;
                if (compressedSizeValue > 1024 * 1024)
                    uncompressedSize = ((double) uncompressedSizeValue / (1024 * 1024)).ToString("F2") + " MB";
                else if (compressedSizeValue > 1024)
                    uncompressedSize = ((double) uncompressedSizeValue / 1024).ToString("F2") + " kB";
                else
                    uncompressedSize = uncompressedSizeValue + " bytes";

                var ratio = ((1 - meta.compressionRatio) * 100).ToString("F2") + "%";
                /* now add the collected data */
                info.Add(new List<object> {uri, name, compressedSize, uncompressedSize, ratio});
            }

            return info;
        }

        #endregion

        #region Utility Methods

        /// <summary>
        ///     Get all compressed files of the archive.
        /// </summary>
        /// <returns>Compressed files of the archive.</returns>
        private List<PackagePart> GetFiles()
        {
            var files = new List<PackagePart>();
            var parts = _archive.GetParts();
            foreach (var part in parts)
                /* try to get get relations owned by this file */
                try
                {
                    var rels = part.GetRelationships();
                    if (rels.Count() != 0) files.Add(part);
                }
                catch (InvalidOperationException)
                {
                    /* relationships file cannot have relations */
                }

            return files;
        }

        private Uri GetMetaPartUri(PackagePart part)
        {
            PackageRelationship relationship = null;
            foreach (var rel in part.GetRelationships()) relationship = rel;

            return _archive.GetPart(relationship.TargetUri).Uri;
        }

        /// <summary>
        ///     Gets meta data of the <paramref name="part" />.
        /// </summary>
        /// <param name="part">The part which meta data should be returned.</param>
        /// <returns>Metadata of the <paramref name="part" />.</returns>
        private FileMetaData GetMetaData(PackagePart part)
        {
            var metaPart = _archive.GetPart(GetMetaPartUri(part));
            FileMetaData meta = null;
            using (var metaStream = metaPart.GetStream())
            {
                var binaryFormatter = new BinaryFormatter();
                meta = (FileMetaData) binaryFormatter.Deserialize(metaStream);
            }

            return meta;
        }

        /// <summary>
        ///     Stores meta data (i.e. data needed to decompress and test the file) for the compressed <paramref name="filePart" />
        ///     .
        /// </summary>
        /// <param name="filePart">The compressed file which meta data should be stored.</param>
        /// <param name="frequencyTable">The frequency table needed to restore the Huffman tree (for file decoding). </param>
        /// <param name="uncompressedHashSum">The hashsum needed to test file correctness after unpacking.</param>
        /// <param name="compressedHashSum">The hashsum needed to test compressed file correctness before unpacking.</param>
        /// <param name="ratio">The compression ratio shown to the user.</param>
        /// <param name="uncompressed">Size of the file before compression.</param>
        /// <param name="compressed">Size of the compressed file.</param>
        private void StoreMetaData(PackagePart filePart, FrequencyTable frequencyTable, byte[] uncompressedHashSum,
            byte[] compressedHashSum, double ratio, long uncompressed, long compressed, string name)
        {
            /* collect metadate into a class */
            var meta = new FileMetaData
            {
                frequencyTable = frequencyTable,
                compressedHash = compressedHashSum,
                uncompressedHash = uncompressedHashSum,
                compressionRatio = ratio,
                uncompressedSize = uncompressed,
                compressedSize = compressed,
                filename = name
            };

            /* create path (relating to the archive root) where the meta data will be stored */
            var metaUri = PackUriHelper.CreatePartUri(new Uri(filePart.Uri + "META", UriKind.Relative));
            /* create a package part in the path */
            var metaPart = _archive.CreatePart(metaUri, "", CompressionOption.NotCompressed);

            filePart.CreateRelationship(metaUri, TargetMode.Internal, ".\\META");

            using (var metaStream = new BufferedStream(metaPart.GetStream(), BufferSize))
            {
                var formatter = new BinaryFormatter();
                formatter.Serialize(metaStream, meta);
            }
        }

        /// <summary>
        ///     Computes the hash for the specified <paramref name="fileStream" />.
        /// </summary>
        /// <param name="fileStream">The stream which hashcode should be calculated.</param>
        /// <returns>The hashcode of the <paramref name="fileStream" /></returns>
        private byte[] ComputeHashCode(Stream fileStream)
        {
            byte[] hash;
            using (var md5 = MD5.Create())
            {
                hash = md5.ComputeHash(fileStream);
            }

            return hash;
        }

        #endregion

        #endregion
    }
}