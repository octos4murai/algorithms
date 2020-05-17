using System;
using Xunit;

namespace Sorts.Tests
{
    public class Quicksort_RunShould
    {
        [Theory]
        [InlineData(0)]
        [InlineData(2, 1)]
        [InlineData(2, 1, 0, -3, 7, 4, 3, 8, 6, -4)]
        public void Run_StandardWithIntegers_SortArray(params int[] arr)
        {
            var origArr = new int[arr.Length];
            Array.Copy(arr, origArr, arr.Length);

            Quicksort<int>.Run(arr);

            for (int i = 1; i < arr.Length; i++)
                Assert.False(arr[i] < arr[i - 1]);

            Assert.Equal(arr.Length, origArr.Length);
        }

        [Theory]
        [InlineData("foo")]
        [InlineData("foo", "bar")]
        [InlineData("foo", "", "bar", "par", "23")]
        public void Run_StandardWithStrings_SortArray(params string[] arr)
        {
            var origArr = new string[arr.Length];
            Array.Copy(arr, origArr, arr.Length);

            Quicksort<string>.Run(arr);

            for (int i = 1; i < arr.Length; i++)
                Assert.NotEqual(-1, arr[i].CompareTo(arr[i - 1]));

            Assert.Equal(arr.Length, origArr.Length);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(2, 1)]
        [InlineData(2, 1, 0, -3, 7, 4, 3, 8, 6, -4)]
        public void Run_ThreeWayWithIntegers_SortArray(params int[] arr)
        {
            var origArr = new int[arr.Length];
            Array.Copy(arr, origArr, arr.Length);

            Quicksort<int>.Run(arr, Quicksort<int>.QuicksortType.THREE_WAY);

            for (int i = 1; i < arr.Length; i++)
                Assert.False(arr[i] < arr[i - 1]);

            Assert.Equal(arr.Length, origArr.Length);
        }

        [Theory]
        [InlineData("foo")]
        [InlineData("foo", "bar")]
        [InlineData("foo", "", "bar", "par", "23")]
        public void Run_ThreeWayWithStrings_SortArray(params string[] arr)
        {
            var origArr = new string[arr.Length];
            Array.Copy(arr, origArr, arr.Length);

            Quicksort<string>.Run(arr, Quicksort<string>.QuicksortType.THREE_WAY);

            for (int i = 1; i < arr.Length; i++)
                Assert.NotEqual(-1, arr[i].CompareTo(arr[i - 1]));

            Assert.Equal(arr.Length, origArr.Length);
        }
    }
}
