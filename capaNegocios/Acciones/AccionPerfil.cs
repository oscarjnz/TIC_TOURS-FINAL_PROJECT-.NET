using System.Linq;
using capaDatos.Database;
using capaModelo.DTO;

namespace capaNegocios.Acciones
{
    public class AccionPerfil
    {
       DbLibraryEntityDataContext _context = new DbLibraryEntityDataContext();
        public void ActualizarDatos(UsuarioDTO dto)
        {
            var entidad = _context.tm_usuarios.FirstOrDefault(u => u.id_usuario == dto.IdUsuario);
            if (entidad != null)
            {
                entidad.nombre = dto.Nombre;
                entidad.apellido = dto.Apellido;
                entidad.telefono = dto.Telefono;
                entidad.direccion = dto.Direccion;
                entidad.nacionalidad = dto.Nacionalidad;
                entidad.genero = dto.Genero;
                entidad.updated_at = System.DateTime.Now;

                _context.SubmitChanges();
            }
        }
    }
}