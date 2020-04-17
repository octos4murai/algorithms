using System;
using Xunit;

namespace QuickUnion.Tests
{
    public class QuickUnionService_QuickUnionShould
    {
        private readonly QuickUnionService _qu;

        public QuickUnionService_QuickUnionShould()
        {
            var sampleArr = new int[] { 0, 1, 2, 3, 4, 5, 6 };
            _qu = new QuickUnionService(sampleArr);
            _qu.Union(0, 6);
            _qu.Union(0, 1);
            _qu.Union(5, 2);
            _qu.Union(2, 3);
        }

        [Theory]
        [InlineData(0, 6)]
        [InlineData(1, 0)]
        [InlineData(1, 6)]
        [InlineData(5, 2)]
        public void Find_ConnectedValues_ReturnTrue(int x, int y)
        {
            var result = _qu.Find(x, y);
            Assert.True(result, $"{x} and {y} should be connected.");
        }

        [Theory]
        [InlineData(0, 5)]
        [InlineData(4, 5)]
        [InlineData(3, 1)]
        public void Find_DisconnectedValues_ReturnFalse(int x, int y)
        {
            var result = _qu.Find(x, y);
            Assert.False(result, $"{x} and {y} should not be connected.");
        }
    }
}
