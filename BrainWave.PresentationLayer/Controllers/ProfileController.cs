using BrainWave.DtoLayer.DataTransferObjects;
using BrainWave.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BrainWave.PresentationLayer.Controllers
{
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
            AppUserInfoDtos appUserInfoDtos = new AppUserInfoDtos
            {
                Name = values.Name,
                Surname = values.Surname,
                About = values.About,
                Experience = values.Experience,
                Education = values.Education,
                Skills = values.Skills,
                Interests = values.Interests,
                Socials = values.Socials
            };

            return View(appUserInfoDtos);
        }
    }
}
