using Microsoft.AspNetCore.Mvc;
using Proyecto_Roles.Models;
using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;

namespace Proyecto_Roles.Controllers
{

    //[Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "Administrador, Supervisor")]
        public IActionResult Ventas()
        {
            return View();
        }

        [Authorize(Roles = "Administrador, Supervisor, Empleado")]
        public IActionResult Clientes()
        {
            return View();
        }

        [Authorize(Roles = "Administrador, Supervisor")]
        public IActionResult Compras()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}