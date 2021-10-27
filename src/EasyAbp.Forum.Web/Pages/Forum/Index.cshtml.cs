using System.Collections.Generic;
using System.Threading.Tasks;
using EasyAbp.Forum.Communities;
using EasyAbp.Forum.Communities.Dtos;
using Volo.Abp.Application.Dtos;

namespace EasyAbp.Forum.Web.Pages.Forum
{
    public class IndexModel : ForumPageModel
    {
        public IReadOnlyList<CommunityDto> Communities { get; set; } = new List<CommunityDto>();
        
        public virtual async Task OnGetAsync()
        {
            var communityAppService = LazyServiceProvider.LazyGetRequiredService<ICommunityAppService>();

            Communities = (await communityAppService.GetListAsync(new GetCommunityListInput
            {
                MaxResultCount = 15
            })).Items;
        }
    }
}