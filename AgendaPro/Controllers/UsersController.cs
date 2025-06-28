using AgendaPro.Data;
using AgendaPro.Models.Scheduling;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AgendaPro.Controllers
{
    public class UsersController : Controller
    {
        private readonly AppDbContext _context;

        public UsersController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Users/Agendar
        public IActionResult Agendar()
        {
            ViewBag.Services = new SelectList(_context.Services, "Id", "Name");
            return View();
        }

        // POST: Users/Agendar
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Agendar(Appointment appointment)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Services = new SelectList(_context.Services, "Id", "Name", appointment.ServiceId);
                return View(appointment);
            }

            // Define status e tipo padrão se necessário
            appointment.AppointmentStatusId = 1; // ex: "Pendente"
            appointment.AppointmentTypeId = 1;   // ex: "Agendamento Online"
            appointment.CreatedAt = DateTime.Now;

            _context.Appointments.Add(appointment);
            _context.SaveChanges();
            return RedirectToAction("Confirmado");
        }

        public IActionResult Confirmado()
        {
            return View();
        }
    }
}
