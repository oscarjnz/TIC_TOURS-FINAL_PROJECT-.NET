using System.Web.Mvc;
using capaNegocios.Acciones;
using capaNegocios.Filtros;

namespace TIC_TOURS_App.Controllers
{
    [AutorizarUsuario(Rol = "Administrador")]
    public class BackOfficeController : Controller
    {
        public ActionResult Index()
        {
            var resumen = new AccionBackoffice().ObtenerKPIs();
            return View(resumen);
        }
    }
}