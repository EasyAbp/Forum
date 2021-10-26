using Volo.Abp.Http.Client.IdentityModel;
using Volo.Abp.Modularity;

namespace EasyAbp.Forum
{
    [DependsOn(
        typeof(ForumHttpApiClientModule),
        typeof(AbpHttpClientIdentityModelModule)
        )]
    public class ForumConsoleApiClientModule : AbpModule
    {
        
    }
}
