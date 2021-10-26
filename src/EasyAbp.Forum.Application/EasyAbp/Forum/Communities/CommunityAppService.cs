using System;
using System.Threading.Tasks;
using EasyAbp.Forum.Permissions;
using EasyAbp.Forum.Communities.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace EasyAbp.Forum.Communities
{
    public class CommunityAppService : CrudAppService<Community, CommunityDto, Guid, PagedAndSortedResultRequestDto, CreateUpdateCommunityDto, CreateUpdateCommunityDto>,
        ICommunityAppService
    {
        protected override string GetPolicyName { get; set; } = null;
        protected override string GetListPolicyName { get; set; } = null;
        protected override string CreatePolicyName { get; set; } = ForumPermissions.Community.Create;
        protected override string UpdatePolicyName { get; set; } = ForumPermissions.Community.Update;
        protected override string DeletePolicyName { get; set; } = ForumPermissions.Community.Delete;

        private readonly ICommunityManager _communityManager;
        private readonly ICommunityRepository _repository;
        
        public CommunityAppService(
            ICommunityManager communityManager,
            ICommunityRepository repository) : base(repository)
        {
            _communityManager = communityManager;
            _repository = repository;
        }

        protected override async Task<Community> MapToEntityAsync(CreateUpdateCommunityDto createInput)
        {
            return await _communityManager.CreateAsync(createInput.Name, createInput.DisplayName,
                createInput.Description);
        }

        protected override Task MapToEntityAsync(CreateUpdateCommunityDto updateInput, Community entity)
        {
            entity.Update(updateInput.Name, updateInput.DisplayName, updateInput.Description);
            
            return Task.CompletedTask;
        }

        public override async Task<CommunityDto> CreateAsync(CreateUpdateCommunityDto input)
        {
            await CheckCreatePolicyAsync();

            var entity = await MapToEntityAsync(input);

            await Repository.InsertAsync(entity, autoSave: true);

            return await MapToGetOutputDtoAsync(entity);
        }

        public override async Task<CommunityDto> UpdateAsync(Guid id, CreateUpdateCommunityDto input)
        {
            await CheckUpdatePolicyAsync();

            var entity = await GetEntityByIdAsync(id);
            
            await MapToEntityAsync(input, entity);
            
            await Repository.UpdateAsync(entity, autoSave: true);

            return await MapToGetOutputDtoAsync(entity);
        }
    }
}
