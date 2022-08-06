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


namespace Microsell_Lite.Productos
{
    public partial class Frm_Explo_Kardex : Form
    {
        RN_Producto obj = new RN_Producto();
        DataTable dt = new DataTable();
        public Frm_Explo_Kardex()
        {
            InitializeComponent();
        }
        
        public string TipoVenta ;
        
        private void Frm_Listar_Producto_Compra_Load(object sender, EventArgs e)
        {
            Configurar_listView();
            Cargar_Todos_Productos();
            txt_buscar.Focus();
            dtp_Inicial.Value = DateTime.Now;
            dtp_Final.Value = DateTime.Now;
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
        private void Cargar_Todos_Productos()
        {
            RN_Kardex n_krdx = new RN_Kardex();
            DataTable dt = new DataTable();
            dt = n_krdx.RN_Buscar_ProductoKardex(dtp_Inicial.Value,dtp_Final.Value,"");
            if (dt.Rows.Count >= 0)
            {
                Llenar_ListView(dt);
            }
            else
            {
                List_Krdx.Items.Clear();
            }
        }
        private void Configurar_listView()
        {
            var lis = List_Krdx;
            List_Krdx.Items.Clear();
            lis.Columns.Clear();
            lis.View = View.Details;
            lis.GridLines = true;
            lis.FullRowSelect = true;
            lis.Scrollable = true;
            lis.HideSelection = false;
            //CONFIGURAR COLUMNA
            lis.Columns.Add("ITEM", 50, HorizontalAlignment.Center).Text.Trim();//0
            lis.Columns.Add("FECHA EMI.", 100, HorizontalAlignment.Left).Text.Trim();//0
            lis.Columns.Add("DOC. SOPORTE", 120, HorizontalAlignment.Left).Text.Trim();//1
            lis.Columns.Add("DETALLE MOVIMIENTO", 240, HorizontalAlignment.Left).Text.Trim();//2
            lis.Columns.Add("ENTRADA", 80, HorizontalAlignment.Left).Text.Trim();//3
            lis.Columns.Add("SALIDA", 80, HorizontalAlignment.Left).Text.Trim();//4
            lis.Columns.Add("SALDOS", 80, HorizontalAlignment.Left).Text.Trim();//5
            lis.Columns.Add("PRODUCTO", 275, HorizontalAlignment.Left).Text.Trim();//6
           
        }
        private void Llenar_ListView(DataTable dt)
        {
            try
            {
                List_Krdx.Items.Clear();
                for ( int i = 0; i < dt.Rows.Count; i ++)
                {
                    DataRow dr = dt.Rows[i];
                    ListViewItem list = new ListViewItem(dr["item"].ToString().Trim());
                    list.SubItems.Add(dr["fecha"].ToString().Trim());
                    list.SubItems.Add(dr["docSoporte"].ToString().Trim());
                    list.SubItems.Add(dr["detMovimiento"].ToString().Trim());
                    list.SubItems.Add(dr["entrada"].ToString().Trim());
                    list.SubItems.Add(dr["salida"].ToString().Trim());
                    list.SubItems.Add(dr["saldo"].ToString().Trim());
                    list.SubItems.Add(dr["Descripcion_larga"].ToString().Trim());
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
            Buscar_Producto(txt_buscar.Text);
        }
        private void txt_buscar_KeyUp(object sender, KeyEventArgs e)
        {
            Buscar_Producto(txt_buscar.Text);
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
       
        private void Buscar_Producto(string valor)
        {
            RN_Kardex n_krdx = new RN_Kardex();
            dt = n_krdx.RN_Buscar_ProductoKardex(dtp_Inicial.Value, dtp_Final.Value,valor);
           
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

        private void btn_add2_Click(object sender, EventArgs e)
        {
            Cargar_Todos_Productos();
        }

        private void pnl_msn_Paint(object sender, PaintEventArgs e)
        {

        }
        Principal.Frm_Filtro fil = new Principal.Frm_Filtro();
        private void btn_imprimir_Click(object sender, EventArgs e)
        {
            Informe.Frm_Print_Kardex krdx = new Informe.Frm_Print_Kardex();

            fil.Show();
            krdx.lbl_fi.Text = dtp_Inicial.Value.ToString();
            krdx.lbl_ff.Text = dtp_Final.Value.ToString();
            krdx.ShowDialog();
            fil.Hide();
            
        }

        private void kardexDelDiaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RN_Kardex n_krdx = new RN_Kardex();
            dt = n_krdx.RN_Buscar_ProductoKardex(DateTime.Now, DateTime.Now, "");
            dtp_Inicial.Value = DateTime.Now;
            dtp_Final.Value = DateTime.Now;
            if (dt.Rows.Count >= 0)
            {
                Llenar_ListView(dt);
            }
            else
            {
                List_Krdx.Items.Clear();
            }
        }

        private void kardexDelMesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RN_Kardex n_krdx = new RN_Kardex();
            DateTime date = DateTime.Now;
            DateTime oPrimerDiaDelMes = new DateTime(date.Year, date.Month, 1);
            DateTime oUltimoDiaDelMes = oPrimerDiaDelMes.AddMonths(1).AddDays(-1);

            dtp_Inicial.Value = oPrimerDiaDelMes;
            dtp_Final.Value = oUltimoDiaDelMes;

            dt = n_krdx.RN_Buscar_ProductoKardex(oPrimerDiaDelMes, oUltimoDiaDelMes, "");
            if (dt.Rows.Count >= 0)
            {
                Llenar_ListView(dt);
            }
            else
            {
                List_Krdx.Items.Clear();
            }
        }
    }
}
