using System;
using System.Collections.Generic;
using capaDatos.Database;
using capaModelo.DTO;
using System.Web.Mvc;
using System.Linq;

namespace capaNegocios.Acciones.AccionesBackoffice
{
    
    public class AccionReclamacion
    {
        DbLibraryEntityDataContext _context = new DbLibraryEntityDataContext();
        public List<ReclamacionDTO> ObtenerTodas()
        {
            return _context.td_reclamaciones.Select(r => new ReclamacionDTO
            {
                IdReclamacion = r.id_reclamacion,
                IdPoliza = r.id_poliza,
                IdMotivo = r.id_motivo,
                Descripcion = r.descripcion,
                Documento = r.documento,
                Estado = r.estado,
                IdAgente = r.id_agente,
                FechaReclamo = r.fecha_reclamo
            }).ToList();
        }

        public ReclamacionDTO ObtenerPorId(int id)
        {
            var r = _context.td_reclamaciones.FirstOrDefault(x => x.id_reclamacion == id);
            if (r == null) return null;

            return new ReclamacionDTO
            {
                IdReclamacion = r.id_reclamacion,
                IdPoliza = r.id_poliza,
                IdMotivo = r.id_motivo,
                Descripcion = r.descripcion,
                Documento = r.documento,
                Estado = r.estado,
                IdAgente = r.id_agente,
                FechaReclamo = r.fecha_reclamo
            };
        }

        public void CambiarEstado(int id, string nuevoEstado)
        {
            var reclamo = _context.td_reclamaciones.FirstOrDefault(r => r.id_reclamacion == id);
            if (reclamo != null)
            {
                reclamo.estado = nuevoEstado;
                _context.SubmitChanges();
            }
        }

    }
}