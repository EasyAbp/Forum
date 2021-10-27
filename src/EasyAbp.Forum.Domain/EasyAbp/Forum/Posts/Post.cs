using System;
using JetBrains.Annotations;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace EasyAbp.Forum.Posts
{
    public class Post : FullAuditedAggregateRoot<Guid>, IMultiTenant
    {
        public virtual Guid? TenantId { get; protected set; }
        
        public virtual Guid CommunityId { get; protected set; }
        
        [NotNull]
        public virtual string Title { get; protected set; }
        
        [CanBeNull]
        public virtual string Outline { get; protected set; }
        
        [CanBeNull]
        public virtual string Thumbnail { get; protected set; }
        
        public virtual PostContent Content { get; protected set; }

        public virtual bool Pinned { get; protected set; }
        
        protected Post()
        {
        }

        public Post(
            Guid id,
            Guid? tenantId,
            Guid communityId,
            [NotNull] string title,
            [CanBeNull] string outline,
            [CanBeNull] string thumbnail,
            [CanBeNull] string contentText,
            bool pinned) : base(id)
        {
            TenantId = tenantId;
            CommunityId = communityId;
            Thumbnail = thumbnail;
            Pinned = pinned;

            Update(title, outline, thumbnail, contentText);
        }

        public void Update(
            [NotNull] string title,
            [CanBeNull] string outline,
            [CanBeNull] string thumbnail,
            [CanBeNull] string contentText)
        {
            Title = title;
            Outline = outline;
            Thumbnail = thumbnail;
            
            if (Content == null)
            {
                Content = new PostContent(Id, contentText);
            }
            else
            {
                Content.Update(contentText);
            }
        }

        public void SetPinned(bool pinned)
        {
            Pinned = pinned;
        }
    }
}
