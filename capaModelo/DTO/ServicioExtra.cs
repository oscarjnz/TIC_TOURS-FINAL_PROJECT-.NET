using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace capaModelo.DTO
{
    public class ServicioExtraDTO
    {
        public int IdServicio { get; set; }
        public string NombreServicio { get; set; }
        public string Descripcion { get; set; }
        public decimal? Precio { get; set; }
        public bool? Disponible { get; set; }
    }
}