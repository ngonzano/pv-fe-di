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
    public partial class Frm_TipoPago_Credito : Form
    {
        public Frm_TipoPago_Credito()
        {
            InitializeComponent();
        }

        private void Frm_TipoPago_Credito_Load(object sender, EventArgs e)
        {
            txt_ACuenta.Focus();
            cbb_tipoPago.SelectedIndex = 0;
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Tag = "";
            this.Close();
        }

        private void txt_limCredito_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilitario uti = new Utilitario();
            e.KeyChar = Convert.ToChar(uti.SoloNumeros(e.KeyChar));
            txt_ACuenta.Text = txt_ACuenta.Text.Replace(",", ".");
            txt_ACuenta.SelectionStart = txt_ACuenta.Text.Length;

            try
            {
                if (txt_ACuenta.Text != "")
                {
                    double saldoPendiente;
                    saldoPendiente = Convert.ToDouble(lbl_totalACobrar.Text) - Convert.ToDouble(txt_ACuenta.Text);
                    lbl_SaldoAPagarCredito.Text = saldoPendiente.ToString("###0.00");
                }

            }
            catch (Exception)
            {
                throw;
            }
        }

        private void btn_listo_Click(object sender, EventArgs e)
        {
            if (txt_ACuenta.Text=="")
            {
                MessageBox.Show("Ingrese un monto a cuenta.","Falta Monto a Cuenta",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                txt_ACuenta.Focus();
                return;
            }
            /*if (txt_ACuenta.Text == "0")
            {
                MessageBox.Show("El importe a cuenta no debe ser CERO.", "Falta Monto a Cuenta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_ACuenta.Focus();
                return;
            }*/
            if (Convert.ToDouble(txt_ACuenta.Text) == Convert.ToDouble(lbl_totalACobrar.Text))
            {
                MessageBox.Show("El importe a cuenta no debe ser igual al total a cobrar, reaizar una venta con el flujo normal", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_ACuenta.Focus();
                return;
            }
            if (Convert.ToDouble(txt_ACuenta.Text) > Convert.ToDouble(lbl_totalACobrar.Text))
            {
                MessageBox.Show("El importe a cuenta NO debe ser mayor al total a cobrar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_ACuenta.Focus();
                return;
            }
            this.Tag = "A";
            this.Close();
        }
        public void Limpiar_Frm_Credito()
        {
            txt_ACuenta.Text = "";
            lbl_totalACobrar.Text = "0";
            lbl_SaldoAPagarCredito.Text = "0";
        }

        private void txt_ACuenta_KeyUp(object sender, KeyEventArgs e)
        {
            txt_ACuenta.Text = txt_ACuenta.Text.Replace(",", ".");
            txt_ACuenta.SelectionStart = txt_ACuenta.Text.Length;

            try
            {
                if (txt_ACuenta.Text != "")
                {
                    double saldoPendiente;
                    saldoPendiente = Convert.ToDouble(lbl_totalACobrar.Text) - Convert.ToDouble(txt_ACuenta.Text);
                    lbl_SaldoAPagarCredito.Text = saldoPendiente.ToString("###0.00");
                }

            }
            catch (Exception)
            {
                throw;
            }
        }

        private void txt_ACuenta_KeyDown(object sender, KeyEventArgs e)
        {
            txt_ACuenta.Text = txt_ACuenta.Text.Replace(",", ".");
            txt_ACuenta.SelectionStart = txt_ACuenta.Text.Length;

            try
            {
                if (txt_ACuenta.Text != "")
                {
                    double saldoPendiente;
                    saldoPendiente = Convert.ToDouble(lbl_totalACobrar.Text) - Convert.ToDouble(txt_ACuenta.Text);
                    lbl_SaldoAPagarCredito.Text = saldoPendiente.ToString("###0.00");
                }

            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
