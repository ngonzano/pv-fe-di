using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BE = businessEntities;
using SPV_Capa_Negocio;
using System.IO;
using Microsell_Lite.Utilitarios;
using Microsell_Lite.Principal;

namespace Microsell_Lite.NotaCredito
{
    public partial class Frm_ResumenBoleta : Form
    {
        public Frm_ResumenBoleta()
        {
            InitializeComponent();
        }


        BE.CPE_RESUMEN_BOLETA objCPE = new BE.CPE_RESUMEN_BOLETA();
        BE.CPE_RESUMEN_BOLETA_DETALLE objCPE_DETALLE = new BE.CPE_RESUMEN_BOLETA_DETALLE();

        BE.CONSULTA_TICKET objCPETICKET = new BE.CONSULTA_TICKET();
        CPEConfig obj = new CPEConfig();





        private void Frm_ResumenBoleta_Load(object sender, EventArgs e)
        {
            Leer_Dato_empresa();
            Config_ListView_Docs();
        }



        private void Leer_Dato_empresa()
        {
            RN_MiEmpresa obj = new RN_MiEmpresa();
            DataTable data = new DataTable();


            try
            {
                data = obj.RN_Mostrar_Empresa(1);
                if (data.Rows.Count > 0)
                {

                    Lbl_EmpresaEmisor.Text = Convert.ToString(data.Rows[0]["nombreRancho"]);
                    Lbl_RucEmisor.Text = Convert.ToString(data.Rows[0]["nroRuc"]);
                    Lbl_DireccionEmpresa.Text = Convert.ToString(data.Rows[0]["Direccionran"]);
                    Lbl_UsuarioSol.Text = Convert.ToString(data.Rows[0]["usuariosol"]);
                    Lbl_ClaveSol.Text = Convert.ToString(data.Rows[0]["clavesol"]);
                    Lbl_CertificadoClave.Text = Convert.ToString(data.Rows[0]["clavecertificado"]);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error al Leer los Datos: " + ex.Message, "Form Add Proveedor", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }


        }



        private void Config_ListView_Docs()
        {
            {
                var withBlock = Lsv_Doc;
                withBlock.Columns.Clear();
                withBlock.Items.Clear();
                withBlock.View = View.Details;
                withBlock.GridLines = true;
                withBlock.FullRowSelect = true;
                withBlock.Scrollable = true;
                withBlock.HideSelection = false;
                // Agregar Columnas a ListView
                withBlock.Columns.Add("Item", 50, HorizontalAlignment.Center); // 0
                withBlock.Columns.Add("Nombre del Cliente", 300, HorizontalAlignment.Left);
                withBlock.Columns.Add("Nro Boleta", 110, HorizontalAlignment.Left); // 3
                withBlock.Columns.Add("T Doc", 50, HorizontalAlignment.Left); // 4
                withBlock.Columns.Add("Nro Dni", 100, HorizontalAlignment.Left); // 5 el precio del Producto con Igv
                withBlock.Columns.Add("Statu", 50, HorizontalAlignment.Left); // 5 el precio del Producto con Igv
                withBlock.Columns.Add("Total", 80, HorizontalAlignment.Right); // 5 el precio del Producto con Igv
                withBlock.Columns.Add("SubTotal", 80, HorizontalAlignment.Right); // 5 el precio del Producto con Igv
                withBlock.Columns.Add("IGV", 80, HorizontalAlignment.Right);

                withBlock.Columns.Add("CDR_Sunat", 100, HorizontalAlignment.Left);
                withBlock.Columns.Add("Bajasunat", 0, HorizontalAlignment.Left);
                withBlock.Columns.Add("FechaDoc", 100, HorizontalAlignment.Left);
            }
        }


        private void Llenar_ListviewDoc(DataTable xdata)
        {
            string xNroDni = "";
            string xNroDoc = "";
            // Dim xIdped As String = ""
            // Dim xsunatEstado As String = ""
            string xTipoDoc = "";
            string CdrSunat = "";
            string xStadoInterno = "";
            string bajSunat = "";
            int xitem = 1;

            // '============== Pasamos la Fecha a Variable:
            string xaño = "";
            string xmes = "";
            string xdia = "";
            string fechapura = "";

            DateTime fechaEmi;

            int nroAprobado = 0;


            if (xdata.Rows.Count < 1)
                return;

            try
            {
                {
                    var withBlock = xdata.Rows[0];
                    Lsv_Doc.Items.Clear();
                    foreach (DataRow Registros in xdata.Rows)
                    {

                        xTipoDoc = Registros["Documento"].ToString();//verififcar
                        CdrSunat = Registros["CDR_Sunat"].ToString();

                        if (xTipoDoc.Trim() == "Nota Venta" | xTipoDoc.Trim() == "Factura")
                        {
                        }
                        else if (CdrSunat.Trim() == "Aprobado")
                        {
                            nroAprobado += 1;
                        }
                        else
                        {
                            ListViewItem withBlock1 = new ListViewItem(xitem.ToString());
                            //withBlock1.SubItems.Add(Registros["id_Doc"].ToString()); // 6
                            withBlock1.SubItems.Add(Registros["Razon_Social_Nombres"].ToString()); // 6
                            xNroDoc = Registros["Id_Doc"].ToString();
                            withBlock1.SubItems.Add(xNroDoc.Trim()); // 14
                            xNroDni = Registros["DNI"].ToString();
                            if (xNroDni.Trim().Length > 8)
                            {
                                withBlock1.SubItems.Add("6"); // '1=Dni 6=RUC
                            }

                            else
                            {
                                withBlock1.SubItems.Add("1");// '1=Dni
                            }

                            withBlock1.SubItems.Add(xNroDni.Trim());
                            withBlock1.SubItems.Add("1");
                            withBlock1.SubItems.Add(Registros["ImporteDoc"].ToString());
                            withBlock1.SubItems.Add(Registros["SubTotal"].ToString());
                            withBlock1.SubItems.Add(Registros["IgvDoc"].ToString());
                            withBlock1.SubItems.Add(Registros["CDR_Sunat"].ToString());
                            withBlock1.SubItems.Add(Registros["EstadoBajada"].ToString());
                            // .SubItems.Add(Registros("Estado_Doc"))
                            fechaEmi = Convert.ToDateTime(Registros["Fecha_Emi"]);
                            withBlock1.SubItems.Add(fechaEmi.ToString("dd/MM/yyyy"));
                            Lbl_serieSunat.Text = Dtp_FechaDoc.Value.ToString("yyyyMMdd");

                            Lsv_Doc.Items.Add(withBlock1);
                            xitem = xitem + 1;

                        }
                    }

                    if (nroAprobado > 0)
                    {
                        MessageBox.Show("Las Boletas ya Fueraon Aprobadas por la Sunat: " + nroAprobado.ToString());
                    }

                    Btn_Enviar.Enabled = true;
                    string xserie = RN_TipoDoc.Sp_Listado_Tipo(15);
                    Txt_NroItem.Text = xserie.Substring(2);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Quitar_Documento();
        }

        private void Quitar_Documento()
        {
            Frm_Filtro fil = new Frm_Filtro();
            Frm_Advertencia ver = new Frm_Advertencia();
            Frm_SINO sino = new Frm_SINO();

            if (Lsv_Doc.SelectedIndices.Count == 0)
            {
                fil.Show(); ver.lbl_msm.Text = "Por Favor Selecciona el Documento a Quitar"; ver.ShowDialog(); fil.Hide(); return;
            }

            fil.Show();
            sino.lbl_msm.Text = "¿Quieres Quitarlo del Carrito?";
            sino.ShowDialog();
            fil.Hide();

            if (sino.Tag.ToString() == "Si")
            {
                //int i;
                //{
                //    var withBlock = Lsv_Doc;
                //    for (var i = withBlock.SelectedItems.Count - 1; i >= 0; i += -1)
                //        withBlock.Items.Remove(withBlock.SelectedItems.Item[i]);
                //}

                int i;
                var lis = Lsv_Doc.SelectedItems[0];
                for (i = Lsv_Doc.SelectedItems.Count - 1; i >= 0; i--)
                {
                    Lsv_Doc.Items.Remove(Lsv_Doc.SelectedItems[i]);
                }
            }
        }





        private void Enviar_Resumen_Boleta()
        {
            string xcdrSunat = "";
            int xtipoopera = 0;
            DateTime xFechaDoc;
            string ruccliente = "";
            Frm_Advertencia ver = new Frm_Advertencia();
            Frm_Filtro fil = new Frm_Filtro();
            Frm_Msm_Bueno ok = new Frm_Msm_Bueno();

            // 'jose estas ahi???
            RN_Documento objdoc = new RN_Documento();

            try
            {


                objCPE.NRO_DOCUMENTO_EMPRESA = Lbl_RucEmisor.Text.Trim(); // ' "10447915125"
                objCPE.RAZON_SOCIAL = Lbl_EmpresaEmisor.Text.Trim(); // ' "CREVPERU S.A."
                objCPE.TIPO_DOCUMENTO = "6";
                objCPE.CODIGO = "RC";
                objCPE.SERIE = Dtp_FechaDoc.Value.ToString("yyyyMMdd"); // Lbl_serieSunat.Text.Trim '' "20161029"  ''Es la fecha del documento pero sin Guiones
                objCPE.SECUENCIA = Txt_NroItem.Text; // ' "1" ''es la cantidad de resumenes que se envia en el Dia
                objCPE.FECHA_REFERENCIA = dtp_Fecharesumen.Value.ToString("yyyy-MM-dd"); // '"2016-10-28" ''Fecha emision
                objCPE.FECHA_DOCUMENTO = Dtp_FechaDoc.Value.ToString("yyyy-MM-dd"); // ' "2016-10-29"  ''Fecha de declaracion

                int xid = Convert.ToInt32(Cbo_TipoServidor.Text);

                objCPE.TIPO_PROCESO = System.Convert.ToInt32(xid); // ' "3"  ''3= beta , 1= produccion
                objCPE.CONTRA_FIRMA = Lbl_CertificadoClave.Text.Trim(); // ' "123456"
                objCPE.USUARIO_SOL_EMPRESA = Lbl_UsuarioSol.Text.Trim(); // ' "MODDATOS"
                objCPE.PASS_SOL_EMPRESA = Lbl_ClaveSol.Text.Trim(); // ' "moddatos"

                List<businessEntities.CPE_RESUMEN_BOLETA_DETALLE> OBJCPE_DETALLE_LIST = new List<businessEntities.CPE_RESUMEN_BOLETA_DETALLE>();
                for (int i = 0; i <= Lsv_Doc.Items.Count - 1; i++)
                {

                    var withBlock = Lsv_Doc.Items[i];
                    objCPE_DETALLE = new businessEntities.CPE_RESUMEN_BOLETA_DETALLE();
                    // 'objCPE_DETALLE.PRECIO = CDec(.SubItems(7).Text) ''   Ejemplo:
                    xcdrSunat = withBlock.SubItems[9].Text;
                    if (xcdrSunat.Trim() == "Aprobado")
                    {
                        ver.lbl_msm.Text = "Hay un Documento que Ya fue Declarado, Revisa por favor"; ver.ShowDialog(); return;
                    }
                    xtipoopera = Convert.ToInt32(withBlock.SubItems[5].Text);

                    if (xtipoopera == 1 & lbl_xop.Text == "3")  //anular
                    {
                        ver.lbl_msm.Text = "Hay un Documento que no Está en la misma operacion a Realizar, Revisa por Favor"; ver.ShowDialog(); return;
                    }
                    if (xtipoopera == 3 & lbl_xop.Text == "1")  //declarar
                    {
                        ver.lbl_msm.Text = "Hay un Documento que no Está en la misma operacion a Realizar, Revisa por Favor"; ver.ShowDialog(); return;
                    }
                    xFechaDoc = Convert.ToDateTime(withBlock.SubItems[11].Text);
                    if (objdoc.RN_Validar_FechaDoc_EnResumenBoleta(xFechaDoc, Dtp_FechaDoc.Value) == false)
                    {
                        ver.lbl_msm.Text = "Algunos Documentos No Coinciden con la Misma Fecha del Dia, Revisa por favor"; ver.ShowDialog(); return;
                    }

                    // 'Si nada de Arriba su Cumple , Entonces pasara a estas filas:
                    objCPE_DETALLE.ITEM = Convert.ToInt32(withBlock.SubItems[0].Text); // ' 1 ''correlativo de la cantidad de boletas a declarar
                    objCPE_DETALLE.TIPO_COMPROBANTE = "03";  // '03= boletas, 1= factura
                    objCPE_DETALLE.NRO_COMPROBANTE = withBlock.SubItems[2].Text;  // ' "B001-12" ''el Nro de la Boleta - correlativo
                    ruccliente = withBlock.SubItems[4].Text;
                    objCPE_DETALLE.TIPO_DOCUMENTO = withBlock.SubItems[3].Text; // ' "1"  ''1=Dni... 6= RUC
                    objCPE_DETALLE.NRO_DOCUMENTO = ruccliente.Trim(); // ' .SubItems(4).Text  '' "44791512" ''Nro de Dni o Ruc del cliente
                    objCPE_DETALLE.TIPO_COMPROBANTE_REF = "";
                    objCPE_DETALLE.NRO_COMPROBANTE_REF = "";
                    objCPE_DETALLE.STATU = withBlock.SubItems[5].Text; // ' 1  ''1=Declarar .-- 3=Anular
                    objCPE_DETALLE.COD_MONEDA = "PEN";
                    objCPE_DETALLE.TOTAL = System.Convert.ToDecimal(withBlock.SubItems[6].Text); // ' 1693.39
                    objCPE_DETALLE.GRAVADA = System.Convert.ToDecimal(withBlock.SubItems[7].Text); // ' 1435.08
                    objCPE_DETALLE.ISC = 0;
                    objCPE_DETALLE.IGV = System.Convert.ToDecimal(withBlock.SubItems[8].Text); // 258.31
                    objCPE_DETALLE.OTROS = 0;
                    objCPE_DETALLE.CARGO_X_ASIGNACION = 1;
                    objCPE_DETALLE.MONTO_CARGO_X_ASIG = 0;
                    objCPE_DETALLE.EXONERADO = 0;
                    objCPE_DETALLE.INAFECTO = 0;
                    objCPE_DETALLE.EXPORTACION = 0;
                    objCPE_DETALLE.GRATUITAS = 0;
                    OBJCPE_DETALLE_LIST.Add(objCPE_DETALLE);

                }

                objCPE.detalle = OBJCPE_DETALLE_LIST;
                // ======================================RESPUESTA====================================
                Dictionary<string, string> dictionaryEnv = new Dictionary<string, string>();
                dictionaryEnv = obj.Enviar_Resumen_Boletas(objCPE);
                string CodFlart = "";


                CodFlart = dictionaryEnv["flg_rta"];
                txt_codSunat.Text = dictionaryEnv["cod_sunat"];
                Txt_MsmSunat.Text = dictionaryEnv["msj_sunat"];
                TXTHASHCPE.Text = dictionaryEnv["hash_cpe"];
                Lbl_HashCpe2.Text = dictionaryEnv["hash_cpe"];
                TXTHASHCDR.Text = dictionaryEnv["hash_cdr"];
                // ==============================
                Txt_NroTicket.Text = dictionaryEnv["msj_sunat"];
                Lbl_NroTicket2.Text = Txt_NroTicket.Text;

                // 'Mensajes:
                if (CodFlart.Trim() == "0")
                {
                    fil.Show();
                    ver.lbl_msm.Text = "Hubo Problemas de Conexion a Internet, Espere que la Señal Regrese";
                    ver.ShowDialog();
                    fil.Hide();
                    return;
                }


                if (txt_codSunat.Text.Trim() == "1" || txt_codSunat.Text.Trim() == "0")
                {
                    fil.Show();
                    ok.Lbl_msm1.Text = "El Resumen de Boletas fue Aceptado Nro Ticket: " + Txt_NroTicket.Text + " Puede Consultar su Estado con el Nro de Ticket";
                    ok.ShowDialog();
                    fil.Hide();
                   
                }
                else if (CodFlart.Trim() == "0")
                {
                    fil.Show();
                    ver.lbl_msm.Text = "Hubo Problemas de Conexion a Internet, Espere que la Señal Regrese";
                    ver.ShowDialog();
                    fil.Hide();
                }
                else
                    MessageBox.Show("El Resumen de boleta fue Rechazado: " + txt_codSunat.Text.Trim() + " --  " + Txt_MsmSunat.Text, "Advertencia del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                btn_consulTicket.Enabled = true;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al Send:: " + ex.Message, "Advertencia del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void Rdb_declarar_CheckedChanged(object sender, EventArgs e)
        {
            if (Rdb_declarar.Checked == true)
            {
                lbl_xop.Text = "1";
            }
        }

        private void Rdb_anular_CheckedChanged(object sender, EventArgs e)
        {
            if (Rdb_anular.Checked == true)
            {
                lbl_xop.Text = "3";
            }
        }

        private void Btn_Enviar_Click(object sender, EventArgs e)
        {
            if (Lsv_Doc.Items.Count == 0) { return; }
            if (lbl_xop.Text.Trim() == "") { return; }

            if (Cbo_TipoServidor.SelectedIndex == -1) { Cbo_TipoServidor.Focus(); return; }

            Enviar_Resumen_Boleta();
            RN_TipoDoc.RN_Actualizar_SiguienteNro_correlativo(15);
        }

        private void Cbo_TipoDocCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            Frm_Filtro fil = new Frm_Filtro();
            Frm_Advertencia ver = new Frm_Advertencia();

            if (Lsv_Doc.SelectedIndices.Count == 0)
            {
                fil.Show();
                ver.lbl_msm.Text = "Selecciona le Item que deseas copiar";
                ver.ShowDialog();
                fil.Hide();
            }
            else
            {
                var lis = Lsv_Doc.SelectedItems[0];
                lis.SubItems[3].Text = Cbo_TipoDocCliente.Text;


            }


        }

        private void btn_consulTicket_Click(object sender, EventArgs e)
        {
            if (Txt_NroTicket.Text.Trim().Length > 2)
            {
                Consultar_EstadoBaja();
            }
        }









        private void Consultar_EstadoBaja()
        {


            Frm_Filtro fil = new Frm_Filtro();
            Frm_Msm_Bueno ok = new Frm_Msm_Bueno();
            Frm_Advertencia ver = new Frm_Advertencia();

            // ===================CONSULTA RESUMEN DE BAJA=======================
            int xti = Convert.ToInt32(Cbo_TipoServidor.Text);

            objCPETICKET.TIPO_PROCESO = System.Convert.ToInt32(xti); // '  3
            objCPETICKET.NRO_DOCUMENTO_EMPRESA = Lbl_RucEmisor.Text.Trim();
            objCPETICKET.USUARIO_SOL_EMPRESA = Lbl_UsuarioSol.Text.Trim();
            objCPETICKET.PASS_SOL_EMPRESA = Lbl_ClaveSol.Text.Trim();
            objCPETICKET.TICKET = Txt_NroTicket.Text.Trim();
            objCPETICKET.TIPO_DOCUMENTO = "RC";
            objCPETICKET.NRO_DOCUMENTO = Lbl_serieSunat.Text + "-" + Txt_NroItem.Text; // ' "-1" '' "20161029-1"

            // ======================================RESPUESTA====================================
            Dictionary<string, string> dictionaryEnv = new Dictionary<string, string>();
            dictionaryEnv = obj.Consulta_Ticket_de_Baja(objCPETICKET);
            txt_codSunat.Text = dictionaryEnv["cod_sunat"];
            Txt_MsmSunat.Text = dictionaryEnv["msj_sunat"];
            TXTHASHCPE.Text = dictionaryEnv["hash_cpe"];
            TXTHASHCDR.Text = dictionaryEnv["hash_cdr"];
            Txt_NroTicket.Text = "";


            fil.Show();
            string xStadoBaja = "";
            if (txt_codSunat.Text.Trim() == "0" || txt_codSunat.Text.Trim() == "1")
            {
                ok.Lbl_msm1.Text = "La Sunat Aceptó el Resumen de Boletas";
                ok.ShowDialog();
                xStadoBaja = "Aprobado";
            }
            else if (txt_codSunat.Text.Trim() == "98")
            {
                ok.Lbl_msm1.Text = "El Resumen de Boletas está en Proceso ";
                ok.ShowDialog();
                xStadoBaja = "En Proceso";
            }
            else if (txt_codSunat.Text.Trim() == "99")
            {
                ver.lbl_msm.Text = "Algo salió mal en el Resumen de boletas ";
                ver.ShowDialog();
                xStadoBaja = "Pendiente";
            }
            else
            {
                ver.lbl_msm.Text = "Algo salió mal al enviar el Resumen de Boletas ";
                ver.ShowDialog();
                xStadoBaja = "Pendiente";
            }

            // 'Actualizar Boletas:
            RN_Documento objDoc = new RN_Documento();
            for (int i = 0; i <= Lsv_Doc.Items.Count - 1; i++)
            {
                string iNroDoc = "";
                // Agregando datos a la lista Comprobante detalle
                {
                    var withBlock = Lsv_Doc.Items[i];
                    iNroDoc = withBlock.SubItems[2].Text;
                }
                objDoc.RN_Cambiar_RPT_EstadoSunat(iNroDoc.Trim(), xStadoBaja, Lbl_HashCpe2.Text.Trim());
            }
            fil.Hide();
        }

        private void Lbl_Lupa_Click(object sender, EventArgs e)
        {
            Consultar_Doc_delDia(Dtp_FechaDoc.Value, 2);
        }



        private void Consultar_Doc_delDia(DateTime fecha, int idTipo)
        {
            DataTable data = new DataTable();
            RN_Documento obj = new RN_Documento();


            data = obj.RN_Leer_Docs_delDia_PorTiopoDoc(fecha, idTipo);
            if (data.Rows.Count > 0)
            {
                Llenar_ListviewDoc(data);
            }
            else
            {
                Lsv_Doc.Items.Clear();
            }


        }

        private void Dtp_FechaDoc_ValueChanged(object sender, EventArgs e)
        {
            DataTable data = new DataTable();
            RN_Documento obj = new RN_Documento();


            data = obj.RN_Leer_Docs_delDia_PorTiopoDoc(Dtp_FechaDoc.Value, 2);
            if (data.Rows.Count > 0)
            {
                Llenar_ListviewDoc(data);
            }
            else
            {
                Lsv_Doc.Items.Clear();
            }
        }

        private void btn_cerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
