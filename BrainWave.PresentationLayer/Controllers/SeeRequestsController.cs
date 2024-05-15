using BrainWave.DataAccessLayer.Concrete;
using BrainWave.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BrainWave.PresentationLayer.Controllers
{
	public class SeeRequestsController : Controller
	{
		private readonly UserManager<AppUser> _userManager;
		private readonly Context _context;

		public SeeRequestsController(UserManager<AppUser> userManager, Context context)
		{
			_userManager = userManager;
			_context = context;
		}

		[HttpGet]
		public async Task<IActionResult> Index()
		{
			var user = await _userManager.FindByNameAsync(User.Identity.Name);
			var seeRequests = _context.ProjectRequests
				.Where(x => x.ReceiverID == user.Id)
				.ToListAsync();

			return View(seeRequests);
		}
	}
}
