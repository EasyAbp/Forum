using EasyAbp.Forum.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace EasyAbp.Forum
{
    public abstract class ForumController : AbpController
    {
        protected ForumController()
        {
            LocalizationResource = typeof(ForumResource);
        }
    }
}
