using Xunit;

namespace Collections.Tests
{
    public class BinaryMaxHeap_RemoveMaxShould
    {
        [Theory]
        [InlineData(0)]
        [InlineData(1, -1, 0)]
        [InlineData(2, 3, 0, -4, -5, 9, 4, 4, 7)]
        public void RemoveMax_ValidIntegers_RemoveMaxElement(params int[] elements)
        {
            var heap = new BinaryMaxHeap<int>(elements);
            Assert.Equal(elements.Length, heap.GetLength());

            int? oldMax = null;
            while (heap.GetLength() > 0)
            {
                int max = heap.RemoveMax();
                Assert.True(!oldMax.HasValue || max.CompareTo(oldMax) <= 0);

                oldMax = max;
            }
        }

        [Theory]
        [InlineData("0")]
        [InlineData("1", "-1", "0")]
        [InlineData("2", "3", "0", "-4", "-5", "9", "4", "4", "7")]
        public void RemoveMax_ValidStrings_RemoveMaxElement(params string[] elements)
        {
            var heap = new BinaryMaxHeap<string>(elements);
            Assert.Equal(elements.Length, heap.GetLength());

            string oldMax = string.Empty;
            while (heap.GetLength() > 0)
            {
                string max = heap.RemoveMax();
                Assert.True(oldMax == string.Empty || max.CompareTo(oldMax) <= 0);

                oldMax = max;
            }
        }
    }
}