using System;
using System.IO;
using BackEnd;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BackEndTests
{
    [TestClass]
    public class FrequencyTableTests
    {
        [TestMethod]
        public void FrequencyTableTest1()
        {
            GenerateByteStream();
            var fileStream = new FileStream("FrequencyTableTest.in", FileMode.Open, FileAccess.Read);
            var bytes = new byte[fileStream.Length];
            fileStream.Read(bytes, 0, (int) fileStream.Length);
            var frequencyTable = new FrequencyTable(bytes);
            Console.WriteLine(frequencyTable.ToString());
        }


        private void GenerateByteStream()
        {
            var fileStream = new FileStream("FrequencyTableTest.in", FileMode.Create, FileAccess.Write);
            var bitWriter = new BitWriter(fileStream);
            for (var @byte = 0; @byte <= byte.MaxValue; @byte++)
            for (var _numBitsRemaining = 7; _numBitsRemaining >= 0; _numBitsRemaining--)
                bitWriter.Write((@byte >> _numBitsRemaining) & 1);

            bitWriter.Dispose();
            fileStream.Dispose();
        }
    }
}