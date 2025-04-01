using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace capaModelo.DTO
{
    public class VistaCotizacionModelo
    {
        public string Destino { get; set; }
        public DateTime FechaSalida { get; set; }
        public DateTime FechaRegreso { get; set; }
        public int CantidadViajeros { get; set; }
        public decimal PrecioCotizacion { get; set; }
        public string MensajeError { get; set; }

    }
}
