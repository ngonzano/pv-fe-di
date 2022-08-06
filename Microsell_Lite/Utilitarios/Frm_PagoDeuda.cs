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

namespace Microsell_Lite.Ventas
{
    public partial class Frm_PagoDeuda : Form
    {
        public Frm_PagoDeuda()
        {
            InitializeComponent();
        }
        
        private void pnl_subtitu_Paint(object sender, PaintEventArgs e)
        {

        }
      
        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Tag = "";
            this.Close();
        }

        Utilitarios.Frm_Advertencia adv = new Utilitarios.Frm_Advertencia();
        private void btn_listo_Click(object sender, EventArgs e)
        {
            if(txt_ACuenta.Text == "0" || txt_ACuenta.Text == null)
            {
                MessageBox.Show("El monto abonar no puede ser cero o vacio.", "Advertencia de Seguridad", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else
            {
                if (Convert.ToDouble(txt_ACuenta.Text) <= Convert.ToDouble(lbl_saldoPendiente.Text))
                {
                    Crear_Registro_Credito_Detealle();
                    Frm_Explo_Credito cre = new Frm_Explo_Credito();
                    cre.Cargar_Todo_Creditos();
                }
                else
                {
                    fil.Show();
                    adv.lbl_msm.Text = "El monto del Abono no puede ser mayor al saldo pendiente.";
                    adv.ShowDialog();
                    fil.Hide();
                }
            }
            
        }
        Principal.Frm_Filtro fil = new Principal.Frm_Filtro();
        void Crear_Registro_Credito_Detealle()
        {
            EN_Det_Credito e_dCre = new EN_Det_Credito();
            RN_Credito n_Cred = new RN_Credito();
            int rpt;
            double deuda;
            try
            {
                e_dCre.Idnotacredito = lbl_codCredito.Text;
                e_dCre.Acuenta = Convert.ToDouble(txt_ACuenta.Text);
                e_dCre.Saldoactual =Convert.ToDouble(Convert.ToDecimal(lbl_totalCredito.Text) - Convert.ToDecimal(lbl_Abono.Text) - Convert.ToDecimal(txt_ACuenta.Text));
                deuda = e_dCre.Saldoactual;
                e_dCre.Fecha_Pago = DateTime.Now;
                e_dCre.TipoPago = cbb_TipoPago.Text;
                e_dCre.NroOpera = txt_Comentario.Text;
                e_dCre.IdUsu = Cls_UsuLogin.Usuario;

                rpt=n_Cred.RN_Ingresar_Credito_Det(e_dCre);
                
                if (rpt==1)
                {
                    
                    Utilitarios.Frm_Msm_Bueno bueno = new Utilitarios.Frm_Msm_Bueno();

                    fil.Show();
                    bueno.Lbl_msm1.Text = "Se registro el Abono de: S/. " + txt_ACuenta.Text + " Satisfactoriamente.";
                    bueno.ShowDialog();
                    fil.Hide();
                }
                //actualizar deuda en la cabecera y cambiar estado segun el monto total del abono
                if (deuda==0)
                {
                    n_Cred.RN_Actualizar_Saldo_Pendiente(lbl_codCredito.Text,deuda,"Cancelado");
                }
                else if (deuda>0)
                {
                    n_Cred.RN_Actualizar_Saldo_Pendiente(lbl_codCredito.Text, deuda, "Pendiente");
                }
                //imprimir Vaucher de Abono
                Informe.Frm_Print_Abono printAbono = new Informe.Frm_Print_Abono();
                fil.Show();
                printAbono.Tag = lbl_codCredito.Text;
                printAbono.lbl_nroDoc.Text = lbl_codCredito.Text;
                printAbono.lbl_xfechaCredito.Text = lbl_FechaCredito.Text;
                printAbono.ShowDialog();
                
                fil.Hide();

                this.Tag = "";
                this.Close();
            }
            catch (Exception)
            {

                throw;
            }
        }
        void limpiar()
        {
            txt_ACuenta.Text = "";
            txt_Comentario.Text = "";
            cbb_TipoPago.SelectedIndex = 0;
        }

        private void btn_cerrar_Click(object sender, EventArgs e)
        {
            this.Tag = "";
            this.Close();
        }

        private void txt_Comentario_Enter(object sender, EventArgs e)
        {
            if (txt_Comentario.Text == "Ingresa un Comentario")
            {
                txt_Comentario.Text = "";
                txt_Comentario.ForeColor = Color.LightGray;
            }
        }

        private void txt_Comentario_Leave(object sender, EventArgs e)
        {
            if (txt_Comentario.Text == "")
            {
                txt_Comentario.Text = "Ingresa un Comentario";
                txt_Comentario.ForeColor = Color.DimGray;
            }
        }

        private void Frm_PagoDeuda_Load(object sender, EventArgs e)
        {
            cbb_TipoPago.SelectedIndex = 0;
        }

        private void txt_ACuenta_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilitario uti = new Utilitario();
            e.KeyChar = Convert.ToChar(uti.SoloNumeros(e.KeyChar));
        }
    }
}
