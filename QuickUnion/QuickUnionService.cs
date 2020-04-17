using System;

namespace QuickUnion
{
    public class QuickUnionService
    {
        public int[] Nodes { get; }

        public QuickUnionService(int[] nodes)
        {
            Nodes = nodes;
        }

        // Given two indices, determines if there is a path between the two.
        public bool Find(int x, int y)
        {
            return Nodes[GetRootNodeIndex(x)] == Nodes[GetRootNodeIndex(y)];
        }

        // Traverse up the tree of nodes until the root is found and return its index.
        private int GetRootNodeIndex(int x)
        {
            int currentIndex = x;
            while (Nodes[currentIndex] != currentIndex)
            {
                currentIndex = Nodes[currentIndex];
            }

            return currentIndex;
        }

        // Given two indices, sets a path between the two.
        public void Union(int x, int y)
        {
            Nodes[GetRootNodeIndex(x)] = y;
        }
    }
}
