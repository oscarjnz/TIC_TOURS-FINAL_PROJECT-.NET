using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace capaModelo
{
    public class VistaInicioModelo
    {
        public string TituloPagina { get; set; }
        public List<string> PromocionesDestacadas { get; set; }
        public string MensajeBienvenida { get; set; }
    }

    public class VistaCotizacionModelo
    {
        public string Destino { get; set; }
        public DateTime FechaSalida { get; set; }
        public DateTime FechaRegreso { get; set; }
        public int CantidadViajeros { get; set; }
        public decimal PrecioCotizacion { get; set; }
        public string MensajeError { get; set; }
    }

    public class VistaCompraModelo
    {
        public int IdSeguro { get; set; }
        public string NombreSeguro { get; set; }
        public decimal Precio { get; set; }
        public string NombreUsuario { get; set; }
        public string MetodoPago { get; set; }
        public bool CompraExitosa { get; set; }
        public string MensajeError { get; set; }
        public int IdUsuario { get; set; }
    }

    public class VistaPolizaModelo
    {
        public string NumeroPoliza { get; set; }
        public string NombreSeguro { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public string Estado { get; set; }
    }

    public class VistaReclamacionModelo
    {
        public int IdReclamacion { get; set; }
        public string Descripcion { get; set; }
        public DateTime Fecha { get; set; }
        public string Estado { get; set; }
        public int IdUsuario { get; set; }
        public string RutaArchivoAdjunto { get; set; }
        public int IdPoliza { get; set; }
    }
}
