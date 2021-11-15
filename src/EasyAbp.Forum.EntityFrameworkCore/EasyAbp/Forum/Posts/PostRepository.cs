using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasyAbp.Forum.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace EasyAbp.Forum.Posts
{
    public class PostRepository : EfCoreRepository<IForumDbContext, Post, Guid>, IPostRepository
    {
        public PostRepository(IDbContextProvider<IForumDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public override async Task<IQueryable<Post>> WithDetailsAsync()
        {
            return (await base.WithDetailsAsync()).IncludeDetails();
        }

        public virtual async Task<List<PostWithCreatorInfo>> GetPostWithCreatorInfoListAsync(IQueryable<Post> queryable)
        {
            return await (from post in queryable
                join formUser in (await GetDbContextAsync()).ForumUsers on post.CreatorId equals formUser.Id
                    into formUsers
                from formUser in formUsers.DefaultIfEmpty()
                select new PostWithCreatorInfo
                {
                    Post = post,
                    CreatorUserName = formUser.UserName
                }).ToListAsync();
        }
    }
}