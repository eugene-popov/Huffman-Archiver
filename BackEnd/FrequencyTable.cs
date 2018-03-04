﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd
{
    /// <summary>
    /// Utility class that represents the frequency table containing frequencies for each byte. 
    /// </summary>
    class FrequencyTable
    {
        #region Fields

        /// <summary>
        /// Number of byte frequencies the table contains (256). 
        /// </summary>
        private const int FreqsInTable = byte.MaxValue + 1;

        /// <summary>
        /// Max index (or byte value) the table can address.
        /// </summary>
        private const int MinTableIndex = byte.MinValue;

        /// <summary>
        /// Min index (or byte value) the table can address.
        /// </summary>
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
        /// <param name="byteValue">Table index of value between 0 and 255.</param>
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
            FillTableWithZeroes();
            foreach (var @byte in bytes)
            {
                this[@byte] += 1;
            }
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
        private new string ToString()
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
                              Convert.ToString(@byte, 2)
                                  .Substring(24, 8) // get string with the binary representation of the byte   
                              + " - " + this[@byte];
                }
            }

            return result;
        }

        #endregion
    }
}