using MediHarbor.Data;
using MediHarbor.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace MediHarbor.Controllers
{
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
            var scans = _context.Scans.ToList();
            return View(scans);
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
