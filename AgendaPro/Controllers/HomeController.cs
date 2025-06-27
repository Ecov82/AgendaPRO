using System.Diagnostics;
using AgendaPro.Models;
using Microsoft.AspNetCore.Mvc;
using AgendaPro.Data;


namespace AgendaPro.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        // P�gina inicial (dashboard ou landing page)
        public IActionResult Index()
        {
            return View();
        }

        // P�gina de Pol�tica de Privacidade
        public IActionResult Privacy()
        {
            return View();
        }

        // P�gina de erro padr�o com captura do RequestId
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
