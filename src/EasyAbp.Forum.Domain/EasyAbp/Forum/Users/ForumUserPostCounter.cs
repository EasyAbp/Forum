using System.Threading.Tasks;
using EasyAbp.Forum.Posts;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Entities.Events;
using Volo.Abp.EventBus;
using Volo.Abp.Uow;

namespace EasyAbp.Forum.Users
{
    public class ForumUserPostCounter :
        ILocalEventHandler<EntityCreatedEventData<Post>>,
        ILocalEventHandler<EntityDeletedEventData<Post>>,
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
        
        [UnitOfWork]
        public virtual async Task HandleEventAsync(EntityCreatedEventData<Post> eventData)
        {
            if (!eventData.Entity.CreatorId.HasValue)
            {
                return;
            }

            var forumUser = await _forumUserLookupService.FindByIdAsync(eventData.Entity.CreatorId.Value);
            
            forumUser.SetPostCount(forumUser.PostCount + 1);

            await _forumUserRepository.UpdateAsync(forumUser, true);
        }

        [UnitOfWork]
        public virtual async Task HandleEventAsync(EntityDeletedEventData<Post> eventData)
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