using System;
using System.Configuration;
using System.Threading.Tasks;
using System.Web.Mvc;
using capaNegocios.Acciones;
using System.Web.Mvc;
using PaypalServerSdk.Standard;
using PaypalServerSdk.Standard.Authentication;
using PaypalServerSdk.Standard.Models;


namespace TIC_TOURS_App.Controllers
{
    // public class PaypalController : Controller
    // {
    //     private string ClientId => System.Configuration.ConfigurationManager.AppSettings["PayPalClientId"];
    //     private string ClientSecret => System.Configuration.ConfigurationManager.AppSettings["PayPalSecret"];
    //
    //     private PaypalServerSdkClient GetClient()
    //     {
    //         return new PaypalServerSdkClient.Builder()
    //             .ClientCredentialsAuth(
    //                 new ClientCredentialsAuthModel.Builder(ClientId, ClientSecret).Build()
    //             )
    //             .Environment(PaypalServerSdk.Standard.Environment.Sandbox) // Cambia a Live para producción
    //             .Build();
    //     }
    //
    //     
    //     public async Task<ActionResult> Checkout(int idCompra, decimal total)
    //     {
    //         var client = GetClient();
    //
    //         var request = new OrderRequest
    //         {
    //             Intent = "CAPTURE",
    //             PurchaseUnits = new System.Collections.Generic.List<PurchaseUnitRequest>
    //             {
    //                 new PurchaseUnitRequest
    //                 {
    //                     Amount = new AmountWithBreakdown
    //                     {
    //                         CurrencyCode = "USD",
    //                         Value = total.ToString("F2")
    //                     }
    //                 }
    //             },
    //             ApplicationContext = new OrderApplicationContext()
    //             {
    //                 ReturnUrl = Url.Action("Success", "Paypal", new { idCompra = idCompra }, Request.Url.Scheme),
    //                 CancelUrl = Url.Action("Cancel", "Paypal", null, Request.Url.Scheme)
    //             }
    //         };
    //
    //         var response = await client.OrdersController.CreateOrderAsync(request);
    //
    //         var approveUrl = response.Links.FirstOrDefault(x => x.Rel == "approve")?.Href;
    //
    //         if (approveUrl != null)
    //             return Redirect(approveUrl);
    //
    //         return Content("Error al generar orden de PayPal.");
    //     }
    //
    //     // GET: Paypal/Success?token=...
    //     public async Task<ActionResult> Success(string token, int idCompra)
    //     {
    //         var client = GetClient();
    //         var captureResult = await client.Orders.CaptureOrderAsync(token);
    //
    //         if (captureResult.Status == "COMPLETED")
    //         {
    //             
    //             AccionCompras.ConfirmarPago(idCompra);
    //             return RedirectToAction("Gracias");
    //         }
    //
    //         return RedirectToAction("Cancel");
    //     }
    //
    //     public ActionResult Cancel()
    //     {
    //         return Content("El pago fue cancelado.");
    //     }
    //
    //     public ActionResult Gracias()
    //     {
    //         return Content("¡Gracias! El pago fue procesado correctamente.");
    //     }
    // }

}