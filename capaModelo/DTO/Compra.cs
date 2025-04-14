using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace capaModelo.DTO
{
    public class CompraDTO
    {
        public int IdCompra { get; set; }
        public int IdUsuario { get; set; }
        public int IdPaquete { get; set; }
        public int IdFormaPago { get; set; }
        public decimal Total { get; set; }
        public string EstadoPago { get; set; }
        public DateTime FechaCompra { get; set; }
    }

}