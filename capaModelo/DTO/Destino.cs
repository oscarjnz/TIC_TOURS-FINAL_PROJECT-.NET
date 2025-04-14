using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace capaModelo.DTO
{
    public class DestinoDTO
    {
        public int IdDestino { get; set; }
        public string NombreDestino { get; set; }
        public string Descripcion { get; set; }
        public int IdCiudad { get; set; }
        public int Popularidad { get; set; }
    }
}