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
        public BasicCommentOperationAuthorizationHandler(IPermissionChecker permissionChecker) : base(permissionChecker)
        {
        }

        protected override async Task HandleGetAsync(AuthorizationHandlerContext context,
            OperationAuthorizationRequirement requirement, CommentOperationInfoModel resource)
        {
            await CheckPolicyAsync(null, context);

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

        protected virtual async Task<bool> IsUserManagerAsync()
        {
            return await PermissionChecker.IsGrantedAsync(ForumPermissions.Comment.Manage);
        }
    }
}