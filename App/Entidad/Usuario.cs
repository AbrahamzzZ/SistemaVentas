using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public string Codigo { get; set; }
        public string NombreCompleto { get; set; }
        public string CorreoElectronico { get; set; }
        public string ClaveEncriptada { get; set; }
        public string Salt { get; set; }
        public string TokenRecuperacion { get; set; }
        public Rol oRol { get; set; }
        public bool Estado { get; set; }
    }
}
