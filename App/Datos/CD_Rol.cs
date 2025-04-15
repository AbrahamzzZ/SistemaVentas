using Entidad;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class CD_Rol
    {
        private readonly Conexion Conexion = new Conexion();

        /// <summary>
        /// Método que muestra una lista de todos los Roles que existen
        /// </summary>
        /// <returns>Una lista de objetos de tipo Rol</returns>
        public List<Rol> RolesUsuarios()
        {
            List<Rol> listaRoles = new List<Rol>();
            try
            {
                StringBuilder rol = new StringBuilder();
                rol.AppendLine("SELECT ID_ROL, DESCRIPCION FROM ROL");
                SqlCommand cmd = new SqlCommand(rol.ToString(), Conexion.ConexionBD());
                cmd.CommandType = CommandType.Text;
                SqlDataReader leer = cmd.ExecuteReader();
                while (leer.Read())
                {
                    listaRoles.Add(new Rol()
                    {
                        IdRol = Convert.ToInt32(leer["ID_ROL"]),
                        Descripcion = leer["DESCRIPCION"].ToString(),
                    }); ;
                }
            }
            catch (Exception ro)
            {
                Console.WriteLine($"Error al mostrar roles: {ro.Message}");
                throw;
            }
            return listaRoles;
        }
    }
}
