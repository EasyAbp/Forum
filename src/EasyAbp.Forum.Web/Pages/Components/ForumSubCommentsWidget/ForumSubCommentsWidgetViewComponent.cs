using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EasyAbp.Forum.Comments;
using EasyAbp.Forum.Comments.Dtos;
using EasyAbp.Forum.Permissions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc.UI.Widgets;
using Volo.Abp.Users;

namespace EasyAbp.Forum.Web.Pages.Components.ForumSubCommentsWidget
{
    [Widget(
        AutoInitialize = true,
        RefreshUrl = "/widgets/forum-sub-comments",
        StyleFiles = new[] { "/Pages/Components/ForumSubCommentsWidget/Default.css" },
        ScriptFiles = new[] { "/Pages/Components/ForumSubCommentsWidget/Default.js" })]
    [ViewComponent(Name = "ForumSubCommentsWidget")]
    public class ForumSubCommentsWidgetViewComponent : AbpViewComponent
    {
        public static int SubCommentPageSize = 10;

        protected IAuthorizationService AuthorizationService =>
            LazyServiceProvider.LazyGetRequiredService<IAuthorizationService>();

        protected ICommentAppService CommentAppService =>
            LazyServiceProvider.LazyGetRequiredService<ICommentAppService>();
        
        protected ICurrentUser CurrentUser => LazyServiceProvider.LazyGetRequiredService<ICurrentUser>();

        public async Task<IViewComponentResult> InvokeAsync(Guid postId, Guid commentId, bool hasChildren)
        {
            var canCreateComment = await CanCreateCommentAsync();

            var subComments = new List<ForumSubCommentsWidgetItemModel>();

            var canLoadMore = false;

            if (hasChildren)
            {
                var getListResult = await CommentAppService.GetListAsync(new GetCommentListInput
                {
                    ParentId = commentId,
                    MaxResultCount = SubCommentPageSize
                });

                foreach (var subComment in getListResult.Items)
                {
                    subComments.Add(new ForumSubCommentsWidgetItemModel
                    {
                        Comment = subComment,
                        CanCreateComment = canCreateComment,
                        CanEditComment = await CanEditCommentAsync(subComment),
                        CanDeleteComment = await CanDeleteCommentAsync(subComment)
                    });
                }

                canLoadMore = subComments.Count < getListResult.TotalCount;
            }

            return View("~/Pages/Components/ForumSubCommentsWidget/Default.cshtml", new ForumSubCommentsWidgetModel
            {
                CurrentUserName = CurrentUser.Name,
                CanLoadMore = canLoadMore,
                CanCreateComment = canCreateComment,
                PostId = postId,
                CommentId = commentId,
                SubComments = subComments
            });
        }
        
        public virtual async Task<bool> CanCreateCommentAsync()
        {
            return await AuthorizationService.IsGrantedAsync(ForumPermissions.Comment.Create);
        }
        
        public virtual async Task<bool> CanEditCommentAsync(CommentDto comment)
        {
            return await AuthorizationService.IsGrantedAsync(ForumPermissions.Comment.Update) &&
                   (comment.CreatorId == CurrentUser.GetId() ||
                    await AuthorizationService.IsGrantedAsync(ForumPermissions.Comment.Manage));
        }
        
        public virtual async Task<bool> CanDeleteCommentAsync(CommentDto comment)
        {
            return await AuthorizationService.IsGrantedAsync(ForumPermissions.Comment.Delete) &&
                   (comment.CreatorId == CurrentUser.GetId() ||
                    await AuthorizationService.IsGrantedAsync(ForumPermissions.Comment.Manage));
        }
    }
}