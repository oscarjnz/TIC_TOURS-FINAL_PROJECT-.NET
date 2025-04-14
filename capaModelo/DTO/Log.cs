using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace capaModelo.DTO
{
    public class LogDTO
    {
        public int IdLog { get; set; }
        public int IdUsuario { get; set; }
        public string Modulo { get; set; }
        public string Accion { get; set; }
        public string Descripcion { get; set; }
        public string IpOrigen { get; set; }
        public DateTime FechaLog { get; set; }
    }
}