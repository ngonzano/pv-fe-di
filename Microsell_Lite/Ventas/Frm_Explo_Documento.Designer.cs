namespace Microsell_Lite.Ventas
{
    partial class Frm_Explo_Documento
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Explo_Documento));
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.pnl_titu = new System.Windows.Forms.Panel();
            this.btn_minimi = new System.Windows.Forms.Button();
            this.btn_cerrar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dtp_Final = new Guna.UI.WinForms.GunaDateTimePicker();
            this.btn_add2 = new FontAwesome.Sharp.IconButton();
            this.dtp_Inicial = new Guna.UI.WinForms.GunaDateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.iconButton1 = new FontAwesome.Sharp.IconButton();
            this.txt_buscar = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.elLabel1 = new Klik.Windows.Forms.v1.EntryLib.ELLabel();
            this.lblcont = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.lsv_Documento = new System.Windows.Forms.ListView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ventasPorDiaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.ventasPorMesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.imprimirDocumentoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.mostrarTodosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editarOperadorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label14 = new System.Windows.Forms.Label();
            this.pnl_msn = new System.Windows.Forms.Panel();
            this.elDivider2 = new Klik.Windows.Forms.v1.EntryLib.ELDivider();
            this.ElDivider3 = new Klik.Windows.Forms.v1.EntryLib.ELDivider();
            this.label16 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label17 = new System.Windows.Forms.Label();
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
            this.pnl_titu.Size = new System.Drawing.Size(1049, 33);
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
            this.btn_minimi.Location = new System.Drawing.Point(977, 4);
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
            this.btn_cerrar.Location = new System.Drawing.Point(1013, 4);
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
            this.label1.Location = new System.Drawing.Point(12, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(218, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Explorador de Documento";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightGray;
            this.panel1.Controls.Add(this.dtp_Final);
            this.panel1.Controls.Add(this.btn_add2);
            this.panel1.Controls.Add(this.dtp_Inicial);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.iconButton1);
            this.panel1.Controls.Add(this.txt_buscar);
            this.panel1.Controls.Add(this.elLabel1);
            this.panel1.Controls.Add(this.lblcont);
            this.panel1.Controls.Add(this.label15);
            this.panel1.Location = new System.Drawing.Point(0, 32);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1049, 37);
            this.panel1.TabIndex = 111;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // dtp_Final
            // 
            this.dtp_Final.BackColor = System.Drawing.Color.Transparent;
            this.dtp_Final.BaseColor = System.Drawing.Color.White;
            this.dtp_Final.BorderColor = System.Drawing.Color.Silver;
            this.dtp_Final.BorderSize = 1;
            this.dtp_Final.CustomFormat = null;
            this.dtp_Final.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
            this.dtp_Final.FocusedColor = System.Drawing.Color.DodgerBlue;
            this.dtp_Final.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtp_Final.ForeColor = System.Drawing.Color.Black;
            this.dtp_Final.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_Final.Location = new System.Drawing.Point(546, 3);
            this.dtp_Final.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtp_Final.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtp_Final.Name = "dtp_Final";
            this.dtp_Final.OnHoverBaseColor = System.Drawing.Color.White;
            this.dtp_Final.OnHoverBorderColor = System.Drawing.Color.DodgerBlue;
            this.dtp_Final.OnHoverForeColor = System.Drawing.Color.DodgerBlue;
            this.dtp_Final.OnPressedColor = System.Drawing.Color.Black;
            this.dtp_Final.Radius = 10;
            this.dtp_Final.Size = new System.Drawing.Size(116, 30);
            this.dtp_Final.TabIndex = 577;
            this.dtp_Final.Text = "9/04/2021";
            this.dtp_Final.Value = new System.DateTime(2021, 4, 9, 0, 46, 1, 513);
            // 
            // btn_add2
            // 
            this.btn_add2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_add2.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_add2.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btn_add2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.WhiteSmoke;
            this.btn_add2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightGray;
            this.btn_add2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_add2.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_add2.ForeColor = System.Drawing.Color.DimGray;
            this.btn_add2.IconChar = FontAwesome.Sharp.IconChar.LayerGroup;
            this.btn_add2.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btn_add2.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btn_add2.IconSize = 25;
            this.btn_add2.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btn_add2.Location = new System.Drawing.Point(683, 5);
            this.btn_add2.Name = "btn_add2";
            this.btn_add2.Size = new System.Drawing.Size(118, 30);
            this.btn_add2.TabIndex = 415;
            this.btn_add2.Text = "Consultar";
            this.btn_add2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTip1.SetToolTip(this.btn_add2, "Consultar Fecha");
            this.btn_add2.UseVisualStyleBackColor = false;
            this.btn_add2.Click += new System.EventHandler(this.btn_add2_Click);
            // 
            // dtp_Inicial
            // 
            this.dtp_Inicial.BackColor = System.Drawing.Color.Transparent;
            this.dtp_Inicial.BaseColor = System.Drawing.Color.White;
            this.dtp_Inicial.BorderColor = System.Drawing.Color.Silver;
            this.dtp_Inicial.BorderSize = 1;
            this.dtp_Inicial.CustomFormat = null;
            this.dtp_Inicial.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
            this.dtp_Inicial.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dtp_Inicial.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtp_Inicial.ForeColor = System.Drawing.Color.Black;
            this.dtp_Inicial.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_Inicial.Location = new System.Drawing.Point(308, 3);
            this.dtp_Inicial.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtp_Inicial.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtp_Inicial.Name = "dtp_Inicial";
            this.dtp_Inicial.OnHoverBaseColor = System.Drawing.Color.White;
            this.dtp_Inicial.OnHoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dtp_Inicial.OnHoverForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dtp_Inicial.OnPressedColor = System.Drawing.Color.Black;
            this.dtp_Inicial.Radius = 10;
            this.dtp_Inicial.Size = new System.Drawing.Size(116, 30);
            this.dtp_Inicial.TabIndex = 576;
            this.dtp_Inicial.Text = "14/04/2021";
            this.dtp_Inicial.Value = new System.DateTime(2021, 4, 14, 0, 0, 0, 0);
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.DimGray;
            this.label5.Location = new System.Drawing.Point(452, 11);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(102, 18);
            this.label5.TabIndex = 417;
            this.label5.Text = "Fecha Final:";
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.DimGray;
            this.label4.Location = new System.Drawing.Point(206, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(114, 18);
            this.label4.TabIndex = 416;
            this.label4.Text = "Fecha Inicial:";
            // 
            // iconButton1
            // 
            this.iconButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.iconButton1.BackColor = System.Drawing.Color.LightGray;
            this.iconButton1.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.iconButton1.FlatAppearance.BorderSize = 0;
            this.iconButton1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.iconButton1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightGray;
            this.iconButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButton1.ForeColor = System.Drawing.Color.Transparent;
            this.iconButton1.IconChar = FontAwesome.Sharp.IconChar.Search;
            this.iconButton1.IconColor = System.Drawing.Color.DimGray;
            this.iconButton1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton1.IconSize = 25;
            this.iconButton1.Location = new System.Drawing.Point(997, 7);
            this.iconButton1.Name = "iconButton1";
            this.iconButton1.Size = new System.Drawing.Size(31, 25);
            this.iconButton1.TabIndex = 172;
            this.iconButton1.UseVisualStyleBackColor = false;
            // 
            // txt_buscar
            // 
            this.txt_buscar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_buscar.BackColor = System.Drawing.Color.LightGray;
            this.txt_buscar.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_buscar.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_buscar.ForeColor = System.Drawing.Color.DimGray;
            this.txt_buscar.HintForeColor = System.Drawing.Color.DimGray;
            this.txt_buscar.HintText = "Buscar Documento";
            this.txt_buscar.isPassword = false;
            this.txt_buscar.LineFocusedColor = System.Drawing.Color.LightGray;
            this.txt_buscar.LineIdleColor = System.Drawing.Color.LightGray;
            this.txt_buscar.LineMouseHoverColor = System.Drawing.Color.LightGray;
            this.txt_buscar.LineThickness = 3;
            this.txt_buscar.Location = new System.Drawing.Point(844, 6);
            this.txt_buscar.Margin = new System.Windows.Forms.Padding(4);
            this.txt_buscar.Name = "txt_buscar";
            this.txt_buscar.Size = new System.Drawing.Size(146, 27);
            this.txt_buscar.TabIndex = 1;
            this.txt_buscar.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txt_buscar.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_buscar_KeyDown);
            this.txt_buscar.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_buscar_KeyPress);
            this.txt_buscar.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_buscar_KeyUp);
            // 
            // elLabel1
            // 
            this.elLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.elLabel1.BackgroundStyle.GradientEndColor = System.Drawing.Color.LightGray;
            this.elLabel1.BackgroundStyle.GradientStartColor = System.Drawing.Color.LightGray;
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
            this.elLabel1.Location = new System.Drawing.Point(830, 5);
            this.elLabel1.Name = "elLabel1";
            this.elLabel1.Size = new System.Drawing.Size(204, 29);
            this.elLabel1.TabIndex = 18;
            this.elLabel1.TabStop = false;
            this.elLabel1.VisualStyle = Klik.Windows.Forms.v1.Common.ControlVisualStyles.Custom;
            // 
            // lblcont
            // 
            this.lblcont.BackColor = System.Drawing.Color.LightGray;
            this.lblcont.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblcont.ForeColor = System.Drawing.Color.DimGray;
            this.lblcont.Location = new System.Drawing.Point(112, 11);
            this.lblcont.Name = "lblcont";
            this.lblcont.Size = new System.Drawing.Size(83, 18);
            this.lblcont.TabIndex = 16;
            this.lblcont.Text = "..";
            this.lblcont.Click += new System.EventHandler(this.lblcont_Click);
            // 
            // label15
            // 
            this.label15.BackColor = System.Drawing.Color.LightGray;
            this.label15.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.DimGray;
            this.label15.Location = new System.Drawing.Point(4, 2);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(113, 33);
            this.label15.TabIndex = 16;
            this.label15.Text = "Total Items:";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label15.Click += new System.EventHandler(this.label15_Click);
            // 
            // lsv_Documento
            // 
            this.lsv_Documento.ContextMenuStrip = this.contextMenuStrip1;
            this.lsv_Documento.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lsv_Documento.ForeColor = System.Drawing.Color.DimGray;
            this.lsv_Documento.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lsv_Documento.HideSelection = false;
            this.lsv_Documento.Location = new System.Drawing.Point(0, 68);
            this.lsv_Documento.Name = "lsv_Documento";
            this.lsv_Documento.Size = new System.Drawing.Size(1049, 522);
            this.lsv_Documento.TabIndex = 2;
            this.lsv_Documento.UseCompatibleStateImageBehavior = false;
            this.lsv_Documento.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lsv_Documento_MouseDoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ventasPorDiaToolStripMenuItem,
            this.toolStripSeparator1,
            this.ventasPorMesToolStripMenuItem,
            this.toolStripSeparator2,
            this.imprimirDocumentoToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(187, 82);
            // 
            // ventasPorDiaToolStripMenuItem
            // 
            this.ventasPorDiaToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("ventasPorDiaToolStripMenuItem.Image")));
            this.ventasPorDiaToolStripMenuItem.Name = "ventasPorDiaToolStripMenuItem";
            this.ventasPorDiaToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.ventasPorDiaToolStripMenuItem.Text = "Ventas Por Dia";
            this.ventasPorDiaToolStripMenuItem.Click += new System.EventHandler(this.ventasPorDiaToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(183, 6);
            // 
            // ventasPorMesToolStripMenuItem
            // 
            this.ventasPorMesToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("ventasPorMesToolStripMenuItem.Image")));
            this.ventasPorMesToolStripMenuItem.Name = "ventasPorMesToolStripMenuItem";
            this.ventasPorMesToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.ventasPorMesToolStripMenuItem.Text = "Ventas Por Mes";
            this.ventasPorMesToolStripMenuItem.Click += new System.EventHandler(this.ventasPorMesToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(183, 6);
            // 
            // imprimirDocumentoToolStripMenuItem
            // 
            this.imprimirDocumentoToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("imprimirDocumentoToolStripMenuItem.Image")));
            this.imprimirDocumentoToolStripMenuItem.Name = "imprimirDocumentoToolStripMenuItem";
            this.imprimirDocumentoToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.imprimirDocumentoToolStripMenuItem.Text = "Imprimir Documento";
            this.imprimirDocumentoToolStripMenuItem.Click += new System.EventHandler(this.imprimirDocumentoToolStripMenuItem_Click);
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
            this.label14.Location = new System.Drawing.Point(0, 593);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(1049, 8);
            this.label14.TabIndex = 15;
            this.label14.Click += new System.EventHandler(this.label14_Click);
            // 
            // pnl_msn
            // 
            this.pnl_msn.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnl_msn.Controls.Add(this.elDivider2);
            this.pnl_msn.Controls.Add(this.ElDivider3);
            this.pnl_msn.Controls.Add(this.label16);
            this.pnl_msn.Controls.Add(this.pictureBox1);
            this.pnl_msn.Controls.Add(this.label17);
            this.pnl_msn.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.pnl_msn.Location = new System.Drawing.Point(0, 68);
            this.pnl_msn.Name = "pnl_msn";
            this.pnl_msn.Size = new System.Drawing.Size(1049, 521);
            this.pnl_msn.TabIndex = 16;
            this.pnl_msn.Visible = false;
            // 
            // elDivider2
            // 
            this.elDivider2.FadeStyle = Klik.Windows.Forms.v1.EntryLib.DividerFadeStyles.Center;
            this.elDivider2.LineColor = System.Drawing.Color.DarkOrange;
            this.elDivider2.Location = new System.Drawing.Point(26, 256);
            this.elDivider2.Margin = new System.Windows.Forms.Padding(4);
            this.elDivider2.Name = "elDivider2";
            this.elDivider2.Size = new System.Drawing.Size(994, 2);
            this.elDivider2.TabIndex = 424;
            this.elDivider2.VisualStyle = Klik.Windows.Forms.v1.Common.ControlVisualStyles.Custom;
            // 
            // ElDivider3
            // 
            this.ElDivider3.FadeStyle = Klik.Windows.Forms.v1.EntryLib.DividerFadeStyles.Center;
            this.ElDivider3.LineColor = System.Drawing.Color.DarkGray;
            this.ElDivider3.Location = new System.Drawing.Point(14, 248);
            this.ElDivider3.Margin = new System.Windows.Forms.Padding(4);
            this.ElDivider3.Name = "ElDivider3";
            this.ElDivider3.Size = new System.Drawing.Size(1019, 10);
            this.ElDivider3.TabIndex = 423;
            this.ElDivider3.VisualStyle = Klik.Windows.Forms.v1.Common.ControlVisualStyles.Custom;
            // 
            // label16
            // 
            this.label16.Font = new System.Drawing.Font("Verdana", 20F);
            this.label16.ForeColor = System.Drawing.Color.DarkOrange;
            this.label16.Location = new System.Drawing.Point(357, 213);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(333, 39);
            this.label16.TabIndex = 422;
            this.label16.Text = "Busqueda sin resultado";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(481, 125);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(85, 85);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 421;
            this.pictureBox1.TabStop = false;
            // 
            // label17
            // 
            this.label17.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.Color.DimGray;
            this.label17.Location = new System.Drawing.Point(3, 262);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(1046, 24);
            this.label17.TabIndex = 18;
            this.label17.Text = "Intentar busqueda con otro Documento.";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Frm_Explo_Documento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1049, 601);
            this.Controls.Add(this.pnl_msn);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.lsv_Documento);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnl_titu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "Frm_Explo_Documento";
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

        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private System.Windows.Forms.Panel pnl_titu;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_cerrar;
        private System.Windows.Forms.Button btn_minimi;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListView lsv_Documento;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ToolStripMenuItem mostrarTodosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editarOperadorToolStripMenuItem;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label lblcont;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Panel pnl_msn;
        private System.Windows.Forms.Label label17;
        private Klik.Windows.Forms.v1.EntryLib.ELLabel elLabel1;
        public Bunifu.Framework.UI.BunifuMaterialTextbox txt_buscar;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ventasPorMesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ventasPorDiaToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem imprimirDocumentoToolStripMenuItem;
        private FontAwesome.Sharp.IconButton iconButton1;
        internal Klik.Windows.Forms.v1.EntryLib.ELDivider elDivider2;
        internal Klik.Windows.Forms.v1.EntryLib.ELDivider ElDivider3;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.PictureBox pictureBox1;
        private FontAwesome.Sharp.IconButton btn_add2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private Guna.UI.WinForms.GunaDateTimePicker dtp_Final;
        private Guna.UI.WinForms.GunaDateTimePicker dtp_Inicial;
    }
}