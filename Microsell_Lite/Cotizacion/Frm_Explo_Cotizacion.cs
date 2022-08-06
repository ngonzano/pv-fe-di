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
using Microsell_Lite.Producto;
using Microsell_Lite.Compras;


namespace Microsell_Lite.Cotizacion
{
    public partial class Frm_Explo_Cotizacion : Form
    {
        DataTable dt = new DataTable();
        public Frm_Explo_Cotizacion()
        {
            InitializeComponent();
        }
        
        public string TipoVenta ;
        
        private void Frm_Listar_Producto_Compra_Load(object sender, EventArgs e)
        {
            Configurar_listView();
            dtp_Inicial.Value = DateTime.Now;
            dtp_Final.Value = DateTime.Now;
            Cargar_Todas_Cotizaciones();
            txt_buscar.Focus();
        }
        
        private void btn_cerrar_Click(object sender, EventArgs e)
        {
            this.Tag = "";
            this.Close();
        }
        private void btn_minimi_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private void pnl_titu_MouseMove(object sender, MouseEventArgs e)
        {
            Utilitario obj = new Utilitario();

            if (e.Button == MouseButtons.Left)
            {
                obj.Mover_formulario(this);

            }
        }
        private void Cargar_Todas_Cotizaciones()
        {
            RN_Cotizacion coti = new RN_Cotizacion();
            dt = coti.RN_Buscar_CotizacionRangoFecha(dtp_Inicial.Value,dtp_Final.Value,"");
            if (dt.Rows.Count >= 0)
            {
                Llenar_ListView(dt);
            }
            else
            {
                lsv_Cotizacion.Items.Clear();
            }
        }
        private void Configurar_listView()
        {
            var lis = lsv_Cotizacion;
            lsv_Cotizacion.Items.Clear();
            lis.Columns.Clear();
            lis.View = View.Details;
            lis.GridLines = true;
            lis.FullRowSelect = true;
            lis.Scrollable = true;
            lis.HideSelection = false;
            //CONFIGURAR COLUMNA
            lis.Columns.Add("ID. COT.", 100, HorizontalAlignment.Center).Text.Trim();//0
            lis.Columns.Add("FECHA", 100, HorizontalAlignment.Left).Text.Trim();//0
            lis.Columns.Add("TOTAL S/", 100, HorizontalAlignment.Left).Text.Trim();//1
            lis.Columns.Add("ESTADO", 100, HorizontalAlignment.Left).Text.Trim();//2
            lis.Columns.Add("CLIENTE", 250, HorizontalAlignment.Left).Text.Trim();//3
            lis.Columns.Add("DNI", 100, HorizontalAlignment.Left).Text.Trim();//4
            lis.Columns.Add("CONDICIONES", 300, HorizontalAlignment.Left).Text.Trim();//6
            lis.Columns.Add("USUARIO", 100, HorizontalAlignment.Left).Text.Trim();//5
        }
        private void Llenar_ListView(DataTable dt)
        {
            try
            {
                lsv_Cotizacion.Items.Clear();
                for ( int i = 0; i < dt.Rows.Count; i ++)
                {
                    DataRow dr = dt.Rows[i];
                    ListViewItem list = new ListViewItem(dr["Id_Cotiza"].ToString().Trim());
                    list.SubItems.Add(dr["FechaCoti"].ToString().Trim());
                    list.SubItems.Add(dr["TotalCotiza"].ToString().Trim());
                    list.SubItems.Add(dr["EstadoCoti"].ToString().Trim());
                    list.SubItems.Add(dr["Razon_Social_Nombres"].ToString().Trim());
                    list.SubItems.Add(dr["DNI"].ToString().Trim());
                    list.SubItems.Add(dr["Condiciones"].ToString().Trim());
                    list.SubItems.Add(dr["Usuario"].ToString().Trim());
                    
                    lsv_Cotizacion.Items.Add(list);// SI NO SE PONE ESTO EL LIST VIEW NO SE LLENARA
                    
                    pintar_listView();
                }
                lbl_items.Text = lsv_Cotizacion.Items.Count.ToString();
            }
            catch (Exception)
            {
                throw;
            }

        }
        public void pintar_listView() //pintar vertical
        { 
            for (int i = 0; i < lsv_Cotizacion.Items.Count; i++)
            {
                lsv_Cotizacion.Items[i].SubItems[5].BackColor = Color.LightGray;
                lsv_Cotizacion.Items[i].SubItems[2].BackColor = Color.Azure;
                lsv_Cotizacion.Items[i].SubItems[3].BackColor = Color.Ivory;
                lsv_Cotizacion.Items[i].SubItems[4].BackColor = Color.MintCream;

                lsv_Cotizacion.Items[i].SubItems[2].Font = new System.Drawing.Font("Verdana",10,FontStyle.Bold);
                lsv_Cotizacion.Items[i].SubItems[5].Font = new System.Drawing.Font("Verdana", 10, FontStyle.Bold);

                lsv_Cotizacion.Items[i].UseItemStyleForSubItems = false;
            }
        }
        private void txt_buscar_KeyDown(object sender, KeyEventArgs e)
        {
            Buscar_Cotizacion(txt_buscar.Text);
        }
        private void txt_buscar_KeyUp(object sender, KeyEventArgs e)
        {
            Buscar_Cotizacion(txt_buscar.Text);
        }       
           
