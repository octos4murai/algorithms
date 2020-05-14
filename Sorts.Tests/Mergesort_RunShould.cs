using System;
using Xunit;

namespace Sorts.Tests
{
    public class Mergesort_RunShould
    {
        [Theory]
        [InlineData(0)]
        [InlineData(2, 1)]
        [InlineData(2, 1, 0, -3, 7, 4, 3, 8, 6, -4)]
        public void Run_RecursiveWithIntegers_SortArray(params int[] arr)
        {
            var origArr = new int[arr.Length];
            Array.Copy(arr, origArr, arr.Length);

            Mergesort<int>.Run(arr);

            for (int i = 1; i < arr.Length; i++)
                Assert.False(arr[i] < arr[i - 1]);

            Assert.Equal(arr.Length, origArr.Length);
        }

        [Theory]
        [InlineData("foo")]
        [InlineData("foo", "bar")]
        [InlineData("foo", "", "bar", "par", "23")]
        public void Run_RecursiveWithStrings_SortArray(params string[] arr)
        {
            var origArr = new string[arr.Length];
            Array.Copy(arr, origArr, arr.Length);

            Mergesort<string>.Run(arr);

            for (int i = 1; i < arr.Length; i++)
                Assert.NotEqual(-1, arr[i].CompareTo(arr[i - 1]));

            Assert.Equal(arr.Length, origArr.Length);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(2, 1)]
        [InlineData(2, 1, 0, -3, 7, 4, 3, 8, 6, -4)]
        public void Run_BottomUpWithIntegers_SortArray(params int[] arr)
        {
            var origArr = new int[arr.Length];
            Array.Copy(arr, origArr, arr.Length);

            Mergesort<int>.Run(arr, Mergesort<int>.MergesortType.BOTTOM_UP);

            for (int i = 1; i < arr.Length; i++)
                Assert.False(arr[i] < arr[i - 1]);

            Assert.Equal(arr.Length, origArr.Length);
        }

        [Theory]
        [InlineData("foo")]
        [InlineData("foo", "bar")]
        [InlineData("foo", "", "bar", "par", "23")]
        public void Run_BottomUpWithStrings_SortArray(params string[] arr)
        {
            var origArr = new string[arr.Length];
            Array.Copy(arr, origArr, arr.Length);

            Mergesort<string>.Run(arr, Mergesort<string>.MergesortType.BOTTOM_UP);

            for (int i = 1; i < arr.Length; i++)
                Assert.NotEqual(-1, arr[i].CompareTo(arr[i - 1]));

            Assert.Equal(arr.Length, origArr.Length);
        }
    }
}
