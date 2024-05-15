using BrainWave.BusinessLayer.Abstract;
using BrainWave.DataAccessLayer.Concrete;
using BrainWave.DtoLayer.DataTransferObjects.ProjectRequestDtos;
using BrainWave.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BrainWave.PresentationLayer.Controllers
{
	public class AllProjectsController : Controller
	{
		private readonly UserManager<AppUser> _userManager;
		private readonly Context _context;
		private readonly IProjectRequestService _projectRequestService;


		public AllProjectsController(UserManager<AppUser> userManager, Context context, IProjectRequestService projectRequestService)
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
		//send request
		[HttpPost]
		public async Task<IActionResult> Index(int projectId, int userId, string message)
		{
			var user = await _userManager.FindByNameAsync(User.Identity.Name);

			var values = new ProjectRequest();
			values.RequestMessage = message;
			values.RequestStatus = false;
			values.ReceiverID = userId; // Proje sahibinin ID'si
			values.ProjectID = projectId;
			values.SenderID = user.Id;
			values.SenderUsername = user.UserName;

			_projectRequestService.TInsert(values);

			return RedirectToAction("Index", "Deneme");
		}
	}
}
