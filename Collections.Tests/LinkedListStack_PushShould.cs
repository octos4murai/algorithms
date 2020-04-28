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
        public void Push_IntegerTypes_PushValues(params int[] nums)
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

        [Theory]
        [InlineData("foo")]
        [InlineData("bar", "foo")]
        [InlineData("bar", "tan", "foo", "arc")]
        public void Push_StringTypes_PushValues(params string[] strings)
        {
            var stack = new LinkedListStack<string>();

            int expectedSize = 0;
            Assert.Equal(expectedSize, stack.GetSize());

            foreach (string s in strings)
            {
                stack.Push(s);
                Assert.Equal(s, stack.Peek());

                expectedSize++;
                Assert.Equal(expectedSize, stack.GetSize());
            }
        }
    }
}
