using Microsoft.AspNetCore.Mvc;
using MediHarbor.Data;
using MediHarbor.ViewModels;
using System.Linq;

namespace MediHarbor.Controllers
{
    public class SearchController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SearchController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Search(TestScanViewModel model)
        {
            var scansQuery = _context.Scans.AsQueryable();
            var testsQuery = _context.MedTests.AsQueryable();

            if (!string.IsNullOrEmpty(model.SearchTerm))
            {
                scansQuery = scansQuery.Where(s => s.ScanType.Contains(model.SearchTerm) || s.BodyPart.Contains(model.SearchTerm));
                testsQuery = testsQuery.Where(t => t.TestName.Contains(model.SearchTerm) || t.TestCategory.Contains(model.SearchTerm));
            }

            if (!string.IsNullOrEmpty(model.Location))
            {
                scansQuery = scansQuery.Where(s => s.Location.Contains(model.Location));
                testsQuery = testsQuery.Where(t => t.Location.Contains(model.Location));
            }

            if (model.AvailableFrom.HasValue)
            {
                scansQuery = scansQuery.Where(s => s.AvailableDate >= model.AvailableFrom);
                testsQuery = testsQuery.Where(t => t.AvailableDate >= model.AvailableFrom);
            }

            if (model.AvailableTo.HasValue)
            {
                scansQuery = scansQuery.Where(s => s.AvailableDate <= model.AvailableTo);
                testsQuery = testsQuery.Where(t => t.AvailableDate <= model.AvailableTo);
            }

            model.Scans = scansQuery.ToList();
            model.MedTests = testsQuery.ToList();

            return View(model);
        }
    }
}
