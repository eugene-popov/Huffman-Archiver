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
        #region Utility classes

        [Serializable]
        private class FileMetaData
        {
            #region Fields

            /// <summary>
            /// The frequency table to restore the Huffman tree to decode the file.
            /// </summary>
            public FrequencyTable frequencyTable;

            /// <summary>
            /// The hash of the uncompressed file.
            /// </summary>
            public byte[] uncompressedHash;

            /// <summary>
            /// The hash of the compressed file.
            /// </summary>
            public byte[] compressedHash;

            /// <summary>
            /// The compression ratio of the file.
            /// </summary>
            public double compressionRatio;

            /// <summary>
            /// The size of the file before compression.
            /// </summary>
            public long uncompressedSize;

            /// <summary>
            /// The size of the compressed file.
            /// </summary>
            public long compressedSize;

            /// <summary>
            ///The original file name.
            /// </summary>
            public string filename;

            #endregion
        }

        #endregion
        
        #region Fields

        /// <summary>
        /// The package that represents the archive. 
        /// </summary>
        private Package _archive;

        /// <summary>
        /// The amount of bytes that should be buffered while performing I/O operations. 
        /// </summary>
        private const int BufferSize = 1024 * 1024 * 4;

        #endregion

        #region Properties

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes an archive object physically located in the provided <paramref name="path"/>.
        /// </summary>
        /// <param name="path">The path the archive is located in.</param>
        public Archive(string path)
        {
            _archive = Package.Open(path, FileMode.OpenOrCreate);
            
        }

        #endregion

        #region Methods

        #region File compression

        /// <summary>
        /// Compresses and adds the file stored in the specified <paramref name="path"/> to the archive.
        /// </summary>
        /// <param name="path">The path the file to be added stored in.</param>
        /// <exception cref="IOException">The file does not exist or cannot be read.</exception>
        public void AddFile(string path)
        {
            /* check if file exists and can be read */
            if (!File.Exists(path))
            {
                throw new IOException("The file in the provided path does not exist or cannot be read.");
            }

            var filename = Path.GetFileName(path);

            /* create path (relating to the archive root) where a compressed file will be stored */
            Uri fileUri = PackUriHelper.CreatePartUri(new Uri(".\\" + filename.Replace(" ", ""), UriKind.Relative));
            /* create a package part in the path */
            PackagePart filePart = _archive.CreatePart(fileUri, "", CompressionOption.NotCompressed);
            
            /* calculate the file's hashsum and size */
            byte[] uncompressedHash;
            long uncompressedSize;
            using (var fileStream = File.OpenRead(path))
            {
                uncompressedSize = fileStream.Length;
                uncompressedHash = ComputeHashCode(fileStream);
            }
            
            /* compress the file and store the compressed file in the package part */
            CompressFile(path, filePart, out FrequencyTable frequencies);
            
            /* calculate the compressed file's hashsum and size */
            byte[] compressedHash;
            long compressedSize;
            using (var compressedPartStream = new BufferedStream(filePart.GetStream(), BufferSize))
            {
                compressedSize = compressedPartStream.Length;
                compressedHash = ComputeHashCode(compressedPartStream);
            }
            filePart.GetStream().Close();
            
            /* store collected meta data of the added file in archive */
            StoreMetaData(filePart, frequencies, uncompressedHash, compressedHash
            , ((double)((compressedSize * 1.0) / uncompressedSize)), uncompressedSize, compressedSize, filename);
            
            
        }

        public void Close()
        {
            _archive.Close();
        }

        /// <summary>
        /// Compresses the file stored in the <paramref name="path"/> and stores compressed file it the <paramref name="filePart"/>.
        /// </summary>
        /// <param name="path">The path to the file to be compressed.</param>
        /// <param name="filePart">The archive part to store the compressed file in.</param>
        /// <param name="frequencyTable">The frequency table to be saved to the archive.</param>
        private void CompressFile(string path, PackagePart filePart, out FrequencyTable frequencyTable)
        {
            /* open the file */
            var fileStream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read, BufferSize);
            /* find frequencies of bytes in the file */
            frequencyTable = new FrequencyTable(fileStream);
            /* rewind the position of the stream to use this stream once again */
            fileStream.Position = 0;          
            /* build the Huffman tree based on the counted frequencies */
            var huffmanTree = new HuffmanTree(frequencyTable);
            /* get the Huffman code from the tree */
            var encodingTable = new EncodingTable(huffmanTree);
            /* get the file part's stream */
            var filePartStream = new BufferedStream(filePart.GetStream(), BufferSize);
            /* encode the file */
            var encoder = new Encoder(fileStream, filePartStream, encodingTable); 
            encoder.Encode();
            /* dispose unused streams */
            fileStream.Close();        
            filePartStream.Close();
        }

        #endregion

        #region File decompression

        public void ExtractFile(String partTitle)
        {
           /* create path (relating to the archive root) where the compressed file is stored */
            Uri fileUri = PackUriHelper.CreatePartUri(new Uri(".\\" + Path.GetFileName(partTitle), UriKind.Relative));
            /* get the package part in the path */
            var filePart = _archive.GetPart(fileUri);
            /* get metadata of the file */
            var meta = GetMetaData(filePart);
            /* create decompressed file's stream */
            var fileStream = new FileStream(Path.GetFileName(partTitle), FileMode.Create, FileAccess.Write, FileShare.Read, BufferSize);
            var compressedStream = new BufferedStream(filePart.GetStream(), BufferSize);
            DecompressFile(compressedStream, fileStream, meta);
            /* close unused streams */
            fileStream.Close();
            compressedStream.Close();
        }

        private void DecompressFile(Stream compressed, Stream decompressed, FileMetaData meta)
        {
            var frequencies = meta.frequencyTable;
            var bytesCount = meta.uncompressedSize;
            var decoder = new Decoder(compressed, decompressed, frequencies, bytesCount);
            decoder.Decode();
        }

        #endregion

        #region View

        /// <summary>
        /// Returns the view of the archive.
        /// </summary>
        /// <returns></returns>
        public List<List<object>> GetView()
        {
            var info = new List<List<object>>();
            /* get all files and their relationships (there are only relationships between archived files and their metadata stored in the package, so the relationsips indicate only those files that we need to show)*/
            var parts = _archive.GetParts();
            foreach (var part in parts)
            {
                /* try to get get relations owned by this file */
                try
                {
                    var rels = part.GetRelationships();
                    if (rels.Count() != 0)
                        /* there is a relation owned by this file (thus the file is a compressed file (not meta or package's meta)) */
                    {
                        /* get meta of the file */
                        var meta = GetMetaData(part);
                        /* now collect all the info about the file */
                        var uri = part.Uri;
                        var name = meta.filename;
                        var compressedSizeValue = meta.compressedSize;
                        string compressedSize;
                        if (compressedSizeValue > 1024 * 1024)
                        {
                            compressedSize = ((double) compressedSizeValue / (1024 * 1024)).ToString("F2") + "MB";
                        }
                        else if (compressedSizeValue > 1024)
                        {
                            compressedSize = ((double) compressedSizeValue / 1024).ToString("F2") + "kB";
                        }
                        else
                        {
                            compressedSize = compressedSizeValue + "bytes";
                        }

                        var uncompressedSizeValue = meta.uncompressedSize;
                        string uncompressedSize;
                        if (compressedSizeValue > 1024 * 1024)
                        {
                            uncompressedSize = ((double) uncompressedSizeValue / (1024 * 1024)).ToString("F2") + " MB";
                        }
                        else if (compressedSizeValue > 1024)
                        {
                            uncompressedSize = ((double) uncompressedSizeValue / 1024).ToString("F2") + " kB";
                        }
                        else
                        {
                            uncompressedSize = uncompressedSizeValue + " bytes";
                        }

                        var ratio = ((1 - meta.compressionRatio)*100).ToString("F2") + " %";
                        /* now add the collected data */
                        info.Add(new List<object>() {uri, name, compressedSize, uncompressedSize, ratio});

                    }
                }
                catch (InvalidOperationException)
                {
                    /* relationships file cannot have relations */
                }
            }

            return info;
        }

        #endregion

        #region Utility Methods

        /// <summary>
        /// Gets meta data of the <paramref name="part"/>.
        /// </summary>
        /// <param name="part">The part which meta data should be returned.</param>
        /// <returns>Metadata of the <paramref name="part"/>.</returns>
        private FileMetaData GetMetaData(PackagePart part)
        {
            PackageRelationship relationship = null;
            foreach (var rel in part.GetRelationships())
            {
                relationship = rel;
            }

            var metaPart = _archive.GetPart(relationship.TargetUri);
            FileMetaData meta = null;
            using (var metaStream = metaPart.GetStream())
            {
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                meta = (FileMetaData)binaryFormatter.Deserialize(metaStream);
            }

            return meta;
        }

        /// <summary>
        /// Stores meta data (i.e. data needed to decompress and test the file) for the compressed <paramref name="filePart"/>.
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
            var meta = new FileMetaData()
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
            var metaUri = PackUriHelper.CreatePartUri(new Uri(filePart.Uri.ToString() + "META", UriKind.Relative));
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
        /// Computes the hash for the specified <paramref name="fileStream"/>.
        /// </summary>
        /// <param name="fileStream">The stream which hashcode should be calculated.</param>
        /// <returns>The hashcode of the <paramref name="fileStream"/></returns>
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