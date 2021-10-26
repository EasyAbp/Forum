using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;

namespace EasyAbp.Forum.Pages
{
    public class IndexModel : ForumPageModel
    {
        public void OnGet()
        {
            
        }

        public async Task OnPostLoginAsync()
        {
            await HttpContext.ChallengeAsync("oidc");
        }
    }
}