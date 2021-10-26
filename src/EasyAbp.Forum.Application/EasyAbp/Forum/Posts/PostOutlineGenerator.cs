using System.Threading.Tasks;
using EasyAbp.Forum.Settings;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Settings;

namespace EasyAbp.Forum.Posts
{
    public class PostOutlineGenerator : IPostOutlineGenerator, ITransientDependency
    {
        private readonly ISettingProvider _settingProvider;

        public PostOutlineGenerator(ISettingProvider settingProvider)
        {
            _settingProvider = settingProvider;
        }
        
        public virtual async Task<string> CreateAsync(string contentText)
        {
            var outlineLength = await _settingProvider.GetAsync<int>(ForumSettings.Post.OutlineLength);
            
            return contentText.Substring(0, outlineLength);
        }
    }
}