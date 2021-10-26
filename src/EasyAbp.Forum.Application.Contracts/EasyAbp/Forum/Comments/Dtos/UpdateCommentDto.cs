using System;
using System.ComponentModel;
using Volo.Abp.ObjectExtending;
using Volo.Abp.Validation;

namespace EasyAbp.Forum.Comments.Dtos
{
    [Serializable]
    public class UpdateCommentDto : ExtensibleObject
    {
        [DynamicRange(
            typeof(ForumConsts),
            typeof(int),
            nameof(ForumConsts.Comment.TextMinLength),
            nameof(ForumConsts.Comment.TextMaxLength)
        )]
        public string Text { get; set; }
    }
}