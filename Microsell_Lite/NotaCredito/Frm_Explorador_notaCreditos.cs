using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsell_Lite.Utilitarios;
using Microsell_Lite.Productos;
using Microsell_Lite.Ventas;
using Microsell_Lite.Cliente;
using SPV_Capa_Negocio;
using Microsell_Lite.Principal;

namespace Microsell_Lite.NotaCredito
{
    public partial class Frm_Explorador_notaCreditos : Form
    {
        public Frm_Explorador_notaCreditos()
        {
            InitializeComponent();
        }

        private void Frm_Explor_Proveedor_Load(object sender, EventArgs e)
        {
            Configurar_listView();
            buscar_Documento_pordia();
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

        private void btn_minimi_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        //configurar nuestro listview:

        private void Configurar_listView()
        {
            var lis = lsv_com;

            lsv_com.Items.Clear();
            lis.Columns.Clear();
            lis.View = View.Details;
            lis.GridLines = false;
            lis.FullRowSelect = true;
            lis.Scrollable = true;
            lis.HideSelection = false;
            //configurar las columnas:
            lis.Columns.Add("ID Doc.", 100, HorizontalAlignment.Left); //0  
            lis.Columns.Add("Fecha Emi", 90, HorizontalAlignment.Left);  //3
            lis.Columns.Add("Nombre Cliente", 250, HorizontalAlignment.Left);  //2           
            lis.Columns.Add("Motivo", 250, HorizontalAlignment.Left);  //4
            lis.Columns.Add("Tipo Doc.", 90, HorizontalAlignment.Left);  //1
            lis.Columns.Add("Estado Din.", 90, HorizontalAlignment.Left);  //1           
            lis.Columns.Add("Total S/", 90, HorizontalAlignment.Right);  //1
            lis.Columns.Add("Estado Cdr", 120, HorizontalAlignment.Center);  //1
            lis.Columns.Add("ID Doc. Sunat", 115, HorizontalAlignment.Center); //0 
        }
        //llenar el listview:
        private void Llenar_Listview(DataTable data)
        {
            lsv_com.Items.Clear();

            for (int i = 0; i < data.Rows.Count; i++)
            {
                DataRow dr = data.Rows[i];
                ListViewItem list = new ListViewItem(dr["Id_Cre"].ToString());
                list.SubItems.Add(dr["Fecha_Emision"].ToString());
                list.SubItems.Add(dr["Razon_Social_Nombres"].ToString());
                list.SubItems.Add(dr["Motivo_Emis"].ToString());
                list.SubItems.Add(dr["Tipocomprobnte"].ToString());
                list.SubItems.Add(dr["EstadoDinero"].ToString());
                list.SubItems.Add(dr["Vlr_Total"].ToString());
                list.SubItems.Add(dr["CdrSunat_NotaCre"].ToString());
                list.SubItems.Add(dr["NC_Enviado_Sunat"].ToString());

                lsv_com.Items.Add(list); //si no podemos esto., el listview nunca se llenara
            }
            Pintar_Filas();
            pnl_msm.Visible = false;
            lbl_totallItem.Text = lsv_com.Items.Count.ToString();
        }


        private void Pintar_Filas()
        {
            int cont = 1;

            for (int i = 0; i < lsv_com.Items.Count; i++)
            {
                if (cont % 2 == 0)
                {

                }
                else
                {
                    lsv_com.Items[i].BackColor = Color.WhiteSmoke;
                }
                cont += 1;

            }


        }




        private void Cargar_Todos_Ventas()
        {
            RN_Notacredito obj = new RN_Notacredito();
            DataTable dato = new DataTable();

            dato = obj.RN_Leer_Todas_notadecredito();
            if (dato.Rows.Count > 0)
            {
                Llenar_Listview(dato);
            }
            else
            {
                lsv_com.Items.Clear();
                pnl_msm.Visible = true;
            }

        }



        private void buscar_Docu_Ventas(string valor)
        {
            RN_Notacredito obj = new RN_Notacredito();
            DataTable dato = new DataTable();

            dato = obj.RN_Buscardor_Gneral_NotasCreditos(valor);
            if (dato.Rows.Count > 0)
            {
                Llenar_Listview(dato);
            }
            else
            {
                lsv_com.Items.Clear();
                pnl_msm.Visible = true;
            }

        }


        //por fechas:
        private void buscar_Documento_pordia()
        {
            RN_Notacredito obj = new RN_Notacredito();
            DataTable dato = new DataTable();

            dato = obj.RN_Leer_Todas_notadecredito_emitidosHOy();
            if (dato.Rows.Count > 0)
            {
                Llenar_Listview(dato);
            }
            else
            {
                lsv_com.Items.Clear();
                pnl_msm.Visible = true;
            }

        }

        //por mes:
        private void buscar_Ventas_porMes(DateTime fechax)
        {
            RN_Notacredito obj = new RN_Notacredito();
            DataTable dato = new DataTable();

            dato = obj.RN_Buscar_NotaCredito_Pormes(fechax);
            if (dato.Rows.Count > 0)
            {
                Llenar_Listview(dato);
            }
            else
            {
                lsv_com.Items.Clear();
                pnl_msm.Visible = true;
            }

        }

        private void txt_buscar_OnValueChanged(object sender, EventArgs e)
        {
            if (txt_buscar.Text.Trim().Length > 2)
            {
                buscar_Docu_Ventas(txt_buscar.Text);
            }
        }

        private void txt_buscar_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                if (txt_buscar.Text.Trim().Length > 2)
                {
                    buscar_Docu_Ventas(txt_buscar.Text);
                }
                else
                {
                    Cargar_Todos_Ventas();
                }



            }

        }

