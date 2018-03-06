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
            FileStream fileStream = new FileStream("FrequencyTableTest.in", FileMode.Open, FileAccess.Read);
            byte[] bytes = new byte[fileStream.Length];
            fileStream.Read(bytes, 0, (int) fileStream.Length); 
            FrequencyTable frequencyTable = new FrequencyTable(bytes);
            Console.WriteLine(frequencyTable.ToString());
        }
        
        
        private void GenerateByteStream()
        {
            FileStream fileStream = new FileStream("FrequencyTableTest.in", FileMode.Create, FileAccess.Write);
            BitWriter bitWriter = new BitWriter(fileStream);
            for (int @byte = 0; @byte <= byte.MaxValue; @byte++)
            {
                for (int _numBitsRemaining = 7; _numBitsRemaining >= 0; _numBitsRemaining--)
                {
                    bitWriter.Write((@byte >> _numBitsRemaining) & 1);
                }
            }
            bitWriter.Dispose();
            fileStream.Dispose();
        }
    }
}