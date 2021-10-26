using Volo.Abp.AspNetCore.Components.Server.Theming;
using Volo.Abp.Modularity;

namespace EasyAbp.Forum.Blazor.Server
{
    [DependsOn(
        typeof(AbpAspNetCoreComponentsServerThemingModule),
        typeof(ForumBlazorModule)
        )]
    public class ForumBlazorServerModule : AbpModule
    {
        
    }
}