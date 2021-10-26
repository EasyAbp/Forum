using EasyAbp.Forum.Localization;
using Volo.Abp.AspNetCore.Components;

namespace EasyAbp.Forum.Blazor.Server.Host
{
    public abstract class ForumComponentBase : AbpComponentBase
    {
        protected ForumComponentBase()
        {
            LocalizationResource = typeof(ForumResource);
        }
    }
}
