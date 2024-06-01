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
            // ProjectRequest tablosundan ProjectStatus true olan projectId'leri alıyoruz
            var projectRequestIds = await _context.ProjectRequests
                .Where(pr => pr.RequestStatus == true)
                .Select(pr => pr.ProjectID)
                .ToListAsync();

            // UserProjects tablosunda bu projectId'lere sahip projeleri alıyoruz
            var myProjects = await _context.UserProjects
                .Where(up => projectRequestIds.Contains(up.UserProjectID) && up.AppUserID == user.Id)
                .ToListAsync();

            return View(myProjects);
        }
    }
}
