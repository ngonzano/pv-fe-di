using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrystalDecisions.Shared;
using SPV_Capa_Negocio;

namespace Microsell_Lite.Ventas
{
    public partial class Frm_Print_NotaVentaTicket : Form
    {
        public Frm_Print_NotaVentaTicket()
        {
            InitializeComponent();
        }

        private void Frm_Print_NotaVenta_Load(object sender, EventArgs e)
        {
            Imprimir_NotaVenta_Ticket(this.Tag.ToString());
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
        public string RutaPPF;
        private void Imprimir_NotaVenta_Ticket(string idDoc)
        {
            RN_Temporal n_tem = new RN_Temporal();
            DataTable dt = new DataTable();

            dt = n_tem.BD_Mostrar_Temporales(idDoc.Trim());
            if (dt.Rows.Count>0)
            {
                rpt_NotaVentaTicket rpt = new rpt_NotaVentaTicket();
                crv_ImprimirTicket.ReportSource = rpt;
                rpt.SetDataSource(dt);
                rpt.Refresh();
                crv_ImprimirTicket.Refresh();
                //crv_ImprimirTicket.ReportSource = rpt;
                //n_tem.BD_Eliminar_Temporal(this.Tag.ToString());

                try
                {
                    //Guardar PDF automatico
                    ExportOptions exportOptions;
                    DiskFileDestinationOptions destinoPDF = new DiskFileDestinationOptions();
                    PdfRtfWordFormatOptions typeformatoOption = new PdfRtfWordFormatOptions();

                    destinoPDF.DiskFileName = RutaPPF;
                    exportOptions = rpt.ExportOptions;

                    exportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
                    exportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;
                    exportOptions.ExportDestinationOptions = destinoPDF;
                    exportOptions.ExportFormatOptions = typeformatoOption;

                    rpt.Export();

                }
                catch (Exception ex)
                {
                    //MessageBox.Show("Error al Exportar el .PDF "+ex.Message,"Advertencia de exportacion",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                }
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
