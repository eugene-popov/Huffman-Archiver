using System;
using System.Collections.Generic;
using BackEnd.Tree;


namespace BackEnd
{
    public class EncodingTable
    {
        #region Fields

        /// <summary>
        /// Number of byte codes the table contains (256). 
        /// </summary>
        private const int CodesInTable = byte.MaxValue + 1;

        /// <summary>
        /// Min index (or byte value) the table can address.
        /// </summary>
        private const int MinTableIndex = byte.MinValue;

        /// <summary>
        /// Max index (or byte value) the table can address.
        /// </summary>
        private const int MaxTableIndex = byte.MaxValue;

        /// <summary>
        /// The backing store of the encoding table, that contains code (or null if the byte has no code) for each byte from 0 to 255.
        /// </summary>
        private int[][] _table = new int[CodesInTable][]; 

        #endregion

        #region Indexer

        /// <summary>
        /// Get the code of the specified byte of value <paramref name="byteValue"/>.
        /// </summary>
        /// <param name="byteValue">Byte of value between 0 and 255.</param>
        public int[] this[int byteValue]
        {
            get
            {
                CheckIndexBounds(byteValue);
                return _table[byteValue] ?? throw new ArgumentException(nameof(byteValue), "The provided byte has no code.");
            }
            private set
            {
                CheckIndexBounds(byteValue);
                _table[byteValue] = value;
            }
        }

        /// <summary>
        /// Checks <paramref name="index"/> on the table indices bounds. 
        /// </summary>
        /// <param name="index">Index that is being checked.</param>
        /// <exception cref="IndexOutOfRangeException"><paramref name="index"/> does not fit the table indices bounds.</exception>
        private void CheckIndexBounds(int index)
        {
            if (index < MinTableIndex)
            {
                throw new IndexOutOfRangeException("Provided byte is less than min possible byte of value " +
                                                   MinTableIndex + ".");
            }

            if (index > MaxTableIndex)
            {
                throw new IndexOutOfRangeException(
                    "Provided byte is greater that max possible byte of value " + MaxTableIndex + ".");
            }
        }

        #endregion
        
        #region Constructors

        public EncodingTable(HuffmanTree tree)
        {
            /* set codes to all bytes as null */
            FillTableWithNull();
            /* traverse the tree and set codes to all of its leaves */
            if (tree.Root is Leaf)
            {
                this[((Leaf) tree.Root).ByteValue] = new[] {0};
            }
            else
            {
                SetCodes(tree.Root, new List<int>());
            }

        }

        #endregion

        #region Methods

        /// <summary>
        /// Sets codes to all leaves in the Huffman tree.
        /// </summary>
        private void SetCodes(Node node, List<int> code)
        {
            if (node is InternalNode)
            {
                InternalNode internalNode = (InternalNode) node;

                code.Add(0);
                SetCodes(internalNode.Left, code);
                code.RemoveAt(code.Count - 1);

                code.Add(1);
                SetCodes(internalNode.Right, code);
                code.RemoveAt(code.Count - 1);
            }
            else if (node is Leaf)
            {
                Leaf leaf = (Leaf) node;
                this[leaf.ByteValue] = code.ToArray();
            }
        }

        
        
        #region Utility Methods

        /// <summary>
        /// Fills all the table cells with null values (which means that bytes have no codes initially).
        /// </summary>
        private void FillTableWithNull()
        {
            for (int @byte = MinTableIndex; @byte <= MaxTableIndex; @byte++)
            {
                this[@byte] = null;
            }
        }

        public override string ToString()
        {
            string result = "";
            for (int @byte = MinTableIndex; @byte <= MaxTableIndex; @byte++)
                /*for each code in the table */
            {
                try
                {
                    /* if the byte has its code */
                    var nextByte = this[@byte];
                    /* print it as: byte - code */
                    result += "\n" +
                              Convert.ToString(@byte, 2) // get string with the binary representation of the byte   
                              + " - ";
                    foreach (var bit in nextByte)
                    {
                        result += bit;
                    }
                }
                catch (ArgumentException)
                {
                    /* the byte has no code, so don't print it */
                }

            }

            return result;
        }

        #endregion

        #endregion
     
    }
}