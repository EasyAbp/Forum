using System.ComponentModel.DataAnnotations;

namespace EasyAbp.Forum.Web.Pages.Forum.Comment.ViewModels
{
    public class EditCommentViewModel
    {
        [Display(Name = "CommentText")]
        public string Text { get; set; }
    }
}