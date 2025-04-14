using System;
using System.Linq;
using System.Web.Mvc;
using capaNegocios;
using capaModelo.DTO;
using capaNegocios.Acciones.AccionesBackoffice;
using capaNegocios.Filtros;

namespace TIC_TOURS_App.Controllers.Backoffice
{
   
        [AutorizarUsuario(Rol = 1)]
        public class ReclamacionesController : Controller
        {
            private readonly AccionReclamacion _bl = new AccionReclamacion();

            public ActionResult Index(string estado = "", string motivo = "")
            {
                var lista = _bl.ObtenerTodas();

                if (!string.IsNullOrEmpty(estado))
                    lista = lista.Where(r => r.Estado == estado).ToList();

                if (!string.IsNullOrEmpty(motivo))
                    lista = lista.Where(r => r.Descripcion != null && r.Descripcion.ToLower().Contains(motivo.ToLower())).ToList();

                ViewBag.Estado = estado;
                ViewBag.Motivo = motivo;

                return View(lista);
            }

            public ActionResult Detalle(int id)
            {
                var reclamo = _bl.ObtenerPorId(id);
                if (reclamo == null)
                    return HttpNotFound();

                return View(reclamo);
            }

            public ActionResult CambiarEstado(int id, string nuevoEstado)
            {
                _bl.CambiarEstado(id, nuevoEstado);
                return RedirectToAction("Index");
            }

            public ActionResult DescargarDocumento(string nombreArchivo)
            {
                string ruta = Server.MapPath("~/App_Data/Reclamaciones/" + nombreArchivo);
                if (!System.IO.File.Exists(ruta))
                    return HttpNotFound("Archivo no encontrado");

                byte[] fileBytes = System.IO.File.ReadAllBytes(ruta);
                return File(fileBytes, "application/octet-stream", nombreArchivo);
            }
        }
    
}