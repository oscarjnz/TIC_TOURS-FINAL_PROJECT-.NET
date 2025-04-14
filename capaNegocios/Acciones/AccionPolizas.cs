using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using capaDatos.Database;
using capaDatos.Funciones;
using System.Web.Mvc;
using capaModelo.DTO;
using capaNegocios.Helpers;

namespace capaNegocios.Acciones
{
    public class AccionPolizas : AccionesBases
    {

        private readonly PolizaDAL _dal = new PolizaDAL();
        public void CrearPoliza(int idCompra)
        {
            var dto = new PolizaDTO
            {
                IdCompra = idCompra,
                IdCobertura = 1,
                NumeroPoliza = $"TS-{Guid.NewGuid().ToString().Substring(0, 8).ToUpper()}",
                FechaInicio = DateTime.Today,
                FechaFin = DateTime.Today.AddDays(7),
                Estado = "activa"
            };

          

            _dal.GenerarPoliza(idCompra, "dasdas", dto.NumeroPoliza, dto.FechaInicio, dto.FechaFin);
        }
        public List<PolizaDTO> ObtenerPolizasPorUsuario(int idUsuario)
        {
            var lista = _dal.ObtenerPolizasPorUsuario(idUsuario);

            return lista.Select(p => new PolizaDTO
            {
                IdPoliza = p.id_poliza,
                IdCompra = p.id_compra,
                IdCobertura = p.id_cobertura,
                NumeroPoliza = p.numero_poliza,
                FechaInicio = p.fecha_inicio,
                FechaFin = p.fecha_fin,
                ArchivoPdf = p.archivo_pdf,
                Estado = p.estado,
                CreatedAt = p.created_at,
                UpdatedAt = p.updated_at
            }).ToList();
        }
    }
}
