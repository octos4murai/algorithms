using Xunit;

namespace Collections.Tests
{
    public class LinkedListQueue_IsEmptyShould
    {
        [Fact]
        public void IsEmpty_NewQueue_ReturnTrue()
        {
            var queue = new LinkedListQueue<int>();
            Assert.True(queue.IsEmpty());
        }

        [Theory]
        [InlineData(5)]
        [InlineData(-1, 0)]
        [InlineData(9, -5, 2, 7, 1)]
        public void IsEmpty_NonEmptyQueue_ReturnFalse(params int[] nums)
        {
            var queue = new LinkedListQueue<int>();

            foreach (int num in nums)
                queue.Enqueue(num);

            Assert.False(queue.IsEmpty());
        }
    }
}