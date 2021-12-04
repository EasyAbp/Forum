using EasyAbp.Forum.Communities.Dtos;
using EasyAbp.Forum.Web.Pages.Forum.Management.Communities.Community.ViewModels;
using EasyAbp.Forum.Posts.Dtos;
using EasyAbp.Forum.Web.Pages.Forum.Post.ViewModels;
using AutoMapper;
using EasyAbp.Forum.Comments.Dtos;
using EasyAbp.Forum.Web.Pages.Forum.Comment.ViewModels;
using Volo.Abp.AutoMapper;

namespace EasyAbp.Forum.Web
{
    public class ForumWebAutoMapperProfile : Profile
    {
        public ForumWebAutoMapperProfile()
        {
            /* You can configure your AutoMapper mapping configuration here.
             * Alternatively, you can split your mapping configurations
             * into multiple profile classes for a better organization. */
            CreateMap<CommunityDto, CreateEditCommunityViewModel>();
            CreateMap<CreateEditCommunityViewModel, CreateUpdateCommunityDto>().Ignore(x => x.ExtraProperties);
            CreateMap<PostDto, EditPostViewModel>();
            CreateMap<CreatePostViewModel, CreatePostDto>().Ignore(x => x.ExtraProperties);
            CreateMap<EditPostViewModel, UpdatePostDto>().Ignore(x => x.ExtraProperties);
            CreateMap<PostContentDto, CreateEditPostContentViewModel>();
            CreateMap<CreateEditPostContentViewModel, CreateUpdatePostContentDto>();
            CreateMap<CommentDto, EditCommentViewModel>();
            CreateMap<EditCommentViewModel, UpdateCommentDto>().Ignore(x => x.ExtraProperties);
        }
    }
}
