using System;
using Volo.Abp.Application.Dtos;

namespace EasyAbp.Forum.Communities.Dtos
{
    [Serializable]
    public class CommunityDto : FullAuditedEntityDto<Guid>
    {
        public string Name { get; set; }

        public string DisplayName { get; set; }

        public string Description { get; set; }
    }
}