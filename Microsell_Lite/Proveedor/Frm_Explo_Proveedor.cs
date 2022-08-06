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


namespace Microsell_Lite.Proveedor
{
    public partial class Frm_Explo_Proveedor : Form
    {
        RN_Proveedor obj = new RN_Proveedor();
        public Frm_Explo_Proveedor()
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
        void Buscar_Proveedor2()
        {
            if (txtBuscar.Text.Trim().Length >= 1)
            {
                Buscar_Proveedores(txtBuscar.Text);
                if (List_Proveedor.Items.Count == 0)
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
                Cargar_Todos_Proveedores();
                pnl_msn.Visible = false;
            }
        }
        private void bunifuMaterialTextbox1_OnValueChanged(object sender, EventArgs e)
        {
            if (txtBuscar.Text.Trim().Length > 1)
            {
                Buscar_Proveedores(txtBuscar.Text);
               
            }
        }

        private void Frm_Explo_Proveedor_Load(object sender, EventArgs e)
        {
            Configurar_listView();
            Cargar_Todos_Proveedores();
        }

        
        private void Pb_Editar_Click(object sender, EventArgs e)
        {
            Principal.Frm_Filtro fil = new Principal.Frm_Filtro();
            Utilitarios.Frm_Advertencia adv = new Utilitarios.Frm_Advertencia();
            Proveedor.Frm_EditProveedor e_pro = new Proveedor.Frm_EditProveedor();

            if (List_Proveedor.SelectedItems.Count == 0)
            {
                fil.Show();
                adv.lbl_msm.Text = "Seleccionar el Item que deseas Editar.";
                adv.ShowDialog();
                fil.Hide();
                //fil.Close();
            }
            else
            {
                var lis = List_Proveedor.SelectedItems[0];
                string idProv = lis.SubItems[0].Text;
                fil.Show();
                e_pro.Tag = idProv;
                e_pro.ShowDialog();
                fil.Hide();
                if (e_pro.Tag.ToString() == "A")
                {
                    Cargar_Todos_Proveedores();
                }
            }
        }
        private void Pb_Agregar_Click(object sender, EventArgs e)
        {
            Principal.Frm_Filtro fil = new Principal.Frm_Filtro();
            Proveedor.Frm_AddProveedor addPro = new Proveedor.Frm_AddProveedor();

            fil.Show();
            addPro.ShowDialog();
            fil.Hide();
            if (addPro.Tag.ToString() == "A")
            {
                Cargar_Todos_Proveedores();
            }
        }

        private void Configurar_listView()
        {
            var lis = List_Proveedor;
            List_Proveedor.Items.Clear();
            lis.Columns.Clear();
            lis.View = View.Details;
            lis.GridLines = true;
            lis.FullRowSelect = true;
            lis.Scrollable = true;
            lis.HideSelection = false;
            //CONFIGURAR COLUMNA
            lis.Columns.Add("ID PROV.", 85, HorizontalAlignment.Left);//0
            lis.Columns.Add("NOMBRE DE PROVEDOR", 176, HorizontalAlignment.Left);//1
            lis.Columns.Add("DIRECCION", 180, HorizontalAlignment.Left);//2
            lis.Columns.Add("TELEFONO", 80, HorizontalAlignment.Left);//3
            lis.Columns.Add("RUBRO", 120, HorizontalAlignment.Left);//4
            lis.Columns.Add("RUC - DNI", 85, HorizontalAlignment.Left);//5
            lis.Columns.Add("CORREO", 200, HorizontalAlignment.Left);//6
            lis.Columns.Add("CONTACTO", 174, HorizontalAlignment.Left);//7
        }

