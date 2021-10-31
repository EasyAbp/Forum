namespace EasyAbp.Forum
{
    public static class ForumConsts
    {
        public static class Community
        {
            public static string NameRegexRule = "^[a-zA-Z0-9_-]+$";
        }
        
        public static class Post
        {
            public static int TitleMinLength { get; set; } = 4;
            
            public static int TitleMaxLength { get; set; } = 100;
            
            public static int ContentTextMinLength { get; set; } = 0;
            
            public static int ContentTextMaxLength { get; set; } = 20000;
        }
        
        public static class Comment
        {
            public static int TextMinLength { get; set; } = 4;
            
            public static int TextMaxLength { get; set; } = 20000;
        }
    }
}