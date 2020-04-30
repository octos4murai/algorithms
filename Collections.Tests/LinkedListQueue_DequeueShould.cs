using Xunit;

namespace Collections.Tests
{
    public class LinkedListQueue_DequeueShould
    {
        [Theory]
        [InlineData(5)]
        [InlineData(-1, 0)]
        [InlineData(9, -5, 2, 7, 1)]
        public void Dequeue_ValidOperation_DequeueValues(params int[] nums)
        {
            var queue = new LinkedListQueue<int>();

            foreach (int num in nums)
                queue.Enqueue(num);

            int expectedSize = nums.Length;
            Assert.Equal(expectedSize, queue.GetSize());

            foreach (int num in nums)
            {
                int retrievedValue = queue.Dequeue();
                Assert.Equal(num, retrievedValue);

                expectedSize--;
                Assert.Equal(expectedSize, queue.GetSize());
            }

            Assert.Equal(0, queue.GetSize());
        }
    }
}