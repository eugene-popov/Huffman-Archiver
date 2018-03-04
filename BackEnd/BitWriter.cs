using System;
using System.IO;

namespace BackEnd
{
    /// <summary>
    /// Utility class that purpose is to write binary data to a stream.
    /// </summary>
    public class BitWriter: IDisposable
    {
        #region Fields

        /// <summary>
        /// The stream to write bits to (not null).
        /// </summary>
        private Stream _outputStream;

        /// <summary>
        /// The value of the current byte being filled with specified bits.
        /// </summary>
        private int _currentByte;

        /// <summary>
        /// Number of filled bits in the current byte to be write. 
        /// </summary>
        private int _numBitsFilled;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the BitWriter class for the specified stream.
        /// </summary>
        /// <param name="outputStream">The stream to be written.</param>
        /// <exception cref="ArgumentNullException"><paramref name="outputStream"/> is <lang>null</value>.</exception>
        /// <exception cref="ArgumentException"><paramref name="outputStream"/>is not writable.</exception>
        public BitWriter(Stream outputStream)
        {
            if (outputStream == null)
            {
                throw new ArgumentNullException();
            }
            else
            {
                _outputStream = outputStream; 
                if (_outputStream.CanWrite == false)
                {
                    throw new ArgumentException();
                }

               
                _numBitsFilled = 0;
                _currentByte = 0;
            }

            
        }

        #endregion

        #region Methods

        /// <summary>
        /// Writes the next bit to the provided stream.  
        /// </summary>
        public void Write(int b)
        {
            if (b != 1 && b != 0)
                /* if the provided value can't be interpreted as a bit */
            {
                throw new ArgumentException();
            }

            /* write the provided bit to the end of the current byte */
            _currentByte = (_currentByte << 1) | b;
            _numBitsFilled += 1;

            if (_numBitsFilled == 8)
                /* if the current byte is completely formed */
            {
                /* write the current byte to the stream */
                _outputStream.WriteByte((byte) _currentByte);
                _currentByte = 0;
                _numBitsFilled = 0;
            }
        }

        /// <summary>
        /// Fills the remaining bits with zeroes.
        /// </summary>
        private void Close()
        {
            while (_numBitsFilled != 0)
            {
                Write(0);
            }
        }
        
        #endregion

        #region IDisposableImplementation

        private bool disposed = false;

        ~BitWriter()
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
                Close();
                if (disposing)
                {
                    _outputStream.Dispose();
                }

                disposed = true;
            }
        }

        #endregion
    }
}