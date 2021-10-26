using EasyAbp.Forum.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace EasyAbp.Forum
{
    /* Domain tests are configured to use the EF Core provider.
     * You can switch to MongoDB, however your domain tests should be
     * database independent anyway.
     */
    [DependsOn(
        typeof(ForumEntityFrameworkCoreTestModule)
        )]
    public class ForumDomainTestModule : AbpModule
    {
        
    }
}
