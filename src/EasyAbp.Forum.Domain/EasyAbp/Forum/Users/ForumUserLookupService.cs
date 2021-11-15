using Volo.Abp.Uow;
using Volo.Abp.Users;

namespace EasyAbp.Forum.Users
{
    public class ForumUserLookupService : UserLookupService<ForumUser, IForumUserRepository>, IForumUserLookupService
    {
        public ForumUserLookupService(
            IForumUserRepository userRepository,
            IUnitOfWorkManager unitOfWorkManager)
            : base(
                userRepository,
                unitOfWorkManager)
        {
            
        }

        protected override ForumUser CreateUser(IUserData externalUser)
        {
            return new ForumUser(externalUser);
        }
    }
}