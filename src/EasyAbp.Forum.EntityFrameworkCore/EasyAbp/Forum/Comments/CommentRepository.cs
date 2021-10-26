using System;
using EasyAbp.Forum.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace EasyAbp.Forum.Comments
{
    public class CommentRepository : EfCoreRepository<IForumDbContext, Comment, Guid>, ICommentRepository
    {
        public CommentRepository(IDbContextProvider<IForumDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}