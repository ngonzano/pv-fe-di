using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsell_Lite.Compras;

using Gma.QrCodeNet.Encoding;
using QRCoder;
using ThoughtWorks.QRCode;
using ThoughtWorks.QRCode.Codec;

//importar:
using SPV_Capa_Entidad;
using SPV_Capa_Negocio;
using System.IO;
using Microsell_Lite.Utilitarios;
using Microsell_Lite.Productos;
using Microsell_Lite.Cliente;
using Microsell_Lite.Informe;
using Microsell_Lite.Ventas;

using BE = businessEntities;
using CPEEnvio;
using CrearXML;
using Signature;
using Microsell_Lite.Principal;
using Microsell_Lite.NotaCredito;

namespace Microsell_Lite.Ventas
{
    public partial class Frm_Anular_FE : Form
    {
        public Frm_Anular_FE()
        {
            InitializeComponent();
        }

        private void Frm_Ventana_Ventas_Load(object sender, EventArgs e)
        {

            Configurar_listView();
            Llenar_Combo_docs();
            cbo_tipoPago.SelectedIndex = 0;
            rdb_devolStock.Checked = false;
            rdb_SindevolStock.Checked = false;
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
            //lbl_totalGanancia.Text = xTotalGanancia.ToString("###0.00");

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
            if (txt_NroDoc.Text.Length < 10) { fil.Show(); ver.lbl_msm.Text = "No se encontro el Documento o No es Valido."; ver.ShowDialog(); fil.Hide(); return false; }
            if (lbl_op.Text.Length <= 1) { fil.Show(); ver.lbl_msm.Text = "Elegir si se va Anular devolviendo o sin devolver Producto."; ver.ShowDialog(); fil.Hide(); return false; }

            return true;
        }





        private void Guardar_Documento()
        {

            RN_Documento obj = new RN_Documento();
            EN_Documento doc = new EN_Documento();
            int rpt;
            try
            {

                txt_NroDoc.Text = RN_TipoDoc.Sp_Listado_Tipo(Convert.ToInt32(Cbo_TipoDoc.SelectedValue));
                //los parametros:
                doc.Id_Doc = txt_NroDoc.Text;
                doc.Id_Ped = txt_nroPed.Text;
                doc.Id_Tipo = Convert.ToInt32(Cbo_TipoDoc.SelectedValue);
                doc.Fecha_Emi = dtp_FechaEmi.Value;
                doc.Importe = Convert.ToDouble(lbl_TotalPagar.Text);
                doc.TipoPago = cbo_tipoPago.Text;
                // doc.NroOpera = txt_NroOperac.Text;
                doc.Id_Usu = Cls_UsuLogin.IdUsu;
                doc.Igv = Convert.ToDouble(lbl_igv.Text);
                doc.Son = lbl_son.Text;
                //doc.TotalGanancia = Convert.ToDouble(lbl_totalGanancia.Text);
                doc.CDR_Sunat = "Pendiente";

                rpt = obj.RN_Ingresar_Documento(doc);

                if (rpt == 1)
                {
                    RN_TipoDoc.RN_Actualizar_SiguienteNro_correlativo(Convert.ToInt32(Cbo_TipoDoc.SelectedValue));
                }



            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }



        }



        private void Guardar_IngresoCaja()
        {

            RN_Caja obj = new RN_Caja();
            EN_Caja cja = new EN_Caja();

            try
            {

                cja.Fecha_Caja = dtp_FechaEmi.Value;
                cja.Tipo_Caja = "Entrada";
                cja.Concepto = "Por Ventas al Publico";
                cja.De_Para = txt_cliente.Text;
                cja.Nro_Doc = txt_NroDoc.Text;
                cja.ImporteCaja = Convert.ToDouble(lbl_TotalPagar.Text);
                cja.Id_Usu = Cls_UsuLogin.IdUsu;
                //cja.TotalUti = Convert.ToDouble(lbl_totalGanancia.Text);
                cja.TipoPago = cbo_tipoPago.Text;
                cja.GeneradoPor = Cbo_TipoDoc.Text;

                obj.RN_Ingresar_Caja(cja);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }


        }


        //int Prod_Krd = 0;

