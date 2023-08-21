using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Volo.Abp.Authorization.Permissions;

namespace EasyAbp.Forum.Authorization;

public abstract class ForumOperationAuthorizationHandler<TOperationInfoModel> :
    AuthorizationHandler<OperationAuthorizationRequirement, TOperationInfoModel>
{
    protected IPermissionChecker PermissionChecker { get; set; }

    public ForumOperationAuthorizationHandler(IPermissionChecker permissionChecker)
    {
        PermissionChecker = permissionChecker;
    }

    protected virtual async Task CheckPolicyAsync(string permissionName, AuthorizationHandlerContext context)
    {
        if (permissionName.IsNullOrEmpty())
        {
            return;
        }

        if (!await PermissionChecker.IsGrantedAsync(permissionName))
        {
            context.Fail();
        }
    }
}