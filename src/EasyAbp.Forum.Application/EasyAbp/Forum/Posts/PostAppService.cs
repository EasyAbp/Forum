using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasyAbp.Forum.Communities;
using EasyAbp.Forum.Permissions;
using EasyAbp.Forum.Posts.Dtos;
using EasyAbp.Forum.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace EasyAbp.Forum.Posts
{
    public class PostAppService : CrudAppService<Post, PostDto, Guid, GetPostListInput, CreatePostDto, UpdatePostDto>,
        IPostAppService
    {
        private readonly IForumUserLookupService _forumUserLookupService;
        private readonly IPostOutlineGenerator _postOutlineGenerator;
        private readonly ICommunityRepository _communityRepository;
        private readonly IPostRepository _repository;
        
        public PostAppService(
            IForumUserLookupService forumUserLookupService,
            IPostOutlineGenerator postOutlineGenerator,
            ICommunityRepository communityRepository,
            IPostRepository repository) : base(repository)
        {
            _forumUserLookupService = forumUserLookupService;
            _postOutlineGenerator = postOutlineGenerator;
            _communityRepository = communityRepository;
            _repository = repository;
        }

        protected override async Task<IQueryable<Post>> CreateFilteredQueryAsync(GetPostListInput input)
        {
            return (await base.CreateFilteredQueryAsync(input))
                .Where(x => x.CommunityId == input.CommunityId)
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

        protected override async Task<PostDto> MapToGetOutputDtoAsync(Post entity)
        {
            var dto = await base.MapToGetOutputDtoAsync(entity);

            if (!dto.CreatorId.HasValue)
            {
                return dto;
            }

            dto.CreatorUserName = (await _forumUserLookupService.FindByIdAsync(dto.CreatorId.Value))?.UserName;

            return dto;
        }

        protected virtual PostOperationInfoModel CreatePostOperationInfoModel(Post post)
        {
            return new()
            {
                CommunityId = post.CommunityId,
                Post = post
            };
        }

        public override async Task<PostDto> GetAsync(Guid id)
        {
            var post = await GetEntityByIdAsync(id);
            
            await AuthorizationService.CheckAsync(CreatePostOperationInfoModel(post),
                new OperationAuthorizationRequirement {Name = ForumPermissions.Post.Default});

            return await MapToGetOutputDtoAsync(post);
        }

        public override async Task<PagedResultDto<PostDto>> GetListAsync(GetPostListInput input)
        {
            // await AuthorizationService.CheckAsync(new PostOperationInfoModel {CommunityId = input.CommunityId},
            //     new OperationAuthorizationRequirement {Name = ForumPermissions.Post.Default});

            var query = await CreateFilteredQueryAsync(input);

            var totalCount = await AsyncExecuter.CountAsync(query);

            query = ApplySorting(query, input);
            query = ApplyPaging(query, input);

            var entities = await _repository.GetPostWithCreatorInfoListAsync(query);
            var entityDtos = ObjectMapper.Map<List<PostWithCreatorInfo>, List<PostDto>>(entities);

            return new PagedResultDto<PostDto>(
                totalCount,
                entityDtos
            );
        }

        public override async Task<PostDto> CreateAsync(CreatePostDto input)
        {
            var post = await MapToEntityAsync(input);
            
            await AuthorizationService.CheckAsync(CreatePostOperationInfoModel(post),
                new OperationAuthorizationRequirement {Name = ForumPermissions.Post.Create});

            await _communityRepository.GetAsync(input.CommunityId);

            await Repository.InsertAsync(post, autoSave: true);

            return await MapToGetOutputDtoAsync(post);
        }

        public override async Task<PostDto> UpdateAsync(Guid id, UpdatePostDto input)
        {
            var post = await GetEntityByIdAsync(id);

            await MapToEntityAsync(input, post);
            
            await AuthorizationService.CheckAsync(CreatePostOperationInfoModel(post),
                new OperationAuthorizationRequirement {Name = ForumPermissions.Post.Update});
            
            await Repository.UpdateAsync(post, autoSave: true);

            return await MapToGetOutputDtoAsync(post);
        }

        public override async Task DeleteAsync(Guid id)
        {
            var post = await GetEntityByIdAsync(id);

            await AuthorizationService.CheckAsync(CreatePostOperationInfoModel(post),
                new OperationAuthorizationRequirement {Name = ForumPermissions.Post.Delete});

            await _repository.DeleteAsync(post, true);
        }

        public virtual async Task PinAsync(Guid id)
        {
            var post = await GetEntityByIdAsync(id);
            
            await AuthorizationService.CheckAsync(CreatePostOperationInfoModel(post),
                new OperationAuthorizationRequirement {Name = ForumPermissions.Post.Pin});

            post.SetPinned(true);

            await _repository.UpdateAsync(post, true);
        }

        public virtual async Task UnpinAsync(Guid id)
        {
            var post = await GetEntityByIdAsync(id);

            await AuthorizationService.CheckAsync(CreatePostOperationInfoModel(post),
                new OperationAuthorizationRequirement {Name = ForumPermissions.Post.Pin});
            
            post.SetPinned(false);

            await _repository.UpdateAsync(post, true);
        }
    }
}
