using AgendaPro.Data;
using AgendaPro.Models.Scheduling;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace AgendaPro.Controllers
{
    public class AppointmentsController : Controller
    {
        private readonly AppDbContext _context;

        public AppointmentsController(AppDbContext context)
        {
            _context = context;
        }

        private void PopulateDropdowns()
        {
            ViewBag.ServiceId = new SelectList(_context.Services, "Id", "Name");
            ViewBag.AppointmentStatusId = new SelectList(_context.AppointmentStatuses, "Id", "Name");
            ViewBag.AppointmentTypeId = new SelectList(_context.AppointmentTypes, "Id", "Name");
        }

        public IActionResult Index()
        {
            var appointments = _context.Appointments
                .Include(a => a.Service)
                .Include(a => a.AppointmentStatus)
                .Include(a => a.AppointmentType)
                .ToList();
            return View(appointments);
        }

        public IActionResult Create()
        {
            PopulateDropdowns();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Appointment appointment)
        {
            if (ModelState.IsValid)
            {
                _context.Appointments.Add(appointment);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            ViewBag.ServiceId = new SelectList(_context.Services, "Id", "Name", appointment.ServiceId);
            ViewBag.AppointmentStatusId = new SelectList(_context.AppointmentStatuses, "Id", "Name", appointment.AppointmentStatusId);
            ViewBag.AppointmentTypeId = new SelectList(_context.AppointmentTypes, "Id", "Name", appointment.AppointmentTypeId);

            return View(appointment);
        }


        // Outros métodos do controlador...
    }
}
