using BrainWave.DataAccessLayer.Concrete;
using BrainWave.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BrainWave.PresentationLayer.Controllers
{
    public class MyProjectsController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly Context _context;
        public MyProjectsController(UserManager<AppUser> userManager, Context context)
        {
            _userManager = userManager;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var myProjects = await _context.UserProjects
                .Where(b => b.ProjectStatus == true && b.AppUserID == user.Id)
                .ToListAsync();

            return View(myProjects);
        }
    }
}
