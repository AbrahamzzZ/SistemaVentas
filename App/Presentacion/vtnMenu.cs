using Entidad;
using Negocios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Presentacion
{
    /// <summary>
    /// Clase que representa la ventana de menú.
    /// </summary>
    public partial class VtnMenu : Form
    {
        private Usuario_Catched nombreUsuarioActual;
        private static Form formularioActivo = null;

        /// <summary> 
        /// Constructor de la clase VtnMenu. 
        /// Inicializa una nueva instancia de VtnMenu con el usuario proporcionado. 
        /// </summary>
        /// <param name="objusuario">Objeto Usuario_Catched que contiene la información del usuario actual.</param>
        public VtnMenu(Usuario_Catched objusuario)
        {
            nombreUsuarioActual = objusuario;
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        private void VtnMenu_Load(object sender, EventArgs e)
        {
            List<Permiso> listaVerificar = new CN_Permiso().Permisos(nombreUsuarioActual.IdUsuario);

            foreach (ToolStripMenuItem iconMenu in MenuPrincipal.Items)
            {
                bool encontrado = listaVerificar.Any(m => m.NombreMenu == iconMenu.Name);
                if (encontrado == false)
                {
                    iconMenu.Visible = false;
                }
            }
            LblUsuario.Text = nombreUsuarioActual.NombreCompleto;
            FechaHora.Enabled = true;
        }

        private void VerPanel(Form formulario)
        {
            if (formularioActivo != null)
            {
                formularioActivo.Close();
            }
            formularioActivo = formulario;
            formulario.TopLevel = false;
            formulario.FormBorderStyle = FormBorderStyle.None;
            formulario.Dock = DockStyle.Fill;
            panel.Controls.Add(formulario);
            formulario.Show();
        }

        private void MenuItemVerUsuarios_Click_1(object sender, EventArgs e)
        {
            VerPanel(new VtnUsuarios());
        }

        private void MenuItemZonaAlmacen_Click(object sender, EventArgs e)
        {
            VerPanel(new VtnInventario());
        }

        private void MenuItemCategoría_Click(object sender, EventArgs e)
        {
            VerPanel(new VtnCategoria());
        }

        private void MenuItemProducto_Click_1(object sender, EventArgs e)
        {
            VerPanel(new VtnProducto());
        }
        private void MenuItemUnidadesMedida_Click(object sender, EventArgs e)
        {
            VerPanel(new VtnUnidadMedida());
        }

        private void MenuItemRealizarVenta_Click(object sender, EventArgs e)
        {
            VerPanel(new VtnVenta(nombreUsuarioActual));
        }
        private void MenuItemVerDetallesVenta_Click(object sender, EventArgs e)
        {
            VerPanel(new VtnVerDetalleVentas());
        }
        private void MenuItemRealizarCompra_Click(object sender, EventArgs e)
        {
            VerPanel(new VtnCompra(nombreUsuarioActual));
        }

        private void MenuItemVerDetallesCompra_Click(object sender, EventArgs e)
        {
            VerPanel(new VtnVerDetalleCompras());
        }
        private void MenuItemVerProveedores_Click(object sender, EventArgs e)
        {
            VerPanel(new VtnProveedor());
        }

        private void MenuItemVerTransportistas_Click(object sender, EventArgs e)
        {
            VerPanel(new VtnTransportista());
        }
        private void MenuItemVerSucursales_Click(object sender, EventArgs e)
        {
            VerPanel(new VtnSucursal());
        }
        private void MenuItemVerClientes_Click(object sender, EventArgs e)
        {
            VerPanel(new VtnCliente());
        }
        private void MenuItemReportesCompras_Click(object sender, EventArgs e)
        {
            VerPanel(new vtnReportesCompras());
        }

        private void MenuItemGraficasCompras_Click(object sender, EventArgs e)
        {
            VerPanel(new VtnGraficaCompras());
        }

        private void MenuItemReportesVentas_Click(object sender, EventArgs e)
        {
            VerPanel(new vtnReportesVentas());
        }

        private void MenuItemGraficasVentas_Click(object sender, EventArgs e)
        {
            VerPanel(new VtnEstadisticaVentas());
        }
        private void MenuItemVerOfertas_Click(object sender, EventArgs e)
        {
            VerPanel(new VtnOferta());
        }

        private void MenuItemVerReclamos_Click(object sender, EventArgs e)
        {
            //VerPanel(new VtnReclamo());
        }
        private void MenuItemVerNegocio_Click(object sender, EventArgs e)
        {
            VerPanel(new VtnInformacionNegocio());
        }

        private void MenuItemVerAutor_Click(object sender, EventArgs e)
        {
            VerPanel(new VtnAutor());
        }

        private void MenuItemVerPrograma_Click(object sender, EventArgs e)
        {
            VerPanel(new VtnInformacionPrograma());
        }

        private void FechaHora_Tick(object sender, EventArgs e)
        {
            LblHora.Text = DateTime.Now.ToString("hh:mm:ss");
            LblFecha.Text = DateTime.Now.ToLongDateString();
        }

        private void BtnRegresar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea salir del sistema?", "Menú principal", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
