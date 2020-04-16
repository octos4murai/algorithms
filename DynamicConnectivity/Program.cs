using QuickFind;
using System;

namespace DynamicConnectivity
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var nodes = new int[] { 5, 7, 2 };
            var qf = new QuickFindService(nodes);
            qf.Union(0, 1);
            // qf.Union(2, 0);

            // For debugging only
            // Console.WriteLine($"[{string.Join(", ", qf.Nodes)}]");
            Console.WriteLine(qf.Find(0, 2));
        }
    }
}
