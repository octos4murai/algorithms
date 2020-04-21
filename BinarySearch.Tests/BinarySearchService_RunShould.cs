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
        public void Run_ValueNotInArray_ReturnErrorValue(int[] nums, int val)
        {
            int ERROR_VALUE = -1;
            Assert.Equal(BinarySearchService.Run(nums, val), ERROR_VALUE);
        }
    }
}
