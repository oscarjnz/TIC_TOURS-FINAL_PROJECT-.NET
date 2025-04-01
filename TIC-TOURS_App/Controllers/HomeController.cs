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
   
        //vista principal
        public ActionResult Index()
            {
                GestorInicio gestor = new GestorInicio();
                var modelo = gestor.ObtenerDatosInicio();
                return View(modelo);
            }
         
         
    }
}