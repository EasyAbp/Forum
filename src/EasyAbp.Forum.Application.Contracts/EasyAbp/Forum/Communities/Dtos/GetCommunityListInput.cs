using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Data;

namespace EasyAbp.Forum.Communities.Dtos
{
    [Serializable]
    public class GetCommunityListInput : PagedAndSortedResultRequestDto, IHasExtraProperties
    {
        public ExtraPropertyDictionary ExtraProperties { get; set; }
    }
}