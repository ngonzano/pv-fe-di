
namespace Microsell_Lite.Cliente
{
    partial class Frm_ListadoClientes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_ListadoClientes));
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.pnl_titu = new System.Windows.Forms.Panel();
            this.lblCantCliente = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txt_buscar = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.elLabel1 = new Klik.Windows.Forms.v1.EntryLib.ELLabel();
            this.list_Cliente = new System.Windows.Forms.ListView();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.bunifuSeparator1 = new Bunifu.Framework.UI.BunifuSeparator();
            this.PNL_AgregarCliente = new System.Windows.Forms.Panel();
            this.chk_consultaReniec = new Guna.UI.WinForms.GunaCheckBox();
            this.lbl_buscando = new System.Windows.Forms.Label();
            this.btn_Consultar = new Bunifu.Framework.UI.BunifuThinButton2();
            this.label13 = new System.Windows.Forms.Label();
            this.txt_estado = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txt_Tipo = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.txt_Condicion = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.chk_consultaSunat = new Guna.UI.WinForms.GunaCheckBox();
            this.dtp_aniv = new System.Windows.Forms.DateTimePicker();
            this.btn_cancelar = new Bunifu.Framework.UI.BunifuThinButton2();
            this.btn_agregar = new Bunifu.Framework.UI.BunifuThinButton2();
            this.txt_Direccion = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.label9 = new System.Windows.Forms.Label();
            this.txt_DNIRUC = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.label8 = new System.Windows.Forms.Label();
            this.txt_RasonSocial = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.label7 = new System.Windows.Forms.Label();
            this.txt_idCliente = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.bunifuSeparator2 = new Bunifu.Framework.UI.BunifuSeparator();
            this.lblID = new System.Windows.Forms.Label();
            this.lblnom = new System.Windows.Forms.Label();
            this.lblRUC = new System.Windows.Forms.Label();
            this.bunifuThinButton21 = new Klik.Windows.Forms.v1.EntryLib.ELButton();
            this.btn_new2 = new Klik.Windows.Forms.v1.EntryLib.ELButton();
            this.pnl_titu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.elLabel1)).BeginInit();
            this.PNL_AgregarCliente.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bunifuThinButton21)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_new2)).BeginInit();
            this.SuspendLayout();
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 20;
            this.bunifuElipse1.TargetControl = this;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri Light", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label1.Location = new System.Drawing.Point(10, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Listado de Cliente";
            // 
            // pnl_titu
            // 
            this.pnl_titu.BackColor = System.Drawing.Color.DimGray;
            this.pnl_titu.Controls.Add(this.lblCantCliente);
            this.pnl_titu.Controls.Add(this.label10);
            this.pnl_titu.Controls.Add(this.txt_buscar);
            this.pnl_titu.Controls.Add(this.elLabel1);
            this.pnl_titu.Controls.Add(this.label1);
            this.pnl_titu.Location = new System.Drawing.Point(-6, -2);
            this.pnl_titu.Name = "pnl_titu";
            this.pnl_titu.Size = new System.Drawing.Size(560, 48);
            this.pnl_titu.TabIndex = 67;
            this.pnl_titu.Paint += new System.Windows.Forms.PaintEventHandler(this.pnl_titu_Paint);
            this.pnl_titu.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnl_titu_MouseMove);
            // 
            // lblCantCliente
            // 
            this.lblCantCliente.AutoSize = true;
            this.lblCantCliente.Font = new System.Drawing.Font("Calibri Light", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCantCliente.ForeColor = System.Drawing.Color.White;
            this.lblCantCliente.Location = new System.Drawing.Point(217, 26);
            this.lblCantCliente.Name = "lblCantCliente";
            this.lblCantCliente.Size = new System.Drawing.Size(0, 15);
            this.lblCantCliente.TabIndex = 26;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Calibri Light", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(185, 7);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(82, 15);
            this.label10.TabIndex = 25;
            this.label10.Text = "Canti. Clientes";
            // 
            // txt_buscar
            // 
            this.txt_buscar.BackColor = System.Drawing.Color.LightGray;
            this.txt_buscar.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_buscar.Font = new System.Drawing.Font("Calibri Light", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_buscar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txt_buscar.HintForeColor = System.Drawing.Color.Black;
            this.txt_buscar.HintText = "Buscar Cliente";
            this.txt_buscar.isPassword = false;
            this.txt_buscar.LineFocusedColor = System.Drawing.Color.LightGray;
            this.txt_buscar.LineIdleColor = System.Drawing.Color.Silver;
            this.txt_buscar.LineMouseHoverColor = System.Drawing.Color.LightGray;
            this.txt_buscar.LineThickness = 3;
            this.txt_buscar.Location = new System.Drawing.Point(331, 10);
            this.txt_buscar.Margin = new System.Windows.Forms.Padding(4);
            this.txt_buscar.Name = "txt_buscar";
            this.txt_buscar.Size = new System.Drawing.Size(118, 28);
            this.txt_buscar.TabIndex = 1;
            this.txt_buscar.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txt_buscar.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_buscar_KeyDown);
            this.txt_buscar.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_buscar_KeyPress);
            this.txt_buscar.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_buscar_KeyUp);
            // 
            // elLabel1
            // 
            this.elLabel1.BackgroundStyle.GradientEndColor = System.Drawing.Color.LightGray;
            this.elLabel1.BackgroundStyle.GradientStartColor = System.Drawing.Color.LightGray;
            this.elLabel1.BorderStyle.BorderShape.BottomLeft = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.elLabel1.BorderStyle.BorderShape.BottomRight = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.elLabel1.BorderStyle.BorderShape.TopLeft = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.elLabel1.BorderStyle.BorderShape.TopRight = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.elLabel1.Cursor = System.Windows.Forms.Cursors.Default;
            paintStyle1.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            paintStyle1.SolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(240)))), ((int)(((byte)(191)))));
            this.elLabel1.FlashStyle = paintStyle1;
            this.elLabel1.Location = new System.Drawing.Point(320, 10);
            this.elLabel1.Name = "elLabel1";
            this.elLabel1.Size = new System.Drawing.Size(141, 29);
            this.elLabel1.TabIndex = 24;
            this.elLabel1.TabStop = false;
            this.elLabel1.VisualStyle = Klik.Windows.Forms.v1.Common.ControlVisualStyles.Custom;
            this.elLabel1.Click += new System.EventHandler(this.elLabel1_Click);
            // 
            // list_Cliente
            // 
            this.list_Cliente.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.list_Cliente.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.list_Cliente.ForeColor = System.Drawing.Color.Gray;
            this.list_Cliente.GridLines = true;
            this.list_Cliente.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.list_Cliente.HideSelection = false;
            this.list_Cliente.Location = new System.Drawing.Point(64, 71);
            this.list_Cliente.Name = "list_Cliente";
            this.list_Cliente.Size = new System.Drawing.Size(419, 385);
            this.list_Cliente.TabIndex = 68;
            this.list_Cliente.UseCompatibleStateImageBehavior = false;
            this.list_Cliente.KeyDown += new System.Windows.Forms.KeyEventHandler(this.list_Cliente_KeyDown);
            this.list_Cliente.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.list_Cliente_MouseDoubleClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri Light", 10F, System.Drawing.FontStyle.Italic);
            this.label2.Location = new System.Drawing.Point(-1, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 17);
            this.label2.TabIndex = 69;
            this.label2.Text = "DATOS DEL CLIENTE";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri Light", 10F, System.Drawing.FontStyle.Italic);
            this.label3.Location = new System.Drawing.Point(220, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 17);
            this.label3.TabIndex = 70;
            this.label3.Text = "DNI";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri Light", 10F, System.Drawing.FontStyle.Italic);
            this.label4.Location = new System.Drawing.Point(360, 46);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 17);
            this.label4.TabIndex = 71;
            this.label4.Text = "ESTADO";
            // 
            // bunifuSeparator1
            // 
            this.bunifuSeparator1.BackColor = System.Drawing.Color.Transparent;
            this.bunifuSeparator1.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(211)))), ((int)(((byte)(211)))));
            this.bunifuSeparator1.LineThickness = 1;
            this.bunifuSeparator1.Location = new System.Drawing.Point(1, 57);
            this.bunifuSeparator1.Name = "bunifuSeparator1";
            this.bunifuSeparator1.Size = new System.Drawing.Size(468, 16);
            this.bunifuSeparator1.TabIndex = 72;
            this.bunifuSeparator1.Transparency = 255;
            this.bunifuSeparator1.Vertical = false;
            // 
            // PNL_AgregarCliente
            // 
            this.PNL_AgregarCliente.BackColor = System.Drawing.Color.White;
            this.PNL_AgregarCliente.Controls.Add(this.chk_consultaReniec);
            this.PNL_AgregarCliente.Controls.Add(this.lbl_buscando);
            this.PNL_AgregarCliente.Controls.Add(this.btn_Consultar);
            this.PNL_AgregarCliente.Controls.Add(this.label13);
            this.PNL_AgregarCliente.Controls.Add(this.txt_estado);
            this.PNL_AgregarCliente.Controls.Add(this.label12);
            this.PNL_AgregarCliente.Controls.Add(this.label11);
            this.PNL_AgregarCliente.Controls.Add(this.txt_Tipo);
            this.PNL_AgregarCliente.Controls.Add(this.txt_Condicion);
            this.PNL_AgregarCliente.Controls.Add(this.chk_consultaSunat);
            this.PNL_AgregarCliente.Controls.Add(this.dtp_aniv);
            this.PNL_AgregarCliente.Controls.Add(this.btn_cancelar);
            this.PNL_AgregarCliente.Controls.Add(this.btn_agregar);
            this.PNL_AgregarCliente.Controls.Add(this.txt_Direccion);
            this.PNL_AgregarCliente.Controls.Add(this.label9);
            this.PNL_AgregarCliente.Controls.Add(this.txt_DNIRUC);
            this.PNL_AgregarCliente.Controls.Add(this.label8);
            this.PNL_AgregarCliente.Controls.Add(this.txt_RasonSocial);
            this.PNL_AgregarCliente.Controls.Add(this.label7);
            this.PNL_AgregarCliente.Controls.Add(this.txt_idCliente);
            this.PNL_AgregarCliente.Controls.Add(this.label6);
            this.PNL_AgregarCliente.Controls.Add(this.label5);
            this.PNL_AgregarCliente.Controls.Add(this.bunifuSeparator2);
            this.PNL_AgregarCliente.Location = new System.Drawing.Point(1, 46);
            this.PNL_AgregarCliente.Name = "PNL_AgregarCliente";
            this.PNL_AgregarCliente.Size = new System.Drawing.Size(550, 471);
            this.PNL_AgregarCliente.TabIndex = 75;
            this.PNL_AgregarCliente.Visible = false;
            this.PNL_AgregarCliente.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // chk_consultaReniec
            // 
            this.chk_consultaReniec.BaseColor = System.Drawing.Color.White;
            this.chk_consultaReniec.Checked = true;
            this.chk_consultaReniec.CheckedOffColor = System.Drawing.Color.Gray;
            this.chk_consultaReniec.CheckedOnColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.chk_consultaReniec.FillColor = System.Drawing.Color.White;
            this.chk_consultaReniec.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Bold);
            this.chk_consultaReniec.Location = new System.Drawing.Point(327, 99);
            this.chk_consultaReniec.Name = "chk_consultaReniec";
            this.chk_consultaReniec.Size = new System.Drawing.Size(162, 20);
            this.chk_consultaReniec.TabIndex = 97;
            this.chk_consultaReniec.Text = "Consultar DNI Reniec";
            this.chk_consultaReniec.CheckedChanged += new System.EventHandler(this.chk_consultaReniec_CheckedChanged);
            // 
            // lbl_buscando
            // 
            this.lbl_buscando.AutoSize = true;
            this.lbl_buscando.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_buscando.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lbl_buscando.Location = new System.Drawing.Point(194, 137);
            this.lbl_buscando.Name = "lbl_buscando";
            this.lbl_buscando.Size = new System.Drawing.Size(94, 16);
            this.lbl_buscando.TabIndex = 96;
            this.lbl_buscando.Text = "Buscando...";
            this.lbl_buscando.Visible = false;
            // 
            // btn_Consultar
            // 
            this.btn_Consultar.ActiveBorderThickness = 1;
            this.btn_Consultar.ActiveCornerRadius = 15;
            this.btn_Consultar.ActiveFillColor = System.Drawing.Color.SeaGreen;
            this.btn_Consultar.ActiveForecolor = System.Drawing.Color.White;
            this.btn_Consultar.ActiveLineColor = System.Drawing.Color.SeaGreen;
            this.btn_Consultar.BackColor = System.Drawing.Color.White;
            this.btn_Consultar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_Consultar.BackgroundImage")));
            this.btn_Consultar.ButtonText = "Consultar";
            this.btn_Consultar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Consultar.Font = new System.Drawing.Font("Century Schoolbook", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Consultar.ForeColor = System.Drawing.Color.SeaGreen;
            this.btn_Consultar.IdleBorderThickness = 1;
            this.btn_Consultar.IdleCornerRadius = 20;
            this.btn_Consultar.IdleFillColor = System.Drawing.Color.White;
            this.btn_Consultar.IdleForecolor = System.Drawing.Color.SeaGreen;
            this.btn_Consultar.IdleLineColor = System.Drawing.Color.SeaGreen;
            this.btn_Consultar.Location = new System.Drawing.Point(324, 120);
            this.btn_Consultar.Margin = new System.Windows.Forms.Padding(5);
            this.btn_Consultar.Name = "btn_Consultar";
            this.btn_Consultar.Size = new System.Drawing.Size(98, 39);
            this.btn_Consultar.TabIndex = 95;
            this.btn_Consultar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn_Consultar.Click += new System.EventHandler(this.btn_Consultar_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.DimGray;
            this.label13.Location = new System.Drawing.Point(19, 377);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(58, 16);
            this.label13.TabIndex = 93;
            this.label13.Text = "Estado";
            // 
            // txt_estado
            // 
            this.txt_estado.BackColor = System.Drawing.Color.White;
            this.txt_estado.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_estado.Enabled = false;
            this.txt_estado.Font = new System.Drawing.Font("Calibri Light", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_estado.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txt_estado.HintForeColor = System.Drawing.Color.Empty;
            this.txt_estado.HintText = "";
            this.txt_estado.isPassword = false;
            this.txt_estado.LineFocusedColor = System.Drawing.Color.DodgerBlue;
            this.txt_estado.LineIdleColor = System.Drawing.Color.LimeGreen;
            this.txt_estado.LineMouseHoverColor = System.Drawing.Color.DodgerBlue;
            this.txt_estado.LineThickness = 3;
            this.txt_estado.Location = new System.Drawing.Point(22, 397);
            this.txt_estado.Margin = new System.Windows.Forms.Padding(4);
            this.txt_estado.Name = "txt_estado";
            this.txt_estado.Size = new System.Drawing.Size(144, 30);
            this.txt_estado.TabIndex = 94;
            this.txt_estado.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.DimGray;
            this.label12.Location = new System.Drawing.Point(203, 303);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(38, 16);
            this.label12.TabIndex = 90;
            this.label12.Text = "Tipo";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.DimGray;
            this.label11.Location = new System.Drawing.Point(19, 303);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(79, 16);
            this.label11.TabIndex = 27;
            this.label11.Text = "Condicion";
            // 
            // txt_Tipo
            // 
            this.txt_Tipo.BackColor = System.Drawing.Color.White;
            this.txt_Tipo.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_Tipo.Enabled = false;
            this.txt_Tipo.Font = new System.Drawing.Font("Calibri Light", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Tipo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txt_Tipo.HintForeColor = System.Drawing.Color.Empty;
            this.txt_Tipo.HintText = "";
            this.txt_Tipo.isPassword = false;
            this.txt_Tipo.LineFocusedColor = System.Drawing.Color.DodgerBlue;
            this.txt_Tipo.LineIdleColor = System.Drawing.Color.LimeGreen;
            this.txt_Tipo.LineMouseHoverColor = System.Drawing.Color.DodgerBlue;
            this.txt_Tipo.LineThickness = 3;
            this.txt_Tipo.Location = new System.Drawing.Point(206, 322);
            this.txt_Tipo.Margin = new System.Windows.Forms.Padding(4);
            this.txt_Tipo.Name = "txt_Tipo";
            this.txt_Tipo.Size = new System.Drawing.Size(299, 30);
            this.txt_Tipo.TabIndex = 89;
            this.txt_Tipo.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // txt_Condicion
            // 
            this.txt_Condicion.BackColor = System.Drawing.Color.White;
            this.txt_Condicion.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_Condicion.Enabled = false;
            this.txt_Condicion.Font = new System.Drawing.Font("Calibri Light", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Condicion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txt_Condicion.HintForeColor = System.Drawing.Color.Empty;
            this.txt_Condicion.HintText = "";
            this.txt_Condicion.isPassword = false;
            this.txt_Condicion.LineFocusedColor = System.Drawing.Color.DodgerBlue;
            this.txt_Condicion.LineIdleColor = System.Drawing.Color.LimeGreen;
            this.txt_Condicion.LineMouseHoverColor = System.Drawing.Color.DodgerBlue;
            this.txt_Condicion.LineThickness = 3;
            this.txt_Condicion.Location = new System.Drawing.Point(22, 322);
            this.txt_Condicion.Margin = new System.Windows.Forms.Padding(4);
            this.txt_Condicion.Name = "txt_Condicion";
            this.txt_Condicion.Size = new System.Drawing.Size(144, 30);
            this.txt_Condicion.TabIndex = 88;
            this.txt_Condicion.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // chk_consultaSunat
            // 
            this.chk_consultaSunat.BaseColor = System.Drawing.Color.White;
            this.chk_consultaSunat.CheckedOffColor = System.Drawing.Color.Gray;
            this.chk_consultaSunat.CheckedOnColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.chk_consultaSunat.FillColor = System.Drawing.Color.White;
            this.chk_consultaSunat.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Bold);
            this.chk_consultaSunat.Location = new System.Drawing.Point(165, 99);
            this.chk_consultaSunat.Name = "chk_consultaSunat";
            this.chk_consultaSunat.Size = new System.Drawing.Size(155, 20);
            this.chk_consultaSunat.TabIndex = 87;
            this.chk_consultaSunat.Text = "Consultar Ruc Sunat";
            this.chk_consultaSunat.CheckedChanged += new System.EventHandler(this.chk_consultaSunat_CheckedChanged);
            // 
            // dtp_aniv
            // 
            this.dtp_aniv.Location = new System.Drawing.Point(255, 377);
            this.dtp_aniv.Name = "dtp_aniv";
            this.dtp_aniv.Size = new System.Drawing.Size(200, 20);
            this.dtp_aniv.TabIndex = 86;
            this.dtp_aniv.Visible = false;
            // 
            // btn_cancelar
            // 
            this.btn_cancelar.ActiveBorderThickness = 1;
            this.btn_cancelar.ActiveCornerRadius = 20;
            this.btn_cancelar.ActiveFillColor = System.Drawing.Color.RoyalBlue;
            this.btn_cancelar.ActiveForecolor = System.Drawing.Color.White;
            this.btn_cancelar.ActiveLineColor = System.Drawing.Color.RoyalBlue;
            this.btn_cancelar.BackColor = System.Drawing.Color.White;
            this.btn_cancelar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_cancelar.BackgroundImage")));
            this.btn_cancelar.ButtonText = "Cancelar";
            this.btn_cancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_cancelar.Font = new System.Drawing.Font("Century Schoolbook", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_cancelar.ForeColor = System.Drawing.Color.SeaGreen;
            this.btn_cancelar.IdleBorderThickness = 1;
            this.btn_cancelar.IdleCornerRadius = 20;
            this.btn_cancelar.IdleFillColor = System.Drawing.Color.White;
            this.btn_cancelar.IdleForecolor = System.Drawing.Color.RoyalBlue;
            this.btn_cancelar.IdleLineColor = System.Drawing.Color.RoyalBlue;
            this.btn_cancelar.Location = new System.Drawing.Point(310, 430);
            this.btn_cancelar.Margin = new System.Windows.Forms.Padding(5);
            this.btn_cancelar.Name = "btn_cancelar";
            this.btn_cancelar.Size = new System.Drawing.Size(98, 39);
            this.btn_cancelar.TabIndex = 85;
            this.btn_cancelar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn_cancelar.Click += new System.EventHandler(this.btn_cancelar_Click);
            // 
            // btn_agregar
            // 
            this.btn_agregar.ActiveBorderThickness = 1;
            this.btn_agregar.ActiveCornerRadius = 15;
            this.btn_agregar.ActiveFillColor = System.Drawing.Color.SeaGreen;
            this.btn_agregar.ActiveForecolor = System.Drawing.Color.White;
            this.btn_agregar.ActiveLineColor = System.Drawing.Color.SeaGreen;
            this.btn_agregar.BackColor = System.Drawing.Color.White;
            this.btn_agregar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_agregar.BackgroundImage")));
            this.btn_agregar.ButtonText = "Agregar";
            this.btn_agregar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_agregar.Font = new System.Drawing.Font("Century Schoolbook", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_agregar.ForeColor = System.Drawing.Color.SeaGreen;
            this.btn_agregar.IdleBorderThickness = 1;
            this.btn_agregar.IdleCornerRadius = 20;
            this.btn_agregar.IdleFillColor = System.Drawing.Color.White;
            this.btn_agregar.IdleForecolor = System.Drawing.Color.SeaGreen;
            this.btn_agregar.IdleLineColor = System.Drawing.Color.SeaGreen;
            this.btn_agregar.Location = new System.Drawing.Point(429, 430);
            this.btn_agregar.Margin = new System.Windows.Forms.Padding(5);
            this.btn_agregar.Name = "btn_agregar";
            this.btn_agregar.Size = new System.Drawing.Size(98, 39);
            this.btn_agregar.TabIndex = 84;
            this.btn_agregar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn_agregar.Click += new System.EventHandler(this.btn_agregar_Click);
            // 
            // txt_Direccion
            // 
            this.txt_Direccion.BackColor = System.Drawing.Color.White;
            this.txt_Direccion.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_Direccion.Font = new System.Drawing.Font("Calibri Light", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Direccion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txt_Direccion.HintForeColor = System.Drawing.Color.Empty;
            this.txt_Direccion.HintText = "";
            this.txt_Direccion.isPassword = false;
            this.txt_Direccion.LineFocusedColor = System.Drawing.Color.DodgerBlue;
            this.txt_Direccion.LineIdleColor = System.Drawing.Color.LimeGreen;
            this.txt_Direccion.LineMouseHoverColor = System.Drawing.Color.DodgerBlue;
            this.txt_Direccion.LineThickness = 3;
            this.txt_Direccion.Location = new System.Drawing.Point(54, 226);
            this.txt_Direccion.Margin = new System.Windows.Forms.Padding(4);
            this.txt_Direccion.Name = "txt_Direccion";
            this.txt_Direccion.Size = new System.Drawing.Size(451, 30);
            this.txt_Direccion.TabIndex = 4;
            this.txt_Direccion.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Calibri", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Gray;
            this.label9.Image = ((System.Drawing.Image)(resources.GetObject("label9.Image")));
            this.label9.Location = new System.Drawing.Point(17, 231);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(24, 24);
            this.label9.TabIndex = 82;
            // 
            // txt_DNIRUC
            // 
            this.txt_DNIRUC.BackColor = System.Drawing.Color.White;
            this.txt_DNIRUC.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_DNIRUC.Font = new System.Drawing.Font("Calibri Light", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_DNIRUC.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txt_DNIRUC.HintForeColor = System.Drawing.Color.Empty;
            this.txt_DNIRUC.HintText = "DNI - RUC";
            this.txt_DNIRUC.isPassword = false;
            this.txt_DNIRUC.LineFocusedColor = System.Drawing.Color.DodgerBlue;
            this.txt_DNIRUC.LineIdleColor = System.Drawing.Color.LimeGreen;
            this.txt_DNIRUC.LineMouseHoverColor = System.Drawing.Color.DodgerBlue;
            this.txt_DNIRUC.LineThickness = 3;
            this.txt_DNIRUC.Location = new System.Drawing.Point(54, 114);
            this.txt_DNIRUC.Margin = new System.Windows.Forms.Padding(4);
            this.txt_DNIRUC.Name = "txt_DNIRUC";
            this.txt_DNIRUC.Size = new System.Drawing.Size(112, 30);
            this.txt_DNIRUC.TabIndex = 3;
            this.txt_DNIRUC.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Calibri", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Gray;
            this.label8.Image = ((System.Drawing.Image)(resources.GetObject("label8.Image")));
            this.label8.Location = new System.Drawing.Point(17, 120);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(24, 24);
            this.label8.TabIndex = 80;
            // 
            // txt_RasonSocial
            // 
            this.txt_RasonSocial.BackColor = System.Drawing.Color.White;
            this.txt_RasonSocial.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_RasonSocial.Font = new System.Drawing.Font("Calibri Light", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_RasonSocial.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txt_RasonSocial.HintForeColor = System.Drawing.Color.Empty;
            this.txt_RasonSocial.HintText = "";
            this.txt_RasonSocial.isPassword = false;
            this.txt_RasonSocial.LineFocusedColor = System.Drawing.Color.DodgerBlue;
            this.txt_RasonSocial.LineIdleColor = System.Drawing.Color.LimeGreen;
            this.txt_RasonSocial.LineMouseHoverColor = System.Drawing.Color.DodgerBlue;
            this.txt_RasonSocial.LineThickness = 3;
            this.txt_RasonSocial.Location = new System.Drawing.Point(54, 168);
            this.txt_RasonSocial.Margin = new System.Windows.Forms.Padding(4);
            this.txt_RasonSocial.Name = "txt_RasonSocial";
            this.txt_RasonSocial.Size = new System.Drawing.Size(451, 30);
            this.txt_RasonSocial.TabIndex = 2;
            this.txt_RasonSocial.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Calibri", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Gray;
            this.label7.Image = ((System.Drawing.Image)(resources.GetObject("label7.Image")));
            this.label7.Location = new System.Drawing.Point(17, 173);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(24, 24);
            this.label7.TabIndex = 78;
            // 
            // txt_idCliente
            // 
            this.txt_idCliente.BackColor = System.Drawing.Color.White;
            this.txt_idCliente.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_idCliente.Enabled = false;
            this.txt_idCliente.Font = new System.Drawing.Font("Calibri Light", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_idCliente.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txt_idCliente.HintForeColor = System.Drawing.Color.Empty;
            this.txt_idCliente.HintText = "ID Cliente";
            this.txt_idCliente.isPassword = false;
            this.txt_idCliente.LineFocusedColor = System.Drawing.Color.DodgerBlue;
            this.txt_idCliente.LineIdleColor = System.Drawing.Color.LimeGreen;
            this.txt_idCliente.LineMouseHoverColor = System.Drawing.Color.DodgerBlue;
            this.txt_idCliente.LineThickness = 3;
            this.txt_idCliente.Location = new System.Drawing.Point(54, 62);
            this.txt_idCliente.Margin = new System.Windows.Forms.Padding(4);
            this.txt_idCliente.Name = "txt_idCliente";
            this.txt_idCliente.Size = new System.Drawing.Size(137, 30);
            this.txt_idCliente.TabIndex = 28;
            this.txt_idCliente.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Calibri", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Gray;
            this.label6.Image = ((System.Drawing.Image)(resources.GetObject("label6.Image")));
            this.label6.Location = new System.Drawing.Point(17, 67);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(24, 24);
            this.label6.TabIndex = 27;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Gray;
            this.label5.Location = new System.Drawing.Point(113, 6);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(248, 29);
            this.label5.TabIndex = 25;
            this.label5.Text = "Registrar Nuevo Cliente";
            // 
            // bunifuSeparator2
            // 
            this.bunifuSeparator2.BackColor = System.Drawing.Color.Transparent;
            this.bunifuSeparator2.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(211)))), ((int)(((byte)(211)))));
            this.bunifuSeparator2.LineThickness = 1;
            this.bunifuSeparator2.Location = new System.Drawing.Point(76, 25);
            this.bunifuSeparator2.Name = "bunifuSeparator2";
            this.bunifuSeparator2.Size = new System.Drawing.Size(327, 20);
            this.bunifuSeparator2.TabIndex = 26;
            this.bunifuSeparator2.Transparency = 255;
            this.bunifuSeparator2.Vertical = false;
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Location = new System.Drawing.Point(90, 555);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(10, 13);
            this.lblID.TabIndex = 88;
            this.lblID.Text = "-";
            this.lblID.Visible = false;
            // 
            // lblnom
            // 
            this.lblnom.AutoSize = true;
            this.lblnom.Location = new System.Drawing.Point(132, 555);
            this.lblnom.Name = "lblnom";
            this.lblnom.Size = new System.Drawing.Size(10, 13);
            this.lblnom.TabIndex = 89;
            this.lblnom.Text = "-";
            this.lblnom.Visible = false;
            // 
            // lblRUC
            // 
            this.lblRUC.AutoSize = true;
            this.lblRUC.Location = new System.Drawing.Point(179, 555);
            this.lblRUC.Name = "lblRUC";
            this.lblRUC.Size = new System.Drawing.Size(10, 13);
            this.lblRUC.TabIndex = 90;
            this.lblRUC.Text = "-";
            this.lblRUC.Visible = false;
            // 
            // bunifuThinButton21
            // 
            this.bunifuThinButton21.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.bunifuThinButton21.BackgroundStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.bunifuThinButton21.BackgroundStyle.SolidColor = System.Drawing.Color.DarkSeaGreen;
            this.bunifuThinButton21.BorderStyle.BorderShape.BottomLeft = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.bunifuThinButton21.BorderStyle.BorderShape.BottomRight = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.bunifuThinButton21.BorderStyle.BorderShape.TopLeft = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.bunifuThinButton21.BorderStyle.BorderShape.TopRight = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.bunifuThinButton21.BorderStyle.EdgeRadius = 7;
            this.bunifuThinButton21.BorderStyle.SmoothingMode = Klik.Windows.Forms.v1.Common.SmoothingModes.AntiAlias;
            this.bunifuThinButton21.BorderStyle.SolidColor = System.Drawing.Color.DarkSeaGreen;
            this.bunifuThinButton21.DropDownArrowColor = System.Drawing.Color.Black;
            this.bunifuThinButton21.FlashStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.bunifuThinButton21.FlashStyle.SolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(240)))), ((int)(((byte)(191)))));
            this.bunifuThinButton21.ForegroundImageStyle.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.bunifuThinButton21.Location = new System.Drawing.Point(198, 475);
            this.bunifuThinButton21.Name = "bunifuThinButton21";
            this.bunifuThinButton21.Office2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ClassicSilver;
            this.bunifuThinButton21.Size = new System.Drawing.Size(123, 40);
            this.bunifuThinButton21.StateStyles.DisabledStyle.TextFont = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuThinButton21.StateStyles.DisabledStyle.TextForeColor = System.Drawing.Color.DarkSeaGreen;
            this.bunifuThinButton21.StateStyles.FocusStyle.BackgroundSolidColor = System.Drawing.Color.DarkSeaGreen;
            this.bunifuThinButton21.StateStyles.FocusStyle.TextBackColor = System.Drawing.Color.DarkSeaGreen;
            this.bunifuThinButton21.StateStyles.FocusStyle.TextFont = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuThinButton21.StateStyles.FocusStyle.TextForeColor = System.Drawing.Color.WhiteSmoke;
            this.bunifuThinButton21.StateStyles.HoverStyle.BackgroundGradientEndColor = System.Drawing.Color.Transparent;
            this.bunifuThinButton21.StateStyles.HoverStyle.BackgroundGradientStartColor = System.Drawing.Color.Transparent;
            this.bunifuThinButton21.StateStyles.HoverStyle.BackgroundImageFilterColor = System.Drawing.Color.White;
            this.bunifuThinButton21.StateStyles.HoverStyle.BackgroundSolidColor = System.Drawing.Color.DarkGray;
            this.bunifuThinButton21.StateStyles.HoverStyle.BorderSolidColor = System.Drawing.Color.DarkGray;
            this.bunifuThinButton21.StateStyles.HoverStyle.TextFont = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuThinButton21.StateStyles.HoverStyle.TextForeColor = System.Drawing.Color.WhiteSmoke;
            this.bunifuThinButton21.StateStyles.PressedStyle.BackgroundSolidColor = System.Drawing.Color.DarkSeaGreen;
            this.bunifuThinButton21.StateStyles.PressedStyle.BorderSolidColor = System.Drawing.Color.WhiteSmoke;
            this.bunifuThinButton21.StateStyles.PressedStyle.TextFont = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuThinButton21.TabIndex = 752;
            this.bunifuThinButton21.TextStyle.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.bunifuThinButton21.TextStyle.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuThinButton21.TextStyle.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.bunifuThinButton21.TextStyle.Text = "Salir";
            this.bunifuThinButton21.TextStyle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.bunifuThinButton21.TransparentStyle.BackColor = System.Drawing.Color.Empty;
            this.bunifuThinButton21.VisualStyle = Klik.Windows.Forms.v1.EntryLib.ButtonVisualStyles.Custom;
            this.bunifuThinButton21.Click += new System.EventHandler(this.bunifuThinButton21_Click);
            // 
            // btn_new2
            // 
            this.btn_new2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btn_new2.BackgroundStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.btn_new2.BackgroundStyle.SolidColor = System.Drawing.Color.WhiteSmoke;
            this.btn_new2.BorderStyle.BorderShape.BottomLeft = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.btn_new2.BorderStyle.BorderShape.BottomRight = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.btn_new2.BorderStyle.BorderShape.TopLeft = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.btn_new2.BorderStyle.BorderShape.TopRight = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.btn_new2.BorderStyle.EdgeRadius = 7;
            this.btn_new2.BorderStyle.SmoothingMode = Klik.Windows.Forms.v1.Common.SmoothingModes.AntiAlias;
            this.btn_new2.BorderStyle.SolidColor = System.Drawing.Color.DarkSeaGreen;
            this.btn_new2.FlashStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.btn_new2.FlashStyle.SolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(240)))), ((int)(((byte)(191)))));
            this.btn_new2.ForegroundImageStyle.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn_new2.Location = new System.Drawing.Point(344, 475);
            this.btn_new2.Name = "btn_new2";
            this.btn_new2.Office2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ClassicSilver;
            this.btn_new2.Size = new System.Drawing.Size(125, 40);
            this.btn_new2.StateStyles.HoverStyle.BackgroundSolidColor = System.Drawing.Color.DarkGray;
            this.btn_new2.StateStyles.HoverStyle.BorderSolidColor = System.Drawing.Color.DarkGray;
            this.btn_new2.StateStyles.HoverStyle.TextFont = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_new2.StateStyles.HoverStyle.TextForeColor = System.Drawing.Color.White;
            this.btn_new2.StateStyles.PressedStyle.BackgroundSolidColor = System.Drawing.Color.DarkSeaGreen;
            this.btn_new2.StateStyles.PressedStyle.BorderSolidColor = System.Drawing.Color.DarkSeaGreen;
            this.btn_new2.StateStyles.PressedStyle.TextFont = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_new2.StateStyles.PressedStyle.TextForeColor = System.Drawing.Color.White;
            this.btn_new2.TabIndex = 751;
            this.btn_new2.TextStyle.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_new2.TextStyle.ForeColor = System.Drawing.Color.DarkSeaGreen;
            this.btn_new2.TextStyle.Text = "Nuevo";
            this.btn_new2.TextStyle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn_new2.VisualStyle = Klik.Windows.Forms.v1.EntryLib.ButtonVisualStyles.Custom;
            this.btn_new2.Click += new System.EventHandler(this.btn_new_Click);
            // 
            // Frm_ListadoClientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(556, 529);
            this.Controls.Add(this.PNL_AgregarCliente);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.list_Cliente);
            this.Controls.Add(this.pnl_titu);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblnom);
            this.Controls.Add(this.lblID);
            this.Controls.Add(this.lblRUC);
            this.Controls.Add(this.bunifuSeparator1);
            this.Controls.Add(this.bunifuThinButton21);
            this.Controls.Add(this.btn_new2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "Frm_ListadoClientes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Frm_ListadoClientes";
            this.Load += new System.EventHandler(this.Frm_ListadoClientes_Load);
            this.pnl_titu.ResumeLayout(false);
            this.pnl_titu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.elLabel1)).EndInit();
            this.PNL_AgregarCliente.ResumeLayout(false);
            this.PNL_AgregarCliente.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bunifuThinButton21)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_new2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private System.Windows.Forms.Panel pnl_titu;
        private System.Windows.Forms.Label label1;
        private Bunifu.Framework.UI.BunifuSeparator bunifuSeparator1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListView list_Cliente;
        private Bunifu.Framework.UI.BunifuMaterialTextbox txt_buscar;
        private Klik.Windows.Forms.v1.EntryLib.ELLabel elLabel1;
        private System.Windows.Forms.Panel PNL_AgregarCliente;
        private Bunifu.Framework.UI.BunifuMaterialTextbox txt_idCliente;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private Bunifu.Framework.UI.BunifuSeparator bunifuSeparator2;
        private Bunifu.Framework.UI.BunifuMaterialTextbox txt_Direccion;
        private System.Windows.Forms.Label label9;
        private Bunifu.Framework.UI.BunifuMaterialTextbox txt_DNIRUC;
        private System.Windows.Forms.Label label8;
        private Bunifu.Framework.UI.BunifuMaterialTextbox txt_RasonSocial;
        private System.Windows.Forms.Label label7;
        private Bunifu.Framework.UI.BunifuThinButton2 btn_agregar;
        private Bunifu.Framework.UI.BunifuThinButton2 btn_cancelar;
        private System.Windows.Forms.DateTimePicker dtp_aniv;
        private System.Windows.Forms.Label lblCantCliente;
        private System.Windows.Forms.Label label10;
        public System.Windows.Forms.Label lblnom;
        public System.Windows.Forms.Label lblID;
        public System.Windows.Forms.Label lblRUC;
        private Bunifu.Framework.UI.BunifuMaterialTextbox txt_Tipo;
        private Bunifu.Framework.UI.BunifuMaterialTextbox txt_Condicion;
        private Guna.UI.WinForms.GunaCheckBox chk_consultaSunat;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private Klik.Windows.Forms.v1.EntryLib.ELButton bunifuThinButton21;
        private Klik.Windows.Forms.v1.EntryLib.ELButton btn_new2;
        private System.Windows.Forms.Label label13;
        private Bunifu.Framework.UI.BunifuMaterialTextbox txt_estado;
        private Bunifu.Framework.UI.BunifuThinButton2 btn_Consultar;
        private System.Windows.Forms.Label lbl_buscando;
        private Guna.UI.WinForms.GunaCheckBox chk_consultaReniec;
    }
}