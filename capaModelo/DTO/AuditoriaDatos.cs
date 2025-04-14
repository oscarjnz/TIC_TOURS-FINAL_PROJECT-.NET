using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace capaModelo.DTO
{
    public class AuditoriaDatos
    {
        public int IdAuditoria { get; set; }
        public int IdUsuario { get; set; }
        public string EntidadAfectada { get; set; }
        public string CampoAfectado { get; set; }
        public string ValorAnterior { get; set; }
        public string ValorNuevo { get; set; }
        public DateTime FechaCambio { get; set; }
    }
}