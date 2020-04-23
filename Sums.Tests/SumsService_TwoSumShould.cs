using Sums;
using System;
using System.Collections.Generic;
using Xunit;

namespace Sums.Tests
{
    public class SumsService_TwoSumShould
    {
        [Theory]
        [InlineData(new int[] { }, 2)]
        [InlineData(new int[] { 1, 2 }, 0)]
        [InlineData(new int[] { 2, -2 }, 2)]
        [InlineData(new int[] { 4, 3, 7, 9, 0 }, 5)]
        public void TwoSum_SumNotInArray_ReturnErrorValue(int[] nums, int val)
        {
            (int, int) ERROR_VALUE = (-1, -1);
            Assert.Equal(ERROR_VALUE, SumsService.TwoSum(nums, val));
        }

        [Theory]
        [InlineData(new int[] { 1, 2 }, 3, 0, 1)]
        [InlineData(new int[] { 2, 0, -2, 2 }, 0, 0, 2)]
        [InlineData(new int[] { 4, 3, 7, 9, 0 }, 3, 1, 4)]
        [InlineData(new int[] { 4, 3, 7, 9, -3 }, 0, 1, 4)]
        [InlineData(new int[] { 1, 3, 7, 9, 0 }, 16, 2, 3)]
        public void TwoSum_ValueInArray_ReturnIndices(int[] nums, int val, int result1, int result2)
        {
            Assert.Equal((result1, result2), SumsService.TwoSum(nums, val));
        }
    }
}
