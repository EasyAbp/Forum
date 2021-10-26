using EasyAbp.Forum.Communities;
using EasyAbp.Forum.Communities.Dtos;
using EasyAbp.Forum.Posts;
using EasyAbp.Forum.Posts.Dtos;
using EasyAbp.Forum.Comments;
using EasyAbp.Forum.Comments.Dtos;
using AutoMapper;

namespace EasyAbp.Forum
{
    public class ForumApplicationAutoMapperProfile : Profile
    {
        public ForumApplicationAutoMapperProfile()
        {
            /* You can configure your AutoMapper mapping configuration here.
             * Alternatively, you can split your mapping configurations
             * into multiple profile classes for a better organization. */
            CreateMap<Community, CommunityDto>();
            CreateMap<PostContent, PostContentDto>();
            CreateMap<Post, PostDto>();
            CreateMap<Comment, CommentDto>();
        }
    }
}
