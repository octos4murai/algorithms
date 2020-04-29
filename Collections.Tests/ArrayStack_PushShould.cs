using Collections;
using System;
using Xunit;

namespace Collections.Tests
{
    public class ArrayStack_PushShould
    {
        [Theory]
        [InlineData(5)]
        [InlineData(-1, 0)]
        [InlineData(9, -5, 2, 7, 1)]
        public void Push_IntegerTypes_PushValues(params int[] nums)
        {
            var stack = new ArrayStack<int>();

            foreach (int num in nums)
            {
                stack.Push(num);
                Assert.Equal(num, stack.Peek());
            }
        }
    }
}