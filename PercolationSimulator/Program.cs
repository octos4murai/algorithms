using Percolation;
using System;
using System.Collections.Generic;

namespace PercolationSimulator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            // All sites are initially blocked.
            var ps = new PercolationService(20);

            int numOpened = 0;
            while (!ps.DoesPercolate())
            {
                // Randomly select a blocked site.
                List<int> blockedSites = ps.GetAllBlockedSites();
                var r = new Random();
                int randomIndex = r.Next(blockedSites.Count);
                int randomSite = blockedSites[randomIndex];

                // Open random blocked site.
                ps.Open(randomSite);
                numOpened++;
            }

            Console.WriteLine(numOpened);
        }
    }
}
