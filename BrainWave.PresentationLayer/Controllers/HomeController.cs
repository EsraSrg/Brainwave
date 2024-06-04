using Microsoft.AspNetCore.Mvc;

namespace BrainWave.PresentationLayer.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
