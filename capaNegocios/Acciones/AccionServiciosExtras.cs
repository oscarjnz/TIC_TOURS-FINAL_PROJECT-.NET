using System;
using System.Collections.Generic;
using capaDatos.Database;
using capaModelo.DTO;
using System.Web.Mvc;
using System.Linq;

namespace capaNegocios.Acciones
{
    public class AccionServiciosExtras
    {
        private readonly DbLibraryEntityDataContext _context = new DbLibraryEntityDataContext();

        public List<ServicioExtraDTO> ObtenerDisponibles()
        {
            return _context.tm_servicios_extras
                .Where(s => s.disponible == true)
                .Select(s => new ServicioExtraDTO
                {
                    IdServicio = s.id_servicio,
                    NombreServicio = s.nombre_servicio,
                    Descripcion = s.descripcion,
                    Precio = s.precio,
                    Disponible = s.disponible
                }).ToList();
        }

    }
}