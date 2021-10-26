using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp.Domain.Services;

namespace EasyAbp.Forum.Communities
{
    public interface ICommunityManager : IDomainService
    {
        Task<Community> CreateAsync([NotNull] string name, [NotNull] string displayName, [CanBeNull] string description);
    }
}