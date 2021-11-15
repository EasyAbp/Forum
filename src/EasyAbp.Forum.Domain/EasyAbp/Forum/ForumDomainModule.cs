using Volo.Abp.Domain;
using Volo.Abp.Modularity;
using Volo.Abp.Users;

namespace EasyAbp.Forum
{
    [DependsOn(
        typeof(AbpDddDomainModule),
        typeof(AbpUsersDomainModule),
        typeof(ForumDomainSharedModule)
    )]
    public class ForumDomainModule : AbpModule
    {

    }
}
