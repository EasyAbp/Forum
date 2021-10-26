using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EasyAbp.Forum.Comments;
using EasyAbp.Forum.Comments.Dtos;
using EasyAbp.Forum.Web.Pages.Forum.Comments.Comment.ViewModels;

namespace EasyAbp.Forum.Web.Pages.Forum.Comments.Comment
{
    public class EditModalModel : ForumPageModel
    {
        [HiddenInput]
        [BindProperty(SupportsGet = true)]
        public Guid Id { get; set; }

        [BindProperty]
        public EditCommentViewModel ViewModel { get; set; }

        private readonly ICommentAppService _service;

        public EditModalModel(ICommentAppService service)
        {
            _service = service;
        }

        public virtual async Task OnGetAsync()
        {
            var dto = await _service.GetAsync(Id);
            ViewModel = ObjectMapper.Map<CommentDto, EditCommentViewModel>(dto);
        }

        public virtual async Task<IActionResult> OnPostAsync()
        {
            var dto = ObjectMapper.Map<EditCommentViewModel, UpdateCommentDto>(ViewModel);
            await _service.UpdateAsync(Id, dto);
            return NoContent();
        }
    }
}