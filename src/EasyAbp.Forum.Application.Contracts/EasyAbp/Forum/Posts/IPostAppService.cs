using System;
using EasyAbp.Forum.Posts.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace EasyAbp.Forum.Posts
{
    public interface IPostAppService :
        ICrudAppService< 
            PostDto, 
            Guid, 
            PagedAndSortedResultRequestDto,
            CreatePostDto,
            UpdatePostDto>
    {

    }
}