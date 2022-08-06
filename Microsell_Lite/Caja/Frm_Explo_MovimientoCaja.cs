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


namespace Microsell_Lite.Caja
{
    public partial class Frm_Explo_MovimientoCaja : Form
    {
        RN_Producto obj = new RN_Producto();
        DataTable dt = new DataTable();
        public Frm_Explo_MovimientoCaja()
        {
            InitializeComponent();
        }
        
        public string TipoVenta ;
        
        private void Frm_Listar_Producto_Compra_Load(object sender, EventArgs e)
        {
            Configurar_listView();
            dtp_Final.Value = DateTime.Now;
            dtp_Inicial.Value = DateTime.Now;
            Cargar_Todos_Productos();
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
        private void Configurar_listView()
        {
            var lis = List_Krdx;//*****
            List_Krdx.Items.Clear();//**
            lis.Columns.Clear();//**
            lis.View = View.Details;//***
            lis.GridLines = true;
            lis.FullRowSelect = true;
            lis.Scrollable = true;
            lis.HideSelection = false;
            //CONFIGURAR COLUMNA
            lis.Columns.Add("ITEM", 0, HorizontalAlignment.Center).Text.Trim();//0
            lis.Columns.Add("NUM. DOC.", 90, HorizontalAlignment.Left).Text.Trim();//1
            lis.Columns.Add("NOM. CLIENTE", 200, HorizontalAlignment.Left).Text.Trim();//2
            lis.Columns.Add("FECHA", 100, HorizontalAlignment.Left).Text.Trim();//3
            lis.Columns.Add("TIPO CAJA", 90, HorizontalAlignment.Left).Text.Trim();//4
            lis.Columns.Add("CONCEPTO", 240, HorizontalAlignment.Left).Text.Trim();//5
            lis.Columns.Add("TOTAL S/", 80, HorizontalAlignment.Left).Text.Trim();//6
            lis.Columns.Add("UTILIDA S/", 80, HorizontalAlignment.Left).Text.Trim();//7
            lis.Columns.Add("TIPO PAGO", 90, HorizontalAlignment.Left).Text.Trim();//8
            lis.Columns.Add("GENERADO POR", 120, HorizontalAlignment.Left).Text.Trim();//9
            lis.Columns.Add("ESTADO", 90, HorizontalAlignment.Left).Text.Trim();//10

        }
        private void Llenar_ListView(DataTable dt)
        {
            try
            {
                List_Krdx.Items.Clear();
                for ( int i = 0; i < dt.Rows.Count; i ++)
                {
                    DataRow dr = dt.Rows[i];
                    ListViewItem list = new ListViewItem(dr["Idcaja"].ToString().Trim());
                    list.SubItems.Add(dr["Nro_Doc"].ToString().Trim());
                    list.SubItems.Add(dr["De_Para"].ToString().Trim());
                    list.SubItems.Add(dr["Fecha_Caja"].ToString().Trim());
                    list.SubItems.Add(dr["Tipo_Caja"].ToString().Trim());
                    list.SubItems.Add(dr["Concepto"].ToString().Trim());
                    list.SubItems.Add(dr["ImporteCaja"].ToString().Trim());
                    list.SubItems.Add(dr["TotalUti"].ToString().Trim());
                    list.SubItems.Add(dr["TipoPago"].ToString().Trim());
                    list.SubItems.Add(dr["GeneradoPor"].ToString().Trim());
                    list.SubItems.Add(dr["EstadoCaja"].ToString().Trim());
                    List_Krdx.Items.Add(list);// SI NO SE PONE ESTO EL LIST VIEW NO SE LLENARA
                    
                    pintar_listView();
                }
                lbl_items.Text = List_Krdx.Items.Count.ToString();
            }
            catch (Exception)
            {
                throw;
            }

        }
        private void Cargar_Todos_Productos()
        {
            RN_Caja n_caja = new RN_Caja();
            dt = n_caja.RN_Buscar_Caja_RangoFechas(dtp_Inicial.Value, dtp_Final.Value, "");
            if (dt.Rows.Count >= 0)
            {
                Llenar_ListView(dt);
            }
            else
            {
                List_Krdx.Items.Clear();
            }
        }
        public void pintar_listView() //pintar vertical
        { 
            for (int i = 0; i < List_Krdx.Items.Count; i++)
            {
                List_Krdx.Items[i].SubItems[5].BackColor = Color.LightGray;
                List_Krdx.Items[i].SubItems[2].BackColor = Color.Azure;
                List_Krdx.Items[i].SubItems[3].BackColor = Color.Ivory;
                List_Krdx.Items[i].SubItems[4].BackColor = Color.MintCream;

                List_Krdx.Items[i].SubItems[2].Font = new System.Drawing.Font("Verdana",10,FontStyle.Bold);
                List_Krdx.Items[i].SubItems[5].Font = new System.Drawing.Font("Verdana", 10, FontStyle.Bold);

                List_Krdx.Items[i].UseItemStyleForSubItems = false;
            }
        }
        private void txt_buscar_KeyDown(object sender, KeyEventArgs e)
        {
            RN_Caja n_caja = new RN_Caja();
            dt = n_caja.RN_Buscar_Caja_RangoFechas(dtp_Inicial.Value, dtp_Final.Value, txt_buscar.Text);
            if (dt.Rows.Count >= 0)
            {
                Llenar_ListView(dt);
            }
            else
            {
                List_Krdx.Items.Clear();
            }
        }
        private void txt_buscar_KeyUp(object sender, KeyEventArgs e)
        {
            RN_Caja n_caja = new RN_Caja();
            dt = n_caja.RN_Buscar_Caja_RangoFechas(dtp_Inicial.Value, dtp_Final.Value, txt_buscar.Text);
            if (dt.Rows.Count >= 0)
            {
                Llenar_ListView(dt);
            }
            else
            {
                List_Krdx.Items.Clear();
            }
        }       
           
        private void txt_buscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar==(int)Keys.Enter)
            {
                if (List_Krdx.Items.Count > 0)
                {
                    List_Krdx.Focus();
                    List_Krdx.Items[0].Selected = true;
                }
            }
        }
        private void btn_add2_Click(object sender, EventArgs e)
        {
            RN_Caja n_caja = new RN_Caja();
            dt = n_caja.RN_Buscar_Caja_RangoFechas(dtp_Inicial.Value,dtp_Final.Value,"");
            if (dt.Rows.Count > 0)
            {
                Llenar_ListView(dt);
                pnl_msn.Visible = false;
            }
            else
            {
                List_Krdx.Items.Clear();
                pnl_msn.Visible = true;
            }
        }

        private void buscarPorDiaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RN_Caja n_caja = new RN_Caja();
            dt=n_caja.RN_Mostrar_Caja_Dia();
            DateTime date = DateTime.Now;
            DateTime oPrimerDiaDelMes = new DateTime(date.Year, date.Month, 1);
            DateTime oUltimoDiaDelMes = oPrimerDiaDelMes.AddMonths(1).AddDays(-1);

            dtp_Inicial.Value = date;
            dtp_Final.Value = date;
            if (dt.Rows.Count > 0)
            {
                Llenar_ListView(dt);
                pnl_msn.Visible = false;
            }
            else
            {
                List_Krdx.Items.Clear();
                pnl_msn.Visible = true;
            }
        }

        private void buscarPorMesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RN_Caja n_caja = new RN_Caja();
            dt=n_caja.RN_Mostrar_Caja_Mes(DateTime.Now);
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
                List_Krdx.Items.Clear();
                pnl_msn.Visible = true;
            }
        }
    }
}
