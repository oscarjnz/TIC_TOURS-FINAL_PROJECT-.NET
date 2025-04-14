using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using capaModelo;
using capaModelo.DTO;
using capaNegocios.Acciones;
using capaNegocios.Filtros;

namespace TIC_TOURS_App.Controllers
{
public class ReclamacionController : Controller
{
    [AutorizarUsuario]
    public ActionResult Nueva()
    {
        ViewBag.Polizas = new AccionPolizas().ObtenerPolizasPorUsuario(((UsuarioDTO)Session["Usuario"]).IdUsuario);
        return View();
    }

    [HttpPost]
    [AutorizarUsuario]
    public ActionResult Nueva(ReclamacionDTO model, HttpPostedFileBase documento)
    {
        if (documento != null && documento.ContentLength > 0)
        {
            string carpeta = Server.MapPath("~/App_Data/Reclamaciones/");
            if (!System.IO.Directory.Exists(carpeta))
            {
                System.IO.Directory.CreateDirectory(carpeta); // CREA LA CARPETA SI NO EXISTE
            }

            string nombre = Path.GetFileName(documento.FileName);
            string ruta = Path.Combine(carpeta, nombre);
            documento.SaveAs(ruta);

            model.Documento = nombre;
        }

        model.IdAgente = 1;
        model.Estado = "pendiente";
        model.FechaReclamo = DateTime.Now;

        new AccionReclamaciones().Registrar(model);
        return RedirectToAction("MisReclamaciones");
    }

    [AutorizarUsuario]
    public ActionResult MisReclamaciones()
    {
        int idUsuario = ((UsuarioDTO)Session["Usuario"]).IdUsuario;
        var lista = new AccionReclamaciones().ObtenerPorUsuario(idUsuario);
        return View(lista);
    }

}
}