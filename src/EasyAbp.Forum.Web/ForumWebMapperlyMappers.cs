using EasyAbp.Forum.Comments.Dtos;
using EasyAbp.Forum.Communities.Dtos;
using EasyAbp.Forum.Posts.Dtos;
using EasyAbp.Forum.Web.Pages.Forum.Comment.ViewModels;
using EasyAbp.Forum.Web.Pages.Forum.Management.Communities.Community.ViewModels;
using EasyAbp.Forum.Web.Pages.Forum.Post.ViewModels;
using Riok.Mapperly.Abstractions;
using Volo.Abp.Mapperly;

namespace EasyAbp.Forum.Web
{
    [Mapper(RequiredMappingStrategy = RequiredMappingStrategy.Target)]
    public partial class CommunityDtoToCreateEditCommunityViewModelMapper : MapperBase<CommunityDto, CreateEditCommunityViewModel>
    {
        public override partial CreateEditCommunityViewModel Map(CommunityDto source);
        public override partial void Map(CommunityDto source, CreateEditCommunityViewModel destination);
    }

    [Mapper(RequiredMappingStrategy = RequiredMappingStrategy.Target)]
    public partial class CreateEditCommunityViewModelToCreateUpdateCommunityDtoMapper : MapperBase<CreateEditCommunityViewModel, CreateUpdateCommunityDto>
    {
        [MapperIgnoreTarget(nameof(CreateUpdateCommunityDto.ExtraProperties))]
        public override partial CreateUpdateCommunityDto Map(CreateEditCommunityViewModel source);

        [MapperIgnoreTarget(nameof(CreateUpdateCommunityDto.ExtraProperties))]
        public override partial void Map(CreateEditCommunityViewModel source, CreateUpdateCommunityDto destination);
    }

    [Mapper(RequiredMappingStrategy = RequiredMappingStrategy.Target)]
    public partial class PostDtoToEditPostViewModelMapper : MapperBase<PostDto, EditPostViewModel>
    {
        public override partial EditPostViewModel Map(PostDto source);
        public override partial void Map(PostDto source, EditPostViewModel destination);
    }

    [Mapper(RequiredMappingStrategy = RequiredMappingStrategy.Target)]
    public partial class CreatePostViewModelToCreatePostDtoMapper : MapperBase<CreatePostViewModel, CreatePostDto>
    {
        [MapperIgnoreTarget(nameof(CreatePostDto.ExtraProperties))]
        public override partial CreatePostDto Map(CreatePostViewModel source);

        [MapperIgnoreTarget(nameof(CreatePostDto.ExtraProperties))]
        public override partial void Map(CreatePostViewModel source, CreatePostDto destination);
    }

    [Mapper(RequiredMappingStrategy = RequiredMappingStrategy.Target)]
    public partial class EditPostViewModelToUpdatePostDtoMapper : MapperBase<EditPostViewModel, UpdatePostDto>
    {
        [MapperIgnoreTarget(nameof(UpdatePostDto.ExtraProperties))]
        public override partial UpdatePostDto Map(EditPostViewModel source);

        [MapperIgnoreTarget(nameof(UpdatePostDto.ExtraProperties))]
        public override partial void Map(EditPostViewModel source, UpdatePostDto destination);
    }

    [Mapper(RequiredMappingStrategy = RequiredMappingStrategy.Target)]
    public partial class PostContentDtoToCreateEditPostContentViewModelMapper : MapperBase<PostContentDto, CreateEditPostContentViewModel>
    {
        public override partial CreateEditPostContentViewModel Map(PostContentDto source);
        public override partial void Map(PostContentDto source, CreateEditPostContentViewModel destination);
    }

    [Mapper(RequiredMappingStrategy = RequiredMappingStrategy.Target)]
    public partial class CreateEditPostContentViewModelToCreateUpdatePostContentDtoMapper : MapperBase<CreateEditPostContentViewModel, CreateUpdatePostContentDto>
    {
        public override partial CreateUpdatePostContentDto Map(CreateEditPostContentViewModel source);
        public override partial void Map(CreateEditPostContentViewModel source, CreateUpdatePostContentDto destination);
    }

    [Mapper(RequiredMappingStrategy = RequiredMappingStrategy.Target)]
    public partial class CommentDtoToEditCommentViewModelMapper : MapperBase<CommentDto, EditCommentViewModel>
    {
        public override partial EditCommentViewModel Map(CommentDto source);
        public override partial void Map(CommentDto source, EditCommentViewModel destination);
    }

    [Mapper(RequiredMappingStrategy = RequiredMappingStrategy.Target)]
    public partial class EditCommentViewModelToUpdateCommentDtoMapper : MapperBase<EditCommentViewModel, UpdateCommentDto>
    {
        [MapperIgnoreTarget(nameof(UpdateCommentDto.ExtraProperties))]
        public override partial UpdateCommentDto Map(EditCommentViewModel source);

        [MapperIgnoreTarget(nameof(UpdateCommentDto.ExtraProperties))]
        public override partial void Map(EditCommentViewModel source, UpdateCommentDto destination);
    }
}
