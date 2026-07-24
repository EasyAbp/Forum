using EasyAbp.Forum.Comments;
using EasyAbp.Forum.Comments.Dtos;
using EasyAbp.Forum.Communities;
using EasyAbp.Forum.Communities.Dtos;
using EasyAbp.Forum.Posts;
using EasyAbp.Forum.Posts.Dtos;
using Riok.Mapperly.Abstractions;
using Volo.Abp.Mapperly;

namespace EasyAbp.Forum
{
    [Mapper(RequiredMappingStrategy = RequiredMappingStrategy.Target)]
    public partial class CommunityToCommunityDtoMapper : MapperBase<Community, CommunityDto>
    {
        public override partial CommunityDto Map(Community source);
        public override partial void Map(Community source, CommunityDto destination);
    }

    [Mapper(RequiredMappingStrategy = RequiredMappingStrategy.Target)]
    public partial class PostContentToPostContentDtoMapper : MapperBase<PostContent, PostContentDto>
    {
        public override partial PostContentDto Map(PostContent source);
        public override partial void Map(PostContent source, PostContentDto destination);
    }

    [Mapper(RequiredMappingStrategy = RequiredMappingStrategy.Target)]
    public partial class PostToPostDtoMapper : MapperBase<Post, PostDto>
    {
        [MapperIgnoreTarget(nameof(PostDto.CreatorUserName))]
        public override partial PostDto Map(Post source);

        [MapperIgnoreTarget(nameof(PostDto.CreatorUserName))]
        public override partial void Map(Post source, PostDto destination);
    }

    [Mapper(RequiredMappingStrategy = RequiredMappingStrategy.Target)]
    public partial class CommentToCommentDtoMapper : MapperBase<Comment, CommentDto>
    {
        [MapperIgnoreTarget(nameof(CommentDto.CreatorUserName))]
        public override partial CommentDto Map(Comment source);

        [MapperIgnoreTarget(nameof(CommentDto.CreatorUserName))]
        public override partial void Map(Comment source, CommentDto destination);
    }
}
