using System.ComponentModel.DataAnnotations;
using Volo.Abp.Validation;

namespace EasyAbp.Forum.Posts.Dtos
{
    public class CreateUpdatePostContentDto
    {
        [DynamicStringLength(
            typeof(ForumConsts.Post),
            nameof(ForumConsts.Post.ContentTextMaxLength),
            nameof(ForumConsts.Post.ContentTextMinLength)
        )]
        public string Text { get; set; }
    }
}