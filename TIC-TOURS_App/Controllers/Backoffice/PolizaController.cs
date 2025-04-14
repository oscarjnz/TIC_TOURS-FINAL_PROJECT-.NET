using System.Linq;
using System.Web.Mvc;
using capaNegocios.Acciones;
using capaNegocios.Acciones.AccionesBackoffice;
using capaNegocios.Filtros;

namespace TIC_TOURS_App.Controllers.Backoffice
{
    [AutorizarUsuario(Rol = 1)]
    public class PolizasController : Controller
    {
        private readonly AccionPoliza polizaBL = new AccionPoliza();

        public ActionResult Index(string estado = "", string numero = "")
        {
            var lista = polizaBL.ObtenerTodas();

            if (!string.IsNullOrEmpty(estado))
                lista = lista.Where(p => p.Estado == estado).ToList();

            if (!string.IsNullOrEmpty(numero))
                lista = lista.Where(p => p.NumeroPoliza.Contains(numero)).ToList();

            ViewBag.Estado = estado;
            ViewBag.Numero = numero;
            return View(lista);
        }

        public ActionResult Detalle(int id)
        {
            var poliza = polizaBL.ObtenerPorId(id);
            if (poliza == null)
                return HttpNotFound();

            return View(poliza);
        }

        public ActionResult CambiarEstado(int id, string nuevoEstado)
        {
            polizaBL.CambiarEstado(id, nuevoEstado);
            return RedirectToAction("Index");
        }

        public ActionResult DescargarPdf(string nombreArchivo)
        {
            string ruta = Server.MapPath("~/App_Data/Polizas/" + nombreArchivo);
            if (!System.IO.File.Exists(ruta))
                return HttpNotFound("Archivo no encontrado");

            byte[] fileBytes = System.IO.File.ReadAllBytes(ruta);
            return File(fileBytes, "application/pdf", nombreArchivo);
        }
    }
}