using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace EasyAbp.Forum.Web.Pages.Forum.Post.ViewModels
{
    public class CreatePostViewModel
    {
        [HiddenInput]
        [Display(Name = "PostCommunityId")]
        public Guid CommunityId { get; set; }

        [Display(Name = "PostTitle")]
        public string Title { get; set; }

        [Display(Name = "PostContent")]
        public CreateEditPostContentViewModel Content { get; set; }
    }
}