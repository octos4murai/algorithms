using Xunit;

namespace Collections.Tests
{
    public class BinaryMaxHeap_InitShould
    {
        [Theory]
        [InlineData(0)]
        [InlineData(1, -1, 0)]
        [InlineData(2, 3, 0, -4, -5, 9, 4, 4, 7)]
        public void Init_ValidIntegers_BuildHeap(params int[] elements)
        {
            var heap = new BinaryMaxHeap<int>(elements);
            Assert.Equal(elements.Length, heap.GetLength());
        }

        [Theory]
        [InlineData("0")]
        [InlineData("1", "-1", "0")]
        [InlineData("2", "3", "0", "-4", "-5", "9", "4", "4", "7")]
        public void Init_ValidStrings_BuildHeap(params string[] elements)
        {
            var heap = new BinaryMaxHeap<string>(elements);
            Assert.Equal(elements.Length, heap.GetLength());
        }
    }
}