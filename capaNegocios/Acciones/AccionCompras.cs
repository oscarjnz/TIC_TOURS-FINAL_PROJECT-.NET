using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using capaDatos.Database;
using capaDatos.Funciones;
using capaModelo.DTO;

namespace capaNegocios.Acciones
{
    public class AccionCompras : AccionesBases
    {
     
            private readonly CompraDAL _dal = new CompraDAL();

         

            public int RegistrarCompra(CompraDTO dto)
            {
                var compra = new td_compra
                {
                    id_usuario = dto.IdUsuario,
                    id_paquete = dto.IdPaquete,
                    id_forma_pago = dto.IdFormaPago,
                    total = dto.Total,
                    estado_pago = "pendiente",
                    fecha_compra = DateTime.Now
                };

                return _dal.RegistrarCompra(compra);
            }

            public void ConfirmarPago(int idCompra)
            {
                _dal.ConfirmarPago(idCompra);
            }
        
    }
}
