using EasyAbp.Forum.Comments;

namespace EasyAbp.Forum.Comments
{
    public class CommentWithCreatorInfo
    {
        public Comment Comment { get; set; }
        
        public string CreatorUserName { get; set; }
    }
}