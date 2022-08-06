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

namespace Microsell_Lite.Ventas
{
    public partial class Frm_Print_NotaVenta : Form
    {
        public Frm_Print_NotaVenta()
        {
            InitializeComponent();
        }

        private void Frm_Print_NotaVenta_Load(object sender, EventArgs e)
        {
            Imprimir_NotaVenta(this.Tag.ToString());
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
        private void Imprimir_NotaVenta(string idDoc)
        {
            RN_Temporal n_tem = new RN_Temporal();
            DataTable dt = new DataTable();

            dt = n_tem.BD_Mostrar_Temporales(idDoc.Trim());
            if (dt.Rows.Count>0)
            {
                rpt_ImpNotaVenta rpt = new rpt_ImpNotaVenta();
                crv_Imprimir.ReportSource = rpt;
                rpt.SetDataSource(dt);
                rpt.Refresh();crv_Imprimir.Refresh();
                n_tem.BD_Eliminar_Temporal(this.Tag.ToString());
            }
        }

        private void btn_Print_Click(object sender, EventArgs e)
        {
            crv_Imprimir.PrintReport();
        }

        private void btn_export_Click(object sender, EventArgs e)
        {
            crv_Imprimir.ExportReport();
        }

        private void btn_actualizar_Click(object sender, EventArgs e)
        {
            crv_Imprimir.RefreshReport();
        }
    }
}
