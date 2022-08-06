namespace Microsell_Lite.NotaCredito
{
    partial class Frm_add_motivo_Nc
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_add_motivo_Nc));
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.bunifuDragControl1 = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.pnl_titu = new System.Windows.Forms.Panel();
            this.btn_cerrar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_motivo = new Guna.UI.WinForms.GunaTextBox();
            this.Label24 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_importe = new Guna.UI.WinForms.GunaTextBox();
            this.btn_comprobar = new Klik.Windows.Forms.v1.EntryLib.ELButton();
            this.pnl_titu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btn_comprobar)).BeginInit();
            this.SuspendLayout();
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 10;
            this.bunifuElipse1.TargetControl = this;
            // 
            // bunifuDragControl1
            // 
            this.bunifuDragControl1.Fixed = true;
            this.bunifuDragControl1.Horizontal = true;
            this.bunifuDragControl1.TargetControl = this.pnl_titu;
            this.bunifuDragControl1.Vertical = true;
            // 
            // pnl_titu
            // 
            this.pnl_titu.BackColor = System.Drawing.Color.DimGray;
            this.pnl_titu.Controls.Add(this.btn_cerrar);
            this.pnl_titu.Controls.Add(this.label1);
            this.pnl_titu.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_titu.Location = new System.Drawing.Point(0, 0);
            this.pnl_titu.Margin = new System.Windows.Forms.Padding(4);
            this.pnl_titu.Name = "pnl_titu";
            this.pnl_titu.Size = new System.Drawing.Size(406, 51);
            this.pnl_titu.TabIndex = 3;
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
            this.btn_cerrar.Location = new System.Drawing.Point(364, 9);
            this.btn_cerrar.Margin = new System.Windows.Forms.Padding(4);
            this.btn_cerrar.Name = "btn_cerrar";
            this.btn_cerrar.Size = new System.Drawing.Size(31, 30);
            this.btn_cerrar.TabIndex = 6;
            this.btn_cerrar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_cerrar.UseVisualStyleBackColor = true;
            this.btn_cerrar.Click += new System.EventHandler(this.btn_cerrar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label1.Location = new System.Drawing.Point(11, 15);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(253, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Agregar Motivo de Nota de Credito";
            // 
            // txt_motivo
            // 
            this.txt_motivo.BackColor = System.Drawing.Color.Transparent;
            this.txt_motivo.BaseColor = System.Drawing.Color.White;
            this.txt_motivo.BorderColor = System.Drawing.Color.Silver;
            this.txt_motivo.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_motivo.FocusedBaseColor = System.Drawing.Color.White;
            this.txt_motivo.FocusedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(151)))), ((int)(((byte)(191)))));
            this.txt_motivo.FocusedForeColor = System.Drawing.SystemColors.ControlText;
            this.txt_motivo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txt_motivo.Location = new System.Drawing.Point(12, 95);
            this.txt_motivo.Name = "txt_motivo";
            this.txt_motivo.PasswordChar = '\0';
            this.txt_motivo.Radius = 5;
            this.txt_motivo.Size = new System.Drawing.Size(340, 30);
            this.txt_motivo.TabIndex = 1;
            // 
            // Label24
            // 
            this.Label24.AutoSize = true;
            this.Label24.BackColor = System.Drawing.Color.Transparent;
            this.Label24.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label24.ForeColor = System.Drawing.Color.Black;
            this.Label24.Location = new System.Drawing.Point(11, 72);
            this.Label24.Name = "Label24";
            this.Label24.Size = new System.Drawing.Size(125, 20);
            this.Label24.TabIndex = 735;
            this.Label24.Text = "Ingrese Motivo:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(14, 134);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 20);
            this.label2.TabIndex = 737;
            this.label2.Text = "Importe";
            // 
            // txt_importe
            // 
            this.txt_importe.BackColor = System.Drawing.Color.Transparent;
            this.txt_importe.BaseColor = System.Drawing.Color.White;
            this.txt_importe.BorderColor = System.Drawing.Color.Silver;
            this.txt_importe.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_importe.FocusedBaseColor = System.Drawing.Color.White;
            this.txt_importe.FocusedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(151)))), ((int)(((byte)(191)))));
            this.txt_importe.FocusedForeColor = System.Drawing.SystemColors.ControlText;
            this.txt_importe.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txt_importe.Location = new System.Drawing.Point(15, 157);
            this.txt_importe.Name = "txt_importe";
            this.txt_importe.PasswordChar = '\0';
            this.txt_importe.Radius = 5;
            this.txt_importe.Size = new System.Drawing.Size(110, 30);
            this.txt_importe.TabIndex = 2;
            // 
            // btn_comprobar
            // 
            this.btn_comprobar.BackgroundStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.btn_comprobar.BackgroundStyle.SolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(151)))), ((int)(((byte)(191)))));
            this.btn_comprobar.BorderStyle.BorderShape.BottomLeft = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.btn_comprobar.BorderStyle.BorderShape.BottomRight = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.btn_comprobar.BorderStyle.BorderShape.TopLeft = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.btn_comprobar.BorderStyle.BorderShape.TopRight = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.btn_comprobar.BorderStyle.EdgeRadius = 7;
            this.btn_comprobar.BorderStyle.SmoothingMode = Klik.Windows.Forms.v1.Common.SmoothingModes.AntiAlias;
            this.btn_comprobar.BorderStyle.SolidColor = System.Drawing.Color.Gainsboro;
            this.btn_comprobar.Cursor = System.Windows.Forms.Cursors.Default;
            this.btn_comprobar.DropDownArrowColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.btn_comprobar.FlashStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.btn_comprobar.FlashStyle.SolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(240)))), ((int)(((byte)(191)))));
            this.btn_comprobar.ForegroundImageStyle.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn_comprobar.Location = new System.Drawing.Point(135, 199);
            this.btn_comprobar.Margin = new System.Windows.Forms.Padding(4);
            this.btn_comprobar.Name = "btn_comprobar";
            this.btn_comprobar.Office2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ModernBlack;
            this.btn_comprobar.Size = new System.Drawing.Size(129, 44);
            this.btn_comprobar.StateStyles.HoverStyle.BackgroundSolidColor = System.Drawing.Color.YellowGreen;
            this.btn_comprobar.StateStyles.HoverStyle.BorderSolidColor = System.Drawing.Color.YellowGreen;
            this.btn_comprobar.TabIndex = 738;
            this.btn_comprobar.TextStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_comprobar.TextStyle.ForeColor = System.Drawing.Color.White;
            this.btn_comprobar.TextStyle.Text = "Aceptar";
            this.btn_comprobar.TextStyle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn_comprobar.VisualStyle = Klik.Windows.Forms.v1.EntryLib.ButtonVisualStyles.Custom;
            this.btn_comprobar.Click += new System.EventHandler(this.btn_comprobar_Click);
            // 
            // Frm_add_motivo_Nc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(406, 256);
            this.Controls.Add(this.btn_comprobar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_importe);
            this.Controls.Add(this.Label24);
            this.Controls.Add(this.txt_motivo);
            this.Controls.Add(this.pnl_titu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Frm_add_motivo_Nc";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Motivo de Nota de credito";
            this.pnl_titu.ResumeLayout(false);
            this.pnl_titu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btn_comprobar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private Bunifu.Framework.UI.BunifuDragControl bunifuDragControl1;
        private System.Windows.Forms.Panel pnl_titu;
        private System.Windows.Forms.Button btn_cerrar;
        private System.Windows.Forms.Label label1;
        internal System.Windows.Forms.Label label2;
        internal System.Windows.Forms.Label Label24;
        private Klik.Windows.Forms.v1.EntryLib.ELButton btn_comprobar;
        internal Guna.UI.WinForms.GunaTextBox txt_motivo;
        internal Guna.UI.WinForms.GunaTextBox txt_importe;
    }
}