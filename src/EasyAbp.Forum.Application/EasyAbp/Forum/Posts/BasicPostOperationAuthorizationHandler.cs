using System.Security.Principal;
using System.Threading.Tasks;
using EasyAbp.Forum.Permissions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.DependencyInjection;

namespace EasyAbp.Forum.Posts
{
    public class BasicPostOperationAuthorizationHandler : PostOperationAuthorizationHandler, ISingletonDependency
    {
        public BasicPostOperationAuthorizationHandler(IPermissionChecker permissionChecker) : base(permissionChecker)
        {
        }

        protected override async Task HandleGetAsync(AuthorizationHandlerContext context,
            OperationAuthorizationRequirement requirement, PostOperationInfoModel resource)
        {
            await CheckPolicyAsync(null, context);

            context.Succeed(requirement);
        }

        protected override async Task HandleCreateAsync(AuthorizationHandlerContext context,
            OperationAuthorizationRequirement requirement, PostOperationInfoModel resource)
        {
            await CheckPolicyAsync(ForumPermissions.Post.Create, context);

            context.Succeed(requirement);
        }

        protected override async Task HandleUpdateAsync(AuthorizationHandlerContext context,
            OperationAuthorizationRequirement requirement, PostOperationInfoModel resource)
        {
            await CheckPolicyAsync(ForumPermissions.Post.Update, context);

            if (resource.Post.CreatorId == context.User.Identity.FindUserId() || await IsUserManagerAsync())
            {
                context.Succeed(requirement);
            }
        }

        protected override async Task HandleDeleteAsync(AuthorizationHandlerContext context,
            OperationAuthorizationRequirement requirement, PostOperationInfoModel resource)
        {
            await CheckPolicyAsync(ForumPermissions.Post.Delete, context);

            if (resource.Post.CreatorId == context.User.Identity.FindUserId() || await IsUserManagerAsync())
            {
                context.Succeed(requirement);
            }
        }

        protected override async Task HandlePinAsync(AuthorizationHandlerContext context,
            OperationAuthorizationRequirement requirement, PostOperationInfoModel resource)
        {
            await CheckPolicyAsync(ForumPermissions.Post.Pin, context);

            context.Succeed(requirement);
        }

        protected virtual async Task<bool> IsUserManagerAsync()
        {
            return await PermissionChecker.IsGrantedAsync(ForumPermissions.Post.Manage);
        }
    }
}