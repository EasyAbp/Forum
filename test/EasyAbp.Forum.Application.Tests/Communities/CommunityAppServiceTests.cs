using System;
using EasyAbp.Forum.Communities.Dtos;
using Shouldly;
using Volo.Abp.ObjectMapping;
using Xunit;

namespace EasyAbp.Forum.Communities
{
    public class CommunityAppServiceTests : ForumApplicationTestBase
    {
        private readonly ICommunityAppService _communityAppService;
        private readonly IObjectMapper<ForumApplicationModule> _objectMapper;

        public CommunityAppServiceTests()
        {
            _communityAppService = GetRequiredService<ICommunityAppService>();
            _objectMapper = GetRequiredService<IObjectMapper<ForumApplicationModule>>();
        }

        [Fact]
        public void Should_Map_Community_To_CommunityDto()
        {
            var community = new Community(Guid.NewGuid(), null, "my-community", "My Community", "desc");

            var dto = _objectMapper.Map<Community, CommunityDto>(community);

            dto.Name.ShouldBe("my-community");
            dto.DisplayName.ShouldBe("My Community");
            dto.Description.ShouldBe("desc");
        }
    }
}
