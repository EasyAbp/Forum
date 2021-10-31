using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;
using Volo.Abp.Validation;

namespace EasyAbp.Forum.Web.Pages.Forum.Post.ViewModels
{
    public class CreatePostViewModel
    {
        [HiddenInput]
        [Display(Name = "PostCommunityId")]
        public Guid CommunityId { get; set; }

        [Required]
        [Display(Name = "PostTitle")]
        [Placeholder("PostTitlePlaceholder")]
        [DynamicStringLength(
            typeof(ForumConsts.Post),
            nameof(ForumConsts.Post.TitleMaxLength),
            nameof(ForumConsts.Post.TitleMinLength)
        )]
        public string Title { get; set; }

        [Display(Name = "PostContent")]
        public CreateEditPostContentViewModel Content { get; set; }
    }
}