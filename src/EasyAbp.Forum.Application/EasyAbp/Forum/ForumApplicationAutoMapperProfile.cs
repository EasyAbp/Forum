using EasyAbp.Forum.Communities;
using EasyAbp.Forum.Communities.Dtos;
using EasyAbp.Forum.Posts;
using EasyAbp.Forum.Posts.Dtos;
using EasyAbp.Forum.Comments;
using EasyAbp.Forum.Comments.Dtos;
using AutoMapper;
using Volo.Abp.AutoMapper;

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
            CreateMap<Post, PostDto>()
                .Ignore(x => x.CreatorUserName);
            CreateMap<PostWithCreatorInfo, PostDto>()
                .ConstructUsing((src, ctx) => ctx.Mapper.Map<PostDto>(src.Post))
                .ForMember(x => x.CreatorUserName, x => x.MapFrom(y => y.CreatorUserName))
                .ForAllOtherMembers(o => o.Ignore());
            CreateMap<Comment, CommentDto>()
                .Ignore(x => x.CreatorUserName);
            CreateMap<CommentWithCreatorInfo, CommentDto>()
                .ConstructUsing((src, ctx) => ctx.Mapper.Map<CommentDto>(src.Comment))
                .ForMember(x => x.CreatorUserName, x => x.MapFrom(y => y.CreatorUserName))
                .ForAllOtherMembers(o => o.Ignore());
        }
    }
}
