using System;
using System.Collections.Generic;
using capaDatos.Database;
using capaModelo.DTO;
using System.Web.Mvc;
using System.Linq;

namespace capaNegocios.Acciones.AccionesBackoffice
{
    public class AccionPoliza
    {
        DbLibraryEntityDataContext _context = new DbLibraryEntityDataContext();
        public List<PolizaDTO> ObtenerTodas()
        {
            return _context.td_polizas.Select(p => new PolizaDTO
            {
                IdPoliza = p.id_poliza,
                NumeroPoliza = p.numero_poliza,
                IdCompra = p.id_compra,
                FechaInicio = p.fecha_inicio,
                FechaFin = p.fecha_fin,
                Estado = p.estado,
                ArchivoPdf = p.archivo_pdf
            }).ToList();
        }

        public PolizaDTO ObtenerPorId(int id)
        {
            var p = _context.td_polizas.FirstOrDefault(x => x.id_poliza == id);
            if (p == null) return null;

            return new PolizaDTO
            {
                IdPoliza = p.id_poliza,
                NumeroPoliza = p.numero_poliza,
                FechaInicio = p.fecha_inicio,
                FechaFin = p.fecha_fin,
                Estado = p.estado,
                ArchivoPdf = p.archivo_pdf
            };
        }

        public void CambiarEstado(int id, string nuevoEstado)
        {
            var poliza = _context.td_polizas.FirstOrDefault(p => p.id_poliza == id);
            if (poliza != null)
            {
                poliza.estado = nuevoEstado;
                poliza.updated_at = DateTime.Now;
                _context.SubmitChanges();
            }
        }

    }
}