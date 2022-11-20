using System;
using EasyAbp.Forum.Comments.Dtos;
using Volo.Abp.Application.Dtos;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;

namespace EasyAbp.Forum.Comments
{
    [RemoteService(Name = ForumRemoteServiceConsts.RemoteServiceName)]
    [Route("/api/forum/comment")]
    public class CommentController : ForumController, ICommentAppService
    {
        private readonly ICommentAppService _service;

        public CommentController(ICommentAppService service)
        {
            _service = service;
        }

        [HttpPost]
        [Route("")]
        public virtual Task<CommentDto> CreateAsync(CreateCommentDto input)
        {
            return _service.CreateAsync(input);
        }

        [HttpPut]
        [Route("{id}")]
        public virtual Task<CommentDto> UpdateAsync(Guid id, UpdateCommentDto input)
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
        public virtual Task<CommentDto> GetAsync(Guid id)
        {
            return _service.GetAsync(id);
        }

        [HttpGet]
        [Route("")]
        public virtual Task<PagedResultDto<CommentDto>> GetListAsync(GetCommentListInput input)
        {
            return _service.GetListAsync(input);
        }
    }
}