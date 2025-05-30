using AgendaPro.Models.Scheduling;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AgendaPro.Data;

namespace AgendaPro.Controllers
{
    public class AppointmentsController : Controller
    {
        private readonly AppDbContext _context;

        public AppointmentsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Appointments
        public async Task<IActionResult> Index()
        {
            var list = await _context.Appointments
                                     .Include(a => a.Service)
                                     .ToListAsync();
            return View(list);
        }

        // GET: Appointments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var appt = await _context.Appointments
                                     .Include(a => a.Service)
                                     .FirstOrDefaultAsync(a => a.Id == id);
            if (appt == null) return NotFound();

            return View(appt);
        }

        // GET: Appointments/Create
        public IActionResult Create()
        {
            ViewData["ServiceId"] = new SelectList(_context.Services, "Id", "Name");
            return View();
        }

        // POST: Appointments/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Appointment appointment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(appointment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            // Se houver erros de validação, recarrega o dropdown
            ViewData["ServiceId"] = new SelectList(_context.Services, "Id", "Name", appointment.ServiceId);
            return View(appointment);
        }

        // GET: Appointments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var appointment = await _context.Appointments.FindAsync(id);
            if (appointment == null) return NotFound();

            ViewData["ServiceId"] = new SelectList(_context.Services, "Id", "Name", appointment.ServiceId);
            return View(appointment);
        }

        // POST: Appointments/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Appointment appointment)
        {
            if (id != appointment.Id) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(appointment);
                    await _context.SaveChangesAsync();
                } catch (DbUpdateConcurrencyException) when (!_context.Appointments.Any(e => e.Id == id))
                {
                    return NotFound();
                }
                return RedirectToAction(nameof(Index));
            }

            ViewData["ServiceId"] = new SelectList(_context.Services, "Id", "Name", appointment.ServiceId);
            return View(appointment);
        }

        // GET: Appointments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var appt = await _context.Appointments
                                     .Include(a => a.Service)
                                     .FirstOrDefaultAsync(a => a.Id == id);
            if (appt == null) return NotFound();

            return View(appt);
        }

        // POST: Appointments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var appt = await _context.Appointments.FindAsync(id);
            if (appt != null)
            {
                _context.Appointments.Remove(appt);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
