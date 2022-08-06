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
using SPV_Capa_Entidad;
using Microsell_Lite.Proveedor;
using Microsell_Lite.Utilitarios;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net;
using System.IO;
using Microsell_Lite.Principal;
using System.Threading;

namespace Microsell_Lite.Cliente
{
    public partial class Frm_ListadoClientes : Form
    {

        public Frm_ListadoClientes()
        {
            InitializeComponent();
        }

        public string xxvalor = "";
        RN_cliente n_cli = new RN_cliente();
        EN_Cliente e_cli = new EN_Cliente();
        private void Frm_ListadoClientes_Load(object sender, EventArgs e)
        {
            Configurar_listView();
            if (xxvalor == "")
            {
                Cargar_Todos_Clientes();
            }
            else
            {
                Buscar_Cliente(xxvalor);
            }
        }
        void Buscar_Cliente2()
        {
            if (txt_buscar.Text.Trim().Length >= 1)
            {
                Buscar_Cliente(txt_buscar.Text);
            }
            else
            {
                Cargar_Todos_Clientes();
            }
        }
        private void Buscar_Cliente(string valor)
        {
            DataTable dt = new DataTable();
            dt = n_cli.RN_Listar_clientes_Valor(valor, "Activo");
            if (dt.Rows.Count >= 0)
            {
                Llenar_ListView(dt);
            }
            else
            {
                list_Cliente.Items.Clear();
            }
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Tag = "";
            this.Close();
        }

