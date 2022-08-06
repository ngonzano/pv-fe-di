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


namespace Microsell_Lite.Ventas
{
    public partial class Frm_Explo_Credito : Form
    {
        DataTable dt = new DataTable();
        public Frm_Explo_Credito()
        {
            InitializeComponent();
        }
        
        public string TipoVenta ;
        private void Frm_Explo_Credito_Load(object sender, EventArgs e)
        {
            dtp_Inicial.Value = DateTime.Now;
            dtp_Final.Value = DateTime.Now;
            Configurar_listView();
            Cargar_Todo_Creditos();
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
            var lis = lsv_Credito;
            lsv_Credito.Items.Clear();
            lis.Columns.Clear();
            lis.View = View.Details;
            lis.GridLines = true;
            lis.FullRowSelect = true;
            lis.Scrollable = true;
            lis.HideSelection = false;
            //CONFIGURAR COLUMNA
            lis.Columns.Add("ID. CRE.", 100, HorizontalAlignment.Center).Text.Trim();//0
            lis.Columns.Add("FECHA CREDITO", 150, HorizontalAlignment.Left).Text.Trim();//1
            lis.Columns.Add("CLIENTE - RAZON SOCIAL", 200, HorizontalAlignment.Left).Text.Trim();//2
            lis.Columns.Add("TOTAL CREDITO", 80, HorizontalAlignment.Left).Text.Trim();//3
            lis.Columns.Add("SALDO PDNTE.", 80, HorizontalAlignment.Left).Text.Trim();//4
            lis.Columns.Add("EST. CRED.", 100, HorizontalAlignment.Left).Text.Trim();//5
            lis.Columns.Add("DOCUMENTO", 100, HorizontalAlignment.Left).Text.Trim();//6
            lis.Columns.Add("EST. DOCUM.", 80, HorizontalAlignment.Left).Text.Trim();//7
            lis.Columns.Add("TOTAL UTIL", 80, HorizontalAlignment.Left).Text.Trim();//8
            lis.Columns.Add("LIM. CREDITO", 80, HorizontalAlignment.Left).Text.Trim();//9
            lis.Columns.Add("DNI", 80, HorizontalAlignment.Left).Text.Trim();//10
        }
        private void Llenar_ListView(DataTable dt)
        {
            try
            {
                lsv_Credito.Items.Clear();
                for ( int i = 0; i < dt.Rows.Count; i ++)
                {
                    DataRow dr = dt.Rows[i];
                    ListViewItem list = new ListViewItem(dr["IdNotaCred"].ToString().Trim());
                    list.SubItems.Add(dr["Fecha_Credito"].ToString().Trim());
                    list.SubItems.Add(dr["Nom_Cliente"].ToString().Trim());
                    list.SubItems.Add(dr["Total_Cre"].ToString().Trim());
                    list.SubItems.Add(dr["Saldo_Pdnte"].ToString().Trim());
                    list.SubItems.Add(dr["Estado_Cred"].ToString().Trim());
                    list.SubItems.Add(dr["id_Doc"].ToString().Trim());
                    list.SubItems.Add(dr["Estado_Doc"].ToString().Trim());
                    list.SubItems.Add(dr["TotalGancia"].ToString().Trim());
                    list.SubItems.Add(dr["Limit_Credit"].ToString().Trim());
                    list.SubItems.Add(dr["DNI"].ToString().Trim());

                    lsv_Credito.Items.Add(list);// SI NO SE PONE ESTO EL LIST VIEW NO SE LLENARA
                    
                    pintar_listView();
                }
                lbl_items.Text = lsv_Credito.Items.Count.ToString();
            }
            catch (Exception)
            {
                throw;
            }

        }
        public void pintar_listView() //pintar vertical
        { 
            for (int i = 0; i < lsv_Credito.Items.Count; i++)
            {
                lsv_Credito.Items[i].SubItems[5].BackColor = Color.LightGray;
                lsv_Credito.Items[i].SubItems[2].BackColor = Color.Azure;
                lsv_Credito.Items[i].SubItems[3].BackColor = Color.Ivory;
                lsv_Credito.Items[i].SubItems[4].BackColor = Color.MintCream;

                lsv_Credito.Items[i].SubItems[2].Font = new System.Drawing.Font("Verdana",10,FontStyle.Bold);
                lsv_Credito.Items[i].SubItems[5].Font = new System.Drawing.Font("Verdana", 10, FontStyle.Bold);

                lsv_Credito.Items[i].UseItemStyleForSubItems = false;
            }
        }
        public void Cargar_Todo_Creditos()
        {
            RN_Credito cre = new RN_Credito();
            dt = cre.RN_Mostrar_TodoCredito(dtp_Inicial.Value,dtp_Final.Value,"");
            if (dt.Rows.Count >= 0)
            {
                Llenar_ListView(dt);
            }
            else
            {
                lsv_Credito.Items.Clear();
            }
        }
        private void txt_buscar_KeyDown(object sender, KeyEventArgs e)
        {
            RN_Credito cre = new RN_Credito();
            dt = cre.RN_Mostrar_TodoCredito(dtp_Inicial.Value, dtp_Final.Value, txt_buscar.Text);
            if (dt.Rows.Count >= 0)
            {
                Llenar_ListView(dt);
            }
            else
            {
                lsv_Credito.Items.Clear();
            }
        }
        private void txt_buscar_KeyUp(object sender, KeyEventArgs e)
        {
            RN_Credito cre = new RN_Credito();
            dt = cre.RN_Mostrar_TodoCredito(dtp_Inicial.Value, dtp_Final.Value, txt_buscar.Text);
            if (dt.Rows.Count >= 0)
            {
                Llenar_ListView(dt);
            }
            else
            {
                lsv_Credito.Items.Clear();
            }
        }               
        private void txt_buscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar==(int)Keys.Enter)
            {
                if (lsv_Credito.Items.Count > 0)
                {
                    lsv_Credito.Focus();
                    lsv_Credito.Items[0].Selected = true;
                }
            }
        }      
        private void Buscar_Credito(string valor)
        {
            RN_Credito cre = new RN_Credito();
            dt = cre.RN_Mostrar_TodoCredito(dtp_Inicial.Value,dtp_Final.Value,valor);
            if (dt.Rows.Count >= 0)
            {
                Llenar_ListView(dt);
            }
            else
            {
                lsv_Credito.Items.Clear();
            }

        }
        private void btn_add2_Click(object sender, EventArgs e)
        {
            RN_Credito cre = new RN_Credito();
            dt = cre.RN_Mostrar_TodoCredito(dtp_Inicial.Value, dtp_Final.Value, txt_buscar.Text);
            if (dt.Rows.Count >= 0)
            {
                Llenar_ListView(dt);
            }
            else
            {
                lsv_Credito.Items.Clear();
            }
        }
        private void cotizacionPorDiaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RN_Credito cre = new RN_Credito();
            dt = cre.RN_Mostrar_Credito_Dia(DateTime.Now);
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
                lsv_Credito.Items.Clear();
                pnl_msn.Visible = true;
            }
        }
        private void cotizacionPorMesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RN_Credito cre = new RN_Credito();
            dt = cre.RN_Mostrar_Credito_Mes(DateTime.Now);
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
                lsv_Credito.Items.Clear();
                pnl_msn.Visible = true;
            }
        }
        Principal.Frm_Filtro fil = new Principal.Frm_Filtro();
        Utilitarios.Frm_Advertencia adv = new Utilitarios.Frm_Advertencia();
       

        private void lsv_Credito_MouseDoubleClick(object sender, MouseEventArgs e)
        {

            Frm_DetCredito cre = new Frm_DetCredito();

            var lis = lsv_Credito.SelectedItems[0];
            string idDoc = lis.SubItems[0].Text;
            fil.Show();
            cre.Tag = idDoc;
            cre.ShowDialog();
            fil.Hide();
        }

        private void pagarDeudaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lsv_Credito.SelectedItems.Count == 0)
            {
                fil.Show();
                adv.lbl_msm.Text = "Seleccionar el Credito para su Abono.";
                adv.ShowDialog();
                fil.Hide();
            }
            else
            {
                var lis = lsv_Credito.SelectedItems[0];
                string idDoc = lis.SubItems[0].Text;
                string nomCli = lis.SubItems[2].Text;
                double totalMonto = Convert.ToDouble(lis.SubItems[3].Text);
                double SaldoPendiente = Convert.ToDouble(lis.SubItems[4].Text);
                DateTime fechaInici = Convert.ToDateTime(lis.SubItems[1].Text);

                if (lsv_Credito.SelectedItems.Count == 0)
                {
                    fil.Show();
                    adv.lbl_msm.Text = "Seleccionar el Credito para su Abono.";
                    adv.ShowDialog();
                    fil.Hide();
                }
                else
                {
                    if (SaldoPendiente != 0)
                    {
                        Frm_PagoDeuda deu = new Frm_PagoDeuda();

                        deu.lbl_codCredito.Text = idDoc;
                        deu.lbl_NomCliente.Text = nomCli;
                        deu.lbl_totalCredito.Text = totalMonto.ToString();
                        deu.lbl_Abono.Text = (totalMonto - SaldoPendiente).ToString();
                        deu.lbl_saldoPendiente.Text = SaldoPendiente.ToString();
                        deu.lbl_FechaCredito.Text = fechaInici.ToString();

                        fil.Show();
                        deu.ShowDialog();
                        Cargar_Todo_Creditos();
                        fil.Hide();
                    }
                    else
                    {
                        fil.Show();
                        adv.lbl_msm.Text = "El credito ya se encuentra cancelado.";
                        adv.ShowDialog();
                        fil.Hide();
                    }
                }
                }
        }
    }
}
