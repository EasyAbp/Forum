using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace EasyAbp.Forum
{
    [DependsOn(
        typeof(ForumApplicationContractsModule),
        typeof(AbpHttpClientModule))]
    public class ForumHttpApiClientModule : AbpModule
    {
        public const string RemoteServiceName = ForumRemoteServiceConsts.RemoteServiceName;

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddHttpClientProxies(
                typeof(ForumApplicationContractsModule).Assembly,
                RemoteServiceName
            );
            
            Configure<AbpVirtualFileSystemOptions>(options =>
            {
                options.FileSets.AddEmbedded<ForumHttpApiClientModule>();
            });
        }
    }
}
