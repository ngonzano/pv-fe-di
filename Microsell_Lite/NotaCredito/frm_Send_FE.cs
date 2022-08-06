using System;
using System.Collections.Generic;
//using System.ComponentModel;
using System.Data;
using System.Drawing;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
using System.Windows.Forms;
//using Microsell_Lite.Compras;

//using Gma.QrCodeNet.Encoding;
//using QRCoder;
//using ThoughtWorks.QRCode;
using ThoughtWorks.QRCode.Codec;

////importar:
//using SPV_Capa_Entidad;
using SPV_Capa_Negocio;
using System.IO;
using Microsell_Lite.Utilitarios;
//using Microsell_Lite.Productos;
//using Microsell_Lite.Cliente;
//using Microsell_Lite.Informe;
using Microsell_Lite.Ventas;

using BE = businessEntities;
//using CPEEnvio;
//using CrearXML;
//using Signature;
using Microsell_Lite.Principal;

namespace Microsell_Lite.NotaCredito
{
    public partial class frm_Send_FE : Form
    {
        public frm_Send_FE()
        {
            InitializeComponent();
        }
        private void Frm_Ventana_Ventas_Load(object sender, EventArgs e)
        {

            Configurar_listView();
            Llenar_Combo_docs();
            cbo_tipoPago.SelectedIndex = 0;
            Leer_Dato_empresa();

        }
        private void Llenar_Combo_docs()
        {

            RN_TipoDoc obj = new RN_TipoDoc();
            DataTable dato = new DataTable();

            dato = obj.RN_Mostrar_TipoDocumento();
            if (dato.Rows.Count > 0)
            {

                var cbo = Cbo_TipoDoc;

                cbo.DataSource = dato;
                cbo.DisplayMember = "Documento";
                cbo.ValueMember = "Id_Tipo";



            }

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
                    Lbl_CorreoEmi.Text = Convert.ToString(data.Rows[0]["correo"]);
                    lbl_claveCorre.Text = Convert.ToString(data.Rows[0]["clavecorreo"]);
                    Lbl_CertificadoClave.Text = Convert.ToString(data.Rows[0]["clavecertificado"]);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error al Leer los Datos: " + ex.Message, "Form Add Proveedor", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }


        }
        private void Configurar_listView()
        {
            var lis = lsv_Det;

            lis.Items.Clear();
            lis.Columns.Clear();
            lis.View = View.Details;
            lis.GridLines = true;
            lis.FullRowSelect = true;
            lis.Scrollable = true;
            lis.HideSelection = false;

            //configurar las columnas:
            lis.Columns.Add("ID producto", 100, HorizontalAlignment.Left); //0
            lis.Columns.Add("Descripcion producto", 250, HorizontalAlignment.Left);  //1
            lis.Columns.Add("cantidad", 80, HorizontalAlignment.Center);  //2
            lis.Columns.Add("precio Unit", 90, HorizontalAlignment.Right);  //3
            lis.Columns.Add("Importe", 90, HorizontalAlignment.Right);  //4
            lis.Columns.Add("Tipo Producto", 100, HorizontalAlignment.Right);  //5
            lis.Columns.Add("Und", 0, HorizontalAlignment.Right);  //6
            lis.Columns.Add("Utilidad Unit", 0, HorizontalAlignment.Right);  //7
            lis.Columns.Add("Total Utilidad", 0, HorizontalAlignment.Right);  //8
            //campos que se requiere para la FE:
            lis.Columns.Add("Afec. Igv", 90, HorizontalAlignment.Left);  //8

            lis.Columns.Add("PreUni sinIgv", 0, HorizontalAlignment.Left);  //3.0
            lis.Columns.Add("SubTotal SinIgv", 0, HorizontalAlignment.Left);  // 0.40
            lis.Columns.Add("Igv", 0, HorizontalAlignment.Left);  //3.40
            lis.Columns.Add("Tipo", 110, HorizontalAlignment.Center);

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
            WindowState = FormWindowState.Minimized;
        }
        private void Calcular()
        {

            double xtotal = 0;
            double xcant = 0;
            double xprecio = 0;
            double ximporte = 0;
            double xsubtotal = 0;
            double xigv = 0;
            double xuti_unit = 0;
            double ximport_Uti = 0;
            double xTotalGanancia = 0;

            //================ para la FE ================
            double igvProd = 0;
            double subtotal_sinIgv = 0;
            double preUnit_sinIgv = 0;

            double xsubtotal_sinIgv = 0;
            double xigv_total = 0;



            for (int i = 0; i < lsv_Det.Items.Count; i++)
            {
                xcant = Convert.ToDouble(lsv_Det.Items[i].SubItems[2].Text);
                xprecio = Convert.ToDouble(lsv_Det.Items[i].SubItems[3].Text);  //precio que incluye el IGV

                //calculo:
                ximporte = xprecio * xcant;
                lsv_Det.Items[i].SubItems[4].Text = ximporte.ToString("###0.00");

                //utilidad:
                xuti_unit = Convert.ToDouble(lsv_Det.Items[i].SubItems[7].Text);
                ximport_Uti = xuti_unit * xcant;
                lsv_Det.Items[i].SubItems[8].Text = ximport_Uti.ToString("###0.00");



                //caluclo del total:
                xtotal = xtotal + Convert.ToDouble(lsv_Det.Items[i].SubItems[4].Text);
                xTotalGanancia = xTotalGanancia + Convert.ToDouble(lsv_Det.Items[i].SubItems[8].Text);

                //Calculo para Sunat: ========================
                preUnit_sinIgv = xprecio / 1.18;
                lsv_Det.Items[i].SubItems[10].Text = preUnit_sinIgv.ToString("###0.00");
                //subtotal sin igv:
                subtotal_sinIgv = preUnit_sinIgv * xcant;
                lsv_Det.Items[i].SubItems[11].Text = subtotal_sinIgv.ToString("###0.00");

                //calculamos el Igv:
                igvProd = subtotal_sinIgv * 0.18;
                lsv_Det.Items[i].SubItems[12].Text = igvProd.ToString("###0.00");


                //=================== Pie de la FE para la Sunat ====================== //
                xsubtotal_sinIgv = xsubtotal_sinIgv + Convert.ToDouble(lsv_Det.Items[i].SubItems[11].Text);
                xigv_total = xigv_total + Convert.ToDouble(lsv_Det.Items[i].SubItems[12].Text);

            }
            //calcular el IGV: IVA
            xsubtotal = xtotal / 1.18;
            xigv = xsubtotal * 0.18;

            lbl_subtotal.Text = xsubtotal.ToString("###0.00");
            lbl_igv.Text = xigv.ToString("###0.00");
            lbl_TotalPagar.Text = xtotal.ToString("###0.00");
            lbl_totalGanancia.Text = xTotalGanancia.ToString("###0.00");

            //=============== Totales del Pie de la FE ===================//
            lbl_subtotalGravado.Text = xsubtotal_sinIgv.ToString("###0.00");
            lbl_igvgravado.Text = xigv_total.ToString("###0.00");
            double totalGravado = xsubtotal_sinIgv + xigv_total;
            Lbl_totalGravado.Text = totalGravado.ToString("###0.00");


            lbl_son.Text = Numalet.ToString(lbl_TotalPagar.Text);
            let.LetraCapital = chkCapital.Checked;
            if (!actualizado) ActualizarCong();




        }
        Numalet let = new Numalet();
        Boolean actualizado = false;
        private void ActualizarCong()
        {
            actualizado = true;
            chkCapital.Checked = let.LetraCapital;
            if (lbl_son.Text.Length > 0)
            {
                lbl_son.Text = let.ToCustomString(lbl_TotalPagar.Text);
                actualizado = false;
            }
        }
        private bool Validar_Antes_Vender()
        {

            Frm_Filtro fil = new Frm_Filtro();
            Frm_Advertencia ver = new Frm_Advertencia();

            if (lsv_Det.Items.Count == 0) { fil.Show(); ver.lbl_msm.Text = "Debes Agregra como Minimo un Producto al Carrito"; ver.ShowDialog(); fil.Hide(); return false; }
            if (Convert.ToInt32(lbl_idcliente.Text.Length) < 2) { fil.Show(); ver.lbl_msm.Text = "Te falta agregar un Cliente"; ver.ShowDialog(); fil.Hide(); return false; }
            if (cbo_tipoPago.SelectedIndex == -1) { fil.Show(); ver.lbl_msm.Text = "Por Favor, Elige un Tipo de Pago"; ver.ShowDialog(); fil.Hide(); cbo_tipoPago.Focus(); return false; }

            if (Cbo_TipoDoc.SelectedIndex == -1) { fil.Show(); ver.lbl_msm.Text = "Por Favor, Elige un Tipo de Comprobante"; ver.ShowDialog(); fil.Hide(); Cbo_TipoDoc.Focus(); return false; }

            if (Cbo_TipoDoc.SelectedIndex == 0 && lbl_idServer.Text == "1")
            {
                fil.Show(); ver.lbl_msm.Text = "Por Favor, Elige un Tipo de Comprobante Valido para la Sunat"; ver.ShowDialog(); fil.Hide(); Cbo_TipoDoc.Focus(); return false;
            }


            return true;
        }
        #region Metodos sin usar
        //private void Guardar_Documento()
        //{

