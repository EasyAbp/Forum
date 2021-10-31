using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using EasyAbp.Forum.Comments;
using EasyAbp.Forum.Comments.Dtos;
using EasyAbp.Forum.Communities;
using EasyAbp.Forum.Communities.Dtos;
using EasyAbp.Forum.Posts;
using EasyAbp.Forum.Posts.Dtos;
using EasyAbp.Forum.Web.Pages.Forum.Post.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Pagination;
using Volo.Abp.Validation;

namespace EasyAbp.Forum.Web.Pages.Forum.Post
{
    public class IndexModel : ForumPageModel
    {
        private readonly ICommentAppService _commentAppService;
        public static int PageSize = 15;
        public static int SubCommentPageSize = 10;
        
        public PagerModel PagerModel { get; set; }

        [BindProperty(SupportsGet = true)]
        public int CurrentPage { get; set; } = 1;
        
        public CommunityDto Community { get; set; }
        
        public PostDto Post { get; set; }
        
        [BindProperty(SupportsGet = true, Name = "id")]
        public Guid PostId { get; set; }
        
        [BindProperty(SupportsGet = true)]
        public Guid? PinnedCommentId { get; set; }
        
        [BindProperty]
        [Required]
        [DynamicStringLength(
            typeof(ForumConsts.Comment),
            nameof(ForumConsts.Comment.TextMaxLength),
            nameof(ForumConsts.Comment.TextMinLength)
        )]
        public string CreateCommentText { get; set; }

        public List<CommentDto> Comments { get; set; } = new();
        
        public Dictionary<CommentDto, IReadOnlyList<CommentDto>> FirstPageSubComments { get; set; } = new();

        public IndexModel(ICommentAppService commentAppService)
        {
            _commentAppService = commentAppService;
        }
        
        public virtual async Task<IActionResult> OnGetAsync()
        {
            var postAppService = LazyServiceProvider.LazyGetRequiredService<IPostAppService>();

            try
            {
                Post = await postAppService.GetAsync(PostId);
            }
            catch
            {
                return RedirectToPage("/Forum/Index");
            }
            
            var commentsResult = await _commentAppService.GetListAsync(new GetCommentListInput
            {
                PostId = Post.Id,
                MaxResultCount = PageSize,
                SkipCount = (CurrentPage - 1) * PageSize
            });
            
            Comments = commentsResult.Items.ToList();

            PagerModel = new PagerModel(commentsResult.TotalCount, commentsResult.Items.Count, CurrentPage, PageSize,
                Request.Path.ToString());
            
            if (PinnedCommentId.HasValue)
            {
                var pinnedComment = await _commentAppService.GetAsync(PinnedCommentId.Value);
                Comments.RemoveAll(x => x.Id == pinnedComment.Id);
                Comments.AddFirst(pinnedComment);
            }

            foreach (var comment in Comments)
            {
                if (comment.ChildrenCount == 0)
                {
                    FirstPageSubComments[comment] = new List<CommentDto>();
                }
                else
                {
                    FirstPageSubComments[comment] = (await _commentAppService.GetListAsync(new GetCommentListInput
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
        
        public virtual async Task<IActionResult> OnPostAsync()
        {
            var newComment = await _commentAppService.CreateAsync(new CreateCommentDto
            {
                PostId = PostId,
                Text = CreateCommentText
            });

            return RedirectToPage("/Forum/Post/Index", new {pinnedCommentId = newComment.Id});
        }
    }
}