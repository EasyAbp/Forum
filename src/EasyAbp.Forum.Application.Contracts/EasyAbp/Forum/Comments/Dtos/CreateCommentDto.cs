using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.ObjectExtending;
using Volo.Abp.Validation;

namespace EasyAbp.Forum.Comments.Dtos
{
    [Serializable]
    public class CreateCommentDto
    {
        public Guid? ParentId { get; set; }

        public Guid PostId { get; set; }

        [Required]
        [DynamicStringLength(
            typeof(ForumConsts.Comment),
            nameof(ForumConsts.Comment.TextMaxLength),
            nameof(ForumConsts.Comment.TextMinLength)
        )]
        public string Text { get; set; }
    }
}