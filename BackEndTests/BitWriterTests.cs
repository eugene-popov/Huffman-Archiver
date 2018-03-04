using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BackEnd;

namespace BackEndTests
{
    [TestClass]
    public class BitWriterTests
    {
        [TestMethod]
        public void BitWriterTest1()
        {
            var stream = new FileStream("BitWriterTest1.out", FileMode.Create, FileAccess.Write);
            BitWriter bitWriter = new BitWriter(stream);
            bitWriter.Write(0);
            bitWriter.Write(1);
            bitWriter.Write(0);
            bitWriter.Write(0);
            bitWriter.Write(0);
            bitWriter.Write(0);
            bitWriter.Write(0);
            bitWriter.Write(1);
            bitWriter.Dispose();
        }
        
        [TestMethod]
        public void BitWriterTest2()
        {
            var stream = new FileStream("BitWriterTest2.out", FileMode.Create, FileAccess.Write);
            BitWriter bitWriter = new BitWriter(stream);
            bitWriter.Write(0);
            bitWriter.Write(1);
            bitWriter.Dispose();
        }
    }
}