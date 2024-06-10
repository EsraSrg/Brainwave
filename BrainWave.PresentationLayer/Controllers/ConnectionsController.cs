using BrainWave.DataAccessLayer.Concrete;
using BrainWave.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace BrainWave.PresentationLayer.Controllers
{
    public class ConnectionsController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly Context _context;

        public ConnectionsController(UserManager<AppUser> userManager, Context context)
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

            var approvedRequests = await _context.UserRequests
                .Where(x => x.ReceiverID == user.Id && x.RequestStatus == true)
                .Select(x => x.SenderID)
                .ToListAsync();

            var approvedConnections = await _context.AppUsers
                .Where(x => approvedRequests.Contains(x.Id))
                .ToListAsync();

            var sentApprovedRequests = await _context.UserRequests
                .Where(x => x.SenderID == user.Id && x.RequestStatus == true)
                .Select(x => x.ReceiverID)
                .ToListAsync();

            var sentApprovedConnections = await _context.AppUsers
                .Where(x => sentApprovedRequests.Contains(x.Id))
                .ToListAsync();

            var allApprovedConnections = approvedConnections.Union(sentApprovedConnections).ToList();

            return View(allApprovedConnections);
        }
    }
}
