using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace EasyAbp.Forum.EntityFrameworkCore
{
    public class ForumHttpApiHostMigrationsDbContextFactory : IDesignTimeDbContextFactory<ForumHttpApiHostMigrationsDbContext>
    {
        public ForumHttpApiHostMigrationsDbContext CreateDbContext(string[] args)
        {
            var configuration = BuildConfiguration();

            var builder = new DbContextOptionsBuilder<ForumHttpApiHostMigrationsDbContext>()
                .UseSqlServer(configuration.GetConnectionString("Forum"));

            return new ForumHttpApiHostMigrationsDbContext(builder.Options);
        }

        private static IConfigurationRoot BuildConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false);

            return builder.Build();
        }
    }
}
