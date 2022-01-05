using System;
using System.Text.Json.Serialization;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Data;

namespace EasyAbp.Forum.Communities.Dtos
{
    [Serializable]
    public class GetCommunityListInput : PagedAndSortedResultRequestDto, IHasExtraProperties
    {
        [JsonInclude]
        public ExtraPropertyDictionary ExtraProperties { get; set; }
    }
}