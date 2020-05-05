using System.ComponentModel;

namespace DynamicConnectivity
{
    public class QuickUnionService
    {
        public int[] Nodes { get; }
        private int[] _sizes;
        private Mode _selectedMode;

        public QuickUnionService(int numNodes, Mode mode = Mode.SIMPLE)
        {
            var nodes = new int[numNodes];
            for (int i = 0; i < nodes.Length; i++)
            {
                nodes[i] = i;
            }

            Nodes = nodes;

            _selectedMode = mode;

            if (_selectedMode == Mode.WEIGHTED || _selectedMode == Mode.WEIGHTED_COMPRESSED)
            {
                _sizes = new int[nodes.Length];
                for (int i = 0; i < _sizes.Length; i++)
                {
                    _sizes[i] = 1;
                }
            }
        }

        public QuickUnionService(int[] nodes, Mode mode = Mode.SIMPLE)
        {
            Nodes = nodes;
            _selectedMode = mode;

            if (_selectedMode == Mode.WEIGHTED || _selectedMode == Mode.WEIGHTED_COMPRESSED)
            {
                _sizes = new int[nodes.Length];
                for (int i = 0; i < _sizes.Length; i++)
                {
                    _sizes[i] = 1;
                }
            }
        }

        // Given two indices, determines if there is a path between the two.
        public bool Find(int x, int y)
        {
            return Nodes[GetRootNodeIndex(x)] == Nodes[GetRootNodeIndex(y)];
        }

        // Given two indices, sets a path between the two.
        public void Union(int x, int y)
        {
            switch (_selectedMode)
            {
                case Mode.SIMPLE:
                    UnionBasic(x, y);
                    break;

                case Mode.WEIGHTED:
                    UnionWeighted(x, y);
                    break;

                case Mode.WEIGHTED_COMPRESSED:
                    UnionCompressed(x, y);
                    break;

                default:
                    throw new InvalidEnumArgumentException();
            }
        }

        private void UnionBasic(int x, int y)
        {
            Nodes[GetRootNodeIndex(x)] = GetRootNodeIndex(y);
        }

        private void UnionWeighted(int x, int y)
        {
            var xRootIndex = GetRootNodeIndex(x);
            var yRootIndex = GetRootNodeIndex(y);

            if (xRootIndex == yRootIndex) return;

            if (_sizes[xRootIndex] < _sizes[yRootIndex])
            {
                _sizes[yRootIndex] += _sizes[xRootIndex];
                Nodes[xRootIndex] = yRootIndex;
                return;
            }

            _sizes[xRootIndex] += _sizes[yRootIndex];
            Nodes[yRootIndex] = xRootIndex;
        }

        private void UnionCompressed(int x, int y)
        {
            var xRootIndex = GetRootNodeIndex(x);
            var yRootIndex = GetRootNodeIndex(y);

            if (xRootIndex == yRootIndex) return;

            if (_sizes[xRootIndex] < _sizes[yRootIndex])
            {
                CompressTree(x, xRootIndex);
                _sizes[yRootIndex] += _sizes[xRootIndex];
                Nodes[xRootIndex] = yRootIndex;
                return;
            }

            CompressTree(y, yRootIndex);
            _sizes[xRootIndex] += _sizes[yRootIndex];
            Nodes[yRootIndex] = xRootIndex;
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

        // Traverse up the tree of nodes, pointing each node to the root.
        private void CompressTree(int x, int rootIndex)
        {
            int currentIndex = x;
            while (Nodes[currentIndex] != rootIndex)
            {
                int previousIndex = currentIndex;
                currentIndex = Nodes[currentIndex];
                Nodes[previousIndex] = rootIndex;
            }
        }

        public enum Mode
        {
            SIMPLE,
            WEIGHTED,
            WEIGHTED_COMPRESSED
        }
    }
}
