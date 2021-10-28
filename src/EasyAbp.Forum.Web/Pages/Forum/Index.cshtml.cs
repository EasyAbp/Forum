using System.Collections.Generic;
using System.Threading.Tasks;
using EasyAbp.Forum.Communities;
using EasyAbp.Forum.Communities.Dtos;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Pagination;

namespace EasyAbp.Forum.Web.Pages.Forum
{
    public class IndexModel : ForumPageModel
    {
        public static int PageSize = 15;
        
        public PagerModel PagerModel { get; set; }

        [BindProperty(SupportsGet = true)]
        public int CurrentPage { get; set; } = 1;
        
        public IReadOnlyList<CommunityDto> Communities { get; set; } = new List<CommunityDto>();
        
        public virtual async Task OnGetAsync()
        {
            var communityAppService = LazyServiceProvider.LazyGetRequiredService<ICommunityAppService>();

            var communitiesResult = await communityAppService.GetListAsync(new GetCommunityListInput
            {
                MaxResultCount = PageSize,
                SkipCount = (CurrentPage - 1) * PageSize
            });
            
            Communities = communitiesResult.Items;

            PagerModel = new PagerModel(communitiesResult.TotalCount, communitiesResult.Items.Count, CurrentPage,
                PageSize, Request.Path.ToString());
        }
    }
}