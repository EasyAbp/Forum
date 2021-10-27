using System;
using System.Threading.Tasks;
using EasyAbp.Forum.Posts.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace EasyAbp.Forum.Posts
{
    public interface IPostAppService :
        ICrudAppService< 
            PostDto, 
            Guid, 
            GetPostListInput,
            CreatePostDto,
            UpdatePostDto>
    {
        Task PinAsync(Guid id);
        
        Task UnpinAsync(Guid id);
    }
}