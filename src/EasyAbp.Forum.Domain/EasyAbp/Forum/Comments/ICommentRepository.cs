using System;
using Volo.Abp.Domain.Repositories;

namespace EasyAbp.Forum.Comments
{
    public interface ICommentRepository : IRepository<Comment, Guid>
    {
    }
}