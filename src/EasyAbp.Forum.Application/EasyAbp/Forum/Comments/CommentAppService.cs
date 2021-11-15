using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasyAbp.Forum.Comments.Dtos;
using EasyAbp.Forum.Permissions;
using EasyAbp.Forum.Posts;
using EasyAbp.Forum.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Validation;

namespace EasyAbp.Forum.Comments
{
    public class CommentAppService : CrudAppService<Comment, CommentDto, Guid, GetCommentListInput, CreateCommentDto, UpdateCommentDto>,
        ICommentAppService
    {
        private readonly IForumUserLookupService _forumUserLookupService;
        private readonly IPostRepository _postRepository;
        private readonly ICommentRepository _repository;
        
        public CommentAppService(
            IForumUserLookupService forumUserLookupService,
            IPostRepository postRepository,
            ICommentRepository repository) : base(repository)
        {
            _forumUserLookupService = forumUserLookupService;
            _postRepository = postRepository;
            _repository = repository;
        }

        protected override async Task<IQueryable<Comment>> CreateFilteredQueryAsync(GetCommentListInput input)
        {
            return (await base.CreateFilteredQueryAsync(input))
                .Where(x => x.PostId == input.PostId)
                .Where(x => x.ParentId == input.ParentId);
        }

        protected override IQueryable<Comment> ApplyDefaultSorting(IQueryable<Comment> query)
        {
            return query.OrderBy(e => e.Id);
        }

        protected override Task<Comment> MapToEntityAsync(CreateCommentDto createInput)
        {
            return Task.FromResult(new Comment(GuidGenerator.Create(), CurrentTenant.Id, createInput.ParentId,
                createInput.PostId, createInput.Text));
        }

        protected override Task MapToEntityAsync(UpdateCommentDto updateInput, Comment entity)
        {
            entity.Update(updateInput.Text);
            
            return Task.CompletedTask;
        }
        
        protected override async Task<CommentDto> MapToGetOutputDtoAsync(Comment entity)
        {
            var dto = await base.MapToGetOutputDtoAsync(entity);

            if (!dto.CreatorId.HasValue)
            {
                return dto;
            }

            dto.CreatorUserName = (await _forumUserLookupService.FindByIdAsync(dto.CreatorId.Value))?.UserName;

            return dto;
        }
        
        protected virtual CommentOperationInfoModel CreateCommentOperationInfoModel(Comment comment, Guid communityId)
        {
            return new()
            {
                CommunityId = communityId,
                PostId = comment.PostId,
                Comment = comment
            };
        }

        public override async Task<CommentDto> GetAsync(Guid id)
        {
            var comment = await GetEntityByIdAsync(id);
            
            var post = await _postRepository.GetAsync(comment.PostId);

            await AuthorizationService.CheckAsync(CreateCommentOperationInfoModel(comment, post.CommunityId),
                new OperationAuthorizationRequirement {Name = ForumPermissions.Comment.Default});

            return await MapToGetOutputDtoAsync(comment);
        }

        public override async Task<PagedResultDto<CommentDto>> GetListAsync(GetCommentListInput input)
        {
            var post = await _postRepository.GetAsync(input.PostId);

            await AuthorizationService.CheckAsync(new CommentOperationInfoModel
                    {CommunityId = post.CommunityId, PostId = input.PostId, ParentId = input.ParentId},
                new OperationAuthorizationRequirement {Name = ForumPermissions.Comment.Default});
            
            var query = await CreateFilteredQueryAsync(input);

            var totalCount = await AsyncExecuter.CountAsync(query);

            query = ApplySorting(query, input);
            query = ApplyPaging(query, input);

            var entities = await _repository.GetCommentWithCreatorInfoListAsync(query);
            var entityDtos = ObjectMapper.Map<List<CommentWithCreatorInfo>, List<CommentDto>>(entities);

            return new PagedResultDto<CommentDto>(
                totalCount,
                entityDtos
            );
        }

        public override async Task<CommentDto> CreateAsync(CreateCommentDto input)
        {
            var post = await _postRepository.GetAsync(input.PostId);

            if (input.ParentId.HasValue)
            {
                var parent = await _repository.GetAsync(input.ParentId.Value);

                if (parent.PostId != post.Id || parent.ParentId.HasValue)
                {
                    throw new AbpValidationException();
                }
            }

            var comment = await MapToEntityAsync(input);
            
            await AuthorizationService.CheckAsync(CreateCommentOperationInfoModel(comment, post.CommunityId),
                new OperationAuthorizationRequirement {Name = ForumPermissions.Comment.Create});

            await Repository.InsertAsync(comment, autoSave: true);

            return await MapToGetOutputDtoAsync(comment);
        }

        public override async Task<CommentDto> UpdateAsync(Guid id, UpdateCommentDto input)
        {
            var comment = await GetEntityByIdAsync(id);

            var post = await _postRepository.GetAsync(comment.PostId);

            await MapToEntityAsync(input, comment);
            
            await AuthorizationService.CheckAsync(CreateCommentOperationInfoModel(comment, post.CommunityId),
                new OperationAuthorizationRequirement {Name = ForumPermissions.Comment.Update});
            
            await Repository.UpdateAsync(comment, autoSave: true);

            return await MapToGetOutputDtoAsync(comment);
        }

        public override async Task DeleteAsync(Guid id)
        {
            var comment = await GetEntityByIdAsync(id);

            var post = await _postRepository.GetAsync(comment.PostId);
            
            await AuthorizationService.CheckAsync(CreateCommentOperationInfoModel(comment, post.CommunityId),
                new OperationAuthorizationRequirement {Name = ForumPermissions.Comment.Delete});

            await _repository.DeleteAsync(comment);
        }
    }
}
