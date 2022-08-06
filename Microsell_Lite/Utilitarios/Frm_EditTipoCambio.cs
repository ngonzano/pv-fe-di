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
    public partial class Frm_EditTipoCambio : Form
    {
        public Frm_EditTipoCambio()
        {
            InitializeComponent();
        }
        
        private void Frm_Correlativo_Load(object sender, EventArgs e)
        {
            Buscar_TipoCambio();
        }
        void Buscar_TipoCambio()
        {
            DataTable dt = new DataTable();
            RN_TipoDoc n_tipo = new RN_TipoDoc();
            dt = n_tipo.RN_Buscar_TipoDocumento("Tipo Cambio");
            if (dt.Rows.Count > 0)
            {
               lbl_tipoCambio.Text= ("S/." + dt.Rows[0]["Numero"]).ToString();
            }
        }

        private void pnl_subtitu_Paint(object sender, PaintEventArgs e)
        {

        }
        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Tag = "";
            this.Close();
        }

        private void btn_listo_Click(object sender, EventArgs e)
        {
            if (txt_TiCambio.Text != "0" || txt_TiCambio.Text== null)
            {
                if (true)
                {
                    RN_TipoDoc n_tipo = new RN_TipoDoc();
                    n_tipo.RN_Actualizar_TipoCambio(7,txt_TiCambio.Text);
                    MessageBox.Show("Se Actrualizo el Tipo de Cambio: S/ " + lbl_tipoCambio.Text+ " al: S/ " + txt_TiCambio.Text, " Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Tag = "";
                    this.Close();
                }

            }
            else
            {
                MessageBox.Show("El tipo de cambio no puede ser cero o vacio.", "Advertencia de seguridad", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }
        private void btn_cerrar_Click(object sender, EventArgs e)
        {
            this.Tag = "";
            this.Close();
        }

        private void txt_TiCambio_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilitario uti = new Utilitario();
            e.KeyChar = Convert.ToChar(uti.SoloNumeros(e.KeyChar));
        }

        private void txt_TiCambio_Enter(object sender, EventArgs e)
        {
            if (txt_TiCambio.Text == "0")
            {
                txt_TiCambio.Text = "";
                txt_TiCambio.ForeColor = Color.LightGray;
            }
        }

        private void txt_TiCambio_Leave(object sender, EventArgs e)
        {
            if (txt_TiCambio.Text == "")
            {
                txt_TiCambio.Text = "0";
                txt_TiCambio.ForeColor = Color.DimGray;
            }
        }
    }
}
