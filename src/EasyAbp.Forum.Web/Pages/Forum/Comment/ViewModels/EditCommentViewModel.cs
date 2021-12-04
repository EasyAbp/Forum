using System.ComponentModel.DataAnnotations;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;

namespace EasyAbp.Forum.Web.Pages.Forum.Comment.ViewModels
{
    public class EditCommentViewModel
    {
        [Display(Name = "CommentText")]
        [TextArea(Rows = 6)]
        public string Text { get; set; }
    }
}