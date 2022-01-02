using System.Threading.Tasks;
using EasyAbp.Forum.Comments;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Entities.Events;
using Volo.Abp.EventBus;
using Volo.Abp.Uow;

namespace EasyAbp.Forum.Users
{
    [UnitOfWork]
    public class ForumUserCommentCounter :
        ILocalEventHandler<EntityCreatedEventData<Comment>>,
        ILocalEventHandler<EntityDeletedEventData<Comment>>,
        ITransientDependency
    {
        private readonly IForumUserLookupService _forumUserLookupService;
        private readonly IForumUserRepository _forumUserRepository;

        public ForumUserCommentCounter(
            IForumUserLookupService forumUserLookupService,
            IForumUserRepository forumUserRepository)
        {
            _forumUserLookupService = forumUserLookupService;
            _forumUserRepository = forumUserRepository;
        }
        
        public virtual async Task HandleEventAsync(EntityCreatedEventData<Comment> eventData)
        {
            if (!eventData.Entity.CreatorId.HasValue)
            {
                return;
            }

            var forumUser = await _forumUserLookupService.FindByIdAsync(eventData.Entity.CreatorId.Value);
            
            forumUser.SetCommentCount(forumUser.CommentCount + 1);

            await _forumUserRepository.UpdateAsync(forumUser, true);
        }

        public virtual async Task HandleEventAsync(EntityDeletedEventData<Comment> eventData)
        {
            if (!eventData.Entity.CreatorId.HasValue)
            {
                return;
            }

            var forumUser = await _forumUserLookupService.FindByIdAsync(eventData.Entity.CreatorId.Value);

            forumUser.SetCommentCount(forumUser.CommentCount - 1);

            await _forumUserRepository.UpdateAsync(forumUser, true);
        }
    }
}