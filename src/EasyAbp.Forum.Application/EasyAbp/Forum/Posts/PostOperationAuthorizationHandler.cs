using System.Threading.Tasks;
using EasyAbp.Forum.Permissions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;

namespace EasyAbp.Forum.Posts
{
    public abstract class PostOperationAuthorizationHandler : AuthorizationHandler<OperationAuthorizationRequirement, PostOperationInfoModel>
    {
        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context,
            OperationAuthorizationRequirement requirement, PostOperationInfoModel resource)
        {
            switch (requirement.Name)
            {
                case ForumPermissions.Post.Default:
                    await HandleGetAsync(context, requirement, resource);
                    break;
                case ForumPermissions.Post.Create:
                    await HandleCreateAsync(context, requirement, resource);
                    break;
                case ForumPermissions.Post.Update:
                    await HandleUpdateAsync(context, requirement, resource);
                    break;
                case ForumPermissions.Post.Delete:
                    await HandleDeleteAsync(context, requirement, resource);
                    break;
                case ForumPermissions.Post.Pin:
                    await HandlePinAsync(context, requirement, resource);
                    break;
            }
        }

        protected virtual Task HandleGetAsync(AuthorizationHandlerContext context,
            OperationAuthorizationRequirement requirement, PostOperationInfoModel resource)
        {
            return Task.CompletedTask;
        }

        protected virtual Task HandleCreateAsync(AuthorizationHandlerContext context,
            OperationAuthorizationRequirement requirement, PostOperationInfoModel resource)
        {
            return Task.CompletedTask;
        }

        protected virtual Task HandleUpdateAsync(AuthorizationHandlerContext context,
            OperationAuthorizationRequirement requirement, PostOperationInfoModel resource)
        {
            return Task.CompletedTask;
        }

        protected virtual Task HandleDeleteAsync(AuthorizationHandlerContext context,
            OperationAuthorizationRequirement requirement, PostOperationInfoModel resource)
        {
            return Task.CompletedTask;
        }

        protected virtual Task HandlePinAsync(AuthorizationHandlerContext context,
            OperationAuthorizationRequirement requirement, PostOperationInfoModel resource)
        {
            return Task.CompletedTask;
        }
    }
}