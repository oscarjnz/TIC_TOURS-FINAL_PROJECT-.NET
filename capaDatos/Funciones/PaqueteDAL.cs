using System.Collections.Generic;
using capaDatos.Database;
using System.Linq;


namespace capaDatos.Funciones
{
    public class PaqueteDAL
    {
        private readonly DbLibraryEntityDataContext _context;

        public PaqueteDAL()
        {
            _context = new DbLibraryEntityDataContext();
        }

        public List<tm_paquete> ObtenerPaquetesActivos()
        {
            return _context.tm_paquetes
                .Where(p => p.estado == "activo")
                .ToList();
        }
        public tm_paquete ObtenerPaquetePorId(int id)
        {
            return _context.tm_paquetes.FirstOrDefault(p => p.id_paquete == id && p.estado == "activo");
        }

    }
}