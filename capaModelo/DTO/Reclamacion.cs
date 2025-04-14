using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace capaModelo.DTO
{
    public class ReclamacionDTO
    {
        public int IdReclamacion { get; set; }
        public int IdPoliza { get; set; }
        public int IdMotivo { get; set; }
        public string Descripcion { get; set; }
        public string Documento { get; set; }
        public string Estado { get; set; }
        public int IdAgente { get; set; }
        public DateTime FechaReclamo { get; set; }
    }
}