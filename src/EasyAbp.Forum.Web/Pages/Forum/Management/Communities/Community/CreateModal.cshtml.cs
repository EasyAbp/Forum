using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EasyAbp.Forum.Communities;
using EasyAbp.Forum.Communities.Dtos;
using EasyAbp.Forum.Web.Pages.Forum.Management.Communities.Community.ViewModels;

namespace EasyAbp.Forum.Web.Pages.Forum.Management.Communities.Community
{
    public class CreateModalModel : ForumPageModel
    {
        [BindProperty]
        public CreateEditCommunityViewModel ViewModel { get; set; }

        private readonly ICommunityAppService _service;

        public CreateModalModel(ICommunityAppService service)
        {
            _service = service;
        }

        public virtual async Task<IActionResult> OnPostAsync()
        {
            var dto = ObjectMapper.Map<CreateEditCommunityViewModel, CreateUpdateCommunityDto>(ViewModel);
            await _service.CreateAsync(dto);
            return NoContent();
        }
    }
}