using System.IO;
using BackEnd;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BackEndTests
{
    [TestClass]
    public class BitWriterTests
    {
        /// <summary>
        ///     Tests how BitWriter treats a complete bit stream.
        /// </summary>
        [TestMethod]
        public void BitWriterTest1()
        {
            var stream = new FileStream("BitWriterTest1.out", FileMode.Create, FileAccess.Write);
            var bitWriter = new BitWriter(stream);
            bitWriter.Write(0);
            bitWriter.Write(1);
            bitWriter.Write(0);
            bitWriter.Write(0);
            bitWriter.Write(0);
            bitWriter.Write(0);
            bitWriter.Write(0);
            bitWriter.Write(1);
            bitWriter.Dispose();
            stream.Dispose();
        }

        /// <summary>
        ///     Tests how BitWriter treats a non-complete bit stream.
        /// </summary>
        [TestMethod]
        public void BitWriterTest2()
        {
            var stream = new FileStream("BitWriterTest2.out", FileMode.Create, FileAccess.Write);
            var bitWriter = new BitWriter(stream);
            bitWriter.Write(0);
            bitWriter.Write(1);
            bitWriter.Dispose();
            stream.Dispose();
        }
    }
}