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


namespace Microsell_Lite.Productos
{
    public partial class Frm_Explo_Producto : Form
    {
        RN_Producto obj = new RN_Producto();
        public Frm_Explo_Producto()
        {
            InitializeComponent();
            

        }
        private void btn_cerrar_Click(object sender, EventArgs e)
        {
            Principal.Frm_Principal pri = new Principal.Frm_Principal();
            pri.bt_almacen.IconColor = Color.Green;
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
            Cargar_Todos_Productos();
        }

        private void Pb_Editar_MouseEnter(object sender, EventArgs e)
        {
            Pb_Editar.BackColor = Color.LightGray;
        }

        private void Pb_Editar_MouseLeave(object sender, EventArgs e)
        {
            Pb_Editar.BackColor = Color.Gray;
        }

        private void Pb_Agregar_MouseEnter(object sender, EventArgs e)
        {
            Pb_Agregar.BackColor = Color.LightGray;
        }

        private void Pb_Agregar_MouseLeave(object sender, EventArgs e)
        {
            Pb_Agregar.BackColor = Color.Gray;
        }



        private void Pb_Editar_Click(object sender, EventArgs e)
        {
            Principal.Frm_Filtro fil = new Principal.Frm_Filtro();
            Utilitarios.Frm_Advertencia adv = new Utilitarios.Frm_Advertencia();
            Producto.Frm_EditProducto e_pro = new Producto.Frm_EditProducto();

            if (List_Producto.SelectedItems.Count == 0)
            {
                fil.Show();
                adv.lbl_msm.Text = "Seleccionar el Item que deseas Editar.";
                adv.ShowDialog();
                fil.Hide();
                //fil.Close();
            }
            else
            {
                var lis = List_Producto.SelectedItems[0];
                string idProd = lis.SubItems[0].Text;
                fil.Show();
                e_pro.Tag = idProd;
                e_pro.ShowDialog();
                fil.Hide();
                if (e_pro.Tag.ToString() == "A")
                {
                    Cargar_Todos_Productos();
                }
            }
        }

        private void Pb_Elimi_Click(object sender, EventArgs e)
        {

        }

        private void Pb_Agregar_Click(object sender, EventArgs e)
        {
            Principal.Frm_Filtro fil = new Principal.Frm_Filtro();
            Producto.Frm_AddProducto addPro = new Producto.Frm_AddProducto();

            fil.Show();
            addPro.ShowDialog();
            fil.Hide();
            if (addPro.Tag.ToString() == "A")
            {
                Cargar_Todos_Productos();
            }
        }

        private void Pb_bProve_Click(object sender, EventArgs e)
        {

        }

        private void Configurar_listView()
        {
            var lis = List_Producto;
            List_Producto.Items.Clear();
            lis.Columns.Clear();
            lis.View = View.Details;
            lis.GridLines = true;
            lis.FullRowSelect = true;
            lis.Scrollable = true;
            lis.HideSelection = false;
            //CONFIGURAR COLUMNA
            lis.Columns.Add("ID PROD.", 100, HorizontalAlignment.Left);//0
            lis.Columns.Add("NOMBRE DE PRODUCTO", 205, HorizontalAlignment.Left);//1
            lis.Columns.Add("STOCK ACTUAL", 95, HorizontalAlignment.Left);//2
            lis.Columns.Add("PRECIO COMPRA", 115, HorizontalAlignment.Left);//3
            lis.Columns.Add("MARGEN", 70, HorizontalAlignment.Left);//4
            lis.Columns.Add("PRE. VENTA1", 95, HorizontalAlignment.Left);//5
            lis.Columns.Add("PRE. VENTA2", 95, HorizontalAlignment.Left);//6
            lis.Columns.Add("UTILIDAD", 70, HorizontalAlignment.Left);//7
            lis.Columns.Add("TOTAL", 70, HorizontalAlignment.Left);//6
            lis.Columns.Add("ESTADO", 60, HorizontalAlignment.Left);//7
            lis.Columns.Add("Marca", 100, HorizontalAlignment.Left);//7
        }

        //LLenar listView
        private void Llenar_ListView(DataTable dt)
        {
            List_Producto.Items.Clear();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];
                ListViewItem list = new ListViewItem(dr["Id_Pro"].ToString().Trim());
                list.SubItems.Add(dr["Descripcion_Larga"].ToString());
                list.SubItems.Add(dr["Stock_Actual"].ToString());
                list.SubItems.Add(dr["Pre_CompraS"].ToString());
                list.SubItems.Add(dr["Frank"].ToString());
                list.SubItems.Add(dr["Pre_vntaxMenor"].ToString());
                list.SubItems.Add(dr["Pre_vntaxMayor"].ToString());
                list.SubItems.Add(dr["UtilidadUnit"].ToString());
                list.SubItems.Add(dr["Valor_porCant"].ToString());
                list.SubItems.Add(dr["Estado_Pro"].ToString());
                list.SubItems.Add(dr["Marca"].ToString());
                List_Producto.Items.Add(list);// SI NO SE PONE ESTO EL LIST VIEW NO SE LLENARA
            }
            pintar_listView();
            lblcont.Text = List_Producto.Items.Count.ToString();
        }
        private void Cargar_Todos_Productos()
        {
            DataTable dt = new DataTable();
            dt = obj.RN_Mostrar_Todas_Producto();
            if (dt.Rows.Count >= 0)
            {
                Llenar_ListView(dt);
            }
            else
            {
                List_Producto.Items.Clear();
            }
        }
        private void Buscar_Producto(string valor)
        {
            DataTable dt = new DataTable();
            dt = obj.RN_Buscar_Producto(valor);
            if (dt.Rows.Count >= 0)
            {
                Llenar_ListView(dt);
            }
            else
            {
                List_Producto.Items.Clear();
            }
        }

        void Buscar_Producto2()
        {
            if (txt_buscar.Text.Trim().Length >= 1)
            {
                Buscar_Producto(txt_buscar.Text);
                if (List_Producto.Items.Count == 0)
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
                Cargar_Todos_Productos();
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

            if (List_Producto.SelectedItems.Count == 0)
            {
                fil.Show();
                adv.lbl_msm.Text = "Seleccionar el Item que deseas copiar.";
                adv.ShowDialog();
                fil.Hide();
                //fil.Close();
            }
            else
            {
                var lis = List_Producto.SelectedItems[0];
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

        private void List_Proveedor_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Pb_bProve_Click_1(object sender, EventArgs e)
        {

        }

        private void txtBuscar_KeyUp(object sender, KeyEventArgs e)
        {
            Buscar_Producto2();
        }

        private void label4_Click(object sender, EventArgs e)
        {

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
            for (int i = 0; i < List_Producto.Items.Count; i++)
            {
                if (cont % 2 != 0)
                {
                    List_Producto.Items[i].BackColor = Color.Linen;
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
        Principal.Frm_Filtro fil = new Principal.Frm_Filtro();
        private void importarProductosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Principal.Frm_Exptar_Producto exp = new Principal.Frm_Exptar_Producto();
            fil.Show();
            exp.ShowDialog();
            Cargar_Todos_Productos();
            fil.Hide();
        }
    }
}
