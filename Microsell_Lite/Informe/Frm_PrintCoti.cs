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

namespace Microsell_Lite.Informe
{
    public partial class Frm_PrintCoti : Form
    {
        public Frm_PrintCoti()
        {
            InitializeComponent();
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {
            ImprimirCotizacion();
        }

        public string RutaPPF;
        void ImprimirCotizacion()
        {
            RN_Cotizacion n_coti = new RN_Cotizacion();
            DataTable dt = new DataTable();

            dt = n_coti.RN_Buscar_Cotizacion_Para_Editar(this.Tag.ToString());
            rpt_Cotizacion r_coti = new rpt_Cotizacion();
            this.crp_Cotizacion.ReportSource = r_coti;

            r_coti.SetDataSource(dt);
            r_coti.Refresh();
            crp_Cotizacion.ReportSource = r_coti;

            try
            {
                //Guardar PDF automatico
                ExportOptions exportOptions;
                DiskFileDestinationOptions destinoPDF = new DiskFileDestinationOptions();
                PdfRtfWordFormatOptions typeformatoOption = new PdfRtfWordFormatOptions();

                destinoPDF.DiskFileName = RutaPPF;
                exportOptions = r_coti.ExportOptions;

                exportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
                exportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;
                exportOptions.ExportDestinationOptions = destinoPDF;
                exportOptions.ExportFormatOptions = typeformatoOption;

                r_coti.Export();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al Exportar el .PDF " + ex.Message, "Advertencia de exportacion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }
        private void pnl_titu_MouseMove(object sender, MouseEventArgs e)
        {
            Utilitario obj = new Utilitario();

            if (e.Button == MouseButtons.Left)
            {
                obj.Mover_formulario(this);
            }
        }

        private void btn_cerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
