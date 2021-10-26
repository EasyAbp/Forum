using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace EasyAbp.Forum.MongoDB
{
    [ConnectionStringName(ForumDbProperties.ConnectionStringName)]
    public interface IForumMongoDbContext : IAbpMongoDbContext
    {
        /* Define mongo collections here. Example:
         * IMongoCollection<Question> Questions { get; }
         */
    }
}
