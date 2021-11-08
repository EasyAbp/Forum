using System.Security.Principal;
using System.Threading.Tasks;
using EasyAbp.Forum.Permissions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.DependencyInjection;

namespace EasyAbp.Forum.Comments
{
    public class BasicCommentOperationAuthorizationHandler : CommentOperationAuthorizationHandler, ISingletonDependency
    {
        private readonly IPermissionChecker _permissionChecker;

        public BasicCommentOperationAuthorizationHandler(IPermissionChecker permissionChecker)
        {
            _permissionChecker = permissionChecker;
        }

        protected override async Task HandleGetAsync(AuthorizationHandlerContext context,
            OperationAuthorizationRequirement requirement, CommentOperationInfoModel resource)
        {
            await CheckPolicyAsync(ForumPermissions.Comment.Default, context);
            
            context.Succeed(requirement);
        }

        protected override async Task HandleCreateAsync(AuthorizationHandlerContext context,
            OperationAuthorizationRequirement requirement, CommentOperationInfoModel resource)
        {
            await CheckPolicyAsync(ForumPermissions.Comment.Create, context);
            
            context.Succeed(requirement);
        }

        protected override async Task HandleUpdateAsync(AuthorizationHandlerContext context,
            OperationAuthorizationRequirement requirement, CommentOperationInfoModel resource)
        {
            await CheckPolicyAsync(ForumPermissions.Comment.Update, context);
            
            if (resource.Comment.CreatorId == context.User.Identity.FindUserId() || await IsUserManagerAsync())
            {
                context.Succeed(requirement);
            }
        }

        protected override async Task HandleDeleteAsync(AuthorizationHandlerContext context,
            OperationAuthorizationRequirement requirement, CommentOperationInfoModel resource)
        {
            await CheckPolicyAsync(ForumPermissions.Comment.Delete, context);
            
            if (resource.Comment.CreatorId == context.User.Identity.FindUserId() || await IsUserManagerAsync())
            {
                context.Succeed(requirement);
            }
        }
        
        protected virtual async Task CheckPolicyAsync(string permissionName, AuthorizationHandlerContext context)
        {
            if (!await _permissionChecker.IsGrantedAsync(permissionName))
            {
                context.Fail();
            }
        }

        protected virtual async Task<bool> IsUserManagerAsync()
        {
            return await _permissionChecker.IsGrantedAsync(ForumPermissions.Comment.Manage);
        }
    }
}