using System.Linq;
using System.Web.Mvc;
using capaModelo.DTO;
using capaNegocios.Acciones;
using capaNegocios.Acciones.AccionesBackoffice;
using capaNegocios.Filtros;

namespace TIC_TOURS_App.Controllers.Backoffice
{
    [AutorizarUsuario(Rol = 1)]
    public class UsuariosController : Controller
    {
        private readonly AccionUsuario usuarioBL = new AccionUsuario();
        private readonly AccionRol rolBL = new AccionRol();

        public ActionResult Index()
        {
            var lista = usuarioBL.ObtenerTodos();
            return View(lista);
        }

        public ActionResult Crear()
        {
            ViewBag.Roles = rolBL.ObtenerTodos();
            return View();
        }

        [HttpPost]
        public ActionResult Crear(UsuarioDTO model)
        {
            if (ModelState.IsValid)
            {
                usuarioBL.RegistrarInterno(model);
                return RedirectToAction("Index");
            }

            ViewBag.Roles = rolBL.ObtenerTodos();
            return View(model);
        }

        public ActionResult Editar(int id)
        {
            var usuario = usuarioBL.ObtenerPorId(id);
            ViewBag.Roles = rolBL.ObtenerTodos();
            return View(usuario);
        }

        [HttpPost]
        public ActionResult Editar(UsuarioDTO model)
        {
            if (ModelState.IsValid)
            {
                usuarioBL.Actualizar(model);
                return RedirectToAction("Index");
            }

            ViewBag.Roles = rolBL.ObtenerTodos();
            return View(model);
        }

        public ActionResult CambiarEstado(int id)
        {
            usuarioBL.CambiarEstado(id);
            return RedirectToAction("Index");
        }
    }
}