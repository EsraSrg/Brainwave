using BrainWave.BusinessLayer.Abstract;
using BrainWave.DataAccessLayer.Concrete;
using BrainWave.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BrainWave.PresentationLayer.Controllers
{
	public class AllUsersController : Controller
	{
		private readonly UserManager<AppUser> _userManager;
		private readonly Context _context;
		private readonly IFriendRequestService _friendRequestService;

		public AllUsersController(UserManager<AppUser> userManager, Context context, IFriendRequestService friendRequestService)
		{
			_userManager = userManager;
			_context = context;
			_friendRequestService = friendRequestService;
		}

		[HttpGet]
		public async Task<IActionResult> Index(string category)
		{
			var user = await _userManager.FindByNameAsync(User.Identity.Name);
			var usersQuery = _context.AppUsers.AsQueryable();


			if (!string.IsNullOrEmpty(category))
			{
				usersQuery = usersQuery.Where(b => b.MainInterest.Contains(category));
			}

			var allUsers = await usersQuery
				.ToListAsync();

			var categories = await _context.AppUsers
				.Select(p => p.MainInterest)
				.Distinct()
				.ToListAsync();

			ViewBag.Categories = categories;

			return View(allUsers);
		}
		//send request
		[HttpPost]
		public async Task<IActionResult> Index(int userId, string message)
		{
			var user = await _userManager.FindByNameAsync(User.Identity.Name);

			var values = new UserRequest();
			values.RequestMessage = message;
			values.RequestStatus = false;
			values.ReceiverID = userId; // istek gonderilen kullanıcının ID'si
			values.SenderID = user.Id;
			values.SenderUsername = user.UserName;

			_friendRequestService.TInsert(values);

			return RedirectToAction("Index", "AllUsers");
		}
	}
}
