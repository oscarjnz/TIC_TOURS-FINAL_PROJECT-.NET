using System.Linq;
using System.Web.Mvc;
using capaModelo.DTO;
using capaNegocios.Acciones;
using capaNegocios.Acciones.AccionesBackoffice;
using capaNegocios.Filtros;

namespace TIC_TOURS_App.Controllers.Backoffice
{
    [AutorizarUsuario(Rol = 1)]
    public class PaisesController : Controller
    {
        private readonly AccionPaisBackoffice _bl = new AccionPaisBackoffice();

        public ActionResult Index()
        {
            var lista = _bl.ObtenerTodos();
            return View(lista);
        }

        public ActionResult Crear() => View();

        [HttpPost]
        public ActionResult Crear(PaisDTO model)
        {
            if (ModelState.IsValid)
            {
                _bl.Crear(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public ActionResult Editar(int id)
        {
            var pais = _bl.ObtenerPorId(id);
            return pais == null ? (ActionResult)HttpNotFound() : View(pais);
        }

        [HttpPost]
        public ActionResult Editar(PaisDTO model)
        {
            if (ModelState.IsValid)
            {
                _bl.Actualizar(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public ActionResult Eliminar(int id)
        {
            _bl.Eliminar(id);
            return RedirectToAction("Index");
        }
    }
}