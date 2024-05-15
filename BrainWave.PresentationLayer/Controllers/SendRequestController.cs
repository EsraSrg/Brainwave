using BrainWave.BusinessLayer.Abstract;
using BrainWave.DataAccessLayer.Concrete;
using BrainWave.DtoLayer.DataTransferObjects.ProjectRequestDtos;
using BrainWave.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BrainWave.PresentationLayer.Controllers
{
    public class SendRequestController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IProjectRequestService _projectRequestService;

        public SendRequestController(UserManager<AppUser> userManager, IProjectRequestService projectRequestService)
        {
            _userManager = userManager;
            _projectRequestService = projectRequestService;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(SendRequestDto sendRequestDto, int appUserId, int projectId)
        {
            if (ModelState.IsValid)
            {
				ViewData["UserProjectID"] = projectId;
				ViewData["AppUserID"] = appUserId;

				var user = await _userManager.FindByNameAsync(User.Identity.Name);
				var context = new Context();
				//var receiverId = context.UserProjects.Where(x=>x.UserProjectID == AppUserId).Select(x => x.AppUserID).FirstOrDefault();
				//var projectId = context.UserProjects.Where(p => p.UserProjectID == sendRequestDto.ProjectID).Select(y => y.UserProjectID).FirstOrDefault();
				//var projectIdd = context.UserProjects.FindAsync();
				var values = new ProjectRequest();

				values.RequestMessage = sendRequestDto.RequestMessage;
				values.RequestStatus = false;
				values.ReceiverID = appUserId;
				values.ProjectID = projectId;
				values.SenderID = user.Id;

				_projectRequestService.TInsert(values);

				return RedirectToAction("Index", "Deneme");
			}
			else
			{
				// ModelState.IsValid false ise, hata mesajları ekle
				foreach (var error in ModelState.Values.SelectMany(x => x.Errors))
				{
					// Hata mesajlarını ModelState'e ekleyin
					ModelState.AddModelError(string.Empty, error.ErrorMessage);
				}
			}
			return View();
		}

    }
}
