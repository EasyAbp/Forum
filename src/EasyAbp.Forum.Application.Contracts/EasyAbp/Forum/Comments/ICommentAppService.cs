using System;
using EasyAbp.Forum.Comments.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace EasyAbp.Forum.Comments
{
    public interface ICommentAppService :
        ICrudAppService< 
            CommentDto, 
            Guid, 
            PagedAndSortedResultRequestDto,
            CreateCommentDto,
            UpdateCommentDto>
    {

    }
}