using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using BackEnd;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BackEndTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var freqTableStream = new FileStream("FrequencyTableTest.in", FileMode.Open, FileAccess.Read);
            var bytes = new byte[freqTableStream.Length];
            freqTableStream.Read(bytes, 0, (int) freqTableStream.Length);
            var frequencyTable = new FrequencyTable(bytes);

            var fileStream = new FileStream("serializedFrequencyTable.out", FileMode.Create, FileAccess.Write);
            var binaryFormatter = new BinaryFormatter();
            binaryFormatter.Serialize(fileStream, frequencyTable);
        }

        [TestMethod]
        public void ArchiveTest1()
        {
            var archive = new Archive("archive");
            archive.AddFile("123.doc");
            archive.AddFile("123.txt");
            archive.Close();
        }

        [TestMethod]
        public void FileEndTest()
        {
            var fileStream = File.OpenRead("123.doc");

            for (var i = 1; i <= fileStream.Length + 5; i++) Console.WriteLine("{0}:{1}", i, fileStream.ReadByte());
        }
    }
}