        //    RN_Documento obj = new RN_Documento();
        //    EN_Documento doc = new EN_Documento();
        //    int rpt;
        //    try
        //    {

        //        txt_NroDoc.Text = RN_TipoDoc.Sp_Listado_Tipo(Convert.ToInt32(Cbo_TipoDoc.SelectedValue));
        //        //los parametros:
        //        doc.Id_Doc = txt_NroDoc.Text;
        //        doc.Id_Ped = txt_nroPed.Text;
        //        doc.Id_Tipo = Convert.ToInt32(Cbo_TipoDoc.SelectedValue);
        //        doc.Fecha_Emi = dtp_FechaEmi.Value;
        //        doc.Importe = Convert.ToDouble(lbl_TotalPagar.Text);
        //        doc.TipoPago = cbo_tipoPago.Text;
        //        doc.NroOpera = txt_NroOperac.Text;
        //        doc.Id_Usu = Cls_UsuLogin.IdUsu;
        //        doc.Igv = Convert.ToDouble(lbl_igv.Text);
        //        doc.Son = lbl_son.Text;
        //        doc.TotalGanancia = Convert.ToDouble(lbl_totalGanancia.Text);
        //        doc.CDR_Sunat = "Pendiente";

        //        rpt = obj.RN_Ingresar_Documento(doc);

        //        if (rpt == 1)
        //        {
        //            RN_TipoDoc.RN_Actualizar_SiguienteNro_correlativo(Convert.ToInt32(Cbo_TipoDoc.SelectedValue));
        //        }



        //    }

        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        //    }



        //}
        //private void Guardar_IngresoCaja()
        //{

        //    RN_Caja obj = new RN_Caja();
        //    EN_Caja cja = new EN_Caja();

        //    try
        //    {

        //        cja.Fecha_Caja = dtp_FechaEmi.Value;
        //        cja.Tipo_Caja = "Entrada";
        //        cja.Concepto = "Por Ventas al Publico";
        //        cja.De_Para = txt_cliente.Text;
        //        cja.Nro_Doc = txt_NroDoc.Text;
        //        cja.ImporteCaja = Convert.ToDouble(lbl_TotalPagar.Text);
        //        cja.Id_Usu = Cls_UsuLogin.IdUsu;
        //        cja.TotalUti = Convert.ToDouble(lbl_totalGanancia.Text);
        //        cja.TipoPago = cbo_tipoPago.Text;
        //        cja.GeneradoPor = Cbo_TipoDoc.Text;

        //        obj.RN_Ingresar_Caja(cja);

        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        //    }


        //}
        //private void Registrar_MoviemtoKardex()
        //{
        //    RN_Kardex obj = new RN_Kardex();
        //    EN_Kardex kar = new EN_Kardex();
        //    RN_Producto objpro = new RN_Producto();
        //    DataTable dato = new DataTable();
        //    DataTable datoprod = new DataTable();
        //    string xidkardex = "";
        //    int xitem = 0;
        //    double stockProd = 0;
        //    double precioCompraProd = 0;

        //    string xidProd = "";
        //    double xcant = 0;
        //    string xTipoProd = "";
        //    try
        //    {

        //        for (int i = 0; i < lsv_Det.Items.Count; i++)
        //        {
        //            var lis = lsv_Det.Items[i];

        //            xidProd = lis.SubItems[0].Text;
        //            xcant = Convert.ToDouble(lis.SubItems[2].Text);
        //            xTipoProd = lis.SubItems[5].Text;

