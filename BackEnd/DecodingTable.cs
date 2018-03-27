using BackEnd.Tree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd
{
    class DecodingTable
    {
        #region Utility classes
        public class CodeBytePair
        {
            public List<int> code;
            public int byteValue;

            public bool CompareCodes(List<int> other)
            {
                if (code.Count != other.Count)
                {
                    return false;
                }
                for (int i = 0; i < code.Count; i++)
                {
                    if (code[i] != other[i])
                    {
                        return false;
                    }
                }
                return true;
            }
            public CodeBytePair(List<int> code, int @byte)
            {
                this.code = code;
                this.byteValue = @byte;
            }
        }

        #endregion
        #region Fields        

        /// <summary>
        /// The backing store of the decoding table, that contains byte for each code.
        /// </summary>
        private List<CodeBytePair> _table = new List<CodeBytePair>();

        #endregion

        #region Indexer

        /// <summary>
        /// Get or set the byte corresponding the specified <paramref name="code"/>.
        /// </summary>
        /// <param name="code">Code of the byte.</param>
        /// <remarks>Returns -1 if the specified <paramref name="code"/> does not exist.</remarks>
        public int this[List<int> codeList]
        {

            get
            {
                var byteValue = _table.Find(e => e.CompareCodes(codeList));
                if(byteValue != null)
                {
                    return byteValue.byteValue;
                }
                else
                {
                    return -1;
                }
            }
            private set
            {
                _table.Add(new CodeBytePair(codeList, value));
            }
        }
        

        #endregion

        #region Constructors

        public DecodingTable(HuffmanTree tree)
        {
            var encodingTable = new EncodingTable(tree);
            SetCodes(encodingTable);
        }

        #endregion

        #region Methods

        /// <summary>
        /// Set all the codes.
        /// </summary>
        private void SetCodes(EncodingTable encodingTable)
        {
            /* reverse the encoding table to the decoding table */
            for (int @byte = byte.MinValue; @byte <= byte.MaxValue; @byte++)
            {
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
        }

        #endregion
    }
}
