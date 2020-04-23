using System;
using System.Collections.Generic;

namespace Sums
{
    public static class SumsService
    {
        // Given an array of numbers and a value, return the index of the element
        // equivalent to the value.
        public static int OneSum(int[] nums, int val)
        {
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == val)
                    return i;
            }

            return -1;
        }

        // Given an array of numbers and a value, return the indexes of the pair
        // of elements that add up to the value, in ascending order.
        public static (int, int) TwoSum(int[] nums, int val)
        {
            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = i + 1; j < nums.Length; j++)
                {
                    if (nums[i] + nums[j] == val)
                        return (i, j);
                }
            }

            return (-1, -1);
        }

        // Given an array of numbers and a value, return the indexes of a set of
        // three elements that add up to the value, in ascending order.
        public static (int, int, int) ThreeSum(int[] nums, int val)
        {
            throw new NotImplementedException();
        }
    }
}
