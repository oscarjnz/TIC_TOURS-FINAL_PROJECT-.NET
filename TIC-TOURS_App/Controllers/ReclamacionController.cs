using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using capaModelo;
using capaNegocios;

namespace TIC_TOURS_App.Controllers
{
    public class ReclamacionController : Controller
    {

        [HttpGet]
        public ActionResult Reclamacion()
        {
            return View(new VistaReclamacionModelo());
        }

        [HttpPost]
        public ActionResult Enviar(VistaReclamacionModelo reclamacion)
        {
            GestorReclamacion gestor = new GestorReclamacion();
            var resultado = gestor.EnviarReclamacion(reclamacion);
            return View("Reclamacion", resultado);
        }
         

    }
}