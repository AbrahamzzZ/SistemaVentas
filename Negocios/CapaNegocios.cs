using System;
using Datos;
using Entidad;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Negocios
{
    public class CapaNegocios
    {
        private CapaDatos objecto = new CapaDatos();
        public List<Usuario> ListarUsuarios()
        {
            return objecto.ingresarUsuario();
        }
        public List<Categoria> ListarCategoria()
        {
            return objecto.mostrarCategoria();
        }
        public List<Producto> ListarProducto()
        {
            return objecto.mostrarProducto();
        }
        public List<Unidad_Medida> ListarUnidadesMedida()
        {
            return objecto.mostrarUnidadesMedidas();
        }
        public Negocio ListarNegocio()
        {
            return objecto.obtenerDatos();
        }
        public List<Cliente> ListarCiente()
        {
            return objecto.mostrarCliente();
        }
        public List<Oferta> ListarOferta()
        {
            return objecto.mostrarOferta();
        }
        public List<Transportista> ListarTransportista()
        {
            return objecto.mostrarTransportista();
        }
        //Permiso
        public List<Permiso> perSQL(int idUsuario)
        {
            return objecto.permisosMenu(idUsuario);
        }
        //Rol
        public List<Rol> mosSQL()
        {
            return objecto.listarRol();
        }
        //Usuario
        public Usuario recSQL(string correo)
        {
            return objecto.recuperarContrasena(correo);
        }
        public List<Usuario> mosuSQL()
        {
            return objecto.mostrarUsuario();
        }
        public int resuSQL(Usuario obj, out string mensaje)
        {
            return objecto.registrarUsuario(obj, out mensaje);

        }
        public bool ediuSQL(Usuario obj, out string mensaje)
        {
            mensaje = string.Empty;
            if (obj.Documento == "")
            {
                mensaje += "Es necesario el documento del usuario.\n";

            }
            if (obj.NombreCompleto == "")
            {
                mensaje += "Es necesario el nombre completo del usuario.\n";
            }
            if (obj.CorreoElectronico == "")
            {
                mensaje += "Es necesario el correo electrónico del usuario.\n";
            }
            if (obj.Clave == "")
            {
                mensaje += "Es necesario la clave del usuario.";
            }
            if (mensaje != string.Empty)
            {
                return false;
            }
            else
            {
                return objecto.editarUsuario(obj, out mensaje);
            }
        }
        public bool eliuSQL(Usuario obj, out string mensaje)
        {
            return objecto.eliminarUsuario(obj, out mensaje);
        }
        //Categoria
        public int rescSQL(Categoria obj, out string mensaje)
        {
            return objecto.registrarCategoria(obj, out mensaje);

        }
        public bool edicSQL(Categoria obj, out string mensaje)
        {
            mensaje = string.Empty;
            if (obj.Descripcion == "")
            {
                mensaje += "Es necesario la descripción de la categoría.";
            }
            if (mensaje != string.Empty)
            {
                return false;
            }
            else
            {
                return objecto.editarCategoria(obj, out mensaje);
            }
        }
        public bool elicSQL(Categoria obj, out string mensaje)
        {
            return objecto.eliminarCategoria(obj, out mensaje);
        }
        //Producto
        public List<Producto> mospSQL()
        {
            return objecto.mostrarProducto();
        }
        public int respSQL(Producto obj, out string mensaje)
        {
            return objecto.registrarProducto(obj, out mensaje);
        }
        public bool edipSQL(Producto obj, out string mensaje)
        {
            mensaje = string.Empty;
            if (obj.Codigo == "")
            {
                mensaje += "Es necesario el codigo del producto.\n";
            }
            if (obj.Nombre == "")
            {
                mensaje += "Es necesario el nombre del producto.\n";
            }
            if (obj.Descripcion == "")
            {
                mensaje += "Es necesario el descripción del producto.\n";
            }
            if (obj.PaisOrigen == "")
            {
                mensaje += "Es necesario el país de origen del producto.";
            }
            if (mensaje != string.Empty)
            {
                return false;
            }
            else
            {
                return objecto.editarProducto(obj, out mensaje);
            }
        }
        public bool elipSQL(Producto obj, out string mensaje)
        {
            return objecto.eliminarProducto(obj, out mensaje);
        }
        //Unidad Medida
        public List<Unidad_Medida> mosumSQL()
        {
            return objecto.mostrarUnidadesMedidas();
        }
        public int resumSQL(Unidad_Medida obj, out string mensaje)
        {
            return objecto.registrarUnidadMedida(obj, out mensaje);
        }
        public bool ediumSQL(Unidad_Medida obj, out string mensaje)
        {
            mensaje = string.Empty;
            if (obj.Descripcion == "")
            {
                mensaje += "Es necesario la descripción de la unidad de la medida.";
            }
            if (obj.Simbolo == "")
            {
                mensaje += "Es necesario la simbología de la unidad de la medida.";
            }
            if (mensaje != string.Empty)
            {
                return false;
            }
            else
            {
                return objecto.editarUnidadMedida(obj, out mensaje);
            }
        }
        public bool eliumSQL(Unidad_Medida obj, out string mensaje)
        {
            return objecto.eliminarUnidadMedida(obj, out mensaje);
        }
        //Iventario
        public List<Inventario> mosiSQL()
        {
            return objecto.mostrarInventario();
        }
        public int resiSQL(Inventario obj, out string mensaje)
        {
            return objecto.agregarProductoInventario(obj, out mensaje);
        }
        public bool ediiSQL(Inventario obj, out string mensaje)
        {
            mensaje = string.Empty;
            if (obj.Cantidad == 0)
            {
                mensaje += "Es necesario la cantidad de productos.\n";
            }
            if (obj.UbicacionAlmacen == "")
            {
                mensaje += "Es necesario la ubicacion del almacen para el producto.";
            }
            if (mensaje != string.Empty)
            {
                return false;
            }
            else
            {
                return objecto.editarProductoInventario(obj, out mensaje);
            }
        }
        public bool eliiSQL(Inventario obj, out string mensaje)
        {
            return objecto.eliminarProductoInventario(obj, out mensaje);
        }
        public int obtcSQL(int idProducto)
        {
            return objecto.ObtenerCantidadComprada(idProducto);
        }
        //Cliente
        public List<Cliente> moscSQL()
        {
            return objecto.mostrarCliente();
        }
        public int rescSQL(Cliente obj, out string mensaje)
        {
            return objecto.registrarCliente(obj, out mensaje);
        }
        public bool edicSQL(Cliente obj, out string mensaje)
        {
            mensaje = string.Empty;
            if (obj.Documento == "")
            {
                mensaje += "Es necesario el documento del cliente.\n";
            }
            if (obj.Nombres == "")
            {
                mensaje += "Es necesario los dos nombres del cliente.\n";
            }
            if (obj.Apellidos == "")
            {
                mensaje += "Es necesario los dos apellidos del cliente.\n";
            }
            if (obj.Cedula == "")
            {
                mensaje += "Es necesario la cédula del cliente.\n";
            }
            if (obj.Telefono == "")
            {
                mensaje += "Es necesario el teléfono del cliente.\n";
            }
            if (obj.CorreoElectronico == "")
            {
                mensaje += "Es necesario el correo electrónico del cliente.";
            }
            if (mensaje != string.Empty)
            {
                return false;
            }
            else
            {
                return objecto.editarCliente(obj, out mensaje);
            }
        }
        public bool elicSQL(Cliente obj, out string mensaje)
        {
            return objecto.eliminarCliente(obj, out mensaje);
        }
        //Proveedor
        public List<Proveedor> mosprSQL()
        {
            return objecto.mostrarProveedor();
        }
        public int resprSQL(Proveedor obj, out string mensaje)
        {
            return objecto.registrarProveedor(obj, out mensaje);
        }
        public bool ediprSQL(Proveedor obj, out string mensaje)
        {
            mensaje = string.Empty;
            if (obj.Documento == "")
            {
                mensaje += "Es necesario el documento del proveedor.\n";
            }
            if (obj.Nombres == "")
            {
                mensaje += "Es necesario los dos nombres del proveedor.\n";
            }
            if (obj.Apellidos == "")
            {
                mensaje += "Es necesario los dos apellidos del proveedor.\n";
            }
            if (obj.Cedula == "")
            {
                mensaje += "Es necesario la cédula del proveedor.\n";
            }
            if (obj.Telefono == "")
            {
                mensaje += "Es necesario el teléfono del proveedor.\n";
            }
            if (obj.CorreoElectronico == "")
            {
                mensaje += "Es necesario el correo electrénico del proveedor.";
            }
            if (mensaje != string.Empty)
            {
                return false;
            }
            else
            {
                return objecto.editarProveedor(obj, out mensaje);
            }
        }
        public bool eliprSQL(Proveedor obj, out string mensaje)
        {
            return objecto.eliminarProveedor(obj, out mensaje);
        }
        //Negocio
        public bool resneSQL(Negocio obj, out string mensaje)
        {
            return objecto.guardarDatos(obj, out mensaje);
        }
        public byte[] obtlSQL(out bool obtenido)
        {
            return objecto.obtenerLogo(out obtenido);
        }
        public bool actlSQL(byte[] image, out string mensaje)
        {
            return objecto.actualizarLogo(image, out mensaje);
        }
        //Compra
        public int obtenerCorrelativoCompra()
        {
            return objecto.obtenerCorrelativoCompra();
        }
        public bool rescoSQL(Compra obj, DataTable DetalleCompra, out string mensaje)
        {
            return objecto.registrarCompra(obj, DetalleCompra, out mensaje);
        }
        public DataTable gracSQL()
        {
            return objecto.graficaCompra();
        }
        //DetalleCompra
        public Compra obtcSQL(string numero)
        {
            Compra oCompra = objecto.ObtenerCompra(numero);
            if (oCompra.IdCompra != 0)
            {
                List<Detalle_Compra> oDetalleCompra = objecto.obtenerDetalleCompra(oCompra.IdCompra);

                oCompra.oDetalle_Compra = oDetalleCompra;
            }
            return oCompra;
        }
        //Venta
        public int obtenerCorrelativoVenta()
        {
            return objecto.obtenerCorrelativoVenta();
        }
        public bool resveSQL(Venta obj, DataTable DetalleVenta, out string mensaje)
        {
            return objecto.registrarVenta(obj, DetalleVenta, out mensaje);
        }
        public bool resstSQL(int idProducto, int cantidad)
        {
            return objecto.restarSotck(idProducto, cantidad);
        }
        public bool sumstSQL(int idProducto, int cantidad)
        {
            return objecto.sumarSotck(idProducto, cantidad);
        }
        public DataTable gravSQL()
        {
            return objecto.graficaVenta();
        }
        //DetalleVenta
        public Venta obtvSQL(string numero)
        {
            Venta oVenta = objecto.obtenerVenta(numero);
            if (oVenta.IdVenta != 0)
            {
                List<Detalle_Venta> oDetalleVenta = objecto.obtenerDetalleVenta(oVenta.IdVenta);
                oVenta.oDetalle_Venta = oDetalleVenta;

            }
            return oVenta;
        }
        //ReporteCompra
        public List<Reporte_Compra> recSQL(string fechaInicio, string fechaFin, int idProveedor, int idTransportista)
        {
            return objecto.reporteCompra(fechaInicio, fechaFin, idProveedor, idTransportista);
        }
        //ReporteVenta
        public List<Reporte_Venta> revSQL(string fechaInicio, string fechaFin)
        {
            return objecto.reporteVenta(fechaInicio, fechaFin);
        }
        //Oferta
        public List<Oferta> mosoSQL()
        {
            return objecto.mostrarOferta();
        }
        public int resoSQL(Oferta obj, out string mensaje)
        {
            return objecto.registrarOferta(obj, out mensaje);
        }
        public bool edioSQL(Oferta obj, out string mensaje)
        {
            mensaje = string.Empty;
            if (obj.NombreOferta == "")
            {
                mensaje += "Es necesario el nombre de la oferta.\n";
            }
            if (obj.Descripcion == "")
            {
                mensaje += "Es necesario el descripción de la oferta.\n";
            }
            if (obj.Descuento == 0)
            {
                mensaje += "Es necesario el descuento para la oferta.";
            }
            if (mensaje != string.Empty)
            {
                return false;
            }
            else
            {
                return objecto.editarOferta(obj, out mensaje);
            }
        }
        public bool elioSQL(Oferta obj, out string mensaje)
        {
            return objecto.eliminarOferta(obj, out mensaje);
        }
        //Reclamo
        public List<Reclamo> mosreSQL()
        {
            return objecto.mostrarReclamo();
        }
        public bool edireSQL(Reclamo obj, out string mensaje)
        {
            return objecto.editarReclamo(obj, out mensaje);

        }
        public bool elireSQL(Reclamo obj, out string mensaje)
        {
            return objecto.eliminarReclamo(obj, out mensaje);
        }
        //Sucursal
        public List<Sucursal> mossuSQL()
        {
            return objecto.mostrarSucursal();
        }
        public int ressuSQL(Sucursal obj, out string mensaje)
        {
            return objecto.registrarSucursal(obj, out mensaje);
        }
        public bool edisuSQL(Sucursal obj, out string mensaje)
        {
            mensaje = string.Empty;
            if (obj.Nombre == "")
            {
                mensaje += "Es necesario el nombre de la sucursal.\n";
            }
            if (obj.Direccion == "")
            {
                mensaje += "Es necesario la dirección de la sucursal.\n";
            }
            if (obj.Latitud == 0)
            {
                mensaje += "Es necesario la latitud de la sucursal.";
            }
            if (obj.Longitud == 0)
            {
                mensaje += "Es necesario la longitud de la sucursal.";
            }
            if (obj.Ciudad == "")
            {
                mensaje += "Es necesario la ciudad de la sucursal.";
            }
            if (mensaje != string.Empty)
            {
                return false;
            }
            else
            {
                return objecto.editarSucursal(obj, out mensaje);
            }
        }
        public bool elisuSQL(Sucursal obj, out string mensaje)
        {
            return objecto.eliminarSucursal(obj, out mensaje);
        }
        //Transportista 
        public List<Transportista> mostrSQL()
        {
            return objecto.mostrarTransportista();
        }
        public int restrSQL(Transportista obj, byte[] imagen, out string mensaje)
        {
            return objecto.registrarTransportista(obj, imagen, out mensaje);
        }
        public bool editrSQL(Transportista obj, byte[] imagen, out string mensaje)
        {
            mensaje = string.Empty;
            if (obj.Documento == "")
            {
                mensaje += "Es necesario el documento del transportista.\n";
            }
            if (obj.Nombres == "")
            {
                mensaje += "Es necesario los dos nombres del transportista.\n";
            }
            if (obj.Apellidos == "")
            {
                mensaje += "Es necesario los dos apellidos del transportista.\n";
            }
            if (obj.Cedula == "")
            {
                mensaje += "Es necesario la cédula del transportista.\n";
            }
            if (obj.Telefono == "")
            {
                mensaje += "Es necesario el teléfono del transportista.\n";
            }
            if (obj.CorreoElectronico == "")
            {
                mensaje += "Es necesario el correo electrénico del transportista.\n";
            }
            if (mensaje != string.Empty)
            {
                return false;
            }
            else
            {
                return objecto.editarTransportista(obj, imagen, out mensaje);
            }
        }
        public bool elitrSQL(Transportista obj, out string mensaje)
        {
            return objecto.eliminarTransportista(obj, out mensaje);
        }
    }
}
