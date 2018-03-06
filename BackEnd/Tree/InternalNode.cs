using System;

namespace BackEnd.Tree
{
    /// <summary>
    /// Represents an internal node of the Huffman tree. 
    /// </summary>
    /// <remarks>Internal nodes have children, but do not have byte value stored.</remarks>
    public class InternalNode : Node
    {
        #region Fields

        /// <summary>
        /// The right child of the node.
        /// </summary>
        private Node _right;

        /// <summary>
        /// The left child of the node.
        /// </summary>
        private Node _left;

        #endregion

        #region Properties

        /// <summary>
        /// The right child of the node.
        /// </summary>
        public Node Left
        {
            get => _left;
            private set => _left =
                value ?? throw new ArgumentNullException(nameof(value), "The provided left child is null.");
        }

        /// <summary>
        /// The left child of the node.
        /// </summary>
        public Node Right
        {
            get => _right;
            private set => _right =
                value ?? throw new ArgumentNullException(nameof(value), "The provided right child is null.");
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Instantiates an internal node with the specified children. 
        /// </summary>
        /// <param name="left">The left children of the internal node.</param>
        /// <param name="right">The right children of the internal node.</param>
        public InternalNode(Node left, Node right)
        {
            Left = left;
            Right = right;
        }

        #endregion
    }
}