using System;
using System.Collections.Generic;
using System.Linq;
using BackEnd.Tree;

namespace BackEnd
{
    internal class DecodingTable
    {
        #region Fields        

        /// <summary>
        ///     The backing store of the decoding table, that contains byte for each code.
        /// </summary>
        private readonly List<CodeBytePair> _table = new List<CodeBytePair>();

        #endregion

        #region Constructors

        public DecodingTable(HuffmanTree tree)
        {
            var encodingTable = new EncodingTable(tree);
            SetCodes(encodingTable);
        }

        #endregion

        #region Indexer

        /// <summary>
        ///     Get or set the byte corresponding the specified <paramref name="code" />.
        /// </summary>
        /// <param name="code">Code of the byte.</param>
        /// <remarks>Returns -1 if the specified <paramref name="code" /> does not exist.</remarks>
        public int this[List<int> codeList]
        {
            get
            {
                var byteValue = _table.Find(e => e.CompareCodes(codeList));
                if (byteValue != null)
                    return byteValue.byteValue;
                return -1;
            }
            private set => _table.Add(new CodeBytePair(codeList, value));
        }

        #endregion

        #region Methods

        /// <summary>
        ///     Set all the codes.
        /// </summary>
        private void SetCodes(EncodingTable encodingTable)
        {
            /* reverse the encoding table to the decoding table */
            for (int @byte = byte.MinValue; @byte <= byte.MaxValue; @byte++)
                try
                {
                    var code = encodingTable[@byte];
                    this[code.ToList()] = @byte;
                }
                catch (ArgumentException)
                {
                    /* the byte has no code, so do nothing */
                }
        }

        #endregion

        #region Utility classes

        public class CodeBytePair
        {
            public int byteValue;
            public List<int> code;

            public CodeBytePair(List<int> code, int @byte)
            {
                this.code = code;
                byteValue = @byte;
            }

            public bool CompareCodes(List<int> other)
            {
                if (code.Count != other.Count) return false;

                for (var i = 0; i < code.Count; i++)
                    if (code[i] != other[i])
                        return false;

                return true;
            }
        }

        #endregion
    }
}