using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;
using EasyAbp.Forum.Communities;
using EasyAbp.Forum.Posts;
using EasyAbp.Forum.Comments;
using EasyAbp.Forum.Users;

namespace EasyAbp.Forum.EntityFrameworkCore
{
    [ConnectionStringName(ForumDbProperties.ConnectionStringName)]
    public class ForumDbContext : AbpDbContext<ForumDbContext>, IForumDbContext
    {
        /* Add DbSet for each Aggregate Root here. Example:
         * public DbSet<Question> Questions { get; set; }
         */
        public DbSet<Community> Communities { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<PostContent> PostContents { get; set; }
        public DbSet<ForumUser> ForumUsers { get; set; }

        public ForumDbContext(DbContextOptions<ForumDbContext> options) 
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ConfigureForum();
        }
    }
}
