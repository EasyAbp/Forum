using System;
using System.Threading.Tasks;
using EasyAbp.Forum.Comments;
using EasyAbp.Forum.Communities;
using EasyAbp.Forum.Posts;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Guids;
using Volo.Abp.MultiTenancy;
using Volo.Abp.Uow;

namespace EasyAbp.Forum
{
    public class DemoDataSeedContributor : IDataSeedContributor, ITransientDependency
    {
        private readonly ICurrentTenant _currentTenant;
        private readonly IGuidGenerator _guidGenerator;
        private readonly ICommunityRepository _communityRepository;
        private readonly IPostRepository _postRepository;
        private readonly ICommentRepository _commentRepository;

        public DemoDataSeedContributor(
            ICurrentTenant currentTenant,
            IGuidGenerator guidGenerator,
            ICommunityRepository communityRepository,
            IPostRepository postRepository,
            ICommentRepository commentRepository)
        {
            _currentTenant = currentTenant;
            _guidGenerator = guidGenerator;
            _communityRepository = communityRepository;
            _postRepository = postRepository;
            _commentRepository = commentRepository;
        }
        
        [UnitOfWork]
        public async Task SeedAsync(DataSeedContext context)
        {
            using var changeTenant = _currentTenant.Change(context.TenantId);
            
            await SeedDemoCommunitiesAsync();
            await SeedDemoPostsAsync();
            await SeedDemoCommentsAsync();
        }

        private async Task SeedDemoCommunitiesAsync()
        {
            await TryCreateCommunityAsync(
                "i-love-abp-framework",
                "I Love ABP Framework",
                "(I have demo posts) ABP Framework is a complete infrastructure based on the ASP.NET Core to create modern web applications and APIs by following the software development best practices and the latest technologies.");
            
            await TryCreateCommunityAsync(
                "easyabp-modules",
                "EasyAbp Modules",
                "EasyAbp is an open-source organization that provides many useful ABP modules to enhance your ABP project development efficiency.");
            
            await TryCreateCommunityAsync(
                "my-community",
                "My Community",
                "A community for myself.");
        }

        private async Task TryCreateCommunityAsync(string name, string displayName, string description)
        {
            if (await _communityRepository.FindAsync(x => x.Name == name) != null)
            {
                return;
            }

            await _communityRepository.InsertAsync(
                new Community(_guidGenerator.Create(), _currentTenant.Id, name, displayName, description), true);
        }
        
        private async Task SeedDemoPostsAsync()
        {
            var community = await _communityRepository.GetAsync(x => x.Name == "i-love-abp-framework");

            await TryCreatePostAsync(
                community.Id,
                "My first post",
                "(I have demo comments) This is my first post.",
                true);
            
            await TryCreatePostAsync(
                community.Id,
                "My second post",
                "This is my second post.",
                true);
            
            await TryCreatePostAsync(
                community.Id,
                "My third post",
                "This is my third post.",
                false);
            
            await TryCreatePostAsync(
                community.Id,
                "My fourth post",
                "This is my fourth post.",
                false);
            
            await TryCreatePostAsync(
                community.Id,
                "My fifth post",
                "This is my fifth post.",
                false);
            
            await TryCreatePostAsync(
                community.Id,
                "My sixth post",
                "This is my sixth post.",
                false);
        }

        private async Task TryCreatePostAsync(Guid communityId, string title, string contentText, bool pinned)
        {
            if (await _postRepository.FindAsync(x => x.Title == title && x.CommunityId == communityId) != null)
            {
                return;
            }

            await _postRepository.InsertAsync(
                new Post(_guidGenerator.Create(), _currentTenant.Id, communityId, title, contentText, null, contentText,
                    pinned), true);
        }
        
        private async Task SeedDemoCommentsAsync()
        {
            var post = await _postRepository.FirstAsync(x => x.Title == "My first post");

            var firstComment = await TryCreateCommentAsync(
                post.Id,
                null,
                "This is my first comment.");
            
            await TryCreateCommentAsync(
                post.Id,
                firstComment.ParentId,
                "This is a sub-comment.");
            
            await TryCreateCommentAsync(
                post.Id,
                firstComment.ParentId,
                "This is another sub-comment.");
            
            await TryCreateCommentAsync(
                post.Id,
                null,
                "This is my second comment.");
            
            await TryCreateCommentAsync(
                post.Id,
                null,
                "This is my third comment.");
        }

        private async Task<Comment> TryCreateCommentAsync(Guid postId, Guid? parentId, string text)
        {
            var comment = await _commentRepository.FindAsync(x => x.PostId == postId && x.Text == text);
            
            if (comment != null)
            {
                return comment;
            }

            comment = new Comment(_guidGenerator.Create(), _currentTenant.Id, parentId, postId, text);

            return await _commentRepository.InsertAsync(comment, true);
        }
    }
}