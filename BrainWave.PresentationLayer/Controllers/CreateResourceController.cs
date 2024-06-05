using BrainWave.DataAccessLayer.Concrete;
using BrainWave.DtoLayer.DataTransferObjects.UserProjectDtos;
using BrainWave.DtoLayer.DataTransferObjects.UserResourcesDtos;
using BrainWave.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BrainWave.PresentationLayer.Controllers
{
	public class CreateResourceController : Controller
	{
		private readonly UserManager<AppUser> _userManager;
		private readonly Context _context;

		public CreateResourceController(UserManager<AppUser> userManager, Context context)
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

		public async Task<IActionResult> Index(CreateResourceDto createResourceDto)
		{
			if (ModelState.IsValid)
			{
				var user = await _userManager.FindByNameAsync(User.Identity.Name);
				UserResource userResource = new UserResource()
				{
					ResourceTitle = createResourceDto.ResourceTitle,
					ResourceDescription = createResourceDto.ResourceDescription,
					ResourcePublishDate = DateTime.Now,
					ResourceAuthor = createResourceDto.ResourceAuthor,
					ResourceCategories = createResourceDto.ResourceCategories,
					ResourceImage = createResourceDto.ResourceImage,
					ResourceUrl	= createResourceDto.ResourceUrl,
					AppUserID = user.Id,
				};
				await _context.AddAsync(userResource);
				_context.SaveChanges();
				return RedirectToAction("Index", "AllResources");
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
