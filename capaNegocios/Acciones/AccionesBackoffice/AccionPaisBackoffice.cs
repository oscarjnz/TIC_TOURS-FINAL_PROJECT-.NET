using System;
using System.Collections.Generic;
using capaDatos.Database;
using capaModelo.DTO;
using System.Web.Mvc;
using System.Linq;

namespace capaNegocios.Acciones.AccionesBackoffice
{
    public class AccionPaisBackoffice
    {
        DbLibraryEntityDataContext _context = new DbLibraryEntityDataContext();

        public List<PaisDTO> ObtenerTodos() =>
            _context.tm_paises.Select(p => new PaisDTO
            {
                IdPais = p.id_pais,
                NombrePais = p.nombre_pais,
                CodigoIso = p.codigo_iso
            }).ToList();

        public PaisDTO ObtenerPorId(int id) =>
            _context.tm_paises.Where(p => p.id_pais == id).Select(p => new PaisDTO
            {
                IdPais = p.id_pais,
                NombrePais = p.nombre_pais,
                CodigoIso = p.codigo_iso
            }).FirstOrDefault();

        public void Crear(PaisDTO dto)
        {
            var entidad = new tm_paise
            {
                nombre_pais = dto.NombrePais,
                codigo_iso = dto.CodigoIso
            };
            _context.tm_paises.InsertOnSubmit(entidad);
            _context.SubmitChanges();
        }

        public void Actualizar(PaisDTO dto)
        {
            var p = _context.tm_paises.FirstOrDefault(x => x.id_pais == dto.IdPais);
            if (p != null)
            {
                p.nombre_pais = dto.NombrePais;
                p.codigo_iso = dto.CodigoIso;
                _context.SubmitChanges();
            }
        }

        public void Eliminar(int id)
        {
            var p = _context.tm_paises.FirstOrDefault(x => x.id_pais == id);
            if (p != null)
            {
                _context.tm_paises.DeleteOnSubmit(p);
                _context.SubmitChanges();
            }
        }
    }
}