using System;
using System.Threading.Tasks;
using EasyAbp.Forum.Comments;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace EasyAbp.Forum.EntityFrameworkCore.Comments
{
    public class CommentRepositoryTests : ForumEntityFrameworkCoreTestBase
    {
        private readonly ICommentRepository _commentRepository;

        public CommentRepositoryTests()
        {
            _commentRepository = GetRequiredService<ICommentRepository>();
        }

        /*
        [Fact]
        public async Task Test1()
        {
            await WithUnitOfWorkAsync(async () =>
            {
                // Arrange

                // Act

                //Assert
            });
        }
        */
    }
}
