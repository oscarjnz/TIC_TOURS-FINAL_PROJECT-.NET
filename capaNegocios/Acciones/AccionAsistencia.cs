using System;
using System.Collections.Generic;
using capaDatos.Database;
using capaModelo.DTO;
using System.Web.Mvc;
using System.Linq;

namespace capaNegocios.Acciones
{
    public class AccionAsistencia
    {
        private readonly DbLibraryEntityDataContext _context = new DbLibraryEntityDataContext();

        public List<AgenteSoporteDTO> ObtenerActivos()
        {
            // Si hay una columna "activo" puedes filtrar, si no, tráelos todos
            return _context.tm_agentes_soportes.Select(a => new AgenteSoporteDTO
            {
                IdAgente = a.id_agente,
                NombreAgente = a.nombre_agente,
                Correo = a.correo,
                Telefono = a.telefono
            }).ToList();
        }
    }
}