
namespace Microsell_Lite.Ventas
{
    partial class Frm_TipoPago_Credito
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_TipoPago_Credito));
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.lbl_totalACobrar = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbl_SaldoAPagarCredito = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.dtp_FechaEmi_vec = new System.Windows.Forms.DateTimePicker();
            this.ElDivider3 = new Klik.Windows.Forms.v1.EntryLib.ELDivider();
            this.btn_listo = new Klik.Windows.Forms.v1.EntryLib.ELButton();
            this.btn_cancel = new Klik.Windows.Forms.v1.EntryLib.ELButton();
            this.label8 = new System.Windows.Forms.Label();
            this.txt_ACuenta = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.elLabel7 = new Klik.Windows.Forms.v1.EntryLib.ELLabel();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cbb_tipoPago = new System.Windows.Forms.ComboBox();
            this.elLabel3 = new Klik.Windows.Forms.v1.EntryLib.ELLabel();
            this.label28 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ElDivider3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_listo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_cancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.elLabel7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.elLabel3)).BeginInit();
            this.SuspendLayout();
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 25;
            this.bunifuElipse1.TargetControl = this;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(343, 60);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.DimGray;
            this.label1.Location = new System.Drawing.Point(68, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(220, 29);
            this.label1.TabIndex = 1;
            this.label1.Text = "Venta a Crédito";
            // 
            // lbl_totalACobrar
            // 
            this.lbl_totalACobrar.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_totalACobrar.ForeColor = System.Drawing.Color.DimGray;
            this.lbl_totalACobrar.Location = new System.Drawing.Point(173, 85);
            this.lbl_totalACobrar.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_totalACobrar.Name = "lbl_totalACobrar";
            this.lbl_totalACobrar.Size = new System.Drawing.Size(126, 27);
            this.lbl_totalACobrar.TabIndex = 494;
            this.lbl_totalACobrar.Text = "00.00";
            this.lbl_totalACobrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.ForeColor = System.Drawing.Color.DimGray;
            this.label18.Location = new System.Drawing.Point(41, 93);
            this.label18.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(109, 16);
            this.label18.TabIndex = 493;
            this.label18.Text = "Total Venta S/.";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DimGray;
            this.label3.Location = new System.Drawing.Point(56, 197);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 16);
            this.label3.TabIndex = 495;
            this.label3.Text = "A Cuenta S/.";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_SaldoAPagarCredito
            // 
            this.lbl_SaldoAPagarCredito.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_SaldoAPagarCredito.ForeColor = System.Drawing.Color.DimGray;
            this.lbl_SaldoAPagarCredito.Location = new System.Drawing.Point(173, 238);
            this.lbl_SaldoAPagarCredito.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_SaldoAPagarCredito.Name = "lbl_SaldoAPagarCredito";
            this.lbl_SaldoAPagarCredito.Size = new System.Drawing.Size(126, 27);
            this.lbl_SaldoAPagarCredito.TabIndex = 498;
            this.lbl_SaldoAPagarCredito.Text = "00.00";
            this.lbl_SaldoAPagarCredito.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.DimGray;
            this.label5.Location = new System.Drawing.Point(7, 247);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(143, 16);
            this.label5.TabIndex = 497;
            this.label5.Text = "Pendiente de PgoS/.";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.DimGray;
            this.label6.Location = new System.Drawing.Point(63, 292);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(87, 16);
            this.label6.TabIndex = 499;
            this.label6.Text = "Vencimiento";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dtp_FechaEmi_vec
            // 
            this.dtp_FechaEmi_vec.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_FechaEmi_vec.Location = new System.Drawing.Point(166, 288);
            this.dtp_FechaEmi_vec.Name = "dtp_FechaEmi_vec";
            this.dtp_FechaEmi_vec.Size = new System.Drawing.Size(140, 20);
            this.dtp_FechaEmi_vec.TabIndex = 500;
            // 
            // ElDivider3
            // 
            this.ElDivider3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.ElDivider3.FadeStyle = Klik.Windows.Forms.v1.EntryLib.DividerFadeStyles.Center;
            this.ElDivider3.LineColor = System.Drawing.Color.SteelBlue;
            this.ElDivider3.Location = new System.Drawing.Point(-2, 316);
            this.ElDivider3.Margin = new System.Windows.Forms.Padding(4);
            this.ElDivider3.Name = "ElDivider3";
            this.ElDivider3.Size = new System.Drawing.Size(345, 18);
            this.ElDivider3.TabIndex = 502;
            this.ElDivider3.VisualStyle = Klik.Windows.Forms.v1.Common.ControlVisualStyles.Custom;
            // 
            // btn_listo
            // 
            this.btn_listo.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btn_listo.BackgroundStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.btn_listo.BackgroundStyle.SolidColor = System.Drawing.Color.DodgerBlue;
            this.btn_listo.BorderStyle.BorderShape.BottomLeft = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.btn_listo.BorderStyle.BorderShape.BottomRight = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.btn_listo.BorderStyle.BorderShape.TopLeft = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.btn_listo.BorderStyle.BorderShape.TopRight = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.btn_listo.BorderStyle.EdgeRadius = 7;
            this.btn_listo.BorderStyle.SmoothingMode = Klik.Windows.Forms.v1.Common.SmoothingModes.AntiAlias;
            this.btn_listo.BorderStyle.SolidColor = System.Drawing.Color.DodgerBlue;
            this.btn_listo.Cursor = System.Windows.Forms.Cursors.Default;
            this.btn_listo.DropDownArrowColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.btn_listo.FlashStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.btn_listo.FlashStyle.SolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(240)))), ((int)(((byte)(191)))));
            this.btn_listo.ForegroundImageStyle.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn_listo.Location = new System.Drawing.Point(194, 341);
            this.btn_listo.Name = "btn_listo";
            this.btn_listo.Office2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ModernBlack;
            this.btn_listo.Size = new System.Drawing.Size(121, 37);
            this.btn_listo.StateStyles.HoverStyle.BackgroundSolidColor = System.Drawing.Color.YellowGreen;
            this.btn_listo.StateStyles.HoverStyle.BorderSolidColor = System.Drawing.Color.YellowGreen;
            this.btn_listo.StateStyles.HoverStyle.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_listo.StateStyles.PressedStyle.BackgroundSolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btn_listo.StateStyles.PressedStyle.BorderSolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btn_listo.TabIndex = 503;
            this.btn_listo.TextStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_listo.TextStyle.ForeColor = System.Drawing.Color.White;
            this.btn_listo.TextStyle.Text = "Listo";
            this.btn_listo.TextStyle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn_listo.VisualStyle = Klik.Windows.Forms.v1.EntryLib.ButtonVisualStyles.Custom;
            this.btn_listo.Click += new System.EventHandler(this.btn_listo_Click);
            // 
            // btn_cancel
            // 
            this.btn_cancel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btn_cancel.BackgroundStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.btn_cancel.BackgroundStyle.SolidColor = System.Drawing.Color.WhiteSmoke;
            this.btn_cancel.BorderStyle.BorderShape.BottomLeft = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.btn_cancel.BorderStyle.BorderShape.BottomRight = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.btn_cancel.BorderStyle.BorderShape.TopLeft = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.btn_cancel.BorderStyle.BorderShape.TopRight = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.btn_cancel.BorderStyle.EdgeRadius = 7;
            this.btn_cancel.BorderStyle.SmoothingMode = Klik.Windows.Forms.v1.Common.SmoothingModes.AntiAlias;
            this.btn_cancel.BorderStyle.SolidColor = System.Drawing.Color.Gainsboro;
            this.btn_cancel.FlashStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.btn_cancel.FlashStyle.SolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(240)))), ((int)(((byte)(191)))));
            this.btn_cancel.ForegroundImageStyle.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn_cancel.Location = new System.Drawing.Point(29, 341);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Office2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ClassicSilver;
            this.btn_cancel.Size = new System.Drawing.Size(121, 37);
            this.btn_cancel.StateStyles.HoverStyle.BackgroundSolidColor = System.Drawing.Color.DimGray;
            this.btn_cancel.StateStyles.HoverStyle.BorderSolidColor = System.Drawing.Color.DimGray;
            this.btn_cancel.StateStyles.HoverStyle.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_cancel.StateStyles.HoverStyle.TextForeColor = System.Drawing.Color.White;
            this.btn_cancel.StateStyles.PressedStyle.BackgroundSolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btn_cancel.StateStyles.PressedStyle.BorderSolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btn_cancel.StateStyles.PressedStyle.TextForeColor = System.Drawing.Color.White;
            this.btn_cancel.TabIndex = 504;
            this.btn_cancel.TextStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_cancel.TextStyle.Text = "Cancelar";
            this.btn_cancel.TextStyle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn_cancel.VisualStyle = Klik.Windows.Forms.v1.EntryLib.ButtonVisualStyles.Custom;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label8.Image = ((System.Drawing.Image)(resources.GetObject("label8.Image")));
            this.label8.Location = new System.Drawing.Point(163, 187);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(26, 26);
            this.label8.TabIndex = 541;
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txt_ACuenta
            // 
            this.txt_ACuenta.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txt_ACuenta.Depth = 0;
            this.txt_ACuenta.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_ACuenta.Hint = "";
            this.txt_ACuenta.Location = new System.Drawing.Point(194, 190);
            this.txt_ACuenta.MouseState = MaterialSkin.MouseState.HOVER;
            this.txt_ACuenta.Name = "txt_ACuenta";
            this.txt_ACuenta.PasswordChar = '\0';
            this.txt_ACuenta.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txt_ACuenta.SelectedText = "";
            this.txt_ACuenta.SelectionLength = 0;
            this.txt_ACuenta.SelectionStart = 0;
            this.txt_ACuenta.Size = new System.Drawing.Size(97, 23);
            this.txt_ACuenta.TabIndex = 0;
            this.txt_ACuenta.Text = "0";
            this.txt_ACuenta.UseSystemPasswordChar = false;
            this.txt_ACuenta.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_ACuenta_KeyDown);
            this.txt_ACuenta.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_limCredito_KeyPress);
            this.txt_ACuenta.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_ACuenta_KeyUp);
            // 
            // elLabel7
            // 
            this.elLabel7.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.elLabel7.BackgroundStyle.GradientEndColor = System.Drawing.Color.White;
            this.elLabel7.BackgroundStyle.GradientStartColor = System.Drawing.Color.White;
            this.elLabel7.BorderStyle.BorderShape.BottomLeft = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.elLabel7.BorderStyle.BorderShape.BottomRight = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.elLabel7.BorderStyle.BorderShape.TopLeft = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.elLabel7.BorderStyle.BorderShape.TopRight = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.elLabel7.BorderStyle.GradientEndColor = System.Drawing.Color.DimGray;
            this.elLabel7.BorderStyle.GradientStartColor = System.Drawing.Color.DimGray;
            this.elLabel7.BorderStyle.SolidColor = System.Drawing.Color.DimGray;
            paintStyle2.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            paintStyle2.SolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(240)))), ((int)(((byte)(191)))));
            this.elLabel7.FlashStyle = paintStyle2;
            this.elLabel7.ImeMode = System.Windows.Forms.ImeMode.On;
            this.elLabel7.Location = new System.Drawing.Point(150, 181);
            this.elLabel7.Name = "elLabel7";
            this.elLabel7.Size = new System.Drawing.Size(156, 35);
            this.elLabel7.TabIndex = 540;
            this.elLabel7.TabStop = false;
            this.elLabel7.VisualStyle = Klik.Windows.Forms.v1.Common.ControlVisualStyles.Custom;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.DimGray;
            this.label2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label2.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DimGray;
            this.label2.Location = new System.Drawing.Point(0, 386);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(343, 8);
            this.label2.TabIndex = 542;
            this.label2.Text = "Saldo S/.";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.DimGray;
            this.label4.Location = new System.Drawing.Point(53, 141);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 16);
            this.label4.TabIndex = 543;
            this.label4.Text = "Tipo de Pago";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbb_tipoPago
            // 
            this.cbb_tipoPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbb_tipoPago.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cbb_tipoPago.ForeColor = System.Drawing.Color.DimGray;
            this.cbb_tipoPago.FormattingEnabled = true;
            this.cbb_tipoPago.Items.AddRange(new object[] {
            "Efectivo",
            "Deposito",
            "Vale"});
            this.cbb_tipoPago.Location = new System.Drawing.Point(183, 136);
            this.cbb_tipoPago.Name = "cbb_tipoPago";
            this.cbb_tipoPago.Size = new System.Drawing.Size(122, 21);
            this.cbb_tipoPago.TabIndex = 545;
            // 
            // elLabel3
            // 
            this.elLabel3.BackgroundStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.elLabel3.BackgroundStyle.SolidColor = System.Drawing.Color.White;
            this.elLabel3.BorderStyle.SolidColor = System.Drawing.Color.Gainsboro;
            this.elLabel3.Cursor = System.Windows.Forms.Cursors.Default;
            paintStyle1.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            paintStyle1.SolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(240)))), ((int)(((byte)(191)))));
            this.elLabel3.FlashStyle = paintStyle1;
            this.elLabel3.Location = new System.Drawing.Point(181, 131);
            this.elLabel3.Name = "elLabel3";
            this.elLabel3.Size = new System.Drawing.Size(124, 32);
            this.elLabel3.TabIndex = 544;
            this.elLabel3.TabStop = false;
            this.elLabel3.TextStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.elLabel3.TextStyle.ForeColor = System.Drawing.Color.White;
            this.elLabel3.TextStyle.Text = "150.20";
            this.elLabel3.TextStyle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.elLabel3.VisualStyle = Klik.Windows.Forms.v1.Common.ControlVisualStyles.Custom;
            // 
            // label28
            // 
            this.label28.Image = ((System.Drawing.Image)(resources.GetObject("label28.Image")));
            this.label28.Location = new System.Drawing.Point(153, 133);
            this.label28.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(26, 26);
            this.label28.TabIndex = 546;
            this.label28.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Frm_TipoPago_Credito
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(343, 394);
            this.Controls.Add(this.cbb_tipoPago);
            this.Controls.Add(this.elLabel3);
            this.Controls.Add(this.label28);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txt_ACuenta);
            this.Controls.Add(this.elLabel7);
            this.Controls.Add(this.btn_listo);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.ElDivider3);
            this.Controls.Add(this.dtp_FechaEmi_vec);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lbl_SaldoAPagarCredito);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lbl_totalACobrar);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "Frm_TipoPago_Credito";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Frm_TipoPago_Credito";
            this.Load += new System.EventHandler(this.Frm_TipoPago_Credito_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ElDivider3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_listo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_cancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.elLabel7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.elLabel3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label18;
        internal Klik.Windows.Forms.v1.EntryLib.ELDivider ElDivider3;
        private Klik.Windows.Forms.v1.EntryLib.ELButton btn_listo;
        private Klik.Windows.Forms.v1.EntryLib.ELButton btn_cancel;
        public System.Windows.Forms.Label lbl_SaldoAPagarCredito;
        public System.Windows.Forms.Label lbl_totalACobrar;
        public System.Windows.Forms.DateTimePicker dtp_FechaEmi_vec;
        private System.Windows.Forms.Label label8;
        public MaterialSkin.Controls.MaterialSingleLineTextField txt_ACuenta;
        private Klik.Windows.Forms.v1.EntryLib.ELLabel elLabel7;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private Klik.Windows.Forms.v1.EntryLib.ELLabel elLabel3;
        private System.Windows.Forms.Label label28;
        public System.Windows.Forms.ComboBox cbb_tipoPago;
    }
}