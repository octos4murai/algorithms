using Sums;
using System;
using Xunit;

namespace Sums.Tests
{
    public class SumsService_ThreeSumShould
    {
        [Theory]
        [InlineData(new int[] { }, 2)]
        [InlineData(new int[] { 1, 2, 1 }, 0)]
        [InlineData(new int[] { 2, -2, 5 }, 3)]
        [InlineData(new int[] { 4, 3, 7, 9, 0 }, 5)]
        public void ThreeSum_SumNotInArray_ReturnErrorValue(int[] nums, int val)
        {
            (int, int, int) ERROR_VALUE = (-1, -1, -1);
            Assert.Equal(ERROR_VALUE, SumsService.ThreeSum(nums, val));
        }

        [Theory]
        [InlineData(new int[] { 2, -2, 5 }, 5, -2, 2, 5)]
        [InlineData(new int[] { 4, 3, 7, 9, 0 }, 12, 0, 3, 9)]

        public void ThreeSum_SumInArray_ReturnIndices(int[] nums, int val, int result1, int result2, int result3)
        {
            Assert.Equal((result1, result2, result3), SumsService.ThreeSum(nums, val));
        }
    }
}