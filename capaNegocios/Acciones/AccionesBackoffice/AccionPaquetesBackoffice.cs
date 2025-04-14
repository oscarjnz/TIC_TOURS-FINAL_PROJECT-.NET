using System;
using System.Collections.Generic;
using capaDatos.Database;
using capaModelo.DTO;
using System.Web.Mvc;
using System.Linq;

namespace capaNegocios.Acciones.AccionesBackoffice
{
    public class AccionPaquetesBackoffice
    {
        DbLibraryEntityDataContext _context = new DbLibraryEntityDataContext();
        public List<PaqueteDTO> ObtenerTodos()
{
    return _context.tm_paquetes.Select(p => new PaqueteDTO
    {
        IdPaquete = p.id_paquete,
        NombrePaquete = p.nombre_paquete,
        Descripcion = p.descripcion,
        DuracionDias = p.duracion_dias,
        PrecioBase = p.precio_base,
        foto = p.foto,
        TipoPaquete = p.tipo_paquete,
        Estado = p.estado,
        IdDestino = p.id_destino,
        CreatedAt = p.created_at,
        UpdatedAt = p.updated_at
    }).ToList();
}

public PaqueteDTO ObtenerPorId(int id)
{
    var p = _context.tm_paquetes.FirstOrDefault(x => x.id_paquete == id);
    if (p == null) return null;

    return new PaqueteDTO
    {
        IdPaquete = p.id_paquete,
        NombrePaquete = p.nombre_paquete,
        Descripcion = p.descripcion,
        DuracionDias = p.duracion_dias,
        PrecioBase = p.precio_base,
        foto = p.foto,
        TipoPaquete = p.tipo_paquete,
        Estado = p.estado,
        IdDestino = p.id_destino
    };
}

public void Crear(PaqueteDTO dto)
{
    var entidad = new tm_paquete
    {
        nombre_paquete = dto.NombrePaquete,
        descripcion = dto.Descripcion,
        duracion_dias = dto.DuracionDias,
        precio_base = dto.PrecioBase,
        tipo_paquete = dto.TipoPaquete,
        estado = dto.Estado,
        id_destino = dto.IdDestino,
        created_at = DateTime.Now,
        updated_at = DateTime.Now
    };

    _context.tm_paquetes.InsertOnSubmit(entidad);
    _context.SubmitChanges();
}

public void Actualizar(PaqueteDTO dto)
{
    var p = _context.tm_paquetes.FirstOrDefault(x => x.id_paquete == dto.IdPaquete);
    if (p != null)
    {
        p.nombre_paquete = dto.NombrePaquete;
        p.descripcion = dto.Descripcion;
        p.duracion_dias = dto.DuracionDias;
        p.precio_base = dto.PrecioBase;
        p.tipo_paquete = dto.TipoPaquete;
        p.estado = dto.Estado;
        p.id_destino = dto.IdDestino;
        p.updated_at = DateTime.Now;

        _context.SubmitChanges();
    }
}

public void Eliminar(int id)
{
    var p = _context.tm_paquetes.FirstOrDefault(x => x.id_paquete == id);
    if (p != null)
    {
        _context.tm_paquetes.DeleteOnSubmit(p);
        _context.SubmitChanges();
    }
}

    }
}