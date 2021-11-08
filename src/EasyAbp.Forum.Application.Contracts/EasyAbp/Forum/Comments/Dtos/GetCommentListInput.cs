using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Data;

namespace EasyAbp.Forum.Comments.Dtos
{
    [Serializable]
    public class GetCommentListInput : PagedAndSortedResultRequestDto, IHasExtraProperties
    {
        public Guid PostId { get; set; }
        
        public Guid? ParentId { get; set; }
        
        public ExtraPropertyDictionary ExtraProperties { get; set; }
    }
}