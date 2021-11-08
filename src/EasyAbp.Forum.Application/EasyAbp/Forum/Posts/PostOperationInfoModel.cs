using System;

namespace EasyAbp.Forum.Posts
{
    public class PostOperationInfoModel
    {
        public Guid? CommunityId { get; set; }
        
        public Post Post { get; set; }
    }
}