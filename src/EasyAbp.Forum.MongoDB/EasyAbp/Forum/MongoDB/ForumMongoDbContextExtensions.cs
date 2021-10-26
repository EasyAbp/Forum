using System;
using Volo.Abp;
using Volo.Abp.MongoDB;

namespace EasyAbp.Forum.MongoDB
{
    public static class ForumMongoDbContextExtensions
    {
        public static void ConfigureForum(
            this IMongoModelBuilder builder,
            Action<AbpMongoModelBuilderConfigurationOptions> optionsAction = null)
        {
            Check.NotNull(builder, nameof(builder));

            var options = new ForumMongoModelBuilderConfigurationOptions(
                ForumDbProperties.DbTablePrefix
            );

            optionsAction?.Invoke(options);
        }
    }
}