using BrainWave.DataAccessLayer.Concrete;
using BrainWave.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BrainWave.PresentationLayer.Controllers
{
    public class AllResourcesController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly Context _context;

        public AllResourcesController(UserManager<AppUser> userManager, Context context)
        {
            _userManager = userManager;
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var allProjects = await _context.UserResources
                .ToListAsync();

            return View(allProjects);
        }
    }
}
