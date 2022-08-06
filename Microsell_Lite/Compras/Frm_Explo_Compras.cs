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


namespace Microsell_Lite.Compras
{
    public partial class Frm_Explo_Compras : Form
    {
        RN_IngresoCompra obj = new RN_IngresoCompra();
        public Frm_Explo_Compras()
        {
            InitializeComponent();
            Configurar_listView();
            dtp_Inicial.Value = DateTime.Now;
            dtp_Final.Value = DateTime.Now;
            Cargar_Todos_Compras();

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

        }

       

        private void Pb_Editar_Click(object sender, EventArgs e)
        {
            Principal.Frm_Filtro fil = new Principal.Frm_Filtro();
            Utilitarios.Frm_Advertencia adv = new Utilitarios.Frm_Advertencia();
            Producto.Frm_EditProducto e_pro = new Producto.Frm_EditProducto();

            if (Lsv_Compras.SelectedItems.Count == 0)
            {
                fil.Show();
                adv.lbl_msm.Text = "Seleccionar el Item que deseas Editar.";
                adv.ShowDialog();
                fil.Hide();
                //fil.Close();
            }
            else
            {
                var lis = Lsv_Compras.SelectedItems[0];
                string idProd = lis.SubItems[0].Text;
                fil.Show();
                e_pro.Tag = idProd;
                e_pro.ShowDialog();
                fil.Hide();
                if (e_pro.Tag.ToString() == "A")
                {
                    Cargar_Todos_Compras();
                }
            }
        }

        private void Pb_Elimi_Click(object sender, EventArgs e)
        {

        }

        private void Pb_Agregar_Click(object sender, EventArgs e)
        {
            Principal.Frm_Filtro fil = new Principal.Frm_Filtro();
            Frm_Compras addCom = new Frm_Compras();

            fil.Show();
            addCom.ShowDialog();
            fil.Hide();
            if (addCom.Tag.ToString() == "A")
            {
                Cargar_Todos_Compras();
            }
        }

        private void Pb_bProve_Click(object sender, EventArgs e)
        {

        }


      
        private void Configurar_listView()
        {
            var lis = Lsv_Compras;
            Lsv_Compras.Items.Clear();
            lis.Columns.Clear();
            lis.View = View.Details;
            lis.GridLines = true;
            lis.FullRowSelect = true;
            lis.Scrollable = true;
            lis.HideSelection = false;
            //CONFIGURAR COLUMNA
            lis.Columns.Add("ID Interno", 98, HorizontalAlignment.Center);//0
            lis.Columns.Add("Num. Fisico", 125, HorizontalAlignment.Left);//1
            lis.Columns.Add("Nombre del Proveedor", 170, HorizontalAlignment.Left);//2
            lis.Columns.Add("Fecha Compra", 112, HorizontalAlignment.Left);//3
            lis.Columns.Add("Importe S/.", 103, HorizontalAlignment.Left);//4
            lis.Columns.Add("Forma Pago", 103, HorizontalAlignment.Center);//5
            lis.Columns.Add("Tipo Ingreso", 105, HorizontalAlignment.Center);//6
            lis.Columns.Add("Tipo Documento", 116, HorizontalAlignment.Center);//7
            lis.Columns.Add("Estado Compra", 109, HorizontalAlignment.Center);//6
        }

