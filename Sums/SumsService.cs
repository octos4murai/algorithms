using System;
using System.Collections.Generic;

namespace Sums
{
    public static class SumsService
    {
        // Given an array of numbers, find all instances of the given value
        // and return a list of the matching indices.
        public static List<int> OneSum(int[] nums, int val)
        {
            var foundList = new List<int>();

            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == val)
                    foundList.Add(i);
            }

            return foundList;
        }
    }
}
