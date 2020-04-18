using System;
using Xunit;

namespace QuickUnion.Tests
{
    public class QuickUnionService_CompressedQuickUnionShould
    {
        private QuickUnionService _cqu;

        public QuickUnionService_CompressedQuickUnionShould()
        {
            var sampleArr = new int[] { 0, 1, 2, 3, 4, 5, 6 };
            _cqu = new QuickUnionService(sampleArr, QuickUnionService.Mode.WEIGHTED_COMPRESSED);
            _cqu.Union(0, 6);
            _cqu.Union(0, 1);
            _cqu.Union(5, 2);
            _cqu.Union(2, 3);
        }

        [Trait("Category", "CompressedQuickUnion")]
        [Theory]
        [InlineData(0, 6)]
        [InlineData(1, 0)]
        [InlineData(1, 6)]
        [InlineData(5, 2)]
        public void Find_ConnectedValues_ReturnTrue(int x, int y)
        {
            var result = _cqu.Find(x, y);
            Assert.True(result, $"{x} and {y} should be connected.");
        }

        [Trait("Category", "CompressedQuickUnion")]
        [Theory]
        [InlineData(0, 5)]
        [InlineData(4, 5)]
        [InlineData(3, 1)]
        public void Find_DisconnectedValues_ReturnFalse(int x, int y)
        {
            var result = _cqu.Find(x, y);
            Assert.False(result, $"{x} and {y} should not be connected.");
        }
    }
}