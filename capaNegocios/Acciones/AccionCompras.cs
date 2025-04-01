using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using capaDatos.Database;

namespace capaNegocios.Acciones
{
    public class AccionCompras : AccionesBases
    {

        /// <summary>
        /// Metodo de guardar compras
        /// </summary>
        /// <param name="idSeguro"></param>
        /// <param name="precio"></param>
        /// <param name="idUsuario"></param>
        /// <returns></returns>
        public bool GuardarCompra(int idSeguro, decimal precio, int idUsuario)
        {
            bool resultado = false;

            try
            {
                //buscar coincidencias

                var seguros_existe = _DbContextSeguros.td_polizas.Where(x => x.id_seguro == idSeguro && x.id_seguro == idSeguro).ToList();

                //validar (operador ternario)

                resultado = (seguros_existe.Count > 0) ? true : false;


                if (resultado)
                {
                    resultado = false;
                    throw new ArgumentException($"El usuario tiene este seguro asignado {idSeguro}");
                }
                else
                {
                    td_poliza nuevaPoliza = new td_poliza();
                    nuevaPoliza.id_usuario = idUsuario;
                    nuevaPoliza.id_seguro = idSeguro;
                    nuevaPoliza.id_cotizacion = 0;
                    nuevaPoliza.fecha_inicio = DateTime.Now;
                    nuevaPoliza.fecha_fin = DateTime.Now.AddYears(1);
                    nuevaPoliza.monto = precio;
                    nuevaPoliza.estado = "Activo";
                    nuevaPoliza.creada_en = DateTime.Now;
                    nuevaPoliza.flag_activo = true;

                    _DbContextSeguros.td_polizas.InsertOnSubmit(nuevaPoliza);
                    _DbContextSeguros.SubmitChanges();

                    resultado = true;
                }

                return resultado;
                 
            }
            catch (Exception)
            {
                return false;
            }

            
        }

    }
}
