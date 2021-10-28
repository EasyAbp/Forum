using System;
using System.Linq;
using System.Threading.Tasks;
using EasyAbp.Forum.Communities;
using EasyAbp.Forum.Permissions;
using EasyAbp.Forum.Posts.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace EasyAbp.Forum.Posts
{
    public class PostAppService : CrudAppService<Post, PostDto, Guid, GetPostListInput, CreatePostDto, UpdatePostDto>,
        IPostAppService
    {
        protected override string GetPolicyName { get; set; } = null;
        protected override string GetListPolicyName { get; set; } = null;
        protected override string CreatePolicyName { get; set; } = ForumPermissions.Post.Create;
        protected override string UpdatePolicyName { get; set; } = ForumPermissions.Post.Update;
        protected override string DeletePolicyName { get; set; } = ForumPermissions.Post.Delete;

        private readonly IPostOutlineGenerator _postOutlineGenerator;
        private readonly ICommunityRepository _communityRepository;
        private readonly IPostRepository _repository;
        
        public PostAppService(
            IPostOutlineGenerator postOutlineGenerator,
            ICommunityRepository communityRepository,
            IPostRepository repository) : base(repository)
        {
            _postOutlineGenerator = postOutlineGenerator;
            _communityRepository = communityRepository;
            _repository = repository;
        }

        protected override async Task<IQueryable<Post>> CreateFilteredQueryAsync(GetPostListInput input)
        {
            return (await base.CreateFilteredQueryAsync(input))
                .WhereIf(input.CommunityId.HasValue, x => x.CommunityId == input.CommunityId.Value)
                .WhereIf(input.PinnedOnly, x => x.Pinned);
        }

        protected override async Task<Post> MapToEntityAsync(CreatePostDto createInput)
        {
            return new(GuidGenerator.Create(), CurrentTenant.Id, createInput.CommunityId, createInput.Title,
                await _postOutlineGenerator.CreateAsync(createInput.Content.Text), null, createInput.Content.Text,
                false);
        }

        protected override async Task MapToEntityAsync(UpdatePostDto updateInput, Post entity)
        {
            entity.Update(updateInput.Title, await _postOutlineGenerator.CreateAsync(updateInput.Content.Text),
                entity.Thumbnail, updateInput.Content.Text);
        }

        public override async Task<PostDto> CreateAsync(CreatePostDto input)
        {
            await CheckCreatePolicyAsync();

            await _communityRepository.GetAsync(input.CommunityId);

            var entity = await MapToEntityAsync(input);

            await Repository.InsertAsync(entity, autoSave: true);

            return await MapToGetOutputDtoAsync(entity);
        }

        public override async Task<PostDto> UpdateAsync(Guid id, UpdatePostDto input)
        {
            await CheckUpdatePolicyAsync();

            var entity = await GetEntityByIdAsync(id);

            await MapToEntityAsync(input, entity);
            
            await Repository.UpdateAsync(entity, autoSave: true);

            return await MapToGetOutputDtoAsync(entity);
        }

        public virtual async Task PinAsync(Guid id)
        {
            await CheckPinPolicyAsync();

            var post = await GetEntityByIdAsync(id);

            post.SetPinned(true);

            await _repository.UpdateAsync(post, true);
        }

        public virtual async Task UnpinAsync(Guid id)
        {
            await CheckPinPolicyAsync();
            
            var post = await GetEntityByIdAsync(id);

            post.SetPinned(false);

            await _repository.UpdateAsync(post, true);
        }
        
        protected virtual async Task CheckPinPolicyAsync()
        {
            await CheckPolicyAsync(ForumPermissions.Post.Pin);
        }
    }
}