        //LLenar listView
        private void Llenar_ListView(DataTable dt)
        {
            List_Proveedor.Items.Clear();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];
                ListViewItem list = new ListViewItem(dr["IDPROVEE"].ToString());
                list.SubItems.Add(dr["NOMBRE"].ToString());
                list.SubItems.Add(dr["DIRECCION"].ToString());
                list.SubItems.Add(dr["TELEFONO"].ToString());
                list.SubItems.Add(dr["RUBRO"].ToString());
                list.SubItems.Add(dr["RUC"].ToString());
                list.SubItems.Add(dr["CORREO"].ToString());
                list.SubItems.Add(dr["CONTACTO"].ToString());
                List_Proveedor.Items.Add(list);// SI NO SE PONE ESTO EL LIST VIEW NO SE LLENARA
            }
            pintar_listView();
            lblcont.Text = List_Proveedor.Items.Count.ToString();

        }
        private void Cargar_Todos_Proveedores()
        {
            DataTable dt = new DataTable();
            dt = obj.RN_Mostrar_Todas_Proveedor();
            if (dt.Rows.Count >= 0)
            {
                Llenar_ListView(dt);
            }
            else
            {
                List_Proveedor.Items.Clear();
            }
        }
        private void Buscar_Proveedores(string valor)
        {
            DataTable dt = new DataTable();
            dt = obj.BN_Buscar_Proveedor(valor);
            if (dt.Rows.Count >= 0)
            {
                Llenar_ListView(dt);
            }
            else
            {
                List_Proveedor.Items.Clear();
            }
        }

        private void txtBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            Buscar_Proveedor2();
        }

        private void bt_copiarIDProveedor_Click(object sender, EventArgs e)
        {
            Principal.Frm_Filtro fil = new Principal.Frm_Filtro();
            Utilitarios.Frm_Advertencia adv = new Utilitarios.Frm_Advertencia();

            if (List_Proveedor.SelectedItems.Count == 0)
            {
                fil.Show();
                adv.lbl_msm.Text = "Seleccionar el Item que deseas copiar.";
                adv.ShowDialog();
                fil.Hide();
                //fil.Close();
            }
            else
            {
                var lis = List_Proveedor.SelectedItems[0];
                string idProv = lis.SubItems[0].Text;
                Clipboard.Clear();
                Clipboard.SetText(idProv.Trim());
            }
        }

        private void nuevoProveedorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Pb_Agregar2_Click(sender, e);
        }

        private void editarProveedorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Pb_Editar2_Click(sender,e);
        }


        private void txtBuscar_KeyUp(object sender, KeyEventArgs e)
        {
            Buscar_Proveedor2();
        }

        void pintar_listView()
        {
            int cont = 1;
            for (int i = 0; i < List_Proveedor.Items.Count; i++)
            {
                if (cont % 2 != 0)
                {
                    List_Proveedor.Items[i].BackColor = Color.MintCream;
                }
                i++;
            }
        }

        private void Frm_Explo_Proveedor_KeyDown(object sender, KeyEventArgs e)
        {
            if ((int)(e.KeyData) == (int)(Keys.Control) + (int)(Keys.B))
            {
                txtBuscar.Focus();
            }
        }

        private void Pb_Agregar2_Click(object sender, EventArgs e)
        {
            Principal.Frm_Filtro fil = new Principal.Frm_Filtro();
            Proveedor.Frm_AddProveedor addPro = new Proveedor.Frm_AddProveedor();

            fil.Show();
            addPro.ShowDialog();
            fil.Hide();
            if (addPro.Tag.ToString() == "A")
            {
                Cargar_Todos_Proveedores();
            }
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {

        }

        private void Pb_Editar2_Click(object sender, EventArgs e)
        {
            Principal.Frm_Filtro fil = new Principal.Frm_Filtro();
            Utilitarios.Frm_Advertencia adv = new Utilitarios.Frm_Advertencia();
            Proveedor.Frm_EditProveedor e_pro = new Proveedor.Frm_EditProveedor();

            if (List_Proveedor.SelectedItems.Count == 0)
            {
                fil.Show();
                adv.lbl_msm.Text = "Seleccionar el Item que deseas Editar.";
                adv.ShowDialog();
                fil.Hide();
                //fil.Close();
            }
            else
            {
                var lis = List_Proveedor.SelectedItems[0];
                string idProv = lis.SubItems[0].Text;
                fil.Show();
                e_pro.Tag = idProv;
                e_pro.ShowDialog();
                fil.Hide();
                if (e_pro.Tag.ToString() == "A")
                {
                    Cargar_Todos_Proveedores();
                }
            }
        }

        private void mostrarProveedorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cargar_Todos_Proveedores();
        }

        private void bunifuSeparator6_Load(object sender, EventArgs e)
        {

        }
    }
}
