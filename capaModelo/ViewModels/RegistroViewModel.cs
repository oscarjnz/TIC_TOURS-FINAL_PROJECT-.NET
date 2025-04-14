using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
namespace capaModelo.DTO
{
    public class RegistroViewModel
    {
        
        public string Nombre { get; set; }

        
        public string Apellido { get; set; }
        
        public string CorreoElectronico { get; set; }
        
        public string Contrasena { get; set; }


        public string ConfirmarContrasena { get; set; }
    }
}