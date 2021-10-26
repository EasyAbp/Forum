using System;
using System.Threading.Tasks;
using EasyAbp.Forum.Posts;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace EasyAbp.Forum.EntityFrameworkCore.Posts
{
    public class PostRepositoryTests : ForumEntityFrameworkCoreTestBase
    {
        private readonly IPostRepository _postRepository;

        public PostRepositoryTests()
        {
            _postRepository = GetRequiredService<IPostRepository>();
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
