using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Data;

namespace EasyAbp.Forum.Posts.Dtos
{
    [Serializable]
    public class GetPostListInput : PagedAndSortedResultRequestDto, IHasExtraProperties
    {
        public bool PinnedOnly { get; set; }
        
        public ExtraPropertyDictionary ExtraProperties { get; set; }
    }
}