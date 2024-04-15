using Microsoft.AspNetCore.Mvc;

namespace BookReviewIdentity.PresentationLayer.Controllers
{
	public class UserLayoutController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
