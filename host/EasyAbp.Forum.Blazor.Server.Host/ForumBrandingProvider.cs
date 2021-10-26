using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace EasyAbp.Forum.Blazor.Server.Host
{
    [Dependency(ReplaceServices = true)]
    public class ForumBrandingProvider : DefaultBrandingProvider
    {
        public override string AppName => "Forum";
    }
}
