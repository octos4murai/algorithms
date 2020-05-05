using Xunit;

namespace Collections.Tests
{
    public class Deque_GetSizeShould
    {
        [Fact]
        public void GetSize_NewDeque_ReturnZero()
        {
            var deque = new Deque<int>();
            Assert.Equal(0, deque.GetSize());
        }

        [Theory]
        [InlineData(5)]
        [InlineData(-1, 0)]
        [InlineData(9, -5, 2, 7, 1)]
        public void GetSize_NonEmptyDeque_ReturnSize(params int[] nums)
        {
            var deque = new Deque<int>();

            foreach (int num in nums)
                deque.AddFirst(num);

            Assert.Equal(nums.Length, deque.GetSize());
        }

        [Theory]
        [InlineData(1, 5)]
        [InlineData(0, -1, 0)]
        [InlineData(3, 9, -5, 2, 7, 1)]
        [InlineData(5, 9, -5, 2, 7, 1)]
        public void GetSize_AddElements_ReturnSize(int numToRemove, params int[] nums)
        {
            var deque = new Deque<int>();

            foreach (int num in nums)
                deque.AddFirst(num);

            for (int i = numToRemove; i > 0; i--)
                deque.RemoveFirst();

            Assert.Equal(nums.Length - numToRemove, deque.GetSize());
        }
    }
}