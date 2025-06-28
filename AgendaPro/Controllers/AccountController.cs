using AgendaPro.Data;
using AgendaPro.Filters;
using AgendaPro.Helpers;
using AgendaPro.Models;
using AgendaPro.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace AgendaPro.Controllers
{
    public class AccountController : Controller
    {
        private readonly AppDbContext _context;

        public AccountController(AppDbContext context)
        {
            _context = context;
        }

        // GET: /Account/Register
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register()
        {
            return View();
        }

        // POST: /Account/Register
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public IActionResult Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            if (_context.Users.Any(u => u.Email == model.Email))
            {
                ModelState.AddModelError("Email", "Este e-mail já está em uso.");
                return View(model);
            }

            var user = new User
            {
                Email = model.Email,
                Name = model.Name,
                PasswordHash = PasswordHasher.ComputeHash(model.Password),
                IsMaster = model.Email.ToLower() == "cleitoneco@gmail.com" // Usuário mestre
            };

            _context.Users.Add(user);
            _context.SaveChanges();

            return RedirectToAction("Login");
        }

        // GET: /Account/Login
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }

        // POST: /Account/Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public IActionResult Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var passwordHash = PasswordHasher.ComputeHash(model.Password);

            var user = _context.Users
                .FirstOrDefault(u => u.Email == model.Email && u.PasswordHash == passwordHash);

            if (user == null)
            {
                ModelState.AddModelError(string.Empty, "E-mail ou senha inválidos.");
                return View(model);
            }

            HttpContext.Session.SetInt32("UserId", user.Id);
            HttpContext.Session.SetString("UserName", user.Name);
            HttpContext.Session.SetString("UserEmail", user.Email);
            HttpContext.Session.SetString("IsMaster", user.IsMaster.ToString());
         



            return RedirectToAction("Index", "Home");
        }

        // GET: /Account/Logout
        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }

        // GET: /Account/AccessDenied
        [HttpGet]
        [AllowAnonymous]
        public IActionResult AccessDenied()
        {
            return View();
        }

        [HttpGet]
        public IActionResult ChangePassword()
        {
            // Pega o email do usuário logado na sessão
            var email = HttpContext.Session.GetString("UserEmail");

            if (string.IsNullOrEmpty(email))
                return RedirectToAction("Login");

            var model = new ChangePasswordViewModel { Email = email };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ChangePassword(ChangePasswordViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var user = _context.Users.FirstOrDefault(u => u.Email == model.Email);
            if (user == null)
            {
                ModelState.AddModelError("", "Usuário não encontrado.");
                return View(model);
            }

            var currentPasswordHash = PasswordHasher.ComputeHash(model.CurrentPassword);
            if (user.PasswordHash != currentPasswordHash)
            {
                ModelState.AddModelError("CurrentPassword", "Senha atual incorreta.");
                return View(model);
            }

            user.PasswordHash = PasswordHasher.ComputeHash(model.NewPassword);
            _context.SaveChanges();

            TempData["SuccessMessage"] = "Senha alterada com sucesso!";
            return RedirectToAction("Index", "Home");
        }


    }
}
