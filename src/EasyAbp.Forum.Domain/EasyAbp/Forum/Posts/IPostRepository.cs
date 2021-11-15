using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace EasyAbp.Forum.Posts
{
    public interface IPostRepository : IRepository<Post, Guid>
    {
        Task<List<PostWithCreatorInfo>> GetPostWithCreatorInfoListAsync(IQueryable<Post> queryable);
    }
}