        private void bt_copiarIDProveedorTool_Click(object sender, EventArgs e)
        {
            Frm_Filtro fil = new Frm_Filtro();
            Frm_Advertencia ver = new Frm_Advertencia();

            if (lsv_com.SelectedIndices.Count == 0)
            {
                fil.Show();
                ver.lbl_msm.Text = "Selecciona le Item que deseas copiar";
                ver.ShowDialog();
                fil.Hide();
            }
            else
            {
                var lis = lsv_com.SelectedItems[0];
                string idprovee = lis.SubItems[8].Text;

                Clipboard.Clear();
                Clipboard.SetText(idprovee.Trim());
            }


        }





        private void mostrarTodosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cargar_Todos_Ventas();
        }



        private void cargaComprasDelDiaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            buscar_Documento_pordia();
            //Frm_Filtro fil = new Frm_Filtro();
            //Frm_SoloFecha solo = new Frm_SoloFecha();

            //fil.Show();
            //solo.ShowDialog();
            //fil.Hide();

            //if (solo.Tag .ToString() =="A")
            //{
            //    DateTime xfecha = solo.dtp_fecha.Value;

            //    buscar_Documento_pordia();


            //}


        }

        private void buscarComprasDelMesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_Filtro fil = new Frm_Filtro();
            Frm_SoloFecha solo = new Frm_SoloFecha();

            fil.Show();
            solo.ShowDialog();
            fil.Hide();

            if (solo.Tag.ToString() == "A")
            {
                DateTime xfecha = solo.dtp_fecha.Value;

                buscar_Ventas_porMes(xfecha);


            }
        }

        private void lsv_com_MouseDoubleClick(object sender, MouseEventArgs e)
        {

            //Frm_Filtro fil = new Frm_Filtro();
            //Frm_Advertencia ver = new Frm_Advertencia();
            //Frm_verDet_Doc edi = new Frm_verDet_Doc();

            //if (lsv_com.SelectedIndices.Count == 0)
            //{
            //    fil.Show();
            //    ver.Lbl_Msm1.Text = "Selecciona el Item";
            //    ver.ShowDialog();
            //    fil.Hide();
            //}
            //else
            //{
            //    var lis = lsv_com.SelectedItems[0];
            //    string idcompra = lis.SubItems[0].Text;

            //    fil.Show();
            //    edi.Tag = idcompra;
            //    edi.ShowDialog();
            //    fil.Hide();

            //}



        }
        private void bt_reimprimirDocumentoTool_Click(object sender, EventArgs e)
        {
            Frm_Filtro fil = new Frm_Filtro();
            Frm_Advertencia ver = new Frm_Advertencia();
            Frm_NotaCredito ven = new Frm_NotaCredito();

            if (lsv_com.SelectedIndices.Count == 0)
            {
                fil.Show();
                ver.lbl_msm.Text = "Selecciona el Item que deseas Reimprimir";
                ver.ShowDialog();
                fil.Hide();
            }
            else
            {
                var lis = lsv_com.SelectedItems[0];
                string iddoc = lis.SubItems[0].Text;
                fil.Show();
                ven.Txt_buscarFac.Text = iddoc;
                // ven.cbo_MotivoEmis.SelectedIndex = 4;
                ven.ShowDialog();
                fil.Hide();

            }



        }

        private void canjearNotaVentaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void cambiarClienteAlDocumentoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //

        }

        private void bt_anularDocumentoTool_Click(object sender, EventArgs e)
        {
            //Frm_Filtro fil = new Frm_Filtro();
            //Frm_Advertencia ver = new Frm_Advertencia();
            //RN_Documento obj = new RN_Documento();
            //RN_CAja objca = new RN_CAja();

            //if (lsv_com.SelectedIndices.Count == 0)
            //{
            //    fil.Show();
            //    ver.Lbl_Msm1.Text = "Selecciona le Item que deseas Anular";
            //    ver.ShowDialog();
            //    fil.Hide();
            //}
            //else
            //{
            //    var lis = lsv_com.SelectedItems[0];
            //    string idDoc = lis.SubItems[0].Text;

            //    obj.BD_Anular_Documento(idDoc, "Anulado");
            //    objca.RN_anular_Movimiento_Caja(idDoc);

            //    Cargar_Todos_Ventas();


            //}
        }

        private void bt_enviarNCredSunatTool_Click(object sender, EventArgs e)
        {
            Frm_Send_NC_FC nc = new Frm_Send_NC_FC();
            Frm_Filtro fil = new Frm_Filtro();
            fil.Show();

            var lis = lsv_com.SelectedItems[0];
            string idprovee = lis.SubItems[8].Text;

            nc.Txt_buscarFac.Text = idprovee.Trim();
            nc.ShowDialog();
            fil.Hide();
        }



        //Codigo de Baja:












    }
}
