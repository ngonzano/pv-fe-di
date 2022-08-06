using System;
//using System.Collections.Generic;
//using System.ComponentModel;
using System.Data;
//using System.Drawing;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
using System.Windows.Forms;
//using CrystalDecisions.Shared;
using SPV_Capa_Negocio;

namespace Microsell_Lite.Informe
{
    public partial class Frm_Print_Kardex : Form
    {
        public Frm_Print_Kardex()
        {
            InitializeComponent();
        }

        private void Frm_Print_NotaVenta_Load(object sender, EventArgs e)
        {
            Print_EntradaSalida_Kardex();
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
        private void Print_EntradaSalida_Kardex()
        {
            RN_Kardex krdx = new RN_Kardex();
            DataTable dt = new DataTable();
            dt = krdx.RN_Entrada_Salida_Kardex(Convert.ToDateTime(lbl_fi.Text), Convert.ToDateTime(lbl_ff.Text));
            if (dt.Rows.Count>0)
            {
                rpt_Kardex rpt = new rpt_Kardex();
                crv_ImprimirTicket.ReportSource = rpt;

                rpt.SetDataSource(dt);
                rpt.Refresh();
                crv_ImprimirTicket.Refresh();
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
