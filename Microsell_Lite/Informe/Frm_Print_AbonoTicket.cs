using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SPV_Capa_Negocio;

namespace Microsell_Lite.Informe
{
    public partial class Frm_Print_Abono : Form
    {
        public Frm_Print_Abono()
        {
            InitializeComponent();
        }

        private void Frm_Print_NotaVenta_Load(object sender, EventArgs e)
        {
            Imprimir_NotaVenta_Ticket(lbl_nroDoc.Text);
            //Imprimir_NotaVenta_Ticket(this.Tag.ToString());
        }

        private void pnl_titu_MouseMove(object sender, MouseEventArgs e)
        {
            Utilitario obj = new Utilitario();

            if (e.Button == MouseButtons.Left)
            {
                obj.Mover_formulario(this);

            }
        }

        private void btn_Cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void Imprimir_NotaVenta_Ticket(string idDoc)
        {
            RN_Credito n_cre = new RN_Credito();
            DataTable dt = new DataTable();
            dt = n_cre.BD_Buscar_CreditoPrint(Convert.ToDateTime(lbl_xfechaCredito.Text), DateTime.Now, lbl_nroDoc.Text);
            if (dt.Rows.Count>0)
            {
                rpt_Abono rpt = new rpt_Abono();
                crv_ImprimirTicket.ReportSource = rpt;
                rpt.SetDataSource(dt);
                rpt.Refresh();crv_ImprimirTicket.Refresh();
            }
        }

        private void btn_Print_Click(object sender, EventArgs e)
        {
            crv_ImprimirTicket.PrintReport();
        }

        private void btn_export_Click(object sender, EventArgs e)
        {
            crv_ImprimirTicket.ExportReport();
        }

        private void btn_actualizar_Click(object sender, EventArgs e)
        {
            crv_ImprimirTicket.RefreshReport();
        }
    }
}
