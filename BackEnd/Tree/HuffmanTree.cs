using System;

namespace BackEnd.Tree
{
    /// <summary>
    /// Represents Huffman Tree.
    /// </summary>
    public class HuffmanTree
    {
        #region Fields

        /// <summary>
        /// The height of the Huffman tree (i.e. number of levels).
        /// </summary>
        private int _height;

        /// <summary>
        /// The root node of the Huffman tree.
        /// </summary>
        private Node _root;

        #endregion

        #region Properties

        /// <summary>
        /// The height of the Huffman tree (i.e. number of levels).
        /// </summary>
        public int Height
        {
            get => _height;
            private set => _height = value >=0 ? value : throw new ArgumentException("The provided height is negative.");
        }

        /// <summary>
        /// The root node of the Huffman tree.
        /// </summary>
        public Node Root
        {
            get => _root;
            private set => _root = value ?? throw new ArgumentNullException(nameof(value), "The provided node is null.");
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Generates a Huffman Tree from the <paramref name="frequencyTable"/>. 
        /// </summary>
        /// <param name="frequencyTable">The frequency table to generate a Huffman tree from.</param>
        public HuffmanTree(FrequencyTable frequencyTable)
        {
            Root = HuffmanTreeGenerator.GenerateHuffmanTree(frequencyTable, out var height);
            Height = height;
        }
        



        #endregion

        #region Methods

        


        #endregion
    }
}