using capaModelo;
using capaNegocios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using capaModelo.DTO;
using capaNegocios.Acciones;
using TIC_TOURS_App.Controllers.Backoffice;
using static capaNegocios.Acciones.AccionCompras;

namespace TIC_TOURS_App.Controllers
{
    public class NosotrosController : Controller
    {
        public ActionResult Index()
        {
          
            return View();
        }
    }
}