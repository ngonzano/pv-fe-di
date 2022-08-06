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
    public partial class Frm_DetCredito : Form
    {
        public Frm_DetCredito()
        {
            InitializeComponent();
           
        }
        private void Frm_DetCredito_Load(object sender, EventArgs e)
        {
            Configurar_listView();
            Llenar_ListView(this.Tag.ToString());
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
            var lis = lsv_DetCredito;
            lsv_DetCredito.Items.Clear();
            lis.Columns.Clear();
            lis.View = View.Details;
            lis.GridLines = true;
            lis.FullRowSelect = true;
            lis.Scrollable = true;
            lis.HideSelection = false;
            //CONFIGURAR COLUMNA
            lis.Columns.Add("ID. CRED.", 80, HorizontalAlignment.Left);//0
            lis.Columns.Add("A CUENTA", 80, HorizontalAlignment.Left);//1
            lis.Columns.Add("SALDO", 80, HorizontalAlignment.Left);//2
            lis.Columns.Add("FECHA MOV.", 75, HorizontalAlignment.Left);//3
            lis.Columns.Add("TP. PAGO", 75, HorizontalAlignment.Left);//4
            lis.Columns.Add("COMENTARIO", 150, HorizontalAlignment.Left);//5
        }
        private void Llenar_ListView(string valor)
        {
            RN_Credito cre = new RN_Credito();
            DataTable dt = new DataTable();

            dt = cre.RN_Mostrar_Detalle_Credito(valor.Trim());

            if (dt.Rows.Count>0)
            {
                lsv_DetCredito.Items.Clear();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow dr = dt.Rows[i];
                    ListViewItem list = new ListViewItem(dr["IdNotaCred"].ToString().Trim());
                    list.SubItems.Add(dr["A_cuenta"].ToString().Trim());
                    list.SubItems.Add(dr["Saldo_Actual"].ToString().Trim());
                    list.SubItems.Add(dr["Fecha_Pago"].ToString().Trim());
                    list.SubItems.Add(dr["TipoPago"].ToString().Trim());
                    list.SubItems.Add(dr["Nro_Opera_Coment"].ToString().Trim());
                    lsv_DetCredito.Items.Add(list);// SI NO SE PONE ESTO EL LIST VIEW NO SE LLENARA
                }
                pintar_listView();
            }
        }
        void pintar_listView()
        {
            int cont = 1;
            for (int i = 0; i < lsv_DetCredito.Items.Count; i++)
            {
                if (cont % 2 != 0)
                {
                    lsv_DetCredito.Items[i].BackColor = Color.MintCream;
                }
                i++;
            }
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
