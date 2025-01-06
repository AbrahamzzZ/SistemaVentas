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

        private static Usuario_Catched _intance;

        public static Usuario_Catched GetInstance()
        {
            if (_intance == null)
            {
                _intance = new Usuario_Catched();
            }
            return _intance;
        }
    }
}