        //LLenar listView
        private void Llenar_ListView(DataTable dt)
        {
            Lsv_Compras.Items.Clear();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];
                ListViewItem list = new ListViewItem(dr["Id_DocComp"].ToString().Trim());
                list.SubItems.Add(dr["NroFac_Fisico"].ToString());
                list.SubItems.Add(dr["NOMBRE"].ToString());
                list.SubItems.Add(dr["Fecha_Ingre"].ToString());
                list.SubItems.Add(dr["Total_Ingre"].ToString());
                list.SubItems.Add(dr["ModalidadPago"].ToString());
                list.SubItems.Add(dr["Tipo_Ingreso"].ToString());
                list.SubItems.Add(dr["TipoDoc_Compra"].ToString());
                list.SubItems.Add(dr["Estado_Ingre"].ToString());
                Lsv_Compras.Items.Add(list);// SI NO SE PONE ESTO EL LIST VIEW NO SE LLENARA
            }
            pintar_listView();
            lblcont.Text = Lsv_Compras.Items.Count.ToString();
        }
        private void Cargar_Todos_Compras()
        {
            DataTable dt = new DataTable();
            dt = obj.RN_MostrarTodoCompras_Explo(dtp_Inicial.Value,dtp_Final.Value,"");
            if (dt.Rows.Count >= 0)
            {
                Llenar_ListView(dt);
                pnl_msn.Visible = false;
            }
            else
            {
                Lsv_Compras.Items.Clear();
                pnl_msn.Visible = true;
            }
        }
        private void Buscar_Compra(string valor)
        {
            DataTable dt = new DataTable();
            dt = obj.RN_MostrarTodoCompras_Explo(dtp_Inicial.Value, dtp_Final.Value, valor);
            if (dt.Rows.Count >= 0)
            {
                Llenar_ListView(dt);
            }
            else
            {
                Lsv_Compras.Items.Clear();
            }
        }

        void Buscar_Producto2()
        {
            if (txt_buscar.Text.Trim().Length >= 1)
            {
                Buscar_Compra(txt_buscar.Text);
                if (Lsv_Compras.Items.Count == 0)
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
                Cargar_Todos_Compras();
                pnl_msn.Visible = false;
            }
        }
        private void txtBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            Buscar_Producto2();
        }

        private void bt_copiarIDProveedor_Click(object sender, EventArgs e)
        {
            Principal.Frm_Filtro fil = new Principal.Frm_Filtro();
            Utilitarios.Frm_Advertencia adv = new Utilitarios.Frm_Advertencia();

            if (Lsv_Compras.SelectedItems.Count == 0)
            {
                fil.Show();
                adv.lbl_msm.Text = "Seleccionar el Item que deseas copiar.";
                adv.ShowDialog();
                fil.Hide();
                //fil.Close();
            }
            else
            {
                var lis = Lsv_Compras.SelectedItems[0];
                string idProv = lis.SubItems[0].Text;
                Clipboard.Clear();
                Clipboard.SetText(idProv.Trim());
            }
           
        }

        private void nuevoProveedorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Pb_Agregar_Click(sender, e);
        }

        private void editarProveedorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Pb_Editar_Click(sender,e);
        }

        private void Pb_bProve_Click_1(object sender, EventArgs e)
        {

        }

        private void txtBuscar_KeyUp(object sender, KeyEventArgs e)
        {
            Buscar_Producto2();
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
            for (int i = 0; i < Lsv_Compras.Items.Count; i++)
            {
                if (cont % 2 != 0)
                {
                    Lsv_Compras.Items[i].BackColor = Color.MintCream;
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
                Buscar_Producto2();
            }
        }

        private void mostrarProveedorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txt_buscar.Text = "";
            Buscar_Producto2();
        }

        private void lblcont_Click(object sender, EventArgs e)
        {

        }

        private void pnl_msn_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txt_buscar_KeyDown(object sender, KeyEventArgs e)
        {
            Buscar_Producto2();
        }

        private void txt_buscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                Buscar_Producto2();
            }
        }

        private void txt_buscar_KeyUp(object sender, KeyEventArgs e)
        {
            Buscar_Producto2();
        }

        private void mostrarComprasDelDiaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Principal.Frm_Filtro fil = new Principal.Frm_Filtro();
            Utilitarios.Frm_SoloFecha solo_f = new Utilitarios.Frm_SoloFecha();
            DateTime date = DateTime.Now;
            DateTime oPrimerDiaDelMes = new DateTime(date.Year, date.Month, 1);
            DateTime oUltimoDiaDelMes = oPrimerDiaDelMes.AddMonths(1).AddDays(-1);

            dtp_Inicial.Value = date;
            dtp_Final.Value = date;
            //fil.Show();
            //solo_f.ShowDialog();
            //fil.Hide();
            Buscar_Compra_DIA(date);

            //if (solo_f.Tag.ToString()=="A")
            //{
            //    DateTime xfecha = solo_f.dtp_fecha.Value;
            //    Buscar_Compra_DIA(xfecha);
            //}

        }
        private void Buscar_Compra_DIA(DateTime fechax)
        {
            DataTable dt = new DataTable();
            dt = obj.RN_Buscar_Compras_Expl_MES_DIA("dia",fechax);
            if (dt.Rows.Count > 0)
            {
                Llenar_ListView(dt);
                pnl_msn.Visible = false;
            }
            else
            {
                Lsv_Compras.Items.Clear();
                pnl_msn.Visible = true;
            }
        }
        private void Buscar_Compra_MES(DateTime fechax)
        {
            DataTable dt = new DataTable();
            dt = obj.RN_Buscar_Compras_Expl_MES_DIA("mes", fechax);
            if (dt.Rows.Count > 0)
            {
                Llenar_ListView(dt);
                pnl_msn.Visible = false;
            }
            else
            {
                Lsv_Compras.Items.Clear();
                pnl_msn.Visible = true;
            }
        }

        private void mostarComprasDelMesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Principal.Frm_Filtro fil = new Principal.Frm_Filtro();
            Utilitarios.Frm_SoloFecha solo_f = new Utilitarios.Frm_SoloFecha();
            DateTime date = DateTime.Now;
            DateTime oPrimerDiaDelMes = new DateTime(date.Year, date.Month, 1);
            DateTime oUltimoDiaDelMes = oPrimerDiaDelMes.AddMonths(1).AddDays(-1);

            dtp_Inicial.Value = oPrimerDiaDelMes;
            dtp_Final.Value = oUltimoDiaDelMes;
            //fil.Show();
            //solo_f.ShowDialog();
            //fil.Hide();
            Buscar_Compra_MES(date);
            //if (solo_f.Tag.ToString() == "A")
            //{
            //    DateTime xfecha = solo_f.dtp_fecha.Value;
            //    Buscar_Compra_MES(xfecha);
            //}
        }

        private void Lsv_Compras_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Principal.Frm_Filtro fil = new Principal.Frm_Filtro();
            Utilitarios.Frm_Advertencia adv = new Utilitarios.Frm_Advertencia();
            Frm_DetCompra detC = new Frm_DetCompra();

            if (Lsv_Compras.SelectedItems.Count == 0)
            {
                fil.Show();
                adv.lbl_msm.Text = "Seleccionar el Item que deseas Editar.";
                adv.ShowDialog();
                fil.Hide();
                //fil.Close();
            }
            else
            {
                var lis = Lsv_Compras.SelectedItems[0];
                string idCompra = lis.SubItems[0].Text;
                fil.Show();
                detC.Tag = idCompra;
                detC.ShowDialog();
                fil.Hide();
                
            }
        }

        private void btn_Consultar_Click(object sender, EventArgs e)
        {
            Cargar_Todos_Compras();
        }
    }
}
