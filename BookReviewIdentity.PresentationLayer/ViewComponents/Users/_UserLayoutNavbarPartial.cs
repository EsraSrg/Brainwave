using Microsoft.AspNetCore.Mvc;

namespace BookReviewIdentity.PresentationLayer.ViewComponents.Users
{
    public class _UserLayoutNavbarPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
