using Xunit;

namespace Collections.Tests
{
    public class RandomizedQueue_GetSizeShould
    {
        [Fact]
        public void GetSize_NewQueue_ReturnZero()
        {
            var queue = new RandomizedQueue<int>();
            Assert.Equal(0, queue.GetSize());
        }

        [Theory]
        [InlineData(5)]
        [InlineData(-1, 0)]
        [InlineData(9, -5, 2, 7, 1)]
        public void GetSize_NonEmptyQueue_ReturnSize(params int[] nums)
        {
            var queue = new RandomizedQueue<int>();

            foreach (int num in nums)
                queue.Enqueue(num);

            Assert.Equal(nums.Length, queue.GetSize());
        }

        [Theory]
        [InlineData(1, 5)]
        [InlineData(0, -1, 0)]
        [InlineData(3, 9, -5, 2, 7, 1)]
        [InlineData(5, 9, -5, 2, 7, 1)]
        public void GetSize_EnqueueElements_ReturnSize(int numToPop, params int[] nums)
        {
            var queue = new RandomizedQueue<int>();

            foreach (int num in nums)
                queue.Enqueue(num);

            for (int i = numToPop; i > 0; i--)
                queue.Dequeue();

            Assert.Equal(nums.Length - numToPop, queue.GetSize());
        }
    }
}