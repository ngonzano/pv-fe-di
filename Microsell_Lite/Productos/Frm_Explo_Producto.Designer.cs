namespace Microsell_Lite.Productos
{
    partial class Frm_Explo_Producto
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Explo_Producto));
            Klik.Windows.Forms.v1.Common.PaintStyle paintStyle1 = new Klik.Windows.Forms.v1.Common.PaintStyle();
            this.pnl_titu = new System.Windows.Forms.Panel();
            this.btn_minimi = new System.Windows.Forms.Button();
            this.btn_cerrar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Pb_Agregar = new FontAwesome.Sharp.IconButton();
            this.iconButton1 = new FontAwesome.Sharp.IconButton();
            this.Pb_Editar = new FontAwesome.Sharp.IconButton();
            this.txt_buscar = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.elLabel1 = new Klik.Windows.Forms.v1.EntryLib.ELLabel();
            this.lblcont = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.List_Producto = new System.Windows.Forms.ListView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.nuevoProveedorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.editarProveedorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mostrarProveedorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.bt_copiarIDProveedor = new System.Windows.Forms.ToolStripMenuItem();
            this.importarProductosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.bunifuSeparator1 = new Bunifu.Framework.UI.BunifuSeparator();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.mostrarTodosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editarOperadorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.pnl_msn = new System.Windows.Forms.Panel();
            this.elDivider2 = new Klik.Windows.Forms.v1.EntryLib.ELDivider();
            this.ElDivider3 = new Klik.Windows.Forms.v1.EntryLib.ELDivider();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.pnl_titu.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.elLabel1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.pnl_msn.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.elDivider2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ElDivider3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pnl_titu
            // 
            this.pnl_titu.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pnl_titu.BackColor = System.Drawing.Color.DimGray;
            this.pnl_titu.Controls.Add(this.btn_minimi);
            this.pnl_titu.Controls.Add(this.btn_cerrar);
            this.pnl_titu.Controls.Add(this.label1);
            this.pnl_titu.Location = new System.Drawing.Point(0, 0);
            this.pnl_titu.Name = "pnl_titu";
            this.pnl_titu.Size = new System.Drawing.Size(1083, 48);
            this.pnl_titu.TabIndex = 0;
            this.pnl_titu.Paint += new System.Windows.Forms.PaintEventHandler(this.pnl_titu_Paint);
            this.pnl_titu.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnl_titu_MouseMove);
            // 
            // btn_minimi
            // 
            this.btn_minimi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_minimi.FlatAppearance.BorderSize = 0;
            this.btn_minimi.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SkyBlue;
            this.btn_minimi.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SkyBlue;
            this.btn_minimi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_minimi.Font = new System.Drawing.Font("Calibri Light", 10F, System.Drawing.FontStyle.Italic);
            this.btn_minimi.ForeColor = System.Drawing.Color.White;
            this.btn_minimi.Image = ((System.Drawing.Image)(resources.GetObject("btn_minimi.Image")));
            this.btn_minimi.Location = new System.Drawing.Point(995, 9);
            this.btn_minimi.Name = "btn_minimi";
            this.btn_minimi.Size = new System.Drawing.Size(30, 30);
            this.btn_minimi.TabIndex = 7;
            this.btn_minimi.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_minimi.UseVisualStyleBackColor = true;
            this.btn_minimi.Click += new System.EventHandler(this.btn_minimi_Click);
            // 
            // btn_cerrar
            // 
            this.btn_cerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_cerrar.FlatAppearance.BorderSize = 0;
            this.btn_cerrar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SkyBlue;
            this.btn_cerrar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SkyBlue;
            this.btn_cerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_cerrar.Font = new System.Drawing.Font("Calibri Light", 10F, System.Drawing.FontStyle.Italic);
            this.btn_cerrar.ForeColor = System.Drawing.Color.White;
            this.btn_cerrar.Image = ((System.Drawing.Image)(resources.GetObject("btn_cerrar.Image")));
            this.btn_cerrar.Location = new System.Drawing.Point(1037, 9);
            this.btn_cerrar.Name = "btn_cerrar";
            this.btn_cerrar.Size = new System.Drawing.Size(30, 30);
            this.btn_cerrar.TabIndex = 6;
            this.btn_cerrar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_cerrar.UseVisualStyleBackColor = true;
            this.btn_cerrar.Click += new System.EventHandler(this.btn_cerrar_Click);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label1.Location = new System.Drawing.Point(12, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(197, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Explorador de Producto";
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.panel1.BackColor = System.Drawing.Color.DarkGray;
            this.panel1.Controls.Add(this.Pb_Agregar);
            this.panel1.Controls.Add(this.iconButton1);
            this.panel1.Controls.Add(this.Pb_Editar);
            this.panel1.Controls.Add(this.txt_buscar);
            this.panel1.Controls.Add(this.elLabel1);
            this.panel1.Controls.Add(this.lblcont);
            this.panel1.Controls.Add(this.label15);
            this.panel1.Location = new System.Drawing.Point(0, 48);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1082, 43);
            this.panel1.TabIndex = 111;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // Pb_Agregar
            // 
            this.Pb_Agregar.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Pb_Agregar.BackColor = System.Drawing.Color.DarkGray;
            this.Pb_Agregar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.Pb_Agregar.FlatAppearance.BorderSize = 0;
            this.Pb_Agregar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DeepSkyBlue;
            this.Pb_Agregar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkSeaGreen;
            this.Pb_Agregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Pb_Agregar.Font = new System.Drawing.Font("Verdana", 9.75F);
            this.Pb_Agregar.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.Pb_Agregar.IconChar = FontAwesome.Sharp.IconChar.UserPlus;
            this.Pb_Agregar.IconColor = System.Drawing.Color.WhiteSmoke;
            this.Pb_Agregar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.Pb_Agregar.IconSize = 30;
            this.Pb_Agregar.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.Pb_Agregar.Location = new System.Drawing.Point(65, 6);
            this.Pb_Agregar.Name = "Pb_Agregar";
            this.Pb_Agregar.Size = new System.Drawing.Size(37, 32);
            this.Pb_Agregar.TabIndex = 26;
            this.Pb_Agregar.UseVisualStyleBackColor = false;
            this.Pb_Agregar.Click += new System.EventHandler(this.Pb_Agregar_Click);
            // 
            // iconButton1
            // 
            this.iconButton1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.iconButton1.BackColor = System.Drawing.Color.LightGray;
            this.iconButton1.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro;
            this.iconButton1.FlatAppearance.BorderSize = 0;
            this.iconButton1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gainsboro;
            this.iconButton1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gainsboro;
            this.iconButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButton1.ForeColor = System.Drawing.Color.Transparent;
            this.iconButton1.IconChar = FontAwesome.Sharp.IconChar.Search;
            this.iconButton1.IconColor = System.Drawing.Color.DimGray;
            this.iconButton1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton1.IconSize = 25;
            this.iconButton1.Location = new System.Drawing.Point(1029, 10);
            this.iconButton1.Name = "iconButton1";
            this.iconButton1.Size = new System.Drawing.Size(28, 25);
            this.iconButton1.TabIndex = 57;
            this.iconButton1.UseVisualStyleBackColor = false;
            // 
            // Pb_Editar
            // 
            this.Pb_Editar.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Pb_Editar.BackColor = System.Drawing.Color.DarkGray;
            this.Pb_Editar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.Pb_Editar.FlatAppearance.BorderSize = 0;
            this.Pb_Editar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DeepSkyBlue;
            this.Pb_Editar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkSeaGreen;
            this.Pb_Editar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Pb_Editar.Font = new System.Drawing.Font("Verdana", 9.75F);
            this.Pb_Editar.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.Pb_Editar.IconChar = FontAwesome.Sharp.IconChar.UserEdit;
            this.Pb_Editar.IconColor = System.Drawing.Color.WhiteSmoke;
            this.Pb_Editar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.Pb_Editar.IconSize = 30;
            this.Pb_Editar.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.Pb_Editar.Location = new System.Drawing.Point(22, 6);
            this.Pb_Editar.Name = "Pb_Editar";
            this.Pb_Editar.Size = new System.Drawing.Size(37, 31);
            this.Pb_Editar.TabIndex = 25;
            this.Pb_Editar.UseVisualStyleBackColor = false;
            this.Pb_Editar.Click += new System.EventHandler(this.Pb_Editar_Click);
            // 
            // txt_buscar
            // 
            this.txt_buscar.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txt_buscar.BackColor = System.Drawing.Color.LightGray;
            this.txt_buscar.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_buscar.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_buscar.ForeColor = System.Drawing.Color.DimGray;
            this.txt_buscar.HintForeColor = System.Drawing.Color.DimGray;
            this.txt_buscar.HintText = "Buscar Producto";
            this.txt_buscar.isPassword = false;
            this.txt_buscar.LineFocusedColor = System.Drawing.Color.LightGray;
            this.txt_buscar.LineIdleColor = System.Drawing.Color.LightGray;
            this.txt_buscar.LineMouseHoverColor = System.Drawing.Color.LightGray;
            this.txt_buscar.LineThickness = 3;
            this.txt_buscar.Location = new System.Drawing.Point(853, 8);
            this.txt_buscar.Margin = new System.Windows.Forms.Padding(4);
            this.txt_buscar.Name = "txt_buscar";
            this.txt_buscar.Size = new System.Drawing.Size(177, 27);
            this.txt_buscar.TabIndex = 1;
            this.txt_buscar.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txt_buscar.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_buscar_KeyDown);
            this.txt_buscar.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_buscar_KeyPress);
            this.txt_buscar.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_buscar_KeyUp);
            // 
            // elLabel1
            // 
            this.elLabel1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.elLabel1.BackgroundStyle.GradientEndColor = System.Drawing.Color.LightGray;
            this.elLabel1.BackgroundStyle.GradientStartColor = System.Drawing.Color.LightGray;
            this.elLabel1.BorderStyle.BorderShape.BottomLeft = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.elLabel1.BorderStyle.BorderShape.BottomRight = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.elLabel1.BorderStyle.BorderShape.TopLeft = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.elLabel1.BorderStyle.BorderShape.TopRight = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.elLabel1.BorderStyle.GradientEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.elLabel1.BorderStyle.GradientStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.elLabel1.BorderStyle.SolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            paintStyle1.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            paintStyle1.SolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(240)))), ((int)(((byte)(191)))));
            this.elLabel1.FlashStyle = paintStyle1;
            this.elLabel1.Location = new System.Drawing.Point(836, 7);
            this.elLabel1.Name = "elLabel1";
            this.elLabel1.Size = new System.Drawing.Size(231, 29);
            this.elLabel1.TabIndex = 18;
            this.elLabel1.TabStop = false;
            this.elLabel1.VisualStyle = Klik.Windows.Forms.v1.Common.ControlVisualStyles.Custom;
            // 
            // lblcont
            // 
            this.lblcont.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblcont.BackColor = System.Drawing.Color.DarkGray;
            this.lblcont.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblcont.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblcont.Location = new System.Drawing.Point(593, 15);
            this.lblcont.Name = "lblcont";
            this.lblcont.Size = new System.Drawing.Size(83, 18);
            this.lblcont.TabIndex = 16;
            this.lblcont.Text = "..";
            this.lblcont.Click += new System.EventHandler(this.lblcont_Click);
            // 
            // label15
            // 
            this.label15.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label15.BackColor = System.Drawing.Color.DarkGray;
            this.label15.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label15.Location = new System.Drawing.Point(477, 12);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(110, 24);
            this.label15.TabIndex = 16;
            this.label15.Text = "Total Items:";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label15.Click += new System.EventHandler(this.label15_Click);
            // 
            // List_Producto
            // 
            this.List_Producto.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.List_Producto.ContextMenuStrip = this.contextMenuStrip1;
            this.List_Producto.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.List_Producto.ForeColor = System.Drawing.Color.DimGray;
            this.List_Producto.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.List_Producto.HideSelection = false;
            this.List_Producto.Location = new System.Drawing.Point(0, 123);
            this.List_Producto.Name = "List_Producto";
            this.List_Producto.Size = new System.Drawing.Size(1082, 467);
            this.List_Producto.TabIndex = 2;
            this.List_Producto.UseCompatibleStateImageBehavior = false;
            this.List_Producto.SelectedIndexChanged += new System.EventHandler(this.List_Proveedor_SelectedIndexChanged);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Font = new System.Drawing.Font("Calibri Light", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevoProveedorToolStripMenuItem,
            this.toolStripSeparator2,
            this.editarProveedorToolStripMenuItem,
            this.toolStripSeparator1,
            this.mostrarProveedorToolStripMenuItem,
            this.toolStripSeparator3,
            this.bt_copiarIDProveedor,
            this.importarProductosToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(168, 132);
            // 
            // nuevoProveedorToolStripMenuItem
            // 
            this.nuevoProveedorToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("nuevoProveedorToolStripMenuItem.Image")));
            this.nuevoProveedorToolStripMenuItem.Name = "nuevoProveedorToolStripMenuItem";
            this.nuevoProveedorToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.nuevoProveedorToolStripMenuItem.Text = "Nuevo Producto";
            this.nuevoProveedorToolStripMenuItem.Click += new System.EventHandler(this.nuevoProveedorToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(164, 6);
            // 
            // editarProveedorToolStripMenuItem
            // 
            this.editarProveedorToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("editarProveedorToolStripMenuItem.Image")));
            this.editarProveedorToolStripMenuItem.Name = "editarProveedorToolStripMenuItem";
            this.editarProveedorToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.editarProveedorToolStripMenuItem.Text = "Editar Producto";
            this.editarProveedorToolStripMenuItem.Click += new System.EventHandler(this.editarProveedorToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(164, 6);
            // 
            // mostrarProveedorToolStripMenuItem
            // 
            this.mostrarProveedorToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("mostrarProveedorToolStripMenuItem.Image")));
            this.mostrarProveedorToolStripMenuItem.Name = "mostrarProveedorToolStripMenuItem";
            this.mostrarProveedorToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.mostrarProveedorToolStripMenuItem.Text = "Mostrar Producto";
            this.mostrarProveedorToolStripMenuItem.Click += new System.EventHandler(this.mostrarProveedorToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(164, 6);
            // 
            // bt_copiarIDProveedor
            // 
            this.bt_copiarIDProveedor.Image = ((System.Drawing.Image)(resources.GetObject("bt_copiarIDProveedor.Image")));
            this.bt_copiarIDProveedor.Name = "bt_copiarIDProveedor";
            this.bt_copiarIDProveedor.Size = new System.Drawing.Size(167, 22);
            this.bt_copiarIDProveedor.Text = "Copiar ID Producto";
            this.bt_copiarIDProveedor.Click += new System.EventHandler(this.bt_copiarIDProveedor_Click);
            // 
            // importarProductosToolStripMenuItem
            // 
            this.importarProductosToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("importarProductosToolStripMenuItem.Image")));
            this.importarProductosToolStripMenuItem.Name = "importarProductosToolStripMenuItem";
            this.importarProductosToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.importarProductosToolStripMenuItem.Text = "Importar Productos";
            this.importarProductosToolStripMenuItem.Click += new System.EventHandler(this.importarProductosToolStripMenuItem_Click);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.BackColor = System.Drawing.SystemColors.Control;
            this.label2.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DimGray;
            this.label2.Location = new System.Drawing.Point(2, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 23);
            this.label2.TabIndex = 3;
            this.label2.Text = "ID Producto";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label3.BackColor = System.Drawing.SystemColors.Control;
            this.label3.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DimGray;
            this.label3.Location = new System.Drawing.Point(106, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(200, 23);
            this.label3.TabIndex = 4;
            this.label3.Text = "Nom. Producto";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label4.BackColor = System.Drawing.SystemColors.Control;
            this.label4.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.DimGray;
            this.label4.Location = new System.Drawing.Point(311, 96);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 23);
            this.label4.TabIndex = 5;
            this.label4.Text = "Stck Act.";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label5.BackColor = System.Drawing.SystemColors.Control;
            this.label5.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.DimGray;
            this.label5.Location = new System.Drawing.Point(591, 96);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 23);
            this.label5.TabIndex = 8;
            this.label5.Text = "Pre. Venta1";
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label6.BackColor = System.Drawing.SystemColors.Control;
            this.label6.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.DimGray;
            this.label6.Location = new System.Drawing.Point(518, 96);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 23);
            this.label6.TabIndex = 7;
            this.label6.Text = "Margen";
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label7.BackColor = System.Drawing.SystemColors.Control;
            this.label7.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.DimGray;
            this.label7.Location = new System.Drawing.Point(402, 96);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(110, 23);
            this.label7.TabIndex = 6;
            this.label7.Text = "Precio Compra";
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label8.BackColor = System.Drawing.SystemColors.Control;
            this.label8.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.DimGray;
            this.label8.Location = new System.Drawing.Point(780, 96);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(100, 23);
            this.label8.TabIndex = 10;
            this.label8.Text = "Utilidad";
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label9.BackColor = System.Drawing.SystemColors.Control;
            this.label9.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.DimGray;
            this.label9.Location = new System.Drawing.Point(684, 96);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(100, 23);
            this.label9.TabIndex = 9;
            this.label9.Text = "Pre. Venta2";
            // 
            // bunifuSeparator1
            // 
            this.bunifuSeparator1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.bunifuSeparator1.BackColor = System.Drawing.Color.Transparent;
            this.bunifuSeparator1.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.bunifuSeparator1.LineThickness = 1;
            this.bunifuSeparator1.Location = new System.Drawing.Point(0, 115);
            this.bunifuSeparator1.Name = "bunifuSeparator1";
            this.bunifuSeparator1.Size = new System.Drawing.Size(1083, 10);
            this.bunifuSeparator1.TabIndex = 11;
            this.bunifuSeparator1.Transparency = 255;
            this.bunifuSeparator1.Vertical = false;
            this.bunifuSeparator1.Load += new System.EventHandler(this.bunifuSeparator1_Load);
            // 
            // toolTip1
            // 
            this.toolTip1.BackColor = System.Drawing.SystemColors.Control;
            this.toolTip1.IsBalloon = true;
            // 
            // mostrarTodosToolStripMenuItem
            // 
            this.mostrarTodosToolStripMenuItem.Name = "mostrarTodosToolStripMenuItem";
            this.mostrarTodosToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.mostrarTodosToolStripMenuItem.Text = "Mostrar Todos";
            // 
            // editarOperadorToolStripMenuItem
            // 
            this.editarOperadorToolStripMenuItem.Name = "editarOperadorToolStripMenuItem";
            this.editarOperadorToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.editarOperadorToolStripMenuItem.Text = "Editar Operador";
            // 
            // label11
            // 
            this.label11.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label11.BackColor = System.Drawing.SystemColors.Control;
            this.label11.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.DimGray;
            this.label11.Location = new System.Drawing.Point(849, 97);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(100, 23);
            this.label11.TabIndex = 12;
            this.label11.Text = "Total S/.";
            // 
            // label12
            // 
            this.label12.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label12.BackColor = System.Drawing.SystemColors.Control;
            this.label12.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.DimGray;
            this.label12.Location = new System.Drawing.Point(917, 97);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(74, 23);
            this.label12.TabIndex = 13;
            this.label12.Text = "Estado";
            // 
            // label13
            // 
            this.label13.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label13.BackColor = System.Drawing.SystemColors.Control;
            this.label13.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.DimGray;
            this.label13.Location = new System.Drawing.Point(979, 97);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(51, 23);
            this.label13.TabIndex = 14;
            this.label13.Text = "Marca";
            this.label13.Click += new System.EventHandler(this.label13_Click);
            // 
            // label14
            // 
            this.label14.BackColor = System.Drawing.Color.DimGray;
            this.label14.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label14.Font = new System.Drawing.Font("Calibri Light", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.DarkSeaGreen;
            this.label14.Location = new System.Drawing.Point(0, 593);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(1083, 8);
            this.label14.TabIndex = 15;
            this.label14.Click += new System.EventHandler(this.label14_Click);
            // 
            // pnl_msn
            // 
            this.pnl_msn.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pnl_msn.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnl_msn.Controls.Add(this.elDivider2);
            this.pnl_msn.Controls.Add(this.ElDivider3);
            this.pnl_msn.Controls.Add(this.label17);
            this.pnl_msn.Controls.Add(this.label16);
            this.pnl_msn.Controls.Add(this.pictureBox1);
            this.pnl_msn.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.pnl_msn.Location = new System.Drawing.Point(0, 92);
            this.pnl_msn.Name = "pnl_msn";
            this.pnl_msn.Size = new System.Drawing.Size(1082, 497);
            this.pnl_msn.TabIndex = 16;
            this.pnl_msn.Visible = false;
            this.pnl_msn.Paint += new System.Windows.Forms.PaintEventHandler(this.pnl_msn_Paint);
            // 
            // elDivider2
            // 
            this.elDivider2.FadeStyle = Klik.Windows.Forms.v1.EntryLib.DividerFadeStyles.Center;
            this.elDivider2.LineColor = System.Drawing.Color.DarkOrange;
            this.elDivider2.Location = new System.Drawing.Point(46, 267);
            this.elDivider2.Margin = new System.Windows.Forms.Padding(4);
            this.elDivider2.Name = "elDivider2";
            this.elDivider2.Size = new System.Drawing.Size(994, 2);
            this.elDivider2.TabIndex = 420;
            this.elDivider2.VisualStyle = Klik.Windows.Forms.v1.Common.ControlVisualStyles.Custom;
            // 
            // ElDivider3
            // 
            this.ElDivider3.FadeStyle = Klik.Windows.Forms.v1.EntryLib.DividerFadeStyles.Center;
            this.ElDivider3.LineColor = System.Drawing.Color.DarkGray;
            this.ElDivider3.Location = new System.Drawing.Point(34, 259);
            this.ElDivider3.Margin = new System.Windows.Forms.Padding(4);
            this.ElDivider3.Name = "ElDivider3";
            this.ElDivider3.Size = new System.Drawing.Size(1019, 10);
            this.ElDivider3.TabIndex = 419;
            this.ElDivider3.VisualStyle = Klik.Windows.Forms.v1.Common.ControlVisualStyles.Custom;
            // 
            // label17
            // 
            this.label17.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.Color.DimGray;
            this.label17.Location = new System.Drawing.Point(371, 281);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(310, 22);
            this.label17.TabIndex = 18;
            this.label17.Text = "Intentar busqueda con otro Producto";
            // 
            // label16
            // 
            this.label16.Font = new System.Drawing.Font("Verdana", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.DarkOrange;
            this.label16.Location = new System.Drawing.Point(362, 224);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(343, 39);
            this.label16.TabIndex = 17;
            this.label16.Text = "Busqueda sin resultado";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(480, 124);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(80, 83);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 25;
            this.bunifuElipse1.TargetControl = this;
            // 
            // Frm_Explo_Producto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1083, 601);
            this.Controls.Add(this.pnl_msn);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.bunifuSeparator1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.List_Producto);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnl_titu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "Frm_Explo_Producto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Explorador de Productos";
            this.Load += new System.EventHandler(this.Frm_Explo_Proveedor_Load);
            this.pnl_titu.ResumeLayout(false);
            this.pnl_titu.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.elLabel1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.pnl_msn.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.elDivider2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ElDivider3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel pnl_titu;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_cerrar;
        private System.Windows.Forms.Button btn_minimi;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListView List_Producto;
        private Bunifu.Framework.UI.BunifuSeparator bunifuSeparator1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ToolStripMenuItem mostrarTodosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editarOperadorToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem nuevoProveedorToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem editarProveedorToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem mostrarProveedorToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem bt_copiarIDProveedor;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Panel pnl_msn;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.PictureBox pictureBox1;
        private Klik.Windows.Forms.v1.EntryLib.ELLabel elLabel1;
        public Bunifu.Framework.UI.BunifuMaterialTextbox txt_buscar;
        private System.Windows.Forms.Label lblcont;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ToolStripMenuItem importarProductosToolStripMenuItem;
        private FontAwesome.Sharp.IconButton iconButton1;
        private FontAwesome.Sharp.IconButton Pb_Agregar;
        private FontAwesome.Sharp.IconButton Pb_Editar;
        internal Klik.Windows.Forms.v1.EntryLib.ELDivider elDivider2;
        internal Klik.Windows.Forms.v1.EntryLib.ELDivider ElDivider3;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
    }
}