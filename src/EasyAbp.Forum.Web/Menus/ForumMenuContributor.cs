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
            
            var forumManagement = new ApplicationMenuItem(ForumMenus.Prefix,
                l["Menu:ForumManagement"]);

            if (await context.IsGrantedAsync(ForumPermissions.Community.Default))
            {
                forumManagement.AddItem(
                    new ApplicationMenuItem(ForumMenus.Community, l["Menu:Community"], "/Forum/Management/Communities/Community")
                );
            }
            if (await context.IsGrantedAsync(ForumPermissions.Post.Manage))
            {
                forumManagement.AddItem(
                    new ApplicationMenuItem(ForumMenus.Post, l["Menu:Post"], "/Forum/Management/Posts/Post")
                );
            }
            if (await context.IsGrantedAsync(ForumPermissions.Comment.Manage))
            {
                forumManagement.AddItem(
                    new ApplicationMenuItem(ForumMenus.Comment, l["Menu:Comment"], "/Forum/Management/Comments/Comment")
                );
            }

            if (forumManagement.Items.Any())
            {
                context.Menu.AddItem(forumManagement);
            }
        }
    }
}
