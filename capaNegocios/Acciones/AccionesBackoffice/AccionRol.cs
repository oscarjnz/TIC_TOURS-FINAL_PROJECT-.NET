using System;
using System.Collections.Generic;
using capaDatos.Database;
using capaModelo.DTO;
using System.Web.Mvc;
using System.Linq;

namespace capaNegocios.Acciones.AccionesBackoffice
{
    public class AccionRol
    {
        private readonly DbLibraryEntityDataContext _context = new DbLibraryEntityDataContext();
        public List<RolDTO> ObtenerTodos()
        {
            return _context.tm_roles.Select(r => new RolDTO
            {
                IdRol = r.id_rol,
                NombreRol = r.nombre_rol,
                Descripcion = r.descripcion,
                CreatedAt = r.created_at,
                UpdatedAt = r.updated_at
            }).ToList();
        }

        public RolDTO ObtenerPorId(int id)
        {
            var r = _context.tm_roles.FirstOrDefault(x => x.id_rol == id);
            if (r == null) return null;

            return new RolDTO
            {
                IdRol = r.id_rol,
                NombreRol = r.nombre_rol,
                Descripcion = r.descripcion,
                CreatedAt = r.created_at,
                UpdatedAt = r.updated_at
            };
        }
    }
}