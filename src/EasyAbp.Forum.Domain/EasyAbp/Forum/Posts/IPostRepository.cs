using System;
using Volo.Abp.Domain.Repositories;

namespace EasyAbp.Forum.Posts
{
    public interface IPostRepository : IRepository<Post, Guid>
    {
    }
}