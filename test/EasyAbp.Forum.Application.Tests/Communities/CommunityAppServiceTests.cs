using Shouldly;
using System.Threading.Tasks;
using Xunit;

namespace EasyAbp.Forum.Communities
{
    public class CommunityAppServiceTests : ForumApplicationTestBase
    {
        private readonly ICommunityAppService _communityAppService;

        public CommunityAppServiceTests()
        {
            _communityAppService = GetRequiredService<ICommunityAppService>();
        }

        /*
        [Fact]
        public async Task Test1()
        {
            // Arrange

            // Act

            // Assert
        }
        */
    }
}