        //            if (obj.RN_Sp_Ver_sihay_Kardex(xidProd) == true)
        //            {
        //                dato = obj.RN_BuscarKardexDetalleProducto(xidProd.Trim());
        //                if (dato.Rows.Count > 0)
        //                {
        //                    xidkardex = Convert.ToString(dato.Rows[0]["Id_krdx"]);
        //                    xitem = dato.Rows.Count;
        //                    //leemos los datos del producto:
        //                    datoprod = objpro.RN_Buscar_Producto(xidProd.Trim());
        //                    stockProd = Convert.ToDouble(datoprod.Rows[0]["Stock_Actual"]);
        //                    precioCompraProd = Convert.ToDouble(datoprod.Rows[0]["Pre_CompraS"]);

        //                    //registramos el Detalle del Kardex:
        //                    kar.Id_Krdx = xidkardex;
        //                    kar.Item = xitem + 1;
        //                    kar.Doc_Soport = txt_NroDoc.Text;
        //                    kar.Det_Operacion = "Por Ventas al Publico";
        //                    //Entrada:
        //                    kar.Cantidad_In = 0;
        //                    kar.Precio_Unt_In = 0;
        //                    kar.Costo_Total_In = 0;
        //                    //salida:
        //                    kar.Cantidad_Out = xcant;
        //                    kar.Precio_Unt_Out = precioCompraProd;
        //                    kar.Importe_Total_Out = xcant * precioCompraProd;
        //                    //saldos:
        //                    kar.Cantidad_Saldo = stockProd - xcant;
        //                    kar.Promedio = precioCompraProd;
        //                    kar.Costo_Total_Saldo = precioCompraProd * kar.Cantidad_Saldo;

        //                    obj.RN_Registrar_det_Kardex(kar);

        //                    //ahora acrtalizamos nuestro stock de la tabla productos:
        //                    objpro.RN_RestarStock_Producto(xidProd.Trim(), xcant);

        //                    Prod_Krd += 1;
        //                }
        //            }
        //        }  //fin del For: 

        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message, "Reg Kardex Capa Cliente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        //    }

        //}
        //private void tocar_timbre_Aparecer()
        //{
        //    string ruta;
        //    ruta = Application.StartupPath;
        //    System.Media.SoundPlayer son;
        //    son = new System.Media.SoundPlayer(ruta + @"\EspadaEfect.wav");
        //    son.Play();

        //}
        //DataTable vObjTempComprobante;
        //DataRow vObjTempFilaComprobante;
        //int Prod_Krd = 0;
        //private void Buscar_Producto_DeCotizacion(string idprdcto)
        //{
        //    RN_Producto obj = new RN_Producto();
        //    DataTable data = new DataTable();

        //    try
        //    {
        //        data = obj.RN_Buscar_Producto(idprdcto);
        //        if (data.Rows.Count > 0)
        //        {
        //            lbl_StockProdx.Text = Convert.ToString(data.Rows[0]["Stock_Actual"]);
        //            lbl_tipoProdx.Text = Convert.ToString(data.Rows[0]["TipoProdcto"]);

        //        }

        //    }
        //    catch (Exception ex)
        //    {

        //        MessageBox.Show("Error al Guardar: " + ex.Message, "Form Add Proveedor", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        //    }


