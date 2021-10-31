using System.ComponentModel.DataAnnotations;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;
using Volo.Abp.Validation;

namespace EasyAbp.Forum.Web.Pages.Forum.Post.ViewModels
{
    public class CreateEditPostContentViewModel
    {
        [TextArea(Rows = 6)]
        [Placeholder("PostContentTextPlaceholder")]
        [Display(Name = "PostContentText")]
        [DynamicStringLength(
            typeof(ForumConsts.Post),
            nameof(ForumConsts.Post.ContentTextMaxLength),
            nameof(ForumConsts.Post.ContentTextMinLength)
        )]
        public string Text { get; set; }
    }
}