using AgendaPro.Models.Scheduling;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using AgendaPro.Data;

namespace AgendaPro.Controllers
{
    public class ServicesController : Controller
    {
        private readonly AppDbContext _context;

        public ServicesController(AppDbContext context)
        {
            _context = context;
        }

        // Aqui você pode colocar ações específicas para Serviços, por exemplo:

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
                return RedirectToAction(nameof(Index)); // ou outro método que listar serviços
            }
            return View(service);
        }

        // Outros métodos para Services (Index, Edit, Delete, etc.) podem ser implementados aqui
    }
}
