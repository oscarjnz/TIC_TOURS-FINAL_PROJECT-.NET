using capaModelo;
using capaNegocios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using capaModelo.DTO;
using capaNegocios.Acciones;
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

                return View(paquete);
            }
            public ActionResult Cotizar(int id)
            {
                var paquete = _paqueteBL.ObtenerPaquetePorId(id);
                if (paquete == null)
                    return RedirectToAction("Index");

                ViewBag.Paquete = paquete;
                return View();
            }
            
            [HttpPost]
            public ActionResult Cotizar(int idPaquete, int cantidadPersonas, DateTime fechaInicio, string[] servicios)
            {
                var paquete = _paqueteBL.ObtenerPaquetePorId(idPaquete);
                if (paquete == null)
                    return RedirectToAction("Index");

                decimal precioBase = paquete.PrecioBase;
                decimal subtotal = precioBase * cantidadPersonas;
                decimal serviciosExtra = 0;
                
                if (servicios != null)
                {
                    foreach (var servicio in servicios)
                    {
                        switch (servicio)
                        {
                            case "Seguro médico":
                                serviciosExtra += 500;
                                break;
                            case "Traslado aeropuerto":
                                serviciosExtra += 800;
                                break;
                            case "Tour guiado":
                                serviciosExtra += 1200;
                                break;
                        }
                    }
                }

                decimal total = subtotal + serviciosExtra;

                ViewBag.Paquete = paquete;
                ViewBag.CantidadPersonas = cantidadPersonas;
                ViewBag.FechaInicio = fechaInicio.ToShortDateString();
                ViewBag.Servicios = servicios;
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
                    return RedirectToAction("Index");
                }
               
                // return RedirectToAction("Checkout", "Paypal", new { idCompra = idCompra , total = total });
            }



    }
}