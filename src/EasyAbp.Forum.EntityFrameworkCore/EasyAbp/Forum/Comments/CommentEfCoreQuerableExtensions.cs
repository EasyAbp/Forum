using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace EasyAbp.Forum.Comments
{
    public static class CommentEfCoreQueryableExtensions
    {
        public static IQueryable<Comment> IncludeDetails(this IQueryable<Comment> queryable, bool include = true)
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