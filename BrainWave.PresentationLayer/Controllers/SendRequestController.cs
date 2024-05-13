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
        public async Task<IActionResult> Index(SendRequestDto sendRequestDto)
        {
            var context = new Context();
            var receiverProjectId = context.UserProjects.Where(p => p.UserProjectID == sendRequestDto.ProjectID).Select(y=>y.UserProjectID).FirstOrDefault();
            var values = new ProjectRequest();

            values.RequestMessage = "Text";
            values.RequestStatus = true;
            values.ReceiverID = receiverProjectId;
            values.ProjectID = 333;
            values.SenderID = 8;

            _projectRequestService.TInsert(values);

            return RedirectToAction("Index", "Deneme");
        }
    }
}
