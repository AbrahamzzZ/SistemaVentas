using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class Usuario_Catched : Usuario
    {
        private Usuario_Catched() { }
      
        private static Usuario_Catched _instance;

        /// <summary> 
        /// Patrón de diseño Singleton 
        /// </summary> 
        /// <returns>Instancia única de Usuario_Catched</returns>
        public static Usuario_Catched GetInstance()
        {
            if (_instance == null)
            {
                _instance = new Usuario_Catched();
            }
            return _instance;
        }
    }
}
