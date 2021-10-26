using Volo.Abp.Modularity;

namespace EasyAbp.Forum
{
    [DependsOn(
        typeof(ForumApplicationModule),
        typeof(ForumDomainTestModule)
        )]
    public class ForumApplicationTestModule : AbpModule
    {

    }
}
