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

namespace Microsell_Lite.Utilitarios
{
    public partial class Frm_Marca : Form
    {
        public Frm_Marca()
        {
            InitializeComponent();
        }
        RN_Marca obj = new RN_Marca();
        private void Frm_Reg_Prod_Load(object sender, EventArgs e)
        {
            Configurar_listView();
            Cargar_Todos_Marca();
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

        private void gru_det_Click(object sender, EventArgs e)
        {

        }

        private void pnl_titu_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
        private void Configurar_listView()
        {
            var lis = lsv_Marca;
            lsv_Marca.Items.Clear();
            lis.Columns.Clear();
            lis.View = View.Details;
            lis.GridLines = false;
            lis.FullRowSelect = true;
            lis.Scrollable = true;
            lis.HideSelection = false;
            //CONFIGURAR COLUMNA
            lis.Columns.Add("ID",40,HorizontalAlignment.Left);//0
            lis.Columns.Add("NOMBRE DE MARCA", 350, HorizontalAlignment.Left);//1
        }

        private void lsv_categ_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void Llenar_ListView(DataTable dt)
        {
            lsv_Marca.Items.Clear();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];
                ListViewItem list = new ListViewItem(dr["Id_Marca"].ToString());
                list.SubItems.Add(dr["Marca"].ToString());
                lsv_Marca.Items.Add(list);// SI NO SE PONE ESTO EL LIST VIEW NO SE LLENARA
            }

        }
        private void Cargar_Todos_Marca()
        {
            DataTable dt = new DataTable();
            dt = obj.RN_Mostrar_Todas_Marca();
            if (dt.Rows.Count>0)
            {
                Llenar_ListView(dt);
            }
            else
            {
                lsv_Marca.Items.Clear();
            }
        }

        private void pb_add_Click(object sender, EventArgs e)
        {
            pnl_add.Visible = true;
            lsv_Marca.Visible = false;
            txt_IDMarca.Focus();
            editar = false;
            txt_IDMarca.Text = "";
            txt_NomMarca.Text = "";
        }

        public bool editar = false;
        private void pb_edit_Click(object sender, EventArgs e)
        {
            
            if (lsv_Marca.SelectedIndices.Count==0)
            {
                MessageBox.Show("Seleccione la Marca para editar", "Ediar Marca", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else
            {
                var lsv = lsv_Marca.SelectedItems[0];
                txt_IDMarca.Text = lsv.SubItems[0].Text;
                txt_NomMarca.Text = lsv.SubItems[1].Text;

                pnl_add.Visible = true;
                txt_NomMarca.Focus();
                editar = true;
            }
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            lsv_Marca.Visible = true;
            pnl_add.Visible = false;
            txt_IDMarca.Text = "";
            txt_NomMarca.Text = "";
        }

        private void btn_listo_Click(object sender, EventArgs e)
        {
            if (txt_NomMarca.Text.Trim().Length <= 0 )
            {
                MessageBox.Show("Ingresar nombre de la Marca","Registrar Marca",MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (editar==false)
            {
                //NUEVO
                obj.RN_Registrar_Marca(txt_NomMarca.Text.ToString());
                pnl_add.Visible = false;
                lsv_Marca.Visible = true;
                MessageBox.Show("La Marca se ha registrado correctamente", "MARCA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Cargar_Todos_Marca();
                txt_NomMarca.Text = "";
            }
            else
            {
                //EDITAR
                obj.RN_Editar_Marca(Convert.ToInt32(txt_IDMarca.Text), txt_NomMarca.Text.ToString());
                pnl_add.Visible = false;
                lsv_Marca.Visible = true;
                MessageBox.Show("La Marca se ha registrado correctamente", "MARCA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Cargar_Todos_Marca();
                txt_NomMarca.Text = "";
                editar = false;
            }
            
        }

        private void bt_add_Click(object sender, EventArgs e)
        {

        }

        private void btn_cancel_MouseCaptureChanged(object sender, EventArgs e)
        {

        }

        private void pb_edit_MouseDown(object sender, MouseEventArgs e)
        {
            
        }

        private void pb_edit_MouseEnter(object sender, EventArgs e)
        {
            pb_edit.BackColor = Color.AliceBlue;
        }

        private void pb_edit_MouseLeave(object sender, EventArgs e)
        {
            pb_edit.BackColor = Color.White;
        }

        private void pb_add_MouseEnter(object sender, EventArgs e)
        {
            pb_add.BackColor = Color.AliceBlue;
        }

        private void pb_add_MouseLeave(object sender, EventArgs e)
        {
            pb_add.BackColor = Color.White;
        }

        private void txtCateg_TextChanged(object sender, EventArgs e)
        {

        }

        private void Pb_Eliminar_MouseLeave(object sender, EventArgs e)
        {
            Pb_Eliminar.BackColor = Color.White;
        }

        private void Pb_Eliminar_MouseEnter(object sender, EventArgs e)
        {
            Pb_Eliminar.BackColor = Color.AliceBlue;
        }

        private void Pb_Eliminar_Click(object sender, EventArgs e)
        {
            if (lsv_Marca.SelectedIndices.Count == 0)
            {
                MessageBox.Show("Seleccione la Marca para Eliminar", "Eliminar Marca", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else
            {
                var lsv = lsv_Marca.SelectedItems[0];
                txt_IDMarca.Text = lsv.SubItems[0].Text;

                Frm_SINO sino = new Frm_SINO();

                sino.lbl_msm.Text = "¿Estas seguro de Eliminar la Marca?";
                sino.ShowDialog();

                if (sino.Tag.ToString()=="SI")
                {
                    obj.RN_Eliminar_Marca(Convert.ToInt32(txt_IDMarca.Text));
                    MessageBox.Show("La Marca se ha registrado correctamente", "MARCA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Cargar_Todos_Marca();
                }

            }
        }

        private void pb_Seleccionar_Click(object sender, EventArgs e)
        {
            if (lsv_Marca.SelectedIndices.Count == 0)
            {
                MessageBox.Show("Seleccione una Marca", "Advertencia de Seguridad", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else
            {
                var lsv = lsv_Marca.SelectedItems[0];
                txt_IDMarca.Text = lsv.SubItems[0].Text;
                txt_NomMarca.Text= lsv.SubItems[1].Text;

                this.Tag = "A";
                this.Close();
            }
        }

        private void lsv_Marca_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            pb_Seleccionar_Click(sender, e);
        }

        private void lsv_Marca_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Enter)
            {
                pb_Seleccionar_Click(sender, e);
            }
            
        }

        private void pb_Seleccionar_MouseEnter(object sender, EventArgs e)
        {
            pb_Seleccionar.BackColor = Color.AliceBlue;
        }

        private void pb_Seleccionar_MouseLeave(object sender, EventArgs e)
        {
            pb_Seleccionar.BackColor = Color.White;
        }
    }
}
