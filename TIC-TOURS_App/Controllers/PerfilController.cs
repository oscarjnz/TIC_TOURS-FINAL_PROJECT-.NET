using System;
using System.Web.Mvc;
using capaModelo.DTO;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.UI.WebControls;
using capaNegocios.Acciones;
using capaNegocios.Filtros;

namespace TIC_TOURS_App.Controllers
{
    public class PerfilController : Controller
    {
        [AutorizarUsuario]
        public ActionResult Datos()
        {
            var usuario = (UsuarioDTO)Session["Usuario"];
            return View(usuario);
        }

        [HttpPost]
        [AutorizarUsuario]
        public ActionResult ActualizarDatos(UsuarioDTO model)
        {
            var usuario = (UsuarioDTO)Session["Usuario"];
            model.IdUsuario = usuario.IdUsuario;
            new AccionPerfil().ActualizarDatos(model);
            Session["Usuario"] = model;
            return RedirectToAction("Datos");
        }
        [AutorizarUsuario]
        public ActionResult MisPolizas()
        {
            var usuario = (UsuarioDTO)Session["Usuario"];
            var polizaBL = new AccionPolizas();
            var lista = polizaBL.ObtenerPolizasPorUsuario(usuario.IdUsuario);
            return View(lista);
        }
        
        [AutorizarUsuario]
        public ActionResult VerPoliza(int idPoliza)
        {
            var usuario = (UsuarioDTO)Session["Usuario"];

            var polizaBL = new AccionPolizas();
            var poliza = polizaBL.ObtenerPolizasPorUsuario(usuario.IdUsuario).Find((x)=> x.IdPoliza == idPoliza);

            return View("PolizaTemplate", poliza);
        }

        // [AutorizarUsuario]
        // public ActionResult DescargarPoliza(string nombreArchivo)
        // {
        //     return new ActionAsPdf("VerPoliza", new { idPoliza = 1 })
        //     {
        //         FileName = $"Poliza_{1}.pdf",
        //     };
        // }
    }
}