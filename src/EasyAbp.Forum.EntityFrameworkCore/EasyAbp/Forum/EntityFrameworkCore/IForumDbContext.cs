using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;
using EasyAbp.Forum.Communities;
using EasyAbp.Forum.Posts;
using EasyAbp.Forum.Comments;

namespace EasyAbp.Forum.EntityFrameworkCore
{
    [ConnectionStringName(ForumDbProperties.ConnectionStringName)]
    public interface IForumDbContext : IEfCoreDbContext
    {
        /* Add DbSet for each Aggregate Root here. Example:
         * DbSet<Question> Questions { get; }
         */
        DbSet<Community> Communities { get; set; }
        DbSet<Post> Posts { get; set; }
        DbSet<Comment> Comments { get; set; }
        DbSet<PostContent> PostContents { get; set; }
    }
}