        private void Registrar_MoviemtoKardex()
        {
            RN_Kardex obj = new RN_Kardex();
            EN_Kardex kar = new EN_Kardex();
            RN_Producto objpro = new RN_Producto();
            DataTable dato = new DataTable();
            DataTable datoprod = new DataTable();



            string xidkardex = "";
            int xitem = 0;
            double stockProd = 0;
            double precioCompraProd = 0;

            string xidProd = "";
            double xcant = 0;
            string xTipoProd = "";




            try
            {

                for (int i = 0; i < lsv_Det.Items.Count; i++)
                {
                    var lis = lsv_Det.Items[i];

                    xidProd = lis.SubItems[0].Text;
                    xcant = Convert.ToDouble(lis.SubItems[2].Text);
                    xTipoProd = lis.SubItems[5].Text;

                    if (obj.RN_Sp_Ver_sihay_Kardex(xidProd) == true)
                    {
                        dato = obj.RN_BuscarKardexDetalleProducto(xidProd.Trim());
                        if (dato.Rows.Count > 0)
                        {
                            xidkardex = Convert.ToString(dato.Rows[0]["Id_krdx"]);
                            xitem = dato.Rows.Count;
                            //leemos los datos del producto:
                            datoprod = objpro.RN_Buscar_Producto(xidProd.Trim());
                            stockProd = Convert.ToDouble(datoprod.Rows[0]["Stock_Actual"]);
                            precioCompraProd = Convert.ToDouble(datoprod.Rows[0]["Pre_CompraS"]);

                            //registramos el Detalle del Kardex:
                            kar.Id_Krdx = xidkardex;
                            kar.Item = xitem + 1;
                            kar.Doc_Soport = txt_NroDoc.Text;
                            kar.Det_Operacion = "Por Anulacion de Venta";
                            //Entrada:
                            kar.Cantidad_In = xcant;
                            kar.Precio_Unt_In = precioCompraProd;
                            kar.Costo_Total_In = xcant * precioCompraProd;
                            //salida:
                            kar.Cantidad_Out = 0;
                            kar.Precio_Unt_Out = 0;
                            kar.Importe_Total_Out = 0;
                            //saldos:
                            kar.Cantidad_Saldo = stockProd + xcant;
                            kar.Promedio = precioCompraProd;
                            kar.Costo_Total_Saldo = precioCompraProd * kar.Cantidad_Saldo;

                            obj.RN_Registrar_det_Kardex(kar);

                            //ahora acrtalizamos nuestro stock de la tabla productos:
                            objpro.RN_SumarStock_Producto(xidProd.Trim(), xcant);

                            //Prod_Krd += 1;
                        }
                    }
                }  //fin del For: 




            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Reg Kardex Capa Cliente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }




        }
        private void btn_procesar_Click(object sender, EventArgs e)
        {
            Frm_Filtro fil = new Frm_Filtro();
            Frm_Msm_Bueno ok = new Frm_Msm_Bueno();
            RN_Documento objDoc = new RN_Documento();
            RN_Caja caja = new RN_Caja();
            RN_Credito credito = new RN_Credito();
            Frm_TerminarNotaCred fin = new Frm_TerminarNotaCred();

            DataTable dtCaja = new DataTable();
            DataTable dtCredito = new DataTable();
            int rpt;
            int rpt2;
            try
            {
                if (Validar_Antes_Vender() == true)
                {
                    rpt = objDoc.RN_Anular_Documento(txt_NroDoc.Text, "Anulado");
                    if (rpt == 1)
                    {
                        rpt2 = caja.RN_AnularMovCaja(txt_NroDoc.Text, "Anulado");
                        if (rpt2 == 1)
                        {
                            dtCredito = credito.RN_Buscar_Credito_Documento(txt_NroDoc.Text);
                            if (dtCredito.Rows.Count > 0)
                            {
                                string v_idCredito = dtCredito.Rows[0]["IdNotaCred"].ToString();
                                credito.RN_Eliminar_credito_Permanente(v_idCredito);
                            }
                            if (rdb_devolStock.Checked == true)
                            {
                                Registrar_MoviemtoKardex();
                                //for (int i = 0; i < lsv_Det.Items.Count; i++)
                                //{
                                //    var lis = lsv_Det.Items[i];
                                //
                                //    idProducto = lis.SubItems[0].Text;
                                //    xCantidad = Convert.ToDouble(lis.SubItems[2].Text);
                                //   
                                //}
                            }
                            fil.Show();
                            fin.label2.Text = "Total Del Comprobante";
                            fin.label3.Text = "Que haras con el Importe del Documento?";
                            fin.lbl_totalDoc.Text = lbl_TotalPagar.Text;
                            fin.ShowDialog();
                            fil.Hide();

                            if (fin.Tag.ToString()=="A")
                            {
                                string opcion = fin.lbl_op.Text;
                                if (opcion.Trim()=="Nada")
                                {
                                    fil.Show();
                                    ok.Lbl_msm1.Text = "El Documento fue Anulado.";
                                    ok.ShowDialog();
                                    fil.Hide();
                                    this.Close();
                                }
                                else if (opcion.Trim() == "Salida")
                                {
                                    Guardar_Egreso_Caja();
                                    fil.Show();
                                    ok.Lbl_msm1.Text = "El Documento fue Anulado.";
                                    ok.ShowDialog();
                                    fil.Hide();
                                    this.Close();
                                }
                                else if (opcion.Trim() == "Vale")
                                {
                                    //

                                }
                            }

                           
                            
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
        }
        private void Guardar_Egreso_Caja()
        {
            EN_Caja e_caja = new EN_Caja();
            RN_Caja n_caja = new RN_Caja();
            int rpt;
            try
            {
                e_caja.Fecha_Caja = dtp_FechaEmi.Value;
                e_caja.Tipo_Caja = "Salida";
                e_caja.Concepto = "Por Anulacion de Comprobante.";
                e_caja.De_Para = txt_cliente.Text;
                e_caja.ImporteCaja = Convert.ToDouble(lbl_TotalPagar.Text);
                e_caja.Id_Usu = Cls_UsuLogin.IdUsu;
                e_caja.TotalUti = 0;
                e_caja.TipoPago = cbo_tipoPago.Text;
                e_caja.GeneradoPor = Cbo_TipoDoc.Text;
                e_caja.Nro_Doc = txt_NroDoc.Text;
                rpt = n_caja.RN_Ingresar_Caja(e_caja);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al Guardar: " + ex.Message, "Guardar_Egreso_Caja", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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

        private void tocar_timbre_Aparecer()
        {
            string ruta;
            ruta = Application.StartupPath;
            System.Media.SoundPlayer son;
            son = new System.Media.SoundPlayer(ruta + @"\EspadaEfect.wav");
            son.Play();

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
            lbl_subtotal.Text = "0";
            lbl_igv.Text = "0";
            cbo_tipoPago.SelectedIndex = -1;
            Cbo_TipoDoc.SelectedIndex = -1;
        }
        private void Buscar_Producto_DeCotizacion(string idprdcto)
        {
            RN_Producto obj = new RN_Producto();
            DataTable data = new DataTable();

            try
            {
                data = obj.RN_Buscar_Producto(idprdcto);
                if (data.Rows.Count > 0)
                {
                    lbl_StockProdx.Text = Convert.ToString(data.Rows[0]["Stock_Actual"]);
                    lbl_tipoProdx.Text = Convert.ToString(data.Rows[0]["TipoProdcto"]);

                }

            }
            catch (Exception ex)
            {

                MessageBox.Show("Error al Guardar: " + ex.Message, "Form Add Proveedor", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }


        }

        private void Buscar_Documento_paraReimprimir(string nroDoc)
        {
            RN_Documento obj = new RN_Documento();
            DataTable dato = new DataTable();
            Frm_Advertencia ver = new Frm_Advertencia();
            Frm_Filtro fil = new Frm_Filtro();

            string descripProd = "";
            //string nroSerie = "";
            string estadoDoc = "";
            int tipoDoc = 0;
            string xtipoProd = "";
            string xidprod;

            try
            {
                dato = obj.RN_Buscar_Documento_y_Detalle(nroDoc.Trim());
                if (dato.Rows.Count > 0)
                {
                    var dt = dato.Rows[0];
                    //Validamos el Documento:
                    estadoDoc = Convert.ToString(dt["Estado_Doc"]);

                    if (estadoDoc.Trim() == "Anulado") { fil.Show(); ver.lbl_msm.Text = "El Documento ingresado ya ha sido Anulado"; ver.ShowDialog(); fil.Hide(); return; }
                    if (estadoDoc.Trim() == "Canjeado") { fil.Show(); ver.lbl_msm.Text = "El Documento ingresado ya ha sido Canjeado"; ver.ShowDialog(); fil.Hide(); return; }



                    txt_NroDoc.Text = Convert.ToString(dt["id_Doc"]).Trim();
                    txt_nroPed.Text = Convert.ToString(dt["id_Ped"]).Trim();
                    Cbo_TipoDoc.SelectedValue = Convert.ToInt32(dt["Id_Tipo"]);
                    dtp_FechaEmi.Value = Convert.ToDateTime(dt["Fecha_Emi"]);
                    cbo_tipoPago.Text = Convert.ToString(dt["TipoPago"]).Trim();
                    lbl_idcliente.Text = Convert.ToString(dt["Id_Cliente"]).Trim();
                    txt_cliente.Text = Convert.ToString(dt["Razon_Social_Nombres"]).Trim();


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

        private void rdb_devolStock_CheckedChanged(object sender, EventArgs e)
        {
            if (rdb_devolStock.Checked == true)
            {
                lbl_op.Text = "Devolver";
            }
        }

        private void rdb_SindevolStock_CheckedChanged(object sender, EventArgs e)
        {
            if (rdb_SindevolStock.Checked == true)
            {
                lbl_op.Text = "NoDevolver";
            }
        }

    }
}
