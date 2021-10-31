using System;
using System.Threading.Tasks;
using EasyAbp.Forum.Posts;
using EasyAbp.Forum.Posts.Dtos;
using Microsoft.AspNetCore.Mvc;
using CreatePostViewModel = EasyAbp.Forum.Web.Pages.Forum.Post.ViewModels.CreatePostViewModel;

namespace EasyAbp.Forum.Web.Pages.Forum.Post
{
    public class CreateModalModel : ForumPageModel
    {
        [BindProperty]
        public CreatePostViewModel ViewModel { get; set; }

        private readonly IPostAppService _service;

        public CreateModalModel(IPostAppService service)
        {
            _service = service;
        }

        public virtual Task OnGetAsync(Guid communityId)
        {
            ViewModel = new CreatePostViewModel
            {
                CommunityId = communityId
            };
            
            return Task.CompletedTask;
        }

        public virtual async Task<IActionResult> OnPostAsync()
        {
            var dto = ObjectMapper.Map<CreatePostViewModel, CreatePostDto>(ViewModel);
            await _service.CreateAsync(dto);
            return NoContent();
        }
    }
}