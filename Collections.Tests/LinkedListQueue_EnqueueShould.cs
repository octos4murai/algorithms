using Xunit;

namespace Collections.Tests
{
    public class LinkedListEnqueue_EnqueueShould
    {
        [Theory]
        [InlineData(5)]
        [InlineData(-1, 0)]
        [InlineData(9, -5, 2, 7, 1)]
        public void Enqueue_IntegerTypes_EnqueueValues(params int[] nums)
        {
            var queue = new LinkedListQueue<int>();

            int expectedSize = 0;
            Assert.Equal(expectedSize, queue.GetSize());

            foreach (int num in nums)
            {
                queue.Enqueue(num);

                expectedSize++;
                Assert.Equal(expectedSize, queue.GetSize());
            }
        }

        [Theory]
        [InlineData("foo")]
        [InlineData("bar", "foo")]
        [InlineData("bar", "tan", "foo", "arc")]
        public void Enqueue_StringTypes_EnqueueValues(params string[] strings)
        {
            var queue = new LinkedListQueue<string>();

            int expectedSize = 0;
            Assert.Equal(expectedSize, queue.GetSize());

            foreach (string s in strings)
            {
                queue.Enqueue(s);

                expectedSize++;
                Assert.Equal(expectedSize, queue.GetSize());
            }
        }
    }
}
