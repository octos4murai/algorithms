using Xunit;

namespace Collections.Tests
{
    public class LinkedListQueue_GetSizeShould
    {
        [Fact]
        public void GetSize_NewQueue_ReturnZero()
        {
            var stack = new LinkedListQueue<int>();
            Assert.Equal(0, stack.GetSize());
        }

        [Theory]
        [InlineData(5)]
        [InlineData(-1, 0)]
        [InlineData(9, -5, 2, 7, 1)]
        public void GetSize_NonEmptyQueue_ReturnSize(params int[] nums)
        {
            var stack = new LinkedListQueue<int>();

            foreach (int num in nums)
                stack.Enqueue(num);

            Assert.Equal(nums.Length, stack.GetSize());
        }

        [Theory]
        [InlineData(1, 5)]
        [InlineData(0, -1, 0)]
        [InlineData(3, 9, -5, 2, 7, 1)]
        [InlineData(5, 9, -5, 2, 7, 1)]
        public void GetSize_DequeueElements_ReturnSize(int numToPop, params int[] nums)
        {
            var stack = new LinkedListQueue<int>();

            foreach (int num in nums)
                stack.Enqueue(num);

            for (int i = numToPop; i > 0; i--)
                stack.Dequeue();

            Assert.Equal(nums.Length - numToPop, stack.GetSize());
        }
    }
}