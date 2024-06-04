using BrainWave.BusinessLayer.Abstract;
using BrainWave.DataAccessLayer.Concrete;
using BrainWave.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BrainWave.PresentationLayer.Controllers
{
	public class SeeFriendRequestsController : Controller
	{

		private readonly UserManager<AppUser> _userManager;
		private readonly Context _context;
		private readonly IFriendRequestService _friendRequestService;

		public SeeFriendRequestsController(UserManager<AppUser> userManager, Context context, IFriendRequestService friendRequestService)
		{
			_userManager = userManager;
			_context = context;
			_friendRequestService = friendRequestService;
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

				var seeRequests = await _context.UserRequests
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
				return View(new List<UserRequest>());
			}
		}

		[HttpPost]
		public async Task<IActionResult> Index(int requestId)
		{
			try
			{
				var request = await _context.UserRequests
					.FirstOrDefaultAsync(x => x.UserRequestID == requestId);

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

