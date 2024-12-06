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
    public class CD_Permiso
    {
        Conexion Conexion = new Conexion();

        //Metodo que muestra una lista de todos los Permisos que tienen cada Usuario
        public List<Permiso> PermisosUsuarios(int idusuario)
        {
            List<Permiso> listaPermiso = new List<Permiso>();
            try
            {
                StringBuilder permisos = new StringBuilder();
                permisos.AppendLine("SELECT p.ID_ROL, p.NOMBRE_MENU FROM PERMISO p");
                permisos.AppendLine("inner join ROL r on r.ID_ROL = p.ID_ROL");
                permisos.AppendLine("inner join USUARIO u on u.ID_ROL = r.ID_ROL");
                permisos.AppendLine("WHERE U.ID_USUARIO = @id_usuario");
                SqlCommand cmd = new SqlCommand(permisos.ToString(), Conexion.ConexionBD());
                cmd.Parameters.AddWithValue("@id_usuario", idusuario);
                cmd.CommandType = CommandType.Text;
                SqlDataReader leer = cmd.ExecuteReader();
                while (leer.Read())
                {
                    listaPermiso.Add(new Permiso()
                    {
                        oRol = new Rol() { IdRol = Convert.ToInt32(leer["ID_ROL"]) },
                        NombreMenu = leer["NOMBRE_MENU"].ToString(),
                    });
                }
            }
            catch (Exception pe)
            {
                Console.WriteLine($"Error al mostrar permisos: {pe.Message}");
                throw;
            }
            return listaPermiso;
        }
    }
}
