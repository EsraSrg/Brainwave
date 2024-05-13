using BrainWave.DtoLayer.DataTransferObjects.AppUserDtos;
using BrainWave.EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BrainWave.PresentationLayer.Controllers
{
	//[Authorize]
	public class ProfileController : Controller
	{
		private readonly UserManager<AppUser> _userManager;

		public ProfileController(UserManager<AppUser> userManager)
		{
			_userManager = userManager;
		}

		[HttpGet]
		public async Task<IActionResult> Index()
		{
			var values = await _userManager.FindByNameAsync(User.Identity.Name);
			AppUserInfoDtos appUserInfoDtos = new AppUserInfoDtos();
			appUserInfoDtos.Name = values.Name;
			appUserInfoDtos.Surname = values.Surname;
			appUserInfoDtos.About = values.About;
			appUserInfoDtos.Experience = values.Experience;
			appUserInfoDtos.Education = values.Education;
			appUserInfoDtos.Skills = values.Skills;
			appUserInfoDtos.Interests = values.Interests;
			return View(appUserInfoDtos);
		}

		//ayarlar guncelleme için 21-22. video
		[HttpPost]
        public async Task<IActionResult> Index(AppUserInfoDtos appUserInfoDtos)
        {
            if(ModelState.IsValid)
			{
                var user = await _userManager.FindByNameAsync(User.Identity.Name);
				user.Name = appUserInfoDtos.Name;
                user.Surname=appUserInfoDtos.Surname;
                user.About = appUserInfoDtos.About;
                user.Experience = appUserInfoDtos.Experience;
                user.Education = appUserInfoDtos.Education;
                user.Skills = appUserInfoDtos.Skills;
                user.Interests = appUserInfoDtos.Interests;

				var result = await _userManager.UpdateAsync(user);
				if(result.Succeeded)
				{
					return RedirectToAction("Index", "Profile");
				}
            }
			return View();
        }
    }
}
