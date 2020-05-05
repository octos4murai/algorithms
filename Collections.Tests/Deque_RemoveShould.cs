using System;
using Xunit;

namespace Collections.Tests
{
    public class Deque_RemoveShould
    {
        [Theory]
        [InlineData(5)]
        [InlineData(-1, 0)]
        [InlineData(9, -5, 2, 7, 1)]
        public void RemoveFirst_ValidOperation_RemoveValues(params int[] nums)
        {
            var deque = new Deque<int>();

            foreach (int num in nums)
                deque.AddLast(num);

            int expectedSize = nums.Length;
            Assert.Equal(expectedSize, deque.GetSize());

            foreach (int num in nums)
            {
                int retrievedValue = deque.RemoveFirst();
                Assert.Equal(num, retrievedValue);

                expectedSize--;
                Assert.Equal(expectedSize, deque.GetSize());
            }

            Assert.Equal(0, deque.GetSize());
        }

        [Fact]
        public void RemoveFirst_InvalidOperation_ThrowsInvalidOperationException()
        {
            var deque = new Deque<int>();
            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => deque.RemoveFirst());
            Assert.Equal("Cannot remove from empty deque.", ex.Message);
        }

        [Theory]
        [InlineData(5)]
        [InlineData(-1, 0)]
        [InlineData(9, -5, 2, 7, 1)]
        public void RemoveLast_ValidOperation_RemoveValues(params int[] nums)
        {
            var deque = new Deque<int>();

            foreach (int num in nums)
                deque.AddFirst(num);

            int expectedSize = nums.Length;
            Assert.Equal(expectedSize, deque.GetSize());

            foreach (int num in nums)
            {
                int retrievedValue = deque.RemoveLast();
                Assert.Equal(num, retrievedValue);

                expectedSize--;
                Assert.Equal(expectedSize, deque.GetSize());
            }

            Assert.Equal(0, deque.GetSize());
        }

        [Fact]
        public void RemoveLast_InvalidOperation_ThrowsInvalidOperationException()
        {
            var deque = new Deque<int>();
            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => deque.RemoveLast());
            Assert.Equal("Cannot remove from empty deque.", ex.Message);
        }
    }
}