using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.ObjectExtending;
using Volo.Abp.Validation;

namespace EasyAbp.Forum.Posts.Dtos
{
    [Serializable]
    public class CreatePostDto : ExtensibleObject
    {
        public Guid CommunityId { get; set; }

        [Required]
        [DynamicStringLength(
            typeof(ForumConsts.Post),
            nameof(ForumConsts.Post.TitleMaxLength),
            nameof(ForumConsts.Post.TitleMinLength)
        )]
        public string Title { get; set; }

        public CreateUpdatePostContentDto Content { get; set; }
    }
}