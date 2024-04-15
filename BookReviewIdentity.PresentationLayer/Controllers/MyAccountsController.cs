using BookReviewIdentity.DtoLayer.Dtos.AppUserDtos;
using BookReviewIdentity.EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BookReviewIdentity.PresentationLayer.Controllers
{
    //[Authorize]
    public class MyAccountsController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public MyAccountsController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);

            AppUserEditDto appUserEditDtos = new AppUserEditDto();
            appUserEditDtos.Name = values.Name;
            appUserEditDtos.Surname = values.Surname;
            appUserEditDtos.Email = values.Email;
            appUserEditDtos.PhoneNumber = values.PhoneNumber;

            return View(appUserEditDtos);
        }
    }
}
