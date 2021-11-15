using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Users;

namespace EasyAbp.Forum.Users
{
    public interface IForumUserRepository : IUserRepository<ForumUser>
    {
        Task<List<ForumUser>> GetUsersAsync(int maxCount, string filter, CancellationToken cancellationToken = default);
    }
}