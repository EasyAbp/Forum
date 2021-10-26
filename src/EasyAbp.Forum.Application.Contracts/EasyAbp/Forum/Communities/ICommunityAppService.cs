using System;
using EasyAbp.Forum.Communities.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace EasyAbp.Forum.Communities
{
    public interface ICommunityAppService :
        ICrudAppService< 
            CommunityDto, 
            Guid, 
            PagedAndSortedResultRequestDto,
            CreateUpdateCommunityDto,
            CreateUpdateCommunityDto>
    {

    }
}