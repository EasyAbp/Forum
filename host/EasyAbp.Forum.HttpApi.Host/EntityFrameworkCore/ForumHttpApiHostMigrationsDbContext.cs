using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace EasyAbp.Forum.EntityFrameworkCore
{
    public class ForumHttpApiHostMigrationsDbContext : AbpDbContext<ForumHttpApiHostMigrationsDbContext>
    {
        public ForumHttpApiHostMigrationsDbContext(DbContextOptions<ForumHttpApiHostMigrationsDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ConfigureForum();
        }
    }
}
