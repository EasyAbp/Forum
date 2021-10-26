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
            public static int TitleMinLength = 4;
            
            public static int TitleMaxLength = 100;
            
            public static int ContentTextMinLength = 0;
            
            public static int ContentTextMaxLength = 20000;
        }
        
        public static class Comment
        {
            public static int TextMinLength = 4;
            
            public static int TextMaxLength = 20000;
        }
    }
}