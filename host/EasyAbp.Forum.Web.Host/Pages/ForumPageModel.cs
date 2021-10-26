using EasyAbp.Forum.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace EasyAbp.Forum.Pages
{
    public abstract class ForumPageModel : AbpPageModel
    {
        protected ForumPageModel()
        {
            LocalizationResourceType = typeof(ForumResource);
        }
    }
}