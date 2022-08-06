
namespace Microsell_Lite.Ventas
{
    partial class Frm_PagoDeuda
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
            Klik.Windows.Forms.v1.Common.PaintStyle paintStyle4 = new Klik.Windows.Forms.v1.Common.PaintStyle();
            Klik.Windows.Forms.v1.Common.PaintStyle paintStyle3 = new Klik.Windows.Forms.v1.Common.PaintStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_PagoDeuda));
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.ElDivider3 = new Klik.Windows.Forms.v1.EntryLib.ELDivider();
            this.Label17 = new System.Windows.Forms.Label();
            this.pnl_subtitu = new System.Windows.Forms.Panel();
            this.btn_cerrar = new System.Windows.Forms.Button();
            this.elDivider2 = new Klik.Windows.Forms.v1.EntryLib.ELDivider();
            this.elDivider1 = new Klik.Windows.Forms.v1.EntryLib.ELDivider();
            this.label11 = new System.Windows.Forms.Label();
            this.txt_ACuenta = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.elLabel6 = new Klik.Windows.Forms.v1.EntryLib.ELLabel();
            this.txt_Comentario = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.elLabel1 = new Klik.Windows.Forms.v1.EntryLib.ELLabel();
            this.label5 = new System.Windows.Forms.Label();
            this.btn_listo2 = new Klik.Windows.Forms.v1.EntryLib.ELButton();
            this.btn_cancel2 = new Klik.Windows.Forms.v1.EntryLib.ELButton();
            this.label4 = new System.Windows.Forms.Label();
            this.cbb_TipoPago = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lbl_NomCliente = new System.Windows.Forms.Label();
            this.lbl_codCredito = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbl_totalAbono = new System.Windows.Forms.Label();
            this.lbl_Abono = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lbl_totalCredito = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.elDivider4 = new Klik.Windows.Forms.v1.EntryLib.ELDivider();
            this.label7 = new System.Windows.Forms.Label();
            this.lbl_saldoPendiente = new System.Windows.Forms.Label();
            this.lbl_FechaCredito = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ElDivider3)).BeginInit();
            this.pnl_subtitu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.elDivider2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.elDivider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.elLabel6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.elLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_listo2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_cancel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.elDivider4)).BeginInit();
            this.SuspendLayout();
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 5;
            this.bunifuElipse1.TargetControl = this;
            // 
            // ElDivider3
            // 
            this.ElDivider3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.ElDivider3.FadeStyle = Klik.Windows.Forms.v1.EntryLib.DividerFadeStyles.Center;
            this.ElDivider3.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ElDivider3.Location = new System.Drawing.Point(62, 38);
            this.ElDivider3.Margin = new System.Windows.Forms.Padding(4);
            this.ElDivider3.Name = "ElDivider3";
            this.ElDivider3.Size = new System.Drawing.Size(355, 10);
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
            this.Label17.Location = new System.Drawing.Point(156, 2);
            this.Label17.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label17.Name = "Label17";
            this.Label17.Size = new System.Drawing.Size(183, 32);
            this.Label17.TabIndex = 405;
            this.Label17.Text = "Ingresar Abono";
            // 
            // pnl_subtitu
            // 
            this.pnl_subtitu.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.pnl_subtitu.Controls.Add(this.btn_cerrar);
            this.pnl_subtitu.Controls.Add(this.elDivider2);
            this.pnl_subtitu.Controls.Add(this.ElDivider3);
            this.pnl_subtitu.Controls.Add(this.Label17);
            this.pnl_subtitu.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_subtitu.Location = new System.Drawing.Point(0, 0);
            this.pnl_subtitu.Name = "pnl_subtitu";
            this.pnl_subtitu.Size = new System.Drawing.Size(480, 46);
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
            this.btn_cerrar.Location = new System.Drawing.Point(434, 5);
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
            this.elDivider2.Location = new System.Drawing.Point(33, -1);
            this.elDivider2.Margin = new System.Windows.Forms.Padding(4);
            this.elDivider2.Name = "elDivider2";
            this.elDivider2.Size = new System.Drawing.Size(407, 10);
            this.elDivider2.TabIndex = 409;
            this.elDivider2.VisualStyle = Klik.Windows.Forms.v1.Common.ControlVisualStyles.Custom;
            // 
            // elDivider1
            // 
            this.elDivider1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.elDivider1.FadeStyle = Klik.Windows.Forms.v1.EntryLib.DividerFadeStyles.Center;
            this.elDivider1.LineColor = System.Drawing.Color.DarkSeaGreen;
            this.elDivider1.LineSize = 3;
            this.elDivider1.Location = new System.Drawing.Point(0, 432);
            this.elDivider1.Margin = new System.Windows.Forms.Padding(4);
            this.elDivider1.Name = "elDivider1";
            this.elDivider1.Size = new System.Drawing.Size(480, 10);
            this.elDivider1.TabIndex = 739;
            this.elDivider1.VisualStyle = Klik.Windows.Forms.v1.Common.ControlVisualStyles.Custom;
            // 
            // label11
            // 
            this.label11.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label11.Image = ((System.Drawing.Image)(resources.GetObject("label11.Image")));
            this.label11.Location = new System.Drawing.Point(149, 228);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(26, 26);
            this.label11.TabIndex = 742;
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txt_ACuenta
            // 
            this.txt_ACuenta.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txt_ACuenta.Depth = 0;
            this.txt_ACuenta.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_ACuenta.Hint = "";
            this.txt_ACuenta.Location = new System.Drawing.Point(182, 231);
            this.txt_ACuenta.MouseState = MaterialSkin.MouseState.HOVER;
            this.txt_ACuenta.Name = "txt_ACuenta";
            this.txt_ACuenta.PasswordChar = '\0';
            this.txt_ACuenta.SelectedText = "";
            this.txt_ACuenta.SelectionLength = 0;
            this.txt_ACuenta.SelectionStart = 0;
            this.txt_ACuenta.Size = new System.Drawing.Size(59, 23);
            this.txt_ACuenta.TabIndex = 740;
            this.txt_ACuenta.Text = "0";
            this.txt_ACuenta.UseSystemPasswordChar = false;
            this.txt_ACuenta.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_ACuenta_KeyPress);
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
            paintStyle4.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            paintStyle4.SolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(240)))), ((int)(((byte)(191)))));
            this.elLabel6.FlashStyle = paintStyle4;
            this.elLabel6.ImeMode = System.Windows.Forms.ImeMode.On;
            this.elLabel6.Location = new System.Drawing.Point(138, 222);
            this.elLabel6.Name = "elLabel6";
            this.elLabel6.Size = new System.Drawing.Size(120, 35);
            this.elLabel6.TabIndex = 741;
            this.elLabel6.TabStop = false;
            this.elLabel6.VisualStyle = Klik.Windows.Forms.v1.Common.ControlVisualStyles.Custom;
            // 
            // txt_Comentario
            // 
            this.txt_Comentario.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txt_Comentario.Depth = 0;
            this.txt_Comentario.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Comentario.Hint = "";
            this.txt_Comentario.Location = new System.Drawing.Point(178, 324);
            this.txt_Comentario.MouseState = MaterialSkin.MouseState.HOVER;
            this.txt_Comentario.Name = "txt_Comentario";
            this.txt_Comentario.PasswordChar = '\0';
            this.txt_Comentario.SelectedText = "";
            this.txt_Comentario.SelectionLength = 0;
            this.txt_Comentario.SelectionStart = 0;
            this.txt_Comentario.Size = new System.Drawing.Size(248, 23);
            this.txt_Comentario.TabIndex = 743;
            this.txt_Comentario.Text = "Ingresa un Comentario";
            this.txt_Comentario.UseSystemPasswordChar = false;
            this.txt_Comentario.Enter += new System.EventHandler(this.txt_Comentario_Enter);
            this.txt_Comentario.Leave += new System.EventHandler(this.txt_Comentario_Leave);
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
            paintStyle3.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            paintStyle3.SolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(240)))), ((int)(((byte)(191)))));
            this.elLabel1.FlashStyle = paintStyle3;
            this.elLabel1.ImeMode = System.Windows.Forms.ImeMode.On;
            this.elLabel1.Location = new System.Drawing.Point(137, 316);
            this.elLabel1.Name = "elLabel1";
            this.elLabel1.Size = new System.Drawing.Size(318, 35);
            this.elLabel1.TabIndex = 744;
            this.elLabel1.TabStop = false;
            this.elLabel1.VisualStyle = Klik.Windows.Forms.v1.Common.ControlVisualStyles.Custom;
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label5.Image = ((System.Drawing.Image)(resources.GetObject("label5.Image")));
            this.label5.Location = new System.Drawing.Point(145, 321);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(26, 26);
            this.label5.TabIndex = 747;
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.btn_listo2.Location = new System.Drawing.Point(243, 388);
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
            this.btn_listo2.TextStyle.Text = "Pagar";
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
            this.btn_cancel2.Location = new System.Drawing.Point(93, 388);
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
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.DimGray;
            this.label4.Location = new System.Drawing.Point(22, 59);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(116, 29);
            this.label4.TabIndex = 751;
            this.label4.Text = "Cliente:";
            // 
            // cbb_TipoPago
            // 
            this.cbb_TipoPago.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cbb_TipoPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbb_TipoPago.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbb_TipoPago.ForeColor = System.Drawing.Color.DimGray;
            this.cbb_TipoPago.FormattingEnabled = true;
            this.cbb_TipoPago.Items.AddRange(new object[] {
            "Efectivo",
            "Deposito"});
            this.cbb_TipoPago.Location = new System.Drawing.Point(138, 277);
            this.cbb_TipoPago.Name = "cbb_TipoPago";
            this.cbb_TipoPago.Size = new System.Drawing.Size(176, 26);
            this.cbb_TipoPago.TabIndex = 752;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DimGray;
            this.label1.Location = new System.Drawing.Point(31, 280);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 18);
            this.label1.TabIndex = 753;
            this.label1.Text = "Tipo de Pago:";
            // 
            // lbl_NomCliente
            // 
            this.lbl_NomCliente.BackColor = System.Drawing.Color.Transparent;
            this.lbl_NomCliente.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_NomCliente.ForeColor = System.Drawing.Color.DimGray;
            this.lbl_NomCliente.Location = new System.Drawing.Point(138, 63);
            this.lbl_NomCliente.Name = "lbl_NomCliente";
            this.lbl_NomCliente.Size = new System.Drawing.Size(309, 25);
            this.lbl_NomCliente.TabIndex = 754;
            this.lbl_NomCliente.Text = "...";
            this.lbl_NomCliente.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_codCredito
            // 
            this.lbl_codCredito.BackColor = System.Drawing.Color.Transparent;
            this.lbl_codCredito.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_codCredito.ForeColor = System.Drawing.Color.DimGray;
            this.lbl_codCredito.Location = new System.Drawing.Point(23, 403);
            this.lbl_codCredito.Name = "lbl_codCredito";
            this.lbl_codCredito.Size = new System.Drawing.Size(59, 25);
            this.lbl_codCredito.TabIndex = 755;
            this.lbl_codCredito.Text = "...";
            this.lbl_codCredito.Visible = false;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DimGray;
            this.label2.Location = new System.Drawing.Point(56, 231);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 18);
            this.label2.TabIndex = 756;
            this.label2.Text = "A Cuenta:";
            // 
            // lbl_totalAbono
            // 
            this.lbl_totalAbono.BackColor = System.Drawing.Color.Transparent;
            this.lbl_totalAbono.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_totalAbono.ForeColor = System.Drawing.Color.DimGray;
            this.lbl_totalAbono.Location = new System.Drawing.Point(256, 143);
            this.lbl_totalAbono.Name = "lbl_totalAbono";
            this.lbl_totalAbono.Size = new System.Drawing.Size(106, 18);
            this.lbl_totalAbono.TabIndex = 757;
            this.lbl_totalAbono.Text = "Total Abono:";
            // 
            // lbl_Abono
            // 
            this.lbl_Abono.BackColor = System.Drawing.Color.Transparent;
            this.lbl_Abono.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Abono.ForeColor = System.Drawing.Color.DimGray;
            this.lbl_Abono.Location = new System.Drawing.Point(356, 138);
            this.lbl_Abono.Name = "lbl_Abono";
            this.lbl_Abono.Size = new System.Drawing.Size(112, 25);
            this.lbl_Abono.TabIndex = 758;
            this.lbl_Abono.Text = "00.00";
            this.lbl_Abono.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.DimGray;
            this.label6.Location = new System.Drawing.Point(28, 143);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(114, 18);
            this.label6.TabIndex = 759;
            this.label6.Text = "Total Credito:";
            // 
            // lbl_totalCredito
            // 
            this.lbl_totalCredito.BackColor = System.Drawing.Color.Transparent;
            this.lbl_totalCredito.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_totalCredito.ForeColor = System.Drawing.Color.DimGray;
            this.lbl_totalCredito.Location = new System.Drawing.Point(139, 143);
            this.lbl_totalCredito.Name = "lbl_totalCredito";
            this.lbl_totalCredito.Size = new System.Drawing.Size(111, 25);
            this.lbl_totalCredito.TabIndex = 760;
            this.lbl_totalCredito.Text = "00.00";
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DimGray;
            this.label3.Location = new System.Drawing.Point(39, 326);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 18);
            this.label3.TabIndex = 761;
            this.label3.Text = "Comentario:";
            // 
            // elDivider4
            // 
            this.elDivider4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.elDivider4.FadeStyle = Klik.Windows.Forms.v1.EntryLib.DividerFadeStyles.Center;
            this.elDivider4.LineColor = System.Drawing.Color.DarkSeaGreen;
            this.elDivider4.Location = new System.Drawing.Point(-16, 371);
            this.elDivider4.Margin = new System.Windows.Forms.Padding(4);
            this.elDivider4.Name = "elDivider4";
            this.elDivider4.Size = new System.Drawing.Size(511, 10);
            this.elDivider4.TabIndex = 411;
            this.elDivider4.VisualStyle = Klik.Windows.Forms.v1.Common.ControlVisualStyles.Custom;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.DimGray;
            this.label7.Location = new System.Drawing.Point(46, 186);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(87, 18);
            this.label7.TabIndex = 762;
            this.label7.Text = "Pendiente:";
            // 
            // lbl_saldoPendiente
            // 
            this.lbl_saldoPendiente.BackColor = System.Drawing.Color.Transparent;
            this.lbl_saldoPendiente.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_saldoPendiente.ForeColor = System.Drawing.Color.DimGray;
            this.lbl_saldoPendiente.Location = new System.Drawing.Point(139, 184);
            this.lbl_saldoPendiente.Name = "lbl_saldoPendiente";
            this.lbl_saldoPendiente.Size = new System.Drawing.Size(107, 25);
            this.lbl_saldoPendiente.TabIndex = 763;
            this.lbl_saldoPendiente.Text = "00.00";
            // 
            // lbl_FechaCredito
            // 
            this.lbl_FechaCredito.BackColor = System.Drawing.Color.Transparent;
            this.lbl_FechaCredito.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_FechaCredito.ForeColor = System.Drawing.Color.DimGray;
            this.lbl_FechaCredito.Location = new System.Drawing.Point(139, 104);
            this.lbl_FechaCredito.Name = "lbl_FechaCredito";
            this.lbl_FechaCredito.Size = new System.Drawing.Size(184, 25);
            this.lbl_FechaCredito.TabIndex = 764;
            this.lbl_FechaCredito.Text = "...";
            this.lbl_FechaCredito.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.DimGray;
            this.label8.Location = new System.Drawing.Point(19, 111);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(114, 18);
            this.label8.TabIndex = 765;
            this.label8.Text = "Fecha Credito:";
            // 
            // Frm_PagoDeuda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(480, 442);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lbl_FechaCredito);
            this.Controls.Add(this.lbl_saldoPendiente);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.elDivider4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lbl_totalCredito);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lbl_Abono);
            this.Controls.Add(this.lbl_totalAbono);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbl_codCredito);
            this.Controls.Add(this.lbl_NomCliente);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbb_TipoPago);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btn_listo2);
            this.Controls.Add(this.btn_cancel2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txt_Comentario);
            this.Controls.Add(this.elLabel1);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txt_ACuenta);
            this.Controls.Add(this.elLabel6);
            this.Controls.Add(this.elDivider1);
            this.Controls.Add(this.pnl_subtitu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Frm_PagoDeuda";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Frm_Correlativo";
            this.Load += new System.EventHandler(this.Frm_PagoDeuda_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ElDivider3)).EndInit();
            this.pnl_subtitu.ResumeLayout(false);
            this.pnl_subtitu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.elDivider2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.elDivider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.elLabel6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.elLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_listo2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_cancel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.elDivider4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        internal Klik.Windows.Forms.v1.EntryLib.ELDivider ElDivider3;
        internal System.Windows.Forms.Label Label17;
        private System.Windows.Forms.Panel pnl_subtitu;
        internal Klik.Windows.Forms.v1.EntryLib.ELDivider elDivider1;
        private MaterialSkin.Controls.MaterialSingleLineTextField txt_Comentario;
        private Klik.Windows.Forms.v1.EntryLib.ELLabel elLabel1;
        private System.Windows.Forms.Label label11;
        private MaterialSkin.Controls.MaterialSingleLineTextField txt_ACuenta;
        private Klik.Windows.Forms.v1.EntryLib.ELLabel elLabel6;
        private System.Windows.Forms.Label label5;
        internal Klik.Windows.Forms.v1.EntryLib.ELDivider elDivider2;
        private System.Windows.Forms.Button btn_cerrar;
        private Klik.Windows.Forms.v1.EntryLib.ELButton btn_listo2;
        private Klik.Windows.Forms.v1.EntryLib.ELButton btn_cancel2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbb_TipoPago;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl_totalAbono;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        internal Klik.Windows.Forms.v1.EntryLib.ELDivider elDivider4;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.Label lbl_Abono;
        public System.Windows.Forms.Label lbl_codCredito;
        public System.Windows.Forms.Label lbl_NomCliente;
        public System.Windows.Forms.Label lbl_totalCredito;
        public System.Windows.Forms.Label lbl_saldoPendiente;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        public System.Windows.Forms.Label lbl_FechaCredito;
    }
}