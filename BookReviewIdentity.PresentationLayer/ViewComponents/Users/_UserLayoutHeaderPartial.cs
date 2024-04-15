using Microsoft.AspNetCore.Mvc;

namespace BookReviewIdentity.PresentationLayer.ViewComponents.Users
{
    public class _UserLayoutHeaderPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
