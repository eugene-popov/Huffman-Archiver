using System;
using System.IO;
using BackEnd;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BackEndTests
{
    [TestClass]
    public class BitReaderTests
    {
        [TestMethod]
        public void BitReaderTest1()
        {
            var stream = new FileStream("BitWriterTest1.out", FileMode.Open, FileAccess.Read);
            BitReader bitReader = new BitReader(stream);
            int bit;
            do
            {
                bit = bitReader.Read();
                Console.Write(bit);
            } while (bit != -1);

        }
    }
}