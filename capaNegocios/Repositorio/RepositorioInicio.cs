using capaDatos.Database;
using capaModelo.DTO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Web.ModelBinding;
using capaNegocios.Acciones;
 
namespace capaDatos
{ 
     public class RepositorioInicio
     {
         // public ActionResult Register() => View();
         //
         //
         //     
         // [HttpPost] 
         // public ActionResult Register(RegistroViewModel model) 
         // {
         //     if (ModelState.IsValid)
         //     {
         //         if (DbContextSeguros.Usuarios.Any(u => u.CorreoElectronico == model.CorreoElectronico))
         //         {
         //             ModelState.AddModelError("", "El correo ya está registrado.");
         //             return View(model);
         //         }
         //
         //         var usuario = new Usuario
         //         {
         //             Nombre = model.Nombre,
         //             Apellido = model.Apellido,
         //             CorreoElectronico = model.CorreoElectronico,
         //             Contrasena = HashPassword(model.Contrasena),
         //             IdRol = 2, // Cliente
         //             EstadoCuenta = "activo",
         //             FechaRegistro = DateTime.Now
         //         };
         //
         //         DbContextSeguros.Usuarios.Add(usuario);
         //         DbContextSeguros.SaveChanges();
         //
         //         // return RedirectToAction("Login");
         //     }
         //
         //     return View(model);
         // }

        //declar los modelos (DTO) vistas de webpage

        // private readonly VistaInicioModelo _repositorioInicio = new VistaInicioModelo();
        // private readonly VistaCotizacionModelo _repositorioCotizacion = new VistaCotizacionModelo();
        // private readonly VistaPolizaModelo _repositorioPoliza = new VistaPolizaModelo();
        // private readonly VistaReclamacionModelo _repositorioReclamacion = new VistaReclamacionModelo();

        //Declarar acciones (Repositorios) de bases de datos

        // private readonly AccionCompras _compras = new AccionCompras();
        // private readonly AccionCotizaciones _cotizacion = new AccionCotizaciones();
        // private readonly AccionPolizas _poliza = new AccionPolizas();
        // private readonly AccionReclamaciones _reclamaciones = new AccionReclamaciones();

        // public VistaInicioModelo ObtenerDatosInicio()
        // {
        //     var modelo = new VistaInicioModelo
        //     {
        //         TituloPagina = "Bienvenido a Turismo Seguro",
        //         MensajeBienvenida = "Disfruta de los mejores seguros para tus viajes",
        //         PromocionesDestacadas = _cotizacion.ObtenerPromocionesDestacadas()
        //     };
        //     return modelo;
        // }

        /// <summary>
        /// Repo. Para Procesar compras del clientes (seguros)
        /// </summary>
        /// <param name="compra"></param>
        /// <returns></returns>
        // public VistaCompraModelo ProcesarCompra(VistaCompraModelo compra)
        // {
        //     // Validar que el precio sea mayor a 0.
        //     if (compra.Precio <= 0)
        //     {
        //         compra.MensajeError = "El precio no es válido.";
        //         return compra;
        //     }
        //     bool guardado = _compras.GuardarCompra(compra.IdSeguro, compra.Precio, compra.IdUsuario);
        //     compra.CompraExitosa = guardado;
        //     return compra;
        // }


        /// <summary>
        /// Repo. Obtener polizas usuarios
        /// </summary>
        /// <param name="idUsuario"></param>
        /// <returns></returns>
        // public List<VistaPolizaModelo> ObtenerPolizasUsuario(string idUsuario)
        // {
        //     int id;
        //     if (!int.TryParse(idUsuario, out id))
        //         return new List<VistaPolizaModelo>();
        //
        //     var listaEntidades = _poliza.ObtenerPolizasPorUsuario(id);
        //
        //     var listaModelos = listaEntidades.Select(p => new VistaPolizaModelo
        //     {
        //         NumeroPoliza = p.id_poliza.ToString(),
        //         NombreSeguro = p.tm_seguro != null ? p.tm_seguro.nombre : string.Empty,
        //         FechaInicio = p.fecha_inicio,
        //         FechaFin = p.fecha_fin,
        //         Estado = p.estado
        //     }).ToList();
        //
        //     return listaModelos;
        // }
         
        
        // public VistaReclamacionModelo EnviarReclamacion(VistaReclamacionModelo reclamacion)
        // {
        //
        //     bool resultado = _reclamaciones.RegistrarReclamacion(reclamacion.IdUsuario, reclamacion.IdPoliza, reclamacion.Descripcion);
        //     reclamacion.Estado = resultado ? "En Proceso" : "Error";
        //     return reclamacion;
        // }
        //
        // public List<VistaReclamacionModelo> ObtenerReclamacionesUsuario(string idUsuario)
        // {
        //     int id;
        //     if (!int.TryParse(idUsuario, out id))
        //         return new List<VistaReclamacionModelo>();
        //
        //     var listaEntidades = _reclamaciones.ObtenerReclamacionesPorUsuario(id);
        //
        //     var listaModelos = listaEntidades.Select(r => new VistaReclamacionModelo
        //     {
        //         IdReclamacion = r.id_reclamo,
        //         Descripcion = r.descripcion,
        //         Fecha = r.fecha_reclamo.HasValue ? r.fecha_reclamo.Value : DateTime.MinValue,
        //         Estado = r.estado,
        //
        //         IdUsuario = r.id_usuario,
        //         IdPoliza = r.id_poliza
        //     }).ToList();
        //
        //     return listaModelos;
        // } 
    } 
   

}

