using System.Linq;
using System.Web.Mvc;
using capaModelo.DTO;
using capaNegocios.Acciones;
using capaNegocios.Acciones.AccionesBackoffice;
using capaNegocios.Filtros;

namespace TIC_TOURS_App.Controllers.Backoffice
{
    [AutorizarUsuario(Rol = 1)]
    public class PaquetesController : Controller
    {
        private readonly AccionPaquetesBackoffice _bl = new AccionPaquetesBackoffice();

        public ActionResult Index(string tipo = "", string destino = "")
        {
            var lista = _bl.ObtenerTodos();

            if (!string.IsNullOrEmpty(tipo))
                lista = lista.Where(p => p.TipoPaquete == tipo).ToList();

            if (!string.IsNullOrEmpty(destino))
                lista = lista.Where(p => p.NombrePaquete.ToLower().Contains(destino.ToLower())).ToList();

            ViewBag.Tipo = tipo;
            ViewBag.Destino = destino;
            return View(lista);
        }

        public ActionResult Crear()
        {
            ViewBag.Ciudades = new AccionCiudadBackoffice().ObtenerTodas();
            
            return View();
        }

        [HttpPost]
        public ActionResult Crear(PaqueteDTO model)
        {
            if (ModelState.IsValid)
            {
                _bl.Crear(model);
                return RedirectToAction("Index");
            }

            ViewBag.Ciudades = new AccionCiudadBackoffice().ObtenerTodas();
            return View(model);
        }

        public ActionResult Editar(int id)
        {
            var paquete = _bl.ObtenerPorId(id);
            if (paquete == null)
                return HttpNotFound();

            ViewBag.Ciudades = new AccionCiudadBackoffice().ObtenerTodas();
            return View(paquete);
        }

        [HttpPost]
        public ActionResult Editar(PaqueteDTO model)
        {
            if (ModelState.IsValid)
            {
                _bl.Actualizar(model);
                return RedirectToAction("Index");
            }

            ViewBag.Ciudades = new AccionCiudadBackoffice().ObtenerTodas();
            return View(model);
        }

        public ActionResult Eliminar(int id)
        {
            _bl.Eliminar(id);
            return RedirectToAction("Index");
        }
    }
}