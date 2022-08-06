namespace Microsell_Lite.Cotizacion
{
    partial class Frm_Explo_Cotizacion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Explo_Cotizacion));
            Klik.Windows.Forms.v1.Common.PaintStyle paintStyle1 = new Klik.Windows.Forms.v1.Common.PaintStyle();
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.pnl_titu = new System.Windows.Forms.Panel();
            this.btn_minimi = new System.Windows.Forms.Button();
            this.btn_cerrar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lsv_Cotizacion = new System.Windows.Forms.ListView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cotizacionPorDiaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.cotizacionPorMesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.imprimirCotizacionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.atenderCotizacionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbl_idpro = new System.Windows.Forms.Label();
            this.lbl_NomProd = new System.Windows.Forms.Label();
            this.bunifuSeparator1 = new Bunifu.Framework.UI.BunifuSeparator();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btn_add2 = new FontAwesome.Sharp.IconButton();
            this.mostrarTodosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editarOperadorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lbl_Pre_Unt = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.pnl_msn = new System.Windows.Forms.Panel();
            this.elDivider2 = new Klik.Windows.Forms.v1.EntryLib.ELDivider();
            this.ElDivider3 = new Klik.Windows.Forms.v1.EntryLib.ELDivider();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lbl_Cant = new System.Windows.Forms.Label();
            this.lbl_Und = new System.Windows.Forms.Label();
            this.lbl_Uti_unit = new System.Windows.Forms.Label();
            this.lbl_tipoProd = new System.Windows.Forms.Label();
            this.lbl_import = new System.Windows.Forms.Label();
            this.elLabel1 = new Klik.Windows.Forms.v1.EntryLib.ELLabel();
            this.txt_buscar = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dtp_Final = new Guna.UI.WinForms.GunaDateTimePicker();
            this.lbl_items = new System.Windows.Forms.Label();
            this.dtp_Inicial = new Guna.UI.WinForms.GunaDateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.iconButton1 = new FontAwesome.Sharp.IconButton();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.lbl_nomProduc = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.pnl_titu.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.pnl_msn.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.elDivider2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ElDivider3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.elLabel1)).BeginInit();
            this.panel1.SuspendLayout();
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
            this.pnl_titu.Size = new System.Drawing.Size(1158, 51);
            this.pnl_titu.TabIndex = 44;
            this.pnl_titu.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnl_titu_MouseMove);
            // 
            // btn_minimi
            // 
            this.btn_minimi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_minimi.FlatAppearance.BorderSize = 0;
            this.btn_minimi.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SkyBlue;
            this.btn_minimi.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SkyBlue;
            this.btn_minimi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_minimi.Font = new System.Drawing.Font("Calibri Light", 8F, System.Drawing.FontStyle.Italic);
            this.btn_minimi.ForeColor = System.Drawing.Color.White;
            this.btn_minimi.Image = ((System.Drawing.Image)(resources.GetObject("btn_minimi.Image")));
            this.btn_minimi.Location = new System.Drawing.Point(1074, 10);
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
            this.btn_cerrar.Font = new System.Drawing.Font("Calibri Light", 8F, System.Drawing.FontStyle.Italic);
            this.btn_cerrar.ForeColor = System.Drawing.Color.White;
            this.btn_cerrar.Image = ((System.Drawing.Image)(resources.GetObject("btn_cerrar.Image")));
            this.btn_cerrar.Location = new System.Drawing.Point(1111, 9);
            this.btn_cerrar.Name = "btn_cerrar";
            this.btn_cerrar.Size = new System.Drawing.Size(30, 30);
            this.btn_cerrar.TabIndex = 6;
            this.btn_cerrar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_cerrar.UseVisualStyleBackColor = true;
            this.btn_cerrar.Click += new System.EventHandler(this.btn_cerrar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri Light", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label1.Location = new System.Drawing.Point(12, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(168, 19);
            this.label1.TabIndex = 33;
            this.label1.Text = "Explorador de Cotizacion";
            // 
            // lsv_Cotizacion
            // 
            this.lsv_Cotizacion.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lsv_Cotizacion.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lsv_Cotizacion.ContextMenuStrip = this.contextMenuStrip1;
            this.lsv_Cotizacion.Font = new System.Drawing.Font("Verdana", 9F);
            this.lsv_Cotizacion.ForeColor = System.Drawing.Color.DarkGray;
            this.lsv_Cotizacion.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lsv_Cotizacion.HideSelection = false;
            this.lsv_Cotizacion.Location = new System.Drawing.Point(0, 134);
            this.lsv_Cotizacion.Name = "lsv_Cotizacion";
            this.lsv_Cotizacion.Size = new System.Drawing.Size(1156, 468);
            this.lsv_Cotizacion.TabIndex = 25;
            this.lsv_Cotizacion.UseCompatibleStateImageBehavior = false;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cotizacionPorDiaToolStripMenuItem,
            this.toolStripSeparator3,
            this.cotizacionPorMesToolStripMenuItem,
            this.toolStripSeparator2,
            this.imprimirCotizacionToolStripMenuItem,
            this.toolStripSeparator1,
            this.atenderCotizacionToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(204, 110);
            // 
            // cotizacionPorDiaToolStripMenuItem
            // 
            this.cotizacionPorDiaToolStripMenuItem.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cotizacionPorDiaToolStripMenuItem.ForeColor = System.Drawing.Color.DimGray;
            this.cotizacionPorDiaToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("cotizacionPorDiaToolStripMenuItem.Image")));
            this.cotizacionPorDiaToolStripMenuItem.Name = "cotizacionPorDiaToolStripMenuItem";
            this.cotizacionPorDiaToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.cotizacionPorDiaToolStripMenuItem.Text = "Cotizacion Por Dia";
            this.cotizacionPorDiaToolStripMenuItem.Click += new System.EventHandler(this.cotizacionPorDiaToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(200, 6);
            // 
            // cotizacionPorMesToolStripMenuItem
            // 
            this.cotizacionPorMesToolStripMenuItem.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cotizacionPorMesToolStripMenuItem.ForeColor = System.Drawing.Color.DimGray;
            this.cotizacionPorMesToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("cotizacionPorMesToolStripMenuItem.Image")));
            this.cotizacionPorMesToolStripMenuItem.Name = "cotizacionPorMesToolStripMenuItem";
            this.cotizacionPorMesToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.cotizacionPorMesToolStripMenuItem.Text = "Cotizacion Por Mes";
            this.cotizacionPorMesToolStripMenuItem.Click += new System.EventHandler(this.cotizacionPorMesToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(200, 6);
            // 
            // imprimirCotizacionToolStripMenuItem
            // 
            this.imprimirCotizacionToolStripMenuItem.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.imprimirCotizacionToolStripMenuItem.ForeColor = System.Drawing.Color.DimGray;
            this.imprimirCotizacionToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("imprimirCotizacionToolStripMenuItem.Image")));
            this.imprimirCotizacionToolStripMenuItem.Name = "imprimirCotizacionToolStripMenuItem";
            this.imprimirCotizacionToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.imprimirCotizacionToolStripMenuItem.Text = "Imprimir Cotizacion";
            this.imprimirCotizacionToolStripMenuItem.Click += new System.EventHandler(this.imprimirCotizacionToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(200, 6);
            // 
            // atenderCotizacionToolStripMenuItem
            // 
            this.atenderCotizacionToolStripMenuItem.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.atenderCotizacionToolStripMenuItem.ForeColor = System.Drawing.Color.DimGray;
            this.atenderCotizacionToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("atenderCotizacionToolStripMenuItem.Image")));
            this.atenderCotizacionToolStripMenuItem.Name = "atenderCotizacionToolStripMenuItem";
            this.atenderCotizacionToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.atenderCotizacionToolStripMenuItem.Text = "Atender Cotizacion";
            this.atenderCotizacionToolStripMenuItem.Click += new System.EventHandler(this.atenderCotizacionToolStripMenuItem_Click);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.SystemColors.Control;
            this.label2.Font = new System.Drawing.Font("Verdana", 9F);
            this.label2.ForeColor = System.Drawing.Color.DimGray;
            this.label2.Location = new System.Drawing.Point(107, 101);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 18);
            this.label2.TabIndex = 3;
            this.label2.Text = "FECHA";
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.SystemColors.Control;
            this.label3.Font = new System.Drawing.Font("Verdana", 9F);
            this.label3.ForeColor = System.Drawing.Color.DimGray;
            this.label3.Location = new System.Drawing.Point(205, 101);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 18);
            this.label3.TabIndex = 4;
            this.label3.Text = "TOTAL S/";
            // 
            // lbl_idpro
            // 
            this.lbl_idpro.BackColor = System.Drawing.SystemColors.Control;
            this.lbl_idpro.Font = new System.Drawing.Font("Verdana", 9F);
            this.lbl_idpro.ForeColor = System.Drawing.Color.DimGray;
            this.lbl_idpro.Location = new System.Drawing.Point(160, 171);
            this.lbl_idpro.Name = "lbl_idpro";
            this.lbl_idpro.Size = new System.Drawing.Size(100, 18);
            this.lbl_idpro.TabIndex = 5;
            this.lbl_idpro.Text = "0";
            this.lbl_idpro.Visible = false;
            // 
            // lbl_NomProd
            // 
            this.lbl_NomProd.BackColor = System.Drawing.SystemColors.Control;
            this.lbl_NomProd.Font = new System.Drawing.Font("Verdana", 9F);
            this.lbl_NomProd.ForeColor = System.Drawing.Color.DimGray;
            this.lbl_NomProd.Location = new System.Drawing.Point(160, 204);
            this.lbl_NomProd.Name = "lbl_NomProd";
            this.lbl_NomProd.Size = new System.Drawing.Size(110, 18);
            this.lbl_NomProd.TabIndex = 6;
            this.lbl_NomProd.Text = "00";
            this.lbl_NomProd.Visible = false;
            // 
            // bunifuSeparator1
            // 
            this.bunifuSeparator1.BackColor = System.Drawing.Color.Transparent;
            this.bunifuSeparator1.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(211)))), ((int)(((byte)(211)))));
            this.bunifuSeparator1.LineThickness = 1;
            this.bunifuSeparator1.Location = new System.Drawing.Point(0, 114);
            this.bunifuSeparator1.Name = "bunifuSeparator1";
            this.bunifuSeparator1.Size = new System.Drawing.Size(1156, 10);
            this.bunifuSeparator1.TabIndex = 11;
            this.bunifuSeparator1.Transparency = 255;
            this.bunifuSeparator1.Vertical = false;
            // 
            // toolTip1
            // 
            this.toolTip1.BackColor = System.Drawing.SystemColors.Control;
            this.toolTip1.IsBalloon = true;
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
            this.btn_add2.Location = new System.Drawing.Point(650, 7);
            this.btn_add2.Name = "btn_add2";
            this.btn_add2.Size = new System.Drawing.Size(117, 30);
            this.btn_add2.TabIndex = 411;
            this.btn_add2.Text = "Consultar";
            this.btn_add2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTip1.SetToolTip(this.btn_add2, "Consultar Fecha");
            this.btn_add2.UseVisualStyleBackColor = false;
            this.btn_add2.Click += new System.EventHandler(this.btn_add2_Click);
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
            // lbl_Pre_Unt
            // 
            this.lbl_Pre_Unt.BackColor = System.Drawing.SystemColors.Control;
            this.lbl_Pre_Unt.Font = new System.Drawing.Font("Verdana", 9F);
            this.lbl_Pre_Unt.ForeColor = System.Drawing.Color.DimGray;
            this.lbl_Pre_Unt.Location = new System.Drawing.Point(316, 237);
            this.lbl_Pre_Unt.Name = "lbl_Pre_Unt";
            this.lbl_Pre_Unt.Size = new System.Drawing.Size(74, 18);
            this.lbl_Pre_Unt.TabIndex = 13;
            this.lbl_Pre_Unt.Text = "00";
            this.lbl_Pre_Unt.Visible = false;
            // 
            // label14
            // 
            this.label14.BackColor = System.Drawing.Color.DimGray;
            this.label14.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label14.Font = new System.Drawing.Font("Calibri Light", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.DimGray;
            this.label14.Location = new System.Drawing.Point(0, 605);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(1158, 8);
            this.label14.TabIndex = 15;
            // 
            // pnl_msn
            // 
            this.pnl_msn.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnl_msn.ContextMenuStrip = this.contextMenuStrip1;
            this.pnl_msn.Controls.Add(this.elDivider2);
            this.pnl_msn.Controls.Add(this.ElDivider3);
            this.pnl_msn.Controls.Add(this.label17);
            this.pnl_msn.Controls.Add(this.label16);
            this.pnl_msn.Controls.Add(this.pictureBox1);
            this.pnl_msn.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.pnl_msn.Location = new System.Drawing.Point(0, 94);
            this.pnl_msn.Name = "pnl_msn";
            this.pnl_msn.Size = new System.Drawing.Size(1156, 507);
            this.pnl_msn.TabIndex = 16;
            this.pnl_msn.Visible = false;
            // 
            // elDivider2
            // 
            this.elDivider2.FadeStyle = Klik.Windows.Forms.v1.EntryLib.DividerFadeStyles.Center;
            this.elDivider2.LineColor = System.Drawing.Color.DarkOrange;
            this.elDivider2.Location = new System.Drawing.Point(81, 257);
            this.elDivider2.Margin = new System.Windows.Forms.Padding(4);
            this.elDivider2.Name = "elDivider2";
            this.elDivider2.Size = new System.Drawing.Size(994, 2);
            this.elDivider2.TabIndex = 416;
            this.elDivider2.VisualStyle = Klik.Windows.Forms.v1.Common.ControlVisualStyles.Custom;
            // 
            // ElDivider3
            // 
            this.ElDivider3.FadeStyle = Klik.Windows.Forms.v1.EntryLib.DividerFadeStyles.Center;
            this.ElDivider3.LineColor = System.Drawing.Color.DarkGray;
            this.ElDivider3.Location = new System.Drawing.Point(69, 250);
            this.ElDivider3.Margin = new System.Windows.Forms.Padding(4);
            this.ElDivider3.Name = "ElDivider3";
            this.ElDivider3.Size = new System.Drawing.Size(1019, 10);
            this.ElDivider3.TabIndex = 415;
            this.ElDivider3.VisualStyle = Klik.Windows.Forms.v1.Common.ControlVisualStyles.Custom;
            // 
            // label17
            // 
            this.label17.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.Color.DimGray;
            this.label17.Location = new System.Drawing.Point(413, 271);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(331, 25);
            this.label17.TabIndex = 18;
            this.label17.Text = "Intentar busqueda con otra Cotizacion";
            // 
            // label16
            // 
            this.label16.Font = new System.Drawing.Font("Verdana", 20F);
            this.label16.ForeColor = System.Drawing.Color.DarkOrange;
            this.label16.Location = new System.Drawing.Point(410, 214);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(336, 39);
            this.label16.TabIndex = 17;
            this.label16.Text = "Busqueda sin resultado";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(542, 133);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(73, 74);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // lbl_Cant
            // 
            this.lbl_Cant.BackColor = System.Drawing.SystemColors.Control;
            this.lbl_Cant.Font = new System.Drawing.Font("Verdana", 9F);
            this.lbl_Cant.ForeColor = System.Drawing.Color.DimGray;
            this.lbl_Cant.Location = new System.Drawing.Point(416, 206);
            this.lbl_Cant.Name = "lbl_Cant";
            this.lbl_Cant.Size = new System.Drawing.Size(74, 18);
            this.lbl_Cant.TabIndex = 61;
            this.lbl_Cant.Text = "00";
            this.lbl_Cant.Visible = false;
            // 
            // lbl_Und
            // 
            this.lbl_Und.BackColor = System.Drawing.SystemColors.Control;
            this.lbl_Und.Font = new System.Drawing.Font("Verdana", 9F);
            this.lbl_Und.ForeColor = System.Drawing.Color.DimGray;
            this.lbl_Und.Location = new System.Drawing.Point(416, 170);
            this.lbl_Und.Name = "lbl_Und";
            this.lbl_Und.Size = new System.Drawing.Size(110, 18);
            this.lbl_Und.TabIndex = 58;
            this.lbl_Und.Text = "00";
            this.lbl_Und.Visible = false;
            // 
            // lbl_Uti_unit
            // 
            this.lbl_Uti_unit.BackColor = System.Drawing.SystemColors.Control;
            this.lbl_Uti_unit.Font = new System.Drawing.Font("Verdana", 9F);
            this.lbl_Uti_unit.ForeColor = System.Drawing.Color.DimGray;
            this.lbl_Uti_unit.Location = new System.Drawing.Point(416, 134);
            this.lbl_Uti_unit.Name = "lbl_Uti_unit";
            this.lbl_Uti_unit.Size = new System.Drawing.Size(110, 18);
            this.lbl_Uti_unit.TabIndex = 57;
            this.lbl_Uti_unit.Text = "0";
            this.lbl_Uti_unit.Visible = false;
            // 
            // lbl_tipoProd
            // 
            this.lbl_tipoProd.BackColor = System.Drawing.SystemColors.Control;
            this.lbl_tipoProd.Font = new System.Drawing.Font("Verdana", 9F);
            this.lbl_tipoProd.ForeColor = System.Drawing.Color.DimGray;
            this.lbl_tipoProd.Location = new System.Drawing.Point(416, 152);
            this.lbl_tipoProd.Name = "lbl_tipoProd";
            this.lbl_tipoProd.Size = new System.Drawing.Size(54, 18);
            this.lbl_tipoProd.TabIndex = 56;
            this.lbl_tipoProd.Text = "00";
            this.lbl_tipoProd.Visible = false;
            // 
            // lbl_import
            // 
            this.lbl_import.BackColor = System.Drawing.SystemColors.Control;
            this.lbl_import.Font = new System.Drawing.Font("Verdana", 9F);
            this.lbl_import.ForeColor = System.Drawing.Color.DimGray;
            this.lbl_import.Location = new System.Drawing.Point(416, 188);
            this.lbl_import.Name = "lbl_import";
            this.lbl_import.Size = new System.Drawing.Size(110, 18);
            this.lbl_import.TabIndex = 62;
            this.lbl_import.Text = "00";
            this.lbl_import.Visible = false;
            // 
            // elLabel1
            // 
            this.elLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.elLabel1.BackgroundStyle.GradientEndColor = System.Drawing.Color.Gainsboro;
            this.elLabel1.BackgroundStyle.GradientStartColor = System.Drawing.Color.Gainsboro;
            this.elLabel1.BorderStyle.BorderShape.BottomLeft = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.elLabel1.BorderStyle.BorderShape.BottomRight = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.elLabel1.BorderStyle.BorderShape.TopLeft = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.elLabel1.BorderStyle.BorderShape.TopRight = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.elLabel1.BorderStyle.GradientEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.elLabel1.BorderStyle.GradientStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.elLabel1.BorderStyle.SolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.elLabel1.Cursor = System.Windows.Forms.Cursors.Default;
            paintStyle1.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            paintStyle1.SolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(240)))), ((int)(((byte)(191)))));
            this.elLabel1.FlashStyle = paintStyle1;
            this.elLabel1.Location = new System.Drawing.Point(892, 7);
            this.elLabel1.Name = "elLabel1";
            this.elLabel1.Size = new System.Drawing.Size(251, 31);
            this.elLabel1.TabIndex = 18;
            this.elLabel1.TabStop = false;
            this.elLabel1.TextStyle.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.elLabel1.VisualStyle = Klik.Windows.Forms.v1.Common.ControlVisualStyles.Custom;
            // 
            // txt_buscar
            // 
            this.txt_buscar.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_buscar.AutoSize = true;
            this.txt_buscar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.txt_buscar.BackColor = System.Drawing.Color.Gainsboro;
            this.txt_buscar.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_buscar.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_buscar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txt_buscar.HintForeColor = System.Drawing.Color.DimGray;
            this.txt_buscar.HintText = "Buscar Cliente";
            this.txt_buscar.isPassword = false;
            this.txt_buscar.LineFocusedColor = System.Drawing.Color.Gainsboro;
            this.txt_buscar.LineIdleColor = System.Drawing.Color.Gainsboro;
            this.txt_buscar.LineMouseHoverColor = System.Drawing.Color.Gainsboro;
            this.txt_buscar.LineThickness = 1;
            this.txt_buscar.Location = new System.Drawing.Point(902, 9);
            this.txt_buscar.Margin = new System.Windows.Forms.Padding(4);
            this.txt_buscar.Name = "txt_buscar";
            this.txt_buscar.Size = new System.Drawing.Size(193, 27);
            this.txt_buscar.TabIndex = 0;
            this.txt_buscar.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txt_buscar.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_buscar_KeyDown);
            this.txt_buscar.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_buscar_KeyPress);
            this.txt_buscar.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_buscar_KeyUp);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.Gainsboro;
            this.panel1.Controls.Add(this.dtp_Final);
            this.panel1.Controls.Add(this.lbl_items);
            this.panel1.Controls.Add(this.dtp_Inicial);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.btn_add2);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.iconButton1);
            this.panel1.Controls.Add(this.txt_buscar);
            this.panel1.Controls.Add(this.elLabel1);
            this.panel1.Location = new System.Drawing.Point(0, 50);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1156, 45);
            this.panel1.TabIndex = 55;
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
            this.dtp_Final.Location = new System.Drawing.Point(522, 8);
            this.dtp_Final.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtp_Final.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtp_Final.Name = "dtp_Final";
            this.dtp_Final.OnHoverBaseColor = System.Drawing.Color.White;
            this.dtp_Final.OnHoverBorderColor = System.Drawing.Color.DodgerBlue;
            this.dtp_Final.OnHoverForeColor = System.Drawing.Color.DodgerBlue;
            this.dtp_Final.OnPressedColor = System.Drawing.Color.Black;
            this.dtp_Final.Radius = 10;
            this.dtp_Final.Size = new System.Drawing.Size(116, 30);
            this.dtp_Final.TabIndex = 579;
            this.dtp_Final.Text = "9/04/2021";
            this.dtp_Final.Value = new System.DateTime(2021, 4, 9, 0, 46, 1, 513);
            // 
            // lbl_items
            // 
            this.lbl_items.BackColor = System.Drawing.Color.Transparent;
            this.lbl_items.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_items.ForeColor = System.Drawing.Color.DimGray;
            this.lbl_items.Location = new System.Drawing.Point(13, 21);
            this.lbl_items.Name = "lbl_items";
            this.lbl_items.Size = new System.Drawing.Size(96, 18);
            this.lbl_items.TabIndex = 414;
            this.lbl_items.Text = "00";
            this.lbl_items.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.dtp_Inicial.Location = new System.Drawing.Point(274, 8);
            this.dtp_Inicial.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtp_Inicial.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtp_Inicial.Name = "dtp_Inicial";
            this.dtp_Inicial.OnHoverBaseColor = System.Drawing.Color.White;
            this.dtp_Inicial.OnHoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dtp_Inicial.OnHoverForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dtp_Inicial.OnPressedColor = System.Drawing.Color.Black;
            this.dtp_Inicial.Radius = 10;
            this.dtp_Inicial.Size = new System.Drawing.Size(116, 30);
            this.dtp_Inicial.TabIndex = 578;
            this.dtp_Inicial.Text = "9/04/2021";
            this.dtp_Inicial.Value = new System.DateTime(2021, 4, 9, 0, 46, 1, 513);
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.DimGray;
            this.label8.Location = new System.Drawing.Point(12, 5);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(96, 18);
            this.label8.TabIndex = 413;
            this.label8.Text = "Total Items";
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.DimGray;
            this.label5.Location = new System.Drawing.Point(414, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(102, 18);
            this.label5.TabIndex = 412;
            this.label5.Text = "Fecha Final:";
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.DimGray;
            this.label4.Location = new System.Drawing.Point(168, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(114, 18);
            this.label4.TabIndex = 411;
            this.label4.Text = "Fecha Inicial:";
            // 
            // iconButton1
            // 
            this.iconButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.iconButton1.BackColor = System.Drawing.Color.Gainsboro;
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
            this.iconButton1.Location = new System.Drawing.Point(1102, 11);
            this.iconButton1.Name = "iconButton1";
            this.iconButton1.Size = new System.Drawing.Size(32, 25);
            this.iconButton1.TabIndex = 56;
            this.iconButton1.UseVisualStyleBackColor = false;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.SystemColors.Control;
            this.label6.Font = new System.Drawing.Font("Verdana", 9F);
            this.label6.ForeColor = System.Drawing.Color.DimGray;
            this.label6.Location = new System.Drawing.Point(1056, 101);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 18);
            this.label6.TabIndex = 68;
            this.label6.Text = "USUARIO";
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.SystemColors.Control;
            this.label7.Font = new System.Drawing.Font("Verdana", 9F);
            this.label7.ForeColor = System.Drawing.Color.DimGray;
            this.label7.Location = new System.Drawing.Point(657, 101);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(70, 18);
            this.label7.TabIndex = 67;
            this.label7.Text = "RUC - DNI";
            // 
            // label12
            // 
            this.label12.BackColor = System.Drawing.SystemColors.Control;
            this.label12.Font = new System.Drawing.Font("Verdana", 9F);
            this.label12.ForeColor = System.Drawing.Color.DimGray;
            this.label12.Location = new System.Drawing.Point(755, 101);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(107, 18);
            this.label12.TabIndex = 65;
            this.label12.Text = "CONDICIONES";
            // 
            // label18
            // 
            this.label18.BackColor = System.Drawing.SystemColors.Control;
            this.label18.Font = new System.Drawing.Font("Verdana", 9F);
            this.label18.ForeColor = System.Drawing.Color.DimGray;
            this.label18.Location = new System.Drawing.Point(407, 101);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(69, 18);
            this.label18.TabIndex = 64;
            this.label18.Text = "CLIENTE";
            // 
            // label19
            // 
            this.label19.BackColor = System.Drawing.SystemColors.Control;
            this.label19.Font = new System.Drawing.Font("Verdana", 9F);
            this.label19.ForeColor = System.Drawing.Color.DimGray;
            this.label19.Location = new System.Drawing.Point(304, 101);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(57, 18);
            this.label19.TabIndex = 63;
            this.label19.Text = "ESTADO";
            // 
            // lbl_nomProduc
            // 
            this.lbl_nomProduc.BackColor = System.Drawing.SystemColors.Control;
            this.lbl_nomProduc.Font = new System.Drawing.Font("Verdana", 9F);
            this.lbl_nomProduc.ForeColor = System.Drawing.Color.DimGray;
            this.lbl_nomProduc.Location = new System.Drawing.Point(416, 224);
            this.lbl_nomProduc.Name = "lbl_nomProduc";
            this.lbl_nomProduc.Size = new System.Drawing.Size(74, 18);
            this.lbl_nomProduc.TabIndex = 410;
            this.lbl_nomProduc.Text = "00";
            this.lbl_nomProduc.Visible = false;
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.SystemColors.Control;
            this.label9.Font = new System.Drawing.Font("Verdana", 9F);
            this.label9.ForeColor = System.Drawing.Color.DimGray;
            this.label9.Location = new System.Drawing.Point(6, 101);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(31, 18);
            this.label9.TabIndex = 411;
            this.label9.Text = "ID. COT.";
            // 
            // Frm_Explo_Cotizacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1158, 613);
            this.Controls.Add(this.pnl_msn);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.lsv_Cotizacion);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnl_titu);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.lbl_nomProduc);
            this.Controls.Add(this.lbl_Pre_Unt);
            this.Controls.Add(this.lbl_Cant);
            this.Controls.Add(this.lbl_NomProd);
            this.Controls.Add(this.lbl_Und);
            this.Controls.Add(this.lbl_idpro);
            this.Controls.Add(this.lbl_Uti_unit);
            this.Controls.Add(this.lbl_tipoProd);
            this.Controls.Add(this.lbl_import);
            this.Controls.Add(this.bunifuSeparator1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "Frm_Explo_Cotizacion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Explorador de Productos";
            this.Load += new System.EventHandler(this.Frm_Listar_Producto_Compra_Load);
            this.pnl_titu.ResumeLayout(false);
            this.pnl_titu.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.pnl_msn.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.elDivider2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ElDivider3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.elLabel1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private System.Windows.Forms.Panel pnl_titu;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_cerrar;
        private System.Windows.Forms.Button btn_minimi;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListView lsv_Cotizacion;
        private Bunifu.Framework.UI.BunifuSeparator bunifuSeparator1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ToolStripMenuItem mostrarTodosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editarOperadorToolStripMenuItem;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Panel pnl_msn;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
        private Klik.Windows.Forms.v1.EntryLib.ELLabel elLabel1;
        private FontAwesome.Sharp.IconButton iconButton1;
        public Bunifu.Framework.UI.BunifuMaterialTextbox txt_buscar;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        public System.Windows.Forms.Label lbl_tipoProd;
        public System.Windows.Forms.Label lbl_Und;
        public System.Windows.Forms.Label lbl_Uti_unit;
        public System.Windows.Forms.Label lbl_import;
        public System.Windows.Forms.Label lbl_Cant;
        public System.Windows.Forms.Label lbl_nomProduc;
        public System.Windows.Forms.Label lbl_idpro;
        public System.Windows.Forms.Label lbl_NomProd;
        public System.Windows.Forms.Label lbl_Pre_Unt;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private FontAwesome.Sharp.IconButton btn_add2;
        private System.Windows.Forms.Label lbl_items;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem cotizacionPorDiaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cotizacionPorMesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem imprimirCotizacionToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem atenderCotizacionToolStripMenuItem;
        internal Klik.Windows.Forms.v1.EntryLib.ELDivider elDivider2;
        internal Klik.Windows.Forms.v1.EntryLib.ELDivider ElDivider3;
        private Guna.UI.WinForms.GunaDateTimePicker dtp_Final;
        private Guna.UI.WinForms.GunaDateTimePicker dtp_Inicial;
        // private FontAwesome.Sharp.IconButton btn_Add;
    }
}