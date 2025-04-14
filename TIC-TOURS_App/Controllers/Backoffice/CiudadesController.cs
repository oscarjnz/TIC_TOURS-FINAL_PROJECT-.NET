using System.Linq;
using System.Web.Mvc;
using capaModelo.DTO;
using capaNegocios.Acciones;
using capaNegocios.Acciones.AccionesBackoffice;
using capaNegocios.Filtros;

namespace TIC_TOURS_App.Controllers.Backoffice
{
    [AutorizarUsuario(Rol = 1)]
    public class CiudadesController : Controller
    {
        private readonly AccionCiudadBackoffice ciudadBL = new AccionCiudadBackoffice();
        private readonly AccionPaisBackoffice paisBL = new AccionPaisBackoffice();

        public ActionResult Index()
        {
            var lista = ciudadBL.ObtenerTodas();
            return View(lista);
        }

        public ActionResult Crear()
        {
            ViewBag.Paises = paisBL.ObtenerTodos();
            return View();
        }

        [HttpPost]
        public ActionResult Crear(CiudadDTO model)
        {
            if (ModelState.IsValid)
            {
                ciudadBL.Crear(model);
                return RedirectToAction("Index");
            }
            ViewBag.Paises = paisBL.ObtenerTodos();
            return View(model);
        }

        public ActionResult Editar(int id)
        {
            var ciudad = ciudadBL.ObtenerPorId(id);
            if (ciudad == null)
                return HttpNotFound();

            ViewBag.Paises = paisBL.ObtenerTodos();
            return View(ciudad);
        }

        [HttpPost]
        public ActionResult Editar(CiudadDTO model)
        {
            if (ModelState.IsValid)
            {
                ciudadBL.Actualizar(model);
                return RedirectToAction("Index");
            }
            ViewBag.Paises = paisBL.ObtenerTodos();
            return View(model);
        }

        public ActionResult Eliminar(int id)
        {
            ciudadBL.Eliminar(id);
            return RedirectToAction("Index");
        }
    }
}