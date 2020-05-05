using System;
using Xunit;

namespace Deque.Tests
{
    public class Deque_IsEmptyShould
    {
        [Fact]
        public void IsEmpty_NewDeque_ReturnTrue()
        {
            var deque = new Deque<int>();
            Assert.True(deque.IsEmpty());
        }

        [Theory]
        [InlineData(5)]
        [InlineData(-1, 0)]
        [InlineData(9, -5, 2, 7, 1)]
        public void IsEmpty_NonEmptyDeque_ReturnFalse(params int[] nums)
        {
            var deque = new Deque<int>();

            foreach (int num in nums)
                deque.AddFirst(num);

            Assert.False(deque.IsEmpty());
        }
    }
}
