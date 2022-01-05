using System;
using System.Text.Json.Serialization;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Data;

namespace EasyAbp.Forum.Posts.Dtos
{
    [Serializable]
    public class GetPostListInput : PagedAndSortedResultRequestDto, IHasExtraProperties
    {
        public Guid CommunityId { get; set; }
        
        public bool PinnedOnly { get; set; }
        
        [JsonInclude]
        public ExtraPropertyDictionary ExtraProperties { get; set; }
    }
}