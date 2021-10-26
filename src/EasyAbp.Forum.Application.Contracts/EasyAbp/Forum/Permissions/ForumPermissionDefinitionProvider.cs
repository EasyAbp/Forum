using EasyAbp.Forum.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace EasyAbp.Forum.Permissions
{
    public class ForumPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var myGroup = context.AddGroup(ForumPermissions.GroupName, L("Permission:Forum"));

            var communityPermission = myGroup.AddPermission(ForumPermissions.Community.Default, L("Permission:Community"));
            communityPermission.AddChild(ForumPermissions.Community.Create, L("Permission:Create"));
            communityPermission.AddChild(ForumPermissions.Community.Update, L("Permission:Update"));
            communityPermission.AddChild(ForumPermissions.Community.Delete, L("Permission:Delete"));

            var postPermission = myGroup.AddPermission(ForumPermissions.Post.Default, L("Permission:Post"));
            postPermission.AddChild(ForumPermissions.Post.Manage, L("Permission:Manage"));
            postPermission.AddChild(ForumPermissions.Post.Create, L("Permission:Create"));
            postPermission.AddChild(ForumPermissions.Post.Update, L("Permission:Update"));
            postPermission.AddChild(ForumPermissions.Post.Delete, L("Permission:Delete"));

            var commentPermission = myGroup.AddPermission(ForumPermissions.Comment.Default, L("Permission:Comment"));
            commentPermission.AddChild(ForumPermissions.Comment.Manage, L("Permission:Manage"));
            commentPermission.AddChild(ForumPermissions.Comment.Create, L("Permission:Create"));
            commentPermission.AddChild(ForumPermissions.Comment.Update, L("Permission:Update"));
            commentPermission.AddChild(ForumPermissions.Comment.Delete, L("Permission:Delete"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<ForumResource>(name);
        }
    }
}
