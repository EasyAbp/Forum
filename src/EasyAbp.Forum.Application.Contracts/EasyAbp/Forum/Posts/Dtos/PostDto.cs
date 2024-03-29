using System;
using Volo.Abp.Application.Dtos;

namespace EasyAbp.Forum.Posts.Dtos
{
    [Serializable]
    public class PostDto : FullAuditedEntityDto<Guid>
    {
        public Guid CommunityId { get; set; }

        public string Title { get; set; }

        public string Outline { get; set; }

        public string Thumbnail { get; set; }
        
        public PostContentDto Content { get; set; }

        public bool Pinned { get; set; }
        
        public string CreatorUserName { get; set; }
    }
}