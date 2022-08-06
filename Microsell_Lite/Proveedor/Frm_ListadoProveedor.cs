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

    public partial class Frm_ListadoProveedor : Form
    {
        RN_Proveedor n_prov = new RN_Proveedor();
        public Frm_ListadoProveedor()
        {
            InitializeComponent();
        }

        private void Frm_ListadoProveedor_Load(object sender, EventArgs e)
        {
            Configurar_listView();
            Cargar_Todos_Proveedores();
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
            this.Tag = "";
            this.Close();
        }
        private void Configurar_listView()
        {
            var lis = lsv_Proveedor;
            lsv_Proveedor.Items.Clear();
            lis.Columns.Clear();
            lis.View = View.Details;
            lis.GridLines = false;
            lis.FullRowSelect = true;
            lis.Scrollable = true;
            lis.HideSelection = false;
            //CONFIGURAR COLUMNA
            lis.Columns.Add("ID", 0, HorizontalAlignment.Left);//0
            lis.Columns.Add("NOMBRE DE PROVEEDOR", 450, HorizontalAlignment.Left);//1
        }
        private void Llenar_ListView(DataTable dt)
        {
            lsv_Proveedor.Items.Clear();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];
                ListViewItem list = new ListViewItem(dr["IDPROVEE"].ToString());
                list.SubItems.Add(dr["NOMBRE"].ToString());
                lsv_Proveedor.Items.Add(list);// SI NO SE PONE ESTO EL LIST VIEW NO SE LLENARA
            }

        }
        private void Cargar_Todos_Proveedores()
        {
            DataTable dt = new DataTable();
            dt = n_prov.RN_Mostrar_Todas_Proveedor();
            if (dt.Rows.Count > 0)
            {
                Llenar_ListView(dt);
            }
            else
            {
                lsv_Proveedor.Items.Clear();
            }
        }

        private void lsv_Proveedor_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (lsv_Proveedor.SelectedItems.Count == 0)
            {
                MessageBox.Show("Seleccione un Proveedor", "PROVEEDOR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                lbl_id.Text = lsv_Proveedor.SelectedItems[0].SubItems[0].Text;
                lbl_nomb.Text = lsv_Proveedor.SelectedItems[0].SubItems[1].Text;
                this.Tag = "A";
                this.Close();
            }
        }

        private void lsv_Proveedor_KeyDown(object sender, KeyEventArgs e)
        {
           
                if (e.KeyCode == Keys.Enter)
                {
                    if (lsv_Proveedor.SelectedItems.Count == 0)
                    {
                        MessageBox.Show("Seleccione un Proveedor", "PROVEEDOR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        lbl_id.Text = lsv_Proveedor.SelectedItems[0].SubItems[0].Text;
                        lbl_nomb.Text = lsv_Proveedor.SelectedItems[0].SubItems[1].Text;
                        this.Tag = "A";
                        this.Close();
                    }
                }
        }

        private void pnl_titu_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Pb_Agregar2_Click(object sender, EventArgs e)
        {
            Frm_AddProveedor add = new Frm_AddProveedor();
            add.ShowDialog();
            Cargar_Todos_Proveedores();
        }
    }
}
