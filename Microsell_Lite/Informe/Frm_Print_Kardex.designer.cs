﻿namespace Microsell_Lite.Informe
{
    partial class Frm_Print_Kardex
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Print_Kardex));
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.pnl_titu = new System.Windows.Forms.Panel();
            this.lbl_ff = new System.Windows.Forms.Label();
            this.lbl_fi = new System.Windows.Forms.Label();
            this.lbl_nroDoc = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_actualizar = new System.Windows.Forms.Button();
            this.btn_export = new System.Windows.Forms.Button();
            this.btn_Print = new System.Windows.Forms.Button();
            this.btn_Cancelar = new System.Windows.Forms.Button();
            this.crv_ImprimirTicket = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.pnl_titu.SuspendLayout();
            this.SuspendLayout();
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 25;
            this.bunifuElipse1.TargetControl = this;
            // 
            // pnl_titu
            // 
            this.pnl_titu.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnl_titu.Controls.Add(this.lbl_ff);
            this.pnl_titu.Controls.Add(this.lbl_fi);
            this.pnl_titu.Controls.Add(this.lbl_nroDoc);
            this.pnl_titu.Controls.Add(this.label1);
            this.pnl_titu.Controls.Add(this.btn_actualizar);
            this.pnl_titu.Controls.Add(this.btn_export);
            this.pnl_titu.Controls.Add(this.btn_Print);
            this.pnl_titu.Controls.Add(this.btn_Cancelar);
            this.pnl_titu.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_titu.Location = new System.Drawing.Point(0, 0);
            this.pnl_titu.Name = "pnl_titu";
            this.pnl_titu.Size = new System.Drawing.Size(1088, 44);
            this.pnl_titu.TabIndex = 0;
            this.pnl_titu.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnl_titu_MouseMove);
            // 
            // lbl_ff
            // 
            this.lbl_ff.AutoSize = true;
            this.lbl_ff.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_ff.ForeColor = System.Drawing.Color.DimGray;
            this.lbl_ff.Location = new System.Drawing.Point(636, 12);
            this.lbl_ff.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_ff.Name = "lbl_ff";
            this.lbl_ff.Size = new System.Drawing.Size(84, 20);
            this.lbl_ff.TabIndex = 513;
            this.lbl_ff.Text = "Fecha fin";
            this.lbl_ff.Visible = false;
            // 
            // lbl_fi
            // 
            this.lbl_fi.AutoSize = true;
            this.lbl_fi.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_fi.ForeColor = System.Drawing.Color.DimGray;
            this.lbl_fi.Location = new System.Drawing.Point(481, 12);
            this.lbl_fi.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_fi.Name = "lbl_fi";
            this.lbl_fi.Size = new System.Drawing.Size(105, 20);
            this.lbl_fi.TabIndex = 512;
            this.lbl_fi.Text = "Fecha inicio";
            this.lbl_fi.Visible = false;
            // 
            // lbl_nroDoc
            // 
            this.lbl_nroDoc.AutoSize = true;
            this.lbl_nroDoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_nroDoc.ForeColor = System.Drawing.Color.DimGray;
            this.lbl_nroDoc.Location = new System.Drawing.Point(123, 10);
            this.lbl_nroDoc.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_nroDoc.Name = "lbl_nroDoc";
            this.lbl_nroDoc.Size = new System.Drawing.Size(118, 20);
            this.lbl_nroDoc.TabIndex = 511;
            this.lbl_nroDoc.Text = "Impresion de ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DimGray;
            this.label1.Location = new System.Drawing.Point(13, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 20);
            this.label1.TabIndex = 510;
            this.label1.Text = "Impresion de ";
            // 
            // btn_actualizar
            // 
            this.btn_actualizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_actualizar.FlatAppearance.BorderSize = 0;
            this.btn_actualizar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SkyBlue;
            this.btn_actualizar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SkyBlue;
            this.btn_actualizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_actualizar.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_actualizar.ForeColor = System.Drawing.Color.White;
            this.btn_actualizar.Image = ((System.Drawing.Image)(resources.GetObject("btn_actualizar.Image")));
            this.btn_actualizar.Location = new System.Drawing.Point(892, 7);
            this.btn_actualizar.Margin = new System.Windows.Forms.Padding(4);
            this.btn_actualizar.Name = "btn_actualizar";
            this.btn_actualizar.Size = new System.Drawing.Size(35, 31);
            this.btn_actualizar.TabIndex = 509;
            this.btn_actualizar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_actualizar.UseVisualStyleBackColor = true;
            this.btn_actualizar.Click += new System.EventHandler(this.btn_actualizar_Click);
            // 
            // btn_export
            // 
            this.btn_export.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_export.FlatAppearance.BorderSize = 0;
            this.btn_export.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SkyBlue;
            this.btn_export.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SkyBlue;
            this.btn_export.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_export.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_export.ForeColor = System.Drawing.Color.White;
            this.btn_export.Image = ((System.Drawing.Image)(resources.GetObject("btn_export.Image")));
            this.btn_export.Location = new System.Drawing.Point(938, 7);
            this.btn_export.Margin = new System.Windows.Forms.Padding(4);
            this.btn_export.Name = "btn_export";
            this.btn_export.Size = new System.Drawing.Size(35, 31);
            this.btn_export.TabIndex = 508;
            this.btn_export.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_export.UseVisualStyleBackColor = true;
            this.btn_export.Click += new System.EventHandler(this.btn_export_Click);
            // 
            // btn_Print
            // 
            this.btn_Print.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Print.FlatAppearance.BorderSize = 0;
            this.btn_Print.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SkyBlue;
            this.btn_Print.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SkyBlue;
            this.btn_Print.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Print.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Print.ForeColor = System.Drawing.Color.White;
            this.btn_Print.Image = ((System.Drawing.Image)(resources.GetObject("btn_Print.Image")));
            this.btn_Print.Location = new System.Drawing.Point(981, 7);
            this.btn_Print.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Print.Name = "btn_Print";
            this.btn_Print.Size = new System.Drawing.Size(35, 31);
            this.btn_Print.TabIndex = 508;
            this.btn_Print.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_Print.UseVisualStyleBackColor = true;
            this.btn_Print.Click += new System.EventHandler(this.btn_Print_Click);
            // 
            // btn_Cancelar
            // 
            this.btn_Cancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Cancelar.FlatAppearance.BorderSize = 0;
            this.btn_Cancelar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SkyBlue;
            this.btn_Cancelar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SkyBlue;
            this.btn_Cancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Cancelar.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Cancelar.ForeColor = System.Drawing.Color.White;
            this.btn_Cancelar.Image = ((System.Drawing.Image)(resources.GetObject("btn_Cancelar.Image")));
            this.btn_Cancelar.Location = new System.Drawing.Point(1040, 7);
            this.btn_Cancelar.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Cancelar.Name = "btn_Cancelar";
            this.btn_Cancelar.Size = new System.Drawing.Size(35, 31);
            this.btn_Cancelar.TabIndex = 507;
            this.btn_Cancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_Cancelar.UseVisualStyleBackColor = true;
            this.btn_Cancelar.Click += new System.EventHandler(this.btn_Cancelar_Click);
            // 
            // crv_ImprimirTicket
            // 
            this.crv_ImprimirTicket.ActiveViewIndex = -1;
            this.crv_ImprimirTicket.AutoSize = true;
            this.crv_ImprimirTicket.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crv_ImprimirTicket.Cursor = System.Windows.Forms.Cursors.Default;
            this.crv_ImprimirTicket.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crv_ImprimirTicket.Location = new System.Drawing.Point(0, 44);
            this.crv_ImprimirTicket.Name = "crv_ImprimirTicket";
            this.crv_ImprimirTicket.ShowCloseButton = false;
            this.crv_ImprimirTicket.ShowCopyButton = false;
            this.crv_ImprimirTicket.ShowExportButton = false;
            this.crv_ImprimirTicket.ShowGotoPageButton = false;
            this.crv_ImprimirTicket.ShowGroupTreeButton = false;
            this.crv_ImprimirTicket.ShowLogo = false;
            this.crv_ImprimirTicket.ShowParameterPanelButton = false;
            this.crv_ImprimirTicket.ShowPrintButton = false;
            this.crv_ImprimirTicket.ShowRefreshButton = false;
            this.crv_ImprimirTicket.ShowZoomButton = false;
            this.crv_ImprimirTicket.Size = new System.Drawing.Size(1088, 743);
            this.crv_ImprimirTicket.TabIndex = 1;
            this.crv_ImprimirTicket.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // Frm_Print_Kardex
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1088, 787);
            this.Controls.Add(this.crv_ImprimirTicket);
            this.Controls.Add(this.pnl_titu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Frm_Print_Kardex";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "impresion";
            this.Load += new System.EventHandler(this.Frm_Print_NotaVenta_Load);
            this.pnl_titu.ResumeLayout(false);
            this.pnl_titu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private System.Windows.Forms.Panel pnl_titu;
        private System.Windows.Forms.Button btn_Cancelar;
        private System.Windows.Forms.Button btn_actualizar;
        private System.Windows.Forms.Button btn_export;
        private System.Windows.Forms.Button btn_Print;
        internal System.Windows.Forms.Label lbl_nroDoc;
        private System.Windows.Forms.Label label1;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crv_ImprimirTicket;
        internal System.Windows.Forms.Label lbl_fi;
        internal System.Windows.Forms.Label lbl_ff;
    }
}