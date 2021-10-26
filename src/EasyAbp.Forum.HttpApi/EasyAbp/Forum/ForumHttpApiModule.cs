using Localization.Resources.AbpUi;
using EasyAbp.Forum.Localization;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Microsoft.Extensions.DependencyInjection;

namespace EasyAbp.Forum
{
    [DependsOn(
        typeof(ForumApplicationContractsModule),
        typeof(AbpAspNetCoreMvcModule))]
    public class ForumHttpApiModule : AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            PreConfigure<IMvcBuilder>(mvcBuilder =>
            {
                mvcBuilder.AddApplicationPartIfNotExists(typeof(ForumHttpApiModule).Assembly);
            });
        }

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources
                    .Get<ForumResource>()
                    .AddBaseTypes(typeof(AbpUiResource));
            });
        }
    }
}
