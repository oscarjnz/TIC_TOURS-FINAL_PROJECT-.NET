using System;
using capaDatos.Database;
using capaDatos.Funciones;
using capaModelo.DTO;

namespace capaNegocios.Acciones
{
    public class AccionRegistrar
    {
        public class UsuarioBL
        {
            private readonly UsuarioDAL _usuarioDAL = new UsuarioDAL();

            public string Registrar(UsuarioDTO dto)
            {

                var entidad = new tm_usuario
                {
                    nombre = dto.Nombre,
                    apellido = dto.Apellido,
                    genero = dto.Genero,
                    fecha_nacimiento = dto.FechaNacimiento,
                    nacionalidad = dto.Nacionalidad,
                    tipo_documento = dto.TipoDocumento,
                    numero_documento = dto.NumeroDocumento,
                    correo_electronico = dto.CorreoElectronico,
                    contrasena = dto.Contrasena,
                    telefono = dto.Telefono,
                    direccion = dto.Direccion,
                    id_rol = dto.IdRol,
                    estado_cuenta = string.IsNullOrEmpty(dto.EstadoCuenta) ? "activo" : dto.EstadoCuenta,
                    fecha_registro = DateTime.Now,
                    created_at = DateTime.Now,
                    updated_at = DateTime.Now
                };

                _usuarioDAL.RegistrarUsuario(entidad);
                return "Registro exitoso";
            }

            public UsuarioDTO Login(string correo, string contrasena)
            {
                var entidad = _usuarioDAL.Autenticar(correo, contrasena);
                if (entidad == null) return null;

                return new UsuarioDTO
                {
                    IdUsuario = entidad.id_usuario,
                    Nombre = entidad.nombre,
                    Apellido = entidad.apellido,
                    Genero = entidad.genero,
                    FechaNacimiento = entidad.fecha_nacimiento,
                    Nacionalidad = entidad.nacionalidad,
                    TipoDocumento = entidad.tipo_documento,
                    NumeroDocumento = entidad.numero_documento,
                    CorreoElectronico = entidad.correo_electronico,
                    Contrasena = entidad.contrasena,
                    Telefono = entidad.telefono,
                    Direccion = entidad.direccion,
                    IdRol = entidad.id_rol ?? 2,
                    EstadoCuenta = entidad.estado_cuenta,
                    FechaRegistro = entidad.fecha_registro ,
                    CreatedAt = entidad.created_at ,
                    UpdatedAt = entidad.updated_at
                };
            }
        }
    }
}

    
