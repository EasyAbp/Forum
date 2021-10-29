using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EasyAbp.Forum.Comments;
using EasyAbp.Forum.Comments.Dtos;
using EasyAbp.Forum.Communities;
using EasyAbp.Forum.Communities.Dtos;
using EasyAbp.Forum.Posts;
using EasyAbp.Forum.Posts.Dtos;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Pagination;

namespace EasyAbp.Forum.Web.Pages.Forum.Post
{
    public class IndexModel : ForumPageModel
    {
        public static int PageSize = 15;
        public static int SubCommentPageSize = 10;
        
        public PagerModel PagerModel { get; set; }

        [BindProperty(SupportsGet = true)]
        public int CurrentPage { get; set; } = 1;
        
        public CommunityDto Community { get; set; }
        
        public PostDto Post { get; set; }

        public IReadOnlyList<CommentDto> Comments { get; set; } = new List<CommentDto>();
        
        public Dictionary<CommentDto, IReadOnlyList<CommentDto>> FirstPageSubComments { get; set; } = new();
        
        public virtual async Task<IActionResult> OnGetAsync(Guid id)
        {
            var postAppService = LazyServiceProvider.LazyGetRequiredService<IPostAppService>();

            try
            {
                Post = await postAppService.GetAsync(id);
            }
            catch
            {
                return RedirectToPage("/Forum/Index");
            }
            
            var commentAppService = LazyServiceProvider.LazyGetRequiredService<ICommentAppService>();

            var commentsResult = await commentAppService.GetListAsync(new GetCommentListInput
            {
                PostId = Post.Id,
                MaxResultCount = PageSize,
                SkipCount = (CurrentPage - 1) * PageSize
            });
            
            Comments = commentsResult.Items;

            PagerModel = new PagerModel(commentsResult.TotalCount, commentsResult.Items.Count, CurrentPage, PageSize,
                Request.Path.ToString());

            foreach (var comment in Comments)
            {
                if (comment.ChildrenCount == 0)
                {
                    FirstPageSubComments[comment] = new List<CommentDto>();
                }
                else
                {
                    FirstPageSubComments[comment] = (await commentAppService.GetListAsync(new GetCommentListInput
                    {
                        ParentId = comment.Id,
                        MaxResultCount = SubCommentPageSize
                    })).Items;
                }
            }

            var communityAppService = LazyServiceProvider.LazyGetRequiredService<ICommunityAppService>();

            Community = await communityAppService.GetAsync(Post.CommunityId);
            
            return Page();
        }
    }
}