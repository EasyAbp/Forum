using Volo.Abp;

namespace EasyAbp.Forum.Communities
{
    public class WrongCommunityNameException : BusinessException
    {
        public WrongCommunityNameException() : base("WrongCommunityName")
        {
        }
    }
}