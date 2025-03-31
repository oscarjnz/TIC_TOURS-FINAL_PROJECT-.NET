using capaModelo;
using capaNegocios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static capaNegocios.GestorCompra;

namespace TIC_TOURS_App.Controllers
{
    public class HomeController : Controller
    {
  
        
    public ActionResult Index()
        {
            GestorInicio gestor = new GestorInicio();
            var modelo = gestor.ObtenerDatosInicio();
            return View(modelo);
        }

        public class CotizacionController : Controller
        {
            [HttpGet]
            public ActionResult Cotizacion()
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
        public class CompraController : Controller
        {
            [HttpGet]
            public ActionResult Compra()
            {
                return View(new VistaCompraModelo());
            }

            [HttpPost]
            public ActionResult Procesar(VistaCompraModelo compra)
            {
                GestorCompra gestor = new GestorCompra();
                var resultado = gestor.ProcesarCompra(compra);
                return View("Compra", resultado);
            }
        }
        public class PolizaController : Controller
        {
            public ActionResult GestionPolizas()
            {
                GestorPoliza gestor = new GestorPoliza();.
                var modelo = gestor.ObtenerPolizasUsuario("usuarioEjemplo");
                return View(modelo);
            }
        }

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
}