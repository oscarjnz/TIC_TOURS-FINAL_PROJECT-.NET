using System;
using System.Collections.Generic;
using capaDatos.Database;
using System.Linq;

namespace capaDatos.Funciones
{
    public class CompraDAL
    {
        private readonly DbLibraryEntityDataContext _context = new DbLibraryEntityDataContext();


        public int RegistrarCompra(td_compra compra)
        {
            _context.td_compras.InsertOnSubmit(compra);
            _context.SubmitChanges();
            return compra.id_compra; // devuelve el ID generado
        }

        public void ConfirmarPago(int idCompra)
        {
            var compra = _context.td_compras.FirstOrDefault(c => c.id_compra == idCompra);
            if (compra != null)
            {
                compra.estado_pago = "pagado";
                compra.fecha_compra = DateTime.Now;
                _context.SubmitChanges();
            }
        }
    }
}