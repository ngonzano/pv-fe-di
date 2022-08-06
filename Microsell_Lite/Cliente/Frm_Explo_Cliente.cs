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


namespace Microsell_Lite.Cliente
{
    public partial class Frm_Explo_Cliente : Form
    {
        RN_cliente n_cli = new RN_cliente();
        public Frm_Explo_Cliente()
        {
            InitializeComponent();
            Configurar_listView();
            Cargar_Todos_Clientes();
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

        private void Pb_Editar_MouseEnter(object sender, EventArgs e)
        {
           
        }

        private void Pb_Editar_MouseLeave(object sender, EventArgs e)
        {
            
        }

       
        private void Pb_Editar_Click(object sender, EventArgs e)
        {
            Principal.Frm_Filtro fil = new Principal.Frm_Filtro();
            Utilitarios.Frm_Advertencia adv = new Utilitarios.Frm_Advertencia();
            Cliente.Frm_EditCliente frm_Edit = new Cliente.Frm_EditCliente();

            if (List_Cliente.SelectedItems.Count == 0)
            {
                fil.Show();
                adv.lbl_msm.Text = "Seleccionar el Item que deseas Editar.";
                adv.ShowDialog();
                fil.Hide();
                //fil.Close();
            }
            else
            {
                var lis = List_Cliente.SelectedItems[0];
                string idProd = lis.SubItems[0].Text;
                fil.Show();
                frm_Edit.Tag = idProd;
                frm_Edit.ShowDialog();
                fil.Hide();
                if (frm_Edit.Tag.ToString() == "A")
                {
                    Cargar_Todos_Clientes();
                }
            }
        }

        private void Pb_Elimi_Click(object sender, EventArgs e)
        {

        }

        private void Pb_Agregar_Click(object sender, EventArgs e)
        {
            Principal.Frm_Filtro fil = new Principal.Frm_Filtro();
            Cliente.Frm_AddCliente addPro = new Cliente.Frm_AddCliente();

            fil.Show();
            addPro.ShowDialog();
            fil.Hide();
            if (addPro.Tag.ToString() == "A")
            {
                Cargar_Todos_Clientes();
            }
        }
       
        private void Configurar_listView()
        {
            var lis = List_Cliente;
            List_Cliente.Items.Clear();
            lis.Columns.Clear();
            lis.View = View.Details;
            lis.GridLines = true;
            lis.FullRowSelect = true;
            lis.Scrollable = true;
            lis.HideSelection = false;
            //CONFIGURAR COLUMNA
            lis.Columns.Add("ID CLIENTE", 100, HorizontalAlignment.Left);//0
            lis.Columns.Add("DATOS DEL CLIENTE", 205, HorizontalAlignment.Left);//1
            lis.Columns.Add("DNI", 95, HorizontalAlignment.Left);//2
            lis.Columns.Add("DIRECCION", 142, HorizontalAlignment.Left);//3
            lis.Columns.Add("TELEFONO", 93, HorizontalAlignment.Left);//4
            lis.Columns.Add("SALDO VALE", 100, HorizontalAlignment.Left);//5
            lis.Columns.Add("CORREO", 100, HorizontalAlignment.Left);//6
            lis.Columns.Add("ESTADO", 70, HorizontalAlignment.Left);//7
        }
        //LLenar listView
        private void Llenar_ListView(DataTable dt)
        {
            List_Cliente.Items.Clear();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];
                ListViewItem list = new ListViewItem(dr["Id_Cliente"].ToString().Trim());
                list.SubItems.Add(dr["Razon_Social_Nombres"].ToString());
                list.SubItems.Add(dr["DNI"].ToString());
                list.SubItems.Add(dr["Direccion"].ToString());
                list.SubItems.Add(dr["Telefono"].ToString());
                list.SubItems.Add(dr["Limit_Credit"].ToString());
                list.SubItems.Add(dr["E_Mail"].ToString());
                list.SubItems.Add(dr["Estado_Cli"].ToString());
                List_Cliente.Items.Add(list);// SI NO SE PONE ESTO EL LIST VIEW NO SE LLENARA
            }
            pintar_listView();
            lblcont.Text = List_Cliente.Items.Count.ToString();
        }
        private void Cargar_Todos_Clientes()
        {
            DataTable dt = new DataTable();
            dt = n_cli.RN_Listar_Todos_clientes("Activo");
            if (dt.Rows.Count >= 0)
            {
                Llenar_ListView(dt);
            }
            else
            {
                List_Cliente.Items.Clear();
            }
        }
        private void Buscar_Cliente(string valor)
        {
            DataTable dt = new DataTable();
            dt = n_cli.RN_Listar_clientes_Valor(valor,"Activo");
            if (dt.Rows.Count >= 0)
            {
                Llenar_ListView(dt);
            }
            else
            {
                List_Cliente.Items.Clear();
            }
        }
        void Buscar_Cliente2()
        {
            if (txt_buscar.Text.Trim().Length >= 1)
            {
                Buscar_Cliente(txt_buscar.Text);
                if (List_Cliente.Items.Count == 0)
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
                Cargar_Todos_Clientes();
                pnl_msn.Visible = false;
            }
        }
        private void txtBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            Buscar_Cliente2();
        }
        private void txtBuscar_KeyUp(object sender, KeyEventArgs e)
        {
            Buscar_Cliente2();
        }
        void pintar_listView()
        {
            int cont = 1;
            for (int i = 0; i < List_Cliente.Items.Count; i++)
            {
                if (cont % 2 != 0)
                {
                    List_Cliente.Items[i].BackColor = Color.Linen;
                }
                i++;
            }
        }
        #region No util
        private void label14_Click(object sender, EventArgs e)
        {

        }
        private void pnl_titu_Paint(object sender, PaintEventArgs e)
        {

        }
        private void label15_Click(object sender, EventArgs e)
        {

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
        private void txtBuscar_OnValueChanged(object sender, EventArgs e)
        {

        }
        private void lblcont_Click(object sender, EventArgs e)
        {

        }
        private void List_Cliente_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void pnl_msn_Paint(object sender, PaintEventArgs e)
        {

        }
        #endregion
        private void txtBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                Buscar_Cliente2();
            }
        }
        private void txt_buscar_KeyDown(object sender, KeyEventArgs e)
        {
            Buscar_Cliente2();
        }
        private void txt_buscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                Buscar_Cliente2();
            }
        }
        private void txt_buscar_KeyUp(object sender, KeyEventArgs e)
        {
            Buscar_Cliente2();
        }
        private void nuevoClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Pb_Agregar2_Click(sender, e);
        }
        private void editarClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Pb_Editar2_Click(sender, e);
        }
        private void mostrarClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txt_buscar.Text = "";
            Buscar_Cliente2();
        }
        private void bt_copiarIDCliente_Click(object sender, EventArgs e)
        {
            Principal.Frm_Filtro fil = new Principal.Frm_Filtro();
            Utilitarios.Frm_Advertencia adv = new Utilitarios.Frm_Advertencia();

            if (List_Cliente.SelectedItems.Count == 0)
            {
                fil.Show();
                adv.lbl_msm.Text = "Seleccionar el Item que deseas copiar.";
                adv.ShowDialog();
                fil.Hide();
                //fil.Close();
            }
            else
            {
                var lis = List_Cliente.SelectedItems[0];
                string idProv = lis.SubItems[0].Text;
                Clipboard.Clear();
                Clipboard.SetText(idProv.Trim());
            }
        }

        private void Pb_Editar2_Click(object sender, EventArgs e)
        {
            Principal.Frm_Filtro fil = new Principal.Frm_Filtro();
            Utilitarios.Frm_Advertencia adv = new Utilitarios.Frm_Advertencia();
            Cliente.Frm_EditCliente frm_Edit = new Cliente.Frm_EditCliente();

            if (List_Cliente.SelectedItems.Count == 0)
            {
                fil.Show();
                adv.lbl_msm.Text = "Seleccionar el Item que deseas Editar.";
                adv.ShowDialog();
                fil.Hide();
                //fil.Close();
            }
            else
            {
                var lis = List_Cliente.SelectedItems[0];
                string idProd = lis.SubItems[0].Text;
                fil.Show();
                frm_Edit.Tag = idProd;
                frm_Edit.ShowDialog();
                fil.Hide();
                if (frm_Edit.Tag.ToString() == "A")
                {
                    Cargar_Todos_Clientes();
                }
            }
        }

        private void Pb_Editar2_MouseEnter(object sender, EventArgs e)
        {

        }

        private void Pb_Editar2_MouseLeave(object sender, EventArgs e)
        {

        }

        private void Pb_Agregar2_Click(object sender, EventArgs e)
        {
            Principal.Frm_Filtro fil = new Principal.Frm_Filtro();
            Cliente.Frm_AddCliente addPro = new Cliente.Frm_AddCliente();

            fil.Show();
            addPro.ShowDialog();
            fil.Hide();
            if (addPro.Tag.ToString() == "A")
            {
                Cargar_Todos_Clientes();
            }
        }

        private void Pb_Agregar2_MouseEnter(object sender, EventArgs e)
        {

        }

        private void Pb_Agregar2_MouseLeave(object sender, EventArgs e)
        {

        }

        private void iconButton2_Click(object sender, EventArgs e)
        {

        }
    }
}
