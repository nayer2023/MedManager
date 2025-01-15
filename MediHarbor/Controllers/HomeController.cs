using System.Diagnostics;
using Humanizer;
using MediHarbor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor.Compilation;

namespace MediHarbor.Controllers
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
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult About()
        {
            return View();
        }
        public ActionResult Vaccination()
        {
            
            return View("~/Views/Articles/Vaccination.cshtml");
        }
        public ActionResult AINeuro()
        {
            return View("~/Views/Articles/AINeuro.cshtml");
        }
        public ActionResult MentalAccess()
        {
            return View("~/Views/Articles/MentalAccess.cshtml");
        }
        public ActionResult MentalHealth()
        {
            return View("~/Views/Articles/MentalHealth.cshtml");
        }
        public ActionResult Neuroscience()
        {
            return View("~/Views/Articles/Neuroscience.cshtml");

        }
        public ActionResult Pills()
        {
            return View("~/Views/Articles/Pills.cshtml");

        }
        public ActionResult RobatsInMed()
        {
            return View("~/Views/Articles/RobatsInMed.cshtml");
        }
        public ActionResult RobaticSurgery()
        {
            return View("~/Views/Articles/RobaticSurgery.cshtml");
        }
        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