        //}
        #endregion
        private void btn_procesar_Click(object sender, EventArgs e)
        {
            Frm_Filtro fil = new Frm_Filtro();
            Frm_Msm_Bueno ok = new Frm_Msm_Bueno();
            Frm_TipoPago_Credito cred = new Frm_TipoPago_Credito();
            RN_Cotizacion objcoti = new RN_Cotizacion();
            RN_Documento objDoc = new RN_Documento();

            Frm_Print_NotaVentaTicket nota = new Frm_Print_NotaVentaTicket();

            try
            {
                if (Validar_Antes_Vender() == true)
                {

                    if (lbl_idServer.Text.Trim() == "1" || lbl_idServer.Text.Trim() == "3")
                    {
                        enviarComprobante_A_Sunat();

                        if (TXTCOD_SUNAT.Text.Trim() == "0" || TXTCOD_SUNAT.Text.Trim() == "1")
                        {
                            objDoc.RN_Cambiar_RPT_EstadoSunat(txt_NroDoc.Text, "Aprobado", TXTHASHCPE.Text);
                            tocar_timbreCaja();

                            //terminar la Venta:
                            fil.Show();
                            ok.Lbl_msm1.Text = "El Comprobante fue Aceptado por la Sunat";
                            ok.ShowDialog();
                            fil.Hide();

                            Limpiar_todo();
                            pnl_sinProd.Visible = true;
                            //limpiar todo:
                        }  //fin
                        else
                        {
                            //NO se ha  Aprobado:
                            objDoc.RN_Cambiar_RPT_EstadoSunat(txt_NroDoc.Text, "Rechazado", TXTHASHCPE.Text);
                            tocar_timbreCaja();

                            //terminar la Venta:
                            fil.Show();
                            ok.Lbl_msm1.Text = "El comprobante fue Rechazado por Sunat: " + TXT_MSJ_SUNAT.Text;
                            ok.ShowDialog();
                            fil.Hide();


                            Limpiar_todo();
                            pnl_sinProd.Visible = true;



                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }


        }
        private void tocar_timbreCaja()
        {
            string ruta;
            ruta = Application.StartupPath;
            System.Media.SoundPlayer son;
            son = new System.Media.SoundPlayer(ruta + @"\Efectocaja.wav");
            son.Play();

        }
        BE.CPE objCPE = new BE.CPE();
        BE.CPE_DETALLE objCPE_DETALLE = new BE.CPE_DETALLE();
        CPEConfig obj = new CPEConfig();
        internal void enviarComprobante_A_Sunat()
        {
            try
            {
                objCPE.TIPO_OPERACION = "0101"; //'0101=Venta Interna
                objCPE.TOTAL_GRAVADAS = Convert.ToDecimal(lbl_subtotal.Text); //SUB TOTAL
                objCPE.SUB_TOTAL = Convert.ToDecimal(lbl_subtotal.Text); //SUB TOTAL
                objCPE.POR_IGV = 18; //NUEVO UBL 2.1
                objCPE.TOTAL_IGV = Convert.ToDecimal(lbl_igv.Text); //TOTAL IGV
                objCPE.TOTAL_ISC = 0;
                objCPE.TOTAL_OTR_IMP = 0;
                objCPE.TOTAL_DESCUENTOGLO = 0;
                objCPE.TOTAL = Convert.ToDecimal(lbl_TotalPagar.Text); //TOTAL COMPROBANTE
                objCPE.TOTAL_EXPORTACION = 0; //NUEVO UBL 2.1
                objCPE.TOTAL_LETRAS = lbl_son.Text;
                objCPE.NRO_GUIA_REMISION = "";
                objCPE.FECHA_GUIA_REMISION = ""; //NUEVO UBL 2.1
                objCPE.COD_GUIA_REMISION = "";
                objCPE.NRO_OTR_COMPROBANTE = "";
                objCPE.COD_OTR_COMPROBANTE = "";
                objCPE.NRO_COMPROBANTE = txt_NroDoc.Text; //' TXTSERIE.Text & [ª0000ª] & TXTNUMERO.Text // F001-0000001 // B001-55655   F012-000000000 - B012
                objCPE.FECHA_DOCUMENTO = dtp_FechaEmi.Value.ToString("yyyy-MM-dd"); //[ª0001ª]
                objCPE.FECHA_VTO = dtp_FechaEmi.Value.ToString("yyyy-MM-dd"); //NUEVO UBL 2.1
                objCPE.COD_TIPO_DOCUMENTO = Lbl_TipoFac_Id.Text; //'01=factura , 03= Boleta

                //objCPE.COD_TIPO_DOCUMENTO = CBOTIPOCOMPROBANTE.SelectedValue  '01=FACTURA, 03=BOLETA, 07=NOTA CREDITO, 08=NOTA DEBITO
                objCPE.COD_MONEDA = "PEN"; //cbo_moneda.SelectedValue; //' [ª0000ª]
                                           //==============PARA PLAA DE VEHICULO SOLO PARA LOS QUE VENDEN GASOLINA. OSEA PARA LOS GRIFOS=============
                                           //objCPE.PLACA_VEHICULO = "-" ' txtplaca_vehiculo.Text
                                           //========================DATOS NOTA CREDITO/NOTA DEBITO==========================
                objCPE.TIPO_COMPROBANTE_MODIFICA = ""; //'Nota Credito
                objCPE.NRO_DOCUMENTO_MODIFICA = ""; //'Lbl_Nro_Doc.Text '' [ª0001ª]
                objCPE.COD_TIPO_MOTIVO = "";
                objCPE.DESCRIPCION_MOTIVO = "";
                //========================DATOS DEL CIENTE==========================
                objCPE.NRO_DOCUMENTO_CLIENTE = lbl_dni_ruc.Text.Trim();
                objCPE.RAZON_SOCIAL_CLIENTE = txt_cliente.Text.Trim();
                objCPE.TIPO_DOCUMENTO_CLIENTE = Lbl_IDTipoDoc_Cli.Text; //' Cbo_TipoDocCliente.Text    '1=DNI,6=RUC
                objCPE.DIRECCION_CLIENTE = lbl_direccion.Text.Trim();
                objCPE.CIUDAD_CLIENTE = "LIMA";
                objCPE.COD_PAIS_CLIENTE = "PE";
                objCPE.COD_UBIGEO_CLIENTE = ""; ////NUEVO UBL2.1
                objCPE.DEPARTAMENTO_CLIENTE = ""; ////NUEVO UBL2.1
                objCPE.PROVINCIA_CLIENTE = ""; ////NUEVO UBL2.1
                objCPE.DISTRITO_CLIENTE = ""; ////NUEVO UBL2.1
                                              //=============================DATOS EMPRESA===========================
                objCPE.NRO_DOCUMENTO_EMPRESA = Lbl_RucEmisor.Text.Trim(); //' [ª0000ª]
                objCPE.TIPO_DOCUMENTO_EMPRESA = "6"; //1=DNI,6=RUC
                objCPE.NOMBRE_COMERCIAL_EMPRESA = Lbl_EmpresaEmisor.Text.Trim(); //' [ª0000ª]
                objCPE.CODIGO_UBIGEO_EMPRESA = "150101"; //TABLA UBIGEO
                objCPE.DIRECCION_EMPRESA = Lbl_DireccionEmpresa.Text.Trim(); //' [ª0000ª]
                objCPE.DEPARTAMENTO_EMPRESA = "LIMA";
                objCPE.PROVINCIA_EMPRESA = "LIMA";
                objCPE.DISTRITO_EMPRESA = "LIMA";
                objCPE.CODIGO_PAIS_EMPRESA = "PE";
                objCPE.RAZON_SOCIAL_EMPRESA = Lbl_EmpresaEmisor.Text.Trim(); //'  [ª0000ª]
                objCPE.CONTACTO_EMPRESA = ""; //NUEVO UBL 2.1
                objCPE.USUARIO_SOL_EMPRESA = Lbl_UsuarioSol.Text.Trim(); //'  [ª0000ª]
                objCPE.PASS_SOL_EMPRESA = Lbl_ClaveSol.Text.Trim(); //' [ª0000ª]
                objCPE.CONTRA_FIRMA = Lbl_CertificadoClave.Text.Trim(); //' [ª0000ª] 'Lbl_CertificadoClave.Text.Trim '' [ª0001ª]

                int xtip = Convert.ToInt32(lbl_idServer.Text);
                objCPE.TIPO_PROCESO = Convert.ToInt32(xtip);


                //===================VARIABLE PARA LAS LISTAS==================
                List<businessEntities.CPE_DETALLE> OBJCPE_DETALLE_LIST = new List<businessEntities.CPE_DETALLE>();
                //'Prueba al Jalar del Listview que Tengo
                for (int i = 0; i < lsv_Det.Items.Count; i++)
                {
                    objCPE_DETALLE = new businessEntities.CPE_DETALLE();
                    objCPE_DETALLE.ITEM = i + 1;
                    objCPE_DETALLE.UNIDAD_MEDIDA = lsv_Det.Items[i].SubItems[13].Text; //'[ª0000ª] ''.SubItems(2).Text '' vObjTempComprobante.Rows(Z)([ª0001ª]).ToString 'UNIDAD MEDIDA SEGUN CATALOGO 8
                    objCPE_DETALLE.CANTIDAD = Convert.ToDecimal(lsv_Det.Items[i].SubItems[2].Text); //'
                    objCPE_DETALLE.PRECIO = Convert.ToDecimal(lsv_Det.Items[i].SubItems[10].Text); //'   Sin IGV
                    objCPE_DETALLE.PRECIO_CONIGV = Convert.ToDecimal(lsv_Det.Items[i].SubItems[3].Text); //'precio con IGV .. solo para la Impresion del PDF
                    objCPE_DETALLE.IMPORTE = Convert.ToDecimal(lsv_Det.Items[i].SubItems[11].Text); //'  sub Total sin IGV
                    objCPE_DETALLE.IMPORTE_CONIGV = Convert.ToDecimal(lsv_Det.Items[i].SubItems[4].Text); //'importe con IGV solo para la Impresion del PDF
                    objCPE_DETALLE.PRECIO_TIPO_CODIGO = "01"; //'01=Precio que Incluye el IGV ---
                    objCPE_DETALLE.IGV = Convert.ToDecimal(lsv_Det.Items[i].SubItems[12].Text); //' Igv sacado del SubTotal sin IGV
                    objCPE_DETALLE.ISC = 0; //'
                    objCPE_DETALLE.COD_TIPO_OPERACION = "10"; //'10= gravado -- 20=exonerado
                    objCPE_DETALLE.CODIGO = lsv_Det.Items[i].SubItems[0].Text; //' vObjTempComprobante.Rows(Z)([ª0000ª]).ToString
                    objCPE_DETALLE.DESCRIPCION = lsv_Det.Items[i].SubItems[1].Text; //' vObjTempComprobante.Rows(Z)([ª0000ª]).ToString
                    objCPE_DETALLE.SUB_TOTAL = Convert.ToDecimal(lsv_Det.Items[i].SubItems[11].Text); //subtotal sin IGV
                    objCPE_DETALLE.PRECIO_SIN_IMPUESTO = Convert.ToDecimal(lsv_Det.Items[i].SubItems[10].Text); //' [ª0000ª] ''CDec(vObjTempComprobante.Rows(Z)([ª0001ª]))
                    OBJCPE_DETALLE_LIST.Add(objCPE_DETALLE);

                }

                objCPE.detalle = OBJCPE_DETALLE_LIST;
                //======================================RESPUESTA====================================
                Dictionary<string, string> dictionaryEnv = new Dictionary<string, string>();
                //Frm_Espere.Lbl_xmsm.Text = "Enviando el Documento para Tratarlo";
                //Frm_Espere.Lbl_xmsm.Refresh();
                //Frm_Espere.Refresh();

                dictionaryEnv = obj.Enviar_Boleta_Factura_Sunat(objCPE);

                //lbl_rutaxml.Text = obj.RutaCompletaxml;


                //'Respuesta de la Sunat:
                TXTCOD_SUNAT.Text = dictionaryEnv["cod_sunat"];
                TXT_MSJ_SUNAT.Text = dictionaryEnv["msj_sunat"];
                //xcodsunat = dictionaryEnv["cod_sunat"];
                //xMsg = dictionaryEnv["msj_sunat"];
                TXTHASHCPE.Text = dictionaryEnv["hash_cpe"];
                TXTHASHCDR.Text = dictionaryEnv["hash_cdr"];



            }
            catch (Exception ex)
            {

                MessageBox.Show("Creado Variable Para el XML: " + "\r\n" + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        public void GenerarQR(string tipodoc, string totalDoc, string Cliente, string nroDoc, string rutaqr)
        {
            QRCodeEncoder generarCodigoQR = new QRCodeEncoder();
            generarCodigoQR.QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.BYTE;
            generarCodigoQR.QRCodeScale = Int32.Parse("4");

            try
            {
                generarCodigoQR.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.M;
                //La versión "0" calcula automáticamente el tamaño
                generarCodigoQR.QRCodeVersion = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al Generar QR 1: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            //' -----------------------------------------------------
            string contenido;
            contenido = "Nro: " + nroDoc + "\r\n" + "Documento: " + tipodoc + "\r\n" + "Total: " + totalDoc + "\r\n" + "Cliente: " + Cliente;

            System.Drawing.Bitmap imgQR;

            try
            {

                imgQR = new System.Drawing.Bitmap(generarCodigoQR.Encode(contenido, System.Text.Encoding.UTF8));
                pic_qr.Image = imgQR;
                // imgQR.Save(rutaqr); //'Aqui Guarda la Primera Imagen QR en .BMP
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al Generar QR 2: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }


        }
        public static byte[] Convertir_Imagen_Bytes(Image img)
        {
            string sTemp = Path.GetTempFileName();
            FileStream fs = new FileStream(sTemp, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            img.Save(fs, System.Drawing.Imaging.ImageFormat.Png);
            fs.Position = 0;

            int imgLength = Convert.ToInt32(fs.Length);
            byte[] bytes = new byte[imgLength];
            fs.Read(bytes, 0, imgLength);
            fs.Close();
            return bytes;
        }
        private void Limpiar_todo()
        {
            lsv_Det.Items.Clear();
            txt_cliente.Text = "";
            lbl_idcliente.Text = "-";
            lbl_totalGanancia.Text = "0";
            lbl_subtotal.Text = "0";
            lbl_igv.Text = "0";
            lbl_totalGanancia.Text = "0";
            lbl_Limit_Cred.Text = "0";
            lbl_dni_ruc.Text = "";
            cbo_tipoPago.SelectedIndex = -1;
            Cbo_TipoDoc.SelectedIndex = -1;
            lbl_saldoPdnte.Text = "0";
            lbl_totalVale.Text = "0";
        }       
        private void Buscar_Documento_paraReimprimir(string nroDoc)
        {
            RN_Documento obj = new RN_Documento();
            DataTable dato = new DataTable();
            Frm_Advertencia ver = new Frm_Advertencia();
            Frm_Filtro fil = new Frm_Filtro();

            string descripProd;
            //string nroSerie = "";
            string estadoDoc;
            int tipoDoc;
            //string xtipoProd;
            string xidprod;

            try
            {
                dato = obj.RN_Buscar_Documento_y_Detalle(nroDoc.Trim());
                if (dato.Rows.Count > 0)
                {
                    var dt = dato.Rows[0];
                    //Validamos el Documento:
                    tipoDoc = Convert.ToInt32(dt["Id_Tipo"]);
                    estadoDoc = Convert.ToString(dt["CDR_Sunat"]);

                    if (tipoDoc == 3) { fil.Show(); ver.lbl_msm.Text = "El Documento ingresado no Es Valido, por Ser Nota de Venta, Ingrese una FE o BE"; ver.ShowDialog(); fil.Hide(); return; }
                    if (estadoDoc.Trim() == "Aprobado") { fil.Show(); ver.lbl_msm.Text = "El Documento ingresado ya ha sido Declarado y Aprobado por la Suant"; ver.ShowDialog(); fil.Hide(); return; }



                    txt_NroDoc.Text = Convert.ToString(dt["id_Doc"]).Trim();
                    txt_nroPed.Text = Convert.ToString(dt["id_Ped"]).Trim();
                    Cbo_TipoDoc.SelectedValue = Convert.ToInt32(dt["Id_Tipo"]);
                    dtp_FechaEmi.Value = Convert.ToDateTime(dt["Fecha_Emi"]);
                    txt_NroOperac.Text = Convert.ToString(dt["Nro_Operacion"]).Trim();
                    cbo_tipoPago.Text = Convert.ToString(dt["TipoPago"]).Trim();
                    lbl_idcliente.Text = Convert.ToString(dt["Id_Cliente"]).Trim();
                    txt_cliente.Text = Convert.ToString(dt["Razon_Social_Nombres"]).Trim();
                    lbl_direccion.Text = Convert.ToString(dt["Direccion"]).Trim();
                    lbl_dni_ruc.Text = Convert.ToString(dt["DNI"]).Trim();
                    if (lbl_dni_ruc.Text.Trim().Length == 8)
                    {
                        Lbl_IDTipoDoc_Cli.Text = "1";
                    }
                    else if (lbl_dni_ruc.Text.Trim().Length == 11)
                    {
                        Lbl_IDTipoDoc_Cli.Text = "6";
                    }
                    else
                    {
                        Lbl_IDTipoDoc_Cli.Text = "00";
                    }



                    //detalle del documento:
                    foreach (DataRow xitem in dato.Rows)
                    {
                        ListViewItem xlist;
                        xlist = lsv_Det.Items.Add(xitem["Id_Pro"].ToString().Trim());
                        xidprod = xitem["Id_Pro"].ToString().Trim();
                        descripProd = xitem["Descripcion_Larga"].ToString().Trim();
                        //nroSerie = xitem["NroSerie_prod"].ToString();

                        xlist.SubItems.Add(descripProd.Trim());
                        xlist.SubItems.Add(xitem["Cantidad"].ToString().Trim());
                        xlist.SubItems.Add(xitem["Precio_ConIgv"].ToString().Trim());
                        xlist.SubItems.Add(xitem["Importe_ConIgv"].ToString().Trim());
                        xlist.SubItems.Add("Producto".ToString().Trim());
                        xlist.SubItems.Add(xitem["Und_Medida"].ToString().Trim());  //und, bls, kg, cja
                        xlist.SubItems.Add(xitem["Utilidad_Unit"].ToString().Trim());
                        xlist.SubItems.Add(xitem["TotalUtilidad"].ToString().Trim());

                        xlist.SubItems.Add(xitem["AfectoIGV"].ToString().Trim());
                        xlist.SubItems.Add(xitem["Precio_sinIgv"].ToString().Trim());
                        xlist.SubItems.Add(xitem["subtotal_sinIgv"].ToString().Trim());
                        xlist.SubItems.Add(xitem["Igv_subtotal"].ToString().Trim());
                        xlist.SubItems.Add("NIU");  //NIU -- ZZ
                                                    //if (xtipoProd.Trim()=="Producto")
                                                    //{
                                                    //    xlist.SubItems.Add("NIU");  //NIU -- ZZ
                                                    //}
                                                    //else
                                                    //{
                                                    //    xlist.SubItems.Add("ZZ");  //NIU -- ZZ
                                                    //}

                    }
                    Calcular();
                    pnl_sinProd.Visible = false;
                }
                else
                {

                    fil.Show();
                    ver.lbl_msm.Text = "el Documento que buscas no Existe";
                    ver.ShowDialog();
                    fil.Hide();
                    return;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error al leer: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }


        }
        private void cbo_tipoPago_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbo_tipoPago.Text == "Deposito")
            {
                txt_NroOperac.ReadOnly = false;
                txt_NroOperac.Focus();
            }
            else
            {
                txt_NroOperac.Text = "-";
                txt_NroOperac.ReadOnly = true;
            }
        }
        private void btn_Cancelar_Click(object sender, EventArgs e)
        {
            lsv_Det.Items.Clear();
            Limpiar_todo();
            pnl_sinProd.Visible = true;

        }
        private void Frm_Crear_Ventas_KeyDown(object sender, KeyEventArgs e)
        {


            if (e.KeyCode == Keys.F1)
            {
                if (pnl_sinProd.Visible == true)
                {
                    btn_Nuevo_buscarProd_Click(sender, e);
                }

            }

            if (e.KeyCode == Keys.F5)
            {
                if (pnl_sinProd.Visible == false)
                {
                    btn_procesar_Click(sender, e);
                }

            }
        }
        private void rdb_sunat_CheckedChanged(object sender, EventArgs e)
        {
            if (rdb_sunat.Checked == true)
            {
                lbl_idServer.Text = "1";
                rdb_sunat.BackColor = Color.SkyBlue;
            }
            else
            {
                rdb_sunat.BackColor = Color.WhiteSmoke;
            }
        }
        private void rdb_prueba_CheckedChanged(object sender, EventArgs e)
        {
            if (rdb_prueba.Checked == true)
            {
                lbl_idServer.Text = "3";
                rdb_prueba.BackColor = Color.SkyBlue;
            }
            else
            {
                rdb_prueba.BackColor = Color.WhiteSmoke;
            }
        }
        private void Cbo_TipoDoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Cbo_TipoDoc.SelectedIndex == 0)
            {
                Lbl_TipoFac_Id.Text = "00";
            }
            else if (Cbo_TipoDoc.SelectedIndex == 1)
            {
                Lbl_TipoFac_Id.Text = "03";
            }
            else if (Cbo_TipoDoc.SelectedIndex == 2)
            {
                Lbl_TipoFac_Id.Text = "01";
            }

        }
        private void btn_comprobar_Click(object sender, EventArgs e)
        {
            RN_Documento objDoc = new RN_Documento();
            Frm_Filtro fil = new Frm_Filtro();
            Frm_Msm_Bueno ok = new Frm_Msm_Bueno();


            // txt_NroDoc.Text = RN_TipoDoc.RN_NroID(Convert.ToInt32(Cbo_TipoDoc.SelectedValue));
            enviarComprobante_dePrueba_Sunat();
            if (TXTCOD_SUNAT.Text.Trim() == "0" || TXTCOD_SUNAT.Text.Trim() == "1")
            {
                objDoc.RN_Cambiar_RPT_EstadoSunat(txt_NroDoc.Text, "Aprobado", TXTHASHCPE.Text);
                tocar_timbreCaja();

                //terminar la Venta:
                fil.Show();
                ok.Lbl_msm1.Text = "El Comprobante fue Aceptado por la Sunat";
                ok.ShowDialog();
                fil.Hide();

                Limpiar_todo();
                pnl_sinProd.Visible = true;
                //limpiar todo:
            }  //fin
            else
            {
                //NO se ha  Aprobado:
                objDoc.RN_Cambiar_RPT_EstadoSunat(txt_NroDoc.Text, "Rechazado", TXTHASHCPE.Text);
                tocar_timbreCaja();

                //terminar la Venta:
                fil.Show();
                ok.Lbl_msm1.Text = "El comprobante fue Rechazado por Sunat: " + TXT_MSJ_SUNAT.Text;
                ok.ShowDialog();
                fil.Hide();
                Limpiar_todo();
                pnl_sinProd.Visible = true;
            }
        }
        internal void enviarComprobante_dePrueba_Sunat()
        {
            try
            {
                objCPE.TIPO_OPERACION = "0101"; //'0101=Venta Interna
                objCPE.TOTAL_GRAVADAS = Convert.ToDecimal(lbl_subtotal.Text); //SUB TOTAL
                objCPE.SUB_TOTAL = Convert.ToDecimal(lbl_subtotal.Text); //SUB TOTAL
                objCPE.POR_IGV = 18; //NUEVO UBL 2.1
                objCPE.TOTAL_IGV = Convert.ToDecimal(lbl_igv.Text); //TOTAL IGV
                objCPE.TOTAL_ISC = 0;
                objCPE.TOTAL_OTR_IMP = 0;
                objCPE.TOTAL_DESCUENTOGLO = 0;
                objCPE.TOTAL = Convert.ToDecimal(lbl_TotalPagar.Text); //TOTAL COMPROBANTE
                objCPE.TOTAL_EXPORTACION = 0; //NUEVO UBL 2.1
                objCPE.TOTAL_LETRAS = lbl_son.Text;
                objCPE.NRO_GUIA_REMISION = "";
                objCPE.FECHA_GUIA_REMISION = ""; //NUEVO UBL 2.1
                objCPE.COD_GUIA_REMISION = "";
                objCPE.NRO_OTR_COMPROBANTE = "";
                objCPE.COD_OTR_COMPROBANTE = "";
                objCPE.NRO_COMPROBANTE = txt_NroDoc.Text; //' TXTSERIE.Text & [ª0000ª] & TXTNUMERO.Text // F001-0000001 // B001-55655   F012-000000000 - B012
                objCPE.FECHA_DOCUMENTO = dtp_FechaEmi.Value.ToString("yyyy-MM-dd"); //[ª0001ª]
                objCPE.FECHA_VTO = dtp_FechaEmi.Value.ToString("yyyy-MM-dd"); //NUEVO UBL 2.1
                objCPE.COD_TIPO_DOCUMENTO = Lbl_TipoFac_Id.Text; //'01=factura , 03= Boleta

                //objCPE.COD_TIPO_DOCUMENTO = CBOTIPOCOMPROBANTE.SelectedValue  '01=FACTURA, 03=BOLETA, 07=NOTA CREDITO, 08=NOTA DEBITO
                objCPE.COD_MONEDA = "PEN"; //cbo_moneda.SelectedValue; //' [ª0000ª]
                                           //==============PARA PLAA DE VEHICULO SOLO PARA LOS QUE VENDEN GASOLINA. OSEA PARA LOS GRIFOS=============
                                           //objCPE.PLACA_VEHICULO = "-" ' txtplaca_vehiculo.Text
                                           //========================DATOS NOTA CREDITO/NOTA DEBITO==========================
                objCPE.TIPO_COMPROBANTE_MODIFICA = ""; //'Nota Credito
                objCPE.NRO_DOCUMENTO_MODIFICA = ""; //'Lbl_Nro_Doc.Text '' [ª0001ª]
                objCPE.COD_TIPO_MOTIVO = "";
                objCPE.DESCRIPCION_MOTIVO = "";
                //========================DATOS DEL CIENTE==========================
                objCPE.NRO_DOCUMENTO_CLIENTE = lbl_dni_ruc.Text.Trim();
                objCPE.RAZON_SOCIAL_CLIENTE = txt_cliente.Text.Trim();
                objCPE.TIPO_DOCUMENTO_CLIENTE = Lbl_IDTipoDoc_Cli.Text; //' Cbo_TipoDocCliente.Text    '1=DNI,6=RUC
                objCPE.DIRECCION_CLIENTE = lbl_direccion.Text.Trim();
                objCPE.CIUDAD_CLIENTE = "LIMA";
                objCPE.COD_PAIS_CLIENTE = "PE";
                objCPE.COD_UBIGEO_CLIENTE = ""; ////NUEVO UBL2.1
                objCPE.DEPARTAMENTO_CLIENTE = ""; ////NUEVO UBL2.1
                objCPE.PROVINCIA_CLIENTE = ""; ////NUEVO UBL2.1
                objCPE.DISTRITO_CLIENTE = ""; ////NUEVO UBL2.1
                                              //=============================DATOS EMPRESA===========================
                objCPE.NRO_DOCUMENTO_EMPRESA = Lbl_RucEmisor.Text.Trim(); //' [ª0000ª]
                objCPE.TIPO_DOCUMENTO_EMPRESA = "6"; //1=DNI,6=RUC
                objCPE.NOMBRE_COMERCIAL_EMPRESA = Lbl_EmpresaEmisor.Text.Trim(); //' [ª0000ª]
                objCPE.CODIGO_UBIGEO_EMPRESA = "150101"; //TABLA UBIGEO
                objCPE.DIRECCION_EMPRESA = Lbl_DireccionEmpresa.Text.Trim(); //' [ª0000ª]
                objCPE.DEPARTAMENTO_EMPRESA = "LIMA";
                objCPE.PROVINCIA_EMPRESA = "LIMA";
                objCPE.DISTRITO_EMPRESA = "LIMA";
                objCPE.CODIGO_PAIS_EMPRESA = "PE";
                objCPE.RAZON_SOCIAL_EMPRESA = Lbl_EmpresaEmisor.Text.Trim(); //'  [ª0000ª]
                objCPE.CONTACTO_EMPRESA = ""; //NUEVO UBL 2.1
                objCPE.USUARIO_SOL_EMPRESA = Lbl_UsuarioSol.Text.Trim(); //'  [ª0000ª]
                objCPE.PASS_SOL_EMPRESA = Lbl_ClaveSol.Text.Trim(); //' [ª0000ª]
                objCPE.CONTRA_FIRMA = Lbl_CertificadoClave.Text.Trim(); //' [ª0000ª] 'Lbl_CertificadoClave.Text.Trim '' [ª0001ª]

                // int xtip = Convert.ToInt32(lbl_idServer.Text);
                objCPE.TIPO_PROCESO = 3;


                //===================VARIABLE PARA LAS LISTAS==================
                List<businessEntities.CPE_DETALLE> OBJCPE_DETALLE_LIST = new List<businessEntities.CPE_DETALLE>();
                //'Prueba al Jalar del Listview que Tengo
                for (int i = 0; i < lsv_Det.Items.Count; i++)
                {
                    objCPE_DETALLE = new businessEntities.CPE_DETALLE();
                    objCPE_DETALLE.ITEM = i + 1;
                    objCPE_DETALLE.UNIDAD_MEDIDA = lsv_Det.Items[i].SubItems[13].Text; //'[ª0000ª] ''.SubItems(2).Text '' vObjTempComprobante.Rows(Z)([ª0001ª]).ToString 'UNIDAD MEDIDA SEGUN CATALOGO 8
                    objCPE_DETALLE.CANTIDAD = Convert.ToDecimal(lsv_Det.Items[i].SubItems[2].Text); //'
                    objCPE_DETALLE.PRECIO = Convert.ToDecimal(lsv_Det.Items[i].SubItems[10].Text); //'   Sin IGV
                    objCPE_DETALLE.PRECIO_CONIGV = Convert.ToDecimal(lsv_Det.Items[i].SubItems[3].Text); //'precio con IGV .. solo para la Impresion del PDF
                    objCPE_DETALLE.IMPORTE = Convert.ToDecimal(lsv_Det.Items[i].SubItems[11].Text); //'  sub Total sin IGV
                    objCPE_DETALLE.IMPORTE_CONIGV = Convert.ToDecimal(lsv_Det.Items[i].SubItems[4].Text); //'importe con IGV solo para la Impresion del PDF
                    objCPE_DETALLE.PRECIO_TIPO_CODIGO = "01"; //'01=Precio que Incluye el IGV ---
                    objCPE_DETALLE.IGV = Convert.ToDecimal(lsv_Det.Items[i].SubItems[12].Text); //' Igv sacado del SubTotal sin IGV
                    objCPE_DETALLE.ISC = 0; //'
                    objCPE_DETALLE.COD_TIPO_OPERACION = "10"; //'10= gravado -- 20=exonerado
                    objCPE_DETALLE.CODIGO = lsv_Det.Items[i].SubItems[0].Text; //' vObjTempComprobante.Rows(Z)([ª0000ª]).ToString
                    objCPE_DETALLE.DESCRIPCION = lsv_Det.Items[i].SubItems[1].Text; //' vObjTempComprobante.Rows(Z)([ª0000ª]).ToString
                    objCPE_DETALLE.SUB_TOTAL = Convert.ToDecimal(lsv_Det.Items[i].SubItems[11].Text); //subtotal sin IGV
                    objCPE_DETALLE.PRECIO_SIN_IMPUESTO = Convert.ToDecimal(lsv_Det.Items[i].SubItems[10].Text); //' [ª0000ª] ''CDec(vObjTempComprobante.Rows(Z)([ª0001ª]))
                    OBJCPE_DETALLE_LIST.Add(objCPE_DETALLE);

                }

                objCPE.detalle = OBJCPE_DETALLE_LIST;
                //======================================RESPUESTA====================================
                Dictionary<string, string> dictionaryEnv = new Dictionary<string, string>();
                //Frm_Espere.Lbl_xmsm.Text = "Enviando el Documento para Tratarlo";
                //Frm_Espere.Lbl_xmsm.Refresh();
                //Frm_Espere.Refresh();

                dictionaryEnv = obj.Enviar_Boleta_Factura_Sunat(objCPE);

                //lbl_rutaxml.Text = obj.RutaCompletaxml;


                //'Respuesta de la Sunat:
                TXTCOD_SUNAT.Text = dictionaryEnv["cod_sunat"];
                TXT_MSJ_SUNAT.Text = dictionaryEnv["msj_sunat"];
                //xcodsunat = dictionaryEnv["cod_sunat"];
                //xMsg = dictionaryEnv["msj_sunat"];
                TXTHASHCPE.Text = dictionaryEnv["hash_cpe"];
                TXTHASHCDR.Text = dictionaryEnv["hash_cdr"];

                if (TXTCOD_SUNAT.Text == "0" || TXTCOD_SUNAT.Text == "1")
                {
                    MessageBox.Show("La FE está ha Sido Probado y Califica para ser Enviado a Sunat", "Comprobacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("El comprobante fue Rechazado: " + TXT_MSJ_SUNAT.Text, "Comprobacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }



            }
            catch (Exception ex)
            {

                MessageBox.Show("Creado Variable Para el XML: " + "\r\n" + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void btn_Nuevo_buscarProd_Click(object sender, EventArgs e)
        {
            Frm_Filtro fil = new Frm_Filtro();
            Frm_Nro_FE num = new Frm_Nro_FE();

            fil.Show();
            num.ShowDialog();
            fil.Hide();

            if (num.Tag.ToString() == "A")
            {
                string nroDoc = num.txt_nro.Text;
                Buscar_Documento_paraReimprimir(nroDoc);
            }

        }
    }
}
