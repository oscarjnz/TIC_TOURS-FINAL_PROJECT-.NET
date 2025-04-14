using System;
using System.Collections.Generic;
using capaDatos.Database;
using System.Linq;

namespace capaDatos.Funciones
{
    public class PaisDAL
    {
        private readonly DbLibraryEntityDataContext _context = new DbLibraryEntityDataContext();
        public List<tm_paise> ObtenerPaises()
        {
            
            return  _context.tm_paises.ToList();
           
        }
    }
}