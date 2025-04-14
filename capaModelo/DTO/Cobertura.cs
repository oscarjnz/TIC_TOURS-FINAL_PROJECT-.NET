using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace capaModelo.DTO
{
    public class CoberturaDTO
    {
        public int IdCobertura { get; set; }
        public string NombreCobertura { get; set; }
        public string Descripcion { get; set; }
        public decimal MontoMaximo { get; set; }
        public bool IncluyeAsistencia { get; set; }
    }

}