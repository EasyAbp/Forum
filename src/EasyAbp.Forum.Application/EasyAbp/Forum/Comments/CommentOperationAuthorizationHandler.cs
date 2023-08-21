using System.Threading.Tasks;
using EasyAbp.Forum.Authorization;
using EasyAbp.Forum.Permissions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Volo.Abp.Authorization.Permissions;

namespace EasyAbp.Forum.Comments
{
    public abstract class CommentOperationAuthorizationHandler :
        ForumOperationAuthorizationHandler<CommentOperationInfoModel>
    {
        public CommentOperationAuthorizationHandler(IPermissionChecker permissionChecker) : base(permissionChecker)
        {
        }

        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context,
            OperationAuthorizationRequirement requirement, CommentOperationInfoModel resource)
        {
            switch (requirement.Name)
            {
                case ForumPermissions.Comment.Default:
                    await HandleGetAsync(context, requirement, resource);
                    break;
                case ForumPermissions.Comment.Create:
                    await HandleCreateAsync(context, requirement, resource);
                    break;
                case ForumPermissions.Comment.Update:
                    await HandleUpdateAsync(context, requirement, resource);
                    break;
                case ForumPermissions.Comment.Delete:
                    await HandleDeleteAsync(context, requirement, resource);
                    break;
            }
        }

        protected virtual Task HandleGetAsync(AuthorizationHandlerContext context,
            OperationAuthorizationRequirement requirement, CommentOperationInfoModel resource)
        {
            return Task.CompletedTask;
        }

        protected virtual Task HandleCreateAsync(AuthorizationHandlerContext context,
            OperationAuthorizationRequirement requirement, CommentOperationInfoModel resource)
        {
            return Task.CompletedTask;
        }

        protected virtual Task HandleUpdateAsync(AuthorizationHandlerContext context,
            OperationAuthorizationRequirement requirement, CommentOperationInfoModel resource)
        {
            return Task.CompletedTask;
        }

        protected virtual Task HandleDeleteAsync(AuthorizationHandlerContext context,
            OperationAuthorizationRequirement requirement, CommentOperationInfoModel resource)
        {
            return Task.CompletedTask;
        }
    }
}