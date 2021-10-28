using EasyAbp.Forum.Localization;
using Volo.Abp.Localization;
using Volo.Abp.Settings;

namespace EasyAbp.Forum.Settings
{
    public class ForumSettingDefinitionProvider : SettingDefinitionProvider
    {
        public override void Define(ISettingDefinitionContext context)
        {
            /* Define module settings here.
             * Use names from ForumSettings class.
             */
            
            context.Add(new SettingDefinition(
                ForumSettings.Post.OutlineLength,
                "600",
                L($"Setting:{ForumSettings.Post.OutlineLength}"),
                isVisibleToClients: true));
        }
        
        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<ForumResource>(name);
        }
    }
}