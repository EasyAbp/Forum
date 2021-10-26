using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EasyAbp.Forum.Posts;
using EasyAbp.Forum.Posts.Dtos;
using EasyAbp.Forum.Web.Pages.Forum.Posts.Post.ViewModels;

namespace EasyAbp.Forum.Web.Pages.Forum.Posts.Post
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

        public virtual async Task<IActionResult> OnPostAsync()
        {
            var dto = ObjectMapper.Map<CreatePostViewModel, CreatePostDto>(ViewModel);
            await _service.CreateAsync(dto);
            return NoContent();
        }
    }
}