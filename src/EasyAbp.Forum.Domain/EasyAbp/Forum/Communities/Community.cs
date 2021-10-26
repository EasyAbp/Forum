using System;
using System.Text.RegularExpressions;
using JetBrains.Annotations;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace EasyAbp.Forum.Communities
{
    public class Community : FullAuditedAggregateRoot<Guid>, IMultiTenant
    {
        public virtual Guid? TenantId { get; protected set; }
        
        [NotNull]
        public virtual string Name { get; protected set; }
        
        [NotNull]
        public virtual string DisplayName { get; protected set; }
        
        [CanBeNull]
        public virtual string Description { get; protected set; }

        protected Community()
        {
        }

        public Community(
            Guid id,
            Guid? tenantId,
            [NotNull] string name,
            [NotNull] string displayName,
            [CanBeNull] string description
        ) : base(id)
        {
            TenantId = tenantId;
            
            Update(name, displayName, description);
        }
        
        public void Update(
            [NotNull] string name,
            [NotNull] string displayName,
            [CanBeNull] string description
        )
        {
            Name = CheckName(name);
            DisplayName = displayName;
            Description = description;
        }

        private string CheckName(string name)
        {
            if (!Regex.IsMatch(name, ForumConsts.Community.NameRegexRule))
            {
                throw new WrongCommunityNameException();
            }

            return name;
        }
    }
}
