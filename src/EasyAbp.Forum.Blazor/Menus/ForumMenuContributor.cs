using System.Linq;
using System.Threading.Tasks;
using EasyAbp.Forum.Localization;
using EasyAbp.Forum.Permissions;
using Volo.Abp.UI.Navigation;

namespace EasyAbp.Forum.Blazor.Menus
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
                l["Menu:Forum"], "~/Forum", icon: "fa fa-comments"));
            
            var forumManagement = new ApplicationMenuItem(ForumMenus.ManagementPrefix,
                l["Menu:ForumManagement"], icon: "fa fa-comments");

            if (await context.IsGrantedAsync(ForumPermissions.Community.Default))
            {
                forumManagement.AddItem(new ApplicationMenuItem(
                    ForumMenus.ManagementCommunity,
                    l["Menu:Community"],
                    "/Forum/Management/Communities/Community"));
            }

            if (forumManagement.Items.Any())
            {
                context.Menu.GetAdministration().AddItem(forumManagement);
            }
        }
    }
}
