using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using capaDatos.Database;

namespace capaNegocios.Acciones
{
    public class AccionReclamaciones : AccionesBases
    {

        public bool RegistrarReclamacion(int idUsuario, int idPoliza, string descripcion)
        {
            try
            {
                td_reclamo nuevoReclamo = new td_reclamo();
                nuevoReclamo.id_usuario = idUsuario;
                nuevoReclamo.id_poliza = idPoliza;
                nuevoReclamo.descripcion = descripcion;
                nuevoReclamo.fecha_reclamo = DateTime.Now;
                nuevoReclamo.estado = "En Proceso";
                nuevoReclamo.creada_en = DateTime.Now;
                nuevoReclamo.flag_activo = true;

                _DbContextSeguros.td_reclamos.InsertOnSubmit(nuevoReclamo);
                _DbContextSeguros.SubmitChanges();
                return true;

                 
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<td_reclamo> ObtenerReclamacionesPorUsuario(int idUsuario)
        {

            var consulta = from reclamo in _DbContextSeguros.td_reclamos
                           where reclamo.id_usuario == idUsuario && reclamo.flag_activo == true
                           select reclamo;
            return consulta.ToList();
            
        }


    }
}
