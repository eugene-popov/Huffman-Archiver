using System;

namespace BackEnd.Tree
{
    /// <summary>
    /// Represents a Huffman tree leaf. 
    /// </summary>
    /// <remarks>Leaves have byte value stored in, but do not have children.</remarks>
    public class Leaf : Node
    {
        #region Fields

        /// <summary>
        /// The byte value the leaf stores.
        /// </summary>
        private int _byteValue;

        #endregion

        #region Properties

        /// <summary>
        /// The byte value the leaf stores.
        /// </summary>
        public int ByteValue
        {
            get => _byteValue;
            private set => _byteValue = value >= 0
                ? value
                : throw new ArgumentException("The provided byte value is negative.", nameof(value));
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Instantiates a Huffman tree leaf with specified <paramref name="byteValue"/>.
        /// </summary>
        /// <param name="byteValue">The byte value the leaf should store.</param>
        public Leaf(int byteValue)
        {
            ByteValue = byteValue;
        }

        #endregion
    }
}