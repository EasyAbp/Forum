using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace EasyAbp.Forum.MongoDB
{
    [ConnectionStringName(ForumDbProperties.ConnectionStringName)]
    public class ForumMongoDbContext : AbpMongoDbContext, IForumMongoDbContext
    {
        /* Add mongo collections here. Example:
         * public IMongoCollection<Question> Questions => Collection<Question>();
         */

        protected override void CreateModel(IMongoModelBuilder modelBuilder)
        {
            base.CreateModel(modelBuilder);

            modelBuilder.ConfigureForum();
        }
    }
}