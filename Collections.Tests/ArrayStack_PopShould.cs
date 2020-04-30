using System;
using Xunit;

namespace Collections.Tests
{
    public class ArrayStack_PopShould
    {
        [Theory]
        [InlineData(5)]
        [InlineData(-1, 0)]
        [InlineData(9, -5, 2, 7, 1)]
        public void Pop_ValidOperation_PopValues(params int[] nums)
        {
            var stack = new ArrayStack<int>();

            foreach (int num in nums)
                stack.Push(num);

            int expectedSize = nums.Length;
            Assert.Equal(expectedSize, stack.GetSize());

            Array.Reverse(nums);
            foreach (int num in nums)
            {
                int retrievedValue = stack.Pop();
                Assert.Equal(num, retrievedValue);

                expectedSize--;
                Assert.Equal(expectedSize, stack.GetSize());
            }

            Assert.Equal(0, stack.GetSize());
        }

        [Fact]
        public void Pop_InvalidOperation_ThrowsInvalidOperationException()
        {
            var stack = new ArrayStack<int>();
            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => stack.Pop());
            Assert.Equal("Cannot pop an empty stack.", ex.Message);
        }
    }
}