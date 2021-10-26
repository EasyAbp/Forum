using System;
using Volo.Abp.Domain.Repositories;

namespace EasyAbp.Forum.Communities
{
    public interface ICommunityRepository : IRepository<Community, Guid>
    {
    }
}