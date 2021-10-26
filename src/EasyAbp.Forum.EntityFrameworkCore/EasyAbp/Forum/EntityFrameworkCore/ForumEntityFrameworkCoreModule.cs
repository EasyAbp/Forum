using EasyAbp.Forum.Comments;
using EasyAbp.Forum.Posts;
using EasyAbp.Forum.Communities;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace EasyAbp.Forum.EntityFrameworkCore
{
    [DependsOn(
        typeof(ForumDomainModule),
        typeof(AbpEntityFrameworkCoreModule)
    )]
    public class ForumEntityFrameworkCoreModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<ForumDbContext>(options =>
            {
                /* Add custom repositories here. Example:
                 * options.AddRepository<Question, EfCoreQuestionRepository>();
                 */
                options.AddRepository<Community, CommunityRepository>();
                options.AddRepository<Post, PostRepository>();
                options.AddRepository<Comment, CommentRepository>();
            });
        }
    }
}
