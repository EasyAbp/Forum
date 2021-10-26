using System.Data;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace EasyAbp.Forum.Communities
{
    public class CommunityManager : DomainService, ICommunityManager
    {
        private readonly ICommunityRepository _communityRepository;

        public CommunityManager(ICommunityRepository communityRepository)
        {
            _communityRepository = communityRepository;
        }
        
        public virtual async Task<Community> CreateAsync(string name, string displayName, string description)
        {
            if (await _communityRepository.AnyAsync(x => x.Name == name))
            {
                throw new DuplicateNameException();
            }
            
            return new Community(GuidGenerator.Create(), CurrentTenant.Id, name, displayName, description);
        }
    }
}