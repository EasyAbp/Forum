using System;
using JetBrains.Annotations;
using Volo.Abp.Domain.Entities;

namespace EasyAbp.Forum.Posts
{
    public class PostContent : Entity
    {
        public virtual Guid PostId { get; protected set; }
        
        [CanBeNull]
        public virtual string Text { get; protected set; }

        public override object[] GetKeys()
        {
            return new object[] {PostId};
        }

        protected PostContent()
        {
        }

        public PostContent(
            Guid postId,
            [CanBeNull] string text
        )
        {
            PostId = postId;
            
            Update(text);
        }

        public void Update(string text)
        {
            Text = text;
        }
    }
}
