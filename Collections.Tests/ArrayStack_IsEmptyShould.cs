using Xunit;

namespace Collections.Tests
{
    public class ArrayStack_IsEmptyShould
    {
        [Fact]
        public void IsEmpty_NewStack_ReturnTrue()
        {
            var stack = new ArrayStack<int>();
            Assert.True(stack.IsEmpty());
        }

        [Theory]
        [InlineData(5)]
        [InlineData(-1, 0)]
        [InlineData(9, -5, 2, 7, 1)]
        public void IsEmpty_NonEmptyStack_ReturnFalse(params int[] nums)
        {
            var stack = new ArrayStack<int>();

            foreach (int num in nums)
                stack.Push(num);

            Assert.False(stack.IsEmpty());
        }
    }
}