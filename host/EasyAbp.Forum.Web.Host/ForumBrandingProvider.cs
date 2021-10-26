using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace EasyAbp.Forum
{
    [Dependency(ReplaceServices = true)]
    public class ForumBrandingProvider : DefaultBrandingProvider
    {
        public override string AppName => "Forum";
    }
}
