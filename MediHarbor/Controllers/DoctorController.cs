using Microsoft.AspNetCore.Mvc;

namespace MediHarbor.Controllers
{
    public class DoctorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
