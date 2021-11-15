using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using EasyAbp.Forum.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Users.EntityFrameworkCore;

namespace EasyAbp.Forum.Users
{
    public class ForumUserRepository : EfCoreUserRepositoryBase<IForumDbContext, ForumUser>, IForumUserRepository
    {
        public ForumUserRepository(IDbContextProvider<IForumDbContext> dbContextProvider) 
            : base(dbContextProvider)
        {

        }

        public async Task<List<ForumUser>> GetUsersAsync(int maxCount, string filter, CancellationToken cancellationToken = default)
        {
            return await (await GetDbSetAsync())
                .WhereIf(!string.IsNullOrWhiteSpace(filter), x => x.UserName.Contains(filter))
                .Take(maxCount).ToListAsync(cancellationToken);
        }
    }
}