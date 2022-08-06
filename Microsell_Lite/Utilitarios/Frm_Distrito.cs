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
    public partial class Frm_Distrito : Form
    {
        public Frm_Distrito()
        {
            InitializeComponent();
        }
        RN_Distrito obj = new RN_Distrito();
        private void Frm_Reg_Prod_Load(object sender, EventArgs e)
        {
            Configurar_listView();
            Cargar_Todos_Distrito();
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
            var lis = lsv_Dist;
            lsv_Dist.Items.Clear();
            lis.Columns.Clear();
            lis.View = View.Details;
            lis.GridLines = false;
            lis.FullRowSelect = true;
            lis.Scrollable = true;
            lis.HideSelection = false;
            //CONFIGURAR COLUMNA
            lis.Columns.Add("ID",40,HorizontalAlignment.Left);//0
            lis.Columns.Add("NOMBRE DE DISTRITO", 350, HorizontalAlignment.Left);//1
        }

        private void lsv_categ_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void Llenar_ListView(DataTable dt)
        {
            lsv_Dist.Items.Clear();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];
                ListViewItem list = new ListViewItem(dr["Id_Dis"].ToString());
                list.SubItems.Add(dr["Distrito"].ToString());
                lsv_Dist.Items.Add(list);// SI NO SE PONE ESTO EL LIST VIEW NO SE LLENARA
            }

        }
        private void Cargar_Todos_Distrito()
        {
            DataTable dt = new DataTable();
            dt = obj.RN_Mostrar_Todas_Distrito();
            if (dt.Rows.Count>0)
            {
                Llenar_ListView(dt);
            }
            else
            {
                lsv_Dist.Items.Clear();
            }
        }

        private void pb_add_Click(object sender, EventArgs e)
        {
            pnl_add.Visible = true;
            lsv_Dist.Visible = false;
            txt_IDDist.Focus();
            editar = false;
            txt_IDDist.Text = "";
            txtNomDist.Text = "";
        }

        public bool editar = false;
        private void pb_edit_Click(object sender, EventArgs e)
        {
            
            if (lsv_Dist.SelectedIndices.Count==0)
            {
                MessageBox.Show("Seleccione El Distrito para editar", "EDITAR DISTRITO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else
            {
                var lsv = lsv_Dist.SelectedItems[0];
                txt_IDDist.Text = lsv.SubItems[0].Text;
                txtNomDist.Text = lsv.SubItems[1].Text;

                pnl_add.Visible = true;
                txtNomDist.Focus();
                editar = true;
            }
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            lsv_Dist.Visible = true;
            pnl_add.Visible = false;
            txt_IDDist.Text = "";
            txtNomDist.Text = "";
        }

        private void btn_listo_Click(object sender, EventArgs e)
        {
            if (txtNomDist.Text.Trim().Length <= 0 )
            {
                MessageBox.Show("Ingresar nombre del Distrito","Registrar Distrito",MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (editar==false)
            {
                //NUEVO
                obj.RN_Registrar_Distrito(txtNomDist.Text.ToString());
                pnl_add.Visible = false;
                lsv_Dist.Visible = true;
                MessageBox.Show("El Distrito se ha registrado correctamente", "DISTRITO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Cargar_Todos_Distrito();
                txtNomDist.Text = "";
            }
            else
            {
                //EDITAR
                obj.RN_Editar_Distrito(Convert.ToInt32(txt_IDDist.Text), txtNomDist.Text.ToString());
                pnl_add.Visible = false;
                lsv_Dist.Visible = true;
                MessageBox.Show("El Distrito se ha Editado correctamente", "DISTRITO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Cargar_Todos_Distrito();
                txtNomDist.Text = "";
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
            if (lsv_Dist.SelectedIndices.Count == 0)
            {
                MessageBox.Show("Seleccione la Distrito para Eliminar", "Eliminar Distrito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else
            {
                var lsv = lsv_Dist.SelectedItems[0];
                txt_IDDist.Text = lsv.SubItems[0].Text;

                Frm_SINO sino = new Frm_SINO();

                sino.lbl_msm.Text = "¿Estas seguro de Eliminar la Distrito?";
                sino.ShowDialog();

                if (sino.Tag.ToString()=="SI")
                {
                    obj.RN_Eliminar_Distrito(Convert.ToInt32(txt_IDDist.Text));
                    MessageBox.Show("El Distrito se ha registrado correctamente", "DISTRITO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Cargar_Todos_Distrito();
                }

            }
        }
    }
}
