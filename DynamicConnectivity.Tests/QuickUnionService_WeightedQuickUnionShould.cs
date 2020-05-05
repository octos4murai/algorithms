using Xunit;

namespace DynamicConnectivity.Tests
{
    public class QuickUnionService_WeightedQuickUnionShould
    {
        private readonly QuickUnionService _wqu;

        public QuickUnionService_WeightedQuickUnionShould()
        {
            _wqu = new QuickUnionService(7, QuickUnionService.Mode.WEIGHTED);
            _wqu.Union(0, 6);
            _wqu.Union(0, 1);
            _wqu.Union(5, 2);
            _wqu.Union(2, 3);
        }

        [Trait("Category", "WeightedQuickUnion")]
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

        [Trait("Category", "WeightedQuickUnion")]
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
