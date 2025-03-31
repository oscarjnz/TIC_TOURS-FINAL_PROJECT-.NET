using capaDatos.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace capaDatos
{
   

 public class RepositorioInicio
    {
        public List<string> ObtenerPromocionesDestacadas()
        {
            using (var contexto = new DbLibraryEntityDataContext())
            {
                var promociones = (from seguro in contexto.tm_seguros
                                   where seguro.flag_activo == true
                                   orderby seguro.creada_en descending
                                   select seguro.nombre).Take(3).ToList();
                return promociones;
            }
        }
    }
    public class RepositorioCotizacion
    {
        public decimal CalcularCotizacion(string destino, DateTime fechaSalida, DateTime fechaRegreso, int cantidadViajeros)
        {
            using (var contexto = new DbLibraryEntityDataContext())
            {
                decimal tarifaBase = contexto.tm_seguros
                                        .Where(s => s.flag_activo == true)
                                        .OrderBy(s => s.precio)
                                        .Select(s => s.precio)
                                        .FirstOrDefault();
                int dias = (fechaRegreso - fechaSalida).Days;
                return tarifaBase * dias * cantidadViajeros;
            }
        }
    }

    public class RepositorioCompra
    {
        public bool GuardarCompra(int idSeguro, decimal precio, int idUsuario)
        {
            try
            {
                using (var contexto = new DbLibraryEntityDataContext())
                {
                    td_poliza nuevaPoliza = new td_poliza();
                    nuevaPoliza.id_usuario = idUsuario;
                    nuevaPoliza.id_seguro = idSeguro;r.
                    nuevaPoliza.id_cotizacion = 0;
                    nuevaPoliza.fecha_inicio = DateTime.Now;
                    nuevaPoliza.fecha_fin = DateTime.Now.AddYears(1);
                    nuevaPoliza.monto = precio;
                    nuevaPoliza.estado = "Activo";
                    nuevaPoliza.creada_en = DateTime.Now;
                    nuevaPoliza.flag_activo = true;

                    contexto.td_polizas.InsertOnSubmit(nuevaPoliza);
                    contexto.SubmitChanges();
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
    public class RepositorioPoliza
    {
        public List<td_poliza> ObtenerPolizasPorUsuario(int idUsuario)
        {
            using (var contexto = new DbLibraryEntityDataContext())
            {
                var consulta = from poliza in contexto.td_polizas
                               where poliza.id_usuario == idUsuario && poliza.flag_activo == true
                               select poliza;
                return consulta.ToList();
            }
        }
    }
    public class RepositorioReclamacion
    {
        public bool RegistrarReclamacion(int idUsuario, int idPoliza, string descripcion)
        {
            try
            {
                using (var contexto = new DbLibraryEntityDataContext())
                {
                    td_reclamo nuevoReclamo = new td_reclamo();
                    nuevoReclamo.id_usuario = idUsuario;
                    nuevoReclamo.id_poliza = idPoliza;
                    nuevoReclamo.descripcion = descripcion;
                    nuevoReclamo.fecha_reclamo = DateTime.Now;
                    nuevoReclamo.estado = "En Proceso";
                    nuevoReclamo.creada_en = DateTime.Now;
                    nuevoReclamo.flag_activo = true;

                    contexto.td_reclamos.InsertOnSubmit(nuevoReclamo);
                    contexto.SubmitChanges();
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<td_reclamo> ObtenerReclamacionesPorUsuario(int idUsuario)
        {
            using (var contexto = new DbLibraryEntityDataContext())
            {
                var consulta = from reclamo in contexto.td_reclamos
                               where reclamo.id_usuario == idUsuario && reclamo.flag_activo == true
                               select reclamo;
                return consulta.ToList();
            }
        }
    }

}

