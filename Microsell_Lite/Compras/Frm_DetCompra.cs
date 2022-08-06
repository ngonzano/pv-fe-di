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

namespace Microsell_Lite.Compras
{
    public partial class Frm_DetCompra : Form
    {
        public Frm_DetCompra()
        {
            InitializeComponent();
        }

        private void Frm_DetCompra_MouseMove(object sender, MouseEventArgs e)
        {
            Utilitario obj = new Utilitario();

            if (e.Button == MouseButtons.Left)
            {
                obj.Mover_formulario(this);

            }
        }
        private void Configurar_listView()
        {
            var lis = lsv_DetCompra;
            lsv_DetCompra.Items.Clear();
            lis.Columns.Clear();
            lis.View = View.Details;
            lis.GridLines = true;
            lis.FullRowSelect = true;
            lis.Scrollable = true;
            lis.HideSelection = false;
            //CONFIGURAR COLUMNA
            lis.Columns.Add("ID DOC.", 80, HorizontalAlignment.Left);//0
            lis.Columns.Add("ID PROD", 75, HorizontalAlignment.Left);//1
            lis.Columns.Add("DESCRIPCION DEL PRODUCTO", 150, HorizontalAlignment.Left);//2
            lis.Columns.Add("PRECIO UNIT", 75, HorizontalAlignment.Right);//3
            lis.Columns.Add("CANTIDAD", 75, HorizontalAlignment.Right);//4
            lis.Columns.Add("IMPORTE /S", 80, HorizontalAlignment.Right);
        }
        private void Llenar_ListView(string valor)
        {
            RN_IngresoCompra n_ing = new RN_IngresoCompra();
            DataTable dt = new DataTable();

            dt = n_ing.BD_Buscar_Documento_Detalle(valor.Trim());

            if (dt.Rows.Count>0)
            {
                lsv_DetCompra.Items.Clear();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow dr = dt.Rows[i];
                    ListViewItem list = new ListViewItem(dr["Id_DocComp"].ToString().Trim());
                    list.SubItems.Add(dr["Id_Pro"].ToString().Trim());
                    list.SubItems.Add(dr["Descripcion_Larga"].ToString().Trim());
                    list.SubItems.Add(dr["PrecioUnit"].ToString().Trim());
                    list.SubItems.Add(dr["Cantidad"].ToString().Trim());
                    list.SubItems.Add(dr["Importe"].ToString().Trim());
                    lsv_DetCompra.Items.Add(list);// SI NO SE PONE ESTO EL LIST VIEW NO SE LLENARA
                }
                pintar_listView();
            }
        }
        void pintar_listView()
        {
            int cont = 1;
            for (int i = 0; i < lsv_DetCompra.Items.Count; i++)
            {
                if (cont % 2 != 0)
                {
                    lsv_DetCompra.Items[i].BackColor = Color.MintCream;
                }
                i++;
            }
        }

        private void Frm_DetCompra_Load(object sender, EventArgs e)
        {
            Configurar_listView();
            Llenar_ListView(this.Tag.ToString());
        }

        private void btn_cerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pnl_titu_MouseMove(object sender, MouseEventArgs e)
        {
            Utilitario obj = new Utilitario();

            if (e.Button == MouseButtons.Left)
            {
                obj.Mover_formulario(this);

            }
        }
    }
}
