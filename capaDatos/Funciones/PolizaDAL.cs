using System;
using System.Collections.Generic;
using capaDatos.Database;
using System.Linq;


namespace capaDatos.Funciones
{
    public class PolizaDAL
    {
        private readonly DbLibraryEntityDataContext _context = new DbLibraryEntityDataContext();
        public void GenerarPoliza(int idCompra, string archivoPdf, string numeroPoliza, DateTime fechaInicio, DateTime fechaFin)
        {
            var nuevaPoliza = new td_poliza
            {
                id_compra = idCompra,
                id_cobertura = 1,
                numero_poliza = numeroPoliza,
                fecha_inicio = fechaInicio,
                fecha_fin = fechaFin,
                archivo_pdf = archivoPdf,
                estado = "activa",
                created_at = DateTime.Now,
                updated_at = DateTime.Now
            };

            _context.td_polizas.InsertOnSubmit(nuevaPoliza);
            _context.SubmitChanges();
        }
        public List<td_poliza> ObtenerPolizasPorUsuario(int idUsuario)
        {
            return (from p in _context.td_polizas
                join c in _context.td_compras on p.id_compra equals c.id_compra
                where c.id_usuario == idUsuario
                select p).ToList();
        }
    }
}