using Microsoft.AspNetCore.Mvc;
using Proyecto_Roles.Models;
using Proyecto_Roles.Data;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;

namespace Proyecto_Roles.Controllers
{
    public class AccesoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(Usuario oUsuario)
        {
            DA_Logica _logica = new DA_Logica();

            var usuario = _logica.Validar_Usuario(oUsuario.Correo, oUsuario.Clave);

            if(usuario != null)
            {
                var claims = new List<Claim>
                {
                    new Claim("Correo", usuario.Correo)
                };

                foreach(string rol in usuario.Roles)
                {
                    claims.Add(new Claim(ClaimTypes.Role, rol));
                }

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

                return RedirectToAction("Index", "Home"); 
            }
            else{return View();}

        }

        public async Task<IActionResult> Salir()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction("Index", "Acceso");
        }
    }
}
