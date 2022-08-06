namespace Microsell_Lite.Cliente
{
    partial class Frm_Explo_Cliente
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
            Klik.Windows.Forms.v1.Common.PaintStyle paintStyle1 = new Klik.Windows.Forms.v1.Common.PaintStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Explo_Cliente));
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.pnl_titu = new System.Windows.Forms.Panel();
            this.btn_minimi = new System.Windows.Forms.Button();
            this.btn_cerrar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.iconButton1 = new FontAwesome.Sharp.IconButton();
            this.Pb_Agregar2 = new FontAwesome.Sharp.IconButton();
            this.Pb_Editar2 = new FontAwesome.Sharp.IconButton();
            this.txt_buscar = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.elLabel1 = new Klik.Windows.Forms.v1.EntryLib.ELLabel();
            this.lblcont = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.List_Cliente = new System.Windows.Forms.ListView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.nuevoClienteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.editarClienteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mostrarClienteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.bt_copiarIDCliente = new System.Windows.Forms.ToolStripMenuItem();
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
            this.label14 = new System.Windows.Forms.Label();
            this.pnl_msn = new System.Windows.Forms.Panel();
            this.elDivider1 = new Klik.Windows.Forms.v1.EntryLib.ELDivider();
            this.ElDivider3 = new Klik.Windows.Forms.v1.EntryLib.ELDivider();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pnl_titu.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.elLabel1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.pnl_msn.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.elDivider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ElDivider3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 25;
            this.bunifuElipse1.TargetControl = this;
            // 
            // pnl_titu
            // 
            this.pnl_titu.BackColor = System.Drawing.Color.DimGray;
            this.pnl_titu.Controls.Add(this.btn_minimi);
            this.pnl_titu.Controls.Add(this.btn_cerrar);
            this.pnl_titu.Controls.Add(this.label1);
            this.pnl_titu.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_titu.Location = new System.Drawing.Point(0, 0);
            this.pnl_titu.Name = "pnl_titu";
            this.pnl_titu.Size = new System.Drawing.Size(914, 42);
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
            this.btn_minimi.Location = new System.Drawing.Point(835, 9);
            this.btn_minimi.Name = "btn_minimi";
            this.btn_minimi.Size = new System.Drawing.Size(25, 25);
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
            this.btn_cerrar.Location = new System.Drawing.Point(876, 9);
            this.btn_cerrar.Name = "btn_cerrar";
            this.btn_cerrar.Size = new System.Drawing.Size(25, 25);
            this.btn_cerrar.TabIndex = 6;
            this.btn_cerrar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_cerrar.UseVisualStyleBackColor = true;
            this.btn_cerrar.Click += new System.EventHandler(this.btn_cerrar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label1.Location = new System.Drawing.Point(12, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(184, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Explorador de Cliente";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkGray;
            this.panel1.Controls.Add(this.iconButton1);
            this.panel1.Controls.Add(this.Pb_Agregar2);
            this.panel1.Controls.Add(this.Pb_Editar2);
            this.panel1.Controls.Add(this.txt_buscar);
            this.panel1.Controls.Add(this.elLabel1);
            this.panel1.Controls.Add(this.lblcont);
            this.panel1.Controls.Add(this.label15);
            this.panel1.Location = new System.Drawing.Point(0, 40);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(912, 37);
            this.panel1.TabIndex = 1;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // iconButton1
            // 
            this.iconButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.iconButton1.BackColor = System.Drawing.Color.Silver;
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
            this.iconButton1.Location = new System.Drawing.Point(866, 7);
            this.iconButton1.Name = "iconButton1";
            this.iconButton1.Size = new System.Drawing.Size(25, 25);
            this.iconButton1.TabIndex = 57;
            this.iconButton1.UseVisualStyleBackColor = false;
            // 
            // Pb_Agregar2
            // 
            this.Pb_Agregar2.BackColor = System.Drawing.Color.DarkGray;
            this.Pb_Agregar2.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.Pb_Agregar2.FlatAppearance.BorderSize = 0;
            this.Pb_Agregar2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DeepSkyBlue;
            this.Pb_Agregar2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkSeaGreen;
            this.Pb_Agregar2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Pb_Agregar2.Font = new System.Drawing.Font("Verdana", 9.75F);
            this.Pb_Agregar2.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.Pb_Agregar2.IconChar = FontAwesome.Sharp.IconChar.UserPlus;
            this.Pb_Agregar2.IconColor = System.Drawing.Color.WhiteSmoke;
            this.Pb_Agregar2.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.Pb_Agregar2.IconSize = 30;
            this.Pb_Agregar2.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.Pb_Agregar2.Location = new System.Drawing.Point(59, 3);
            this.Pb_Agregar2.Name = "Pb_Agregar2";
            this.Pb_Agregar2.Size = new System.Drawing.Size(37, 32);
            this.Pb_Agregar2.TabIndex = 23;
            this.Pb_Agregar2.UseVisualStyleBackColor = false;
            this.Pb_Agregar2.Click += new System.EventHandler(this.Pb_Agregar2_Click);
            this.Pb_Agregar2.MouseEnter += new System.EventHandler(this.Pb_Agregar2_MouseEnter);
            this.Pb_Agregar2.MouseLeave += new System.EventHandler(this.Pb_Agregar2_MouseLeave);
            // 
            // Pb_Editar2
            // 
            this.Pb_Editar2.BackColor = System.Drawing.Color.DarkGray;
            this.Pb_Editar2.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.Pb_Editar2.FlatAppearance.BorderSize = 0;
            this.Pb_Editar2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DeepSkyBlue;
            this.Pb_Editar2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkSeaGreen;
            this.Pb_Editar2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Pb_Editar2.Font = new System.Drawing.Font("Verdana", 9.75F);
            this.Pb_Editar2.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.Pb_Editar2.IconChar = FontAwesome.Sharp.IconChar.UserEdit;
            this.Pb_Editar2.IconColor = System.Drawing.Color.WhiteSmoke;
            this.Pb_Editar2.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.Pb_Editar2.IconSize = 30;
            this.Pb_Editar2.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.Pb_Editar2.Location = new System.Drawing.Point(16, 3);
            this.Pb_Editar2.Name = "Pb_Editar2";
            this.Pb_Editar2.Size = new System.Drawing.Size(37, 31);
            this.Pb_Editar2.TabIndex = 22;
            this.Pb_Editar2.UseVisualStyleBackColor = false;
            this.Pb_Editar2.Click += new System.EventHandler(this.Pb_Editar2_Click);
            this.Pb_Editar2.MouseEnter += new System.EventHandler(this.Pb_Editar2_MouseEnter);
            this.Pb_Editar2.MouseLeave += new System.EventHandler(this.Pb_Editar2_MouseLeave);
            // 
            // txt_buscar
            // 
            this.txt_buscar.BackColor = System.Drawing.Color.Silver;
            this.txt_buscar.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_buscar.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_buscar.ForeColor = System.Drawing.Color.DimGray;
            this.txt_buscar.HintForeColor = System.Drawing.Color.DimGray;
            this.txt_buscar.HintText = "Buscar Cliente";
            this.txt_buscar.isPassword = false;
            this.txt_buscar.LineFocusedColor = System.Drawing.Color.Silver;
            this.txt_buscar.LineIdleColor = System.Drawing.Color.Silver;
            this.txt_buscar.LineMouseHoverColor = System.Drawing.Color.Silver;
            this.txt_buscar.LineThickness = 3;
            this.txt_buscar.Location = new System.Drawing.Point(684, 5);
            this.txt_buscar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txt_buscar.Name = "txt_buscar";
            this.txt_buscar.Size = new System.Drawing.Size(175, 25);
            this.txt_buscar.TabIndex = 20;
            this.txt_buscar.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txt_buscar.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_buscar_KeyDown);
            this.txt_buscar.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_buscar_KeyPress);
            this.txt_buscar.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_buscar_KeyUp);
            // 
            // elLabel1
            // 
            this.elLabel1.BackgroundStyle.GradientEndColor = System.Drawing.Color.Silver;
            this.elLabel1.BackgroundStyle.GradientStartColor = System.Drawing.Color.Silver;
            this.elLabel1.BorderStyle.BorderShape.BottomLeft = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.elLabel1.BorderStyle.BorderShape.BottomRight = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.elLabel1.BorderStyle.BorderShape.TopLeft = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.elLabel1.BorderStyle.BorderShape.TopRight = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.elLabel1.BorderStyle.GradientEndColor = System.Drawing.Color.DarkOrange;
            this.elLabel1.BorderStyle.GradientStartColor = System.Drawing.Color.DarkOrange;
            this.elLabel1.BorderStyle.SolidColor = System.Drawing.Color.DarkOrange;
            paintStyle1.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            paintStyle1.SolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(240)))), ((int)(((byte)(191)))));
            this.elLabel1.FlashStyle = paintStyle1;
            this.elLabel1.Location = new System.Drawing.Point(669, 4);
            this.elLabel1.Name = "elLabel1";
            this.elLabel1.Size = new System.Drawing.Size(234, 29);
            this.elLabel1.TabIndex = 21;
            this.elLabel1.TabStop = false;
            this.elLabel1.VisualStyle = Klik.Windows.Forms.v1.Common.ControlVisualStyles.Custom;
            // 
            // lblcont
            // 
            this.lblcont.BackColor = System.Drawing.Color.DarkGray;
            this.lblcont.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblcont.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblcont.Location = new System.Drawing.Point(476, 11);
            this.lblcont.Name = "lblcont";
            this.lblcont.Size = new System.Drawing.Size(83, 18);
            this.lblcont.TabIndex = 16;
            this.lblcont.Text = "..";
            this.lblcont.Click += new System.EventHandler(this.lblcont_Click);
            // 
            // label15
            // 
            this.label15.BackColor = System.Drawing.Color.DarkGray;
            this.label15.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label15.Location = new System.Drawing.Point(374, 5);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(113, 24);
            this.label15.TabIndex = 16;
            this.label15.Text = "Total Items:";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label15.Click += new System.EventHandler(this.label15_Click);
            // 
            // List_Cliente
            // 
            this.List_Cliente.ContextMenuStrip = this.contextMenuStrip1;
            this.List_Cliente.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.List_Cliente.ForeColor = System.Drawing.Color.DimGray;
            this.List_Cliente.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.List_Cliente.HideSelection = false;
            this.List_Cliente.Location = new System.Drawing.Point(0, 115);
            this.List_Cliente.Name = "List_Cliente";
            this.List_Cliente.Size = new System.Drawing.Size(912, 400);
            this.List_Cliente.TabIndex = 2;
            this.List_Cliente.UseCompatibleStateImageBehavior = false;
            this.List_Cliente.SelectedIndexChanged += new System.EventHandler(this.List_Cliente_SelectedIndexChanged);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Font = new System.Drawing.Font("Calibri Light", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevoClienteToolStripMenuItem,
            this.toolStripSeparator2,
            this.editarClienteToolStripMenuItem,
            this.toolStripSeparator1,
            this.mostrarClienteToolStripMenuItem,
            this.toolStripSeparator3,
            this.bt_copiarIDCliente});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(156, 110);
            // 
            // nuevoClienteToolStripMenuItem
            // 
            this.nuevoClienteToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("nuevoClienteToolStripMenuItem.Image")));
            this.nuevoClienteToolStripMenuItem.Name = "nuevoClienteToolStripMenuItem";
            this.nuevoClienteToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.nuevoClienteToolStripMenuItem.Text = "Nuevo Cliente";
            this.nuevoClienteToolStripMenuItem.Click += new System.EventHandler(this.nuevoClienteToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(152, 6);
            // 
            // editarClienteToolStripMenuItem
            // 
            this.editarClienteToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("editarClienteToolStripMenuItem.Image")));
            this.editarClienteToolStripMenuItem.Name = "editarClienteToolStripMenuItem";
            this.editarClienteToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.editarClienteToolStripMenuItem.Text = "Editar Cliente";
            this.editarClienteToolStripMenuItem.Click += new System.EventHandler(this.editarClienteToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(152, 6);
            // 
            // mostrarClienteToolStripMenuItem
            // 
            this.mostrarClienteToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("mostrarClienteToolStripMenuItem.Image")));
            this.mostrarClienteToolStripMenuItem.Name = "mostrarClienteToolStripMenuItem";
            this.mostrarClienteToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.mostrarClienteToolStripMenuItem.Text = "Mostrar Cliente";
            this.mostrarClienteToolStripMenuItem.Click += new System.EventHandler(this.mostrarClienteToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(152, 6);
            // 
            // bt_copiarIDCliente
            // 
            this.bt_copiarIDCliente.Image = ((System.Drawing.Image)(resources.GetObject("bt_copiarIDCliente.Image")));
            this.bt_copiarIDCliente.Name = "bt_copiarIDCliente";
            this.bt_copiarIDCliente.Size = new System.Drawing.Size(155, 22);
            this.bt_copiarIDCliente.Text = "Copiar ID Cliente";
            this.bt_copiarIDCliente.Click += new System.EventHandler(this.bt_copiarIDCliente_Click);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.SystemColors.Control;
            this.label2.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DimGray;
            this.label2.Location = new System.Drawing.Point(2, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 23);
            this.label2.TabIndex = 3;
            this.label2.Text = "ID CLIENTE";
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.SystemColors.Control;
            this.label3.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DimGray;
            this.label3.Location = new System.Drawing.Point(106, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(200, 23);
            this.label3.TabIndex = 4;
            this.label3.Text = "DATOS DEL CLIENTE";
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.SystemColors.Control;
            this.label4.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.DimGray;
            this.label4.Location = new System.Drawing.Point(306, 80);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 23);
            this.label4.TabIndex = 5;
            this.label4.Text = "DNI";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.SystemColors.Control;
            this.label5.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.DimGray;
            this.label5.Location = new System.Drawing.Point(638, 80);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 23);
            this.label5.TabIndex = 8;
            this.label5.Text = "LIM. CREDITO";
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.SystemColors.Control;
            this.label6.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.DimGray;
            this.label6.Location = new System.Drawing.Point(545, 80);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 23);
            this.label6.TabIndex = 7;
            this.label6.Text = "TELEFONO";
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.SystemColors.Control;
            this.label7.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.DimGray;
            this.label7.Location = new System.Drawing.Point(402, 80);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(130, 23);
            this.label7.TabIndex = 6;
            this.label7.Text = "DIRECCION";
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.SystemColors.Control;
            this.label8.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.DimGray;
            this.label8.Location = new System.Drawing.Point(841, 80);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(71, 23);
            this.label8.TabIndex = 10;
            this.label8.Text = "ESTADO";
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.SystemColors.Control;
            this.label9.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.DimGray;
            this.label9.Location = new System.Drawing.Point(739, 80);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(100, 23);
            this.label9.TabIndex = 9;
            this.label9.Text = "CORREO";
            // 
            // bunifuSeparator1
            // 
            this.bunifuSeparator1.BackColor = System.Drawing.Color.Transparent;
            this.bunifuSeparator1.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.bunifuSeparator1.LineThickness = 1;
            this.bunifuSeparator1.Location = new System.Drawing.Point(0, 96);
            this.bunifuSeparator1.Name = "bunifuSeparator1";
            this.bunifuSeparator1.Size = new System.Drawing.Size(912, 10);
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
            // label14
            // 
            this.label14.BackColor = System.Drawing.Color.DimGray;
            this.label14.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label14.Font = new System.Drawing.Font("Calibri Light", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.DarkSeaGreen;
            this.label14.Location = new System.Drawing.Point(0, 519);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(914, 8);
            this.label14.TabIndex = 15;
            this.label14.Click += new System.EventHandler(this.label14_Click);
            // 
            // pnl_msn
            // 
            this.pnl_msn.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnl_msn.Controls.Add(this.elDivider1);
            this.pnl_msn.Controls.Add(this.ElDivider3);
            this.pnl_msn.Controls.Add(this.label17);
            this.pnl_msn.Controls.Add(this.label16);
            this.pnl_msn.Controls.Add(this.pictureBox1);
            this.pnl_msn.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.pnl_msn.Location = new System.Drawing.Point(0, 78);
            this.pnl_msn.Name = "pnl_msn";
            this.pnl_msn.Size = new System.Drawing.Size(912, 437);
            this.pnl_msn.TabIndex = 16;
            this.pnl_msn.Visible = false;
            this.pnl_msn.Paint += new System.Windows.Forms.PaintEventHandler(this.pnl_msn_Paint);
            // 
            // elDivider1
            // 
            this.elDivider1.FadeStyle = Klik.Windows.Forms.v1.EntryLib.DividerFadeStyles.Center;
            this.elDivider1.LineColor = System.Drawing.Color.DarkOrange;
            this.elDivider1.Location = new System.Drawing.Point(4, 232);
            this.elDivider1.Margin = new System.Windows.Forms.Padding(4);
            this.elDivider1.Name = "elDivider1";
            this.elDivider1.Size = new System.Drawing.Size(904, 2);
            this.elDivider1.TabIndex = 412;
            this.elDivider1.VisualStyle = Klik.Windows.Forms.v1.Common.ControlVisualStyles.Custom;
            // 
            // ElDivider3
            // 
            this.ElDivider3.FadeStyle = Klik.Windows.Forms.v1.EntryLib.DividerFadeStyles.Center;
            this.ElDivider3.LineColor = System.Drawing.Color.DarkGray;
            this.ElDivider3.Location = new System.Drawing.Point(34, 224);
            this.ElDivider3.Margin = new System.Windows.Forms.Padding(4);
            this.ElDivider3.Name = "ElDivider3";
            this.ElDivider3.Size = new System.Drawing.Size(844, 12);
            this.ElDivider3.TabIndex = 411;
            this.ElDivider3.VisualStyle = Klik.Windows.Forms.v1.Common.ControlVisualStyles.Custom;
            // 
            // label17
            // 
            this.label17.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.Color.DimGray;
            this.label17.Location = new System.Drawing.Point(346, 247);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(233, 23);
            this.label17.TabIndex = 18;
            this.label17.Text = "Intentar busqueda con otro Cliente.";
            // 
            // label16
            // 
            this.label16.Font = new System.Drawing.Font("Verdana", 20F);
            this.label16.ForeColor = System.Drawing.Color.DarkOrange;
            this.label16.Location = new System.Drawing.Point(303, 181);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(342, 39);
            this.label16.TabIndex = 17;
            this.label16.Text = "Busqueda sin resultado";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(422, 109);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(65, 69);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // Frm_Explo_Cliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(914, 527);
            this.Controls.Add(this.pnl_msn);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.bunifuSeparator1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.List_Cliente);
            this.Controls.Add(this.pnl_titu);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "Frm_Explo_Cliente";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Explorador de Cliente";
            this.pnl_titu.ResumeLayout(false);
            this.pnl_titu.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.elLabel1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.pnl_msn.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.elDivider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ElDivider3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private System.Windows.Forms.Panel pnl_titu;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_cerrar;
        private System.Windows.Forms.Button btn_minimi;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListView List_Cliente;
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
        private System.Windows.Forms.ToolStripMenuItem nuevoClienteToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem editarClienteToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem mostrarClienteToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem bt_copiarIDCliente;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label lblcont;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Panel pnl_msn;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.PictureBox pictureBox1;
        private Klik.Windows.Forms.v1.EntryLib.ELLabel elLabel1;
        public Bunifu.Framework.UI.BunifuMaterialTextbox txt_buscar;
        private FontAwesome.Sharp.IconButton Pb_Editar2;
        private FontAwesome.Sharp.IconButton Pb_Agregar2;
        private FontAwesome.Sharp.IconButton iconButton1;
        internal Klik.Windows.Forms.v1.EntryLib.ELDivider elDivider1;
        internal Klik.Windows.Forms.v1.EntryLib.ELDivider ElDivider3;
    }
}