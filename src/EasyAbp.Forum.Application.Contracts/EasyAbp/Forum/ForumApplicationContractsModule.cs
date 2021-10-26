using Volo.Abp.Application;
using Volo.Abp.Modularity;
using Volo.Abp.Authorization;

namespace EasyAbp.Forum
{
    [DependsOn(
        typeof(ForumDomainSharedModule),
        typeof(AbpDddApplicationContractsModule),
        typeof(AbpAuthorizationModule)
        )]
    public class ForumApplicationContractsModule : AbpModule
    {

    }
}
