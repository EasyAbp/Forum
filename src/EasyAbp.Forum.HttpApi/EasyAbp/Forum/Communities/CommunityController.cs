using System;
using EasyAbp.Forum.Communities.Dtos;
using Volo.Abp.Application.Dtos;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;

namespace EasyAbp.Forum.Communities
{
    [RemoteService(Name = ForumRemoteServiceConsts.RemoteServiceName)]
    [Route("/api/forum/community")]
    public class CommunityController : ForumController, ICommunityAppService
    {
        private readonly ICommunityAppService _service;

        public CommunityController(ICommunityAppService service)
        {
            _service = service;
        }

        [HttpPost]
        [Route("")]
        public virtual Task<CommunityDto> CreateAsync(CreateUpdateCommunityDto input)
        {
            return _service.CreateAsync(input);
        }

        [HttpPut]
        [Route("{id}")]
        public virtual Task<CommunityDto> UpdateAsync(Guid id, CreateUpdateCommunityDto input)
        {
            return _service.UpdateAsync(id, input);
        }

        [HttpDelete]
        [Route("{id}")]
        public virtual Task DeleteAsync(Guid id)
        {
            return _service.DeleteAsync(id);
        }

        [HttpGet]
        [Route("by-name/{name}")]
        public Task<CommunityDto> GetByNameAsync(string name)
        {
            return _service.GetByNameAsync(name);
        }

        [HttpGet]
        [Route("{id}")]
        public virtual Task<CommunityDto> GetAsync(Guid id)
        {
            return _service.GetAsync(id);
        }

        [HttpGet]
        [Route("")]
        public virtual Task<PagedResultDto<CommunityDto>> GetListAsync(GetCommunityListInput input)
        {
            return _service.GetListAsync(input);
        }
    }
}