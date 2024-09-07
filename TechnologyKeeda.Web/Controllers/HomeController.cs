using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TechnologyKeeda.Web.Models;

namespace TechnologyKeeda.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            List<People> people = new List<People>();
            people.Add(new People { Id = 1, Name = "Pawan", City = "Churu" });
            people.Add(new People { Id = 2, Name = "Panwar", City = "Churu" });
            people.Add(new People { Id = 3, Name = "Agastya", City = "Churu" });
            people.Add(new People { Id = 4, Name = "Richa", City = "Roorkee" });
            
            return View("Index", people);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
