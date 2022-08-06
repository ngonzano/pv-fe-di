
namespace Microsell_Lite.Utilitarios
{
    partial class Frm_EditTipoCambio
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_EditTipoCambio));
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.ElDivider3 = new Klik.Windows.Forms.v1.EntryLib.ELDivider();
            this.Label17 = new System.Windows.Forms.Label();
            this.pnl_subtitu = new System.Windows.Forms.Panel();
            this.btn_cerrar = new System.Windows.Forms.Button();
            this.elDivider2 = new Klik.Windows.Forms.v1.EntryLib.ELDivider();
            this.label3 = new System.Windows.Forms.Label();
            this.elDivider1 = new Klik.Windows.Forms.v1.EntryLib.ELDivider();
            this.btn_cancel = new Klik.Windows.Forms.v1.EntryLib.ELButton();
            this.label11 = new System.Windows.Forms.Label();
            this.txt_TiCambio = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.btn_listo = new Klik.Windows.Forms.v1.EntryLib.ELButton();
            this.grb_Documento = new System.Windows.Forms.GroupBox();
            this.lbl_tipoCambio = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ElDivider3)).BeginInit();
            this.pnl_subtitu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.elDivider2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.elDivider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_cancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_listo)).BeginInit();
            this.grb_Documento.SuspendLayout();
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
            this.ElDivider3.Location = new System.Drawing.Point(-49, 27);
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
            this.Label17.Location = new System.Drawing.Point(50, 3);
            this.Label17.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label17.Name = "Label17";
            this.Label17.Size = new System.Drawing.Size(222, 32);
            this.Label17.TabIndex = 405;
            this.Label17.Text = "Editar Tipo Cambio";
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
            this.pnl_subtitu.Size = new System.Drawing.Size(326, 40);
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
            this.btn_cerrar.Location = new System.Drawing.Point(283, 1);
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
            this.elDivider2.Location = new System.Drawing.Point(-44, -7);
            this.elDivider2.Margin = new System.Windows.Forms.Padding(4);
            this.elDivider2.Name = "elDivider2";
            this.elDivider2.Size = new System.Drawing.Size(407, 19);
            this.elDivider2.TabIndex = 409;
            this.elDivider2.VisualStyle = Klik.Windows.Forms.v1.Common.ControlVisualStyles.Custom;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DimGray;
            this.label3.Location = new System.Drawing.Point(27, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 16);
            this.label3.TabIndex = 735;
            this.label3.Text = "Antes";
            // 
            // elDivider1
            // 
            this.elDivider1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.elDivider1.FadeStyle = Klik.Windows.Forms.v1.EntryLib.DividerFadeStyles.Center;
            this.elDivider1.LineColor = System.Drawing.Color.DarkSeaGreen;
            this.elDivider1.LineSize = 3;
            this.elDivider1.Location = new System.Drawing.Point(0, 219);
            this.elDivider1.Margin = new System.Windows.Forms.Padding(4);
            this.elDivider1.Name = "elDivider1";
            this.elDivider1.Size = new System.Drawing.Size(326, 10);
            this.elDivider1.TabIndex = 739;
            this.elDivider1.VisualStyle = Klik.Windows.Forms.v1.Common.ControlVisualStyles.Custom;
            // 
            // btn_cancel
            // 
            this.btn_cancel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btn_cancel.BackgroundStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.btn_cancel.BackgroundStyle.SolidColor = System.Drawing.Color.WhiteSmoke;
            this.btn_cancel.BorderStyle.BorderShape.BottomLeft = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.btn_cancel.BorderStyle.BorderShape.BottomRight = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.btn_cancel.BorderStyle.BorderShape.TopLeft = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.btn_cancel.BorderStyle.BorderShape.TopRight = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.btn_cancel.BorderStyle.EdgeRadius = 7;
            this.btn_cancel.BorderStyle.SmoothingMode = Klik.Windows.Forms.v1.Common.SmoothingModes.AntiAlias;
            this.btn_cancel.BorderStyle.SolidColor = System.Drawing.Color.DarkSeaGreen;
            this.btn_cancel.FlashStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.btn_cancel.FlashStyle.SolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(240)))), ((int)(((byte)(191)))));
            this.btn_cancel.ForegroundImageStyle.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn_cancel.Location = new System.Drawing.Point(26, 160);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Office2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ClassicSilver;
            this.btn_cancel.Size = new System.Drawing.Size(125, 40);
            this.btn_cancel.StateStyles.HoverStyle.BackgroundSolidColor = System.Drawing.Color.DarkGray;
            this.btn_cancel.StateStyles.HoverStyle.BorderSolidColor = System.Drawing.Color.DarkGray;
            this.btn_cancel.StateStyles.HoverStyle.TextFont = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_cancel.StateStyles.HoverStyle.TextForeColor = System.Drawing.Color.White;
            this.btn_cancel.StateStyles.PressedStyle.BackgroundSolidColor = System.Drawing.Color.DarkSeaGreen;
            this.btn_cancel.StateStyles.PressedStyle.BorderSolidColor = System.Drawing.Color.DarkSeaGreen;
            this.btn_cancel.StateStyles.PressedStyle.TextFont = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_cancel.StateStyles.PressedStyle.TextForeColor = System.Drawing.Color.White;
            this.btn_cancel.TabIndex = 738;
            this.btn_cancel.TextStyle.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_cancel.TextStyle.ForeColor = System.Drawing.Color.DarkSeaGreen;
            this.btn_cancel.TextStyle.Text = "Cancelar";
            this.btn_cancel.TextStyle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn_cancel.VisualStyle = Klik.Windows.Forms.v1.EntryLib.ButtonVisualStyles.Custom;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // label11
            // 
            this.label11.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label11.Image = ((System.Drawing.Image)(resources.GetObject("label11.Image")));
            this.label11.Location = new System.Drawing.Point(121, 51);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(26, 26);
            this.label11.TabIndex = 742;
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txt_TiCambio
            // 
            this.txt_TiCambio.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txt_TiCambio.Depth = 0;
            this.txt_TiCambio.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_TiCambio.Hint = "";
            this.txt_TiCambio.Location = new System.Drawing.Point(154, 54);
            this.txt_TiCambio.MouseState = MaterialSkin.MouseState.HOVER;
            this.txt_TiCambio.Name = "txt_TiCambio";
            this.txt_TiCambio.PasswordChar = '\0';
            this.txt_TiCambio.SelectedText = "";
            this.txt_TiCambio.SelectionLength = 0;
            this.txt_TiCambio.SelectionStart = 0;
            this.txt_TiCambio.Size = new System.Drawing.Size(59, 23);
            this.txt_TiCambio.TabIndex = 740;
            this.txt_TiCambio.Text = "0";
            this.txt_TiCambio.UseSystemPasswordChar = false;
            this.txt_TiCambio.Enter += new System.EventHandler(this.txt_TiCambio_Enter);
            this.txt_TiCambio.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_TiCambio_KeyPress);
            this.txt_TiCambio.Leave += new System.EventHandler(this.txt_TiCambio_Leave);
            // 
            // btn_listo
            // 
            this.btn_listo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btn_listo.BackgroundStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.btn_listo.BackgroundStyle.SolidColor = System.Drawing.Color.DarkSeaGreen;
            this.btn_listo.BorderStyle.BorderShape.BottomLeft = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.btn_listo.BorderStyle.BorderShape.BottomRight = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.btn_listo.BorderStyle.BorderShape.TopLeft = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.btn_listo.BorderStyle.BorderShape.TopRight = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.btn_listo.BorderStyle.EdgeRadius = 7;
            this.btn_listo.BorderStyle.SmoothingMode = Klik.Windows.Forms.v1.Common.SmoothingModes.AntiAlias;
            this.btn_listo.BorderStyle.SolidColor = System.Drawing.Color.DarkSeaGreen;
            this.btn_listo.DropDownArrowColor = System.Drawing.Color.Black;
            this.btn_listo.FlashStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.btn_listo.FlashStyle.SolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(240)))), ((int)(((byte)(191)))));
            this.btn_listo.ForegroundImageStyle.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn_listo.Location = new System.Drawing.Point(176, 160);
            this.btn_listo.Name = "btn_listo";
            this.btn_listo.Office2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ClassicSilver;
            this.btn_listo.Size = new System.Drawing.Size(123, 40);
            this.btn_listo.StateStyles.DisabledStyle.TextFont = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_listo.StateStyles.DisabledStyle.TextForeColor = System.Drawing.Color.DarkSeaGreen;
            this.btn_listo.StateStyles.FocusStyle.BackgroundSolidColor = System.Drawing.Color.DarkSeaGreen;
            this.btn_listo.StateStyles.FocusStyle.TextBackColor = System.Drawing.Color.DarkSeaGreen;
            this.btn_listo.StateStyles.FocusStyle.TextFont = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_listo.StateStyles.FocusStyle.TextForeColor = System.Drawing.Color.WhiteSmoke;
            this.btn_listo.StateStyles.HoverStyle.BackgroundGradientEndColor = System.Drawing.Color.Transparent;
            this.btn_listo.StateStyles.HoverStyle.BackgroundGradientStartColor = System.Drawing.Color.Transparent;
            this.btn_listo.StateStyles.HoverStyle.BackgroundImageFilterColor = System.Drawing.Color.White;
            this.btn_listo.StateStyles.HoverStyle.BackgroundSolidColor = System.Drawing.Color.DarkGray;
            this.btn_listo.StateStyles.HoverStyle.BorderSolidColor = System.Drawing.Color.DarkGray;
            this.btn_listo.StateStyles.HoverStyle.TextFont = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_listo.StateStyles.HoverStyle.TextForeColor = System.Drawing.Color.WhiteSmoke;
            this.btn_listo.StateStyles.PressedStyle.BackgroundSolidColor = System.Drawing.Color.DarkSeaGreen;
            this.btn_listo.StateStyles.PressedStyle.BorderSolidColor = System.Drawing.Color.WhiteSmoke;
            this.btn_listo.StateStyles.PressedStyle.TextFont = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_listo.TabIndex = 746;
            this.btn_listo.TextStyle.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btn_listo.TextStyle.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_listo.TextStyle.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btn_listo.TextStyle.Text = "Actualizar";
            this.btn_listo.TextStyle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn_listo.TransparentStyle.BackColor = System.Drawing.Color.Empty;
            this.btn_listo.VisualStyle = Klik.Windows.Forms.v1.EntryLib.ButtonVisualStyles.Custom;
            this.btn_listo.Click += new System.EventHandler(this.btn_listo_Click);
            // 
            // grb_Documento
            // 
            this.grb_Documento.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.grb_Documento.Controls.Add(this.label1);
            this.grb_Documento.Controls.Add(this.lbl_tipoCambio);
            this.grb_Documento.Controls.Add(this.label3);
            this.grb_Documento.Controls.Add(this.label11);
            this.grb_Documento.Controls.Add(this.txt_TiCambio);
            this.grb_Documento.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grb_Documento.ForeColor = System.Drawing.Color.DimGray;
            this.grb_Documento.Location = new System.Drawing.Point(26, 53);
            this.grb_Documento.Name = "grb_Documento";
            this.grb_Documento.Size = new System.Drawing.Size(273, 95);
            this.grb_Documento.TabIndex = 748;
            this.grb_Documento.TabStop = false;
            this.grb_Documento.Text = "Tipo Cambio";
            // 
            // lbl_tipoCambio
            // 
            this.lbl_tipoCambio.AutoSize = true;
            this.lbl_tipoCambio.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_tipoCambio.ForeColor = System.Drawing.Color.DimGray;
            this.lbl_tipoCambio.Location = new System.Drawing.Point(27, 54);
            this.lbl_tipoCambio.Name = "lbl_tipoCambio";
            this.lbl_tipoCambio.Size = new System.Drawing.Size(58, 18);
            this.lbl_tipoCambio.TabIndex = 743;
            this.lbl_tipoCambio.Text = "Antes";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DimGray;
            this.label1.Location = new System.Drawing.Point(126, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 16);
            this.label1.TabIndex = 744;
            this.label1.Text = "Actualizar";
            // 
            // Frm_EditTipoCambio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(326, 229);
            this.Controls.Add(this.btn_listo);
            this.Controls.Add(this.elDivider1);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.pnl_subtitu);
            this.Controls.Add(this.grb_Documento);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Frm_EditTipoCambio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Frm_Correlativo";
            this.Load += new System.EventHandler(this.Frm_Correlativo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ElDivider3)).EndInit();
            this.pnl_subtitu.ResumeLayout(false);
            this.pnl_subtitu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.elDivider2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.elDivider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_cancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_listo)).EndInit();
            this.grb_Documento.ResumeLayout(false);
            this.grb_Documento.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        internal Klik.Windows.Forms.v1.EntryLib.ELDivider ElDivider3;
        internal System.Windows.Forms.Label Label17;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel pnl_subtitu;
        internal Klik.Windows.Forms.v1.EntryLib.ELDivider elDivider1;
        private Klik.Windows.Forms.v1.EntryLib.ELButton btn_cancel;
        private System.Windows.Forms.Label label11;
        private MaterialSkin.Controls.MaterialSingleLineTextField txt_TiCambio;
        private Klik.Windows.Forms.v1.EntryLib.ELButton btn_listo;
        private System.Windows.Forms.GroupBox grb_Documento;
        internal Klik.Windows.Forms.v1.EntryLib.ELDivider elDivider2;
        private System.Windows.Forms.Button btn_cerrar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl_tipoCambio;
    }
}