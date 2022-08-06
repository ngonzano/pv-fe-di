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


namespace Microsell_Lite.Ventas
{
    public partial class Frm_Explo_Documento : Form
    {
        RN_Documento n_doc = new RN_Documento();
        public Frm_Explo_Documento()
        {
            InitializeComponent();
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

        private void Frm_Explo_Proveedor_Load(object sender, EventArgs e)
        {
            Configurar_listView();
            Cargar_Todos_Ventas();
            dtp_Inicial.Value = DateTime.Now;
            dtp_Final.Value = DateTime.Now;
        }

       

        private void Pb_Editar_Click(object sender, EventArgs e)
        {
            Producto.Frm_EditProducto e_pro = new Producto.Frm_EditProducto();

            if (lsv_Documento.SelectedItems.Count == 0)
            {
                fil.Show();
                adv.lbl_msm.Text = "Seleccionar el Item que deseas Editar.";
                adv.ShowDialog();
                fil.Hide();
                //fil.Close();
            }
            else
            {
                var lis = lsv_Documento.SelectedItems[0];
                string idProd = lis.SubItems[0].Text;
                fil.Show();
                e_pro.Tag = idProd;
                e_pro.ShowDialog();
                fil.Hide();
                if (e_pro.Tag.ToString() == "A")
                {
                    Cargar_Todos_Ventas();
                }
            }
        }
        private void Configurar_listView()
        {
            var lis = lsv_Documento;
            lsv_Documento.Items.Clear();
            lis.Columns.Clear();
            lis.View = View.Details;
            lis.GridLines = true;
            lis.FullRowSelect = true;
            lis.Scrollable = true;
            lis.HideSelection = false;
            //CONFIGURAR COLUMNA
            lis.Columns.Add("ID DOC.", 100, HorizontalAlignment.Left);//0
            lis.Columns.Add("FECHA EMI.", 90, HorizontalAlignment.Left);//1
            lis.Columns.Add("NOMBRE CLIENTE", 150, HorizontalAlignment.Left);//2
            lis.Columns.Add("TIPO DOC.", 90, HorizontalAlignment.Left);//3
            lis.Columns.Add("NRO. PEDIDO", 100, HorizontalAlignment.Left);//4
            lis.Columns.Add("TIPO PAGO", 80, HorizontalAlignment.Left);//5
            lis.Columns.Add("TOTAL S/.", 75, HorizontalAlignment.Left);//6
            lis.Columns.Add("EST. DOC", 80, HorizontalAlignment.Left);//7

            lis.Columns.Add("CDR SUNAT", 90, HorizontalAlignment.Left);//6
            lis.Columns.Add("BAJA SUNAT", 90, HorizontalAlignment.Left);//7

            lis.Columns.Add("VENDEDOR", 100, HorizontalAlignment.Left);//6
        }

        //LLenar listView
        private void Llenar_ListView(DataTable dt)
        {
            lsv_Documento.Items.Clear();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];
                ListViewItem list = new ListViewItem(dr["id_Doc"].ToString().Trim());
                list.SubItems.Add(dr["Fecha_Emi"].ToString());
                list.SubItems.Add(dr["Razon_Social_Nombres"].ToString());
                list.SubItems.Add(dr["Documento"].ToString());
                list.SubItems.Add(dr["id_Ped"].ToString());
                list.SubItems.Add(dr["TipoPago"].ToString());
                list.SubItems.Add(dr["ImporteDoc"].ToString());
                list.SubItems.Add(dr["Estado_Doc"].ToString());

                list.SubItems.Add(dr["CDR_Sunat"].ToString());
                list.SubItems.Add(dr["EstadoBajada"].ToString());

                list.SubItems.Add(dr["NombreCompletoUsu"].ToString());
                lsv_Documento.Items.Add(list);// SI NO SE PONE ESTO EL LIST VIEW NO SE LLENARA
            }
            pintar_listView();
            lblcont.Text = lsv_Documento.Items.Count.ToString();
        }
        private void Cargar_Todos_Ventas()
        {
            DataTable dt = new DataTable();
            dt = n_doc.RN_BuscarDocumentoValor(dtp_Inicial.Value,dtp_Final.Value,"");
            if (dt.Rows.Count >= 0)
            {
                Llenar_ListView(dt);
            }
            else
            {
                lsv_Documento.Items.Clear();
            }
        }
        private void Buscar_Venta(string valor)
        {
            DataTable dt = new DataTable();
            dt = n_doc.RN_BuscarDocumentoValor(dtp_Inicial.Value,dtp_Final.Value, valor);
            if (dt.Rows.Count >= 0)
            {
                Llenar_ListView(dt);
            }
            else
            {
                lsv_Documento.Items.Clear();
            }
        }

