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

        [TestMethod]
        public void EncodingTest2()
        {
            GenerateByteStream("EncodingTest2", 15, 15, false);
            FileStream fileStream = new FileStream("EncodingTest2", FileMode.Open, FileAccess.Read);
            byte[] bytes = new byte[fileStream.Length];
            fileStream.Read(bytes, 0, (int)fileStream.Length);
            FrequencyTable frequencyTable = new FrequencyTable(bytes);

            HuffmanTree huffmanTree = new HuffmanTree(frequencyTable);
            EncodingTable encodingTable = new EncodingTable(huffmanTree);
            Console.WriteLine(encodingTable.ToString());
        }

        [TestMethod]
        public void EncodingTest3()
        {
            GenerateByteStream("EncodingTest3", 15, 16, false);
            FileStream fileStream = new FileStream("EncodingTest3", FileMode.Open, FileAccess.Read);
            byte[] bytes = new byte[fileStream.Length];
            fileStream.Read(bytes, 0, (int)fileStream.Length);
            FrequencyTable frequencyTable = new FrequencyTable(bytes);

            HuffmanTree huffmanTree = new HuffmanTree(frequencyTable);
            EncodingTable encodingTable = new EncodingTable(huffmanTree);
            Console.WriteLine(encodingTable.ToString());
        }
        [TestMethod]
        public void EncodingTest4()
        {
            GenerateByteStream("EncodingTest4", 0, 16, true);
            FileStream fileStream = new FileStream("EncodingTest4", FileMode.Open, FileAccess.Read);
            byte[] bytes = new byte[fileStream.Length];
            fileStream.Read(bytes, 0, (int)fileStream.Length);
            FrequencyTable frequencyTable = new FrequencyTable(bytes);
            Console.WriteLine(frequencyTable.ToString());

            HuffmanTree huffmanTree = new HuffmanTree(frequencyTable);
            EncodingTable encodingTable = new EncodingTable(huffmanTree);
            Console.WriteLine(encodingTable.ToString());
        }

        private void GenerateByteStream(string filename, int min, int max, bool random)
        {
            FileStream fileStream = new FileStream(filename, FileMode.Create, FileAccess.Write);
            BitWriter bitWriter = new BitWriter(fileStream);
            Random rand = new Random();
            for (int @byte = min; @byte <= max; @byte++)
            {
                if (random)
                {
                    for (int i = 0; i < rand.Next(5000); i++)
                    {
                        for (int _numBitsRemaining = 7; _numBitsRemaining >= 0; _numBitsRemaining--)
                        {
                            bitWriter.Write((@byte >> _numBitsRemaining) & 1);
                        }
                    }
                }
                else
                {
                    for (int _numBitsRemaining = 7; _numBitsRemaining >= 0; _numBitsRemaining--)
                    {
                        bitWriter.Write((@byte >> _numBitsRemaining) & 1);
                    }
                }
                
               
            }
            bitWriter.Dispose();
            fileStream.Dispose();
        }
    }
}
