using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace capaModelo.DTO
{
    public class CompraServicioExtraDTO
    {
        public int Id { get; set; }
        public int IdCompra { get; set; }
        public int IdServicio { get; set; }
        public int Cantidad { get; set; }
    }
}