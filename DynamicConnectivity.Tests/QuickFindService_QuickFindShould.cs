using Xunit;

namespace DynamicConnectivity.Tests
{
    public class QuickFindService_QuickFindShould
    {
        private readonly QuickFindService _qf;

        public QuickFindService_QuickFindShould()
        {
            _qf = new QuickFindService(7);
            _qf.Union(0, 6);
            _qf.Union(0, 1);
            _qf.Union(5, 2);
            _qf.Union(2, 3);
        }

        [Theory]
        [InlineData(0, 6)]
        [InlineData(1, 0)]
        [InlineData(1, 6)]
        [InlineData(5, 2)]
        public void Find_ConnectedValues_ReturnTrue(int x, int y)
        {
            var result = _qf.Find(x, y);
            Assert.True(result, $"{x} and {y} should be connected.");
        }

        [Theory]
        [InlineData(0, 5)]
        [InlineData(4, 5)]
        [InlineData(3, 1)]
        public void Find_DisconnectedValues_ReturnFalse(int x, int y)
        {
            var result = _qf.Find(x, y);
            Assert.False(result, $"{x} and {y} should not be connected.");
        }
    }
}