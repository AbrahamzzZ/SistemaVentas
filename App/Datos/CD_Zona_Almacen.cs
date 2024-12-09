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
    public class CD_Zona_Almacen
    {
        Conexion Conexion = new Conexion();

        //Metodo que muestra una lista de todos las Zonas de almacenamiento que tiene el supermercado
        public List<Zona_Almacen> MostrarZonasAlmacen()
        {
            List<Zona_Almacen> listaMostrarZonaAlmacen = new List<Zona_Almacen>();
            try
            {
                StringBuilder mostrar = new StringBuilder();
                mostrar.AppendLine("SELECT ID_ZONA, NOMBRE_ZONA , LIMITE_ESPACIOS, ESTADO FROM ZONA_ALMACEN");
                SqlCommand cmd = new SqlCommand(mostrar.ToString(), Conexion.ConexionBD());
                cmd.CommandType = CommandType.Text;
                SqlDataReader leer = cmd.ExecuteReader();
                while (leer.Read())
                {
                    listaMostrarZonaAlmacen.Add(new Zona_Almacen()
                    {
                        IdZona = Convert.ToInt32(leer["ID_ZONA"]),
                        NombreZona = leer["NOMBRE_ZONA"].ToString(),
                        LimiteEspacios = Convert.ToInt32(leer["LIMITE_ESPACIOS"].ToString()),
                        Estado = Convert.ToBoolean(leer["ESTADO"]),
                    });
                }
            }
            catch (Exception us)
            {
                Console.WriteLine($"Error al mostrar zonas de almacen: {us.Message}");
                throw;
            }
            return listaMostrarZonaAlmacen;
        }
    }
}
