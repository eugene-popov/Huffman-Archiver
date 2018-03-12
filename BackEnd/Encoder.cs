using System;
using System.IO;
using System.Reflection.Emit;

namespace BackEnd
{
    /// <summary>
    /// Encodes the input stream bytes using the encoding table to the output stream. 
    /// </summary>
    public class Encoder
    {
        #region Fields

        /// <summary>
        /// The stream to get bytes from.
        /// </summary>
        private Stream _inputStream;

        /// <summary>
        /// The stream to write encoded bits to.
        /// </summary>
        private Stream _outputStream;

        /// <summary>
        /// The encoding table with the Huffman code. 
        /// </summary>
        private EncodingTable _encodingTable;

        #endregion

        #region Properties

        /// <summary>
        /// The stream to get bytes from. 
        /// </summary>
        /// <exception cref="ArgumentNullException">The stream is null.</exception>
        /// <exception cref="ArgumentException">The stream is not readable.</exception>
        private Stream InputStream
        {
            get => _inputStream;
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value), "The provided stream is null.");
                }

                if (!value.CanRead)
                {
                    throw new ArgumentException("The provided stream is not readable.");
                }

                _inputStream = value;

            }
        }

        /// <summary>
        /// The stream to write encoded bits to.
        /// </summary>
        /// <exception cref="ArgumentNullException">The provided stream is null.</exception>
        /// <exception cref="ArgumentException">The provided stream cannot be written.</exception>
        private Stream OutputStream
        {
            get => _outputStream;
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value), "The provided stream is null.");
                }

                if (!value.CanWrite)
                {
                    throw new ArgumentException("The stream cannot be written.");
                }

                _outputStream = value;
            }
        }

        /// <summary>
        /// The encoding table with the Huffman code. 
        /// </summary>
        private EncodingTable EncodingTable
        {
            get => _encodingTable;
            set => _encodingTable = value ?? throw new ArgumentNullException(nameof(value), "The provided encoding table is null.");
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes an encoder that encodes the <paramref name="inputStream"/> bytes with codes in the <paramref name="encodingTable"/> to the <paramref name="outputStream"/>.
        /// </summary>
        /// <param name="inputStream">The stream to read bytes from.</param>
        /// <param name="outputStream">The stream to write encoded bytes to.</param>
        /// <param name="encodingTable">The table containing Huffman codes for bytes.</param>
        public Encoder(Stream inputStream, Stream outputStream, EncodingTable encodingTable)
        {
            InputStream = inputStream;
            OutputStream = outputStream;
            EncodingTable = encodingTable;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Encodes the stream.
        /// </summary>
        public void Encode()
        {
            var bitWriter = new BitWriter(OutputStream);
            
            int nextByte = InputStream.ReadByte();
            while (nextByte != -1)
            {
                var code = EncodingTable[nextByte];
                for (int bitIndex = 0; bitIndex < code.Length; bitIndex++)
                    bitWriter.Write(code[bitIndex]);
                nextByte = InputStream.ReadByte();
            }

            bitWriter.Dispose();
        }

        #endregion
    }
}