namespace Presentacion
{
    partial class VtnMenu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VtnMenu));
            this.BtnRegresar = new System.Windows.Forms.Button();
            this.FechaHora = new System.Windows.Forms.Timer(this.components);
            this.MenuPrincipal = new System.Windows.Forms.MenuStrip();
            this.MenuUsuarios = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemVerUsuarios = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuMantenimiento = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemInventario = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.menuItemUnidadesMedida = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
            this.menuItemCategoría = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.menuItemProducto = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuCompras = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemRealizarCompra = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.menuItemVerDetallesCompra = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuVentas = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemRealizarVenta = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.menuItemVerDetallesVenta = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuProveedores = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemVerProveedores = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuTransportistas = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemVerTransportistas = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuSucursales = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemVerSucursales = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuClientes = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemVerClientes = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuReportes = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemReportesCompras = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.menuItemGraficasCompras = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.menuItemReportesVentas = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.menuItemGraficasVentas = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuOfertas = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemVerOfertas = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuReclamos = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemVerReclamos = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuAcercaDe = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemNegocio = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.menuItemAutor = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.menuItemPrograma = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuTitulo = new System.Windows.Forms.MenuStrip();
            this.panel = new System.Windows.Forms.Panel();
            this.LblTitulo = new System.Windows.Forms.Label();
            this.LblUsuario = new System.Windows.Forms.Label();
            this.LblFecha = new System.Windows.Forms.Label();
            this.LblHora = new System.Windows.Forms.Label();
            this.PictureBoxLogo = new System.Windows.Forms.PictureBox();
            this.MenuPrincipal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnRegresar
            // 
            this.BtnRegresar.BackColor = System.Drawing.Color.Wheat;
            this.BtnRegresar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnRegresar.FlatAppearance.BorderColor = System.Drawing.Color.Wheat;
            this.BtnRegresar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnRegresar.Image = global::Presentacion.Properties.Resources.salir;
            this.BtnRegresar.Location = new System.Drawing.Point(1301, 78);
            this.BtnRegresar.Margin = new System.Windows.Forms.Padding(4);
            this.BtnRegresar.Name = "BtnRegresar";
            this.BtnRegresar.Size = new System.Drawing.Size(81, 73);
            this.BtnRegresar.TabIndex = 2;
            this.BtnRegresar.UseVisualStyleBackColor = false;
            this.BtnRegresar.Click += new System.EventHandler(this.BtnRegresar_Click);
            // 
            // FechaHora
            // 
            this.FechaHora.Tick += new System.EventHandler(this.FechaHora_Tick);
            // 
            // MenuPrincipal
            // 
            this.MenuPrincipal.AutoSize = false;
            this.MenuPrincipal.BackColor = System.Drawing.Color.Wheat;
            this.MenuPrincipal.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.MenuPrincipal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuUsuarios,
            this.MenuMantenimiento,
            this.MenuCompras,
            this.MenuVentas,
            this.MenuProveedores,
            this.MenuTransportistas,
            this.MenuSucursales,
            this.MenuClientes,
            this.MenuReportes,
            this.MenuOfertas,
            this.MenuReclamos,
            this.MenuAcercaDe});
            this.MenuPrincipal.Location = new System.Drawing.Point(0, 78);
            this.MenuPrincipal.Name = "MenuPrincipal";
            this.MenuPrincipal.Size = new System.Drawing.Size(1382, 73);
            this.MenuPrincipal.TabIndex = 13;
            this.MenuPrincipal.Text = "menuStrip1";
            // 
            // MenuUsuarios
            // 
            this.MenuUsuarios.BackColor = System.Drawing.Color.Wheat;
            this.MenuUsuarios.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemVerUsuarios});
            this.MenuUsuarios.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MenuUsuarios.Image = global::Presentacion.Properties.Resources.usuarios;
            this.MenuUsuarios.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.MenuUsuarios.Name = "MenuUsuarios";
            this.MenuUsuarios.Size = new System.Drawing.Size(89, 69);
            this.MenuUsuarios.Text = "Usuarios";
            this.MenuUsuarios.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.MenuUsuarios.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // menuItemVerUsuarios
            // 
            this.menuItemVerUsuarios.BackColor = System.Drawing.Color.Wheat;
            this.menuItemVerUsuarios.Name = "menuItemVerUsuarios";
            this.menuItemVerUsuarios.Size = new System.Drawing.Size(224, 28);
            this.menuItemVerUsuarios.Text = "Ver usuarios";
            this.menuItemVerUsuarios.Click += new System.EventHandler(this.MenuItemVerUsuarios_Click_1);
            // 
            // MenuMantenimiento
            // 
            this.MenuMantenimiento.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemInventario,
            this.toolStripSeparator1,
            this.menuItemUnidadesMedida,
            this.toolStripSeparator10,
            this.menuItemCategoría,
            this.toolStripSeparator2,
            this.menuItemProducto});
            this.MenuMantenimiento.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MenuMantenimiento.Image = global::Presentacion.Properties.Resources.mantenimiento;
            this.MenuMantenimiento.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.MenuMantenimiento.Name = "MenuMantenimiento";
            this.MenuMantenimiento.Size = new System.Drawing.Size(141, 69);
            this.MenuMantenimiento.Text = "Mantenimiento";
            this.MenuMantenimiento.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.MenuMantenimiento.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // menuItemInventario
            // 
            this.menuItemInventario.BackColor = System.Drawing.Color.Wheat;
            this.menuItemInventario.Name = "menuItemInventario";
            this.menuItemInventario.Size = new System.Drawing.Size(224, 28);
            this.menuItemInventario.Text = "Inventario";
            this.menuItemInventario.Click += new System.EventHandler(this.MenuItemInventario_Click_1);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.BackColor = System.Drawing.Color.Black;
            this.toolStripSeparator1.ForeColor = System.Drawing.Color.Black;
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(221, 6);
            // 
            // menuItemUnidadesMedida
            // 
            this.menuItemUnidadesMedida.BackColor = System.Drawing.Color.Wheat;
            this.menuItemUnidadesMedida.Name = "menuItemUnidadesMedida";
            this.menuItemUnidadesMedida.Size = new System.Drawing.Size(224, 28);
            this.menuItemUnidadesMedida.Text = "Unidad Medida";
            this.menuItemUnidadesMedida.Click += new System.EventHandler(this.MenuItemUnidadesMedida_Click);
            // 
            // toolStripSeparator10
            // 
            this.toolStripSeparator10.Name = "toolStripSeparator10";
            this.toolStripSeparator10.Size = new System.Drawing.Size(221, 6);
            // 
            // menuItemCategoría
            // 
            this.menuItemCategoría.BackColor = System.Drawing.Color.Wheat;
            this.menuItemCategoría.Name = "menuItemCategoría";
            this.menuItemCategoría.Size = new System.Drawing.Size(224, 28);
            this.menuItemCategoría.Text = "Categoría";
            this.menuItemCategoría.Click += new System.EventHandler(this.MenuItemCategoría_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(221, 6);
            // 
            // menuItemProducto
            // 
            this.menuItemProducto.BackColor = System.Drawing.Color.Wheat;
            this.menuItemProducto.Name = "menuItemProducto";
            this.menuItemProducto.Size = new System.Drawing.Size(224, 28);
            this.menuItemProducto.Text = "Producto";
            this.menuItemProducto.Click += new System.EventHandler(this.MenuItemProducto_Click_1);
            // 
            // MenuCompras
            // 
            this.MenuCompras.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemRealizarCompra,
            this.toolStripSeparator4,
            this.menuItemVerDetallesCompra});
            this.MenuCompras.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MenuCompras.Image = global::Presentacion.Properties.Resources.compra;
            this.MenuCompras.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.MenuCompras.Name = "MenuCompras";
            this.MenuCompras.Size = new System.Drawing.Size(92, 69);
            this.MenuCompras.Text = "Compras";
            this.MenuCompras.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.MenuCompras.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // menuItemRealizarCompra
            // 
            this.menuItemRealizarCompra.BackColor = System.Drawing.Color.Wheat;
            this.menuItemRealizarCompra.Name = "menuItemRealizarCompra";
            this.menuItemRealizarCompra.Size = new System.Drawing.Size(224, 28);
            this.menuItemRealizarCompra.Text = "Realizar compra";
            this.menuItemRealizarCompra.Click += new System.EventHandler(this.MenuItemRealizarCompra_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(221, 6);
            // 
            // menuItemVerDetallesCompra
            // 
            this.menuItemVerDetallesCompra.BackColor = System.Drawing.Color.Wheat;
            this.menuItemVerDetallesCompra.Name = "menuItemVerDetallesCompra";
            this.menuItemVerDetallesCompra.Size = new System.Drawing.Size(224, 28);
            this.menuItemVerDetallesCompra.Text = "Ver detalles";
            this.menuItemVerDetallesCompra.Click += new System.EventHandler(this.MenuItemVerDetallesCompra_Click);
            // 
            // MenuVentas
            // 
            this.MenuVentas.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemRealizarVenta,
            this.toolStripSeparator3,
            this.menuItemVerDetallesVenta});
            this.MenuVentas.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MenuVentas.Image = global::Presentacion.Properties.Resources.precio;
            this.MenuVentas.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.MenuVentas.Name = "MenuVentas";
            this.MenuVentas.Size = new System.Drawing.Size(75, 69);
            this.MenuVentas.Text = "Ventas";
            this.MenuVentas.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.MenuVentas.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // menuItemRealizarVenta
            // 
            this.menuItemRealizarVenta.BackColor = System.Drawing.Color.Wheat;
            this.menuItemRealizarVenta.Name = "menuItemRealizarVenta";
            this.menuItemRealizarVenta.Size = new System.Drawing.Size(224, 28);
            this.menuItemRealizarVenta.Text = "Realizar venta";
            this.menuItemRealizarVenta.Click += new System.EventHandler(this.MenuItemRealizarVenta_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(221, 6);
            // 
            // menuItemVerDetallesVenta
            // 
            this.menuItemVerDetallesVenta.BackColor = System.Drawing.Color.Wheat;
            this.menuItemVerDetallesVenta.Name = "menuItemVerDetallesVenta";
            this.menuItemVerDetallesVenta.Size = new System.Drawing.Size(224, 28);
            this.menuItemVerDetallesVenta.Text = "Ver detalles";
            this.menuItemVerDetallesVenta.Click += new System.EventHandler(this.MenuItemVerDetallesVenta_Click);
            // 
            // MenuProveedores
            // 
            this.MenuProveedores.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemVerProveedores});
            this.MenuProveedores.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MenuProveedores.Image = global::Presentacion.Properties.Resources.proveedor;
            this.MenuProveedores.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.MenuProveedores.Name = "MenuProveedores";
            this.MenuProveedores.Size = new System.Drawing.Size(118, 69);
            this.MenuProveedores.Text = "Proveedores";
            this.MenuProveedores.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.MenuProveedores.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // menuItemVerProveedores
            // 
            this.menuItemVerProveedores.BackColor = System.Drawing.Color.Wheat;
            this.menuItemVerProveedores.Name = "menuItemVerProveedores";
            this.menuItemVerProveedores.Size = new System.Drawing.Size(224, 28);
            this.menuItemVerProveedores.Text = "Ver proveedores";
            this.menuItemVerProveedores.Click += new System.EventHandler(this.MenuItemVerProveedores_Click);
            // 
            // MenuTransportistas
            // 
            this.MenuTransportistas.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemVerTransportistas});
            this.MenuTransportistas.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MenuTransportistas.Image = global::Presentacion.Properties.Resources.transportista;
            this.MenuTransportistas.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.MenuTransportistas.Name = "MenuTransportistas";
            this.MenuTransportistas.Size = new System.Drawing.Size(129, 69);
            this.MenuTransportistas.Text = "Transportistas";
            this.MenuTransportistas.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.MenuTransportistas.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // menuItemVerTransportistas
            // 
            this.menuItemVerTransportistas.BackColor = System.Drawing.Color.Wheat;
            this.menuItemVerTransportistas.Name = "menuItemVerTransportistas";
            this.menuItemVerTransportistas.Size = new System.Drawing.Size(227, 28);
            this.menuItemVerTransportistas.Text = "Ver transportistas";
            this.menuItemVerTransportistas.Click += new System.EventHandler(this.MenuItemVerTransportistas_Click);
            // 
            // MenuSucursales
            // 
            this.MenuSucursales.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemVerSucursales});
            this.MenuSucursales.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MenuSucursales.Image = global::Presentacion.Properties.Resources.sucursal;
            this.MenuSucursales.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.MenuSucursales.Name = "MenuSucursales";
            this.MenuSucursales.Size = new System.Drawing.Size(103, 69);
            this.MenuSucursales.Text = "Sucursales";
            this.MenuSucursales.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.MenuSucursales.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // menuItemVerSucursales
            // 
            this.menuItemVerSucursales.BackColor = System.Drawing.Color.Wheat;
            this.menuItemVerSucursales.Name = "menuItemVerSucursales";
            this.menuItemVerSucursales.Size = new System.Drawing.Size(224, 28);
            this.menuItemVerSucursales.Text = "Ver sucursales";
            this.menuItemVerSucursales.Click += new System.EventHandler(this.MenuItemVerSucursales_Click);
            // 
            // MenuClientes
            // 
            this.MenuClientes.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemVerClientes});
            this.MenuClientes.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MenuClientes.Image = global::Presentacion.Properties.Resources.clientes;
            this.MenuClientes.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.MenuClientes.Name = "MenuClientes";
            this.MenuClientes.Size = new System.Drawing.Size(84, 69);
            this.MenuClientes.Text = "Clientes";
            this.MenuClientes.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.MenuClientes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // menuItemVerClientes
            // 
            this.menuItemVerClientes.BackColor = System.Drawing.Color.Wheat;
            this.menuItemVerClientes.Name = "menuItemVerClientes";
            this.menuItemVerClientes.Size = new System.Drawing.Size(224, 28);
            this.menuItemVerClientes.Text = "Ver clientes";
            this.menuItemVerClientes.Click += new System.EventHandler(this.MenuItemVerClientes_Click);
            // 
            // MenuReportes
            // 
            this.MenuReportes.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemReportesCompras,
            this.toolStripSeparator5,
            this.menuItemGraficasCompras,
            this.toolStripSeparator6,
            this.menuItemReportesVentas,
            this.toolStripSeparator7,
            this.menuItemGraficasVentas});
            this.MenuReportes.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MenuReportes.Image = global::Presentacion.Properties.Resources.reporte;
            this.MenuReportes.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.MenuReportes.Name = "MenuReportes";
            this.MenuReportes.Size = new System.Drawing.Size(91, 69);
            this.MenuReportes.Text = "Reportes";
            this.MenuReportes.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.MenuReportes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // menuItemReportesCompras
            // 
            this.menuItemReportesCompras.BackColor = System.Drawing.Color.Wheat;
            this.menuItemReportesCompras.Name = "menuItemReportesCompras";
            this.menuItemReportesCompras.Size = new System.Drawing.Size(231, 28);
            this.menuItemReportesCompras.Text = "Reportes compras";
            this.menuItemReportesCompras.Click += new System.EventHandler(this.MenuItemReportesCompras_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(228, 6);
            // 
            // menuItemGraficasCompras
            // 
            this.menuItemGraficasCompras.BackColor = System.Drawing.Color.Wheat;
            this.menuItemGraficasCompras.Name = "menuItemGraficasCompras";
            this.menuItemGraficasCompras.Size = new System.Drawing.Size(231, 28);
            this.menuItemGraficasCompras.Text = "Gráficas compras";
            this.menuItemGraficasCompras.Click += new System.EventHandler(this.MenuItemGraficasCompras_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(228, 6);
            // 
            // menuItemReportesVentas
            // 
            this.menuItemReportesVentas.BackColor = System.Drawing.Color.Wheat;
            this.menuItemReportesVentas.Name = "menuItemReportesVentas";
            this.menuItemReportesVentas.Size = new System.Drawing.Size(231, 28);
            this.menuItemReportesVentas.Text = "Reporte ventas";
            this.menuItemReportesVentas.Click += new System.EventHandler(this.MenuItemReportesVentas_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(228, 6);
            // 
            // menuItemGraficasVentas
            // 
            this.menuItemGraficasVentas.BackColor = System.Drawing.Color.Wheat;
            this.menuItemGraficasVentas.Name = "menuItemGraficasVentas";
            this.menuItemGraficasVentas.Size = new System.Drawing.Size(231, 28);
            this.menuItemGraficasVentas.Text = "Gráficas ventas";
            this.menuItemGraficasVentas.Click += new System.EventHandler(this.MenuItemGraficasVentas_Click);
            // 
            // MenuOfertas
            // 
            this.MenuOfertas.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemVerOfertas});
            this.MenuOfertas.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MenuOfertas.Image = global::Presentacion.Properties.Resources.oferta;
            this.MenuOfertas.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.MenuOfertas.Name = "MenuOfertas";
            this.MenuOfertas.Size = new System.Drawing.Size(79, 69);
            this.MenuOfertas.Text = "Ofertas";
            this.MenuOfertas.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.MenuOfertas.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // menuItemVerOfertas
            // 
            this.menuItemVerOfertas.BackColor = System.Drawing.Color.Wheat;
            this.menuItemVerOfertas.Name = "menuItemVerOfertas";
            this.menuItemVerOfertas.Size = new System.Drawing.Size(224, 28);
            this.menuItemVerOfertas.Text = "Ver ofertas";
            this.menuItemVerOfertas.Click += new System.EventHandler(this.MenuItemVerOfertas_Click);
            // 
            // MenuReclamos
            // 
            this.MenuReclamos.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemVerReclamos});
            this.MenuReclamos.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MenuReclamos.Image = global::Presentacion.Properties.Resources.reclamo;
            this.MenuReclamos.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.MenuReclamos.Name = "MenuReclamos";
            this.MenuReclamos.Size = new System.Drawing.Size(96, 69);
            this.MenuReclamos.Text = "Reclamos";
            this.MenuReclamos.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.MenuReclamos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // menuItemVerReclamos
            // 
            this.menuItemVerReclamos.BackColor = System.Drawing.Color.Wheat;
            this.menuItemVerReclamos.Name = "menuItemVerReclamos";
            this.menuItemVerReclamos.Size = new System.Drawing.Size(224, 28);
            this.menuItemVerReclamos.Text = "Ver reclamos";
            this.menuItemVerReclamos.Click += new System.EventHandler(this.MenuItemVerReclamos_Click);
            // 
            // MenuAcercaDe
            // 
            this.MenuAcercaDe.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemNegocio,
            this.toolStripSeparator8,
            this.menuItemAutor,
            this.toolStripSeparator9,
            this.menuItemPrograma});
            this.MenuAcercaDe.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MenuAcercaDe.Image = global::Presentacion.Properties.Resources.informacion;
            this.MenuAcercaDe.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.MenuAcercaDe.Name = "MenuAcercaDe";
            this.MenuAcercaDe.Size = new System.Drawing.Size(99, 69);
            this.MenuAcercaDe.Text = "Acerca de";
            this.MenuAcercaDe.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.MenuAcercaDe.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // menuItemNegocio
            // 
            this.menuItemNegocio.BackColor = System.Drawing.Color.Wheat;
            this.menuItemNegocio.Name = "menuItemNegocio";
            this.menuItemNegocio.Size = new System.Drawing.Size(224, 28);
            this.menuItemNegocio.Text = "Negocio";
            this.menuItemNegocio.Click += new System.EventHandler(this.MenuItemVerNegocio_Click);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(221, 6);
            // 
            // menuItemAutor
            // 
            this.menuItemAutor.BackColor = System.Drawing.Color.Wheat;
            this.menuItemAutor.Name = "menuItemAutor";
            this.menuItemAutor.Size = new System.Drawing.Size(224, 28);
            this.menuItemAutor.Text = "Autor";
            this.menuItemAutor.Click += new System.EventHandler(this.MenuItemVerAutor_Click);
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            this.toolStripSeparator9.Size = new System.Drawing.Size(221, 6);
            // 
            // menuItemPrograma
            // 
            this.menuItemPrograma.BackColor = System.Drawing.Color.Wheat;
            this.menuItemPrograma.Name = "menuItemPrograma";
            this.menuItemPrograma.Size = new System.Drawing.Size(224, 28);
            this.menuItemPrograma.Text = "Programa";
            this.menuItemPrograma.Click += new System.EventHandler(this.MenuItemVerPrograma_Click);
            // 
            // MenuTitulo
            // 
            this.MenuTitulo.AutoSize = false;
            this.MenuTitulo.BackColor = System.Drawing.Color.White;
            this.MenuTitulo.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.MenuTitulo.Location = new System.Drawing.Point(0, 0);
            this.MenuTitulo.Name = "MenuTitulo";
            this.MenuTitulo.Size = new System.Drawing.Size(1382, 78);
            this.MenuTitulo.TabIndex = 14;
            // 
            // panel
            // 
            this.panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel.Location = new System.Drawing.Point(0, 151);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(1382, 602);
            this.panel.TabIndex = 15;
            // 
            // LblTitulo
            // 
            this.LblTitulo.AutoSize = true;
            this.LblTitulo.BackColor = System.Drawing.Color.White;
            this.LblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTitulo.Location = new System.Drawing.Point(570, 24);
            this.LblTitulo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LblTitulo.Name = "LblTitulo";
            this.LblTitulo.Size = new System.Drawing.Size(269, 32);
            this.LblTitulo.TabIndex = 16;
            this.LblTitulo.Text = "Sistema de Ventas";
            // 
            // LblUsuario
            // 
            this.LblUsuario.AutoSize = true;
            this.LblUsuario.BackColor = System.Drawing.Color.White;
            this.LblUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblUsuario.Location = new System.Drawing.Point(13, 46);
            this.LblUsuario.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LblUsuario.Name = "LblUsuario";
            this.LblUsuario.Size = new System.Drawing.Size(94, 20);
            this.LblUsuario.TabIndex = 17;
            this.LblUsuario.Text = "lblUsuario";
            // 
            // LblFecha
            // 
            this.LblFecha.AutoSize = true;
            this.LblFecha.BackColor = System.Drawing.Color.White;
            this.LblFecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblFecha.Location = new System.Drawing.Point(13, 9);
            this.LblFecha.Name = "LblFecha";
            this.LblFecha.Size = new System.Drawing.Size(60, 20);
            this.LblFecha.TabIndex = 18;
            this.LblFecha.Text = "Fecha";
            // 
            // LblHora
            // 
            this.LblHora.AutoSize = true;
            this.LblHora.BackColor = System.Drawing.Color.White;
            this.LblHora.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblHora.Location = new System.Drawing.Point(1281, 32);
            this.LblHora.Name = "LblHora";
            this.LblHora.Size = new System.Drawing.Size(46, 20);
            this.LblHora.TabIndex = 19;
            this.LblHora.Text = "hora";
            // 
            // PictureBoxLogo
            // 
            this.PictureBoxLogo.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.PictureBoxLogo.Image = global::Presentacion.Properties.Resources.Logo1;
            this.PictureBoxLogo.Location = new System.Drawing.Point(847, 0);
            this.PictureBoxLogo.Margin = new System.Windows.Forms.Padding(4);
            this.PictureBoxLogo.Name = "PictureBoxLogo";
            this.PictureBoxLogo.Size = new System.Drawing.Size(75, 78);
            this.PictureBoxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PictureBoxLogo.TabIndex = 20;
            this.PictureBoxLogo.TabStop = false;
            // 
            // VtnMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(1382, 753);
            this.Controls.Add(this.PictureBoxLogo);
            this.Controls.Add(this.BtnRegresar);
            this.Controls.Add(this.LblHora);
            this.Controls.Add(this.LblFecha);
            this.Controls.Add(this.LblUsuario);
            this.Controls.Add(this.LblTitulo);
            this.Controls.Add(this.panel);
            this.Controls.Add(this.MenuPrincipal);
            this.Controls.Add(this.MenuTitulo);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "VtnMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menú principal";
            this.Load += new System.EventHandler(this.VtnMenu_Load);
            this.MenuPrincipal.ResumeLayout(false);
            this.MenuPrincipal.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer FechaHora;
        private System.Windows.Forms.Button BtnRegresar;
        private System.Windows.Forms.MenuStrip MenuPrincipal;
        private System.Windows.Forms.MenuStrip MenuTitulo;
        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.ToolStripMenuItem MenuUsuarios;
        private System.Windows.Forms.Label LblTitulo;
        private System.Windows.Forms.Label LblUsuario;
        private System.Windows.Forms.Label LblFecha;
        private System.Windows.Forms.Label LblHora;
        private System.Windows.Forms.ToolStripMenuItem menuItemVerUsuarios;
        private System.Windows.Forms.PictureBox PictureBoxLogo;
        private System.Windows.Forms.ToolStripMenuItem MenuMantenimiento;
        private System.Windows.Forms.ToolStripMenuItem menuItemInventario;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem menuItemCategoría;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem menuItemProducto;
        private System.Windows.Forms.ToolStripMenuItem MenuVentas;
        private System.Windows.Forms.ToolStripMenuItem menuItemRealizarVenta;
        private System.Windows.Forms.ToolStripMenuItem MenuCompras;
        private System.Windows.Forms.ToolStripMenuItem menuItemRealizarCompra;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem menuItemVerDetallesVenta;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem menuItemVerDetallesCompra;
        private System.Windows.Forms.ToolStripMenuItem MenuProveedores;
        private System.Windows.Forms.ToolStripMenuItem menuItemVerProveedores;
        private System.Windows.Forms.ToolStripMenuItem MenuTransportistas;
        private System.Windows.Forms.ToolStripMenuItem MenuSucursales;
        private System.Windows.Forms.ToolStripMenuItem menuItemVerTransportistas;
        private System.Windows.Forms.ToolStripMenuItem menuItemVerSucursales;
        private System.Windows.Forms.ToolStripMenuItem MenuClientes;
        private System.Windows.Forms.ToolStripMenuItem menuItemVerClientes;
        private System.Windows.Forms.ToolStripMenuItem MenuReportes;
        private System.Windows.Forms.ToolStripMenuItem menuItemReportesCompras;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem menuItemGraficasCompras;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem menuItemReportesVentas;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripMenuItem menuItemGraficasVentas;
        private System.Windows.Forms.ToolStripMenuItem MenuOfertas;
        private System.Windows.Forms.ToolStripMenuItem menuItemVerOfertas;
        private System.Windows.Forms.ToolStripMenuItem MenuReclamos;
        private System.Windows.Forms.ToolStripMenuItem MenuAcercaDe;
        private System.Windows.Forms.ToolStripMenuItem menuItemVerReclamos;
        private System.Windows.Forms.ToolStripMenuItem menuItemNegocio;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripMenuItem menuItemAutor;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
        private System.Windows.Forms.ToolStripMenuItem menuItemPrograma;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator10;
        private System.Windows.Forms.ToolStripMenuItem menuItemUnidadesMedida;
    }
}