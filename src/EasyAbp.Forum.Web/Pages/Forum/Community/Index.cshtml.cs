using System.Collections.Generic;
using System.Threading.Tasks;
using EasyAbp.Forum.Communities;
using EasyAbp.Forum.Communities.Dtos;
using EasyAbp.Forum.Posts;
using EasyAbp.Forum.Posts.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace EasyAbp.Forum.Web.Pages.Forum.Community
{
    public class IndexModel : ForumPageModel
    {
        [BindProperty(SupportsGet = true, Name = "page")]
        public int PageNumber { get; set; } = 1;
        
        public CommunityDto Community { get; set; }

        public IReadOnlyList<PostDto> PinnedPosts { get; set; } = new List<PostDto>();
        
        public IReadOnlyList<PostDto> Posts { get; set; } = new List<PostDto>();
        
        public virtual async Task<IActionResult> OnGetAsync(string name)
        {
            var communityAppService = LazyServiceProvider.LazyGetRequiredService<ICommunityAppService>();

            try
            {
                Community = await communityAppService.GetByNameAsync(name);
            }
            catch
            {
                return RedirectToPage("/Forum/Index");
            }
            
            var postAppService = LazyServiceProvider.LazyGetRequiredService<IPostAppService>();

            PinnedPosts = (await postAppService.GetListAsync(new GetPostListInput
            {
                PinnedOnly = true,
                MaxResultCount = 6
            })).Items;
            
            Posts = (await postAppService.GetListAsync(new GetPostListInput
            {
                MaxResultCount = 15,
                SkipCount = (PageNumber - 1) * 15
            })).Items;

            return Page();
        }
    }
}