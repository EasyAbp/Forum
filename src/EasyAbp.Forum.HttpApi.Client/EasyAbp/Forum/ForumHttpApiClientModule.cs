using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;

namespace EasyAbp.Forum
{
    [DependsOn(
        typeof(ForumApplicationContractsModule),
        typeof(AbpHttpClientModule))]
    public class ForumHttpApiClientModule : AbpModule
    {
        public const string RemoteServiceName = "EasyAbpForum";

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddHttpClientProxies(
                typeof(ForumApplicationContractsModule).Assembly,
                RemoteServiceName
            );
        }
    }
}
