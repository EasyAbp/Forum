using System;
using JetBrains.Annotations;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace EasyAbp.Forum.Comments
{
    public class Comment : FullAuditedAggregateRoot<Guid>, IMultiTenant
    {
        public virtual Guid? TenantId { get; protected set; }

        public virtual Guid? ParentId { get; protected set; }

        public virtual Guid PostId { get; protected set; }
        
        [NotNull]
        public virtual string Text { get; protected set; }

        protected Comment()
        {
        }

        public Comment(
            Guid id,
            Guid? tenantId,
            Guid? parentId,
            Guid postId,
            [NotNull] string text
        ) : base(id)
        {
            TenantId = tenantId;
            ParentId = parentId;
            PostId = postId;
            
            Update(text);
        }

        public void Update([NotNull] string text)
        {
            Text = text;
        }
    }
}
