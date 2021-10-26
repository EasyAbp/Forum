using System.Threading.Tasks;

namespace EasyAbp.Forum.Web.Pages.Forum.Management.Comments.Comment
{
    public class IndexModel : ForumPageModel
    {
        public virtual async Task OnGetAsync()
        {
            await Task.CompletedTask;
        }
    }
}
