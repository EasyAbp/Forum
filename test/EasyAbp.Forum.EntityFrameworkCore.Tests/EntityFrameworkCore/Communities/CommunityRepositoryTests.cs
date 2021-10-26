using System;
using System.Threading.Tasks;
using EasyAbp.Forum.Communities;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace EasyAbp.Forum.EntityFrameworkCore.Communities
{
    public class CommunityRepositoryTests : ForumEntityFrameworkCoreTestBase
    {
        private readonly ICommunityRepository _communityRepository;

        public CommunityRepositoryTests()
        {
            _communityRepository = GetRequiredService<ICommunityRepository>();
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
