using System;
using System.IO;

namespace BackEnd
{
    public class BitReader : IDisposable
    {
        #region Fields

        /// <summary>
        /// The stream to read bits from (not null).
        /// </summary>
        private Stream _inputStream;

        /// <summary>
        /// The value of the current byte in the stream. Equals to -1 if the end of the stream is reached.
        /// </summary>
        private int _currentByte;

        /// <summary>
        /// Number of remaining bits in the current byte to be read. 
        /// </summary>
        private int _numBitsRemaining;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the BitReader class for the specified stream.
        /// </summary>
        /// <param name="inputStream">The stream to be read.</param>
        /// <exception cref="ArgumentNullException"><paramref name="inputStream"/> is <value>null</value>.</exception>
        /// <exception cref="ArgumentException"><paramref name="inputStream"/> does not support reading.</exception>
        public BitReader(Stream inputStream)
        {
            if (inputStream == null)
            {
                throw new ArgumentNullException();
            }

            if (inputStream.CanRead == false)
            {
                throw new ArgumentException();
            }

            _inputStream = inputStream;
            _numBitsRemaining = 0;
            _currentByte = 0;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Reads the next bit in the provided stream.  
        /// </summary>
        /// <returns>The next bit in the stream (0 or 1) or -1 if the end of the stream is reached.</returns>
        public int Read()
        {
            if (_currentByte == -1)
                /* if the end of the stream is reached and the next bit is being asked */
            {
                /* indicate that the end of the stream is reached */
                return -1;
            }

            if (_numBitsRemaining == 0)
                /* if the current byte has been completely read or the first byte is about to be read from the input stream */
            {
                _currentByte = _inputStream.ReadByte();
                if (_currentByte == -1)
                    /* if the end of the stream reached */
                {
                    /* indicate that the end of the stream is reached */
                    return -1;
                }

                _numBitsRemaining = 8;
            }

            _numBitsRemaining -= 1;

            /* get and return the value of the bit at the position (7 - _numBitsRemaining) of the current byte,
             * where _numBitsRemaining gets values from 7 to 0 inclusively in the presented order */
            return (_currentByte >> _numBitsRemaining) & 1;
        }

        #endregion

        #region IDisposableImplementation

        private bool disposed = false;

        ~BitReader()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
                /* if Dispose() hasn't been called yet */
            {
                if (disposing)
                {
                    _inputStream.Dispose();
                }

                disposed = true;
            }
        }

        #endregion
    }
}