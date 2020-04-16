using QuickFind;
using Xunit;

namespace QuickFind.Tests
{
    public class QuickFind_FindShould
    {
        private readonly QuickFindService _quickFindService;

        public QuickFind_FindShould()
        {
            _quickFindService = new QuickFindService();
        }
    }
}