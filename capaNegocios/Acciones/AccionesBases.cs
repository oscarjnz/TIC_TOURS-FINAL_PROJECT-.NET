using capaDatos;
using capaDatos.Database;
using capaModelo;
using System;
using System.Collections.Generic;
using System.Linq;

namespace capaNegocios
{
    public class AccionesBases
    {
     public DbLibraryEntityDataContext dbLibraryContext = new DbLibraryEntityDataContext();
   
    }

    public class GestorInicio
    {
        private RepositorioInicio _repositorio = new RepositorioInicio();

        public VistaInicioModelo ObtenerDatosInicio()
        {
            var modelo = new VistaInicioModelo
            {
                TituloPagina = "Bienvenido a Turismo Seguro",
                MensajeBienvenida = "Disfruta de los mejores seguros para tus viajes",
                PromocionesDestacadas = _repositorio.ObtenerPromocionesDestacadas()
            };
            return modelo;
        }
    }
    public class GestorCotizacion
    {
        private RepositorioCotizacion _repositorio = new RepositorioCotizacion();

        public VistaCotizacionModelo ObtenerCotizacion(VistaCotizacionModelo modelo)
        {
            if (modelo.FechaSalida >= modelo.FechaRegreso)
            {
                modelo.MensajeError = "La fecha de salida debe ser anterior a la fecha de regreso.";
                return modelo;
            }
            modelo.PrecioCotizacion = _repositorio.CalcularCotizacion(modelo.Destino, modelo.FechaSalida, modelo.FechaRegreso, modelo.CantidadViajeros);
            return modelo;
        }
    }
    public class GestorCompra
    {
        private RepositorioCompra _repositorio = new RepositorioCompra();

        public VistaCompraModelo ProcesarCompra(VistaCompraModelo compra)
        {
            // Validar que el precio sea mayor a 0.
            if (compra.Precio <= 0)
            {
                compra.MensajeError = "El precio no es válido.";
                return compra;
            }
            bool guardado = _repositorio.GuardarCompra(compra.IdSeguro, compra.Precio, compra.IdUsuario);
            compra.CompraExitosa = guardado;
            return compra;
        }
    }

    public class GestorPoliza
    {
        private RepositorioPoliza _repositorio = new RepositorioPoliza();

        public List<VistaPolizaModelo> ObtenerPolizasUsuario(string idUsuario)
        {
            int id;
            if (!int.TryParse(idUsuario, out id))
                return new List<VistaPolizaModelo>();

            var listaEntidades = _repositorio.ObtenerPolizasPorUsuario(id);

            var listaModelos = listaEntidades.Select(p => new VistaPolizaModelo
            {
                NumeroPoliza = p.id_poliza.ToString(),
                NombreSeguro = p.tm_seguro != null ? p.tm_seguro.nombre : string.Empty,
                FechaInicio = p.fecha_inicio,
                FechaFin = p.fecha_fin,
                Estado = p.estado
            }).ToList();

            return listaModelos;
        }
    }

    public class GestorReclamacion
    {
        private RepositorioReclamacion _repositorio = new RepositorioReclamacion();

        public VistaReclamacionModelo EnviarReclamacion(VistaReclamacionModelo reclamacion)
        {

            bool resultado = _repositorio.RegistrarReclamacion(reclamacion.IdUsuario, reclamacion.IdPoliza, reclamacion.Descripcion);
            reclamacion.Estado = resultado ? "En Proceso" : "Error";
            return reclamacion;
        }

        public List<VistaReclamacionModelo> ObtenerReclamacionesUsuario(string idUsuario)
        {
            int id;
            if (!int.TryParse(idUsuario, out id))
                return new List<VistaReclamacionModelo>();

            var listaEntidades = _repositorio.ObtenerReclamacionesPorUsuario(id);

            var listaModelos = listaEntidades.Select(r => new VistaReclamacionModelo
            {
                IdReclamacion = r.id_reclamo,
                Descripcion = r.descripcion,
                Fecha = r.fecha_reclamo.HasValue ? r.fecha_reclamo.Value : DateTime.MinValue,
                Estado = r.estado,

                IdUsuario = r.id_usuario,
                IdPoliza = r.id_poliza
            }).ToList();

            return listaModelos;
        }
    }

}
