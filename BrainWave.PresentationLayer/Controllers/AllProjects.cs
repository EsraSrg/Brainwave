using BrainWave.BusinessLayer.Abstract;
using BrainWave.DataAccessLayer.Concrete;
using BrainWave.DtoLayer.DataTransferObjects.ProjectRequestDtos;
using BrainWave.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BrainWave.PresentationLayer.Controllers
{
	public class AllProjects : Controller
	{
		private readonly UserManager<AppUser> _userManager;
		private readonly Context _context;
		private readonly IProjectRequestService _projectRequestService;


		public AllProjects(UserManager<AppUser> userManager, Context context, IProjectRequestService projectRequestService)
		{
			_userManager = userManager;
			_context = context;
			_projectRequestService = projectRequestService;
		}
		[HttpGet]
		public async Task<IActionResult> Index()
		{
			var user = await _userManager.FindByNameAsync(User.Identity.Name);
			var allProjects = await _context.UserProjects
				.Where(b => b.ProjectStatus == true)
				.ToListAsync();

			return View(allProjects);
		}

		[HttpPost]
		public async Task<IActionResult> Index(SendRequestDto sendRequestDto)
		{
			var user = await _userManager.FindByNameAsync(User.Identity.Name);
			var context = new Context();
			var receiverProjectId = context.UserProjects.Where(p => p.UserProjectID == sendRequestDto.ProjectID).Select(y => y.UserProjectID).FirstOrDefault();
			
			var values = new ProjectRequest();
			values.RequestMessage = "Text";
			values.RequestStatus = true;
			values.ReceiverID = receiverProjectId;
			values.ProjectID = 333;
			values.SenderID = user.Id;

			_projectRequestService.TInsert(values);

			return RedirectToAction("Index", "Deneme");
		}
	}
}
