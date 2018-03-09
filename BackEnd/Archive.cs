using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Packaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BackEnd.Tree;

namespace BackEnd
{
    public class Archive
    {
        #region Fields

        /// <summary>
        /// The package that represents the archive. 
        /// </summary>
        private Package _archive;

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
            _archive = Package.Open(path, FileMode.Create);
            
        }

        #endregion

        #region Methods

        public void AddFile(string path)
        {
            Uri fileUri = PackUriHelper.CreatePartUri(new Uri(".\\" + Path.GetFileName(path), UriKind.Relative));
            PackagePart filePart = _archive.CreatePart(fileUri, "", CompressionOption.NotCompressed);
            
            CompressFile(path, filePart);

        }

        /// <summary>
        /// Compresses the file stored in the <paramref name="path"/> and stores compressed file it the <paramref name="filePart"/>.
        /// </summary>
        /// <param name="path">The path to the file to be compressed.</param>
        /// <param name="filePart">The archive part to store the compressed file in.</param>
        private void CompressFile(string path, PackagePart filePart)
        {
            /* open the file */
            FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read);
            /* read bytes from the file */
            byte[] bytes = new byte[fileStream.Length];
            fileStream.Read(bytes, 0, (int)fileStream.Length);
            fileStream.Dispose();
            FrequencyTable frequencyTable = new FrequencyTable(bytes);

            HuffmanTree huffmanTree = new HuffmanTree(frequencyTable);
            EncodingTable encodingTable = new EncodingTable(huffmanTree);
            
            List<byte> buffer = new List<byte>();
            BitWriter bitWriter = new BitWriter(ref buffer);
            foreach (var @byte in bytes)
            {
                foreach (var bit in encodingTable[@byte])
                {
                    bitWriter.Write(bit);
                }
            }
            
            bitWriter.Dispose();
            filePart.GetStream().Write(buffer.ToArray(), 0, buffer.Count);           
            
        }

        #endregion
    }
}