using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasyAbp.Forum.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace EasyAbp.Forum.Comments
{
    public class CommentRepository : EfCoreRepository<IForumDbContext, Comment, Guid>, ICommentRepository
    {
        public CommentRepository(IDbContextProvider<IForumDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
        
        public virtual async Task<List<CommentWithCreatorInfo>> GetCommentWithCreatorInfoListAsync(IQueryable<Comment> queryable)
        {
            return await (from comment in queryable
                join formUser in (await GetDbContextAsync()).ForumUsers on comment.CreatorId equals formUser.Id
                    into formUsers
                from formUser in formUsers.DefaultIfEmpty()
                select new CommentWithCreatorInfo
                {
                    Comment = comment,
                    CreatorUserName = formUser.UserName
                }).ToListAsync();
        }
    }
}