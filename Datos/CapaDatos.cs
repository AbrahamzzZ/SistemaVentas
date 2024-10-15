using System;
using Entidad;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class CapaDatos
    {
        public SqlConnection ConexioBDD()
        {
            SqlConnection cn = new SqlConnection("server= DESKTOP-8CQM9OG\\SQLSEXPRESS ; database= Sistema_Ventas ; integrated security=true;");//Conexion BD
            cn.Open();
            return cn;
        }
        //Usuario
        public List<Usuario> ingresarUsuario()
        {
            List<Usuario> listaUsuario = new List<Usuario>();
            try
            {
                string registrar = "SELECT ID_USUARIO, DOCUMENTO, NOMBRE_COMPLETO, CORREO_ELECTRONICO, CLAVE, ESTADO FROM USUARIO";
                SqlCommand cmd = new SqlCommand(registrar, ConexioBDD());
                cmd.CommandType = CommandType.Text;
                SqlDataReader leer = cmd.ExecuteReader();
                while (leer.Read())
                {
                    listaUsuario.Add(new Usuario()
                    {
                        IdUsuario = Convert.ToInt32(leer["ID_USUARIO"]),
                        Documento = leer["DOCUMENTO"].ToString(),
                        NombreCompleto = leer["NOMBRE_COMPLETO"].ToString(),
                        CorreoElectronico = leer["CORREO_ELECTRONICO"].ToString(),
                        Clave = leer["CLAVE"].ToString(),
                        Estado = Convert.ToBoolean(leer["ESTADO"])
                    });
                }
            }
            catch (Exception us)
            {
                listaUsuario = new List<Usuario>();
            }
            return listaUsuario;
        }
        public Usuario recuperarContrasena(string correoElectronico)
        {
            Usuario usuario = null;
            try
            {
                string consulta = "SELECT CLAVE FROM USUARIO WHERE CORREO_ELECTRONICO = @correoElectronico";
                SqlCommand cmd = new SqlCommand(consulta, ConexioBDD());
                cmd.Parameters.AddWithValue("@correoElectronico", correoElectronico);
                cmd.CommandType = CommandType.Text;
                SqlDataReader leer = cmd.ExecuteReader();

                if (leer.Read())
                {
                    usuario = new Usuario()
                    {
                        Clave = leer["CLAVE"].ToString()
                    };
                }
            }
            catch (Exception us)
            {

            }
            return usuario;
        }
        public List<Usuario> mostrarUsuario()
        {
            List<Usuario> listaMostrarUsuario = new List<Usuario>();
            try
            {
                StringBuilder mostrar = new StringBuilder();
                mostrar.AppendLine("SELECT u.ID_USUARIO, u.DOCUMENTO, u.NOMBRE_COMPLETO, u.CORREO_ELECTRONICO, u.CLAVE, u.ESTADO, r.ID_ROL, r.DESCRIPCION FROM USUARIO u");
                mostrar.AppendLine("inner join ROL r on r.ID_ROL = u.ID_ROL");
                SqlCommand cmd = new SqlCommand(mostrar.ToString(), ConexioBDD());
                cmd.CommandType = CommandType.Text;
                SqlDataReader leer = cmd.ExecuteReader();
                while (leer.Read())
                {
                    listaMostrarUsuario.Add(new Usuario()
                    {
                        IdUsuario = Convert.ToInt32(leer["ID_USUARIO"]),
                        Documento = leer["DOCUMENTO"].ToString(),
                        NombreCompleto = leer["NOMBRE_COMPLETO"].ToString(),
                        CorreoElectronico = leer["CORREO_ELECTRONICO"].ToString(),
                        Clave = leer["CLAVE"].ToString(),
                        Estado = Convert.ToBoolean(leer["ESTADO"]),
                        oRol = new Rol() { IdRol = Convert.ToInt32(leer["ID_ROL"]), Descripcion = leer["DESCRIPCION"].ToString() },
                    });
                }
            }
            catch (Exception us)
            {
                listaMostrarUsuario = new List<Usuario>();
            }
            return listaMostrarUsuario;
        }
        public int registrarUsuario(Usuario obj, out string mensaje)
        {
            int idUsuarioGenerado = 0;
            mensaje = string.Empty;
            try
            {
                SqlCommand cmd = new SqlCommand("PA_REGISTRAR_USUARIO", ConexioBDD());
                cmd.Parameters.AddWithValue("Documento", obj.Documento);
                cmd.Parameters.AddWithValue("Nombre_Completo", obj.NombreCompleto);
                cmd.Parameters.AddWithValue("Correo_Electronico", obj.CorreoElectronico);
                cmd.Parameters.AddWithValue("Clave", obj.Clave);
                cmd.Parameters.AddWithValue("Id_Rol", obj.oRol.IdRol);
                cmd.Parameters.AddWithValue("Estado", obj.Estado);
                cmd.Parameters.Add("Id_Usuario_Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();

                idUsuarioGenerado = Convert.ToInt32(cmd.Parameters["Id_Usuario_Resultado"].Value);
                mensaje = cmd.Parameters["Mensaje"].Value.ToString();
            }
            catch (Exception us)
            {
                idUsuarioGenerado = 0;
                mensaje = us.Message;

            }
            return idUsuarioGenerado;
        }
        public bool editarUsuario(Usuario obj, out string mensaje)
        {
            bool respuesta = false;
            mensaje = string.Empty;
            try
            {

                SqlCommand cmd = new SqlCommand("PA_EDITAR_USUARIO", ConexioBDD());
                cmd.Parameters.AddWithValue("Id_Usuario", obj.IdUsuario);
                cmd.Parameters.AddWithValue("Documento", obj.Documento);
                cmd.Parameters.AddWithValue("Nombre_Completo", obj.NombreCompleto);
                cmd.Parameters.AddWithValue("Correo_Electronico", obj.CorreoElectronico);
                cmd.Parameters.AddWithValue("Clave", obj.Clave);
                cmd.Parameters.AddWithValue("Id_Rol", obj.oRol.IdRol);
                cmd.Parameters.AddWithValue("Estado", obj.Estado);
                cmd.Parameters.Add("Respuesta", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();

                respuesta = Convert.ToBoolean(cmd.Parameters["Respuesta"].Value);
                mensaje = cmd.Parameters["Mensaje"].Value.ToString();
            }
            catch (Exception us)
            {
                respuesta = false;
                mensaje = us.Message;

            }
            return respuesta;
        }
        public bool eliminarUsuario(Usuario obj, out string mensaje)
        {
            bool respuesta = false;
            mensaje = string.Empty;
            try
            {

                SqlCommand cmd = new SqlCommand("PA_ELIMINAR_USUARIO", ConexioBDD());
                cmd.Parameters.AddWithValue("Id_Usuario", obj.IdUsuario);
                cmd.Parameters.Add("Respuesta", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();

                respuesta = Convert.ToBoolean(cmd.Parameters["Respuesta"].Value);
                mensaje = cmd.Parameters["Mensaje"].Value.ToString();
            }
            catch (Exception us)
            {
                respuesta = false;
                mensaje = us.Message;

            }
            return respuesta;
        }
        //Permiso
        public List<Permiso> permisosMenu(int idusuario)
        {
            List<Permiso> listaPermiso = new List<Permiso>();
            try
            {
                StringBuilder permisos = new StringBuilder();
                permisos.AppendLine("SELECT p.ID_ROL, p.NOMBRE_MENU FROM PERMISO p");
                permisos.AppendLine("inner join ROL r on r.ID_ROL = p.ID_ROL");
                permisos.AppendLine("inner join USUARIO u on u.ID_ROL = r.ID_ROL");
                permisos.AppendLine("WHERE U.ID_USUARIO = @id_usuario");
                SqlCommand cmd = new SqlCommand(permisos.ToString(), ConexioBDD());
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
                listaPermiso = new List<Permiso>();
            }
            return listaPermiso;
        }
        //Rol
        public List<Rol> listarRol()
        {
            List<Rol> listaRoles = new List<Rol>();
            try
            {
                StringBuilder rol = new StringBuilder();
                rol.AppendLine("SELECT ID_ROL, DESCRIPCION FROM ROL");
                SqlCommand cmd = new SqlCommand(rol.ToString(), ConexioBDD());
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
                listaRoles = new List<Rol>();
            }
            return listaRoles;
        }
        //Categoria
        public List<Categoria> mostrarCategoria()
        {
            List<Categoria> listaMostrarCategoria = new List<Categoria>();
            try
            {
                StringBuilder mostrar = new StringBuilder();
                mostrar.AppendLine("SELECT ID_CATEGORIA, DESCRIPCION, ESTADO FROM CATEGORIA");
                SqlCommand cmd = new SqlCommand(mostrar.ToString(), ConexioBDD());
                cmd.CommandType = CommandType.Text;
                SqlDataReader leer = cmd.ExecuteReader();
                while (leer.Read())
                {
                    listaMostrarCategoria.Add(new Categoria()
                    {
                        IdCategoria = Convert.ToInt32(leer["ID_CATEGORIA"]),
                        Descripcion = leer["DESCRIPCION"].ToString(),
                        Estado = Convert.ToBoolean(leer["ESTADO"])
                    });
                }
            }
            catch (Exception ca)
            {
                listaMostrarCategoria = new List<Categoria>();
            }
            return listaMostrarCategoria;
        }
        public int registrarCategoria(Categoria obj, out string mensaje)
        {
            int idCategoriaGenerado = 0;
            mensaje = string.Empty;
            try
            {
                SqlCommand cmd = new SqlCommand("PA_REGISTRAR_CATEGORIA", ConexioBDD());
                cmd.Parameters.AddWithValue("Descripcion", obj.Descripcion);
                cmd.Parameters.AddWithValue("Estado", obj.Estado);
                cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();

                idCategoriaGenerado = Convert.ToInt32(cmd.Parameters["Resultado"].Value);
                mensaje = cmd.Parameters["Mensaje"].Value.ToString();
            }
            catch (Exception ca)
            {
                idCategoriaGenerado = 0;
                mensaje = ca.Message;

            }
            return idCategoriaGenerado;
        }
        public bool editarCategoria(Categoria obj, out string mensaje)
        {
            bool respuesta = false;
            mensaje = string.Empty;
            try
            {
                SqlCommand cmd = new SqlCommand("PA_EDITAR_CATEGORIA", ConexioBDD());
                cmd.Parameters.AddWithValue("Id_Categoria", obj.IdCategoria);
                cmd.Parameters.AddWithValue("Descripcion", obj.Descripcion);
                cmd.Parameters.AddWithValue("Estado", obj.Estado);
                cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();

                respuesta = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);
                mensaje = cmd.Parameters["Mensaje"].Value.ToString();
            }
            catch (Exception ca)
            {
                respuesta = false;
                mensaje = ca.Message;

            }
            return respuesta;
        }
        public bool eliminarCategoria(Categoria obj, out string mensaje)
        {
            bool respuesta = false;
            mensaje = string.Empty;
            try
            {
                SqlCommand cmd = new SqlCommand("PA_ELIMINAR_CATEGORIA", ConexioBDD());
                cmd.Parameters.AddWithValue("Id_Categoria", obj.IdCategoria);
                cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();

                respuesta = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);
                mensaje = cmd.Parameters["Mensaje"].Value.ToString();
            }
            catch (Exception ca)
            {
                respuesta = false;
                mensaje = ca.Message;

            }
            return respuesta;
        }
        //Producto
        public List<Producto> mostrarProducto()
        {
            List<Producto> listaMostrarProducto = new List<Producto>();
            try
            {
                StringBuilder mostrar = new StringBuilder();
                mostrar.AppendLine("SELECT ID_PRODUCTO, CODIGO, NOMBRE_PRODUCTO, p.DESCRIPCION, c.ID_CATEGORIA, c.DESCRIPCION[DESCRIPCION_CATEGORIA], u.ID_UNIDAD_MEDIDA, u.DESCRIPCION[DESCRIPCION_UNIDAD_MEDIDA], PAIS_ORIGEN, STOCK, PRECIO_COMPRA, PRECIO_VENTA, p.ESTADO FROM PRODUCTO P");
                mostrar.AppendLine("inner join CATEGORIA c on c.ID_CATEGORIA = p.ID_CATEGORIA");
                mostrar.AppendLine("inner join UNIDAD_MEDIDA u on u.ID_UNIDAD_MEDIDA = p.ID_UNIDAD_MEDIDA");
                SqlCommand cmd = new SqlCommand(mostrar.ToString(), ConexioBDD());
                cmd.CommandType = CommandType.Text;
                SqlDataReader leer = cmd.ExecuteReader();
                while (leer.Read())
                {
                    listaMostrarProducto.Add(new Producto()
                    {
                        IdProducto = Convert.ToInt32(leer["ID_PRODUCTO"]),
                        Codigo = leer["CODIGO"].ToString(),
                        Nombre = leer["NOMBRE_PRODUCTO"].ToString(),
                        Descripcion = leer["DESCRIPCION"].ToString(),
                        oCategoria = new Categoria() { IdCategoria = Convert.ToInt32(leer["ID_CATEGORIA"]), Descripcion = leer["DESCRIPCION_CATEGORIA"].ToString() },
                        oUnidadMedida = new Unidad_Medida() { IdUnidadMedida = Convert.ToInt32(leer["ID_UNIDAD_MEDIDA"]), Descripcion = leer["DESCRIPCION_UNIDAD_MEDIDA"].ToString() },
                        PaisOrigen = leer["PAIS_ORIGEN"].ToString(),
                        Stock = Convert.ToInt32(leer["STOCK"]),
                        PrecioCompra = Convert.ToDecimal(leer["PRECIO_COMPRA"]),
                        PrecioVenta = Convert.ToDecimal(leer["PRECIO_VENTA"]),
                        Estado = Convert.ToBoolean(leer["ESTADO"])
                    });
                }
            }
            catch (Exception pr)
            {
                listaMostrarProducto = new List<Producto>();
            }
            return listaMostrarProducto;
        }
        public int registrarProducto(Producto obj, out string mensaje)
        {
            int idProductoGenerado = 0;
            mensaje = string.Empty;
            try
            {
                SqlCommand cmd = new SqlCommand("PA_REGISTRAR_PRODUCTO", ConexioBDD());
                cmd.Parameters.AddWithValue("Codigo", obj.Codigo);
                cmd.Parameters.AddWithValue("Nombre_Producto", obj.Nombre);
                cmd.Parameters.AddWithValue("Descripcion", obj.Descripcion);
                cmd.Parameters.AddWithValue("Id_Categoria", obj.oCategoria.IdCategoria);
                cmd.Parameters.AddWithValue("Id_Unidad_Medida", obj.oUnidadMedida.IdUnidadMedida);
                cmd.Parameters.AddWithValue("Pais_Origen", obj.PaisOrigen);
                cmd.Parameters.AddWithValue("Estado", obj.Estado);
                cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();

                idProductoGenerado = Convert.ToInt32(cmd.Parameters["Resultado"].Value);
                mensaje = cmd.Parameters["Mensaje"].Value.ToString();
            }
            catch (Exception pr)
            {
                idProductoGenerado = 0;
                mensaje = pr.Message;

            }
            return idProductoGenerado;
        }
        public bool editarProducto(Producto obj, out string mensaje)
        {
            bool respuesta = false;
            mensaje = string.Empty;
            try
            {
                SqlCommand cmd = new SqlCommand("PA_EDITAR_PRODUCTO", ConexioBDD());
                cmd.Parameters.AddWithValue("Id_Producto", obj.IdProducto);
                cmd.Parameters.AddWithValue("Codigo", obj.Codigo);
                cmd.Parameters.AddWithValue("Nombre_Producto", obj.Nombre);
                cmd.Parameters.AddWithValue("Descripcion", obj.Descripcion);
                cmd.Parameters.AddWithValue("Id_Categoria", obj.oCategoria.IdCategoria);
                cmd.Parameters.AddWithValue("Id_Unidad_Medida", obj.oUnidadMedida.IdUnidadMedida);
                cmd.Parameters.AddWithValue("Pais_Origen", obj.PaisOrigen);
                cmd.Parameters.AddWithValue("Estado", obj.Estado);
                cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();

                respuesta = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);
                mensaje = cmd.Parameters["Mensaje"].Value.ToString();
            }
            catch (Exception pr)
            {
                respuesta = false;
                mensaje = pr.Message;

            }
            return respuesta;
        }
        public bool eliminarProducto(Producto obj, out string mensaje)
        {
            bool respuesta = false;
            mensaje = string.Empty;
            try
            {
                SqlCommand cmd = new SqlCommand("PA_ELIMINAR_PRODUCTO", ConexioBDD());
                cmd.Parameters.AddWithValue("Id_Producto", obj.IdProducto);
                cmd.Parameters.Add("Respuesta", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();

                respuesta = Convert.ToBoolean(cmd.Parameters["Respuesta"].Value);
                mensaje = cmd.Parameters["Mensaje"].Value.ToString();
            }
            catch (Exception pr)
            {
                respuesta = false;
                mensaje = pr.Message;

            }
            return respuesta;
        }
        //Unidad Medida
        public List<Unidad_Medida> mostrarUnidadesMedidas()
        {
            List<Unidad_Medida> listaMostrarUnidadesMedidas = new List<Unidad_Medida>();
            try
            {
                StringBuilder mostrar = new StringBuilder();
                mostrar.AppendLine("SELECT ID_UNIDAD_MEDIDA, DESCRIPCION, SIMBOLO, ESTADO FROM UNIDAD_MEDIDA");
                SqlCommand cmd = new SqlCommand(mostrar.ToString(), ConexioBDD());
                cmd.CommandType = CommandType.Text;
                SqlDataReader leer = cmd.ExecuteReader();
                while (leer.Read())
                {
                    listaMostrarUnidadesMedidas.Add(new Unidad_Medida()
                    {
                        IdUnidadMedida = Convert.ToInt32(leer["ID_UNIDAD_MEDIDA"]),
                        Descripcion = leer["DESCRIPCION"].ToString(),
                        Simbolo = leer["SIMBOLO"].ToString(),
                        Estado = Convert.ToBoolean(leer["ESTADO"])
                    });
                }
            }
            catch (Exception ca)
            {
                listaMostrarUnidadesMedidas = new List<Unidad_Medida>();
            }
            return listaMostrarUnidadesMedidas;
        }
        public int registrarUnidadMedida(Unidad_Medida obj, out string mensaje)
        {
            int idUnidadMedidaGenerada = 0;
            mensaje = string.Empty;
            try
            {
                SqlCommand cmd = new SqlCommand("PA_REGISTRAR_UNIDAD_MEDIDA", ConexioBDD());
                cmd.Parameters.AddWithValue("Descripcion", obj.Descripcion);
                cmd.Parameters.AddWithValue("Simbolo", obj.Simbolo);
                cmd.Parameters.AddWithValue("Estado", obj.Estado);
                cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();

                idUnidadMedidaGenerada = Convert.ToInt32(cmd.Parameters["Resultado"].Value);
                mensaje = cmd.Parameters["Mensaje"].Value.ToString();
            }
            catch (Exception ca)
            {
                idUnidadMedidaGenerada = 0;
                mensaje = ca.Message;

            }
            return idUnidadMedidaGenerada;
        }
        public bool editarUnidadMedida(Unidad_Medida obj, out string mensaje)
        {
            bool respuesta = false;
            mensaje = string.Empty;
            try
            {
                SqlCommand cmd = new SqlCommand("PA_EDITAR_UNIDAD_MEDIDA", ConexioBDD());
                cmd.Parameters.AddWithValue("Id_Unidad_Medida", obj.IdUnidadMedida);
                cmd.Parameters.AddWithValue("Descripcion", obj.Descripcion);
                cmd.Parameters.AddWithValue("Simbolo", obj.Simbolo);
                cmd.Parameters.AddWithValue("Estado", obj.Estado);
                cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();

                respuesta = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);
                mensaje = cmd.Parameters["Mensaje"].Value.ToString();
            }
            catch (Exception ca)
            {
                respuesta = false;
                mensaje = ca.Message;

            }
            return respuesta;
        }
        public bool eliminarUnidadMedida(Unidad_Medida obj, out string mensaje)
        {
            bool respuesta = false;
            mensaje = string.Empty;
            try
            {
                SqlCommand cmd = new SqlCommand("PA_ELIMINAR_UNIDAD_MEDIDA", ConexioBDD());
                cmd.Parameters.AddWithValue("Id_Unidad_Medida", obj.IdUnidadMedida);
                cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();

                respuesta = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);
                mensaje = cmd.Parameters["Mensaje"].Value.ToString();
            }
            catch (Exception ca)
            {
                respuesta = false;
                mensaje = ca.Message;

            }
            return respuesta;
        }
        //Inventario
        public List<Inventario> mostrarInventario()
        {
            List<Inventario> listaMostrarProductoInventario = new List<Inventario>();
            try
            {
                StringBuilder mostrar = new StringBuilder();
                mostrar.AppendLine("SELECT i.ID_INVENTARIO,p.ID_PRODUCTO,p.CODIGO AS CODIGO_PRODUCTO, p.NOMBRE_PRODUCTO AS NOMBRE_PRODUCTO, i.CANTIDAD, i.UBICACION_ALMACEN, p.ESTADO, i.FECHA_INGRESO FROM INVENTARIO i");
                mostrar.AppendLine("INNER JOIN PRODUCTO p ON p.ID_PRODUCTO = i.ID_PRODUCTO");
                SqlCommand cmd = new SqlCommand(mostrar.ToString(), ConexioBDD());
                cmd.CommandType = CommandType.Text;
                SqlDataReader leer = cmd.ExecuteReader();
                while (leer.Read())
                {
                    listaMostrarProductoInventario.Add(new Inventario()
                    {
                        IdInventario = Convert.ToInt32(leer["ID_INVENTARIO"]),
                        oProducto = new Producto() { IdProducto = Convert.ToInt32(leer["ID_PRODUCTO"]), Codigo = leer["CODIGO_PRODUCTO"].ToString(), Nombre = leer["NOMBRE_PRODUCTO"].ToString() },
                        Cantidad = Convert.ToInt32(leer["CANTIDAD"]),
                        UbicacionAlmacen = leer["UBICACION_ALMACEN"].ToString(),
                        Estado = Convert.ToBoolean(leer["ESTADO"])
                    });
                }
            }
            catch (Exception inv)
            {
                listaMostrarProductoInventario = new List<Inventario>();
            }
            return listaMostrarProductoInventario;
        }
        public int agregarProductoInventario(Inventario obj, out string mensaje)
        {
            int idInventarioGenerado = 0;
            mensaje = string.Empty;
            try
            {
                SqlCommand cmd = new SqlCommand("PA_REGISTRAR_PRODUCTO_INVENTARIO", ConexioBDD());
                cmd.Parameters.AddWithValue("ID_PRODUCTO", obj.oProducto.IdProducto);
                cmd.Parameters.AddWithValue("CODIGO_PRODUCTO", obj.oProducto.Codigo);
                cmd.Parameters.AddWithValue("NOMBRE_PRODUCTO", obj.oProducto.Nombre);
                cmd.Parameters.AddWithValue("CANTIDAD", obj.Cantidad);
                cmd.Parameters.AddWithValue("UBICACION_ALMACEN", obj.UbicacionAlmacen);
                cmd.Parameters.AddWithValue("ESTADO", obj.Estado);
                cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();

                idInventarioGenerado = Convert.ToInt32(cmd.Parameters["Resultado"].Value);
                mensaje = cmd.Parameters["Mensaje"].Value.ToString();
            }
            catch (Exception inv)
            {
                idInventarioGenerado = 0;
                mensaje = inv.Message;
            }
            return idInventarioGenerado;
        }
        public bool editarProductoInventario(Inventario obj, out string mensaje)
        {
            bool respuesta = false;
            mensaje = string.Empty;
            try
            {
                SqlCommand cmd = new SqlCommand("PA_EDITAR_PRODUCTO_INVENTARIO", ConexioBDD());
                cmd.Parameters.AddWithValue("Id_Inventario", obj.IdInventario);
                cmd.Parameters.AddWithValue("Id_Producto", obj.oProducto.IdProducto);
                cmd.Parameters.AddWithValue("Codigo_Producto", obj.oProducto.Codigo);
                cmd.Parameters.AddWithValue("Nombre_Producto ", obj.oProducto.Nombre);
                cmd.Parameters.AddWithValue("Cantidad", obj.Cantidad);
                cmd.Parameters.AddWithValue("Ubicacion_Almacen", obj.UbicacionAlmacen);
                cmd.Parameters.AddWithValue("Estado", obj.Estado);
                cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();

                respuesta = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);
                mensaje = cmd.Parameters["Mensaje"].Value.ToString();
            }
            catch (Exception inv)
            {
                respuesta = false;
                mensaje = inv.Message;
            }
            return respuesta;
        }
        public bool eliminarProductoInventario(Inventario obj, out string mensaje)
        {
            bool respuesta = false;
            mensaje = string.Empty;
            try
            {
                SqlCommand cmd = new SqlCommand("PA_ELIMINAR_PRODUCTO_INVENTARIO", ConexioBDD());
                cmd.Parameters.AddWithValue("Id_Inventario", obj.IdInventario);
                cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();

                respuesta = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);
                mensaje = cmd.Parameters["Mensaje"].Value.ToString();
            }
            catch (Exception inv)
            {
                respuesta = false;
                mensaje = inv.Message;

            }
            return respuesta;
        }
        public int ObtenerCantidadComprada(int idProducto)
        {
            int cantidadComprada = 0;
            try
            {
                StringBuilder mostrar = new StringBuilder();
                mostrar.AppendLine("SELECT SUM(Cantidad) AS CantidadComprada FROM DETALLE_COMPRA WHERE ID_PRODUCTO = @IdProducto");

                SqlCommand cmd = new SqlCommand(mostrar.ToString(), ConexioBDD());
                cmd.Parameters.AddWithValue("@IdProducto", idProducto);

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    cantidadComprada = reader.IsDBNull(0) ? 0 : reader.GetInt32(0);
                }
            }
            catch (Exception inv)
            {
                cantidadComprada = 0;
            }
            return cantidadComprada;
        }
        //Cliente
        public List<Cliente> mostrarCliente()
        {
            List<Cliente> listaMostrarCliente = new List<Cliente>();
            try
            {
                StringBuilder mostrar = new StringBuilder();
                mostrar.AppendLine("SELECT ID_CLIENTE, DOCUMENTO, NOMBRES, APELLIDOS, CEDULA, TELEFONO, CORREO_ELECTRONICO, ESTADO FROM CLIENTE;");
                SqlCommand cmd = new SqlCommand(mostrar.ToString(), ConexioBDD());
                cmd.CommandType = CommandType.Text;
                SqlDataReader leer = cmd.ExecuteReader();
                while (leer.Read())
                {
                    listaMostrarCliente.Add(new Cliente()
                    {
                        IdCliente = Convert.ToInt32(leer["ID_CLIENTE"]),
                        Documento = leer["DOCUMENTO"].ToString(),
                        Nombres = leer["NOMBRES"].ToString(),
                        Apellidos = leer["APELLIDOS"].ToString(),
                        Cedula = leer["CEDULA"].ToString(),
                        Telefono = leer["TELEFONO"].ToString(),
                        CorreoElectronico = leer["CORREO_ELECTRONICO"].ToString(),
                        Estado = Convert.ToBoolean(leer["ESTADO"])
                    });
                }
            }
            catch (Exception cl)
            {
                listaMostrarCliente = new List<Cliente>();
            }
            return listaMostrarCliente;
        }
        public int registrarCliente(Cliente obj, out string mensaje)
        {
            int idClienteGenerado = 0;
            mensaje = string.Empty;
            try
            {
                SqlCommand cmd = new SqlCommand("PA_REGISTRAR_CLIENTE", ConexioBDD());
                cmd.Parameters.AddWithValue("Documento", obj.Documento);
                cmd.Parameters.AddWithValue("Nombre_Cliente", obj.Nombres);
                cmd.Parameters.AddWithValue("Apellido_Cliente", obj.Apellidos);
                cmd.Parameters.AddWithValue("Cedula", obj.Cedula);
                cmd.Parameters.AddWithValue("Telefono", obj.Telefono);
                cmd.Parameters.AddWithValue("Correo_Electronico", obj.CorreoElectronico);
                cmd.Parameters.AddWithValue("Estado", obj.Estado);
                cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();

                idClienteGenerado = Convert.ToInt32(cmd.Parameters["Resultado"].Value);
                mensaje = cmd.Parameters["Mensaje"].Value.ToString();
            }
            catch (Exception cl)
            {
                idClienteGenerado = 0;
                mensaje = cl.Message;

            }
            return idClienteGenerado;
        }
        public bool editarCliente(Cliente obj, out string mensaje)
        {
            bool respuesta = false;
            mensaje = string.Empty;
            try
            {

                SqlCommand cmd = new SqlCommand("PA_EDITAR_CLIENTE", ConexioBDD());
                cmd.Parameters.AddWithValue("Id_Cliente", obj.IdCliente);
                cmd.Parameters.AddWithValue("Documento", obj.Documento);
                cmd.Parameters.AddWithValue("Nombre_Cliente", obj.Nombres);
                cmd.Parameters.AddWithValue("Apellido_Cliente", obj.Apellidos);
                cmd.Parameters.AddWithValue("Cedula", obj.Cedula);
                cmd.Parameters.AddWithValue("Telefono", obj.Telefono);
                cmd.Parameters.AddWithValue("Correo_Electronico", obj.CorreoElectronico);
                cmd.Parameters.AddWithValue("Estado", obj.Estado);
                cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();

                respuesta = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);
                mensaje = cmd.Parameters["Mensaje"].Value.ToString();
            }
            catch (Exception cl)
            {
                respuesta = false;
                mensaje = cl.Message;

            }
            return respuesta;
        }
        public bool eliminarCliente(Cliente obj, out string mensaje)
        {
            bool respuesta = false;
            mensaje = string.Empty;
            try
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM CLIENTE WHERE ID_CLIENTE = @Id_Cliente", ConexioBDD());
                cmd.Parameters.AddWithValue("Id_Cliente", obj.IdCliente);
                cmd.CommandType = CommandType.Text;
                respuesta = cmd.ExecuteNonQuery() > 0 ? true : false;
            }
            catch (Exception cl)
            {
                respuesta = false;
                mensaje = cl.Message;

            }
            return respuesta;
        }
        //Proveedores
        public List<Proveedor> mostrarProveedor()
        {
            List<Proveedor> listaMostrarProveedor = new List<Proveedor>();
            try
            {
                StringBuilder mostrar = new StringBuilder();
                mostrar.AppendLine("SELECT ID_PROVEEDOR, DOCUMENTO, NOMBRES, APELLIDOS, CEDULA, TELEFONO, CORREO_ELECTRONICO, ESTADO FROM PROVEEDOR;");
                SqlCommand cmd = new SqlCommand(mostrar.ToString(), ConexioBDD());
                cmd.CommandType = CommandType.Text;
                SqlDataReader leer = cmd.ExecuteReader();
                while (leer.Read())
                {
                    listaMostrarProveedor.Add(new Proveedor()
                    {
                        IdProveedor = Convert.ToInt32(leer["ID_PROVEEDOR"]),
                        Documento = leer["DOCUMENTO"].ToString(),
                        Nombres = leer["NOMBRES"].ToString(),
                        Apellidos = leer["APELLIDOS"].ToString(),
                        Cedula = leer["CEDULA"].ToString(),
                        Telefono = leer["TELEFONO"].ToString(),
                        CorreoElectronico = leer["CORREO_ELECTRONICO"].ToString(),
                        Estado = Convert.ToBoolean(leer["ESTADO"])
                    });
                }
            }
            catch (Exception pr)
            {
                listaMostrarProveedor = new List<Proveedor>();
            }
            return listaMostrarProveedor;
        }
        public int registrarProveedor(Proveedor obj, out string mensaje)
        {
            int idProveedorGenerado = 0;
            mensaje = string.Empty;
            try
            {
                SqlCommand cmd = new SqlCommand("PA_REGISTRAR_PROVEEDOR", ConexioBDD());
                cmd.Parameters.AddWithValue("Documento", obj.Documento);
                cmd.Parameters.AddWithValue("Nombres_Proveedor", obj.Nombres);
                cmd.Parameters.AddWithValue("Apellidos_Proveedor", obj.Apellidos);
                cmd.Parameters.AddWithValue("Cedula", obj.Cedula);
                cmd.Parameters.AddWithValue("Telefono", obj.Telefono);
                cmd.Parameters.AddWithValue("Correo_Electronico", obj.CorreoElectronico);
                cmd.Parameters.AddWithValue("Estado", obj.Estado);
                cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();

                idProveedorGenerado = Convert.ToInt32(cmd.Parameters["Resultado"].Value);
                mensaje = cmd.Parameters["Mensaje"].Value.ToString();
            }
            catch (Exception pr)
            {
                idProveedorGenerado = 0;
                mensaje = pr.Message;

            }
            return idProveedorGenerado;
        }
        public bool editarProveedor(Proveedor obj, out string mensaje)
        {
            bool respuesta = false;
            mensaje = string.Empty;
            try
            {

                SqlCommand cmd = new SqlCommand("PA_EDITAR_PROVEEDOR", ConexioBDD());
                cmd.Parameters.AddWithValue("Id_Proveedor", obj.IdProveedor);
                cmd.Parameters.AddWithValue("Documento", obj.Documento);
                cmd.Parameters.AddWithValue("Nombres_Proveedor", obj.Nombres);
                cmd.Parameters.AddWithValue("Apellidos_Proveedor", obj.Apellidos);
                cmd.Parameters.AddWithValue("Cedula", obj.Cedula);
                cmd.Parameters.AddWithValue("Telefono", obj.Telefono);
                cmd.Parameters.AddWithValue("Correo_Electronico", obj.CorreoElectronico);
                cmd.Parameters.AddWithValue("Estado", obj.Estado);
                cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();

                respuesta = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);
                mensaje = cmd.Parameters["Mensaje"].Value.ToString();
            }
            catch (Exception cl)
            {
                respuesta = false;
                mensaje = cl.Message;

            }
            return respuesta;
        }
        public bool eliminarProveedor(Proveedor obj, out string mensaje)
        {
            bool respuesta = false;
            mensaje = string.Empty;
            try
            {
                SqlCommand cmd = new SqlCommand("PA_ELIMINAR_PROVEEDOR", ConexioBDD());
                cmd.Parameters.AddWithValue("Id_Proveedor", obj.IdProveedor);
                cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();

                respuesta = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);
                mensaje = cmd.Parameters["Mensaje"].Value.ToString();
            }
            catch (Exception cl)
            {
                respuesta = false;
                mensaje = cl.Message;

            }
            return respuesta;
        }
        //Negocio
        public Negocio obtenerDatos()
        {
            Negocio obtenerDatos = new Negocio();
            try
            {
                string obtener = "SELECT ID_NEGOCIO, NOMBRE, TELEFONO, RUC, DIRECCION, CORREO_ELECTRONICO FROM NEGOCIO WHERE ID_NEGOCIO = 1";
                SqlCommand cmd = new SqlCommand(obtener, ConexioBDD());
                cmd.CommandType = CommandType.Text;
                SqlDataReader leer = cmd.ExecuteReader();

                while (leer.Read())
                {
                    obtenerDatos = new Negocio()
                    {
                        IdNegocio = Convert.ToInt32(leer["ID_NEGOCIO"]),
                        Nombre = leer["NOMBRE"].ToString(),
                        Telefono = leer["TELEFONO"].ToString(),
                        Ruc = leer["RUC"].ToString(),
                        Direccion = leer["DIRECCION"].ToString(),
                        CorreoElectronico = leer["CORREO_ELECTRONICO"].ToString()
                    };
                }

            }
            catch (Exception ne)
            {
                obtenerDatos = new Negocio();

            }

            return obtenerDatos;
        }
        public bool guardarDatos(Negocio obj, out string mensaje)
        {
            mensaje = string.Empty;
            bool respuesta = true;
            try
            {
                StringBuilder modificarNegocio = new StringBuilder();
                modificarNegocio.AppendLine("UPDATE NEGOCIO SET NOMBRE = @Nombre,");
                modificarNegocio.AppendLine("TELEFONO = @Telefono,");
                modificarNegocio.AppendLine("RUC = @Ruc,");
                modificarNegocio.AppendLine("DIRECCION = @Direccion,");
                modificarNegocio.AppendLine("CORREO_ELECTRONICO = @CorreoElectronico");
                modificarNegocio.AppendLine("WHERE ID_NEGOCIO = 1;");

                SqlCommand cmd = new SqlCommand(modificarNegocio.ToString(), ConexioBDD());
                cmd.Parameters.AddWithValue("@Nombre", obj.Nombre);
                cmd.Parameters.AddWithValue("@Telefono", obj.Telefono);
                cmd.Parameters.AddWithValue("@Ruc", obj.Ruc);
                cmd.Parameters.AddWithValue("@Direccion", obj.Direccion);
                cmd.Parameters.AddWithValue("@CorreoElectronico", obj.CorreoElectronico);
                cmd.CommandType = CommandType.Text;

                if (cmd.ExecuteNonQuery() < 1)
                {
                    mensaje = "No se pudo guardar los datos.";
                    respuesta = false;
                }
            }
            catch (Exception ne)
            {
                mensaje = ne.Message;
                respuesta = false;
            }
            return respuesta;
        }
        public byte[] obtenerLogo(out bool obtenido)
        {
            obtenido = true;
            byte[] logoByte = new byte[0];
            try
            {
                string obtenerLogo = "SELECT LOGO FROM NEGOCIO WHERE ID_NEGOCIO = 1";
                SqlCommand cmd = new SqlCommand(obtenerLogo, ConexioBDD());
                cmd.CommandType = CommandType.Text;
                SqlDataReader leer = cmd.ExecuteReader();

                while (leer.Read())
                {
                    logoByte = (byte[])leer["LOGO"];
                }
            }
            catch (Exception ne)
            {
                obtenido = false;
                logoByte = new byte[0];
            }
            return logoByte;
        }
        public bool actualizarLogo(byte[] image, out string mensaje)
        {
            mensaje = string.Empty;
            bool respuesta = true;
            try
            {
                StringBuilder actualizarLogo = new StringBuilder();
                actualizarLogo.AppendLine("UPDATE NEGOCIO SET LOGO = @Image");
                actualizarLogo.AppendLine("WHERE ID_NEGOCIO = 1");

                SqlCommand cmd = new SqlCommand(actualizarLogo.ToString(), ConexioBDD());
                cmd.Parameters.AddWithValue("@Image", image);
                cmd.CommandType = CommandType.Text;

                if (cmd.ExecuteNonQuery() < 1)
                {
                    mensaje = "No se pudo actulizar el logo.";
                    respuesta = false;
                }
            }
            catch (Exception ne)
            {
                mensaje = ne.Message;
                respuesta = false;
            }
            return respuesta;
        }
        //Compra
        public int obtenerCorrelativoCompra()
        {
            int idCorrelativo = 0;
            try
            {
                StringBuilder obtenerCorrelatico = new StringBuilder();
                obtenerCorrelatico.AppendLine("SELECT count (*) + 1 FROM COMPRA;");

                SqlCommand cmd = new SqlCommand(obtenerCorrelatico.ToString(), ConexioBDD());
                cmd.CommandType = CommandType.Text;
                idCorrelativo = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (Exception co)
            {
                idCorrelativo = 0;
            }
            return idCorrelativo;
        }
        public bool registrarCompra(Compra obj, DataTable DetalleCompra, out string mensaje)
        {
            bool respuesta = false;
            mensaje = string.Empty;
            try
            {
                SqlCommand cmd = new SqlCommand("PA_REGISTRAR_COMPRA", ConexioBDD());
                cmd.Parameters.AddWithValue("Id_Usuario", obj.oUsuario.IdUsuario);
                cmd.Parameters.AddWithValue("Id_Proveedor", obj.oProveedor.IdProveedor);
                cmd.Parameters.AddWithValue("Id_Transportista", obj.oTransportista.IdTransportista);
                cmd.Parameters.AddWithValue("Tipo_Documento", obj.TipoDocumento);
                cmd.Parameters.AddWithValue("Numero_Documento", obj.NumeroDocumento);
                cmd.Parameters.AddWithValue("Monto_Total", obj.MontoTotal);
                cmd.Parameters.AddWithValue("Detalle_Compra", DetalleCompra);
                cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.ExecuteNonQuery();
                respuesta = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);
                mensaje = cmd.Parameters["Mensaje"].Value.ToString();

            }
            catch (Exception co)
            {
                respuesta = false;
                mensaje = co.Message;
            }
            return respuesta;
        }
        public Compra ObtenerCompra(string numero)
        {
            Compra obj = new Compra();
            try
            {
                StringBuilder mostrar = new StringBuilder();
                mostrar.AppendLine("select c.ID_COMPRA, u.NOMBRE_COMPLETO, pr.DOCUMENTO, pr.NOMBRES, t.DOCUMENTO[DOCUMENTO_TRANSPORTISTA], t.NOMBRES[NOMBRE_TRANSPORTISTA], c.TIPO_DOCUMENTO, c.NUMERO_DOCUMENTO, c.MONTO_TOTAL, convert(char(10),c.FECHA_COMPRA,103)[FECHA_COMPRA]");
                mostrar.AppendLine("from COMPRA c inner join USUARIO u on u.ID_USUARIO = c.ID_USUARIO");
                mostrar.AppendLine("inner join PROVEEDOR pr on pr.ID_PROVEEDOR = c.ID_PROVEEDOR");
                mostrar.AppendLine("inner join TRANSPORTISTA t on t.ID_TRANSPORTISTA = c.ID_TRANSPORTISTA");
                mostrar.AppendLine("where c.NUMERO_DOCUMENTO = @numero");
                SqlCommand cmd = new SqlCommand(mostrar.ToString(), ConexioBDD());
                cmd.Parameters.AddWithValue("@numero", numero);
                cmd.CommandType = CommandType.Text;

                SqlDataReader leer = cmd.ExecuteReader();
                while (leer.Read())
                {
                    obj = new Compra()
                    {
                        IdCompra = Convert.ToInt32(leer["ID_COMPRA"]),
                        oUsuario = new Usuario() { NombreCompleto = leer["NOMBRE_COMPLETO"].ToString() },
                        oProveedor = new Proveedor() { Documento = leer["DOCUMENTO"].ToString(), Nombres = leer["NOMBRES"].ToString() },
                        oTransportista = new Transportista() { Documento = leer["DOCUMENTO_TRANSPORTISTA"].ToString(), Nombres = leer["NOMBRE_TRANSPORTISTA"].ToString() },
                        TipoDocumento = leer["TIPO_DOCUMENTO"].ToString(),
                        NumeroDocumento = leer["NUMERO_DOCUMENTO"].ToString(),
                        MontoTotal = Convert.ToDecimal(leer["MONTO_TOTAL"]),
                        FechaCompra = leer["FECHA_COMPRA"].ToString()
                    };
                }
            }
            catch (Exception us)
            {
                obj = new Compra();
            }
            return obj;
        }
        public DataTable graficaCompra()
        {
            DataTable tabla = new DataTable();
            try
            {
                StringBuilder grafica = new StringBuilder();
                grafica.AppendLine("SELECT P.NOMBRE_PRODUCTO, COUNT(DC.ID_PRODUCTO) AS CANTIDAD_COMPRADA FROM DETALLE_COMPRA DC");
                grafica.AppendLine("JOIN PRODUCTO P ON DC.ID_PRODUCTO = P.ID_PRODUCTO GROUP BY P.NOMBRE_PRODUCTO;");

                SqlCommand cmd = new SqlCommand(grafica.ToString(), ConexioBDD());
                SqlDataAdapter data = new SqlDataAdapter(cmd);

                data.Fill(tabla);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            return tabla;
        }
        //DetalleCompra
        public List<Detalle_Compra> obtenerDetalleCompra(int idCompra)
        {
            List<Detalle_Compra> oLista = new List<Detalle_Compra>();
            try
            {
                StringBuilder mostrar = new StringBuilder();
                mostrar.AppendLine("select p.NOMBRE_PRODUCTO, dc.PRECIO_COMPRA, dc.CANTIDAD, dc.MONTO_TOTAL from DETALLE_COMPRA dc");
                mostrar.AppendLine("inner join PRODUCTO p on p.ID_PRODUCTO = dc.ID_PRODUCTO");
                mostrar.AppendLine("where dc.ID_COMPRA = @idCompra");
                SqlCommand cmd = new SqlCommand(mostrar.ToString(), ConexioBDD());
                cmd.Parameters.AddWithValue("@idCompra", idCompra);
                cmd.CommandType = CommandType.Text;

                SqlDataReader leer = cmd.ExecuteReader();
                while (leer.Read())
                {
                    oLista.Add(new Detalle_Compra()
                    {
                        oProducto = new Producto() { Nombre = leer["NOMBRE_PRODUCTO"].ToString() },
                        PrecioCompra = Convert.ToDecimal(leer["PRECIO_COMPRA"].ToString()),
                        Cantidad = Convert.ToInt32(leer["CANTIDAD"].ToString()),
                        MontoTotal = Convert.ToDecimal(leer["MONTO_TOTAL"].ToString()),
                    });
                }
            }
            catch (Exception dec)
            {
                oLista = new List<Detalle_Compra>();
            }
            return oLista;
        }
        //Venta
        public int obtenerCorrelativoVenta()
        {
            int idCorrelativo = 0;
            try
            {
                StringBuilder obtenerCorrelatico = new StringBuilder();
                obtenerCorrelatico.AppendLine("SELECT count (*) + 1 FROM VENTA;");

                SqlCommand cmd = new SqlCommand(obtenerCorrelatico.ToString(), ConexioBDD());
                cmd.CommandType = CommandType.Text;
                idCorrelativo = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (Exception co)
            {
                idCorrelativo = 0;
            }
            return idCorrelativo;
        }
        public bool restarSotck(int idProducto, int cantidad)
        {
            bool respuesta = true;
            try
            {
                StringBuilder obtenerCorrelatico = new StringBuilder();
                obtenerCorrelatico.AppendLine("UPDATE PRODUCTO SET STOCK = STOCK - @Cantidad WHERE Id_Producto = @idProducto");

                SqlCommand cmd = new SqlCommand(obtenerCorrelatico.ToString(), ConexioBDD());
                cmd.Parameters.AddWithValue("@Cantidad", cantidad);
                cmd.Parameters.AddWithValue("@idProducto", idProducto);
                cmd.CommandType = CommandType.Text;

                respuesta = cmd.ExecuteNonQuery() > 0 ? true : false;
            }
            catch (Exception ve)
            {
                respuesta = false;
            }
            return respuesta;
        }
        public bool sumarSotck(int idProducto, int cantidad)
        {
            bool respuesta = true;
            try
            {
                StringBuilder obtenerCorrelatico = new StringBuilder();
                obtenerCorrelatico.AppendLine("UPDATE PRODUCTO SET STOCK = STOCK + @Cantidad WHERE Id_Producto = @idProducto");

                SqlCommand cmd = new SqlCommand(obtenerCorrelatico.ToString(), ConexioBDD());
                cmd.Parameters.AddWithValue("@Cantidad", cantidad);
                cmd.Parameters.AddWithValue("@idProducto", idProducto);
                cmd.CommandType = CommandType.Text;

                respuesta = cmd.ExecuteNonQuery() > 0 ? true : false;
            }
            catch (Exception ve)
            {
                respuesta = false;
            }
            return respuesta;
        }
        public bool registrarVenta(Venta obj, DataTable DetalleVenta, out string mensaje)
        {
            bool respuesta = false;
            mensaje = string.Empty;
            try
            {
                SqlCommand cmd = new SqlCommand("PA_REGISTRAR_VENTA", ConexioBDD());
                cmd.Parameters.AddWithValue("Id_Usuario", obj.oUsuario.IdUsuario);
                cmd.Parameters.AddWithValue("Tipo_Documento", obj.TipoDocumento);
                cmd.Parameters.AddWithValue("Numero_Documento", obj.NumeroDocumento);
                cmd.Parameters.AddWithValue("Documento_Cliente", obj.DocumentoCliente);
                cmd.Parameters.AddWithValue("Nombre_Cliente", obj.NombreCliente);
                cmd.Parameters.AddWithValue("Monto_Pago", obj.MontoPago);
                cmd.Parameters.AddWithValue("Monto_Cambio", obj.MontoCambio);
                cmd.Parameters.AddWithValue("Monto_Total", obj.MontoTotal);
                cmd.Parameters.AddWithValue("Descuento", obj.Descuento);
                cmd.Parameters.AddWithValue("Detalle_Venta", DetalleVenta);
                cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.ExecuteNonQuery();
                respuesta = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);
                mensaje = cmd.Parameters["Mensaje"].Value.ToString();
            }
            catch (Exception ve)
            {
                respuesta = false;
                mensaje = ve.Message;
            }
            return respuesta;
        }
        public Venta obtenerVenta(string numero)
        {
            Venta obj = new Venta();
            try
            {
                StringBuilder obtener = new StringBuilder();
                obtener.AppendLine("select v.ID_VENTA, u.NOMBRE_COMPLETO, v.DOCUMENTO_CLIENTE, v.NOMBRE_CLIENTE, v.TIPO_DOCUMENTO, v.NUMERO_DOCUMENTO, v.MONTO_PAGO, v.MONTO_CAMBIO, v.MONTO_TOTAL, v.DESCUENTO, Convert(char(10),v.FECHA_VENTA,103)[FECHA_VENTA]");
                obtener.AppendLine("from VENTA v inner join USUARIO u on u.ID_USUARIO = v.ID_USUARIO");
                obtener.AppendLine("WHERE v.NUMERO_DOCUMENTO = @numero");

                SqlCommand cmd = new SqlCommand(obtener.ToString(), ConexioBDD());
                cmd.Parameters.AddWithValue("@numero", numero);
                cmd.CommandType = System.Data.CommandType.Text;

                SqlDataReader leer = cmd.ExecuteReader();
                while (leer.Read())
                {
                    obj = new Venta()
                    {
                        IdVenta = int.Parse(leer["Id_Venta"].ToString()),
                        oUsuario = new Usuario() { NombreCompleto = leer["Nombre_Completo"].ToString() },
                        DocumentoCliente = leer["Documento_Cliente"].ToString(),
                        NombreCliente = leer["Nombre_Cliente"].ToString(),
                        TipoDocumento = leer["Tipo_Documento"].ToString(),
                        NumeroDocumento = leer["Numero_Documento"].ToString(),
                        MontoPago = Convert.ToDecimal(leer["Monto_Pago"].ToString()),
                        MontoCambio = Convert.ToDecimal(leer["Monto_Cambio"].ToString()),
                        MontoTotal = Convert.ToDecimal(leer["Monto_Total"].ToString()),
                        Descuento = Convert.ToDecimal(leer["Descuento"].ToString()),
                        FechaVenta = leer["Fecha_Venta"].ToString()
                    };
                }
            }
            catch (Exception ve)
            {
                obj = new Venta();
            }
            return obj;
        }
        public DataTable graficaVenta()
        {
            DataTable tabla = new DataTable();
            try
            {
                StringBuilder grafica = new StringBuilder();
                grafica.AppendLine("SELECT P.NOMBRE_PRODUCTO, COUNT(DV.ID_PRODUCTO) AS CANTIDAD_VENDIDA FROM DETALLE_VENTA DV");
                grafica.AppendLine("JOIN PRODUCTO P ON DV.ID_PRODUCTO = P.ID_PRODUCTO GROUP BY P.NOMBRE_PRODUCTO;");

                SqlCommand cmd = new SqlCommand(grafica.ToString(), ConexioBDD());
                SqlDataAdapter data = new SqlDataAdapter(cmd);

                data.Fill(tabla);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            return tabla;
        }
        //DetalleVenta
        public List<Detalle_Venta> obtenerDetalleVenta(int idVenta)
        {
            List<Detalle_Venta> oLista = new List<Detalle_Venta>();
            try
            {
                StringBuilder obtener = new StringBuilder();
                obtener.AppendLine("SELECT p.NOMBRE_PRODUCTO, dv.PRECIO_VENTA, dv.CANTIDAD_PRODUCTO, dv.SUBTOTAL, dv.DESCUENTO");
                obtener.AppendLine("FROM DETALLE_VENTA DV inner join PRODUCTO p on p.ID_PRODUCTO = dv.ID_PRODUCTO");
                obtener.AppendLine("WHERE dv.ID_VENTA = @idVenta");

                SqlCommand cmd = new SqlCommand(obtener.ToString(), ConexioBDD());
                cmd.Parameters.AddWithValue("@idVenta", idVenta);
                cmd.CommandType = System.Data.CommandType.Text;

                SqlDataReader leer = cmd.ExecuteReader();
                while (leer.Read())
                {
                    oLista.Add(new Detalle_Venta()
                    {
                        oProducto = new Producto() { Nombre = leer["NOMBRE_PRODUCTO"].ToString() },
                        PrecioVenta = Convert.ToDecimal(leer["PRECIO_VENTA"].ToString()),
                        CantidadProducto = Convert.ToInt32(leer["CANTIDAD_PRODUCTO"].ToString()),
                        SubTotal = Convert.ToDecimal(leer["SUBTOTAL"].ToString()),
                        Descuento = Convert.ToDecimal(leer["DESCUENTO"].ToString())
                    });
                }
            }
            catch (Exception ve)
            {
                oLista = new List<Detalle_Venta>();
            }
            return oLista;
        }
        //ReporteCompra
        public List<Reporte_Compra> reporteCompra(string fechaInicio, string fechaFin, int idProveedor, int idTransportista)
        {
            List<Reporte_Compra> lista = new List<Reporte_Compra>();
            try
            {
                StringBuilder reporte = new StringBuilder();
                SqlCommand cmd = new SqlCommand("PA_REPORTE_COMPRA", ConexioBDD());
                cmd.Parameters.AddWithValue("Fecha_Inicio", fechaInicio);
                cmd.Parameters.AddWithValue("Fecha_Fin", fechaFin);
                cmd.Parameters.AddWithValue("Id_Proveedor", idProveedor);
                cmd.Parameters.AddWithValue("Id_Transportista", idTransportista);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader leer = cmd.ExecuteReader();
                while (leer.Read())
                {
                    lista.Add(new Reporte_Compra()
                    {
                        FechaRegistro = leer["FECHA_COMPRA"].ToString(),
                        TipoDocumento = leer["TIPO_DOCUMENTO"].ToString(),
                        NumeroDocumento = leer["NUMERO_DOCUMENTO"].ToString(),
                        MontoTotal = leer["MONTO_TOTAL"].ToString(),
                        UsuarioRegistro = leer["NOMBRE_USUARIO"].ToString(),
                        DocumentoProveedor = leer["DOCUMENTO_PROVEEDOR"].ToString(),
                        NombreProveedor = leer["NOMBRE_PROVEEDOR"].ToString(),
                        DocumentoTranportista = leer["DOCUMENTO_TRANSPORTISTA"].ToString(),
                        NombreTransportista = leer["NOMBRE_TRANSPORTISTA"].ToString(),
                        CodigoProducto = leer["CODIGO_PRODUCTO"].ToString(),
                        NombreProducto = leer["NOMBRE_PRODUCTO"].ToString(),
                        Categoria = leer["CATEGORIA"].ToString(),
                        PrecioCompra = leer["PRECIO_COMPRA"].ToString(),
                        PrecioVenta = leer["PRECIO_VENTA"].ToString(),
                        Cantidad = leer["CANTIDAD"].ToString(),
                        SubTotal = leer["SUBTOTAL"].ToString()
                    });
                }
            }
            catch (Exception rec)
            {
                lista = new List<Reporte_Compra>();
            }
            return lista;
        }
        //Reporte Venta
        public List<Reporte_Venta> reporteVenta(string fechaInicio, string fechaFin)
        {
            List<Reporte_Venta> lista = new List<Reporte_Venta>();
            try
            {
                StringBuilder reporte = new StringBuilder();
                SqlCommand cmd = new SqlCommand("PA_REPORTE_VENTA", ConexioBDD());
                cmd.Parameters.AddWithValue("fecha_Inicio", fechaInicio);
                cmd.Parameters.AddWithValue("fecha_Fin", fechaFin);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader leer = cmd.ExecuteReader();
                while (leer.Read())
                {
                    lista.Add(new Reporte_Venta()
                    {
                        FechaRegistro = leer["FECHA_VENTA"].ToString(),
                        TipoDocumento = leer["TIPO_DOCUMENTO"].ToString(),
                        NumeroDocumento = leer["NUMERO_DOCUMENTO"].ToString(),
                        MontoTotal = leer["MONTO_TOTAL"].ToString(),
                        UsuarioRegistro = leer["NOMBRE_USUARIO"].ToString(),
                        DocumentoCliente = leer["DOCUMENTO_CLIENTE"].ToString(),
                        NombreCliente = leer["NOMBRE_CLIENTE"].ToString(),
                        CodigoProducto = leer["CODIGO_PRODUCTO"].ToString(),
                        NombreProducto = leer["NOMBRE_PRODUCTO"].ToString(),
                        Categoria = leer["CATEGORIA"].ToString(),
                        PrecioVenta = leer["PRECIO_VENTA"].ToString(),
                        Cantidad = leer["CANTIDAD_PRODUCTO"].ToString(),
                        SubTotal = leer["SUBTOTAL"].ToString(),
                        Descuento = leer["DESCUENTO"].ToString()
                    });
                }
            }
            catch (Exception rev)
            {
                lista = new List<Reporte_Venta>();
            }
            return lista;
        }
        //Oferta
        public List<Oferta> mostrarOferta()
        {
            List<Oferta> listaMostrarOferta = new List<Oferta>();
            try
            {
                StringBuilder mostrar = new StringBuilder();
                mostrar.AppendLine("SELECT ID_OFERTA, p.ID_PRODUCTO, p.NOMBRE_PRODUCTO, NOMBRE_OFERTA, O.DESCRIPCION, FECHA_INICIO, FECHA_FIN, DESCUENTO, O.ESTADO FROM OFERTA O");
                mostrar.AppendLine("INNER JOIN PRODUCTO p ON p.ID_PRODUCTO = O.ID_PRODUCTO;");
                SqlCommand cmd = new SqlCommand(mostrar.ToString(), ConexioBDD());
                cmd.CommandType = CommandType.Text;
                SqlDataReader leer = cmd.ExecuteReader();
                while (leer.Read())
                {
                    listaMostrarOferta.Add(new Oferta()
                    {
                        IdOferta = Convert.ToInt32(leer["ID_OFERTA"]),
                        oProducto = new Producto() { IdProducto = Convert.ToInt32(leer["ID_PRODUCTO"]), Nombre = leer["NOMBRE_PRODUCTO"].ToString() },
                        NombreOferta = leer["NOMBRE_OFERTA"].ToString(),
                        Descripcion = leer["DESCRIPCION"].ToString(),
                        FechaInicio = leer["FECHA_INICIO"].ToString(),
                        FechaFin = leer["FECHA_FIN"].ToString(),
                        Descuento = Convert.ToDecimal(leer["DESCUENTO"]),
                        Estado = Convert.ToBoolean(leer["ESTADO"])
                    });
                }
            }
            catch (Exception of)
            {
                listaMostrarOferta = new List<Oferta>();
            }
            return listaMostrarOferta;
        }
        public int registrarOferta(Oferta obj, out string mensaje)
        {
            int idOfertaoGenerada = 0;
            mensaje = string.Empty;
            try
            {
                SqlCommand cmd = new SqlCommand("PA_REGISTRAR_OFERTA", ConexioBDD());
                cmd.Parameters.AddWithValue("Id_Producto", obj.oProducto.IdProducto);
                cmd.Parameters.AddWithValue("Nombre_Oferta", obj.NombreOferta);
                cmd.Parameters.AddWithValue("Descripcion", obj.Descripcion);
                cmd.Parameters.AddWithValue("Fecha_Inicio", obj.FechaInicio);
                cmd.Parameters.AddWithValue("Fecha_Fin", obj.FechaFin);
                cmd.Parameters.AddWithValue("Descuento", obj.Descuento);
                cmd.Parameters.AddWithValue("Estado", obj.Estado);
                cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();

                idOfertaoGenerada = Convert.ToInt32(cmd.Parameters["Resultado"].Value);
                mensaje = cmd.Parameters["Mensaje"].Value.ToString();
            }
            catch (Exception of)
            {
                idOfertaoGenerada = 0;
                mensaje = of.Message;

            }
            return idOfertaoGenerada;
        }
        public bool editarOferta(Oferta obj, out string mensaje)
        {
            bool respuesta = false;
            mensaje = string.Empty;
            try
            {
                SqlCommand cmd = new SqlCommand("PA_EDITAR_OFERTA", ConexioBDD());
                cmd.Parameters.AddWithValue("Id_Oferta", obj.IdOferta);
                cmd.Parameters.AddWithValue("Id_Producto", obj.oProducto.IdProducto);
                cmd.Parameters.AddWithValue("Nombre_Oferta", obj.NombreOferta);
                cmd.Parameters.AddWithValue("Descripcion", obj.Descripcion);
                cmd.Parameters.AddWithValue("Fecha_Inicio", obj.FechaInicio);
                cmd.Parameters.AddWithValue("Fecha_Fin", obj.FechaFin);
                cmd.Parameters.AddWithValue("Descuento", obj.Descuento);
                cmd.Parameters.AddWithValue("Estado", obj.Estado);
                cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();

                respuesta = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);
                mensaje = cmd.Parameters["Mensaje"].Value.ToString();
            }
            catch (Exception pr)
            {
                respuesta = false;
                mensaje = pr.Message;

            }
            return respuesta;
        }
        public bool eliminarOferta(Oferta obj, out string mensaje)
        {
            bool respuesta = false;
            mensaje = string.Empty;
            try
            {
                SqlCommand cmd = new SqlCommand("PA_ELIMINAR_OFERTA", ConexioBDD());
                cmd.Parameters.AddWithValue("Id_Oferta", obj.IdOferta);
                cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();

                respuesta = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);
                mensaje = cmd.Parameters["Mensaje"].Value.ToString();
            }
            catch (Exception pr)
            {
                respuesta = false;
                mensaje = pr.Message;

            }
            return respuesta;
        }
       
        //Reclamo
        public List<Reclamo> mostrarReclamo()
        {
            List<Reclamo> listaMostrarReclamo = new List<Reclamo>();
            try
            {
                StringBuilder mostrar = new StringBuilder();
                mostrar.AppendLine("SELECT ID_RECLAMO, c.ID_CLIENTE, c.DOCUMENTO, c.NOMBRES, c.CORREO_ELECTRONICO, DESCRIPCION, r.ESTADO FROM RECLAMO r");
                mostrar.AppendLine("INNER JOIN CLIENTE c ON c.ID_CLIENTE = r.ID_CLIENTE;");
                SqlCommand cmd = new SqlCommand(mostrar.ToString(), ConexioBDD());
                cmd.CommandType = CommandType.Text;
                SqlDataReader leer = cmd.ExecuteReader();
                while (leer.Read())
                {
                    listaMostrarReclamo.Add(new Reclamo()
                    {
                        IdReclamo = Convert.ToInt32(leer["ID_RECLAMO"]),
                        oCliente = new Cliente() { IdCliente = Convert.ToInt32(leer["ID_CLIENTE"]), Documento = leer["DOCUMENTO"].ToString(), Nombres = leer["NOMBRES"].ToString(), CorreoElectronico = leer["CORREO_ELECTRONICO"].ToString() },
                        Descripcion = leer["DESCRIPCION"].ToString(),
                        Estado = Convert.ToBoolean(leer["ESTADO"])
                    });
                }
            }
            catch (Exception of)
            {
                listaMostrarReclamo = new List<Reclamo>();
            }
            return listaMostrarReclamo;
        }
        public bool editarReclamo(Reclamo obj, out string mensaje)
        {
            bool respuesta = false;
            mensaje = string.Empty;
            try
            {
                SqlCommand cmd = new SqlCommand("PA_EDITAR_RECLAMO", ConexioBDD());
                cmd.Parameters.AddWithValue("Id_Reclamo", obj.IdReclamo);
                cmd.Parameters.AddWithValue("Estado", obj.Estado);
                cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();

                respuesta = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);
                mensaje = cmd.Parameters["Mensaje"].Value.ToString();
            }
            catch (Exception pr)
            {
                respuesta = false;
                mensaje = pr.Message;

            }
            return respuesta;
        }
        public bool eliminarReclamo(Reclamo obj, out string mensaje)
        {
            bool respuesta = false;
            mensaje = string.Empty;
            try
            {
                SqlCommand cmd = new SqlCommand("PA_ELIMINAR_RECLAMO", ConexioBDD());
                cmd.Parameters.AddWithValue("Id_Reclamo", obj.IdReclamo);
                cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();

                respuesta = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);
                mensaje = cmd.Parameters["Mensaje"].Value.ToString();
            }
            catch (Exception pr)
            {
                respuesta = false;
                mensaje = pr.Message;

            }
            return respuesta;
        }
        //Sucursal
        public List<Sucursal> mostrarSucursal()
        {
            List<Sucursal> listaSucursal = new List<Sucursal>();
            try
            {
                string mostrar = "SELECT ID_SUCURSAL, NOMBRE_SUCURSAL, DIRECCION_SUCURSAL, LATITUD_SUCURSAL, LONGITUD_SUCURSAL, CIUDAD_SUCURSAL, ESTADO FROM SUCURSAL";
                SqlCommand cmd = new SqlCommand(mostrar, ConexioBDD());
                cmd.CommandType = CommandType.Text;
                SqlDataReader leer = cmd.ExecuteReader();
                while (leer.Read())
                {
                    listaSucursal.Add(new Sucursal()
                    {
                        IdSucursal = Convert.ToInt32(leer["ID_SUCURSAL"]),
                        Nombre = leer["NOMBRE_SUCURSAL"].ToString(),
                        Direccion = leer["DIRECCION_SUCURSAL"].ToString(),
                        Latitud = Convert.ToDouble(leer["LATITUD_SUCURSAL"]),
                        Longitud = Convert.ToDouble(leer["LONGITUD_SUCURSAL"]),
                        Ciudad = leer["CIUDAD_SUCURSAL"].ToString(),
                        Estado = Convert.ToBoolean(leer["ESTADO"])
                    });
                }
            }
            catch (Exception su)
            {
                listaSucursal = new List<Sucursal>();
            }
            return listaSucursal;
        }
        public int registrarSucursal(Sucursal obj, out string mensaje)
        {
            int idSucursaloGenerada = 0;
            mensaje = string.Empty;
            try
            {
                SqlCommand cmd = new SqlCommand("PA_REGISTRAR_SUCURSAL", ConexioBDD());
                cmd.Parameters.AddWithValue("Nombre_Sucursal", obj.Nombre);
                cmd.Parameters.AddWithValue("Direccion_Sucursal", obj.Direccion);
                cmd.Parameters.AddWithValue("Latitud_Sucursal", obj.Latitud);
                cmd.Parameters.AddWithValue("Longitud_Sucursal", obj.Longitud);
                cmd.Parameters.AddWithValue("Ciudad_Sucursal", obj.Ciudad);
                cmd.Parameters.AddWithValue("Estado", obj.Estado);
                cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();

                idSucursaloGenerada = Convert.ToInt32(cmd.Parameters["Resultado"].Value);
                mensaje = cmd.Parameters["Mensaje"].Value.ToString();
            }
            catch (Exception su)
            {
                idSucursaloGenerada = 0;
                mensaje = su.Message;

            }
            return idSucursaloGenerada;
        }
        public bool editarSucursal(Sucursal obj, out string mensaje)
        {
            bool respuesta = false;
            mensaje = string.Empty;
            try
            {
                SqlCommand cmd = new SqlCommand("PA_EDITAR_SUCURSAL", ConexioBDD());
                cmd.Parameters.AddWithValue("Id_Sucursal", obj.IdSucursal);
                cmd.Parameters.AddWithValue("Nombre_Sucursal", obj.Nombre);
                cmd.Parameters.AddWithValue("Direccion_Sucursal", obj.Direccion);
                cmd.Parameters.AddWithValue("Latitud_Sucursal", obj.Latitud);
                cmd.Parameters.AddWithValue("Longitud_Sucursal", obj.Longitud);
                cmd.Parameters.AddWithValue("Ciudad_Sucursal", obj.Ciudad);
                cmd.Parameters.AddWithValue("Estado", obj.Estado);
                cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();

                respuesta = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);
                mensaje = cmd.Parameters["Mensaje"].Value.ToString();
            }
            catch (Exception su)
            {
                respuesta = false;
                mensaje = su.Message;

            }
            return respuesta;
        }
        public bool eliminarSucursal(Sucursal obj, out string mensaje)
        {
            bool respuesta = false;
            mensaje = string.Empty;
            try
            {
                SqlCommand cmd = new SqlCommand("PA_ELIMINAR_SUCURSAL", ConexioBDD());
                cmd.Parameters.AddWithValue("Id_Sucursal", obj.IdSucursal);
                cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();

                respuesta = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);
                mensaje = cmd.Parameters["Mensaje"].Value.ToString();
            }
            catch (Exception su)
            {
                respuesta = false;
                mensaje = su.Message;

            }
            return respuesta;
        }
        //Transportista
        public List<Transportista> mostrarTransportista()
        {
            List<Transportista> listaTransportista = new List<Transportista>();
            try
            {
                string mostrar = "SELECT ID_TRANSPORTISTA, DOCUMENTO, NOMBRES, APELLIDOS, CEDULA, TELEFONO, CORREO_ELECTRONICO, IMAGEN, ESTADO FROM TRANSPORTISTA";
                SqlCommand cmd = new SqlCommand(mostrar, ConexioBDD());
                cmd.CommandType = CommandType.Text;
                SqlDataReader leer = cmd.ExecuteReader();
                while (leer.Read())
                {
                    listaTransportista.Add(new Transportista()
                    {
                        IdTransportista = Convert.ToInt32(leer["ID_TRANSPORTISTA"]),
                        Documento = leer["DOCUMENTO"].ToString(),
                        Nombres = leer["NOMBRES"].ToString(),
                        Apellidos = leer["APELLIDOS"].ToString(),
                        Cedula = leer["CEDULA"].ToString(),
                        Telefono = leer["TELEFONO"].ToString(),
                        CorreoElectronico = leer["CORREO_ELECTRONICO"].ToString(),
                        Imagen = (byte[])leer["IMAGEN"],
                        Estado = Convert.ToBoolean(leer["ESTADO"])
                    });
                }
            }
            catch (Exception tra)
            {
                listaTransportista = new List<Transportista>();
            }
            return listaTransportista;
        }
        public int registrarTransportista(Transportista obj, byte[] imagen, out string mensaje)
        {
            int idTransportistaGenerada = 0;
            mensaje = string.Empty;
            try
            {
                SqlCommand cmd = new SqlCommand("PA_REGISTRAR_TRANSPORTISTA", ConexioBDD());
                cmd.Parameters.AddWithValue("Documento", obj.Documento);
                cmd.Parameters.AddWithValue("Nombres", obj.Nombres);
                cmd.Parameters.AddWithValue("Apellidos", obj.Apellidos);
                cmd.Parameters.AddWithValue("Cedula", obj.Cedula);
                cmd.Parameters.AddWithValue("Telefono", obj.Telefono);
                cmd.Parameters.AddWithValue("Correo_Electronico", obj.CorreoElectronico);
                cmd.Parameters.AddWithValue("Imagen", imagen);
                cmd.Parameters.AddWithValue("Estado", obj.Estado);
                cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();

                idTransportistaGenerada = Convert.ToInt32(cmd.Parameters["Resultado"].Value);
                mensaje = cmd.Parameters["Mensaje"].Value.ToString();
            }
            catch (Exception tr)
            {
                idTransportistaGenerada = 0;
                mensaje = tr.Message;

            }
            return idTransportistaGenerada;
        }
        public bool editarTransportista(Transportista obj, byte[] imagen, out string mensaje)
        {
            bool respuesta = false;
            mensaje = string.Empty;
            try
            {
                SqlCommand cmd = new SqlCommand("PA_EDITAR_TRANSPORTISTA", ConexioBDD());
                cmd.Parameters.AddWithValue("Id_Transportista", obj.IdTransportista);
                cmd.Parameters.AddWithValue("Documento", obj.Documento);
                cmd.Parameters.AddWithValue("Nombres", obj.Nombres);
                cmd.Parameters.AddWithValue("Apellidos", obj.Apellidos);
                cmd.Parameters.AddWithValue("Cedula", obj.Cedula);
                cmd.Parameters.AddWithValue("Telefono", obj.Telefono);
                cmd.Parameters.AddWithValue("Correo_Electronico", obj.CorreoElectronico);
                cmd.Parameters.AddWithValue("Imagen", imagen);
                cmd.Parameters.AddWithValue("Estado", obj.Estado);
                cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();

                respuesta = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);
                mensaje = cmd.Parameters["Mensaje"].Value.ToString();
            }
            catch (Exception tr)
            {
                respuesta = false;
                mensaje = tr.Message;
            }
            return respuesta;
        }
        public bool eliminarTransportista(Transportista obj, out string mensaje)
        {
            bool respuesta = false;
            mensaje = string.Empty;
            try
            {
                SqlCommand cmd = new SqlCommand("PA_ELIMINAR_TRANSPORTISTA", ConexioBDD());
                cmd.Parameters.AddWithValue("Id_Transportista", obj.IdTransportista);
                cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();

                respuesta = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);
                mensaje = cmd.Parameters["Mensaje"].Value.ToString();
            }
            catch (Exception tr)
            {
                respuesta = false;
                mensaje = tr.Message;
            }
            return respuesta;
        }
    }
}
