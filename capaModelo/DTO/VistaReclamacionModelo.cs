using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace capaModelo.DTO
{
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
