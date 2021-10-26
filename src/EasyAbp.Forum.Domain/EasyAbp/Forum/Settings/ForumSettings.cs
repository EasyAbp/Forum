namespace EasyAbp.Forum.Settings
{
    public static class ForumSettings
    {
        public const string GroupName = "EasyAbp.Forum";

        /* Add constants for setting names. Example:
         * public const string MySettingName = GroupName + ".MySettingName";
         */
        
        public static class Post
        {
            public const string PostGroupName = GroupName + ".Post";

            public const string OutlineLength = PostGroupName + ".OutlineLength";
        }
    }
}