using EasyAbp.Forum.Localization;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;

namespace EasyAbp.Forum
{
    [Area(ForumRemoteServiceConsts.ModuleName)]
    public abstract class ForumController : AbpControllerBase
    {
        protected ForumController()
        {
            LocalizationResource = typeof(ForumResource);
        }
    }
}
