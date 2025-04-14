using capaDatos.Database;
using System.Linq;

namespace capaDatos.Funciones
{
    public class UsuarioDAL
    {
        private readonly DbLibraryEntityDataContext _context;
        

        public UsuarioDAL()
        {
            _context = new DbLibraryEntityDataContext();
        }

        public void RegistrarUsuario(tm_usuario entidad)
        {
            _context.tm_usuarios.InsertOnSubmit(entidad);
            _context.SubmitChanges();
        }
        public tm_usuario Autenticar(string correo, string contrasena)
        {
            return _context.tm_usuarios
                .FirstOrDefault(u => u.correo_electronico == correo && u.contrasena == contrasena && u.estado_cuenta == "activo");
        }
        
        
    }
}