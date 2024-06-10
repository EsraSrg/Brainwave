using BrainWave.DataAccessLayer.Concrete;
using BrainWave.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace BrainWave.PresentationLayer.Controllers
{
    public class PendingRequestsController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly Context _context;

        public PendingRequestsController(UserManager<AppUser> userManager, Context context)
        {
            _userManager = userManager;
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return RedirectToAction("Login", "Account");
            }

            var pendingRequests = await _context.UserRequests
                .Where(x => x.ReceiverID == user.Id && x.RequestStatus == false)
                .ToListAsync();

            return View(pendingRequests);
        }

        [HttpPost]
        public async Task<IActionResult> ApproveRequest(int requestId)
        {
            var request = await _context.UserRequests.FindAsync(requestId);
            if (request != null)
            {
                request.RequestStatus = true;
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> RejectRequest(int requestId)
        {
            var request = await _context.UserRequests.FindAsync(requestId);
            if (request != null)
            {
                _context.UserRequests.Remove(request);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("Index");
        }
    }
}
