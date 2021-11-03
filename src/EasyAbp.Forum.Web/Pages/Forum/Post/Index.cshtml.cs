using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using EasyAbp.Forum.Comments;
using EasyAbp.Forum.Comments.Dtos;
using EasyAbp.Forum.Communities;
using EasyAbp.Forum.Communities.Dtos;
using EasyAbp.Forum.Permissions;
using EasyAbp.Forum.Posts;
using EasyAbp.Forum.Posts.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Pagination;
using Volo.Abp.Users;
using Volo.Abp.Validation;

namespace EasyAbp.Forum.Web.Pages.Forum.Post
{
    public class IndexModel : ForumPageModel
    {
        private readonly IAuthorizationService _authorizationService;
        private readonly ICommentAppService _commentAppService;
        public static int PageSize = 15;
        
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

        public IndexModel(
            IAuthorizationService authorizationService,
            ICommentAppService commentAppService)
        {
            _authorizationService = authorizationService;
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
        
        public virtual async Task<bool> CanEditPostAsync()
        {
            return await _authorizationService.IsGrantedAsync(ForumPermissions.Post.Update) &&
                   (Post.CreatorId == CurrentUser.GetId() ||
                    await _authorizationService.IsGrantedAsync(ForumPermissions.Post.Manage));
        }
        
        public virtual async Task<bool> CanDeletePostAsync()
        {
            return await _authorizationService.IsGrantedAsync(ForumPermissions.Post.Delete) &&
                   (Post.CreatorId == CurrentUser.GetId() ||
                    await _authorizationService.IsGrantedAsync(ForumPermissions.Post.Manage));
        }

        public virtual async Task<bool> CanCreateCommentAsync()
        {
            return await _authorizationService.IsGrantedAsync(ForumPermissions.Comment.Create);
        }
        
        public virtual async Task<bool> CanEditCommentAsync(CommentDto comment)
        {
            return await _authorizationService.IsGrantedAsync(ForumPermissions.Comment.Update) &&
                   (comment.CreatorId == CurrentUser.GetId() ||
                    await _authorizationService.IsGrantedAsync(ForumPermissions.Comment.Manage));
        }
        
        public virtual async Task<bool> CanDeleteCommentAsync(CommentDto comment)
        {
            return await _authorizationService.IsGrantedAsync(ForumPermissions.Comment.Delete) &&
                   (comment.CreatorId == CurrentUser.GetId() ||
                    await _authorizationService.IsGrantedAsync(ForumPermissions.Comment.Manage));
        }
    }
}