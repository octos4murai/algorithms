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
        public void OneSum_ValueNotInArray_ReturnEmptyList(int[] nums, int val)
        {
            Assert.Equal(new List<int>(), SumsService.OneSum(nums, val));
        }

        [Theory]
        [InlineData(new int[] { 2 }, 2, new int[] { 0 })]
        [InlineData(new int[] { 1, 2 }, 1, new int[] { 0 })]
        [InlineData(new int[] { 1, 2 }, 2, new int[] { 1 })]
        [InlineData(new int[] { 4, 3, 7, 9, 3 }, 3, new int[] { 1, 4 })]
        [InlineData(new int[] { 0, 3, 7, 9, 0 }, 0, new int[] { 0, 4 })]
        public void OneSum_ValueInArray_ReturnListOfIndices(int[] nums, int val, int[] results)
        {
            Assert.Equal(new List<int>(results), SumsService.OneSum(nums, val));
        }
    }
}
