using System;
using Xunit;

namespace Collections.Tests
{
    public class ArrayStack_PeekShould
    {
        [Theory]
        [InlineData(5)]
        [InlineData(-1, 0)]
        [InlineData(9, -5, 2, 7, 1)]
        public void Peek_NonEmptyStack_ReturnValue(params int[] nums)
        {
            var stack = new ArrayStack<int>();

            foreach (int num in nums)
                stack.Push(num);

            Assert.Equal(nums[nums.Length - 1], stack.Peek());
            Assert.Equal(nums.Length, stack.GetSize());
        }

        [Fact]
        public void Peek_EmptyStack_ReturnNull()
        {
            var stack = new ArrayStack<int>();
            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => stack.Peek());
            Assert.Equal("Cannot peek an empty stack.", ex.Message);
        }

        [Theory]
        [InlineData(5)]
        [InlineData(-1, 0)]
        [InlineData(9, -5, 2, 7, 1)]
        public void Peek_NewlyEmptyStack_ReturnNull(params int[] nums)
        {
            var stack = new ArrayStack<int>();

            foreach (int num in nums)
                stack.Push(num);

            Array.Reverse(nums);
            foreach (int num in nums)
                stack.Pop();

            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => stack.Peek());
            Assert.Equal("Cannot peek an empty stack.", ex.Message);
        }
    }
}