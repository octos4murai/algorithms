using Percolation;
using System.Collections.Generic;
using System;

namespace PercolationSimulator
{
    public class PercolationSimulator
    {
        public List<double> Results { get; private set; }

        public PercolationSimulator(int n, int trials)
        {
            Results = new List<double>();

            for (int i = 0; i < trials; i++)
            {
                // All sites are initially blocked.
                var ps = new PercolationService(n);
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

                Results.Add((numOpened / (double)(n * n)));
            }
        }

        public double GetMean()
        {
            double sum = 0;
            foreach (double r in Results)
            {
                sum += r;
            }

            return sum / (double)Results.Count;
        }

        public double GetVariance()
        {
            double mean = GetMean();
            double sum = 0;

            foreach (var r in Results)
            {
                double diff = r - mean;
                sum += (diff * diff);
            }

            return sum / (double)Results.Count;
        }

        public double GetStandardDeviation()
        {
            return Math.Sqrt(GetVariance());
        }

        public double ConfidenceLo()
        {
            double mean = GetMean();
            double sd = GetStandardDeviation();
            return mean - ((double)(1.96 * sd) / Math.Sqrt(Results.Count));
        }

        public double ConfidenceHi()
        {
            double mean = GetMean();
            double sd = GetStandardDeviation();
            return mean + ((double)(1.96 * sd) / Math.Sqrt(Results.Count));
        }
    }
}