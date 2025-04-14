
using System.Web.Mvc;
using capaNegocios.Acciones;

namespace TIC_TOURS_App.Controllers
{
    public class AsistenciaController : Controller
    {
        public ActionResult Index()
        {
            var agentes = new AccionAsistencia().ObtenerActivos();
            return View(agentes);
        }
    }
}