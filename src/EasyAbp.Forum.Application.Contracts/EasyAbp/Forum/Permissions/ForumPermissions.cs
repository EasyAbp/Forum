using Volo.Abp.Reflection;

namespace EasyAbp.Forum.Permissions
{
    public class ForumPermissions
    {
        public const string GroupName = "EasyAbp.Forum";

        public static string[] GetAll()
        {
            return ReflectionHelper.GetPublicConstantsRecursively(typeof(ForumPermissions));
        }

        public class Community
        {
            public const string Default = GroupName + ".Community";
            public const string Update = Default + ".Update";
            public const string Create = Default + ".Create";
            public const string Delete = Default + ".Delete";
        }

        public class Post
        {
            public const string Default = GroupName + ".Post";
            public const string Manage = Default + ".Manage";
            public const string Update = Default + ".Update";
            public const string Create = Default + ".Create";
            public const string Delete = Default + ".Delete";
            public const string Pin = Default + ".Pin";
        }

        public class Comment
        {
            public const string Default = GroupName + ".Comment";
            public const string Manage = Default + ".Manage";
            public const string Update = Default + ".Update";
            public const string Create = Default + ".Create";
            public const string Delete = Default + ".Delete";
        }
    }
}
