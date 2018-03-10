using System;
using System.IO;
using BackEnd.Tree;

namespace BackEnd
{
    public class Decoder
    {
        #region Fields

        /// <summary>
        /// The stream to get encoded bits from.
        /// </summary>
        private Stream _inputStream;

        /// <summary>
        /// The stream to write decoded bytes to.
        /// </summary>
        private Stream _outputStream;

        /// <summary>
        /// The Huffman tree used in decoding. 
        /// </summary>
        private HuffmanTree _tree;

        /// <summary>
        /// The number of bytes that should be decoded and written.
        /// <remarks>BitWriter class may add from 0 to 7 zero bits to the end of the encoded file in order to fit the very last bits to byte boundaries.</remarks>
        /// </summary>
        private long _encodedBytesCount;
        
        #endregion
        
        #region Properties

        /// <summary>
        /// The stream to get encoded bits from.
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
        /// The stream to write decoded bytes to.
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
        private HuffmanTree Tree
        {
            get => _tree;
            set => _tree = value ?? throw new ArgumentNullException(nameof(value), "The provided Huffman tree is null.");
        }

        /// <summary>
        /// The number of bytes that should be decoded and written.
        /// </summary>
        private long BytesCount
        {
            get => _encodedBytesCount;
            set => _encodedBytesCount = value >= 0 ? value : throw new ArgumentException(nameof(value), "The provided encoded bytes counter is negative.");
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the decoder.
        /// </summary>
        /// <param name="frequencyTable">The frequency table to build the Huffman tree from.</param>
        /// <param name="encoodedBytesCount">The number of bytes that should be decoded and written.</param>
        public Decoder(Stream input, Stream output, FrequencyTable frequencyTable, long encoodedBytesCount)
        {
            InputStream = input;
            OutputStream = output;
            Tree = new HuffmanTree(frequencyTable);
            BytesCount = encoodedBytesCount;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Decodes the stream.
        /// </summary>
        /// <exception cref="InvalidOperationException">Errors in the encoded file occured.</exception>
        public void Decode()
        {
            var currentNode = Tree.Root;
            var bitReader = new BitReader(InputStream);
            while (BytesCount > 0)
            {
                if (currentNode is Leaf leaf)
                {
                    OutputStream.WriteByte((byte) leaf.ByteValue);
                    currentNode = Tree.Root;
                    BytesCount--;
                }
                var bit = bitReader.Read();
                if (bit == 0)
                {
                    currentNode = ((InternalNode) currentNode).Left;
                }

                if (bit == 1)
                {
                    currentNode = ((InternalNode) currentNode).Right;
                }

                if (bit == -1 && BytesCount > 0)
                {
                    throw new InvalidOperationException("The decoding has failed due to errors in the encoded file.");
                }


            }
        }

        #endregion
    }
}