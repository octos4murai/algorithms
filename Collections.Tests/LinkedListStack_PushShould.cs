using Collections;
using System;
using System.Collections.Generic;
using Xunit;

namespace Collections.Tests
{
    public class LinkedListStack_PushShould
    {
        [Theory]
        [InlineData(5)]
        [InlineData(-1, 0)]
        [InlineData(9, -5, 2, 7, 1)]
        public void Push_ValidIntegers_PushValues(params int[] nums)
        {
            var stack = new LinkedListStack<int>();

            int expectedSize = 0;
            Assert.Equal(expectedSize, stack.GetSize());

            foreach (int num in nums)
            {
                stack.Push(num);
                Assert.Equal(num, stack.Peek());

                expectedSize++;
                Assert.Equal(expectedSize, stack.GetSize());
            }
        }
    }
}
