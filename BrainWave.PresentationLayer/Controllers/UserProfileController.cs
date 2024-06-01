using BrainWave.DataAccessLayer.Concrete;
using BrainWave.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BrainWave.PresentationLayer.Controllers
{
	public class UserProfileController : Controller
	{
		private readonly UserManager<AppUser> _userManager;
		private readonly Context _context;

		public UserProfileController(UserManager<AppUser> userManager, Context context)
		{
			_userManager = userManager;
			_context = context;
		}
		[HttpGet]
		public async Task<IActionResult> Index(string username)
		{
			if (string.IsNullOrEmpty(username))
			{
				return BadRequest("Username cannot be null or empty");
			}

			var user = await _userManager.FindByNameAsync(username);
			if (user == null)
			{
				return BadRequest("Sıkıntı kanzi");
			}

			return View(user);
		}
	}
}
