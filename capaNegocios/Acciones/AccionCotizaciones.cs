using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using capaDatos;
using capaDatos.Database;
using capaModelo;

namespace capaNegocios.Acciones
{
    public class AccionCotizaciones :AccionesBases
    {
         
        #region CRUD (crear, Actualizar, Eliminar, Consultar
         
        /// <summary>
        /// Metodo de consultar cotizaciones (Vehiculos, Vida, Viajes)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<tm_seguro> GetCotizaciones(int id = 0)
        { 
            return _DbContextSeguros.tm_seguros
                .Where(x=> (x.id_seguro == id) || (x.id_seguro > 0))    // filtrar por id o descartar el ID
                .ToList();

        }


        public List<string> ObtenerPromocionesDestacadas()
        {
            var promociones = (from seguro in _DbContextSeguros.tm_seguros
                               where seguro.flag_activo == true
                               orderby seguro.creada_en descending
                               select seguro.nombre).Take(3).ToList();
            return promociones;

            
        }


        #endregion

        #region Calculos

        /// <summary>
        /// Metodo de calcular cotizacion
        /// </summary>
        /// <param name="destino"></param>
        /// <param name="fechaSalida"></param>
        /// <param name="fechaRegreso"></param>
        /// <param name="cantidadViajeros"></param>
        /// <returns></returns>
        public decimal CalcularCotizacion(
            string destino,
            DateTime fechaSalida,
            DateTime fechaRegreso,
            int cantidadViajeros)
        {
            //linq

            decimal tarifaBase = _DbContextSeguros.tm_seguros
                                    .Where(s => s.flag_activo == true)
                                    .OrderBy(s => s.precio)
                                    .Select(s => s.precio)
                                    .FirstOrDefault();
            int dias = (fechaRegreso - fechaSalida).Days;
            return tarifaBase * dias * cantidadViajeros;


        }
        #endregion
         

    }
}
