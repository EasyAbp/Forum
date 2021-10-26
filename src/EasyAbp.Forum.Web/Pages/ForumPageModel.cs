using EasyAbp.Forum.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace EasyAbp.Forum.Web.Pages
{
    /* Inherit your PageModel classes from this class.
     */
    public abstract class ForumPageModel : AbpPageModel
    {
        protected ForumPageModel()
        {
            LocalizationResourceType = typeof(ForumResource);
            ObjectMapperContext = typeof(ForumWebModule);
        }
    }
}