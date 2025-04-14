using System;
using System.Linq;
using System.Web.Mvc;
using capaDatos.Database;
using capaModelo.DTO;
using capaNegocios.Acciones;
using capaNegocios.Filtros;

namespace TIC_TOURS_App.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly AccionRegistrar.UsuarioBL _usuarioBL = new AccionRegistrar.UsuarioBL();

        // AutorizarUsuario(Rol = "Administrador")
        [HttpGet]
        public ActionResult Registro()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Registro(UsuarioDTO model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var resultado = _usuarioBL.Registrar(model);

            if (resultado == "Registro exitoso")
                return RedirectToAction("Login");

            ViewBag.Mensaje = resultado;
            return View(model);
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(UsuarioDTO model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var usuario = _usuarioBL.Login(model.CorreoElectronico, model.Contrasena);
            if (usuario == null)
            {
                ViewBag.Mensaje = "Credenciales incorrectas o cuenta inactiva.";
                return View(model);
            }

            
            Session["Usuario"] = usuario;
            Session["Nombre"] = usuario.Nombre;
            Session["Rol"] = usuario.IdRol;

            return RedirectToAction("Index", "Home");
        }

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Login");
        }
    }
}