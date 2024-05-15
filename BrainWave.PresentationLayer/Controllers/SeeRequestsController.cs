using BrainWave.BusinessLayer.Abstract;
using BrainWave.DataAccessLayer.Concrete;
using BrainWave.DtoLayer.DataTransferObjects.ProjectRequestDtos;
using BrainWave.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;

namespace BrainWave.PresentationLayer.Controllers
{
	public class SeeRequestsController : Controller
	{
		private readonly UserManager<AppUser> _userManager;
		private readonly Context _context;
		private readonly IProjectRequestService _projectRequestService;


		public SeeRequestsController(UserManager<AppUser> userManager, Context context, IProjectRequestService projectRequestService)
		{
			_userManager = userManager;
			_context = context;
			_projectRequestService = projectRequestService;
		}

		[HttpGet]
		public async Task<IActionResult> Index(SendRequestDto sendRequestDto)
		{
			var user = await _userManager.FindByNameAsync(User.Identity.Name);
			var seeRequests = await _context.ProjectRequests
				.Where(x => x.ReceiverID == user.Id && sendRequestDto.RequestStatus == false)
				.ToListAsync();

			return View(seeRequests);
		}


		//tekrarbakkkkkk istegi onaylamak için belki başka sayfaya yonlendirir
		[HttpPost]
		public async Task<IActionResult> Index(int requestId)
		{
			var request = await _context.ProjectRequests
				.FirstOrDefaultAsync(x => x.ProjectRequestID == requestId);

			//var request = await _context.ProjectRequests.FindAsync(requestId);
			if (request != null)
			{
				var values = new ProjectRequest();
				values.RequestStatus = true;
				//request.RequestStatus = true;
				_context.SaveChanges(); // Save the changes to the database
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

			return View(request);
		}
	}
}
