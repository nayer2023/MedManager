using Microsoft.AspNetCore.Mvc;

namespace MediHarbor.Controllers
{
    public class PatientController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
