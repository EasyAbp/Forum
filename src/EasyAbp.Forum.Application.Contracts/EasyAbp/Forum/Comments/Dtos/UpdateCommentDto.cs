using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.ObjectExtending;
using Volo.Abp.Validation;

namespace EasyAbp.Forum.Comments.Dtos
{
    [Serializable]
    public class UpdateCommentDto : ExtensibleObject
    {
        [Required]
        [DynamicStringLength(
            typeof(ForumConsts.Comment),
            nameof(ForumConsts.Comment.TextMaxLength),
            nameof(ForumConsts.Comment.TextMinLength)
        )]
        public string Text { get; set; }
    }
}