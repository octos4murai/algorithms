using BinarySearch;
using System;
using System.Collections.Generic;

namespace Sums
{
    public static class SumsService
    {
        // Given an array of numbers and a value, return the pair of elements that add up to the value.
        public static (int, int) TwoSum(int[] nums, int val)
        {
            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = i + 1; j < nums.Length; j++)
                {
                    if (nums[i] + nums[j] == val)
                        return (nums[i], nums[j]);
                }
            }

            return (-1, -1);
        }

        // Given an array of numbers and a value, return the three elements that add up to the value.
        public static (int, int, int) ThreeSum(int[] nums, int val)
        {
            var numsList = new List<int>(nums);
            numsList.Sort();

            for (int i = 0; i < numsList.Count; i++)
            {
                for (int j = i + 1; j < numsList.Count; j++)
                {
                    var missingNum = val - (numsList[i] + numsList[j]);
                    int missingNumIndex = BinarySearchService.Run(numsList.ToArray(), missingNum);

                    if (missingNumIndex != -1)
                        return (numsList[i], numsList[j], numsList[missingNumIndex]);
                }
            }

            return (-1, -1, -1);
        }
    }
}
