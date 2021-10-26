using Volo.Abp.AspNetCore.Components.WebAssembly.Theming;
using Volo.Abp.Modularity;

namespace EasyAbp.Forum.Blazor.WebAssembly
{
    [DependsOn(
        typeof(ForumBlazorModule),
        typeof(ForumHttpApiClientModule),
        typeof(AbpAspNetCoreComponentsWebAssemblyThemingModule)
        )]
    public class ForumBlazorWebAssemblyModule : AbpModule
    {
        
    }
}