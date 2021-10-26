using JetBrains.Annotations;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace EasyAbp.Forum.EntityFrameworkCore
{
    public class ForumModelBuilderConfigurationOptions : AbpModelBuilderConfigurationOptions
    {
        public ForumModelBuilderConfigurationOptions(
            [NotNull] string tablePrefix = "",
            [CanBeNull] string schema = null)
            : base(
                tablePrefix,
                schema)
        {

        }
    }
}