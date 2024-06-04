using BrainWave.BusinessLayer.Abstract;
using BrainWave.DataAccessLayer.Concrete;
using BrainWave.DtoLayer.DataTransferObjects.ProjectRequestDtos;
using BrainWave.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;

namespace BrainWave.PresentationLayer.Controllers
{
	//proje istekleri
	public class SeeRequestsController : Controller
	{
		private readonly UserManager<AppUser> _userManager;
		private readonly Context _context;
		private readonly IProjectRequestService _projectRequestService;


		public SeeRequestsController(UserManager<AppUser> userManager, Context context, IProjectRequestService projectRequestService)
		{
			_userManager = userManager;
			_context = context;
			_projectRequestService = projectRequestService;
		}

		[HttpGet]
		public async Task<IActionResult> Index()
		{
			try
			{
				var user = await _userManager.FindByNameAsync(User.Identity.Name);
				if (user == null)
				{
					return RedirectToAction("Login", "Account"); // Kullanıcı bulunamazsa login sayfasına yönlendir
				}

				var seeRequests = await _context.ProjectRequests
					.Where(x => x.ReceiverID == user.Id && x.RequestStatus == false)
					.ToListAsync();

				if (seeRequests == null || !seeRequests.Any())
				{
					ModelState.AddModelError(string.Empty, "No pending requests found.");
				}

				return View(seeRequests);
			}
			catch (Exception ex)
			{
				ModelState.AddModelError(string.Empty, $"An error occurred while processing your request: {ex.Message}");
				return View(new List<ProjectRequest>());
			}
		}

		[HttpPost]
		public async Task<IActionResult> Index(int requestId)
		{
			try
			{
				var request = await _context.ProjectRequests
					.FirstOrDefaultAsync(x => x.ProjectRequestID == requestId);

				if (request != null)
				{
					request.RequestStatus = true;
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

			return RedirectToAction("Index"); // İşlem tamamlandığında tekrar Index'e yönlendir
		}
	}
}