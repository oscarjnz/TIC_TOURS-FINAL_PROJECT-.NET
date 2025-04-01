using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace capaModelo.DTO
{
    public class VistaInicioModelo
    { 
        public string TituloPagina { get; set; }
        public List<string> PromocionesDestacadas { get; set; }
        public string MensajeBienvenida { get; set; }

        //referenciar clases a otras
        public VistaInicioModelo()
        {

        }

        public VistaInicioModelo(string tituloPagina, List<string> promocionesDestacadas, string mensajeBienvenida)
        {
            TituloPagina = tituloPagina;
            PromocionesDestacadas = promocionesDestacadas;
            MensajeBienvenida = mensajeBienvenida;
        }   
    }
}
