using BrainWave.BusinessLayer.Abstract;
using BrainWave.DataAccessLayer.Concrete;
using BrainWave.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;

namespace BrainWave.PresentationLayer.Controllers
{
	public class MyProjectsController : Controller
	{
		private readonly UserManager<AppUser> _userManager;
		private readonly Context _context;
		private readonly ITaskRequestService _taskRequestService;
		public MyProjectsController(UserManager<AppUser> userManager, Context context, ITaskRequestService taskRequestService)
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
			var projectRequestIds = await _context.ProjectRequests
				.Where(pr => pr.RequestStatus == true && pr.SenderID == user.Id)
				.Select(pr => pr.ProjectID)
				.ToListAsync();

			// UserProjects tablosunda bu projectId'lere sahip ve kullanıcının kendi oluşturdugu projeleri alıyoruz
			var myProjects = await _context.UserProjects
				.Where(up => projectRequestIds.Contains(up.UserProjectID) || up.AppUserID == user.Id)
				.ToListAsync();

            ViewBag.UserId = user.Id;

            return View(myProjects);
		}
		[HttpGet]
		public async Task<IActionResult> Edit(int id)
		{
			var user = await _userManager.FindByNameAsync(User.Identity.Name);
			var project = await _context.UserProjects
				.FirstOrDefaultAsync(p => p.UserProjectID == id && p.AppUserID == user.Id);

			if (project == null)
			{

				return View();
			}

            //if (project.AppUserID != user.Id)
            //{
            //    TempData["Message"] = "Bu projeyi düzenleme yetkisine sahip değilsiniz.";
            //    return RedirectToAction("Index","MyProjects"); // Yetki yoksa anasayfaya yönlendirir
            //}
            return View(project);
		}

		[HttpPost]
		public async Task<IActionResult> Edit(UserProject project)
		{
			if (ModelState.IsValid)
			{
				_context.Update(project);
				await _context.SaveChangesAsync();
				return RedirectToAction(nameof(Index));
			}
			return View(project);
		}

		[HttpGet]
		public async Task<IActionResult> Task(int id)
		{
			try
			{
				var user = await _userManager.FindByNameAsync(User.Identity.Name);
				var projectParticipants = await _context.ProjectRequests
					.Where(a => a.ProjectID == id && a.RequestStatus == true)
					.ToListAsync();

				//ViewBag.ProjectID = id;
				return View(projectParticipants);
			}
			catch (Exception ex)
			{
				ModelState.AddModelError(string.Empty, $"An error occurred while processing your request: {ex.Message}");
				return View(new List<ProjectRequest>());
			}
		}

		//send request
		[HttpPost]
		public async Task<IActionResult> Task(int userId, int projectId, string message, string username)
		{
			var user = await _userManager.FindByNameAsync(User.Identity.Name);

			var values = new ProjectTask();
			values.TaskDescription = message;
			values.TaskStatus = false;
			values.ReceiverID = userId; // istek gonderilen kullanıcının ID'si
			values.SenderID = user.Id;
			values.ProjectID = projectId;
			values.ReceiverUsername = username;

			_taskRequestService.TInsert(values);
			return RedirectToAction("Index", "MyProjects");
		}



	}
}
