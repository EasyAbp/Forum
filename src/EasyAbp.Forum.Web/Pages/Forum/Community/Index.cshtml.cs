using System.Collections.Generic;
using System.Threading.Tasks;
using EasyAbp.Forum.Communities;
using EasyAbp.Forum.Communities.Dtos;
using EasyAbp.Forum.Permissions;
using EasyAbp.Forum.Posts;
using EasyAbp.Forum.Posts.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Pagination;

namespace EasyAbp.Forum.Web.Pages.Forum.Community
{
    public class IndexModel : ForumPageModel
    {
        private readonly IAuthorizationService _authorizationService;
        public static int PageSize = 15;
        
        public PagerModel PagerModel { get; set; }

        [BindProperty(SupportsGet = true)]
        public int CurrentPage { get; set; } = 1;
        
        public CommunityDto Community { get; set; }

        public IReadOnlyList<PostDto> PinnedPosts { get; set; } = new List<PostDto>();
        
        public IReadOnlyList<PostDto> Posts { get; set; } = new List<PostDto>();

        public IndexModel(IAuthorizationService authorizationService)
        {
            _authorizationService = authorizationService;
        }
        
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

            if (CurrentPage == 1)
            {
                PinnedPosts = (await postAppService.GetListAsync(new GetPostListInput
                {
                    CommunityId = Community.Id,
                    PinnedOnly = true,
                    MaxResultCount = 6
                })).Items;
            }

            var postsResult = await postAppService.GetListAsync(new GetPostListInput
            {
                CommunityId = Community.Id,
                MaxResultCount = PageSize,
                SkipCount = (CurrentPage - 1) * PageSize
            });
            
            Posts = postsResult.Items;

            PagerModel = new PagerModel(postsResult.TotalCount, postsResult.Items.Count, CurrentPage, PageSize,
                Request.Path.ToString());
            
            return Page();
        }

        public virtual async Task<bool> CanCreatePostAsync()
        {
            return await _authorizationService.IsGrantedAsync(ForumPermissions.Post.Create);
        }
    }
}