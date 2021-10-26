using System;
using EasyAbp.Forum.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace EasyAbp.Forum.Communities
{
    public class CommunityRepository : EfCoreRepository<IForumDbContext, Community, Guid>, ICommunityRepository
    {
        public CommunityRepository(IDbContextProvider<IForumDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}