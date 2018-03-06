using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using BackEnd;
using BackEnd.Tree;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BackEndTests
{
    [TestClass]
    public class EncodingTests
    {
        [TestMethod]
        public void EncodingTest1()
        {
            FileStream fileStream = new FileStream("FrequencyTableTest.in", FileMode.Open, FileAccess.Read);
            byte[] bytes = new byte[fileStream.Length];
            fileStream.Read(bytes, 0, (int)fileStream.Length);
            FrequencyTable frequencyTable = new FrequencyTable(bytes);

            HuffmanTree huffmanTree = new HuffmanTree(frequencyTable);
            EncodingTable encodingTable = new EncodingTable(huffmanTree);
            Console.WriteLine(encodingTable.ToString());

        }
    }
}
