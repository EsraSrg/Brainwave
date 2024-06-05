using BrainWave.BusinessLayer.Abstract;
using BrainWave.DataAccessLayer.Concrete;
using BrainWave.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Asn1.Ocsp;

namespace BrainWave.PresentationLayer.Controllers
{
	public class MyTasksController : Controller
	{
		private readonly UserManager<AppUser> _userManager;
		private readonly Context _context;
		private readonly ITaskRequestService _taskRequestService;

		public MyTasksController(UserManager<AppUser> userManager, Context context, ITaskRequestService taskRequestService)
		{
			_userManager = userManager;
			_context = context;
			_taskRequestService = taskRequestService;
		}
		[HttpGet]
		public async Task<IActionResult> Index()
		{
			var user = await _userManager.FindByNameAsync(User.Identity.Name);
			// ProjectRequest tablosundan ProjectStatus true olan projectId'leri alıyoruz
			//var projectRequestIds = await _context.ProjectRequests
			//	.Where(pr => pr.RequestStatus == true && pr.SenderID == user.Id)
			//	.Select(pr => pr.ProjectID)
			//	.ToListAsync();

			var myTasks = await _context.ProjectTasks
				.Where(a => a.ReceiverID == user.Id && a.TaskStatus==false)
				.ToListAsync();

			// UserProjects tablosunda bu projectId'lere sahip ve kullanıcının kendi oluşturdugu projeleri alıyoruz
			//var myTasks = await _context.UserProjects
			//	.Where(up => projectId.Contains(up.UserProjectID) || up.AppUserID == user.Id)
			//	.ToListAsync();

			return View(myTasks);
		}
		//send finish note
		[HttpPost]
		public async Task<IActionResult> Index(int projecttaskId, string message)
		{
			try
			{
				var task = await _context.ProjectTasks
					.FirstOrDefaultAsync(x => x.ProjectTaskID == projecttaskId);

				if (task != null)
				{
					task.TaskStatus = true;
					task.TaskFinishedNote = message;
					await _context.SaveChangesAsync();
				}
				else
				{
					ModelState.AddModelError(string.Empty, "Request not found.");
				}
			}
			catch (Exception ex)
			{
				ModelState.AddModelError(string.Empty, $"An error occurred while processing your request: {ex.Message}");
			}
			return RedirectToAction("Index");
		}
	}
}
