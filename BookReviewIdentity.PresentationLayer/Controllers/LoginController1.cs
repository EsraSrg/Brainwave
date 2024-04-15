using BookReviewIdentity.EntityLayer.Concrete;
using BookReviewIdentity.PresentationLayer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BookReviewIdentity.PresentationLayer.Controllers
{
	public class LoginController1 : Controller
	{
		private readonly SignInManager<AppUser> _signInManager;
		private readonly UserManager<AppUser> _userManager;

		public LoginController1(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager)
		{
			_signInManager = signInManager;
			_userManager = userManager;
		}

		[HttpGet]
		public IActionResult Index()
		{
			return View();
		}

		[HttpPost]

		public async Task<IActionResult> Index(LoginViewModel loginViewModel)
		{
			var result = await _signInManager.PasswordSignInAsync(loginViewModel.Username, loginViewModel.Password,false,true);
			if(result.Succeeded)
			{
				var user = await _userManager.FindByNameAsync(loginViewModel.Username);
				if (user.EmailConfirmed ==true)
				{
					return RedirectToAction("Index", "MyAccounts");
				}
			}
			return View();
		}

	}
}
