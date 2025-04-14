using System;
using System.Collections.Generic;
using capaDatos.Database;
using capaModelo.DTO;
using System.Web.Mvc;
using System.Linq;

namespace capaNegocios.Acciones.AccionesBackoffice
{
    public class AccionCiudadBackoffice
    {
        private readonly DbLibraryEntityDataContext _context = new DbLibraryEntityDataContext();
        
        public List<CiudadDTO> ObtenerTodas()
        {
            return _context.tm_ciudades.Select(c => new CiudadDTO
            {
                IdCiudad = c.id_ciudad,
                NombreCiudad = c.nombre_ciudad,
                IdPais = c.id_pais
            }).ToList();
        }

        public CiudadDTO ObtenerPorId(int id)
        {
            var c = _context.tm_ciudades.FirstOrDefault(x => x.id_ciudad == id);
            if (c == null) return null;

            return new CiudadDTO
            {
                IdCiudad = c.id_ciudad,
                NombreCiudad = c.nombre_ciudad,
                IdPais = c.id_pais
            };
        }

        public void Crear(CiudadDTO dto)
        {
            var entidad = new tm_ciudade
            {
                nombre_ciudad = dto.NombreCiudad,
                id_pais = dto.IdPais
            };
            _context.tm_ciudades.InsertOnSubmit(entidad);
            _context.SubmitChanges();
        }

        public void Actualizar(CiudadDTO dto)
        {
            var c = _context.tm_ciudades.FirstOrDefault(x => x.id_ciudad == dto.IdCiudad);
            if (c != null)
            {
                c.nombre_ciudad = dto.NombreCiudad;
                c.id_pais = dto.IdPais;
                _context.SubmitChanges();
            }
        }

        public void Eliminar(int id)
        {
            var c = _context.tm_ciudades.FirstOrDefault(x => x.id_ciudad == id);
            if (c != null)
            {
                _context.tm_ciudades.DeleteOnSubmit(c);
                _context.SubmitChanges();
            }
        }
    }
}