using System;

namespace BinarySearch
{
    public static class BinarySearchService
    {
        // Given a sorted array, return the index of a given value.
        public static int Run(int[] nums, int val)
        {
            if (nums.Length == 0)
                return -1;

            int lowerBound = 0;
            int upperBound = nums.Length - 1;
            int middleVal = (lowerBound + upperBound) / 2;

            throw new NotImplementedException();
        }
    }
}
