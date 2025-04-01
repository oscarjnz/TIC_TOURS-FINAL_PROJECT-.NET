using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using capaModelo;
using capaNegocios;

namespace TIC_TOURS_App.Controllers
{
    public class CotizacionController : Controller
    {
        [Route("Cotizacion")]
        public ActionResult Cotizacion() //view
        {
            return View(new VistaCotizacionModelo());
        }

        [HttpPost]
        public ActionResult Calcular(VistaCotizacionModelo modelo)
        {
            GestorCotizacion gestor = new GestorCotizacion();
            var resultado = gestor.ObtenerCotizacion(modelo);
            return View("Cotizacion", resultado);
        }



    }
}