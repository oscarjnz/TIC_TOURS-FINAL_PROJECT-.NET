using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace capaModelo.DTO
{
    public class FormaPagoDTO
    {
        public int IdFormaPago { get; set; }
        public string Metodo { get; set; }
        public string Descripcion { get; set; }
    }

}