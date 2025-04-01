using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using capaDatos.Database;

namespace capaNegocios.Acciones
{
    public class AccionPolizas : AccionesBases
    {

        /// <summary>
        /// Metodo de obtener polizas por usuarios
        /// </summary>
        /// <param name="idUsuario"></param>
        /// <returns></returns>
        public List<td_poliza> ObtenerPolizasPorUsuario(int idUsuario = 0)
        {
            var consulta = from poliza in _DbContextSeguros.td_polizas
                           where poliza.id_usuario == idUsuario && poliza.flag_activo == true
                          || (poliza.id_usuario != 0) // enviar todo el listado de la tabla
                           select poliza;
            return consulta.ToList();

             
        }
    }
}
