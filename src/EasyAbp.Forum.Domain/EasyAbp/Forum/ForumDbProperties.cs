namespace EasyAbp.Forum
{
    public static class ForumDbProperties
    {
        public static string DbTablePrefix { get; set; } = "EasyAbpForum";

        public static string DbSchema { get; set; } = null;

        public const string ConnectionStringName = "EasyAbpForum";
    }
}