        void Buscar_Venta2()
        {
            if (txt_buscar.Text.Trim().Length >= 1)
            {
                Buscar_Venta(txt_buscar.Text);
                if (lsv_Documento.Items.Count == 0)
                {
                    pnl_msn.Visible = true;
                }
                else
                {
                    pnl_msn.Visible = false;
                }
            }
            else
            {
                Cargar_Todos_Ventas();
                pnl_msn.Visible = false;
            }
        }
        private void txtBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            Buscar_Venta2();
        }


        private void txtBuscar_KeyUp(object sender, KeyEventArgs e)
        {
            Buscar_Venta2();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void bunifuSeparator1_Load(object sender, EventArgs e)
        {

        }
        void pintar_listView()
        {
            int cont = 1;
            for (int i = 0; i < lsv_Documento.Items.Count; i++)
            {
                if (cont % 2 != 0)
                {
                    lsv_Documento.Items[i].BackColor = Color.MintCream;
                }
                i++;
            }
        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void pnl_titu_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void txtBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                Buscar_Venta2();
            }
        }


        private void lblcont_Click(object sender, EventArgs e)
        {

        }

        private void txt_buscar_KeyDown(object sender, KeyEventArgs e)
        {
            Buscar_Venta2();
        }

        private void txt_buscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                Buscar_Venta2();
            }
        }

        private void txt_buscar_KeyUp(object sender, KeyEventArgs e)
        {
            Buscar_Venta2();
        }
 
        private void Buscar_Compra_DIA(DateTime fechax)
        {
           DataTable dt = new DataTable();
            dt = n_doc.RN_Buscar_Documento_Dia(fechax);
            if (dt.Rows.Count > 0)
            {
                Llenar_ListView(dt);
                pnl_msn.Visible = false;
            }
            else
            {
                lsv_Documento.Items.Clear();
                pnl_msn.Visible = true;
            }
        }
        private void Buscar_Compra_MES(DateTime fechax)
        {
            DataTable dt = new DataTable();
            dt = n_doc.RN_Buscar_Documento_Mes(fechax);
           
            if (dt.Rows.Count > 0)
            {
                Llenar_ListView(dt);
                pnl_msn.Visible = false;
            }
            else
            {
                lsv_Documento.Items.Clear();
                pnl_msn.Visible = true;
            }
        }
        Utilitarios.Frm_Advertencia adv = new Utilitarios.Frm_Advertencia();

        Principal.Frm_Filtro fil = new Principal.Frm_Filtro();
        Utilitarios.Frm_SoloFecha solo = new Utilitarios.Frm_SoloFecha();
        private void ventasPorMesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fil.Show();
            solo.ShowDialog();
            fil.Hide();
            DateTime date = DateTime.Now;
            DateTime oPrimerDiaDelMes = new DateTime(date.Year, date.Month, 1);
            DateTime oUltimoDiaDelMes = oPrimerDiaDelMes.AddMonths(1).AddDays(-1);

            dtp_Inicial.Value = oPrimerDiaDelMes;
            dtp_Final.Value = oUltimoDiaDelMes;
            if (solo.Tag.ToString()=="A")
            {
                DateTime xfecha = solo.dtp_fecha.Value;
                Buscar_Compra_MES(xfecha);
            }
        }

        private void ventasPorDiaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fil.Show();
            solo.ShowDialog();
            fil.Hide();
            DateTime date = DateTime.Now;
            DateTime oPrimerDiaDelMes = new DateTime(date.Year, date.Month, 1);
            DateTime oUltimoDiaDelMes = oPrimerDiaDelMes.AddMonths(1).AddDays(-1);

            dtp_Inicial.Value = date;
            dtp_Final.Value = date;
            if (solo.Tag.ToString() == "A")
            {
                DateTime xfecha = solo.dtp_fecha.Value;
                Buscar_Compra_DIA(xfecha); 
            }
        }

        private void imprimirDocumentoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //llamar a la venta o el documento que se haya generado
            //InicioTicket 
            Frm_Print_NotaVentaTicket nv_ticket = new Frm_Print_NotaVentaTicket();

            if (lsv_Documento.SelectedItems.Count == 0)
            {
                fil.Show();
                adv.lbl_msm.Text = "Seleccionar el Item que deseas Imprimir.";
                adv.ShowDialog();
                fil.Hide();
            }
            else
            {
                var lis = lsv_Documento.SelectedItems[0];
                string idDoc = lis.SubItems[0].Text;
                nv_ticket.lbl_nroDoc.Text = "Nota Venta: " + idDoc;
                nv_ticket.Tag = idDoc;
                nv_ticket.ShowDialog();
            }
        }

        private void lsv_Documento_MouseDoubleClick(object sender, MouseEventArgs e)
        {
             Frm_DetVenta dVen = new Frm_DetVenta();
            
            var lis = lsv_Documento.SelectedItems[0];
            string idDoc = lis.SubItems[0].Text;
            string estado = lis.SubItems[4].Text;
            if (estado!="Cancelado")
            {
                fil.Show();
                dVen.Tag = idDoc;
                dVen.ShowDialog();
                fil.Hide();
            }
            else
            {
                MessageBox.Show("El credito se encuentra Cancelado","Mensaje",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            
           
        }

        private void btn_add2_Click(object sender, EventArgs e)
        {
            Cargar_Todos_Ventas();
        }
    }
}
