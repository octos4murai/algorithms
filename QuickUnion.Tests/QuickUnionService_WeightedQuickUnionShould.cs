using System;
using Xunit;

namespace QuickUnion.Tests
{
    public class QuickUnionService_WeightedQuickUnionShould
    {
        private readonly QuickUnionService _wqu;

        public QuickUnionService_WeightedQuickUnionShould()
        {
            var sampleArr = new int[] { 0, 1, 2, 3, 4, 5, 6 };
            _wqu = new QuickUnionService(sampleArr, QuickUnionService.Mode.WEIGHTED);
            _wqu.Union(0, 6);
            _wqu.Union(0, 1);
            _wqu.Union(5, 2);
            _wqu.Union(2, 3);
        }

        [Theory]
        [InlineData(0, 6)]
        [InlineData(1, 0)]
        [InlineData(1, 6)]
        [InlineData(5, 2)]
        public void Find_ConnectedValues_ReturnTrue(int x, int y)
        {
            var result = _wqu.Find(x, y);
            Assert.True(result, $"{x} and {y} should be connected.");
        }

        [Theory]
        [InlineData(0, 5)]
        [InlineData(4, 5)]
        [InlineData(3, 1)]
        public void Find_DisconnectedValues_ReturnFalse(int x, int y)
        {
            var result = _wqu.Find(x, y);
            Assert.False(result, $"{x} and {y} should not be connected.");
        }
    }
}
