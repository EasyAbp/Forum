using System;
using System.Threading.Tasks;
using EasyAbp.Forum.Posts;
using EasyAbp.Forum.Posts.Dtos;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.Json;
using CreatePostViewModel = EasyAbp.Forum.Web.Pages.Forum.Post.ViewModels.CreatePostViewModel;

namespace EasyAbp.Forum.Web.Pages.Forum.Post
{
    public class CreateModalModel : ForumPageModel
    {
        [BindProperty]
        public CreatePostViewModel ViewModel { get; set; }

        private readonly IPostAppService _service;
        private readonly IJsonSerializer _jsonSerializer;

        public CreateModalModel(
            IPostAppService service,
            IJsonSerializer jsonSerializer)
        {
            _service = service;
            _jsonSerializer = jsonSerializer;
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
            
            var post = await _service.CreateAsync(dto);
            
            return Content(_jsonSerializer.Serialize(post));
        }
    }
}