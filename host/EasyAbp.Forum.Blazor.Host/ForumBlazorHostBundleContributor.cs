using Volo.Abp.Bundling;

namespace EasyAbp.Forum.Blazor.Host
{
    public class ForumBlazorHostBundleContributor : IBundleContributor
    {
        public void AddScripts(BundleContext context)
        {

        }

        public void AddStyles(BundleContext context)
        {
            context.Add("main.css", true);
        }
    }
}
