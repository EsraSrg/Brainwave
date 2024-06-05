using BrainWave.DtoLayer.DataTransferObjects.AppUserDtos;
using BrainWave.EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BrainWave.PresentationLayer.Controllers
{
	//[Authorize]
	public class ProfileController : Controller
	{
		private readonly UserManager<AppUser> _userManager;
		private readonly IWebHostEnvironment _webHostEnvironment;

		public ProfileController(UserManager<AppUser> userManager, IWebHostEnvironment webHostEnvironment)
		{
			_userManager = userManager;
			_webHostEnvironment = webHostEnvironment;
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

        [HttpGet]
        public async Task<IActionResult> UploadProfileImage()
        {
            
            return View();
        }
        [HttpPost]
		public async Task<IActionResult> UploadProfileImage(IFormFile profileImage)
		{
			var user = await _userManager.FindByNameAsync(User.Identity.Name);
			if (user == null)
			{
				return NotFound("Kullanıcı bulunamadı.");
			}

			if (profileImage != null && profileImage.Length > 0)
			{
				var uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images");
				var uniqueFileName = $"{Guid.NewGuid()}_{profileImage.FileName}";
				var filePath = Path.Combine(uploadsFolder, uniqueFileName);

				ViewBag.UniqueFileName = uniqueFileName;

				// Dosyayı sunucuda kaydedin
				using (var stream = new FileStream(filePath, FileMode.Create))
				{
					await profileImage.CopyToAsync(stream);
				}

				// Eski profil resmini silin (eğer varsa)
				if (!string.IsNullOrEmpty(user.ProfileImagePath))
				{
					var oldImagePath = Path.Combine(_webHostEnvironment.WebRootPath, user.ProfileImagePath.TrimStart('/'));
					if (System.IO.File.Exists(oldImagePath))
					{
						System.IO.File.Delete(oldImagePath);
					}
				}

				// Kullanıcının profil resim yolunu güncelleyin
				user.ProfileImagePath = $"/images/{uniqueFileName}";
				var result = await _userManager.UpdateAsync(user);

				if (result.Succeeded)
				{
					return RedirectToAction("Index", "Profile");
				}
				else
				{
					// Hata mesajları ekleyin
					foreach (var error in result.Errors)
					{
						ModelState.AddModelError("", error.Description);
					}
				}
			}

			return View("Index", user);
		}
	}
}
