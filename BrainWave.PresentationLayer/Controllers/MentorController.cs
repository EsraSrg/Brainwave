using BrainWave.BusinessLayer.Abstract;
using BrainWave.DataAccessLayer.Concrete;
using BrainWave.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BrainWave.PresentationLayer.Controllers
{
    public class MentorController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly Context _context;
        private readonly IFriendRequestService _friendRequestService;

        public MentorController(UserManager<AppUser> userManager, Context context, IFriendRequestService friendRequestService)
        {
            _userManager = userManager;
            _context = context;
            _friendRequestService = friendRequestService;
        }
        [HttpGet]
        public async Task<IActionResult> Index(string type)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var usersQuery = _context.AppUsers.AsQueryable();


            if (!string.IsNullOrEmpty(type))
            {
                usersQuery = usersQuery.Where(b => b.MainInterest.Contains(type));
            }

            var allUsers = await usersQuery
                .ToListAsync();

            var categories = await _context.AppUsers
                .Select(p => p.Type)
                .Distinct()
                .ToListAsync();

            ViewBag.Type = type;

            return View(allUsers);
        }
        //send request
        [HttpPost]
        public async Task<IActionResult> Index(int userId, string message)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);

            var values = new UserRequest();
            values.RequestMessage = message;
            values.RequestStatus = false;
            values.ReceiverID = userId; // istek gonderilen kullanıcının ID'si
            values.SenderID = user.Id;
            values.SenderUsername = user.UserName;
            values.RelationshipType = user.Type;

            _friendRequestService.TInsert(values);

            return RedirectToAction("Index", "Mentor");
        }
    }
}

