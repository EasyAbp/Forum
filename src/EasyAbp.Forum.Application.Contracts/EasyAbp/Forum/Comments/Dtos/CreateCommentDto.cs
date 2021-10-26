using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.ObjectExtending;
using Volo.Abp.Validation;

namespace EasyAbp.Forum.Comments.Dtos
{
    [Serializable]
    public class CreateCommentDto : ExtensibleObject
    {
        public Guid? ParentId { get; set; }

        public Guid PostId { get; set; }

        [DynamicRange(
            typeof(ForumConsts),
            typeof(int),
            nameof(ForumConsts.Comment.TextMinLength),
            nameof(ForumConsts.Comment.TextMaxLength)
        )]
        public string Text { get; set; }
    }
}