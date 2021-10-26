using Shouldly;
using System.Threading.Tasks;
using Xunit;

namespace EasyAbp.Forum.Posts
{
    public class PostAppServiceTests : ForumApplicationTestBase
    {
        private readonly IPostAppService _postAppService;

        public PostAppServiceTests()
        {
            _postAppService = GetRequiredService<IPostAppService>();
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
