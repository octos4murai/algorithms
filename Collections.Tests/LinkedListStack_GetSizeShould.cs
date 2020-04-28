using Collections;
using System;
using System.Collections.Generic;
using Xunit;

namespace Collections.Tests
{
    public class LinkedListStack_GetSizeShould
    {
        [Fact]
        public void GetSize_NewStack_ReturnZero()
        {
            var stack = new LinkedListStack<int>();
            Assert.Equal(0, stack.GetSize());
        }

        [Theory]
        [InlineData(5)]
        [InlineData(-1, 0)]
        [InlineData(9, -5, 2, 7, 1)]
        public void GetSize_NonEmptyStack_ReturnSize(params int[] nums)
        {
            var stack = new LinkedListStack<int>();

            foreach (int num in nums)
                stack.Push(num);

            Assert.Equal(nums.Length, stack.GetSize());
        }

        [Theory]
        [InlineData(1, 5)]
        [InlineData(0, -1, 0)]
        [InlineData(3, 9, -5, 2, 7, 1)]
        [InlineData(5, 9, -5, 2, 7, 1)]
        public void GetSize_PopElements_ReturnSize(int numToPop, params int[] nums)
        {
            var stack = new LinkedListStack<int>();

            foreach (int num in nums)
                stack.Push(num);

            for (int i = numToPop; i > 0; i--)
                stack.Pop();

            Assert.Equal(nums.Length - numToPop, stack.GetSize());
        }
    }
}