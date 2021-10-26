using Volo.Abp.Validation;

namespace EasyAbp.Forum.Posts.Dtos
{
    public class CreateUpdatePostContentDto
    {
        [DynamicRange(
            typeof(ForumConsts),
            typeof(int),
            nameof(ForumConsts.Post.ContentTextMinLength),
            nameof(ForumConsts.Post.ContentTextMaxLength)
        )]
        public string Text { get; set; }
    }
}