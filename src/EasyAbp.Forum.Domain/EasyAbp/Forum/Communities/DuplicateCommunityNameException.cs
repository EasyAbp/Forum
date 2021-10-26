using Volo.Abp;

namespace EasyAbp.Forum.Communities
{
    public class DuplicateCommunityNameException : BusinessException
    {
        public DuplicateCommunityNameException() : base("DuplicateCommunityName")
        {
        }
    }
}