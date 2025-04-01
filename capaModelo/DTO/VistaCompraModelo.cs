using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace capaModelo.DTO
{
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
}
