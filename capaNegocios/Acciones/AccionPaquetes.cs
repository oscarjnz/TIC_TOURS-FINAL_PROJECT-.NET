using System;
using System.Collections.Generic;
using System.Linq;
using capaDatos.Funciones;
using capaModelo.DTO;

namespace capaNegocios.Acciones
{
    public class AccionPaquetes
    {
            private readonly PaqueteDAL _paqueteDAL = new PaqueteDAL();
            
            public List<PaqueteDTO> ObtenerPaquetes()
            {
                var paquetes = _paqueteDAL.ObtenerPaquetesActivos();

                return paquetes.Select(p => new PaqueteDTO()
                {
                    IdPaquete = p.id_paquete,
                    NombrePaquete = p.nombre_paquete,
                    foto = p.foto,
                    Descripcion = p.descripcion,
                    DuracionDias = p.duracion_dias,
                    PrecioBase = p.precio_base,  
                    IdDestino = p.id_destino ,
                    TipoPaquete = p.tipo_paquete,
                    Estado = p.estado,
                    CreatedAt = p.created_at ,
                    UpdatedAt = p.updated_at 
                }).ToList();
            } 
            public PaqueteDTO ObtenerPaquetePorId(int id)
            {
                var entidad = _paqueteDAL.ObtenerPaquetePorId(id);
                if (entidad == null) return null;

                return new PaqueteDTO
                {
                    IdPaquete = entidad.id_paquete,
                    NombrePaquete = entidad.nombre_paquete,
                    Descripcion = entidad.descripcion,
                    foto = entidad.foto,
                    DuracionDias = entidad.duracion_dias,
                    PrecioBase = entidad.precio_base,
                    IdDestino = entidad.id_destino,
                    TipoPaquete = entidad.tipo_paquete,
                    Estado = entidad.estado,
                    CreatedAt = entidad.created_at,
                    UpdatedAt = entidad.updated_at
                };
            }

    }
}