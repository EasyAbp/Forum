using System;

using System.ComponentModel.DataAnnotations;

namespace EasyAbp.Forum.Web.Pages.Forum.Posts.Post.ViewModels
{
    public class EditPostViewModel
    {
        [Display(Name = "PostTitle")]
        public string Title { get; set; }

        [Display(Name = "PostContent")]
        public CreateEditPostContentViewModel Content { get; set; }
    }
}