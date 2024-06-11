using BrainWave.DataAccessLayer.Concrete;
using BrainWave.DtoLayer.DataTransferObjects.UserProjectDtos;
using BrainWave.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BrainWave.PresentationLayer.Controllers
{
    public class CreateProjectController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly Context _context;

        public CreateProjectController(UserManager<AppUser> userManager, Context context)
        {
            _userManager = userManager;
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(CreateProjectDto createProjectDto, List<ProjectRequest> projectRequests)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByNameAsync(User.Identity.Name);
                UserProject userProject = new UserProject()
                {
                    ProjectTitle = createProjectDto.ProjectTitle,
                    ProjectDescription = createProjectDto.ProjectDescription,
                    ProjectStartDate = DateTime.Now,
                    ProjectEndDate = createProjectDto.ProjectEndDate,
                    ProjectStatus = createProjectDto.ProjectStatus,
                    ProjectPrivacy = createProjectDto.ProjectPrivacy,
                    ProjectCategories = createProjectDto.ProjectCategories,
                    ProjectSources = createProjectDto.ProjectSources,
                    ProjectTasks = createProjectDto.ProjectTasks,
                    ProjectTools = createProjectDto.ProjectTools,
                    AppUserID = user.Id,
                };
                await _context.AddAsync(userProject);
                _context.SaveChanges();
                return RedirectToAction("Index", "Deneme");
            }
            else
            {
                // ModelState.IsValid false ise, hata mesajları ekle
                foreach (var error in ModelState.Values.SelectMany(x => x.Errors))
                {
                    // Hata mesajlarını ModelState'e ekleyin
                    ModelState.AddModelError(string.Empty, error.ErrorMessage);
                }
            }
            return View();
        }
    }
}
