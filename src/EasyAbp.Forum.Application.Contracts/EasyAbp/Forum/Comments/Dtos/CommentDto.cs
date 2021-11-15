using System;
using Volo.Abp.Application.Dtos;

namespace EasyAbp.Forum.Comments.Dtos
{
    [Serializable]
    public class CommentDto : FullAuditedEntityDto<Guid>
    {
        public Guid? ParentId { get; set; }

        public Guid PostId { get; set; }

        public string Text { get; set; }
        
        public int ChildrenCount { get; set; }
        
        public string CreatorUserName { get; set; }
    }
}