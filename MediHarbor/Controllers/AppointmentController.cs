using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MediHarbor.Models;
using MediHarbor.ViewModels;
using System;
using System.Linq;
using System.Threading.Tasks;
using MediHarbor.Data;

namespace MediHarbor.Controllers
{
    [Authorize]  
    public class AppointmentController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public AppointmentController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // Get method to show the form
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var doctors = await _context.Doctors.ToListAsync();  
            ViewBag.Doctors = doctors;  
            return View();
        }

        // Post method to handle appointment booking
        [HttpPost]
        public async Task<IActionResult> Create(DocApptViewModel model)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account");  // Redirect to login if not authenticated
            }

            var userId = _userManager.GetUserId(User);  
            var patient = await _context.Patients.FirstOrDefaultAsync(p => p.UserId == userId);  // Get the patient's record

            if (patient == null)
            {
                ModelState.AddModelError("", "Patient record not found.");
                return View(model);
            }

            if (ModelState.IsValid)
            {
                // Create new appointment object
                var appointment = new Appointment
                {
                    PatientID = patient.PatientID,
                    DoctorID = model.DoctorID,
                    AppointmentDate = model.AppointmentDate,
                    Reason = model.Reason,
                    Status = "Scheduled",
                    CreatedOn = DateTime.Now
                };

                _context.Appointments.Add(appointment); 
                await _context.SaveChangesAsync();  
                return RedirectToAction("Index", "Home");  
            }

            return View(model);  
        }
    }
}
