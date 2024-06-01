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
        public async Task<IActionResult> Index(string category)
        {

            var resourcesQuery = _context.UserResources.AsQueryable();
			if (!string.IsNullOrEmpty(category))
			{
				resourcesQuery = resourcesQuery.Where(b => b.ResourceCategories.Contains(category));
			}
			var allResources = await resourcesQuery.ToListAsync();

			var categories = await _context.UserResources
				.Select(p => p.ResourceCategories)
				.Distinct()
				.ToListAsync();

			ViewBag.Categories = categories;


			return View(allResources);

        }
    }
}
