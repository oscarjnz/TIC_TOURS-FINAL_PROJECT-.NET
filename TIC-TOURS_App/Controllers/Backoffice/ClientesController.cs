using System.Web.Mvc;
using capaNegocios.Acciones;
using capaNegocios.Acciones.AccionesBackoffice;
using capaNegocios.Filtros;

namespace TIC_TOURS_App.Controllers.Backoffice
{
    [AutorizarUsuario(Rol = 1)]
    public class ClientesController : Controller
    {
        private readonly AccionUsuario _usuarioBl = new  AccionUsuario();

        public ActionResult Index(string buscar = "")
        {
            var clientes = _usuarioBl.ObtenerClientes(buscar);
            ViewBag.Buscar = buscar;
            return View(clientes);
        }

        public ActionResult Detalle(int id)
        {
            var cliente = _usuarioBl.ObtenerPorId(id);
            if (cliente == null)
                return HttpNotFound();

            var polizas = new AccionPolizas().ObtenerPolizasPorUsuario(id);
            var reclamaciones = new AccionReclamaciones().ObtenerPorUsuario(id);

            ViewBag.Polizas = polizas;
            ViewBag.Reclamaciones = reclamaciones;
            return View(cliente);
        }

        public ActionResult Suspender(int id)
        {
            _usuarioBl.CambiarEstado(id, "suspendido");
            return RedirectToAction("Index");
        }

        public ActionResult Activar(int id)
        {
            _usuarioBl.CambiarEstado(id, "activo");
            return RedirectToAction("Index");
        }
    }
}