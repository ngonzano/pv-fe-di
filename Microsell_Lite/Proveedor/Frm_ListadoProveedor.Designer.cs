
namespace Microsell_Lite.Proveedor
{
    partial class Frm_ListadoProveedor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_ListadoProveedor));
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.lsv_Proveedor = new System.Windows.Forms.ListView();
            this.pnl_titu = new System.Windows.Forms.Panel();
            this.btn_cerrar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbl_nomb = new System.Windows.Forms.Label();
            this.lbl_id = new System.Windows.Forms.Label();
            this.Pb_Agregar2 = new FontAwesome.Sharp.IconButton();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.pnl_titu.SuspendLayout();
            this.SuspendLayout();
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 25;
            this.bunifuElipse1.TargetControl = this;
            // 
            // lsv_Proveedor
            // 
            this.lsv_Proveedor.Font = new System.Drawing.Font("Calibri Light", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lsv_Proveedor.ForeColor = System.Drawing.Color.DimGray;
            this.lsv_Proveedor.HideSelection = false;
            this.lsv_Proveedor.Location = new System.Drawing.Point(1, 87);
            this.lsv_Proveedor.Name = "lsv_Proveedor";
            this.lsv_Proveedor.Size = new System.Drawing.Size(457, 256);
            this.lsv_Proveedor.TabIndex = 5;
            this.lsv_Proveedor.UseCompatibleStateImageBehavior = false;
            this.lsv_Proveedor.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lsv_Proveedor_KeyDown);
            this.lsv_Proveedor.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lsv_Proveedor_MouseDoubleClick);
            // 
            // pnl_titu
            // 
            this.pnl_titu.BackColor = System.Drawing.Color.DimGray;
            this.pnl_titu.Controls.Add(this.btn_cerrar);
            this.pnl_titu.Controls.Add(this.label1);
            this.pnl_titu.Location = new System.Drawing.Point(1, 2);
            this.pnl_titu.Name = "pnl_titu";
            this.pnl_titu.Size = new System.Drawing.Size(457, 41);
            this.pnl_titu.TabIndex = 4;
            this.pnl_titu.Paint += new System.Windows.Forms.PaintEventHandler(this.pnl_titu_Paint);
            this.pnl_titu.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnl_titu_MouseMove);
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
            this.btn_cerrar.Location = new System.Drawing.Point(412, 6);
            this.btn_cerrar.Name = "btn_cerrar";
            this.btn_cerrar.Size = new System.Drawing.Size(30, 30);
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
            this.label1.Location = new System.Drawing.Point(11, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(200, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Listado de Proveedores";
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.DimGray;
            this.label2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label2.ForeColor = System.Drawing.Color.DarkSeaGreen;
            this.label2.Location = new System.Drawing.Point(0, 346);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(460, 8);
            this.label2.TabIndex = 6;
            // 
            // lbl_nomb
            // 
            this.lbl_nomb.AutoSize = true;
            this.lbl_nomb.Location = new System.Drawing.Point(263, 171);
            this.lbl_nomb.Name = "lbl_nomb";
            this.lbl_nomb.Size = new System.Drawing.Size(10, 13);
            this.lbl_nomb.TabIndex = 8;
            this.lbl_nomb.Text = "-";
            this.lbl_nomb.Visible = false;
            // 
            // lbl_id
            // 
            this.lbl_id.AutoSize = true;
            this.lbl_id.Location = new System.Drawing.Point(188, 171);
            this.lbl_id.Name = "lbl_id";
            this.lbl_id.Size = new System.Drawing.Size(10, 13);
            this.lbl_id.TabIndex = 7;
            this.lbl_id.Text = "-";
            this.lbl_id.Visible = false;
            // 
            // Pb_Agregar2
            // 
            this.Pb_Agregar2.BackColor = System.Drawing.Color.DarkGray;
            this.Pb_Agregar2.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.Pb_Agregar2.FlatAppearance.BorderSize = 0;
            this.Pb_Agregar2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DeepSkyBlue;
            this.Pb_Agregar2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(205)))), ((int)(((byte)(117)))));
            this.Pb_Agregar2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Pb_Agregar2.Font = new System.Drawing.Font("Verdana", 9.75F);
            this.Pb_Agregar2.ForeColor = System.Drawing.Color.DimGray;
            this.Pb_Agregar2.IconChar = FontAwesome.Sharp.IconChar.UserPlus;
            this.Pb_Agregar2.IconColor = System.Drawing.Color.WhiteSmoke;
            this.Pb_Agregar2.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.Pb_Agregar2.IconSize = 30;
            this.Pb_Agregar2.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.Pb_Agregar2.Location = new System.Drawing.Point(3, 49);
            this.Pb_Agregar2.Name = "Pb_Agregar2";
            this.Pb_Agregar2.Size = new System.Drawing.Size(37, 32);
            this.Pb_Agregar2.TabIndex = 28;
            this.toolTip1.SetToolTip(this.Pb_Agregar2, "Agregar Proveedor");
            this.Pb_Agregar2.UseVisualStyleBackColor = false;
            this.Pb_Agregar2.Click += new System.EventHandler(this.Pb_Agregar2_Click);
            // 
            // Frm_ListadoProveedor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(460, 354);
            this.Controls.Add(this.Pb_Agregar2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lsv_Proveedor);
            this.Controls.Add(this.pnl_titu);
            this.Controls.Add(this.lbl_nomb);
            this.Controls.Add(this.lbl_id);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Frm_ListadoProveedor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Frm_ListadoProveedor";
            this.Load += new System.EventHandler(this.Frm_ListadoProveedor_Load);
            this.pnl_titu.ResumeLayout(false);
            this.pnl_titu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListView lsv_Proveedor;
        private System.Windows.Forms.Panel pnl_titu;
        private System.Windows.Forms.Button btn_cerrar;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label lbl_nomb;
        public System.Windows.Forms.Label lbl_id;
        private FontAwesome.Sharp.IconButton Pb_Agregar2;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}