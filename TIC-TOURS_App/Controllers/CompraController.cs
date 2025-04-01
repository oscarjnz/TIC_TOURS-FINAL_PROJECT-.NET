using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using capaDatos;
using capaModelo;
using capaModelo.DTO;
using capaNegocios;

namespace TIC_TOURS_App.Controllers
{
    public class CompraController : Controller
    {

        private readonly RepositorioInicio _repositorios = new RepositorioInicio();


        [Route("Compra")]
        public ActionResult Compra(VistaCompraModelo modelo) //index view
        {
            // retornar el listado de compras
            //var compras = _repositorios.ProcesarCompra(modelo);

            return View();
        }

        [HttpPost]
        public ActionResult Procesar(VistaCompraModelo compra)
        {
            var resultado = _repositorios.ProcesarCompra(compra);
       
            return View("Compra", resultado);
        }


    }
}