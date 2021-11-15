using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace EasyAbp.Forum.Comments
{
    public interface ICommentRepository : IRepository<Comment, Guid>
    {
        Task<List<CommentWithCreatorInfo>> GetCommentWithCreatorInfoListAsync(IQueryable<Comment> queryable);
    }
}