using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using capaDatos.Database;
using capaModelo.DTO;

namespace capaNegocios.Acciones
{
    public class AccionReclamaciones : AccionesBases
    {

            private readonly DbLibraryEntityDataContext _context = new DbLibraryEntityDataContext();

            public void Registrar(ReclamacionDTO dto)
            {
                var entidad = new td_reclamacione
                {
                    id_poliza = dto.IdPoliza,
                    id_motivo = dto.IdMotivo > 0 ? dto.IdMotivo : 1, // Motivo por defecto si no viene
                    descripcion = dto.Descripcion,
                    documento = dto.Documento,
                    estado = "pendiente",
                    id_agente = dto.IdAgente,
                    fecha_reclamo = DateTime.Now
                };

                _context.td_reclamaciones.InsertOnSubmit(entidad);
                _context.SubmitChanges();
            }

            public List<ReclamacionDTO> ObtenerPorUsuario(int idUsuario)
            {
                var query = from r in _context.td_reclamaciones
                    join p in _context.td_polizas on r.id_poliza equals p.id_poliza
                    join c in _context.td_compras on p.id_compra equals c.id_compra
                    where c.id_usuario == idUsuario
                    select new ReclamacionDTO
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

                return query.ToList();
            }
        
    }
}
