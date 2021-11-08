using System.Linq;
using System.Threading.Tasks;
using EasyAbp.Forum.Localization;
using EasyAbp.Forum.Permissions;
using Volo.Abp.UI.Navigation;

namespace EasyAbp.Forum.Web.Menus
{
    public class ForumMenuContributor : IMenuContributor
    {
        public async Task ConfigureMenuAsync(MenuConfigurationContext context)
        {
            if (context.Menu.Name == StandardMenus.Main)
            {
                await ConfigureMainMenuAsync(context);
            }
        }

        private async Task ConfigureMainMenuAsync(MenuConfigurationContext context)
        {
            var l = context.GetLocalizer<ForumResource>();
            
            //Add main menu items.

            var forum = context.Menu.AddItem(new ApplicationMenuItem(ForumMenus.Prefix,
                l["Menu:Forum"], "~/Forum"));
            
            var forumManagement = new ApplicationMenuItem(ForumMenus.ManagementPrefix,
                l["Menu:ForumManagement"]);

            if (await context.IsGrantedAsync(ForumPermissions.Community.Default))
            {
                forumManagement.AddItem(new ApplicationMenuItem(
                    ForumMenus.ManagementCommunity,
                    l["Menu:Community"],
                    "/Forum/Management/Communities/Community"));
            }

            if (forumManagement.Items.Any())
            {
                context.Menu.AddItem(forumManagement);
            }
        }
    }
}
