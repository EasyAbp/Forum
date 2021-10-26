using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EasyAbp.Forum.Communities;
using EasyAbp.Forum.Communities.Dtos;
using EasyAbp.Forum.Web.Pages.Forum.Management.Communities.Community.ViewModels;

namespace EasyAbp.Forum.Web.Pages.Forum.Management.Communities.Community
{
    public class EditModalModel : ForumPageModel
    {
        [HiddenInput]
        [BindProperty(SupportsGet = true)]
        public Guid Id { get; set; }

        [BindProperty]
        public CreateEditCommunityViewModel ViewModel { get; set; }

        private readonly ICommunityAppService _service;

        public EditModalModel(ICommunityAppService service)
        {
            _service = service;
        }

        public virtual async Task OnGetAsync()
        {
            var dto = await _service.GetAsync(Id);
            ViewModel = ObjectMapper.Map<CommunityDto, CreateEditCommunityViewModel>(dto);
        }

        public virtual async Task<IActionResult> OnPostAsync()
        {
            var dto = ObjectMapper.Map<CreateEditCommunityViewModel, CreateUpdateCommunityDto>(ViewModel);
            await _service.UpdateAsync(Id, dto);
            return NoContent();
        }
    }
}