using SPV_Capa_Entidad;
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

namespace Microsell_Lite.Caja
{
    public partial class Frm_Reg_otroIngresos : Form
    {
        public Frm_Reg_otroIngresos()
        {
            InitializeComponent();
        }

        private void Pnl_titulo_MouseMove(object sender, MouseEventArgs e)
        {
            Utilitario ui = new Utilitario();
            if (e.Button == MouseButtons.Left)
            {
                ui.Mover_formulario(this);
            }
        }

        private void Frm_Reg_otroIngresos_Load(object sender, EventArgs e)
        {

        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            this.Tag = "";
            this.Close();

        }

        private void btn_aceptar_Click(object sender, EventArgs e)
        {
            Guardar_Otros_Ingreso_Caja();
        }

        Utilitarios.Frm_Msm_Bueno bueno = new Utilitarios.Frm_Msm_Bueno();
        Principal.Frm_Filtro fil = new Principal.Frm_Filtro();
        private void Guardar_Otros_Ingreso_Caja()
        {
            EN_Caja e_caja = new EN_Caja();
            RN_Caja n_caja = new RN_Caja();
            int rpt;
            try
            {
                e_caja.Fecha_Caja = dtp_fecha.Value;
                e_caja.Tipo_Caja = "Entrada";
                e_caja.Concepto = txt_concepto.Text;
                e_caja.De_Para = txt_cliente.Text;
                e_caja.ImporteCaja = Convert.ToDouble(txt_importe.Text);
                e_caja.Id_Usu = Cls_UsuLogin.IdUsu;
                e_caja.TotalUti = 0;
                e_caja.TipoPago = cbo_tipoPago.Text;
                e_caja.GeneradoPor = "Otros Ingresos";
                e_caja.Nro_Doc = txt_nroDoc.Text;
                rpt = n_caja.RN_Ingresar_Caja(e_caja);
                if (rpt==1)
                {
                    fil.Show();
                    bueno.Lbl_msm1.Text = "Se guardo el ingreso Satisfactoriamente.";
                    bueno.ShowDialog();
                    fil.Hide();

                    this.Tag = "A";
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al Guardar: " + ex.Message, "Form Add Caja", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
