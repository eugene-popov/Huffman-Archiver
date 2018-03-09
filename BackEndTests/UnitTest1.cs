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
            FileStream freqTableStream = new FileStream("FrequencyTableTest.in", FileMode.Open, FileAccess.Read);
            byte[] bytes = new byte[freqTableStream.Length];
            freqTableStream.Read(bytes, 0, (int)freqTableStream.Length);
            FrequencyTable frequencyTable = new FrequencyTable(bytes);

            FileStream fileStream = new FileStream("serializedFrequencyTable.out", FileMode.Create, FileAccess.Write);
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            binaryFormatter.Serialize(fileStream, frequencyTable);

        }
    }
}
