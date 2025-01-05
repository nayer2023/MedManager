using Microsoft.AspNetCore.Mvc;

namespace MediHarbor.Controllers
{
    public class ManagerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
