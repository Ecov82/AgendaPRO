using AgendaPro.Filters;
using Microsoft.AspNetCore.Mvc;

namespace AgendaPro.Controllers
{
    [MasterOnly] // Filtro customizado para permitir apenas usuário mestre
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        // Adicione outras ações administrativas aqui
    }
}
