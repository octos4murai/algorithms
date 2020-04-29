using Collections;
using System;
using System.Collections.Generic;
using Xunit;

namespace Collections.Tests
{
    public class LinkedListStack_IsEmptyShould
    {
        [Fact]
        public void IsEmpty_NewStack_ReturnTrue()
        {
            var stack = new LinkedListStack<int>();
            Assert.True(stack.IsEmpty());
        }

        [Theory]
        [InlineData(5)]
        [InlineData(-1, 0)]
        [InlineData(9, -5, 2, 7, 1)]
        public void IsEmpty_NonEmptyStack_ReturnFalse(params int[] nums)
        {
            var stack = new LinkedListStack<int>();

            foreach (int num in nums)
                stack.Push(num);

            Assert.False(stack.IsEmpty());
        }
    }
}