using System.Linq;
using capaDatos.Database;
using capaModelo.DTO;

namespace capaNegocios.Acciones
{
    public class AccionBackoffice
    {
        DbLibraryEntityDataContext _context = new DbLibraryEntityDataContext();
        public DashboardResumenDTO ObtenerKPIs()
        {
            return new DashboardResumenDTO
            {
                TotalUsuarios = _context.tm_usuarios.Count(),
                TotalPolizas = _context.td_polizas.Count(),
                TotalReclamaciones = _context.td_reclamaciones.Count(),
                PolizasActivas = _context.td_polizas.Count(p => p.estado == "activa"),
                ReclamacionesPendientes = _context.td_reclamaciones.Count(r => r.estado == "pendiente")
            };
        }
    }
}