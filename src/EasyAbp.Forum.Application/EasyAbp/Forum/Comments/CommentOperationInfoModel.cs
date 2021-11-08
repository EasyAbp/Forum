using System;
using EasyAbp.Forum.Posts;

namespace EasyAbp.Forum.Comments
{
    public class CommentOperationInfoModel
    {
        public Guid? CommunityId { get; set; }
        
        public Guid? PostId { get; set; }
        
        public Guid? ParentId { get; set; }
        
        public Comment Comment { get; set; }
    }
}