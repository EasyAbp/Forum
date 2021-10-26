using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace EasyAbp.Forum.Communities
{
    public static class CommunityEfCoreQueryableExtensions
    {
        public static IQueryable<Community> IncludeDetails(this IQueryable<Community> queryable, bool include = true)
        {
            if (!include)
            {
                return queryable;
            }

            return queryable
                // .Include(x => x.xxx) // TODO: AbpHelper generated
                ;
        }
    }
}