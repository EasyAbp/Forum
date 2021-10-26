using JetBrains.Annotations;
using Volo.Abp.MongoDB;

namespace EasyAbp.Forum.MongoDB
{
    public class ForumMongoModelBuilderConfigurationOptions : AbpMongoModelBuilderConfigurationOptions
    {
        public ForumMongoModelBuilderConfigurationOptions(
            [NotNull] string collectionPrefix = "")
            : base(collectionPrefix)
        {
        }
    }
}