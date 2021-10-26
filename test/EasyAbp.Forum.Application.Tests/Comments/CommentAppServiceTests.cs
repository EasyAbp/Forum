using Shouldly;
using System.Threading.Tasks;
using Xunit;

namespace EasyAbp.Forum.Comments
{
    public class CommentAppServiceTests : ForumApplicationTestBase
    {
        private readonly ICommentAppService _commentAppService;

        public CommentAppServiceTests()
        {
            _commentAppService = GetRequiredService<ICommentAppService>();
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
