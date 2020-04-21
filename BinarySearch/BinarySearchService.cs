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

            while (lowerBound != upperBound)
            {
                if (nums[middleVal] < val)
                    lowerBound = middleVal == nums.Length - 1 ? middleVal : middleVal+ 1;
                else if (nums[middleVal] > val)
                    upperBound = middleVal == 0 ? middleVal : middleVal - 1;
                else
                    break;

                middleVal = (lowerBound + upperBound) / 2;
            }

            if (nums[middleVal] == val)
                return middleVal;

            return -1;
        }
    }
}
