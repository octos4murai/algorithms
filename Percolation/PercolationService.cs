using DynamicConnectivity;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Percolation
{
    public class PercolationService
    {
        // -----
        // Toggle for debugging
        // -----
        // private readonly QuickFind solver;
        private readonly QuickUnionService solver;
        // -----

        private int[] _siteStates;
        private int _numOpenSites;
        private int _numSites;

        // Create an n-by-n grid, with all sites initially blocked.
        public PercolationService(int n)
        {
            _numSites = n * n;

            // -----
            // Toggle for debugging
            // -----
            // Add two for dummy start node and dummy end node.
            // solver = new QuickFind(_numSites + 2);
            // solver = new QuickUnionService(_numSites + 2);
            solver = new QuickUnionService(_numSites + 2, QuickUnionService.Mode.WEIGHTED);
            // solver = new QuickUnionService(_numSites + 2, QuickUnionService.Mode.WEIGHTED_COMPRESSED);
            // -----

            // Initialize all sites with state 0, meaning blocked.
            _siteStates = new int[_numSites];

            // Set up dummy start node and dummy end node.
            for (int i = 0; i < n; i++)
            {
                Open(0, i);
                solver.Union(GridToArrayIndex(0, i), _numSites);

                Open(n - 1, i);
                solver.Union(GridToArrayIndex(n - 1, i), _numSites + 1);
            }
        }

        public void Open(int row, int col)
        {
            int SITE_STATES_OPEN = 1;

            if (_siteStates[GridToArrayIndex(row, col)] == SITE_STATES_OPEN)
                return;

            _siteStates[GridToArrayIndex(row, col)] = SITE_STATES_OPEN;
            _numOpenSites++;

            foreach (Direction d in Enum.GetValues(typeof(Direction)))
            {
                if (TryGetNeighbour(row, col, d, out (int Row, int Col) neighbour))
                {
                    if (IsOpen(neighbour.Row, neighbour.Col))
                        solver.Union(GridToArrayIndex(row, col), GridToArrayIndex(neighbour.Row, neighbour.Col));
                }
            }
        }

        public void Open(int x)
        {
            (int Row, int Col) site = ArrayToGridIndex(x);
            Open(site.Row, site.Col);
        }

        // Check if the site is open
        public bool IsOpen(int row, int col)
        {
            int SITE_STATES_OPEN = 1;
            return _siteStates[GridToArrayIndex(row, col)] == SITE_STATES_OPEN;
        }

        // Return number of open sites
        public int NumberOfOpenSites()
        {
            return _numOpenSites;
        }

        public bool DoesPercolate()
        {
            return solver.Find(_numSites, _numSites + 1);
        }

        public List<int> GetAllBlockedSites()
        {
            var blockedSites = new List<int>();

            for (int i = 0; i < _siteStates.Length; i++)
            {
                int SITE_STATES_OPEN = 1;
                if (_siteStates[i] != SITE_STATES_OPEN)
                {
                    blockedSites.Add(i);
                }
            }

            return blockedSites;
        }

        private bool TryGetNeighbour(int row, int col, Direction dir, out (int Row, int Col) neighbour)
        {
            neighbour.Row = row;
            neighbour.Col = col;
            bool isOutOfBounds = false;
            int n = (int)Math.Sqrt(_numSites);

            switch (dir)
            {
                case Direction.UP:
                    if (row <= 0) isOutOfBounds = true;
                    neighbour.Row--;
                    break;

                case Direction.DOWN:
                    if (row >= n - 1) isOutOfBounds = true;
                    neighbour.Row++;
                    break;

                case Direction.LEFT:
                    if (col <= 0) isOutOfBounds = true;
                    neighbour.Col--;
                    break;

                case Direction.RIGHT:
                    if (col >= n - 1) isOutOfBounds = true;
                    neighbour.Col++;
                    break;

                default:
                    throw new InvalidEnumArgumentException();
            }

            return !isOutOfBounds;
        }

        private int GridToArrayIndex(int row, int col)
        {
            int n = (int)Math.Sqrt(_numSites);
            return (row * n) + col;
        }

        private (int Row, int Col) ArrayToGridIndex(int x)
        {
            int n = (int)Math.Sqrt(_numSites);
            return (x / n, x % n);
        }

        private enum Direction { 
            UP,
            DOWN,
            LEFT,
            RIGHT
        }
    }
}
