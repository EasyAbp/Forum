using System;
using EasyAbp.Forum.Posts.Dtos;
using Volo.Abp.Application.Dtos;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.Application.Dtos;

namespace EasyAbp.Forum.Posts
{
    [RemoteService(Name = "EasyAbpForum")]
    [Route("/api/forum/post")]
    public class PostController : ForumController, IPostAppService
    {
        private readonly IPostAppService _service;

        public PostController(IPostAppService service)
        {
            _service = service;
        }

        [HttpPost]
        [Route("")]
        public virtual Task<PostDto> CreateAsync(CreatePostDto input)
        {
            return _service.CreateAsync(input);
        }

        [HttpPut]
        [Route("{id}")]
        public virtual Task<PostDto> UpdateAsync(Guid id, UpdatePostDto input)
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
        [Route("{id}")]
        public virtual Task<PostDto> GetAsync(Guid id)
        {
            return _service.GetAsync(id);
        }

        [HttpGet]
        [Route("")]
        public virtual Task<PagedResultDto<PostDto>> GetListAsync(PagedAndSortedResultRequestDto input)
        {
            return _service.GetListAsync(input);
        }
    }
}