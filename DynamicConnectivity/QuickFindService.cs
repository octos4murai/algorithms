namespace DynamicConnectivity
{
    public class QuickFindService
    {
        public int[] Nodes { get; }

        public QuickFindService(int numNodes)
        {
            var nodes = new int[numNodes];
            for (int i = 0; i < nodes.Length; i++)
            {
                nodes[i] = i;
            }

            Nodes = nodes;
        }

        public QuickFindService(int[] nodes)
        {
            Nodes = nodes;
        }

        // Given two indices, determines if there is a path between the two.
        public bool Find(int x, int y)
        {
            return Nodes[x] == Nodes[y];
        }

        // Given two indices, sets a path between the two.
        public void Union(int x, int y)
        {
            int xVal = Nodes[x];
            int yVal = Nodes[y];
            for (int i = 0; i < Nodes.Length; i++)
            {
                if (Nodes[i] == xVal)
                {
                    Nodes[i] = yVal;
                }
            }
        }
    }
}
