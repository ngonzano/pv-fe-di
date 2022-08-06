namespace Microsell_Lite.Compras
{
    partial class Frm_Explo_Compras
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Explo_Compras));
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.pnl_titu = new System.Windows.Forms.Panel();
            this.btn_minimi = new System.Windows.Forms.Button();
            this.btn_cerrar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dtp_Final = new Guna.UI.WinForms.GunaDateTimePicker();
            this.dtp_Inicial = new Guna.UI.WinForms.GunaDateTimePicker();
            this.btn_Consultar = new FontAwesome.Sharp.IconButton();
            this.label10 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.iconButton1 = new FontAwesome.Sharp.IconButton();
            this.Pb_Agregar2 = new FontAwesome.Sharp.IconButton();
            this.txt_buscar = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.elLabel1 = new Klik.Windows.Forms.v1.EntryLib.ELLabel();
            this.lblcont = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.Lsv_Compras = new System.Windows.Forms.ListView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.nuevoCompraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mostrarCompraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.bt_copiarIDCompra = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.mostrarComprasDelDiaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.mostarComprasDelMesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.label14 = new System.Windows.Forms.Label();
            this.pnl_msn = new System.Windows.Forms.Panel();
            this.elDivider2 = new Klik.Windows.Forms.v1.EntryLib.ELDivider();
            this.ElDivider3 = new Klik.Windows.Forms.v1.EntryLib.ELDivider();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
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
            this.pnl_titu.Size = new System.Drawing.Size(1049, 47);
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
            this.btn_minimi.Location = new System.Drawing.Point(967, 8);
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
            this.btn_cerrar.Location = new System.Drawing.Point(1007, 8);
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
            this.label1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label1.Location = new System.Drawing.Point(12, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(197, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Explorador de Compras";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightGray;
            this.panel1.Controls.Add(this.dtp_Final);
            this.panel1.Controls.Add(this.dtp_Inicial);
            this.panel1.Controls.Add(this.btn_Consultar);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.iconButton1);
            this.panel1.Controls.Add(this.Pb_Agregar2);
            this.panel1.Controls.Add(this.txt_buscar);
            this.panel1.Controls.Add(this.elLabel1);
            this.panel1.Controls.Add(this.lblcont);
            this.panel1.Controls.Add(this.label15);
            this.panel1.Location = new System.Drawing.Point(0, 44);
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
            this.dtp_Final.Location = new System.Drawing.Point(564, 3);
            this.dtp_Final.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtp_Final.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtp_Final.Name = "dtp_Final";
            this.dtp_Final.OnHoverBaseColor = System.Drawing.Color.White;
            this.dtp_Final.OnHoverBorderColor = System.Drawing.Color.DodgerBlue;
            this.dtp_Final.OnHoverForeColor = System.Drawing.Color.DodgerBlue;
            this.dtp_Final.OnPressedColor = System.Drawing.Color.Black;
            this.dtp_Final.Radius = 10;
            this.dtp_Final.Size = new System.Drawing.Size(116, 30);
            this.dtp_Final.TabIndex = 583;
            this.dtp_Final.Text = "9/04/2021";
            this.dtp_Final.Value = new System.DateTime(2021, 4, 9, 0, 46, 1, 513);
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
            this.dtp_Inicial.Location = new System.Drawing.Point(327, 3);
            this.dtp_Inicial.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtp_Inicial.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtp_Inicial.Name = "dtp_Inicial";
            this.dtp_Inicial.OnHoverBaseColor = System.Drawing.Color.White;
            this.dtp_Inicial.OnHoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dtp_Inicial.OnHoverForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dtp_Inicial.OnPressedColor = System.Drawing.Color.Black;
            this.dtp_Inicial.Radius = 10;
            this.dtp_Inicial.Size = new System.Drawing.Size(116, 30);
            this.dtp_Inicial.TabIndex = 582;
            this.dtp_Inicial.Text = "9/04/2021";
            this.dtp_Inicial.Value = new System.DateTime(2021, 4, 9, 0, 46, 1, 513);
            // 
            // btn_Consultar
            // 
            this.btn_Consultar.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Consultar.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_Consultar.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btn_Consultar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.WhiteSmoke;
            this.btn_Consultar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightGray;
            this.btn_Consultar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Consultar.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Consultar.ForeColor = System.Drawing.Color.DimGray;
            this.btn_Consultar.IconChar = FontAwesome.Sharp.IconChar.LayerGroup;
            this.btn_Consultar.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btn_Consultar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btn_Consultar.IconSize = 25;
            this.btn_Consultar.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btn_Consultar.Location = new System.Drawing.Point(702, 4);
            this.btn_Consultar.Name = "btn_Consultar";
            this.btn_Consultar.Size = new System.Drawing.Size(117, 30);
            this.btn_Consultar.TabIndex = 415;
            this.btn_Consultar.Text = "Consultar";
            this.btn_Consultar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTip1.SetToolTip(this.btn_Consultar, "Consultar Fecha");
            this.btn_Consultar.UseVisualStyleBackColor = false;
            this.btn_Consultar.Click += new System.EventHandler(this.btn_Consultar_Click);
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.DimGray;
            this.label10.Location = new System.Drawing.Point(471, 11);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(102, 18);
            this.label10.TabIndex = 417;
            this.label10.Text = "Fecha Final:";
            // 
            // label12
            // 
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.DimGray;
            this.label12.Location = new System.Drawing.Point(225, 12);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(114, 18);
            this.label12.TabIndex = 416;
            this.label12.Text = "Fecha Inicial:";
            // 
            // iconButton1
            // 
            this.iconButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
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
            this.iconButton1.Location = new System.Drawing.Point(999, 6);
            this.iconButton1.Name = "iconButton1";
            this.iconButton1.Size = new System.Drawing.Size(25, 25);
            this.iconButton1.TabIndex = 58;
            this.iconButton1.UseVisualStyleBackColor = false;
            // 
            // Pb_Agregar2
            // 
            this.Pb_Agregar2.BackColor = System.Drawing.Color.LightGray;
            this.Pb_Agregar2.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.Pb_Agregar2.FlatAppearance.BorderSize = 0;
            this.Pb_Agregar2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DeepSkyBlue;
            this.Pb_Agregar2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkSeaGreen;
            this.Pb_Agregar2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Pb_Agregar2.Font = new System.Drawing.Font("Verdana", 9.75F);
            this.Pb_Agregar2.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.Pb_Agregar2.IconChar = FontAwesome.Sharp.IconChar.CartArrowDown;
            this.Pb_Agregar2.IconColor = System.Drawing.Color.DarkOrange;
            this.Pb_Agregar2.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.Pb_Agregar2.IconSize = 30;
            this.Pb_Agregar2.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.Pb_Agregar2.Location = new System.Drawing.Point(5, 2);
            this.Pb_Agregar2.Name = "Pb_Agregar2";
            this.Pb_Agregar2.Size = new System.Drawing.Size(37, 32);
            this.Pb_Agregar2.TabIndex = 26;
            this.toolTip1.SetToolTip(this.Pb_Agregar2, "Realizar una compra");
            this.Pb_Agregar2.UseVisualStyleBackColor = false;
            this.Pb_Agregar2.Click += new System.EventHandler(this.Pb_Agregar_Click);
            // 
            // txt_buscar
            // 
            this.txt_buscar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_buscar.BackColor = System.Drawing.Color.LightGray;
            this.txt_buscar.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_buscar.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_buscar.ForeColor = System.Drawing.Color.DimGray;
            this.txt_buscar.HintForeColor = System.Drawing.Color.DimGray;
            this.txt_buscar.HintText = "Buscar Doc. Fisico";
            this.txt_buscar.isPassword = false;
            this.txt_buscar.LineFocusedColor = System.Drawing.Color.LightGray;
            this.txt_buscar.LineIdleColor = System.Drawing.Color.LightGray;
            this.txt_buscar.LineMouseHoverColor = System.Drawing.Color.LightGray;
            this.txt_buscar.LineThickness = 3;
            this.txt_buscar.Location = new System.Drawing.Point(853, 5);
            this.txt_buscar.Margin = new System.Windows.Forms.Padding(4);
            this.txt_buscar.Name = "txt_buscar";
            this.txt_buscar.Size = new System.Drawing.Size(154, 27);
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
            this.elLabel1.Location = new System.Drawing.Point(837, 4);
            this.elLabel1.Name = "elLabel1";
            this.elLabel1.Size = new System.Drawing.Size(197, 29);
            this.elLabel1.TabIndex = 18;
            this.elLabel1.TabStop = false;
            this.elLabel1.VisualStyle = Klik.Windows.Forms.v1.Common.ControlVisualStyles.Custom;
            // 
            // lblcont
            // 
            this.lblcont.BackColor = System.Drawing.Color.LightGray;
            this.lblcont.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblcont.ForeColor = System.Drawing.Color.DimGray;
            this.lblcont.Location = new System.Drawing.Point(154, 10);
            this.lblcont.Name = "lblcont";
            this.lblcont.Size = new System.Drawing.Size(59, 18);
            this.lblcont.TabIndex = 16;
            this.lblcont.Text = "..";
            this.lblcont.Click += new System.EventHandler(this.lblcont_Click);
            // 
            // label15
            // 
            this.label15.BackColor = System.Drawing.Color.LightGray;
            this.label15.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.DimGray;
            this.label15.Location = new System.Drawing.Point(49, 5);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(113, 26);
            this.label15.TabIndex = 16;
            this.label15.Text = "Total Items:";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label15.Click += new System.EventHandler(this.label15_Click);
            // 
            // Lsv_Compras
            // 
            this.Lsv_Compras.ContextMenuStrip = this.contextMenuStrip1;
            this.Lsv_Compras.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lsv_Compras.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.Lsv_Compras.HideSelection = false;
            this.Lsv_Compras.Location = new System.Drawing.Point(0, 114);
            this.Lsv_Compras.Name = "Lsv_Compras";
            this.Lsv_Compras.Size = new System.Drawing.Size(1049, 476);
            this.Lsv_Compras.TabIndex = 2;
            this.Lsv_Compras.UseCompatibleStateImageBehavior = false;
            this.Lsv_Compras.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.Lsv_Compras_MouseDoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Font = new System.Drawing.Font("Calibri Light", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevoCompraToolStripMenuItem,
            this.toolStripSeparator1,
            this.mostrarCompraToolStripMenuItem,
            this.toolStripSeparator3,
            this.bt_copiarIDCompra,
            this.toolStripSeparator4,
            this.mostrarComprasDelDiaToolStripMenuItem,
            this.toolStripSeparator5,
            this.mostarComprasDelMesToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(236, 160);
            // 
            // nuevoCompraToolStripMenuItem
            // 
            this.nuevoCompraToolStripMenuItem.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nuevoCompraToolStripMenuItem.ForeColor = System.Drawing.Color.DimGray;
            this.nuevoCompraToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("nuevoCompraToolStripMenuItem.Image")));
            this.nuevoCompraToolStripMenuItem.Name = "nuevoCompraToolStripMenuItem";
            this.nuevoCompraToolStripMenuItem.Size = new System.Drawing.Size(235, 22);
            this.nuevoCompraToolStripMenuItem.Text = "Nueva Compra";
            this.nuevoCompraToolStripMenuItem.Click += new System.EventHandler(this.nuevoProveedorToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(232, 6);
            // 
            // mostrarCompraToolStripMenuItem
            // 
            this.mostrarCompraToolStripMenuItem.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mostrarCompraToolStripMenuItem.ForeColor = System.Drawing.Color.DimGray;
            this.mostrarCompraToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("mostrarCompraToolStripMenuItem.Image")));
            this.mostrarCompraToolStripMenuItem.Name = "mostrarCompraToolStripMenuItem";
            this.mostrarCompraToolStripMenuItem.Size = new System.Drawing.Size(235, 22);
            this.mostrarCompraToolStripMenuItem.Text = "Mostrar Compra";
            this.mostrarCompraToolStripMenuItem.Click += new System.EventHandler(this.mostrarProveedorToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(232, 6);
            // 
            // bt_copiarIDCompra
            // 
            this.bt_copiarIDCompra.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_copiarIDCompra.ForeColor = System.Drawing.Color.DimGray;
            this.bt_copiarIDCompra.Image = ((System.Drawing.Image)(resources.GetObject("bt_copiarIDCompra.Image")));
            this.bt_copiarIDCompra.Name = "bt_copiarIDCompra";
            this.bt_copiarIDCompra.Size = new System.Drawing.Size(235, 22);
            this.bt_copiarIDCompra.Text = "Copiar ID Interno";
            this.bt_copiarIDCompra.Click += new System.EventHandler(this.bt_copiarIDProveedor_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(232, 6);
            // 
            // mostrarComprasDelDiaToolStripMenuItem
            // 
            this.mostrarComprasDelDiaToolStripMenuItem.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mostrarComprasDelDiaToolStripMenuItem.ForeColor = System.Drawing.Color.DimGray;
            this.mostrarComprasDelDiaToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("mostrarComprasDelDiaToolStripMenuItem.Image")));
            this.mostrarComprasDelDiaToolStripMenuItem.Name = "mostrarComprasDelDiaToolStripMenuItem";
            this.mostrarComprasDelDiaToolStripMenuItem.Size = new System.Drawing.Size(235, 22);
            this.mostrarComprasDelDiaToolStripMenuItem.Text = "Mostrar Compras Del Dia";
            this.mostrarComprasDelDiaToolStripMenuItem.Click += new System.EventHandler(this.mostrarComprasDelDiaToolStripMenuItem_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(232, 6);
            // 
            // mostarComprasDelMesToolStripMenuItem
            // 
            this.mostarComprasDelMesToolStripMenuItem.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mostarComprasDelMesToolStripMenuItem.ForeColor = System.Drawing.Color.DimGray;
            this.mostarComprasDelMesToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("mostarComprasDelMesToolStripMenuItem.Image")));
            this.mostarComprasDelMesToolStripMenuItem.Name = "mostarComprasDelMesToolStripMenuItem";
            this.mostarComprasDelMesToolStripMenuItem.Size = new System.Drawing.Size(235, 22);
            this.mostarComprasDelMesToolStripMenuItem.Text = "Mostar Compras Del Mes";
            this.mostarComprasDelMesToolStripMenuItem.Click += new System.EventHandler(this.mostarComprasDelMesToolStripMenuItem_Click);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.SystemColors.Control;
            this.label2.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DimGray;
            this.label2.Location = new System.Drawing.Point(2, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 23);
            this.label2.TabIndex = 3;
            this.label2.Text = "ID Interno";
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.SystemColors.Control;
            this.label3.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DimGray;
            this.label3.Location = new System.Drawing.Point(103, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(121, 23);
            this.label3.TabIndex = 4;
            this.label3.Text = "Num. Fisico";
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.SystemColors.Control;
            this.label4.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.DimGray;
            this.label4.Location = new System.Drawing.Point(227, 88);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(166, 23);
            this.label4.TabIndex = 5;
            this.label4.Text = "Nombre del Proveedor";
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.SystemColors.Control;
            this.label5.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.DimGray;
            this.label5.Location = new System.Drawing.Point(613, 88);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 23);
            this.label5.TabIndex = 8;
            this.label5.Text = "Forma Pago";
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.SystemColors.Control;
            this.label6.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.DimGray;
            this.label6.Location = new System.Drawing.Point(510, 88);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 23);
            this.label6.TabIndex = 7;
            this.label6.Text = "Importe S/.";
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.SystemColors.Control;
            this.label7.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.DimGray;
            this.label7.Location = new System.Drawing.Point(397, 88);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(110, 23);
            this.label7.TabIndex = 6;
            this.label7.Text = "Fecha Compra";
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.SystemColors.Control;
            this.label8.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.DimGray;
            this.label8.Location = new System.Drawing.Point(820, 88);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(116, 23);
            this.label8.TabIndex = 10;
            this.label8.Text = "Tipo Documento";
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.SystemColors.Control;
            this.label9.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.DimGray;
            this.label9.Location = new System.Drawing.Point(716, 88);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(100, 23);
            this.label9.TabIndex = 9;
            this.label9.Text = "Tipo Ingreso";
            // 
            // bunifuSeparator1
            // 
            this.bunifuSeparator1.BackColor = System.Drawing.Color.Transparent;
            this.bunifuSeparator1.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.bunifuSeparator1.LineThickness = 1;
            this.bunifuSeparator1.Location = new System.Drawing.Point(0, 106);
            this.bunifuSeparator1.Name = "bunifuSeparator1";
            this.bunifuSeparator1.Size = new System.Drawing.Size(1052, 10);
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
            this.label11.BackColor = System.Drawing.SystemColors.Control;
            this.label11.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.DimGray;
            this.label11.Location = new System.Drawing.Point(956, 88);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(67, 23);
            this.label11.TabIndex = 12;
            this.label11.Text = "Estado Compra";
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
            this.pnl_msn.ContextMenuStrip = this.contextMenuStrip1;
            this.pnl_msn.Controls.Add(this.elDivider2);
            this.pnl_msn.Controls.Add(this.ElDivider3);
            this.pnl_msn.Controls.Add(this.label17);
            this.pnl_msn.Controls.Add(this.label16);
            this.pnl_msn.Controls.Add(this.pictureBox1);
            this.pnl_msn.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.pnl_msn.Location = new System.Drawing.Point(0, 81);
            this.pnl_msn.Name = "pnl_msn";
            this.pnl_msn.Size = new System.Drawing.Size(1049, 508);
            this.pnl_msn.TabIndex = 16;
            this.pnl_msn.Visible = false;
            this.pnl_msn.Paint += new System.Windows.Forms.PaintEventHandler(this.pnl_msn_Paint);
            // 
            // elDivider2
            // 
            this.elDivider2.FadeStyle = Klik.Windows.Forms.v1.EntryLib.DividerFadeStyles.Center;
            this.elDivider2.LineColor = System.Drawing.Color.DarkOrange;
            this.elDivider2.Location = new System.Drawing.Point(30, 247);
            this.elDivider2.Margin = new System.Windows.Forms.Padding(4);
            this.elDivider2.Name = "elDivider2";
            this.elDivider2.Size = new System.Drawing.Size(994, 2);
            this.elDivider2.TabIndex = 414;
            this.elDivider2.VisualStyle = Klik.Windows.Forms.v1.Common.ControlVisualStyles.Custom;
            // 
            // ElDivider3
            // 
            this.ElDivider3.FadeStyle = Klik.Windows.Forms.v1.EntryLib.DividerFadeStyles.Center;
            this.ElDivider3.LineColor = System.Drawing.Color.DarkGray;
            this.ElDivider3.Location = new System.Drawing.Point(18, 240);
            this.ElDivider3.Margin = new System.Windows.Forms.Padding(4);
            this.ElDivider3.Name = "ElDivider3";
            this.ElDivider3.Size = new System.Drawing.Size(1019, 10);
            this.ElDivider3.TabIndex = 413;
            this.ElDivider3.VisualStyle = Klik.Windows.Forms.v1.Common.ControlVisualStyles.Custom;
            // 
            // label17
            // 
            this.label17.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.Color.DimGray;
            this.label17.Location = new System.Drawing.Point(374, 261);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(305, 24);
            this.label17.TabIndex = 18;
            this.label17.Text = "Intentar busqueda con otra Compra";
            // 
            // label16
            // 
            this.label16.Font = new System.Drawing.Font("Verdana", 20F);
            this.label16.ForeColor = System.Drawing.Color.DarkOrange;
            this.label16.Location = new System.Drawing.Point(361, 202);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(333, 39);
            this.label16.TabIndex = 17;
            this.label16.Text = "Busqueda sin resultado";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(488, 130);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(71, 69);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // Frm_Explo_Compras
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1049, 601);
            this.Controls.Add(this.pnl_msn);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Lsv_Compras);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnl_titu);
            this.Controls.Add(this.bunifuSeparator1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "Frm_Explo_Compras";
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
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListView Lsv_Compras;
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
        private System.Windows.Forms.ToolStripMenuItem nuevoCompraToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem mostrarCompraToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem bt_copiarIDCompra;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label lblcont;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Panel pnl_msn;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.PictureBox pictureBox1;
        private Klik.Windows.Forms.v1.EntryLib.ELLabel elLabel1;
        public Bunifu.Framework.UI.BunifuMaterialTextbox txt_buscar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem mostrarComprasDelDiaToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem mostarComprasDelMesToolStripMenuItem;
        private FontAwesome.Sharp.IconButton Pb_Agregar2;
        private FontAwesome.Sharp.IconButton iconButton1;
        private FontAwesome.Sharp.IconButton btn_Consultar;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label12;
        internal Klik.Windows.Forms.v1.EntryLib.ELDivider elDivider2;
        internal Klik.Windows.Forms.v1.EntryLib.ELDivider ElDivider3;
        private Guna.UI.WinForms.GunaDateTimePicker dtp_Inicial;
        private Guna.UI.WinForms.GunaDateTimePicker dtp_Final;
    }
}