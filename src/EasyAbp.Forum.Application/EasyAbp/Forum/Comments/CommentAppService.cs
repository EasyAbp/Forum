using System;
using System.Linq;
using System.Threading.Tasks;
using EasyAbp.Forum.Permissions;
using EasyAbp.Forum.Comments.Dtos;
using EasyAbp.Forum.Posts;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Validation;

namespace EasyAbp.Forum.Comments
{
    public class CommentAppService : CrudAppService<Comment, CommentDto, Guid, GetCommentListInput, CreateCommentDto, UpdateCommentDto>,
        ICommentAppService
    {
        protected override string GetPolicyName { get; set; } = null;
        protected override string GetListPolicyName { get; set; } = null;
        protected override string CreatePolicyName { get; set; } = ForumPermissions.Comment.Create;
        protected override string UpdatePolicyName { get; set; } = ForumPermissions.Comment.Update;
        protected override string DeletePolicyName { get; set; } = ForumPermissions.Comment.Delete;

        private readonly IPostRepository _postRepository;
        private readonly ICommentRepository _repository;
        
        public CommentAppService(
            IPostRepository postRepository,
            ICommentRepository repository) : base(repository)
        {
            _postRepository = postRepository;
            _repository = repository;
        }

        protected override async Task<IQueryable<Comment>> CreateFilteredQueryAsync(GetCommentListInput input)
        {
            return (await base.CreateFilteredQueryAsync(input))
                .WhereIf(input.PostId.HasValue, x => x.PostId == input.PostId.Value)
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

        public override async Task<CommentDto> CreateAsync(CreateCommentDto input)
        {
            await CheckCreatePolicyAsync();

            var post = await _postRepository.GetAsync(input.PostId);
            
            if (input.ParentId.HasValue)
            {
                var parent = await _repository.GetAsync(input.ParentId.Value);

                if (parent.PostId != post.Id || parent.ParentId.HasValue)
                {
                    throw new AbpValidationException();
                }
            }

            var entity = await MapToEntityAsync(input);

            await Repository.InsertAsync(entity, autoSave: true);

            return await MapToGetOutputDtoAsync(entity);
        }

        public override async Task<CommentDto> UpdateAsync(Guid id, UpdateCommentDto input)
        {
            await CheckUpdatePolicyAsync();

            var entity = await GetEntityByIdAsync(id);

            await MapToEntityAsync(input, entity);
            
            await Repository.UpdateAsync(entity, autoSave: true);

            return await MapToGetOutputDtoAsync(entity);
        }
    }
}
