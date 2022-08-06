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

namespace Microsell_Lite.Ventas
{
    public partial class Frm_DetVenta : Form
    {
        public Frm_DetVenta()
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
            var lis = lsv_DetVenta;
            lsv_DetVenta.Items.Clear();
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
            RN_Documento n_doc = new RN_Documento();
            DataTable dt = new DataTable();

            dt = n_doc.RN_Buscar_Documento_y_Detalle(valor.Trim());

            if (dt.Rows.Count>0)
            {
                lsv_DetVenta.Items.Clear();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow dr = dt.Rows[i];
                    ListViewItem list = new ListViewItem(dr["Id_Doc"].ToString().Trim());
                    list.SubItems.Add(dr["Id_Pro"].ToString().Trim());
                    list.SubItems.Add(dr["Descripcion_Larga"].ToString().Trim());
                    list.SubItems.Add(dr["Precio_ConIgv"].ToString().Trim());
                    list.SubItems.Add(dr["Cantidad"].ToString().Trim());
                    list.SubItems.Add(dr["Importe_ConIgv"].ToString().Trim());
                    lsv_DetVenta.Items.Add(list);// SI NO SE PONE ESTO EL LIST VIEW NO SE LLENARA
                }
                pintar_listView();
            }
        }
        void pintar_listView()
        {
            int cont = 1;
            for (int i = 0; i < lsv_DetVenta.Items.Count; i++)
            {
                if (cont % 2 != 0)
                {
                    lsv_DetVenta.Items[i].BackColor = Color.MintCream;
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
