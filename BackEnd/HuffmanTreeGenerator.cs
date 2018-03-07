using System;
using System.Collections.Generic;
using System.Threading;
using BackEnd.Tree;

namespace BackEnd
{
    public class HuffmanTreeGenerator
    {
        #region Utility Classes

        /// <summary>
        /// Class used to store a node and its weight (i.e. total frequency) together. 
        /// </summary>
        private class WeightedNode : IComparable<WeightedNode>
        {
            public Node node;
            public long weight;
           public int CompareTo(WeightedNode other)
            {
                if (weight > other.weight)
                {
                    return 1;
                }

                if (weight < other.weight)
                {
                    return -1;
                }

                return 0;
            }
        }

        #endregion

        #region Methods

        public static Node GenerateHuffmanTree(FrequencyTable frequencyTable, out int height)
        {
            //TODO enhance this code (assuming that both arrays have the same lenght)
            /* check frequency table */
            if (frequencyTable == null)
            {
                throw new ArgumentNullException(nameof(frequencyTable), "The provided frequency table is null.");
            }
            
            /* set initial height */
            height = 0;
            
            /* the array contaning leaves of a tree */
            WeightedNode[] leaves = PackNodes(frequencyTable);
            Array.Sort(leaves);
            if (leaves.Length == 1)
            {
                return leaves[0].node;
                height = 1;
            }

            if (leaves.Length == 0)
            {
                return null;
            }
          
            /* the array containing internal nodes of a tree */
            WeightedNode[] internalNodes = new WeightedNode[leaves.Length-1]; // (because Huffman tree is a full binary tree the array containg leaves-1 elements)
            /* fill internailNodes with null values (null means node of infinite weight) */
            FillWithNull(ref internalNodes);

            /* the index of the current element of the leaves array */
            int leavesIndex = 0;
            /* the index of the current element of the internalNodes array */
            int internalNodesIndex = 0;

            int internalNodesEnd = 0;

            /* current sum value */
            long currentSum;
            
            /* current (withing a loop iteration) min sum value */
            long minSum;

            /* special marker variable for determining the exact two elements of the min sum */
            string status = "";
            
            
            for(int i = 0; i <= internalNodes.Length-1; i++)
                /* while  */
            {
                height += 1;
                minSum = long.MaxValue;
                
                if (leavesIndex + 1 < leaves.Length)
                    /* if two sequential elements (relating to leavesIndex) of leaves array exist */
                {
                    /* check if their sum is less than the min sum (and set it as the new min sum if so) */
                    currentSum = leaves[leavesIndex].weight + leaves[leavesIndex + 1].weight;
                    if (currentSum < minSum)
                    {
                        minSum = currentSum;
                        status = "leaves + leaves";
                    }
                }
                
                if (leavesIndex < leaves.Length && internalNodes[internalNodesIndex] != null)
                    /* if current internal node's weight is not equal to infinity */
                {
                    /* check if sum of current leaf and internal node is less than the min sum (and set it as the new min sum if so) */
                    currentSum = leaves[leavesIndex].weight + internalNodes[internalNodesIndex].weight;
                    if (currentSum < minSum)
                    {
                        minSum = currentSum;
                        status = "leaves + internalNodes";
                    }
                }
                if (internalNodes[internalNodesIndex] != null && internalNodesIndex + 1 < internalNodes.Length)
                        /* if two sequential elements (relating to internalNodesIndex) of internalNodes array exist */
                    {
                        if (internalNodes[internalNodesIndex + 1] != null)
                        {
                            /* check if sum of current leaf and internal node is less than the min sum (and set it as the new min sum if so) */
                            currentSum = internalNodes[internalNodesIndex].weight +
                                         internalNodes[internalNodesIndex + 1].weight;
                            if (currentSum < minSum)
                            {
                                minSum = currentSum;
                                status = "internalNodes + internalNodes";
                            }
                        }
                    }    
                

                WeightedNode w1, w2; 

                switch (status)
                {
                        case "leaves + leaves":
                            w1 = leaves[leavesIndex];
                            w2 = leaves[leavesIndex + 1];
                            internalNodes[internalNodesEnd++] = new WeightedNode()
                            {
                                node = new InternalNode(w1.node, w2.node),
                                weight = w1.weight + w2.weight
                            };
                            leavesIndex += 2;
                            break;
                        case "leaves + internalNodes":
                            w1 = leaves[leavesIndex];
                            w2 = internalNodes[internalNodesIndex];
                            internalNodes[internalNodesEnd++] = new WeightedNode()
                            {
                                node = new InternalNode(w1.node, w2.node),
                                weight = w1.weight + w2.weight
                            };
                            leavesIndex += 1;
                            internalNodesIndex += 1;
                            break;
                        case "internalNodes + internalNodes":
                            w1 = internalNodes[internalNodesIndex];
                            w2 = internalNodes[internalNodesIndex + 1];
                            internalNodes[internalNodesEnd++] = new WeightedNode()
                            {
                                node = new InternalNode(w1.node, w2.node),
                                weight = w1.weight + w2.weight
                            };
                            internalNodesIndex += 2;
                            break; 
                        default:
                            throw new NotImplementedException();
                            
                }
                
            }

            return internalNodes[internalNodes.Length - 1].node;


        }


        #region Utility Methods

        /// <summary>
        /// Packs non-zero frequency bytes to Huffman tree leaves and joins it to corresponding bytes' frequencies. 
        /// </summary>
        /// <param name="freq">The frequency table to get nodes from.</param>
        /// <returns>Weighted nodes containing Huffman tree leaves and their weights.</returns>
        private static WeightedNode[] PackNodes(FrequencyTable freq)
        {
            List<WeightedNode> weightedNodes = new List<WeightedNode>();

            for (int @byte = byte.MinValue; @byte <= byte.MaxValue; @byte++)
                /* for each byte in the frequency table */
            {
                if (freq[@byte] != 0)
                    /* if the byte occurs in the stream at least once */
                {
                    /* add the Huffman tree leaf containing this byte and the weight of the byte to the list */
                    weightedNodes.Add(new WeightedNode() {node = new Leaf(@byte), weight = freq[@byte]});
                }
            }

            return weightedNodes.ToArray();
        }

        /// <summary>
        /// Fills <paramref name="arr"/> with null values.
        /// </summary>
        /// <param name="arr">An array to be filled.</param>
        private static void FillWithNull(ref WeightedNode[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = null;
            }
        }

        #endregion

        #endregion
    }
}