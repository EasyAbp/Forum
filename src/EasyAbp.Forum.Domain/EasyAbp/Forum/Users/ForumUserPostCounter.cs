using System.Threading.Tasks;
using EasyAbp.Forum.Posts;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Entities.Events;
using Volo.Abp.EventBus;
using Volo.Abp.Uow;

namespace EasyAbp.Forum.Users
{
    [UnitOfWork]
    public class ForumUserPostCounter :
        ILocalEventHandler<EntityCreatingEventData<Post>>,
        ILocalEventHandler<EntityDeletingEventData<Post>>,
        ITransientDependency
    {
        private readonly IForumUserLookupService _forumUserLookupService;
        private readonly IForumUserRepository _forumUserRepository;

        public ForumUserPostCounter(
            IForumUserLookupService forumUserLookupService,
            IForumUserRepository forumUserRepository)
        {
            _forumUserLookupService = forumUserLookupService;
            _forumUserRepository = forumUserRepository;
        }
        
        public virtual async Task HandleEventAsync(EntityCreatingEventData<Post> eventData)
        {
            if (!eventData.Entity.CreatorId.HasValue)
            {
                return;
            }

            var forumUser = await _forumUserLookupService.FindByIdAsync(eventData.Entity.CreatorId.Value);
            
            forumUser.SetPostCount(forumUser.PostCount + 1);

            await _forumUserRepository.UpdateAsync(forumUser, true);
        }

        public virtual async Task HandleEventAsync(EntityDeletingEventData<Post> eventData)
        {
            if (!eventData.Entity.CreatorId.HasValue)
            {
                return;
            }

            var forumUser = await _forumUserLookupService.FindByIdAsync(eventData.Entity.CreatorId.Value);

            forumUser.SetPostCount(forumUser.PostCount - 1);

            await _forumUserRepository.UpdateAsync(forumUser, true);
        }
    }
}