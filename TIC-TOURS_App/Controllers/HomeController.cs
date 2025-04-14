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
    public class HomeController : Controller
    {
   
     
            private readonly AccionPaquetes _paqueteBL = new AccionPaquetes();

         public ActionResult Index(string destino = "", int? duracionMin = null, int? edad = null, int? personas = null)
         {
             var paquetes = _paqueteBL.ObtenerPaquetes();
         
             if (!string.IsNullOrEmpty(destino))
                 paquetes = paquetes.Where(p => p.NombrePaquete != null && 
                                                p.NombrePaquete.IndexOf(destino, StringComparison.OrdinalIgnoreCase) >= 0).ToList();

         
             if (duracionMin.HasValue)
                 paquetes = paquetes.Where(p => p.DuracionDias >= duracionMin.Value).ToList();
             
         
             return View(paquetes);
         }
        
            public ActionResult Detalle(int id)
            {
                var paquete = _paqueteBL.ObtenerPaquetePorId(id);
                if (paquete == null)
                    return RedirectToAction("Index");
                var paquetes = _paqueteBL.ObtenerPaquetes();
                ViewBag.Relacionados = paquetes;
                return View(paquete);
            }
            public ActionResult Cotizar(int id)
            {
                var paquete = _paqueteBL.ObtenerPaquetePorId(id);
                if (paquete == null)
                    return RedirectToAction("Index");
                var servicios = new AccionServiciosExtras().ObtenerDisponibles();
                
                ViewBag.Servicios = servicios;
                ViewBag.Paquete = paquete;
                return View();
            }
            
            [HttpPost]
            public ActionResult Cotizar(int idPaquete, int cantidadPersonas, DateTime fechaInicio, int[] servicios)
            {
                var paquete = _paqueteBL.ObtenerPaquetePorId(idPaquete);
                if (paquete == null)
                    return RedirectToAction("Index");

                decimal precioBase = paquete.PrecioBase;
                decimal subtotal = precioBase * cantidadPersonas;
                decimal serviciosExtra = 0;

                List<ServicioExtraDTO> serviciosElegidos = new List<ServicioExtraDTO>();

                if (servicios != null && servicios.Any())
                {
                    var todosServicios = new AccionServiciosExtras().ObtenerDisponibles();

                    serviciosElegidos = todosServicios
                        .Where(s => servicios.Contains(s.IdServicio))
                        .ToList();

                    serviciosExtra = serviciosElegidos.Sum(s => s.Precio ?? 0);
                }

                decimal total = subtotal + serviciosExtra;

                ViewBag.Paquete = paquete;
                ViewBag.CantidadPersonas = cantidadPersonas;
                ViewBag.FechaInicio = fechaInicio.ToShortDateString();
                ViewBag.Servicios = serviciosElegidos;
                ViewBag.Subtotal = subtotal;
                ViewBag.Extras = serviciosExtra;
                ViewBag.Total = total;

                return View("ResultadoCotizacion");
            }


            [HttpPost]
            public ActionResult Comprar(int idPaquete, int cantidadPersonas, decimal total)
            {
                if (Session["Usuario"] == null)
                    return RedirectToAction("login", "Usuario");

                var usuario = (UsuarioDTO)Session["Usuario"];

                var compra = new CompraDTO
                {
                    IdUsuario = usuario.IdUsuario,
                    IdPaquete = idPaquete,
                    IdFormaPago = 1, // Supongamos que 1 = PayPal
                    Total = total
                };

                var compraBL = new AccionCompras();
                int idCompra = compraBL.RegistrarCompra(compra);



                if (true)
                {
                    compraBL.ConfirmarPago(idCompra);

                    var polizaBL = new AccionPolizas();
                    polizaBL.CrearPoliza(idCompra);
                    int polizaId = polizaBL.ObtenerPolizasPorUsuario(usuario.IdUsuario).ToList().Last().IdPoliza;
                    return RedirectToAction("VerPoliza", "Perfil", new {idPoliza = polizaId});
                }
               
                // return RedirectToAction("Checkout", "Paypal", new { idCompra = idCompra , total = total });
            }



    }
}