        private void txt_buscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar==(int)Keys.Enter)
            {
                if (lsv_Cotizacion.Items.Count > 0)
                {
                    lsv_Cotizacion.Focus();
                    lsv_Cotizacion.Items[0].Selected = true;
                }
            }
        }
       
        private void Buscar_Cotizacion(string valor)
        {
            RN_Cotizacion coti = new RN_Cotizacion();
            dt = coti.RN_Buscar_CotizacionRangoFecha(dtp_Inicial.Value, dtp_Final.Value, txt_buscar.Text);
            if (dt.Rows.Count > 0)
            {
                Llenar_ListView(dt);
                pnl_msn.Visible = false;
            }
            else
            {
                lsv_Cotizacion.Items.Clear();
                pnl_msn.Visible = true;
            }

        }

        private void btn_add2_Click(object sender, EventArgs e)
        {
            RN_Cotizacion coti = new RN_Cotizacion();
            dt = coti.RN_Buscar_CotizacionRangoFecha(dtp_Inicial.Value, dtp_Final.Value, "");
            if (dt.Rows.Count > 0)
            {
                Llenar_ListView(dt);
                pnl_msn.Visible = false;
            }
            else
            {
                lsv_Cotizacion.Items.Clear();
                pnl_msn.Visible = true;
            }
        }

        private void cotizacionPorDiaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RN_Cotizacion coti = new RN_Cotizacion();
            dt = coti.RN_Buscar_Cotizacion_Dia_Mes("dia",DateTime.Now);
            DateTime date = DateTime.Now;
            DateTime oPrimerDiaDelMes = new DateTime(date.Year, date.Month, 1);
            DateTime oUltimoDiaDelMes = oPrimerDiaDelMes.AddMonths(1).AddDays(-1);

            dtp_Inicial.Value = oPrimerDiaDelMes;
            dtp_Final.Value = oUltimoDiaDelMes;
            if (dt.Rows.Count > 0)
            {
                Llenar_ListView(dt);
                pnl_msn.Visible = false;
            }
            else
            {
                lsv_Cotizacion.Items.Clear();
                pnl_msn.Visible = true;
            }
        }

        private void cotizacionPorMesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RN_Cotizacion coti = new RN_Cotizacion();
            dt = coti.RN_Buscar_Cotizacion_Dia_Mes("mes", DateTime.Now);
            DateTime date = DateTime.Now;
            DateTime oPrimerDiaDelMes = new DateTime(date.Year, date.Month, 1);
            DateTime oUltimoDiaDelMes = oPrimerDiaDelMes.AddMonths(1).AddDays(-1);

            dtp_Inicial.Value = oPrimerDiaDelMes;
            dtp_Final.Value = oUltimoDiaDelMes;
            if (dt.Rows.Count > 0)
            {
                Llenar_ListView(dt);
                pnl_msn.Visible = false;
            }
            else
            {
                lsv_Cotizacion.Items.Clear();
                pnl_msn.Visible = true;
            }
        }
        Principal.Frm_Filtro fil = new Principal.Frm_Filtro();
        Utilitarios.Frm_Advertencia adv = new Utilitarios.Frm_Advertencia();
        private void imprimirCotizacionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Informe.Frm_PrintCoti printCoti = new Informe.Frm_PrintCoti();

            if (lsv_Cotizacion.SelectedItems.Count == 0)
            {
                fil.Show();
                adv.lbl_msm.Text = "Seleccionar el Item que deseas Imprimir.";
                adv.ShowDialog();
                fil.Hide();
            }
            else
            {
                var lis = lsv_Cotizacion.SelectedItems[0];
                string idDoc = lis.SubItems[0].Text;

                fil.Show();
                printCoti.Tag = idDoc;
                printCoti.ShowDialog();
                fil.Hide();
            }
        }

        private void atenderCotizacionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Ventas.Frm_Crear_Ventas venta = new Ventas.Frm_Crear_Ventas();
            var lis = lsv_Cotizacion.SelectedItems[0];
            string idDoc = lis.SubItems[0].Text;
            string estado= lis.SubItems[3].Text;

            if (lsv_Cotizacion.SelectedItems.Count == 0)
            {
                fil.Show();
                adv.lbl_msm.Text = "Seleccionar el Item que deseas Atender.";
                adv.ShowDialog();
                fil.Hide();
            }
            else if (estado=="Atendido")
            {
                fil.Show();
                adv.lbl_msm.Text = "La cotizacion seleccionada ya se encuentra Atendida.";
                adv.ShowDialog();
                fil.Hide();
            }
            else
            {
                fil.Show();
                venta.txt_buscar.Text= idDoc;
                venta.ShowDialog();
                Cargar_Todas_Cotizaciones();
                fil.Hide();
            }
        }
    }
}
