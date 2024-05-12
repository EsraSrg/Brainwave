using Microsoft.AspNetCore.Mvc;

namespace BrainWave.PresentationLayer.Controllers
{
	public class ProfileController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
