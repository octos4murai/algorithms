using System;
using System.Diagnostics;

namespace PercolationSimulator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var stopwatch = new Stopwatch();
            stopwatch.Start();

            var ps = new PercolationSimulator(200, 10);
            Console.WriteLine($"Mean: {ps.GetMean()}");
            Console.WriteLine($"SD: {ps.GetStandardDeviation()}");
            Console.WriteLine($"95% Confidence: [{ps.ConfidenceLo()}, {ps.ConfidenceHi()}]");

            stopwatch.Stop();
            Console.WriteLine($"Time Elapsed: {stopwatch.Elapsed}");
        }
    }
}
