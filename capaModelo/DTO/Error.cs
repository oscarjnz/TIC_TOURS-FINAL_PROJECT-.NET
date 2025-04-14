using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace capaModelo.DTO
{
    public class ErrorDTO
    {
        public int IdError { get; set; }
        public string Modulo { get; set; }
        public string Mensaje { get; set; }
        public string Traza { get; set; }
        public string Nivel { get; set; }
        public DateTime Fecha { get; set; }
    }
}