using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SPV_Capa_Entidad;
using SPV_Capa_Negocio;

namespace Microsell_Lite.Caja
{
    public partial class Frm_InicioCaja : Form
    {
        public Frm_InicioCaja()
        {
            InitializeComponent();
        }

        private void Frm_InicioCaja_Load(object sender, EventArgs e)
        {
            txt_importe.Focus();
        }

        private void Frm_InicioCaja_MouseMove(object sender, MouseEventArgs e)
        {
            Utilitario ui = new Utilitario();
            if (e.Button ==MouseButtons.Left )
            {
                ui.Mover_formulario(this);
            }
        }

        private void Frm_InicioCaja_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode ==Keys.Escape )
            {
                this.Tag = "";
                this.Close();
            }
        }
        Principal.Frm_Filtro fil = new Principal.Frm_Filtro();
        Utilitarios.Frm_Advertencia adv = new Utilitarios.Frm_Advertencia();
        Utilitarios.Frm_Msm_Bueno bueno = new Utilitarios.Frm_Msm_Bueno();
        void Registrar_InicioCaja()
        {
            EN_CierreCaja e_cie = new EN_CierreCaja();
            RN_CierreCaja n_cie = new RN_CierreCaja();
            int rpt;
            try
            {
                string idCierre = RN_TipoDoc.Sp_Listado_Tipo(13);
                e_cie.IdCierre=idCierre;
                e_cie.Apertura_Caja=Convert.ToDouble(txt_importe.Text);
                e_cie.Total_Ingreso=0;
                e_cie.TotalEgreso = 0;
                e_cie.Id_usu = Cls_UsuLogin.IdUsu;
                e_cie.TodoDeposito = 0;
                e_cie.TotalGanancia = 0;
                e_cie.TotalEntregado = 0;
                e_cie.SaldoSiguiente = 0;
                e_cie.TotalFactura = 0;
                e_cie.TotalBoleta = 0;
                e_cie.Totalnota = 0;
                e_cie.TotalCreditoCobrado = 0;
                e_cie.TotalCreditoEmitido = 0;

                rpt=n_cie.RN_Registrar_Inicio_CierreCaja(e_cie);
                if (rpt==1)
                {
                    RN_TipoDoc.RN_Actualizar_SiguienteNro_correlativo(13);
                    fil.Show();
                    bueno.Lbl_msm1.Text = "Inicio de caja de: "+e_cie.Id_usu.ToUpper()+" se aperturo satisfactoriamente.";
                    bueno.ShowDialog();
                    fil.Hide();

                    txt_importe.Text = "";
                    this.Tag = "A";
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Tag = "";
            this.Close();
        }

        private void btn_procesar_Click(object sender, EventArgs e)
        {
            RN_CierreCaja n_cie = new RN_CierreCaja();
            if (txt_importe.Text.Length == 0)
            {
                fil.Show();
                adv.lbl_msm.Text = "Por Favor, ingresa el importe para aperturar la caja del dia";
                adv.ShowDialog();
                fil.Hide();
                txt_importe.Focus();
                
            }
            else if (n_cie.RN_Validar_Registro_Caja())
            {
                fil.Show();
                adv.lbl_msm.Text = "Se verifica que existe una apertura de caja en este mismo dia.";
                adv.ShowDialog();
                fil.Hide();
                txt_importe.Focus();
               
            }
            else
            {
                Registrar_InicioCaja();
            }
        }
    }
}
