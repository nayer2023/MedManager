using MediHarbor.Data;
using MediHarbor.Models;
using MediHarbor.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace MediHarbor.Controllers
{
    [Authorize(Roles = "Manager")] // Restrict access only to Managers
    public class ManagerController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ManagerController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Manager/Index
        public IActionResult Index()
        {
            var viewModel = new ManagerDashboardViewModel
            {
                Scans = _context.Scans.ToList(),
                Doctors = _context.Doctors.ToList(),
                Appointments = _context.Appointments.ToList(),
                Texts = _context.TextItems.ToList()
            };

            return View(viewModel);
        }

        // GET: Manager/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Manager/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Scan scan)
        {
            if (ModelState.IsValid)
            {
                _context.Add(scan);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(scan);
        }
    }
}
