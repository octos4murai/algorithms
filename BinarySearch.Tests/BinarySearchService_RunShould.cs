using BinarySearch;
using System;
using Xunit;

namespace BinarySearch.Tests
{
    public class BinarySearchService_RunShould
    {
        [Theory]
        [InlineData(new int[] { 1, 2, 3, 4, 5 }, 0)]
        [InlineData(new int[] { 0, 2, 3, 4, 5 }, 1)]
        [InlineData(new int[] {}, 1)]
        [InlineData(new int[] { 0 }, 1)]
        [InlineData(new int[] { 0, 2 }, 1)]
        public void Run_ValueNotInArray_ReturnErrorValue(int[] nums, int val)
        {
            int ERROR_VALUE = -1;
            Assert.Equal(ERROR_VALUE, BinarySearchService.Run(nums, val));
        }

        [Theory]
        [InlineData(new int[] { 1, 2, 3, 4, 5 }, 1, 0)]
        [InlineData(new int[] { 1, 2, 3, 4, 5 }, 5, 4)]
        [InlineData(new int[] { 0, 1, 3, 8, 9 }, 3, 2)]
        [InlineData(new int[] { 3 }, 3, 0)]
        [InlineData(new int[] { 3, 5 }, 5, 1)]
        public void Run_ValueInArray_ReturnIndex(int[] nums, int val, int result)
        {
            Assert.Equal(result, BinarySearchService.Run(nums, val));
        }
    }
}
