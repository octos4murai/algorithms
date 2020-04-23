using Sums;
using System;
using System.Collections.Generic;
using Xunit;

namespace Sums.Tests
{
    public class SumsService_OneSumShould
    {
        [Theory]
        [InlineData(new int[] { }, 2)]
        [InlineData(new int[] { 1 }, 0)]
        [InlineData(new int[] { 4, 3, 7, 9, 0 }, 5)]
        public void OneSum_ValueNotInArray_ReturnErrorValue(int[] nums, int val)
        {
            int ERROR_VALUE = -1;
            Assert.Equal(ERROR_VALUE, SumsService.OneSum(nums, val));
        }

        [Theory]
        [InlineData(new int[] { 2 }, 2, 0)]
        [InlineData(new int[] { 1, 2 }, 1, 0)]
        [InlineData(new int[] { 1, 2 }, 2, 1)]
        [InlineData(new int[] { 4, 3, 7, 9, 3 }, 3, 1)]
        [InlineData(new int[] { 7, 3, 7, 9, 0 }, 0, 4)]
        public void OneSum_ValueInArray_ReturnIndex(int[] nums, int val, int result)
        {
            Assert.Equal(result, SumsService.OneSum(nums, val));
        }
    }
}
