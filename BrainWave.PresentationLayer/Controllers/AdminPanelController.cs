using BrainWave.DtoLayer.DataTransferObjects;
using BrainWave.EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrainWave.PresentationLayer.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminPanelController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppRole> _roleManager;

        public AdminPanelController(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var users = _userManager.Users.ToList();
            return View(users);
        }

        [HttpGet]
        public IActionResult CreateUser()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(CreateUserDto model)
        {
            if (ModelState.IsValid)
            {
                var user = new AppUser
                {
                    UserName = model.UserName,
                    Email = model.Email,
                    Name = model.Name,
                    Surname = model.Surname
                };
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, model.Role);
                    return RedirectToAction("Index");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteUser(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user != null)
            {
                var result = await _userManager.DeleteAsync(user);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult AddDropdownOption()
        {
            var model = new AddDropdownOptionDto();
            return View(model);
        }

        [HttpPost]
        public IActionResult AddDropdownOption(AddDropdownOptionDto model)
        {
            if (ModelState.IsValid)
            {
                // Burada yeni seçeneği veritabanına veya bir dosyaya kaydetme işlemi yapabilirsiniz.
                // Örneğin, bir dosya kullanarak saklayabilirsiniz.
                string filePath = "wwwroot/dropdownOptions.json";
                var options = System.IO.File.Exists(filePath)
                    ? System.Text.Json.JsonSerializer.Deserialize<DropdownOptions>(System.IO.File.ReadAllText(filePath))
                    : new DropdownOptions();

                switch (model.Category)
                {
                    //case "Lise":
                      //  options.HighSchoolOptions.Add(model.Option);
                        //break;
                    case "Üniversite":
                        options.UniversityOptions.Add(model.Option);
                        break;
                    case "Yetenekler":
                        options.SkillOptions.Add(model.Option);
                        break;
                    case "İlgi Alanları":
                        options.InterestOptions.Add(model.Option);
                        break;
                }

                System.IO.File.WriteAllText(filePath, System.Text.Json.JsonSerializer.Serialize(options));
                TempData["Message"] = "Yeni seçenek başarıyla eklendi!";
                return RedirectToAction("AddDropdownOption");
            }
            return View(model);
        }
    }

    public class DropdownOptions
    {
        //public List<string> HighSchoolOptions { get; set; } = new List<string>();
        public List<string> UniversityOptions { get; set; } = new List<string>();
        public List<string> SkillOptions { get; set; } = new List<string>();
        public List<string> InterestOptions { get; set; } = new List<string>();
    }
}
