using System;
using System.IO;
using BackEnd;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BackEndTests
{
    [TestClass]
    public class BitReaderTests
    {
        /// <summary>
        ///     Tests how BitReader reads a byte stream.
        /// </summary>
        [TestMethod]
        public void BitReaderTest1()
        {
            var stream = new FileStream("BitWriterTest1.out", FileMode.Open, FileAccess.Read);
            var bitReader = new BitReader(stream);
            var bit = bitReader.Read();
            while (bit != -1)
            {
                Console.Write(bit);
                bit = bitReader.Read();
            }

            bitReader.Dispose();
            stream.Dispose();
        }
    }
}