        private void elButton2_Click(object sender, EventArgs e)
        {
            this.Tag = "";
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
        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            PNL_AgregarCliente.Visible = false;
            Limpiar_text();
        }
        private void Configurar_listView()
        {
            var lis = list_Cliente;
            list_Cliente.Items.Clear();
            lis.Columns.Clear();
            lis.View = View.Details;
            lis.GridLines = false;
            lis.FullRowSelect = true;
            lis.Scrollable = true;
            lis.HideSelection = false;
            //CONFIGURAR COLUMNA
            lis.Columns.Add("ID CLIENTE", 0, HorizontalAlignment.Left);//0
            lis.Columns.Add("DATOS DEL CLIENTE", 215, HorizontalAlignment.Left);//1
            lis.Columns.Add("DNI", 140, HorizontalAlignment.Left);//2
            lis.Columns.Add("ESTADO", 100, HorizontalAlignment.Left);//2
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
                list_Cliente.Items.Clear();
            }
        }
        private void Llenar_ListView(DataTable dt)
        {
            list_Cliente.Items.Clear();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];
                ListViewItem list = new ListViewItem(dr["Id_Cliente"].ToString().Trim());
                list.SubItems.Add(dr["Razon_Social_Nombres"].ToString());
                list.SubItems.Add(dr["DNI"].ToString());
                list.SubItems.Add(dr["Estado_Cli"].ToString());
                list_Cliente.Items.Add(list);// SI NO SE PONE ESTO EL LIST VIEW NO SE LLENARA
            }
            pintar_listView();
            lblCantCliente.Text = list_Cliente.Items.Count.ToString();
        }
        void pintar_listView()
        {
            int cont = 1;
            for (int i = 0; i < list_Cliente.Items.Count; i++)
            {
                if (cont % 2 != 0)
                {
                    list_Cliente.Items[i].BackColor = Color.SeaShell;
                }
                i++;
            }
        }


        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pnl_titu_Paint(object sender, PaintEventArgs e)
        {

        }

        private void elLabel1_Click(object sender, EventArgs e)
        {

        }

        private void btn_agregar_Click(object sender, EventArgs e)
        {
            try
            {
                if (validar_textbox() == true)
                {
                    Registrar_Cliente();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        private void Registrar_Cliente()
        {
            try
            {
                e_cli.Idcliente = RN_TipoDoc.Sp_Listado_Tipo(8);
                e_cli.Razonsocial = txt_RasonSocial.Text;
                e_cli.Dni = txt_DNIRUC.Text;
                e_cli.Direccion = txt_Direccion.Text;
                e_cli.Telefono = "0";
                e_cli.Email = "-";
                e_cli.IdDis = 1;
                e_cli.FechaAniver = Convert.ToDateTime(dtp_aniv.Value);
                e_cli.Contacto = "";
                e_cli.LimiteCred = 50;
                e_cli.Foto = "-";

                if (n_cli.RN_Validar_Cliente(e_cli.Dni) == false)
                {
                    if (n_cli.RN_Registrar_Cliente(e_cli) == 1)
                    {
                        RN_TipoDoc.RN_Actualizar_SiguienteNro_correlativo(8);
                        txt_buscar.Text = txt_RasonSocial.Text;
                        Buscar_Cliente2();
                        Limpiar_text();
                        PNL_AgregarCliente.Visible = false;
                    }
                }
                else
                {
                    string NomCliente;
                    DataTable dt = new DataTable();
                    dt = n_cli.RN_Buscar_cliente(e_cli.Dni);
                    DataRow dr = dt.Rows[0];
                    NomCliente = dr["Razon_Social_Nombres"].ToString();
                    MessageBox.Show("El DNI " + e_cli.Dni + " ya se encuentra registrado por: " + NomCliente,
                        "CLIENTE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al Registrar msj:" + ex, "frm Cliente", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void Limpiar_text()
        {
            txt_idCliente.Text = "";
            txt_RasonSocial.Text = "";
            //txt_DNIRUC.Text = "";
            txt_Direccion.Text = "";

        }
        private void btn_new_Click(object sender, EventArgs e)
        {
            //txt_idCliente.Text = RN_TipoDoc.Sp_Listado_Tipo(8);
            PNL_AgregarCliente.Visible = true;
            txt_DNIRUC.Focus();

        }
        private bool validar_textbox()
        {
            Principal.Frm_Filtro fil = new Principal.Frm_Filtro();
            Frm_Advertencia adv = new Frm_Advertencia();
            if (txt_RasonSocial.Text.Trim().Length < 2) { fil.Show(); adv.lbl_msm.Text = "Ingresa Razon Social."; adv.ShowDialog(); fil.Hide(); txt_RasonSocial.Focus(); return false; }
            if (txt_DNIRUC.Text.Trim().Length < 2) { fil.Show(); adv.lbl_msm.Text = "Ingresa DNI o RUC."; adv.ShowDialog(); fil.Hide(); txt_DNIRUC.Focus(); return false; }
            if (txt_Direccion.Text.Trim().Length < 1) { fil.Show(); adv.lbl_msm.Text = "Ingrese la Direccion."; adv.ShowDialog(); fil.Hide(); txt_Direccion.Text = "0"; return false; }

            return true;
        }

        private void txt_buscar_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txt_buscar_KeyUp(object sender, KeyEventArgs e)
        {
            Buscar_Cliente2();
        }
        void SeleccionarCliente()
        {
            if (list_Cliente.SelectedIndices.Count == 0)
            {

            }
            else
            {
                var lis = list_Cliente.SelectedItems[0];
                lblID.Text = lis.SubItems[0].Text;
                lblnom.Text = lis.SubItems[1].Text;
                lblRUC.Text = lis.SubItems[2].Text;
                this.Tag = "A";
                this.Close();
            }
        }
        private void list_Cliente_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            SeleccionarCliente();
        }

        private void list_Cliente_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SeleccionarCliente();
            }
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            this.Tag = "";
            this.Close();
        }

        private void txt_DNIRUC_OnValueChanged(object sender, EventArgs e)
        {
            //if (chk_consulta.Checked == true)
            //{
            //    if (txt_DNIRUC.Text.Trim().Length == 11)
            //    {
            //        //pic_load.Visible = true;
            //        //lbl_consultar.Visible = true;
            //        //pic_load.Refresh();
            //        //lbl_consultar.Refresh();
            //        Consultar_Sunat(txt_DNIRUC.Text.Trim());
            //    }
            //}
        }
        private string SendRequest(string uri, byte[] JsonDataByte, string contextType, string method)
        {
            WebRequest req = WebRequest.Create(uri);

            req.ContentType = contextType;
            req.Method = method;
            req.ContentLength = JsonDataByte.Length;

            var stream = req.GetRequestStream();
            stream.Write(JsonDataByte, 0, JsonDataByte.Length);
            var response = req.GetResponse().GetResponseStream();

            var reader = new StreamReader(response);
            string res = reader.ReadToEnd();

            reader.Close();
            response.Close();

            return res;
        }
        #region Consulta de Ruc 2
        //private void Consultar_Sunat(string nroRuc)
        //{


        //    Frm_Filtro fil = new Frm_Filtro();
        //    Frm_Msm_Bueno ok = new Frm_Msm_Bueno();

        //    var data = Encoding.UTF8.GetBytes("{ }");
        //    string JsonSpta;

        //    try
        //    {
        //        var result_post = SendRequest("https://facturacionelectronica.us/facturacion/controller/ws_consulta_rucdni_v2.php?usuario=10447915125&password=985511933&documento=RUC&nro_documento=" + nroRuc, data, "application/json", "POST");
        //        JsonSpta = JValue.Parse(result_post).ToString(Formatting.Indented);
        //        JObject jResults = JObject.Parse(JsonSpta);

        //        if (jResults["success"].ToString() == "True")
        //        {
        //            string xRuc = jResults["result"]["RUC"].ToString();
        //            string xRazonSocial = jResults["result"]["RazonSocial"].ToString();
        //            string xxCondicion = jResults["result"]["Condicion"].ToString();
        //            string xTipo = jResults["result"]["Tipo"].ToString();
        //            string xEstado = jResults["result"]["Estado"].ToString();
        //            string xDireccion = jResults["result"]["Direccion"].ToString();

        //            txt_DNIRUC.Text = xRuc;
        //            txt_RasonSocial.Text = xRazonSocial;
        //            txt_Condicion.Text = xxCondicion;
        //            txt_Tipo.Text = xTipo;
        //            txt_Direccion.Text = xDireccion;
        //            txt_estado.Text = xEstado;

        //            //pic_load.Visible = false;
        //            //lbl_consultar.Visible = false;
        //        }
        //        else
        //        {
        //            fil.Show();
        //            ok.Lbl_msm1.Text = "El RUC ingresado no existe.";
        //            ok.ShowDialog();
        //            fil.Hide();
        //            //pic_load.Visible = false;
        //            //lbl_consultar.Visible = false;
        //            txt_DNIRUC.Text = "";
        //            txt_DNIRUC.Focus();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        //pic_load.Visible = false;
        //        //lbl_consultar.Visible = false;
        //        MessageBox.Show(ex.Message);
        //    }
        //}
        #endregion

        private void chk_consulta_CheckedChanged(object sender, EventArgs e)
        {

        }
        public void Algo()
        {
            Thread.Sleep(3000);
        }
        private void btn_Consultar_Click(object sender, EventArgs e)
        {
            try
            {
                if (chk_consultaSunat.Checked == true && txt_DNIRUC.Text.Trim().Length == 11)
                {

                    #region consulta de ruc 2
                    //if (txt_DNIRUC.Text.Trim().Length == 11)
                    //{
                    //    lbl_buscando.Visible = true;
                    //    Consultar_Sunat(txt_DNIRUC.Text.Trim());
                    //    lbl_buscando.Visible = false;
                    //}
                    #endregion

                    string url = "https://api.apis.net.pe/v1/ruc?numero=" + txt_DNIRUC.Text;
                     string respuest = GetHttp(url);
                    VariableConsultRUC oObject = JsonConvert.DeserializeObject<VariableConsultRUC>(respuest);
                    txt_RasonSocial.Text = oObject.nombre;
                    txt_Condicion.Text = oObject.condicion;
                    //txt_Tipo.Text = oObject.viaTipo +" "+ oObject.tipoDocumento + " " + oObject.zonaTipo;
                    txt_Direccion.Text = oObject.direccion;
                    txt_estado.Text = oObject.estado;
                }
                else if (chk_consultaReniec.Checked == true && txt_DNIRUC.Text.Trim().Length == 8)
                {
                    //string token = "00d286908c0ba22547102507dd4f84ac8b6e2ccdfed435b95c0bb43884e89754";
                    string url = "https://api.apis.net.pe/v1/dni?numero="+ txt_DNIRUC.Text;
                    string respuest = GetHttp(url);
                    VariableConsultDNI oObject = JsonConvert.DeserializeObject<VariableConsultDNI>(respuest);
                    txt_RasonSocial.Text = oObject.apellidoPaterno + " " + oObject.apellidoMaterno + ", " + oObject.nombres;
                    txt_Direccion.Text = "-";

                }
                else
                {
                    MessageBox.Show("Se ingreso un documento "+ txt_DNIRUC.Text +" con "+txt_DNIRUC.Text.Length+" Digitos que no son Validos y/o no se selecciono un tipo de consulta.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Limpiar_text();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se encontro informacion: "+ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Limpiar_text();
            }
            
        }
        public static string GetHttp(string url)
        {
            System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12;
            WebRequest oRequest = WebRequest.Create(url);
            WebResponse oResponse = oRequest.GetResponse();
            StreamReader sr = new StreamReader(oResponse.GetResponseStream());
            return sr.ReadToEnd().Trim();
        }
        public class VariableConsultDNI
        {
            public string dni { get; set; }
            public int codVerifica { get; set; }
            public string apellidoPaterno { get; set; }
            public string apellidoMaterno { get; set; }
            public string nombres { get; set; }
            public string numero { get; set; }
            public string nombre_completo { get; set; }
        }
        public class VariableConsultRUC
        {
            public string nombre { get; set; }
            public string tipoDocumento { get; set; }
            public string numeroDocumento { get; set; }
            public string estado { get; set; }
            public string condicion { get; set; }
            public string direccion { get; set; }
            public string ubigeo { get; set; }
            public string viaTipo { get; set; }
            public string viaNombre { get; set; }
            public string zonaCodigo { get; set; }
            public string zonaTipo { get; set; }
            public string numero { get; set; }
            public string interior { get; set; }
            public string lote { get; set; }
            public string dpto { get; set; }
            public string manzana { get; set; }
            public string kilometro { get; set; }
            public string distrito { get; set; }
            public string provincia { get; set; }
            public string departamento { get; set; }
        }

        private void chk_consultaSunat_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_consultaSunat.Checked == true)
            {
                chk_consultaReniec.Checked = false;
            }

        }

        private void chk_consultaReniec_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_consultaReniec.Checked == true)
            {
                chk_consultaSunat.Checked = false;
            }

        }
    }
}
