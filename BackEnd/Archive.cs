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
            BufferedStream bufferedStream = new BufferedStream(fileStream, 1024*1024);
            /* read bytes from the file */
            //byte[] bytes = new byte[fileStream.Length];
            //fileStream.Read(bytes, 0, (int)fileStream.Length);
           //fileStream.Dispose();
            
            FrequencyTable frequencyTable = new FrequencyTable(bufferedStream);

            
            fileStream.Close();
            bufferedStream.Close();
            

            HuffmanTree huffmanTree = new HuffmanTree(frequencyTable);
            EncodingTable encodingTable = new EncodingTable(huffmanTree);
            
            fileStream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read);
            bufferedStream = new BufferedStream(fileStream, 1024*1024);

            var outStream = new BufferedStream(filePart.GetStream(), 1024 * 1024);
         
            BitWriter bitWriter = new BitWriter(outStream);
           
            int nextByte = bufferedStream.ReadByte();
            while (nextByte != -1)
            {
                var code = encodingTable[nextByte];
                for (int bit = 0; bit < code.Length; bit++)
                    bitWriter.Write(code[bit]);
                nextByte = bufferedStream.ReadByte();
            }
            fileStream.Close();
            bufferedStream.Close();
            
            bitWriter.Dispose();
             
            _archive.Close();
            
        }

        #endregion
    }
}