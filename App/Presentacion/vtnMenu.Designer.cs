namespace Presentacion
{
    partial class vtnMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(vtnMenu));
            this.btnRegresar = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.menu2 = new System.Windows.Forms.MenuStrip();
            this.menuUsuarios = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemVerUsuarios = new System.Windows.Forms.ToolStripMenuItem();
            this.menuMantenimiento = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemInventario = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.menuItemCategoría = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.menuItemProducto = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
            this.menuItemUnidadesMedida = new System.Windows.Forms.ToolStripMenuItem();
            this.menuCompras = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemRealizarCompra = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.menuItemVerDetallesCompra = new System.Windows.Forms.ToolStripMenuItem();
            this.menuVentas = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemRealizarVenta = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.menuItemVerDetallesVenta = new System.Windows.Forms.ToolStripMenuItem();
            this.menuProveedores = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemVerProveedores = new System.Windows.Forms.ToolStripMenuItem();
            this.menuTransportistas = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemVerTransportistas = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSucursales = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemVerSucursales = new System.Windows.Forms.ToolStripMenuItem();
            this.menuClientes = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemVerClientes = new System.Windows.Forms.ToolStripMenuItem();
            this.menuReportes = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemReportesCompras = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.menuItemGraficasCompras = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.menuItemReportesVentas = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.menuItemGraficasVentas = new System.Windows.Forms.ToolStripMenuItem();
            this.menuOfertas = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemVerOfertas = new System.Windows.Forms.ToolStripMenuItem();
            this.menuReclamos = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemVerReclamos = new System.Windows.Forms.ToolStripMenuItem();
            this.menuAcercaDe = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemNegocio = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.menuItemAutor = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.menuItemPrograma = new System.Windows.Forms.ToolStripMenuItem();
            this.menu1 = new System.Windows.Forms.MenuStrip();
            this.panel = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lbl2 = new System.Windows.Forms.Label();
            this.lblFecha = new System.Windows.Forms.Label();
            this.lblHora = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.menu2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnRegresar
            // 
            this.btnRegresar.BackColor = System.Drawing.Color.Wheat;
            this.btnRegresar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRegresar.FlatAppearance.BorderColor = System.Drawing.Color.Wheat;
            this.btnRegresar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegresar.Image = global::Presentacion.Properties.Resources.salir;
            this.btnRegresar.Location = new System.Drawing.Point(1301, 78);
            this.btnRegresar.Margin = new System.Windows.Forms.Padding(4);
            this.btnRegresar.Name = "btnRegresar";
            this.btnRegresar.Size = new System.Drawing.Size(81, 73);
            this.btnRegresar.TabIndex = 2;
            this.btnRegresar.UseVisualStyleBackColor = false;
            this.btnRegresar.Click += new System.EventHandler(this.btnRegresar_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // menu2
            // 
            this.menu2.AutoSize = false;
            this.menu2.BackColor = System.Drawing.Color.Wheat;
            this.menu2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menu2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuUsuarios,
            this.menuMantenimiento,
            this.menuCompras,
            this.menuVentas,
            this.menuProveedores,
            this.menuTransportistas,
            this.menuSucursales,
            this.menuClientes,
            this.menuReportes,
            this.menuOfertas,
            this.menuReclamos,
            this.menuAcercaDe});
            this.menu2.Location = new System.Drawing.Point(0, 78);
            this.menu2.Name = "menu2";
            this.menu2.Size = new System.Drawing.Size(1382, 73);
            this.menu2.TabIndex = 13;
            this.menu2.Text = "menuStrip1";
            // 
            // menuUsuarios
            // 
            this.menuUsuarios.BackColor = System.Drawing.Color.Wheat;
            this.menuUsuarios.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemVerUsuarios});
            this.menuUsuarios.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuUsuarios.Image = global::Presentacion.Properties.Resources.usuarios;
            this.menuUsuarios.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menuUsuarios.Name = "menuUsuarios";
            this.menuUsuarios.Size = new System.Drawing.Size(89, 69);
            this.menuUsuarios.Text = "Usuarios";
            this.menuUsuarios.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.menuUsuarios.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // menuItemVerUsuarios
            // 
            this.menuItemVerUsuarios.BackColor = System.Drawing.Color.Wheat;
            this.menuItemVerUsuarios.Name = "menuItemVerUsuarios";
            this.menuItemVerUsuarios.Size = new System.Drawing.Size(187, 28);
            this.menuItemVerUsuarios.Text = "Ver usuarios";
            this.menuItemVerUsuarios.Click += new System.EventHandler(this.menuItemVerUsuarios_Click_1);
            // 
            // menuMantenimiento
            // 
            this.menuMantenimiento.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemInventario,
            this.toolStripSeparator1,
            this.menuItemUnidadesMedida,
            this.toolStripSeparator10,
            this.menuItemCategoría,
            this.toolStripSeparator2,
            this.menuItemProducto});
            this.menuMantenimiento.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuMantenimiento.Image = global::Presentacion.Properties.Resources.mantenimiento;
            this.menuMantenimiento.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menuMantenimiento.Name = "menuMantenimiento";
            this.menuMantenimiento.Size = new System.Drawing.Size(141, 69);
            this.menuMantenimiento.Text = "Mantenimiento";
            this.menuMantenimiento.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.menuMantenimiento.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // menuItemInventario
            // 
            this.menuItemInventario.BackColor = System.Drawing.Color.Wheat;
            this.menuItemInventario.Name = "menuItemInventario";
            this.menuItemInventario.Size = new System.Drawing.Size(224, 28);
            this.menuItemInventario.Text = "Inventario";
            this.menuItemInventario.Click += new System.EventHandler(this.menuItemInventario_Click_1);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.BackColor = System.Drawing.Color.Black;
            this.toolStripSeparator1.ForeColor = System.Drawing.Color.Black;
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(221, 6);
            // 
            // menuItemCategoría
            // 
            this.menuItemCategoría.BackColor = System.Drawing.Color.Wheat;
            this.menuItemCategoría.Name = "menuItemCategoría";
            this.menuItemCategoría.Size = new System.Drawing.Size(224, 28);
            this.menuItemCategoría.Text = "Categoría";
            this.menuItemCategoría.Click += new System.EventHandler(this.menuItemCategoría_Click);
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
            this.menuItemProducto.Click += new System.EventHandler(this.menuItemProducto_Click_1);
            // 
            // toolStripSeparator10
            // 
            this.toolStripSeparator10.Name = "toolStripSeparator10";
            this.toolStripSeparator10.Size = new System.Drawing.Size(221, 6);
            // 
            // menuItemUnidadesMedida
            // 
            this.menuItemUnidadesMedida.BackColor = System.Drawing.Color.Wheat;
            this.menuItemUnidadesMedida.Name = "menuItemUnidadesMedida";
            this.menuItemUnidadesMedida.Size = new System.Drawing.Size(224, 28);
            this.menuItemUnidadesMedida.Text = "Unidad Medida";
            this.menuItemUnidadesMedida.Click += new System.EventHandler(this.menuItemUnidadesMedida_Click);
            // 
            // menuCompras
            // 
            this.menuCompras.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemRealizarCompra,
            this.toolStripSeparator4,
            this.menuItemVerDetallesCompra});
            this.menuCompras.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuCompras.Image = global::Presentacion.Properties.Resources.compra;
            this.menuCompras.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menuCompras.Name = "menuCompras";
            this.menuCompras.Size = new System.Drawing.Size(92, 69);
            this.menuCompras.Text = "Compras";
            this.menuCompras.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.menuCompras.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // menuItemRealizarCompra
            // 
            this.menuItemRealizarCompra.BackColor = System.Drawing.Color.Wheat;
            this.menuItemRealizarCompra.Name = "menuItemRealizarCompra";
            this.menuItemRealizarCompra.Size = new System.Drawing.Size(216, 28);
            this.menuItemRealizarCompra.Text = "Realizar compra";
            this.menuItemRealizarCompra.Click += new System.EventHandler(this.menuItemRealizarCompra_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(213, 6);
            // 
            // menuItemVerDetallesCompra
            // 
            this.menuItemVerDetallesCompra.BackColor = System.Drawing.Color.Wheat;
            this.menuItemVerDetallesCompra.Name = "menuItemVerDetallesCompra";
            this.menuItemVerDetallesCompra.Size = new System.Drawing.Size(216, 28);
            this.menuItemVerDetallesCompra.Text = "Ver detalles";
            this.menuItemVerDetallesCompra.Click += new System.EventHandler(this.menuItemVerDetallesCompra_Click);
            // 
            // menuVentas
            // 
            this.menuVentas.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemRealizarVenta,
            this.toolStripSeparator3,
            this.menuItemVerDetallesVenta});
            this.menuVentas.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuVentas.Image = global::Presentacion.Properties.Resources.precio;
            this.menuVentas.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menuVentas.Name = "menuVentas";
            this.menuVentas.Size = new System.Drawing.Size(75, 69);
            this.menuVentas.Text = "Ventas";
            this.menuVentas.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.menuVentas.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // menuItemRealizarVenta
            // 
            this.menuItemRealizarVenta.BackColor = System.Drawing.Color.Wheat;
            this.menuItemRealizarVenta.Name = "menuItemRealizarVenta";
            this.menuItemRealizarVenta.Size = new System.Drawing.Size(200, 28);
            this.menuItemRealizarVenta.Text = "Realizar venta";
            this.menuItemRealizarVenta.Click += new System.EventHandler(this.menuItemRealizarVenta_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(197, 6);
            // 
            // menuItemVerDetallesVenta
            // 
            this.menuItemVerDetallesVenta.BackColor = System.Drawing.Color.Wheat;
            this.menuItemVerDetallesVenta.Name = "menuItemVerDetallesVenta";
            this.menuItemVerDetallesVenta.Size = new System.Drawing.Size(200, 28);
            this.menuItemVerDetallesVenta.Text = "Ver detalles";
            this.menuItemVerDetallesVenta.Click += new System.EventHandler(this.menuItemVerDetallesVenta_Click);
            // 
            // menuProveedores
            // 
            this.menuProveedores.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemVerProveedores});
            this.menuProveedores.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuProveedores.Image = global::Presentacion.Properties.Resources.proveedor;
            this.menuProveedores.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menuProveedores.Name = "menuProveedores";
            this.menuProveedores.Size = new System.Drawing.Size(118, 69);
            this.menuProveedores.Text = "Proveedores";
            this.menuProveedores.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.menuProveedores.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // menuItemVerProveedores
            // 
            this.menuItemVerProveedores.BackColor = System.Drawing.Color.Wheat;
            this.menuItemVerProveedores.Name = "menuItemVerProveedores";
            this.menuItemVerProveedores.Size = new System.Drawing.Size(218, 28);
            this.menuItemVerProveedores.Text = "Ver proveedores";
            this.menuItemVerProveedores.Click += new System.EventHandler(this.menuItemVerProveedores_Click);
            // 
            // menuTransportistas
            // 
            this.menuTransportistas.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemVerTransportistas});
            this.menuTransportistas.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuTransportistas.Image = global::Presentacion.Properties.Resources.transportista;
            this.menuTransportistas.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menuTransportistas.Name = "menuTransportistas";
            this.menuTransportistas.Size = new System.Drawing.Size(129, 69);
            this.menuTransportistas.Text = "Transportistas";
            this.menuTransportistas.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.menuTransportistas.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // menuItemVerTransportistas
            // 
            this.menuItemVerTransportistas.BackColor = System.Drawing.Color.Wheat;
            this.menuItemVerTransportistas.Name = "menuItemVerTransportistas";
            this.menuItemVerTransportistas.Size = new System.Drawing.Size(227, 28);
            this.menuItemVerTransportistas.Text = "Ver transportistas";
            this.menuItemVerTransportistas.Click += new System.EventHandler(this.menuItemVerTransportistas_Click);
            // 
            // menuSucursales
            // 
            this.menuSucursales.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemVerSucursales});
            this.menuSucursales.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuSucursales.Image = global::Presentacion.Properties.Resources.sucursal;
            this.menuSucursales.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menuSucursales.Name = "menuSucursales";
            this.menuSucursales.Size = new System.Drawing.Size(103, 69);
            this.menuSucursales.Text = "Sucursales";
            this.menuSucursales.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.menuSucursales.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // menuItemVerSucursales
            // 
            this.menuItemVerSucursales.BackColor = System.Drawing.Color.Wheat;
            this.menuItemVerSucursales.Name = "menuItemVerSucursales";
            this.menuItemVerSucursales.Size = new System.Drawing.Size(201, 28);
            this.menuItemVerSucursales.Text = "Ver sucursales";
            this.menuItemVerSucursales.Click += new System.EventHandler(this.menuItemVerSucursales_Click);
            // 
            // menuClientes
            // 
            this.menuClientes.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemVerClientes});
            this.menuClientes.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuClientes.Image = global::Presentacion.Properties.Resources.clientes;
            this.menuClientes.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menuClientes.Name = "menuClientes";
            this.menuClientes.Size = new System.Drawing.Size(84, 69);
            this.menuClientes.Text = "Clientes";
            this.menuClientes.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.menuClientes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // menuItemVerClientes
            // 
            this.menuItemVerClientes.BackColor = System.Drawing.Color.Wheat;
            this.menuItemVerClientes.Name = "menuItemVerClientes";
            this.menuItemVerClientes.Size = new System.Drawing.Size(181, 28);
            this.menuItemVerClientes.Text = "Ver clientes";
            this.menuItemVerClientes.Click += new System.EventHandler(this.menuItemVerClientes_Click);
            // 
            // menuReportes
            // 
            this.menuReportes.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemReportesCompras,
            this.toolStripSeparator5,
            this.menuItemGraficasCompras,
            this.toolStripSeparator6,
            this.menuItemReportesVentas,
            this.toolStripSeparator7,
            this.menuItemGraficasVentas});
            this.menuReportes.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuReportes.Image = global::Presentacion.Properties.Resources.reporte;
            this.menuReportes.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menuReportes.Name = "menuReportes";
            this.menuReportes.Size = new System.Drawing.Size(91, 69);
            this.menuReportes.Text = "Reportes";
            this.menuReportes.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.menuReportes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // menuItemReportesCompras
            // 
            this.menuItemReportesCompras.BackColor = System.Drawing.Color.Wheat;
            this.menuItemReportesCompras.Name = "menuItemReportesCompras";
            this.menuItemReportesCompras.Size = new System.Drawing.Size(231, 28);
            this.menuItemReportesCompras.Text = "Reportes compras";
            this.menuItemReportesCompras.Click += new System.EventHandler(this.menuItemReportesCompras_Click);
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
            this.menuItemGraficasCompras.Click += new System.EventHandler(this.menuItemGraficasCompras_Click);
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
            this.menuItemReportesVentas.Click += new System.EventHandler(this.menuItemReportesVentas_Click);
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
            this.menuItemGraficasVentas.Click += new System.EventHandler(this.menuItemGraficasVentas_Click);
            // 
            // menuOfertas
            // 
            this.menuOfertas.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemVerOfertas});
            this.menuOfertas.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuOfertas.Image = global::Presentacion.Properties.Resources.oferta;
            this.menuOfertas.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menuOfertas.Name = "menuOfertas";
            this.menuOfertas.Size = new System.Drawing.Size(79, 69);
            this.menuOfertas.Text = "Ofertas";
            this.menuOfertas.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.menuOfertas.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // menuItemVerOfertas
            // 
            this.menuItemVerOfertas.BackColor = System.Drawing.Color.Wheat;
            this.menuItemVerOfertas.Name = "menuItemVerOfertas";
            this.menuItemVerOfertas.Size = new System.Drawing.Size(176, 28);
            this.menuItemVerOfertas.Text = "Ver ofertas";
            this.menuItemVerOfertas.Click += new System.EventHandler(this.menuItemVerOfertas_Click);
            // 
            // menuReclamos
            // 
            this.menuReclamos.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemVerReclamos});
            this.menuReclamos.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuReclamos.Image = global::Presentacion.Properties.Resources.reclamo;
            this.menuReclamos.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menuReclamos.Name = "menuReclamos";
            this.menuReclamos.Size = new System.Drawing.Size(96, 69);
            this.menuReclamos.Text = "Reclamos";
            this.menuReclamos.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.menuReclamos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // menuItemVerReclamos
            // 
            this.menuItemVerReclamos.BackColor = System.Drawing.Color.Wheat;
            this.menuItemVerReclamos.Name = "menuItemVerReclamos";
            this.menuItemVerReclamos.Size = new System.Drawing.Size(192, 28);
            this.menuItemVerReclamos.Text = "Ver reclamos";
            this.menuItemVerReclamos.Click += new System.EventHandler(this.menuItemVerReclamos_Click);
            // 
            // menuAcercaDe
            // 
            this.menuAcercaDe.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemNegocio,
            this.toolStripSeparator8,
            this.menuItemAutor,
            this.toolStripSeparator9,
            this.menuItemPrograma});
            this.menuAcercaDe.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuAcercaDe.Image = global::Presentacion.Properties.Resources.informacion;
            this.menuAcercaDe.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menuAcercaDe.Name = "menuAcercaDe";
            this.menuAcercaDe.Size = new System.Drawing.Size(99, 69);
            this.menuAcercaDe.Text = "Acerca de";
            this.menuAcercaDe.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.menuAcercaDe.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // menuItemNegocio
            // 
            this.menuItemNegocio.BackColor = System.Drawing.Color.Wheat;
            this.menuItemNegocio.Name = "menuItemNegocio";
            this.menuItemNegocio.Size = new System.Drawing.Size(169, 28);
            this.menuItemNegocio.Text = "Negocio";
            this.menuItemNegocio.Click += new System.EventHandler(this.menuItemVerNegocio_Click);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(166, 6);
            // 
            // menuItemAutor
            // 
            this.menuItemAutor.BackColor = System.Drawing.Color.Wheat;
            this.menuItemAutor.Name = "menuItemAutor";
            this.menuItemAutor.Size = new System.Drawing.Size(169, 28);
            this.menuItemAutor.Text = "Autor";
            this.menuItemAutor.Click += new System.EventHandler(this.menuItemVerAutor_Click);
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            this.toolStripSeparator9.Size = new System.Drawing.Size(166, 6);
            // 
            // menuItemPrograma
            // 
            this.menuItemPrograma.BackColor = System.Drawing.Color.Wheat;
            this.menuItemPrograma.Name = "menuItemPrograma";
            this.menuItemPrograma.Size = new System.Drawing.Size(169, 28);
            this.menuItemPrograma.Text = "Programa";
            this.menuItemPrograma.Click += new System.EventHandler(this.menuItemVerPrograma_Click);
            // 
            // menu1
            // 
            this.menu1.AutoSize = false;
            this.menu1.BackColor = System.Drawing.Color.White;
            this.menu1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menu1.Location = new System.Drawing.Point(0, 0);
            this.menu1.Name = "menu1";
            this.menu1.Size = new System.Drawing.Size(1382, 78);
            this.menu1.TabIndex = 14;
            // 
            // panel
            // 
            this.panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel.Location = new System.Drawing.Point(0, 151);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(1382, 602);
            this.panel.TabIndex = 15;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.BackColor = System.Drawing.Color.White;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.Location = new System.Drawing.Point(570, 24);
            this.lblTitulo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(269, 32);
            this.lblTitulo.TabIndex = 16;
            this.lblTitulo.Text = "Sistema de Ventas";
            // 
            // lbl2
            // 
            this.lbl2.AutoSize = true;
            this.lbl2.BackColor = System.Drawing.Color.White;
            this.lbl2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl2.Location = new System.Drawing.Point(13, 46);
            this.lbl2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl2.Name = "lbl2";
            this.lbl2.Size = new System.Drawing.Size(94, 20);
            this.lbl2.TabIndex = 17;
            this.lbl2.Text = "lblUsuario";
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.BackColor = System.Drawing.Color.White;
            this.lblFecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFecha.Location = new System.Drawing.Point(13, 9);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(60, 20);
            this.lblFecha.TabIndex = 18;
            this.lblFecha.Text = "Fecha";
            // 
            // lblHora
            // 
            this.lblHora.AutoSize = true;
            this.lblHora.BackColor = System.Drawing.Color.White;
            this.lblHora.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHora.Location = new System.Drawing.Point(1281, 32);
            this.lblHora.Name = "lblHora";
            this.lblHora.Size = new System.Drawing.Size(46, 20);
            this.lblHora.TabIndex = 19;
            this.lblHora.Text = "hora";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.pictureBox1.Image = global::Presentacion.Properties.Resources.Logo1;
            this.pictureBox1.Location = new System.Drawing.Point(847, 0);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(75, 78);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 20;
            this.pictureBox1.TabStop = false;
            // 
            // vtnMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(1382, 753);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnRegresar);
            this.Controls.Add(this.lblHora);
            this.Controls.Add(this.lblFecha);
            this.Controls.Add(this.lbl2);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.panel);
            this.Controls.Add(this.menu2);
            this.Controls.Add(this.menu1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "vtnMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menú principal";
            this.Load += new System.EventHandler(this.vtnMenu_Load);
            this.menu2.ResumeLayout(false);
            this.menu2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btnRegresar;
        private System.Windows.Forms.MenuStrip menu2;
        private System.Windows.Forms.MenuStrip menu1;
        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.ToolStripMenuItem menuUsuarios;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lbl2;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.Label lblHora;
        private System.Windows.Forms.ToolStripMenuItem menuItemVerUsuarios;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStripMenuItem menuMantenimiento;
        private System.Windows.Forms.ToolStripMenuItem menuItemInventario;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem menuItemCategoría;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem menuItemProducto;
        private System.Windows.Forms.ToolStripMenuItem menuVentas;
        private System.Windows.Forms.ToolStripMenuItem menuItemRealizarVenta;
        private System.Windows.Forms.ToolStripMenuItem menuCompras;
        private System.Windows.Forms.ToolStripMenuItem menuItemRealizarCompra;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem menuItemVerDetallesVenta;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem menuItemVerDetallesCompra;
        private System.Windows.Forms.ToolStripMenuItem menuProveedores;
        private System.Windows.Forms.ToolStripMenuItem menuItemVerProveedores;
        private System.Windows.Forms.ToolStripMenuItem menuTransportistas;
        private System.Windows.Forms.ToolStripMenuItem menuSucursales;
        private System.Windows.Forms.ToolStripMenuItem menuItemVerTransportistas;
        private System.Windows.Forms.ToolStripMenuItem menuItemVerSucursales;
        private System.Windows.Forms.ToolStripMenuItem menuClientes;
        private System.Windows.Forms.ToolStripMenuItem menuItemVerClientes;
        private System.Windows.Forms.ToolStripMenuItem menuReportes;
        private System.Windows.Forms.ToolStripMenuItem menuItemReportesCompras;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem menuItemGraficasCompras;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem menuItemReportesVentas;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripMenuItem menuItemGraficasVentas;
        private System.Windows.Forms.ToolStripMenuItem menuOfertas;
        private System.Windows.Forms.ToolStripMenuItem menuItemVerOfertas;
        private System.Windows.Forms.ToolStripMenuItem menuReclamos;
        private System.Windows.Forms.ToolStripMenuItem menuAcercaDe;
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