using EasyAbp.Forum.Localization;
using Volo.Abp.Application.Services;

namespace EasyAbp.Forum
{
    public abstract class ForumAppService : ApplicationService
    {
        protected ForumAppService()
        {
            LocalizationResource = typeof(ForumResource);
            ObjectMapperContext = typeof(ForumApplicationModule);
        }
    }
}
