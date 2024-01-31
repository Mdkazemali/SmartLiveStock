using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using smartlivestock.Data;
using smartlivestock.Models;
using smartlivestock.UserInfoModelView;

namespace smartlivestock.Controllers
{
    public class SharedController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHost;
        public SharedController(ILogger<HomeController> logger, ApplicationDbContext context, IWebHostEnvironment webHost)
        {
            _logger = logger;
            _context = context;
            _webHost = webHost;
        }
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public IActionResult _LoginPartial()
        {
            var loginId = User.Identity.Name;
            var info = _context.UserInformation.FirstOrDefault(x => x.LoginId == loginId);

            var viewModel = new UserInfoViewModel
            {
                Name = User.Identity.Name,
                PhotoUrl = (info != null) ? info.PhotoUrl : null
            };

            return View(viewModel);
        }
        public UserInformation GetUserInformation(string loginId)
        {
            // Implement the logic to query the database and retrieve user information
            return _context.UserInformation.FirstOrDefault(u => u.LoginId == loginId);
        }

    }
}
