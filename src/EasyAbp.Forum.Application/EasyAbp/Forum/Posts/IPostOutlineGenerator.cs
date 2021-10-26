using System.Threading.Tasks;

namespace EasyAbp.Forum.Posts
{
    public interface IPostOutlineGenerator
    {
        Task<string> CreateAsync(string contentText);
    }
}