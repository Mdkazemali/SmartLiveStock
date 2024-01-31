using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using smartlivestock.Data;
using smartlivestock.Models;

namespace smartlivestock.Controllers
{
    public class CalculatorController : Controller
    {

        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHost;

        public CalculatorController(ApplicationDbContext context, IWebHostEnvironment webHost)
        {
            _context = context;
            _webHost = webHost;
        }




        public IActionResult Ghaseranalysis()
        {
            return View();
        }

        public IActionResult OjonOKhaddo()
        {
            return View();
        }
        public IActionResult Layer()
        {
            return View();
        }
       
        
        public IActionResult Broiler()
        {
            return View();
        }

        public IActionResult PeatBird()
        {
            return View();
        }



    }
}
