using BrainWave.DtoLayer.DataTransferObjects.AppUserDtos;
using BrainWave.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BrainWave.PresentationLayer.Controllers
{
    public class AccountSettingsController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public AccountSettingsController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(new AppUserAccountSettingsDto());
        }

        [HttpPost]
        public async Task<IActionResult> UpdateUsername(AppUserAccountSettingsDto model)
        {
            ModelState.Clear();
            TryValidateModel(model);

            if (ModelState.IsValid && !string.IsNullOrEmpty(model.NewUserName))
            {
                var user = await _userManager.GetUserAsync(User);
                if (user != null)
                {
                    user.UserName = model.NewUserName;
                    var result = await _userManager.UpdateAsync(user);
                    if (result.Succeeded)
                    {
                        TempData["SuccessMessage"] = "Username updated successfully!";
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError("", error.Description);
                        }
                    }
                }
            }
            return View("Index", model);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateEmail(AppUserAccountSettingsDto model)
        {
            ModelState.Clear();
            TryValidateModel(model);

            if (ModelState.IsValid && !string.IsNullOrEmpty(model.NewEmail))
            {
                var user = await _userManager.GetUserAsync(User);
                if (user != null)
                {
                    user.Email = model.NewEmail;
                    var result = await _userManager.UpdateAsync(user);
                    if (result.Succeeded)
                    {
                        TempData["SuccessMessage"] = "Email updated successfully!";
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError("", error.Description);
                        }
                    }
                }
            }
            return View("Index", model);
        }

        [HttpPost]
        public async Task<IActionResult> UpdatePassword(AppUserAccountSettingsDto model)
        {
            ModelState.Clear();
            TryValidateModel(model);

            if (ModelState.IsValid && !string.IsNullOrEmpty(model.OldPassword) && !string.IsNullOrEmpty(model.NewPassword) && model.NewPassword == model.ConfirmPassword)
            {
                var user = await _userManager.GetUserAsync(User);
                if (user != null)
                {
                    var result = await _userManager.ChangePasswordAsync(user, model.OldPassword, model.NewPassword);
                    if (result.Succeeded)
                    {
                        await _signInManager.RefreshSignInAsync(user);
                        TempData["SuccessMessage"] = "Password updated successfully!";
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError("", error.Description);
                        }
                    }
                }
            }
            return View("Index", model);
        }
    }
}
