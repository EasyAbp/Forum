using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace EasyAbp.Forum
{
    [DependsOn(
        typeof(AbpDddDomainModule),
        typeof(ForumDomainSharedModule)
    )]
    public class ForumDomainModule : AbpModule
    {

    }
}
