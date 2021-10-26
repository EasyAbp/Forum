using System;

using System.ComponentModel.DataAnnotations;

namespace EasyAbp.Forum.Web.Pages.Forum.Management.Communities.Community.ViewModels
{
    public class CreateEditCommunityViewModel
    {
        [Display(Name = "CommunityName")]
        public string Name { get; set; }

        [Display(Name = "CommunityDisplayName")]
        public string DisplayName { get; set; }

        [Display(Name = "CommunityDescription")]
        public string Description { get; set; }
    }
}