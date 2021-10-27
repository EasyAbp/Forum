using System;
using System.Threading.Tasks;
using EasyAbp.Forum.Communities.Dtos;
using JetBrains.Annotations;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace EasyAbp.Forum.Communities
{
    public interface ICommunityAppService :
        ICrudAppService< 
            CommunityDto, 
            Guid, 
            GetCommunityListInput,
            CreateUpdateCommunityDto,
            CreateUpdateCommunityDto>
    {
        Task<CommunityDto> GetByNameAsync([NotNull] string name);
    }
}