
namespace Microsell_Lite.Utilitarios
{
    partial class Frm_Nro_FE
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
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.pnl_titu = new System.Windows.Forms.Panel();
            this.txt_nro = new Klik.Windows.Forms.v1.EntryLib.ELEntryBox();
            this.label3 = new System.Windows.Forms.Label();
            this.elDivider1 = new Klik.Windows.Forms.v1.EntryLib.ELDivider();
            this.lbl_tipo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.txt_nro)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.elDivider1)).BeginInit();
            this.SuspendLayout();
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 25;
            this.bunifuElipse1.TargetControl = this;
            // 
            // pnl_titu
            // 
            this.pnl_titu.BackColor = System.Drawing.SystemColors.Control;
            this.pnl_titu.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_titu.Location = new System.Drawing.Point(0, 0);
            this.pnl_titu.Name = "pnl_titu";
            this.pnl_titu.Size = new System.Drawing.Size(330, 26);
            this.pnl_titu.TabIndex = 11;
            // 
            // txt_nro
            // 
            this.txt_nro.CaptionStyle.BorderStyle.BorderType = Klik.Windows.Forms.v1.Common.BorderTypes.None;
            this.txt_nro.CaptionStyle.CaptionSize = 0;
            this.txt_nro.CaptionStyle.FlashStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.txt_nro.CaptionStyle.FlashStyle.SolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(240)))), ((int)(((byte)(191)))));
            this.txt_nro.CaptionStyle.StateStyles.DisabledStyle.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.txt_nro.CaptionStyle.StateStyles.FocusStyle.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.txt_nro.CaptionStyle.StateStyles.HoverStyle.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.txt_nro.CaptionStyle.TextStyle.BackColor = System.Drawing.SystemColors.ControlText;
            this.txt_nro.CaptionStyle.TextStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.txt_nro.CaptionStyle.TextStyle.ForeColor = System.Drawing.SystemColors.Window;
            this.txt_nro.CaptionStyle.TextStyle.Text = "elEntryBox1";
            this.txt_nro.CaptionStyle.TextStyle.TextType = Klik.Windows.Forms.v1.Common.TextTypes.BlockShadow;
            this.txt_nro.EditBoxStyle.BorderStyle.BorderType = Klik.Windows.Forms.v1.Common.BorderTypes.None;
            this.txt_nro.EditBoxStyle.Font = new System.Drawing.Font("Calibri", 16F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.txt_nro.EditBoxStyle.ForeColor = System.Drawing.Color.DimGray;
            this.txt_nro.EditBoxStyle.Office2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ModernSilver;
            this.txt_nro.EditBoxStyle.StateStyles.DisabledStyle.Font = new System.Drawing.Font("Calibri", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.txt_nro.EditBoxStyle.StateStyles.FocusStyle.Font = new System.Drawing.Font("Calibri", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.txt_nro.EditBoxStyle.StateStyles.HoverStyle.Font = new System.Drawing.Font("Calibri", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_nro.EditBoxStyle.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_nro.Location = new System.Drawing.Point(52, 87);
            this.txt_nro.Name = "txt_nro";
            this.txt_nro.Size = new System.Drawing.Size(220, 39);
            this.txt_nro.TabIndex = 1;
            this.txt_nro.ValidationStyle.PasswordChar = '\0';
            this.txt_nro.Value = "";
            this.txt_nro.VisualStyle = Klik.Windows.Forms.v1.Common.ControlVisualStyles.Office2003;
            this.txt_nro.TextChanged += new System.EventHandler(this.txt_Cantidad_TextChanged);
            this.txt_nro.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_Cantidad_KeyDown);
            this.txt_nro.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_Cantidad_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DimGray;
            this.label3.Location = new System.Drawing.Point(18, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(308, 25);
            this.label3.TabIndex = 6;
            this.label3.Text = "Ingresar Factura - Boleta";
            // 
            // elDivider1
            // 
            this.elDivider1.FadeColor = System.Drawing.Color.LawnGreen;
            this.elDivider1.FadeStyle = Klik.Windows.Forms.v1.EntryLib.DividerFadeStyles.Center;
            this.elDivider1.LineColor = System.Drawing.Color.LawnGreen;
            this.elDivider1.Location = new System.Drawing.Point(52, 116);
            this.elDivider1.Name = "elDivider1";
            this.elDivider1.Office2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ClassicSilver;
            this.elDivider1.Size = new System.Drawing.Size(220, 23);
            this.elDivider1.TabIndex = 8;
            // 
            // lbl_tipo
            // 
            this.lbl_tipo.AutoSize = true;
            this.lbl_tipo.Font = new System.Drawing.Font("Calibri Light", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_tipo.ForeColor = System.Drawing.Color.DimGray;
            this.lbl_tipo.Location = new System.Drawing.Point(12, 43);
            this.lbl_tipo.Name = "lbl_tipo";
            this.lbl_tipo.Size = new System.Drawing.Size(0, 19);
            this.lbl_tipo.TabIndex = 13;
            this.lbl_tipo.Visible = false;
            // 
            // Frm_Nro_FE
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(330, 156);
            this.Controls.Add(this.lbl_tipo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txt_nro);
            this.Controls.Add(this.pnl_titu);
            this.Controls.Add(this.elDivider1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "Frm_Nro_FE";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Frm_Solo_Cant";
            this.Load += new System.EventHandler(this.Frm_Solo_Cant_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Frm_Solo_Cant_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.txt_nro)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.elDivider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private System.Windows.Forms.Panel pnl_titu;
        private System.Windows.Forms.Label label3;
        public Klik.Windows.Forms.v1.EntryLib.ELEntryBox txt_nro;
        private Klik.Windows.Forms.v1.EntryLib.ELDivider elDivider1;
        public System.Windows.Forms.Label lbl_tipo;
    }
}