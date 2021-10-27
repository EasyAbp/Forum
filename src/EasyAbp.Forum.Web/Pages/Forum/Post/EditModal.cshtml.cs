using System;
using System.Threading.Tasks;
using EasyAbp.Forum.Posts;
using EasyAbp.Forum.Posts.Dtos;
using EasyAbp.Forum.Web.Pages.Forum.Post.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace EasyAbp.Forum.Web.Pages.Forum.Post
{
    public class EditModalModel : ForumPageModel
    {
        [HiddenInput]
        [BindProperty(SupportsGet = true)]
        public Guid Id { get; set; }

        [BindProperty]
        public EditPostViewModel ViewModel { get; set; }

        private readonly IPostAppService _service;

        public EditModalModel(IPostAppService service)
        {
            _service = service;
        }

        public virtual async Task OnGetAsync()
        {
            var dto = await _service.GetAsync(Id);
            ViewModel = ObjectMapper.Map<PostDto, EditPostViewModel>(dto);
        }

        public virtual async Task<IActionResult> OnPostAsync()
        {
            var dto = ObjectMapper.Map<EditPostViewModel, UpdatePostDto>(ViewModel);
            await _service.UpdateAsync(Id, dto);
            return NoContent();
        }
    }
}