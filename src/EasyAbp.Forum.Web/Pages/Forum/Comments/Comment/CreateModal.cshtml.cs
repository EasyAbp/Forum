using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EasyAbp.Forum.Comments;
using EasyAbp.Forum.Comments.Dtos;
using EasyAbp.Forum.Web.Pages.Forum.Comments.Comment.ViewModels;

namespace EasyAbp.Forum.Web.Pages.Forum.Comments.Comment
{
    public class CreateModalModel : ForumPageModel
    {
        [BindProperty]
        public CreateCommentViewModel ViewModel { get; set; }

        private readonly ICommentAppService _service;

        public CreateModalModel(ICommentAppService service)
        {
            _service = service;
        }

        public virtual async Task<IActionResult> OnPostAsync()
        {
            var dto = ObjectMapper.Map<CreateCommentViewModel, CreateCommentDto>(ViewModel);
            await _service.CreateAsync(dto);
            return NoContent();
        }
    }
}