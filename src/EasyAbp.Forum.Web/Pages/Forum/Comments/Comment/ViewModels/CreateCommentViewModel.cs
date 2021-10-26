using System;
using System.ComponentModel.DataAnnotations;

namespace EasyAbp.Forum.Web.Pages.Forum.Comments.Comment.ViewModels
{
    public class CreateCommentViewModel
    {
        [Display(Name = "CommentParentId")]
        public Guid? ParentId { get; set; }

        [Display(Name = "CommentPostId")]
        public Guid PostId { get; set; }

        [Display(Name = "CommentText")]
        public string Text { get; set; }
    }
}