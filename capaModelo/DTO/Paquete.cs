using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace capaModelo.DTO
{
    public class PaqueteDTO
    {
        public int IdPaquete { get; set; }
        public string NombrePaquete { get; set; }
        public string Descripcion { get; set; }
        public int DuracionDias { get; set; }
        public decimal PrecioBase { get; set; }
        public int IdDestino { get; set; }
        public string TipoPaquete { get; set; }
        public string foto { get; set; }
        public string Estado { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}