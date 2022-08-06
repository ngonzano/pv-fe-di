
namespace Microsell_Lite.Principal
{
    partial class Frm_Exptar_Producto
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Exptar_Producto));
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.kFormManager1 = new Klik.Windows.Forms.v1.Common.KFormManager(this.components);
            this.pnl_titu = new System.Windows.Forms.Panel();
            this.btn_cerrar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.Dgv_Datos = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_ruta = new Klik.Windows.Forms.v1.EntryLib.ELEntryBox();
            this.txt_nomLibro = new Klik.Windows.Forms.v1.EntryLib.ELEntryBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_Quitar = new Klik.Windows.Forms.v1.EntryLib.ELButton();
            this.btn_CargarArchivo = new Klik.Windows.Forms.v1.EntryLib.ELButton();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lbl_fila = new System.Windows.Forms.Label();
            this.lbl_Guardado = new System.Windows.Forms.Label();
            this.btn_cancelar = new Klik.Windows.Forms.v1.EntryLib.ELButton();
            this.btn_aceptar = new Klik.Windows.Forms.v1.EntryLib.ELButton();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.kFormManager1)).BeginInit();
            this.pnl_titu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv_Datos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_ruta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_nomLibro)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_Quitar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_CargarArchivo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_cancelar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_aceptar)).BeginInit();
            this.SuspendLayout();
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 5;
            this.bunifuElipse1.TargetControl = this;
            // 
            // kFormManager1
            // 
            this.kFormManager1.BackgroundStyle.GradientEndColor = System.Drawing.Color.Gainsboro;
            this.kFormManager1.BackgroundStyle.GradientStartColor = System.Drawing.Color.DarkGray;
            this.kFormManager1.BackgroundStyle.SolidColor = System.Drawing.Color.DimGray;
            this.kFormManager1.BorderShape.BottomLeft = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.kFormManager1.BorderShape.BottomRight = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.kFormManager1.FormOffice2003Scheme = Klik.Windows.Forms.v1.Common.Office2003Schemes.ToolBar;
            this.kFormManager1.FormOffice2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ModernSilver;
            this.kFormManager1.MainContainer = this;
            // 
            // pnl_titu
            // 
            this.pnl_titu.BackColor = System.Drawing.Color.DimGray;
            this.pnl_titu.Controls.Add(this.label10);
            this.pnl_titu.Controls.Add(this.btn_cerrar);
            this.pnl_titu.Controls.Add(this.label1);
            this.pnl_titu.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_titu.Location = new System.Drawing.Point(0, 0);
            this.pnl_titu.Name = "pnl_titu";
            this.pnl_titu.Size = new System.Drawing.Size(691, 79);
            this.pnl_titu.TabIndex = 2;
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
            this.btn_cerrar.Location = new System.Drawing.Point(648, 3);
            this.btn_cerrar.Name = "btn_cerrar";
            this.btn_cerrar.Size = new System.Drawing.Size(32, 32);
            this.btn_cerrar.TabIndex = 20;
            this.btn_cerrar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_cerrar.UseVisualStyleBackColor = true;
            this.btn_cerrar.Click += new System.EventHandler(this.btn_cerrar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label1.Location = new System.Drawing.Point(4, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(179, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Registro de Producto";
            // 
            // Dgv_Datos
            // 
            this.Dgv_Datos.AllowUserToAddRows = false;
            this.Dgv_Datos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Dgv_Datos.ColumnHeadersVisible = false;
            this.Dgv_Datos.Location = new System.Drawing.Point(9, 337);
            this.Dgv_Datos.Name = "Dgv_Datos";
            this.Dgv_Datos.Size = new System.Drawing.Size(672, 277);
            this.Dgv_Datos.TabIndex = 3;
            this.Dgv_Datos.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Dgv_Datos_CellDoubleClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DimGray;
            this.label2.Location = new System.Drawing.Point(20, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(126, 16);
            this.label2.TabIndex = 21;
            this.label2.Text = "RUTA DEL EXCEL";
            // 
            // txt_ruta
            // 
            this.txt_ruta.CaptionStyle.CaptionSize = 0;
            this.txt_ruta.CaptionStyle.FlashStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.txt_ruta.CaptionStyle.FlashStyle.SolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(240)))), ((int)(((byte)(191)))));
            this.txt_ruta.CaptionStyle.Office2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ModernBlack;
            this.txt_ruta.CaptionStyle.TextStyle.ForeColor = System.Drawing.Color.White;
            this.txt_ruta.CaptionStyle.TextStyle.Text = "ElEntryBox1";
            this.txt_ruta.EditBoxStyle.BorderStyle.BorderType = Klik.Windows.Forms.v1.Common.BorderTypes.None;
            this.txt_ruta.EditBoxStyle.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_ruta.EditBoxStyle.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txt_ruta.EditBoxStyle.Office2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ModernBlack;
            this.txt_ruta.Enabled = false;
            this.txt_ruta.Location = new System.Drawing.Point(23, 117);
            this.txt_ruta.Name = "txt_ruta";
            this.txt_ruta.Size = new System.Drawing.Size(482, 31);
            this.txt_ruta.TabIndex = 436;
            this.txt_ruta.ValidationStyle.MaxLength = 150;
            this.txt_ruta.ValidationStyle.PasswordChar = '\0';
            this.txt_ruta.ValidationStyle.StringValidationStyle.CharacterCasing = Klik.Windows.Forms.v1.EntryLib.CharacterCasing.Upper;
            this.txt_ruta.Value = "";
            // 
            // txt_nomLibro
            // 
            this.txt_nomLibro.CaptionStyle.CaptionSize = 0;
            this.txt_nomLibro.CaptionStyle.FlashStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.txt_nomLibro.CaptionStyle.FlashStyle.SolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(240)))), ((int)(((byte)(191)))));
            this.txt_nomLibro.CaptionStyle.Office2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ModernBlack;
            this.txt_nomLibro.CaptionStyle.TextStyle.ForeColor = System.Drawing.Color.White;
            this.txt_nomLibro.CaptionStyle.TextStyle.Text = "ElEntryBox1";
            this.txt_nomLibro.EditBoxStyle.BorderStyle.BorderType = Klik.Windows.Forms.v1.Common.BorderTypes.None;
            this.txt_nomLibro.EditBoxStyle.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_nomLibro.EditBoxStyle.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txt_nomLibro.EditBoxStyle.Office2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ModernBlack;
            this.txt_nomLibro.Enabled = false;
            this.txt_nomLibro.Location = new System.Drawing.Point(23, 178);
            this.txt_nomLibro.Name = "txt_nomLibro";
            this.txt_nomLibro.Size = new System.Drawing.Size(151, 31);
            this.txt_nomLibro.TabIndex = 438;
            this.txt_nomLibro.ValidationStyle.MaxLength = 150;
            this.txt_nomLibro.ValidationStyle.PasswordChar = '\0';
            this.txt_nomLibro.ValidationStyle.StringValidationStyle.CharacterCasing = Klik.Windows.Forms.v1.EntryLib.CharacterCasing.Upper;
            this.txt_nomLibro.Value = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DimGray;
            this.label3.Location = new System.Drawing.Point(20, 159);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(148, 16);
            this.label3.TabIndex = 437;
            this.label3.Text = "NOMBRE DEL LIBRO";
            // 
            // btn_Quitar
            // 
            this.btn_Quitar.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btn_Quitar.BackgroundStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.btn_Quitar.BackgroundStyle.SolidColor = System.Drawing.Color.DarkSeaGreen;
            this.btn_Quitar.BorderStyle.BorderShape.BottomLeft = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.btn_Quitar.BorderStyle.BorderShape.BottomRight = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.btn_Quitar.BorderStyle.BorderShape.TopLeft = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.btn_Quitar.BorderStyle.BorderShape.TopRight = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.btn_Quitar.BorderStyle.EdgeRadius = 7;
            this.btn_Quitar.BorderStyle.SmoothingMode = Klik.Windows.Forms.v1.Common.SmoothingModes.AntiAlias;
            this.btn_Quitar.BorderStyle.SolidColor = System.Drawing.Color.DarkSeaGreen;
            this.btn_Quitar.DropDownArrowColor = System.Drawing.Color.Black;
            this.btn_Quitar.FlashStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.btn_Quitar.FlashStyle.SolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(240)))), ((int)(((byte)(191)))));
            this.btn_Quitar.ForegroundImageStyle.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn_Quitar.Location = new System.Drawing.Point(556, 252);
            this.btn_Quitar.Name = "btn_Quitar";
            this.btn_Quitar.Office2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ClassicSilver;
            this.btn_Quitar.Size = new System.Drawing.Size(125, 31);
            this.btn_Quitar.StateStyles.DisabledStyle.TextFont = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Quitar.StateStyles.DisabledStyle.TextForeColor = System.Drawing.Color.DarkSeaGreen;
            this.btn_Quitar.StateStyles.FocusStyle.BackgroundSolidColor = System.Drawing.Color.DarkSeaGreen;
            this.btn_Quitar.StateStyles.FocusStyle.TextBackColor = System.Drawing.Color.DarkSeaGreen;
            this.btn_Quitar.StateStyles.FocusStyle.TextFont = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Quitar.StateStyles.FocusStyle.TextForeColor = System.Drawing.Color.WhiteSmoke;
            this.btn_Quitar.StateStyles.HoverStyle.BackgroundGradientEndColor = System.Drawing.Color.Transparent;
            this.btn_Quitar.StateStyles.HoverStyle.BackgroundGradientStartColor = System.Drawing.Color.Transparent;
            this.btn_Quitar.StateStyles.HoverStyle.BackgroundImageFilterColor = System.Drawing.Color.White;
            this.btn_Quitar.StateStyles.HoverStyle.BackgroundSolidColor = System.Drawing.Color.DarkGray;
            this.btn_Quitar.StateStyles.HoverStyle.BorderSolidColor = System.Drawing.Color.DarkGray;
            this.btn_Quitar.StateStyles.HoverStyle.TextFont = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Quitar.StateStyles.HoverStyle.TextForeColor = System.Drawing.Color.WhiteSmoke;
            this.btn_Quitar.StateStyles.PressedStyle.BackgroundSolidColor = System.Drawing.Color.DarkSeaGreen;
            this.btn_Quitar.StateStyles.PressedStyle.BorderSolidColor = System.Drawing.Color.WhiteSmoke;
            this.btn_Quitar.StateStyles.PressedStyle.TextFont = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Quitar.TabIndex = 752;
            this.btn_Quitar.TextStyle.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btn_Quitar.TextStyle.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Quitar.TextStyle.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btn_Quitar.TextStyle.Text = "Quitar Fila";
            this.btn_Quitar.TextStyle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn_Quitar.TransparentStyle.BackColor = System.Drawing.Color.Empty;
            this.btn_Quitar.VisualStyle = Klik.Windows.Forms.v1.EntryLib.ButtonVisualStyles.Custom;
            this.btn_Quitar.Click += new System.EventHandler(this.btn_Quitar_Click);
            // 
            // btn_CargarArchivo
            // 
            this.btn_CargarArchivo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btn_CargarArchivo.BackgroundStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.btn_CargarArchivo.BackgroundStyle.SolidColor = System.Drawing.Color.WhiteSmoke;
            this.btn_CargarArchivo.BorderStyle.BorderShape.BottomLeft = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.btn_CargarArchivo.BorderStyle.BorderShape.BottomRight = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.btn_CargarArchivo.BorderStyle.BorderShape.TopLeft = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.btn_CargarArchivo.BorderStyle.BorderShape.TopRight = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.btn_CargarArchivo.BorderStyle.EdgeRadius = 7;
            this.btn_CargarArchivo.BorderStyle.SmoothingMode = Klik.Windows.Forms.v1.Common.SmoothingModes.AntiAlias;
            this.btn_CargarArchivo.BorderStyle.SolidColor = System.Drawing.Color.DarkSeaGreen;
            this.btn_CargarArchivo.FlashStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.btn_CargarArchivo.FlashStyle.SolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(240)))), ((int)(((byte)(191)))));
            this.btn_CargarArchivo.ForegroundImageStyle.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn_CargarArchivo.Location = new System.Drawing.Point(406, 252);
            this.btn_CargarArchivo.Name = "btn_CargarArchivo";
            this.btn_CargarArchivo.Office2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ClassicSilver;
            this.btn_CargarArchivo.Size = new System.Drawing.Size(129, 31);
            this.btn_CargarArchivo.StateStyles.HoverStyle.BackgroundSolidColor = System.Drawing.Color.DarkGray;
            this.btn_CargarArchivo.StateStyles.HoverStyle.BorderSolidColor = System.Drawing.Color.DarkGray;
            this.btn_CargarArchivo.StateStyles.HoverStyle.TextFont = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_CargarArchivo.StateStyles.HoverStyle.TextForeColor = System.Drawing.Color.White;
            this.btn_CargarArchivo.StateStyles.PressedStyle.BackgroundSolidColor = System.Drawing.Color.DarkSeaGreen;
            this.btn_CargarArchivo.StateStyles.PressedStyle.BorderSolidColor = System.Drawing.Color.DarkSeaGreen;
            this.btn_CargarArchivo.StateStyles.PressedStyle.TextFont = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_CargarArchivo.StateStyles.PressedStyle.TextForeColor = System.Drawing.Color.White;
            this.btn_CargarArchivo.TabIndex = 751;
            this.btn_CargarArchivo.TextStyle.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_CargarArchivo.TextStyle.ForeColor = System.Drawing.Color.DarkSeaGreen;
            this.btn_CargarArchivo.TextStyle.Text = "Cargar File";
            this.btn_CargarArchivo.TextStyle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn_CargarArchivo.VisualStyle = Klik.Windows.Forms.v1.EntryLib.ButtonVisualStyles.Custom;
            this.btn_CargarArchivo.Click += new System.EventHandler(this.btn_CargarArchivo_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.DimGray;
            this.label4.Location = new System.Drawing.Point(25, 235);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 16);
            this.label4.TabIndex = 753;
            this.label4.Text = "N° Fila";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.DimGray;
            this.label5.Location = new System.Drawing.Point(25, 260);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(107, 16);
            this.label5.TabIndex = 754;
            this.label5.Text = "N° Guardados";
            // 
            // lbl_fila
            // 
            this.lbl_fila.AutoSize = true;
            this.lbl_fila.BackColor = System.Drawing.Color.Transparent;
            this.lbl_fila.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_fila.ForeColor = System.Drawing.Color.DimGray;
            this.lbl_fila.Location = new System.Drawing.Point(141, 235);
            this.lbl_fila.Name = "lbl_fila";
            this.lbl_fila.Size = new System.Drawing.Size(26, 16);
            this.lbl_fila.TabIndex = 755;
            this.lbl_fila.Text = "00";
            // 
            // lbl_Guardado
            // 
            this.lbl_Guardado.AutoSize = true;
            this.lbl_Guardado.BackColor = System.Drawing.Color.Transparent;
            this.lbl_Guardado.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Guardado.ForeColor = System.Drawing.Color.DimGray;
            this.lbl_Guardado.Location = new System.Drawing.Point(141, 260);
            this.lbl_Guardado.Name = "lbl_Guardado";
            this.lbl_Guardado.Size = new System.Drawing.Size(26, 16);
            this.lbl_Guardado.TabIndex = 756;
            this.lbl_Guardado.Text = "00";
            // 
            // btn_cancelar
            // 
            this.btn_cancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_cancelar.BackgroundStyle.GradientAngle = 0F;
            this.btn_cancelar.BackgroundStyle.GradientEndColor = System.Drawing.Color.OrangeRed;
            this.btn_cancelar.BackgroundStyle.GradientStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btn_cancelar.BackgroundStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.btn_cancelar.BackgroundStyle.SolidColor = System.Drawing.Color.WhiteSmoke;
            this.btn_cancelar.BorderStyle.SolidColor = System.Drawing.Color.Gainsboro;
            this.btn_cancelar.DropDownArrowColor = System.Drawing.Color.White;
            this.btn_cancelar.EnableThemes = false;
            this.btn_cancelar.FlashStyle.GradientEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btn_cancelar.FlashStyle.GradientStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btn_cancelar.FlashStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.btn_cancelar.FlashStyle.SolidColor = System.Drawing.Color.OrangeRed;
            this.btn_cancelar.ForegroundImageStyle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_cancelar.Location = new System.Drawing.Point(446, 627);
            this.btn_cancelar.Name = "btn_cancelar";
            this.btn_cancelar.Size = new System.Drawing.Size(121, 37);
            this.btn_cancelar.StateStyles.HoverStyle.BackgroundGradientEndColor = System.Drawing.Color.Gainsboro;
            this.btn_cancelar.StateStyles.HoverStyle.BackgroundGradientStartColor = System.Drawing.Color.Gainsboro;
            this.btn_cancelar.StateStyles.HoverStyle.BackgroundSolidColor = System.Drawing.Color.Gainsboro;
            this.btn_cancelar.StateStyles.HoverStyle.BorderSolidColor = System.Drawing.Color.Gainsboro;
            this.btn_cancelar.TabIndex = 758;
            this.btn_cancelar.TextStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btn_cancelar.TextStyle.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_cancelar.TextStyle.ForeColor = System.Drawing.Color.SlateGray;
            this.btn_cancelar.TextStyle.Text = "Salir";
            this.btn_cancelar.TextStyle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn_cancelar.VisualStyle = Klik.Windows.Forms.v1.EntryLib.ButtonVisualStyles.Custom;
            this.btn_cancelar.Click += new System.EventHandler(this.btn_cancelar_Click);
            // 
            // btn_aceptar
            // 
            this.btn_aceptar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_aceptar.BackgroundStyle.GradientAngle = 0F;
            this.btn_aceptar.BackgroundStyle.GradientEndColor = System.Drawing.Color.OrangeRed;
            this.btn_aceptar.BackgroundStyle.GradientStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btn_aceptar.BackgroundStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.btn_aceptar.BackgroundStyle.SolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btn_aceptar.BorderStyle.SolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btn_aceptar.DropDownArrowColor = System.Drawing.Color.White;
            this.btn_aceptar.EnableThemes = false;
            this.btn_aceptar.FlashStyle.GradientEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btn_aceptar.FlashStyle.GradientStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btn_aceptar.FlashStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.btn_aceptar.FlashStyle.SolidColor = System.Drawing.Color.OrangeRed;
            this.btn_aceptar.ForegroundImageStyle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_aceptar.Location = new System.Drawing.Point(573, 627);
            this.btn_aceptar.Name = "btn_aceptar";
            this.btn_aceptar.Size = new System.Drawing.Size(106, 37);
            this.btn_aceptar.StateStyles.HoverStyle.BackgroundGradientEndColor = System.Drawing.Color.YellowGreen;
            this.btn_aceptar.StateStyles.HoverStyle.BackgroundGradientStartColor = System.Drawing.Color.YellowGreen;
            this.btn_aceptar.StateStyles.HoverStyle.BackgroundSolidColor = System.Drawing.Color.YellowGreen;
            this.btn_aceptar.StateStyles.HoverStyle.BorderSolidColor = System.Drawing.Color.YellowGreen;
            this.btn_aceptar.TabIndex = 757;
            this.btn_aceptar.TextStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btn_aceptar.TextStyle.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_aceptar.TextStyle.ForeColor = System.Drawing.Color.White;
            this.btn_aceptar.TextStyle.Text = "Guardar";
            this.btn_aceptar.TextStyle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn_aceptar.VisualStyle = Klik.Windows.Forms.v1.EntryLib.ButtonVisualStyles.Custom;
            this.btn_aceptar.Click += new System.EventHandler(this.btn_aceptar_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Honeydew;
            this.label6.Location = new System.Drawing.Point(51, 318);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(88, 16);
            this.label6.TabIndex = 759;
            this.label6.Text = "Nom. Prod.";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Honeydew;
            this.label7.Location = new System.Drawing.Point(147, 318);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(92, 16);
            this.label7.TabIndex = 760;
            this.label7.Text = "S/. Compra";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Honeydew;
            this.label8.Location = new System.Drawing.Point(245, 318);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(78, 16);
            this.label8.TabIndex = 761;
            this.label8.Text = "S/. Venta";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Honeydew;
            this.label9.Location = new System.Drawing.Point(353, 318);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(48, 16);
            this.label9.TabIndex = 762;
            this.label9.Text = "Stock";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label10.Location = new System.Drawing.Point(3, 51);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(293, 18);
            this.label10.TabIndex = 21;
            this.label10.Text = "El archivo debe tener una cabecera";
            // 
            // Frm_Exptar_Producto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(691, 676);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btn_cancelar);
            this.Controls.Add(this.btn_aceptar);
            this.Controls.Add(this.lbl_Guardado);
            this.Controls.Add(this.lbl_fila);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btn_Quitar);
            this.Controls.Add(this.btn_CargarArchivo);
            this.Controls.Add(this.txt_nomLibro);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txt_ruta);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Dgv_Datos);
            this.Controls.Add(this.pnl_titu);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Frm_Exptar_Producto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form2";
            this.TransparencyKey = System.Drawing.Color.Black;
            ((System.ComponentModel.ISupportInitialize)(this.kFormManager1)).EndInit();
            this.pnl_titu.ResumeLayout(false);
            this.pnl_titu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv_Datos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_ruta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_nomLibro)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_Quitar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_CargarArchivo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_cancelar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_aceptar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private Klik.Windows.Forms.v1.Common.KFormManager kFormManager1;
        private System.Windows.Forms.Panel pnl_titu;
        private System.Windows.Forms.Button btn_cerrar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        internal Klik.Windows.Forms.v1.EntryLib.ELEntryBox txt_ruta;
        internal Klik.Windows.Forms.v1.EntryLib.ELEntryBox txt_nomLibro;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbl_Guardado;
        private System.Windows.Forms.Label lbl_fila;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private Klik.Windows.Forms.v1.EntryLib.ELButton btn_Quitar;
        private Klik.Windows.Forms.v1.EntryLib.ELButton btn_CargarArchivo;
        internal Klik.Windows.Forms.v1.EntryLib.ELButton btn_cancelar;
        internal Klik.Windows.Forms.v1.EntryLib.ELButton btn_aceptar;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.DataGridView Dgv_Datos;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label10;
    }
}