using Microsoft.AspNetCore.Mvc;
using AgendaPro.Models.Scheduling;
using AgendaPro.Data;
using Microsoft.EntityFrameworkCore;

namespace AgendaPro.Controllers
{
    public class ServicesController : Controller
    {
        private readonly AppDbContext _context;

        public ServicesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Services
        public IActionResult Index()
        {
            var services = _context.Services.ToList();
            return View(services);
        }

        // GET: Services/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Services/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Service service)
        {
            if (ModelState.IsValid)
            {
                _context.Services.Add(service);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(service);
        }

        // GET: Services/Edit/5
        public IActionResult Edit(int id)
        {
            var service = _context.Services.Find(id);
            if (service == null)
            {
                return NotFound();
            }
            return View(service);
        }

        // POST: Services/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Service service)
        {
            if (ModelState.IsValid)
            {
                _context.Update(service);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(service);
        }

        // GET: Services/Details/5
        public IActionResult Details(int id)
        {
            var service = _context.Services.FirstOrDefault(s => s.Id == id);
            if (service == null)
            {
                return NotFound();
            }
            return View(service);
        }

        // POST: Services/DeleteConfirmed
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var service = _context.Services
                .Include(s => s.Appointments) // Carrega os agendamentos relacionados
                .FirstOrDefault(s => s.Id == id);

            if (service == null)
            {
                return NotFound();
            }

            // Verifica se existem agendamentos vinculados
            if (service.Appointments?.Any() == true)
            {
                TempData["ErrorMessage"] = "Não é possível excluir um serviço com agendamentos vinculados.";
                return RedirectToAction(nameof(Index));
            }

            _context.Services.Remove(service);
            _context.SaveChanges();

            TempData["SuccessMessage"] = "Serviço excluído com sucesso!";
            return RedirectToAction(nameof(Index));
        }
    }
}