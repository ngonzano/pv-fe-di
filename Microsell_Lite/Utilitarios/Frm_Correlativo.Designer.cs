
namespace Microsell_Lite.Utilitarios
{
    partial class Frm_Correlativo
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
            Klik.Windows.Forms.v1.Common.PaintStyle paintStyle2 = new Klik.Windows.Forms.v1.Common.PaintStyle();
            Klik.Windows.Forms.v1.Common.PaintStyle paintStyle1 = new Klik.Windows.Forms.v1.Common.PaintStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Correlativo));
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.cbb_TipDocumento = new System.Windows.Forms.ComboBox();
            this.ElDivider3 = new Klik.Windows.Forms.v1.EntryLib.ELDivider();
            this.Label17 = new System.Windows.Forms.Label();
            this.pnl_subtitu = new System.Windows.Forms.Panel();
            this.btn_cerrar = new System.Windows.Forms.Button();
            this.elDivider2 = new Klik.Windows.Forms.v1.EntryLib.ELDivider();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.elDivider1 = new Klik.Windows.Forms.v1.EntryLib.ELDivider();
            this.label11 = new System.Windows.Forms.Label();
            this.txt_Serie = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.elLabel6 = new Klik.Windows.Forms.v1.EntryLib.ELLabel();
            this.txt_numero = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.elLabel1 = new Klik.Windows.Forms.v1.EntryLib.ELLabel();
            this.label5 = new System.Windows.Forms.Label();
            this.grb_Documento = new System.Windows.Forms.GroupBox();
            this.btn_listo2 = new Klik.Windows.Forms.v1.EntryLib.ELButton();
            this.btn_cancel2 = new Klik.Windows.Forms.v1.EntryLib.ELButton();
            ((System.ComponentModel.ISupportInitialize)(this.ElDivider3)).BeginInit();
            this.pnl_subtitu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.elDivider2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.elDivider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.elLabel6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.elLabel1)).BeginInit();
            this.grb_Documento.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btn_listo2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_cancel2)).BeginInit();
            this.SuspendLayout();
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 5;
            this.bunifuElipse1.TargetControl = this;
            // 
            // cbb_TipDocumento
            // 
            this.cbb_TipDocumento.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cbb_TipDocumento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbb_TipDocumento.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbb_TipDocumento.ForeColor = System.Drawing.Color.DimGray;
            this.cbb_TipDocumento.FormattingEnabled = true;
            this.cbb_TipDocumento.Items.AddRange(new object[] {
            "Seleccionar..."});
            this.cbb_TipDocumento.Location = new System.Drawing.Point(201, 74);
            this.cbb_TipDocumento.Name = "cbb_TipDocumento";
            this.cbb_TipDocumento.Size = new System.Drawing.Size(176, 26);
            this.cbb_TipDocumento.TabIndex = 1;
            this.cbb_TipDocumento.SelectionChangeCommitted += new System.EventHandler(this.cbb_TipDocumento_SelectionChangeCommitted);
            // 
            // ElDivider3
            // 
            this.ElDivider3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.ElDivider3.FadeStyle = Klik.Windows.Forms.v1.EntryLib.DividerFadeStyles.Center;
            this.ElDivider3.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ElDivider3.Location = new System.Drawing.Point(-1, 27);
            this.ElDivider3.Margin = new System.Windows.Forms.Padding(4);
            this.ElDivider3.Name = "ElDivider3";
            this.ElDivider3.Size = new System.Drawing.Size(419, 19);
            this.ElDivider3.TabIndex = 408;
            this.ElDivider3.VisualStyle = Klik.Windows.Forms.v1.Common.ControlVisualStyles.Custom;
            // 
            // Label17
            // 
            this.Label17.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Label17.AutoSize = true;
            this.Label17.BackColor = System.Drawing.Color.Transparent;
            this.Label17.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label17.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.Label17.Location = new System.Drawing.Point(111, 4);
            this.Label17.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label17.Name = "Label17";
            this.Label17.Size = new System.Drawing.Size(205, 32);
            this.Label17.TabIndex = 405;
            this.Label17.Text = "Editar Correlativo";
            // 
            // pnl_subtitu
            // 
            this.pnl_subtitu.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.pnl_subtitu.Controls.Add(this.Label17);
            this.pnl_subtitu.Controls.Add(this.btn_cerrar);
            this.pnl_subtitu.Controls.Add(this.elDivider2);
            this.pnl_subtitu.Controls.Add(this.ElDivider3);
            this.pnl_subtitu.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_subtitu.Location = new System.Drawing.Point(0, 0);
            this.pnl_subtitu.Name = "pnl_subtitu";
            this.pnl_subtitu.Size = new System.Drawing.Size(422, 40);
            this.pnl_subtitu.TabIndex = 732;
            this.pnl_subtitu.Paint += new System.Windows.Forms.PaintEventHandler(this.pnl_subtitu_Paint);
            // 
            // btn_cerrar
            // 
            this.btn_cerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_cerrar.FlatAppearance.BorderSize = 0;
            this.btn_cerrar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SkyBlue;
            this.btn_cerrar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SkyBlue;
            this.btn_cerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_cerrar.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_cerrar.ForeColor = System.Drawing.Color.White;
            this.btn_cerrar.Image = ((System.Drawing.Image)(resources.GetObject("btn_cerrar.Image")));
            this.btn_cerrar.Location = new System.Drawing.Point(379, 1);
            this.btn_cerrar.Name = "btn_cerrar";
            this.btn_cerrar.Size = new System.Drawing.Size(42, 36);
            this.btn_cerrar.TabIndex = 410;
            this.btn_cerrar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_cerrar.UseVisualStyleBackColor = true;
            this.btn_cerrar.Click += new System.EventHandler(this.btn_cerrar_Click);
            // 
            // elDivider2
            // 
            this.elDivider2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.elDivider2.FadeStyle = Klik.Windows.Forms.v1.EntryLib.DividerFadeStyles.Center;
            this.elDivider2.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.elDivider2.Location = new System.Drawing.Point(4, -7);
            this.elDivider2.Margin = new System.Windows.Forms.Padding(4);
            this.elDivider2.Name = "elDivider2";
            this.elDivider2.Size = new System.Drawing.Size(407, 19);
            this.elDivider2.TabIndex = 409;
            this.elDivider2.VisualStyle = Klik.Windows.Forms.v1.Common.ControlVisualStyles.Custom;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DimGray;
            this.label2.Location = new System.Drawing.Point(26, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(169, 18);
            this.label2.TabIndex = 733;
            this.label2.Text = "Tipo De Documento";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DimGray;
            this.label3.Location = new System.Drawing.Point(27, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 16);
            this.label3.TabIndex = 735;
            this.label3.Text = "Serie";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.DimGray;
            this.label4.Location = new System.Drawing.Point(203, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 16);
            this.label4.TabIndex = 736;
            this.label4.Text = "Numero";
            // 
            // elDivider1
            // 
            this.elDivider1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.elDivider1.FadeStyle = Klik.Windows.Forms.v1.EntryLib.DividerFadeStyles.Center;
            this.elDivider1.LineColor = System.Drawing.Color.DarkSeaGreen;
            this.elDivider1.LineSize = 3;
            this.elDivider1.Location = new System.Drawing.Point(0, 273);
            this.elDivider1.Margin = new System.Windows.Forms.Padding(4);
            this.elDivider1.Name = "elDivider1";
            this.elDivider1.Size = new System.Drawing.Size(422, 10);
            this.elDivider1.TabIndex = 739;
            this.elDivider1.VisualStyle = Klik.Windows.Forms.v1.Common.ControlVisualStyles.Custom;
            // 
            // label11
            // 
            this.label11.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label11.Image = ((System.Drawing.Image)(resources.GetObject("label11.Image")));
            this.label11.Location = new System.Drawing.Point(45, 162);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(26, 26);
            this.label11.TabIndex = 742;
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txt_Serie
            // 
            this.txt_Serie.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txt_Serie.Depth = 0;
            this.txt_Serie.Enabled = false;
            this.txt_Serie.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Serie.Hint = "";
            this.txt_Serie.Location = new System.Drawing.Point(78, 165);
            this.txt_Serie.MouseState = MaterialSkin.MouseState.HOVER;
            this.txt_Serie.Name = "txt_Serie";
            this.txt_Serie.PasswordChar = '\0';
            this.txt_Serie.SelectedText = "";
            this.txt_Serie.SelectionLength = 0;
            this.txt_Serie.SelectionStart = 0;
            this.txt_Serie.Size = new System.Drawing.Size(59, 23);
            this.txt_Serie.TabIndex = 740;
            this.txt_Serie.Text = "0";
            this.txt_Serie.UseSystemPasswordChar = false;
            // 
            // elLabel6
            // 
            this.elLabel6.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.elLabel6.BackgroundStyle.GradientEndColor = System.Drawing.Color.White;
            this.elLabel6.BackgroundStyle.GradientStartColor = System.Drawing.Color.White;
            this.elLabel6.BorderStyle.BorderShape.BottomLeft = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.elLabel6.BorderStyle.BorderShape.BottomRight = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.elLabel6.BorderStyle.BorderShape.TopLeft = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.elLabel6.BorderStyle.BorderShape.TopRight = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.elLabel6.BorderStyle.GradientEndColor = System.Drawing.Color.DimGray;
            this.elLabel6.BorderStyle.GradientStartColor = System.Drawing.Color.DimGray;
            this.elLabel6.BorderStyle.SolidColor = System.Drawing.Color.DimGray;
            this.elLabel6.Cursor = System.Windows.Forms.Cursors.Default;
            paintStyle2.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            paintStyle2.SolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(240)))), ((int)(((byte)(191)))));
            this.elLabel6.FlashStyle = paintStyle2;
            this.elLabel6.ImeMode = System.Windows.Forms.ImeMode.On;
            this.elLabel6.Location = new System.Drawing.Point(34, 156);
            this.elLabel6.Name = "elLabel6";
            this.elLabel6.Size = new System.Drawing.Size(120, 35);
            this.elLabel6.TabIndex = 741;
            this.elLabel6.TabStop = false;
            this.elLabel6.VisualStyle = Klik.Windows.Forms.v1.Common.ControlVisualStyles.Custom;
            // 
            // txt_numero
            // 
            this.txt_numero.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txt_numero.Depth = 0;
            this.txt_numero.Enabled = false;
            this.txt_numero.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_numero.Hint = "";
            this.txt_numero.Location = new System.Drawing.Point(247, 165);
            this.txt_numero.MouseState = MaterialSkin.MouseState.HOVER;
            this.txt_numero.Name = "txt_numero";
            this.txt_numero.PasswordChar = '\0';
            this.txt_numero.SelectedText = "";
            this.txt_numero.SelectionLength = 0;
            this.txt_numero.SelectionStart = 0;
            this.txt_numero.Size = new System.Drawing.Size(80, 23);
            this.txt_numero.TabIndex = 743;
            this.txt_numero.Text = "0";
            this.txt_numero.UseSystemPasswordChar = false;
            this.txt_numero.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_numero_KeyPress);
            // 
            // elLabel1
            // 
            this.elLabel1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.elLabel1.BackgroundStyle.GradientEndColor = System.Drawing.Color.White;
            this.elLabel1.BackgroundStyle.GradientStartColor = System.Drawing.Color.White;
            this.elLabel1.BorderStyle.BorderShape.BottomLeft = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.elLabel1.BorderStyle.BorderShape.BottomRight = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.elLabel1.BorderStyle.BorderShape.TopLeft = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.elLabel1.BorderStyle.BorderShape.TopRight = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.elLabel1.BorderStyle.GradientEndColor = System.Drawing.Color.DimGray;
            this.elLabel1.BorderStyle.GradientStartColor = System.Drawing.Color.DimGray;
            this.elLabel1.BorderStyle.SolidColor = System.Drawing.Color.DimGray;
            this.elLabel1.Cursor = System.Windows.Forms.Cursors.Default;
            paintStyle1.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            paintStyle1.SolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(240)))), ((int)(((byte)(191)))));
            this.elLabel1.FlashStyle = paintStyle1;
            this.elLabel1.ImeMode = System.Windows.Forms.ImeMode.On;
            this.elLabel1.Location = new System.Drawing.Point(207, 156);
            this.elLabel1.Name = "elLabel1";
            this.elLabel1.Size = new System.Drawing.Size(137, 35);
            this.elLabel1.TabIndex = 744;
            this.elLabel1.TabStop = false;
            this.elLabel1.VisualStyle = Klik.Windows.Forms.v1.Common.ControlVisualStyles.Custom;
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label5.Image = ((System.Drawing.Image)(resources.GetObject("label5.Image")));
            this.label5.Location = new System.Drawing.Point(218, 162);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(26, 26);
            this.label5.TabIndex = 747;
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // grb_Documento
            // 
            this.grb_Documento.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.grb_Documento.Controls.Add(this.label4);
            this.grb_Documento.Controls.Add(this.label3);
            this.grb_Documento.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grb_Documento.ForeColor = System.Drawing.Color.DimGray;
            this.grb_Documento.Location = new System.Drawing.Point(22, 110);
            this.grb_Documento.Name = "grb_Documento";
            this.grb_Documento.Size = new System.Drawing.Size(378, 95);
            this.grb_Documento.TabIndex = 748;
            this.grb_Documento.TabStop = false;
            this.grb_Documento.Text = "Documento";
            // 
            // btn_listo2
            // 
            this.btn_listo2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btn_listo2.BackgroundStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.btn_listo2.BackgroundStyle.SolidColor = System.Drawing.Color.DarkSeaGreen;
            this.btn_listo2.BorderStyle.BorderShape.BottomLeft = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.btn_listo2.BorderStyle.BorderShape.BottomRight = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.btn_listo2.BorderStyle.BorderShape.TopLeft = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.btn_listo2.BorderStyle.BorderShape.TopRight = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.btn_listo2.BorderStyle.EdgeRadius = 7;
            this.btn_listo2.BorderStyle.SmoothingMode = Klik.Windows.Forms.v1.Common.SmoothingModes.AntiAlias;
            this.btn_listo2.BorderStyle.SolidColor = System.Drawing.Color.DarkSeaGreen;
            this.btn_listo2.DropDownArrowColor = System.Drawing.Color.Black;
            this.btn_listo2.FlashStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.btn_listo2.FlashStyle.SolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(240)))), ((int)(((byte)(191)))));
            this.btn_listo2.ForegroundImageStyle.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn_listo2.Location = new System.Drawing.Point(228, 223);
            this.btn_listo2.Name = "btn_listo2";
            this.btn_listo2.Office2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ClassicSilver;
            this.btn_listo2.Size = new System.Drawing.Size(123, 40);
            this.btn_listo2.StateStyles.DisabledStyle.TextFont = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_listo2.StateStyles.DisabledStyle.TextForeColor = System.Drawing.Color.DarkSeaGreen;
            this.btn_listo2.StateStyles.FocusStyle.BackgroundSolidColor = System.Drawing.Color.DarkSeaGreen;
            this.btn_listo2.StateStyles.FocusStyle.TextBackColor = System.Drawing.Color.DarkSeaGreen;
            this.btn_listo2.StateStyles.FocusStyle.TextFont = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_listo2.StateStyles.FocusStyle.TextForeColor = System.Drawing.Color.WhiteSmoke;
            this.btn_listo2.StateStyles.HoverStyle.BackgroundGradientEndColor = System.Drawing.Color.Transparent;
            this.btn_listo2.StateStyles.HoverStyle.BackgroundGradientStartColor = System.Drawing.Color.Transparent;
            this.btn_listo2.StateStyles.HoverStyle.BackgroundImageFilterColor = System.Drawing.Color.White;
            this.btn_listo2.StateStyles.HoverStyle.BackgroundSolidColor = System.Drawing.Color.DarkGray;
            this.btn_listo2.StateStyles.HoverStyle.BorderSolidColor = System.Drawing.Color.DarkGray;
            this.btn_listo2.StateStyles.HoverStyle.TextFont = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_listo2.StateStyles.HoverStyle.TextForeColor = System.Drawing.Color.WhiteSmoke;
            this.btn_listo2.StateStyles.PressedStyle.BackgroundSolidColor = System.Drawing.Color.DarkSeaGreen;
            this.btn_listo2.StateStyles.PressedStyle.BorderSolidColor = System.Drawing.Color.WhiteSmoke;
            this.btn_listo2.StateStyles.PressedStyle.TextFont = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_listo2.TabIndex = 750;
            this.btn_listo2.TextStyle.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btn_listo2.TextStyle.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_listo2.TextStyle.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btn_listo2.TextStyle.Text = "Actualizar";
            this.btn_listo2.TextStyle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn_listo2.TransparentStyle.BackColor = System.Drawing.Color.Empty;
            this.btn_listo2.VisualStyle = Klik.Windows.Forms.v1.EntryLib.ButtonVisualStyles.Custom;
            this.btn_listo2.Click += new System.EventHandler(this.btn_listo_Click);
            // 
            // btn_cancel2
            // 
            this.btn_cancel2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btn_cancel2.BackgroundStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.btn_cancel2.BackgroundStyle.SolidColor = System.Drawing.Color.WhiteSmoke;
            this.btn_cancel2.BorderStyle.BorderShape.BottomLeft = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.btn_cancel2.BorderStyle.BorderShape.BottomRight = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.btn_cancel2.BorderStyle.BorderShape.TopLeft = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.btn_cancel2.BorderStyle.BorderShape.TopRight = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.btn_cancel2.BorderStyle.EdgeRadius = 7;
            this.btn_cancel2.BorderStyle.SmoothingMode = Klik.Windows.Forms.v1.Common.SmoothingModes.AntiAlias;
            this.btn_cancel2.BorderStyle.SolidColor = System.Drawing.Color.DarkSeaGreen;
            this.btn_cancel2.FlashStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.btn_cancel2.FlashStyle.SolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(240)))), ((int)(((byte)(191)))));
            this.btn_cancel2.ForegroundImageStyle.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn_cancel2.Location = new System.Drawing.Point(78, 223);
            this.btn_cancel2.Name = "btn_cancel2";
            this.btn_cancel2.Office2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ClassicSilver;
            this.btn_cancel2.Size = new System.Drawing.Size(125, 40);
            this.btn_cancel2.StateStyles.HoverStyle.BackgroundSolidColor = System.Drawing.Color.DarkGray;
            this.btn_cancel2.StateStyles.HoverStyle.BorderSolidColor = System.Drawing.Color.DarkGray;
            this.btn_cancel2.StateStyles.HoverStyle.TextFont = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_cancel2.StateStyles.HoverStyle.TextForeColor = System.Drawing.Color.White;
            this.btn_cancel2.StateStyles.PressedStyle.BackgroundSolidColor = System.Drawing.Color.DarkSeaGreen;
            this.btn_cancel2.StateStyles.PressedStyle.BorderSolidColor = System.Drawing.Color.DarkSeaGreen;
            this.btn_cancel2.StateStyles.PressedStyle.TextFont = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_cancel2.StateStyles.PressedStyle.TextForeColor = System.Drawing.Color.White;
            this.btn_cancel2.TabIndex = 749;
            this.btn_cancel2.TextStyle.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_cancel2.TextStyle.ForeColor = System.Drawing.Color.DarkSeaGreen;
            this.btn_cancel2.TextStyle.Text = "Cancelar";
            this.btn_cancel2.TextStyle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn_cancel2.VisualStyle = Klik.Windows.Forms.v1.EntryLib.ButtonVisualStyles.Custom;
            this.btn_cancel2.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // Frm_Correlativo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(422, 283);
            this.Controls.Add(this.btn_listo2);
            this.Controls.Add(this.btn_cancel2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txt_numero);
            this.Controls.Add(this.elLabel1);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txt_Serie);
            this.Controls.Add(this.elLabel6);
            this.Controls.Add(this.elDivider1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pnl_subtitu);
            this.Controls.Add(this.cbb_TipDocumento);
            this.Controls.Add(this.grb_Documento);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Frm_Correlativo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Frm_Correlativo";
            this.Load += new System.EventHandler(this.Frm_Correlativo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ElDivider3)).EndInit();
            this.pnl_subtitu.ResumeLayout(false);
            this.pnl_subtitu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.elDivider2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.elDivider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.elLabel6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.elLabel1)).EndInit();
            this.grb_Documento.ResumeLayout(false);
            this.grb_Documento.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btn_listo2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_cancel2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private System.Windows.Forms.ComboBox cbb_TipDocumento;
        internal Klik.Windows.Forms.v1.EntryLib.ELDivider ElDivider3;
        internal System.Windows.Forms.Label Label17;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel pnl_subtitu;
        internal Klik.Windows.Forms.v1.EntryLib.ELDivider elDivider1;
        private MaterialSkin.Controls.MaterialSingleLineTextField txt_numero;
        private Klik.Windows.Forms.v1.EntryLib.ELLabel elLabel1;
        private System.Windows.Forms.Label label11;
        private MaterialSkin.Controls.MaterialSingleLineTextField txt_Serie;
        private Klik.Windows.Forms.v1.EntryLib.ELLabel elLabel6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox grb_Documento;
        internal Klik.Windows.Forms.v1.EntryLib.ELDivider elDivider2;
        private System.Windows.Forms.Button btn_cerrar;
        private Klik.Windows.Forms.v1.EntryLib.ELButton btn_listo2;
        private Klik.Windows.Forms.v1.EntryLib.ELButton btn_cancel2;
    }
}