using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd
{
    /// <summary>
    /// Utility class that represents the frequency table containing frequencies for each byte. 
    /// </summary>
    [Serializable]
    public class FrequencyTable
    {
        #region Fields

        /// <summary>
        /// Number of byte frequencies the table contains (256). 
        /// </summary>
        [NonSerialized]
        private const int FreqsInTable = byte.MaxValue + 1;

        /// <summary>
        /// Min index (or byte value) the table can address.
        /// </summary>
        [NonSerialized]
        private const int MinTableIndex = byte.MinValue;

        /// <summary>
        /// Max index (or byte value) the table can address.
        /// </summary>
        [NonSerialized]
        private const int MaxTableIndex = byte.MaxValue;

        /// <summary>
        /// The backing store of the frequency table, that contains frequency (0 if byte has not occured in the input stream, otherwise positive integer) for each byte from 0 to 255.
        /// </summary>
        private int[] _table = new int[FreqsInTable];

        #endregion

        #region Indexer

        /// <summary>
        /// Get the frequency of the specified byte of value <paramref name="byteValue"/>.
        /// </summary>
        /// <param name="byteValue">Byte of value between 0 and 255.</param>
        public int this[int byteValue]
        {
            get
            {
                CheckIndexBounds(byteValue);
                return _table[byteValue];
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

        public FrequencyTable(byte[] bytes)
        {
            int[] newBytes = DivideBytes(bytes);

            FillTableWithZeroes();
            foreach (var @byte in newBytes)
            {
                this[@byte] += 1;
            }
        }
        /// <summary>
        /// Divides each 8-bit byte to two 4-digit parts in order to escape overflow out of type int32 storing max-possible code of bit lenght 255.
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        private int[] DivideBytes(byte[] bytes)
        {
            
            int[] oldBytes = new int[bytes.Length];
            int[] newBytes = new int[bytes.Length*2];
            bytes.CopyTo(oldBytes, 0);
            int newBytesCounter = 0;
            for (int i = 0; i < oldBytes.Length; i++)
            {

                newBytes[newBytesCounter] = 0;
                for (int k = 7; k >= 4; k--)
                {
                    newBytes[newBytesCounter] = (newBytes[newBytesCounter] << 1) | (oldBytes[i] >> k) & 1;
                }

                newBytesCounter++;

                newBytes[newBytesCounter] = 0;
                for (int k = 3; k >= 0; k--)
                {
                    newBytes[newBytesCounter] = (newBytes[newBytesCounter] << 1) | (oldBytes[i] >> k) & 1;
                }

                newBytesCounter++;

               
            }

            return newBytes;
        }

        /// <summary>
        /// Sets all the frequencies to the initial value of 0. 
        /// </summary>
        private void FillTableWithZeroes()
        {
            for (int @byte = MinTableIndex; @byte <= MaxTableIndex; @byte++)
            {
                this[@byte] = 0;
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Get the string representing the table (made for testing purposes).
        /// </summary>
        /// <returns>String representation of the table.</returns>
        public override string ToString()
        {
            string result = "";
            for (int @byte = MinTableIndex; @byte <= MaxTableIndex; @byte++)
                /*for each frequency in the table */
            {
                if (this[@byte] != 0)
                    /* if the frequency is not 0 */
                {
                    /* print it as: byte - frequency */
                    result += "\n" +
                              Convert.ToString(@byte, 2) // get string with the binary representation of the byte   
                              + " - " + this[@byte];
                }
            }

            return result;
        }

        #endregion
    }
}