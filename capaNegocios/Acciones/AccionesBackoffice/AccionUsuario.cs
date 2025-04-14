using System;
using System.Collections.Generic;
using capaDatos.Database;
using capaModelo.DTO;
using System.Web.Mvc;
using System.Linq;


namespace capaNegocios.Acciones.AccionesBackoffice
{
    
    public class AccionUsuario
    {
        private readonly DbLibraryEntityDataContext _context = new DbLibraryEntityDataContext();

        public List<UsuarioDTO> ObtenerClientes(string buscar = "")
        {
            var query = _context.tm_usuarios
                .Where(u => u.id_rol == 3); 

            if (!string.IsNullOrWhiteSpace(buscar))
            {
                query = query.Where(u =>
                    u.nombre.Contains(buscar) ||
                    u.apellido.Contains(buscar) ||
                    u.correo_electronico.Contains(buscar) ||
                    u.numero_documento.Contains(buscar));
            }

            return query
                .Select(u => new UsuarioDTO
                {
                    IdUsuario = u.id_usuario,
                    Nombre = u.nombre,
                    Apellido = u.apellido,
                    CorreoElectronico = u.correo_electronico,
                    EstadoCuenta = u.estado_cuenta,
                    FechaRegistro = u.fecha_registro
                }).ToList();
        }

        public UsuarioDTO ObtenerPorId(int id)
        {
            var u = _context.tm_usuarios.FirstOrDefault(x => x.id_usuario == id);
            if (u == null) return null;

            return new UsuarioDTO
            {
                IdUsuario = u.id_usuario,
                Nombre = u.nombre,
                Apellido = u.apellido,
                CorreoElectronico = u.correo_electronico,
                EstadoCuenta = u.estado_cuenta,
                Telefono = u.telefono,
                Direccion = u.direccion,
                Nacionalidad = u.nacionalidad,
                NumeroDocumento = u.numero_documento,
                FechaNacimiento = u.fecha_nacimiento
            };
        }

        public void CambiarEstado(int id, string estado)
        {
            var usuario = _context.tm_usuarios.FirstOrDefault(u => u.id_usuario == id);
            if (usuario != null)
            {
                usuario.estado_cuenta = estado;
                usuario.updated_at = DateTime.Now;
                _context.SubmitChanges();
            }
        }

        public List<UsuarioDTO> ObtenerTodos()
        {
            return _context.tm_usuarios.Select(u => new UsuarioDTO
            {
                IdUsuario = u.id_usuario,
                Nombre = u.nombre,
                Apellido = u.apellido,
                CorreoElectronico = u.correo_electronico,
                IdRol = u.id_rol,
                EstadoCuenta = u.estado_cuenta
            }).ToList();
        }

        public void RegistrarInterno(UsuarioDTO dto)
        {
            var usuario = new tm_usuario
            {
                nombre = dto.Nombre,
                apellido = dto.Apellido,
                correo_electronico = dto.CorreoElectronico,
                contrasena = dto.Contrasena,
                id_rol = dto.IdRol,
                estado_cuenta = "activo",
                fecha_registro = DateTime.Now,
                created_at = DateTime.Now,
                updated_at = DateTime.Now
            };
            _context.tm_usuarios.InsertOnSubmit(usuario);
            _context.SubmitChanges();
        }

        public void CambiarEstado(int id)
        {
            var usuario = _context.tm_usuarios.FirstOrDefault(x => x.id_usuario == id);
            if (usuario != null)
            {
                usuario.estado_cuenta = usuario.estado_cuenta == "activo" ? "suspendido" : "activo";
                usuario.updated_at = DateTime.Now;
                _context.SubmitChanges();
            }
        }
        public void Actualizar(UsuarioDTO dto)
        {
            var usuario = _context.tm_usuarios.FirstOrDefault(x => x.id_usuario == dto.IdUsuario);
            if (usuario != null)
            {
                usuario.nombre = dto.Nombre;
                usuario.apellido = dto.Apellido;
                usuario.correo_electronico = dto.CorreoElectronico;

              if (!string.IsNullOrEmpty(dto.Contrasena))
                {
                    usuario.contrasena = dto.Contrasena;
                }

                usuario.id_rol = dto.IdRol;
                usuario.updated_at = DateTime.Now;

                _context.SubmitChanges();
            }
        }


    }
}