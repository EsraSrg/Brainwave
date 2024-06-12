using BrainWave.DtoLayer.DataTransferObjects;
using BrainWave.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using System.Threading.Tasks;

namespace BrainWave.PresentationLayer.Controllers
{
    public class EditProfileController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public EditProfileController(UserManager<AppUser> userManager, IWebHostEnvironment webHostEnvironment)
        {
            _userManager = userManager;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            AppUserInfoDtos appUserInfoDtos = new AppUserInfoDtos
            {
                Name = values.Name,
                Surname = values.Surname,
                About = values.About,
                Experience = values.Experience,
                Education = values.Education,
                Skills = values.Skills,
                Interests = values.Interests,
                Socials = values.Socials,
                //ProfileImageName = values.ProfileImagePath
            };

            return View(appUserInfoDtos);
        }

        [HttpPost]
        public async Task<IActionResult> Index(AppUserInfoDtos appUserInfoDtos)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByNameAsync(User.Identity.Name);
                if (user != null)
                {
                    user.Name = appUserInfoDtos.Name;
                    user.Surname = appUserInfoDtos.Surname;
                    user.About = appUserInfoDtos.About;
                    user.Experience = appUserInfoDtos.Experience;
                    user.Education = appUserInfoDtos.Education;
                    user.Skills = appUserInfoDtos.Skills;
                    user.Interests = appUserInfoDtos.Interests;
                    user.Socials = appUserInfoDtos.Socials;

                    //// Profil resmini yükle
                    //if (appUserInfoDtos.ProfileImage != null)
                    //{
                    //    string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images");
                    //    string uniqueFileName = Guid.NewGuid().ToString() + "_" + appUserInfoDtos.ProfileImage.FileName;
                    //    string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                    //    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    //    {
                    //        await appUserInfoDtos.ProfileImage.CopyToAsync(fileStream);
                    //    }

                    //    user.ProfileImagePath = uniqueFileName;
                    //}

                    var result = await _userManager.UpdateAsync(user);
                    if (result.Succeeded)
                    {
                        TempData["Message"] = "Profiliniz başarıyla güncellendi!";
                        return RedirectToAction("Index", "Profile");
                    }
                    else
                    {
                        TempData["ErrorMessage"] = "Profil güncellenirken bir hata oluştu!";
                        foreach (var error in result.Errors)
                        {
                            TempData["ErrorMessage"] += $" {error.Description}";
                        }
                    }
                }
                else
                {
                    TempData["ErrorMessage"] = "Kullanıcı bulunamadı!";
                }
            }
            else
            {
                TempData["ErrorMessage"] = "Model doğrulaması geçerli değil!";
            }
            return View(appUserInfoDtos);
        }
    }
}
