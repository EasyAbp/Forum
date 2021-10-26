using System;
using System.Linq;
using System.Threading.Tasks;
using EasyAbp.Forum.EntityFrameworkCore;
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
    }
}