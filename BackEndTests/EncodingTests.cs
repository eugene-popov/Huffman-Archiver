using System;
using System.IO;
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
            GenerateByteStream("EncodingTest1", 0, 255, false);
            var fileStream = new FileStream("EncodingTest1", FileMode.Open, FileAccess.Read);
            var bytes = new byte[fileStream.Length];
            fileStream.Read(bytes, 0, (int) fileStream.Length);
            var frequencyTable = new FrequencyTable(bytes);

            var huffmanTree = new HuffmanTree(frequencyTable);
            var encodingTable = new EncodingTable(huffmanTree);
            Console.WriteLine(encodingTable.ToString());
        }

        [TestMethod]
        public void EncodingTest2()
        {
            GenerateByteStream("EncodingTest2", 15, 15, false);
            var fileStream = new FileStream("EncodingTest2", FileMode.Open, FileAccess.Read);
            var bytes = new byte[fileStream.Length];
            fileStream.Read(bytes, 0, (int) fileStream.Length);
            var frequencyTable = new FrequencyTable(bytes);

            var huffmanTree = new HuffmanTree(frequencyTable);
            var encodingTable = new EncodingTable(huffmanTree);
            Console.WriteLine(encodingTable.ToString());
        }

        [TestMethod]
        public void EncodingTest3()
        {
            GenerateByteStream("EncodingTest3", 15, 16, false);
            var fileStream = new FileStream("EncodingTest3", FileMode.Open, FileAccess.Read);
            var bytes = new byte[fileStream.Length];
            fileStream.Read(bytes, 0, (int) fileStream.Length);
            var frequencyTable = new FrequencyTable(bytes);

            var huffmanTree = new HuffmanTree(frequencyTable);
            var encodingTable = new EncodingTable(huffmanTree);
            Console.WriteLine(encodingTable.ToString());
        }

        [TestMethod]
        public void EncodingTest4()
        {
            GenerateByteStream("EncodingTest4", 0, 16, true);
            var fileStream = new FileStream("EncodingTest4", FileMode.Open, FileAccess.Read);
            var bytes = new byte[fileStream.Length];
            fileStream.Read(bytes, 0, (int) fileStream.Length);
            var frequencyTable = new FrequencyTable(bytes);
            Console.WriteLine(frequencyTable.ToString());

            var huffmanTree = new HuffmanTree(frequencyTable);
            var encodingTable = new EncodingTable(huffmanTree);
            Console.WriteLine(encodingTable.ToString());
        }

        private void GenerateByteStream(string filename, int min, int max, bool random)
        {
            var fileStream = new FileStream(filename, FileMode.Create, FileAccess.Write);
            var bitWriter = new BitWriter(fileStream);
            var rand = new Random();
            for (var @byte = min; @byte <= max; @byte++)
                if (random)
                    for (var i = 0; i < rand.Next(5000); i++)
                    for (var _numBitsRemaining = 7; _numBitsRemaining >= 0; _numBitsRemaining--)
                        bitWriter.Write((@byte >> _numBitsRemaining) & 1);
                else
                    for (var _numBitsRemaining = 7; _numBitsRemaining >= 0; _numBitsRemaining--)
                        bitWriter.Write((@byte >> _numBitsRemaining) & 1);

            bitWriter.Dispose();
            fileStream.Dispose();
        }
    }
}