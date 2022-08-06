using SPV_Capa_Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Microsell_Lite.Utilitarios
{
    public partial class Frm_Correlativo : Form
    {
        public Frm_Correlativo()
        {
            InitializeComponent();
        }
        
        private void Frm_Correlativo_Load(object sender, EventArgs e)
        {
            listar_ComboBox_TipoDocumento();
        }
        void listar_ComboBox_TipoDocumento()
        {
            DataTable dt = new DataTable();
            RN_TipoDoc n_tipo = new RN_TipoDoc();
            dt = n_tipo.RN_Listar_TipoDocumento();
            if (dt.Rows.Count > 0)
            {
                var cbb = cbb_TipDocumento;
                cbb.DataSource = dt;
                cbb.DisplayMember = "Documento";
                cbb.ValueMember = "Id_Tipo";
                cbb.SelectedIndex = 0;
            }
        }

        private void pnl_subtitu_Paint(object sender, PaintEventArgs e)
        {

        }
        private void cbb_TipDocumento_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cbb_TipDocumento.Text != "Seleccionar...")
            {
                DataTable dt = new DataTable();
                RN_TipoDoc n_tipo = new RN_TipoDoc();
                grb_Documento.Text = cbb_TipDocumento.Text;
                dt = n_tipo.RN_Buscar_TipoDocumento(cbb_TipDocumento.Text);
                txt_Serie.Text = dt.Rows[0]["Serie"].ToString();
                txt_numero.Text= dt.Rows[0]["Numero"].ToString();

                txt_numero.Enabled = true;
                txt_Serie.Enabled = true;
            }
            else
            {
                grb_Documento.Text = "Documento";
                limpiar();
            }
            
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Tag = "";
            this.Close();
        }

        private void txt_numero_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilitario uti = new Utilitario();
            e.KeyChar = Convert.ToChar(uti.SoloNumeros(e.KeyChar));
        }

        private void btn_listo_Click(object sender, EventArgs e)
        {
            if (cbb_TipDocumento.Text != "Seleccionar...")
            {
                if (txt_numero.Text == "" || txt_Serie.Text == "")
                {
                    MessageBox.Show("El numero de Serie ó Numero de documento no pueden estar Vacios", "Advertencia de seguridad", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    RN_TipoDoc n_tipo = new RN_TipoDoc();
                    n_tipo.RN_Editar_Nro_correlativo(Convert.ToInt32(cbb_TipDocumento.SelectedValue), cbb_TipDocumento.Text, txt_Serie.Text, txt_numero.Text);
                    MessageBox.Show("Se Actualizo el correlativo del Documento: " + cbb_TipDocumento.Text + " al correlativo: " + txt_numero.Text, " Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    limpiar();
                }

            }
            else
            {
                MessageBox.Show("Seleccione un documento.", "Advertencia de seguridad", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }
        void limpiar()
        {
            cbb_TipDocumento.SelectedIndex = 0;
            txt_numero.Text = "0";
            txt_Serie.Text = "0";
            txt_numero.Enabled = false;
            txt_Serie.Enabled = false;
        }

        private void btn_cerrar_Click(object sender, EventArgs e)
        {
            this.Tag = "";
            this.Close();
        }
    }
}
