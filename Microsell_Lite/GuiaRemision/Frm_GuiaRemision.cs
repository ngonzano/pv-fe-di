using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SPV_Capa_Entidad;
using SPV_Capa_Negocio;
using Microsell_Lite.Utilitarios;
using BE = businessEntities;
using CPEEnvio;
using CrearXML;
using Signature;
using ThoughtWorks.QRCode.Codec;
using System.IO;
using Microsell_Lite.Principal;
using Microsell_Lite.Ventas;
using Microsell_Lite.Compras;

namespace Microsell_Lite.GuiaRemision
{
    public partial class Frm_GuiaRemision : Form
    {
        public Frm_GuiaRemision()
        {
            InitializeComponent();
        }
        private void Frm_GuiaRemision_Load(object sender, EventArgs e)
        {
            inicio();
            //Config_ListView();
            //dtp_fecha2.Value = dtp_fechaActual.Value;
        }
        void inicio()
        {
            Leer_Dato_empresa();
            cargarComboMotivo();
            cargarCombo_DestinoSunat();
            listar_ComboBox_Departamentos();
            listar_ComboBox_Departamentos_DES();
            cbb_modoTrasldo.SelectedIndex = 0;
            Mostrar_MotTraslado();
            Mostrar_Establecimiento();
            rbt_no.Checked = true;
            Listar_Unidad_Medida();
            Listar_tipo_Documento_cond();
            Listar_tipo_Documento_trans();
        }
        void Mostrar_MotTraslado()
        {
            DataTable dt = new DataTable();
            RN_GuiaRemision n_guia = new RN_GuiaRemision();

            dt = n_guia.RN_Listar_Mot_traslado();
            if (dt.Rows.Count > 0)
            {
                var cbb = cbb_motivoTraslado;
                cbb.DataSource = dt;
                cbb.DisplayMember = "des";
                cbb.ValueMember = "cod";
                cbb.SelectedIndex = 0;

            }
        }
        void Mostrar_Establecimiento()
        {
            DataTable dt = new DataTable();
            RN_GuiaRemision n_guia = new RN_GuiaRemision();

            dt = n_guia.RN_Listar_Establecimiento();
            if (dt.Rows.Count > 0)
            {
                var cbb = cbb_establecimiento;
                cbb.DataSource = dt;
                cbb.DisplayMember = "des";
                cbb.ValueMember = "cod";
                cbb.SelectedIndex = 0;

            }
        }
        void Listar_tipo_Documento_cond()
        {
            DataTable dt = new DataTable();
            RN_GuiaRemision n_prod = new RN_GuiaRemision();

            dt = n_prod.RN_Listar_Tipo_doc();
            if (dt.Rows.Count > 0)
            {
                var cbb = cbb_tipo_doc_ident_cond;
                cbb.DataSource = dt;
                cbb.DisplayMember = "des";
                cbb.ValueMember = "cod";
                cbb.SelectedIndex = 1;
            }
        }
        void Listar_tipo_Documento_trans()
        {
            DataTable dt = new DataTable();
            RN_GuiaRemision n_prod = new RN_GuiaRemision();

            dt = n_prod.RN_Listar_Tipo_doc();
            if (dt.Rows.Count > 0)
            {
                var cbb2 = cbb_tipo_doc_ident_trans;
                cbb2.DataSource = dt;
                cbb2.DisplayMember = "des";
                cbb2.ValueMember = "cod";
                cbb2.SelectedIndex = 1;

            }
        }
        void Listar_Unidad_Medida()
        {
            DataTable dt = new DataTable();
            RN_Producto n_prod = new RN_Producto();

            dt = n_prod.RN_Buscar_UniMedia_Todos();
            if (dt.Rows.Count > 0)
            {
                var cbb = cbb_uniMedida;
                cbb.DataSource = dt;
                cbb.DisplayMember = "des";
                cbb.ValueMember = "cod";
                cbb.SelectedIndex = 2;

            }
        }

        #region UBIGEO_PARTIDA
        void listar_ComboBox_Departamentos()
        {
            DataTable dt = new DataTable();
            RN_GuiaRemision n_guia = new RN_GuiaRemision();
            dt = n_guia.RN_Listar_Departamento();
            if (dt.Rows.Count > 0)
            {
                var cbb = cbb_par_Depar;
                cbb.DataSource = dt;
                cbb.DisplayMember = "Departamento";
                cbb.ValueMember = "ubi_dep";
                cbb.SelectedIndex = 14;
            }
        }
        void listar_ComboBox_Provincia()
        {
            DataTable dt = new DataTable();
            RN_GuiaRemision n_guia = new RN_GuiaRemision();

            dt = n_guia.RN_Listar_Provincia(cbb_par_Depar.SelectedValue.ToString());
            if (dt.Rows.Count > 0)
            {
                var cbb = cbb_par_Prov;
                cbb.DataSource = dt;
                cbb.DisplayMember = "Provincia";
                cbb.ValueMember = "ubi_dep";
                if (cbb_par_Depar.Text=="LIMA")
                {
                    cbb.SelectedIndex = 7;
                }
                listar_ComboBox_Distrito();
            }

        }
        void listar_ComboBox_Distrito()
        {
            DataTable dt = new DataTable();
            RN_GuiaRemision n_guia = new RN_GuiaRemision();

            dt = n_guia.RN_Listar_Distrito(cbb_par_Prov.SelectedValue.ToString());
            if (dt.Rows.Count > 0)
            {
                var cbb = cbb_par_Dist;
                cbb.DataSource = dt;
                cbb.DisplayMember = "Distrito";
                cbb.ValueMember = "ubi_dep";
                if (cbb_par_Prov.Text == "LIMA")
                {
                    cbb.SelectedIndex = 24;
                }
            }
        }
        private void cbb_par_Depar_TextChanged(object sender, EventArgs e)
        {
            listar_ComboBox_Provincia();
        }
        private void cbb_par_Prov_TextChanged(object sender, EventArgs e)
        {
            listar_ComboBox_Distrito();
        }
        #endregion
        #region UBIGEO_DESTINO
        void listar_ComboBox_Departamentos_DES()
        {
            DataTable dt = new DataTable();
            RN_GuiaRemision n_guia = new RN_GuiaRemision();
            dt = n_guia.RN_Listar_Departamento();
            if (dt.Rows.Count > 0)
            {
                var cbb = cbb_lleg_Depar;
                cbb.DataSource = dt;
                cbb.DisplayMember = "Departamento";
                cbb.ValueMember = "ubi_dep";
                cbb.SelectedIndex = 14;
            }
        }
        void listar_ComboBox_Provincia_DES()
        {
            DataTable dt = new DataTable();
            RN_GuiaRemision n_guia = new RN_GuiaRemision();

            dt = n_guia.RN_Listar_Provincia(cbb_lleg_Depar.SelectedValue.ToString());
            if (dt.Rows.Count > 0)
            {
                var cbb = cbb_lleg_Prov;
                cbb.DataSource = dt;
                cbb.DisplayMember = "Provincia";
                cbb.ValueMember = "ubi_dep";
                if (cbb_lleg_Depar.Text == "LIMA")
                {
                    cbb.SelectedIndex = 7;
                }
                listar_ComboBox_Distrito_DES();
            }

        }
        void listar_ComboBox_Distrito_DES()
        {
            DataTable dt = new DataTable();
            RN_GuiaRemision n_guia = new RN_GuiaRemision();

            dt = n_guia.RN_Listar_Distrito(cbb_lleg_Prov.SelectedValue.ToString());
            if (dt.Rows.Count > 0)
            {
                var cbb = cbb_lleg_Dist;
                cbb.DataSource = dt;
                cbb.DisplayMember = "Distrito";
                cbb.ValueMember = "ubi_dep";
                if (cbb_lleg_Prov.Text == "LIMA")
                {
                    cbb.SelectedIndex = 24;
                }
            }
        }

        private void cbb_lleg_Depar_TextChanged(object sender, EventArgs e)
        {
            listar_ComboBox_Provincia_DES();
        }

        private void cbb_lleg_Prov_TextChanged(object sender, EventArgs e)
        {
            listar_ComboBox_Distrito_DES();
        }
        #endregion
        private void Leer_Dato_empresa()
        {
            RN_MiEmpresa obj = new RN_MiEmpresa();
            DataTable data = new DataTable();


            try
            {
                data = obj.RN_Mostrar_Empresa(1);
                if (data.Rows.Count > 0)
                {

                    Lbl_EmpresaEmisor.Text = Convert.ToString(data.Rows[0]["nombrerancho"]);
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
        public void cargarCombo_DestinoSunat()
        {
            DataTable dt;
            dt = new DataTable("Tabla");

            dt.Columns.Add("Codigo");
            dt.Columns.Add("Descripcion");

            DataRow dr;

            dr = dt.NewRow();
            dr["Codigo"] = "1";
            dr["Descripcion"] = "Servidor de Produccion";
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["Codigo"] = "3";
            dr["Descripcion"] = "Servidor de Pruebas";
            dt.Rows.Add(dr);


            dr = dt.NewRow();
            dr["Codigo"] = "0";
            dr["Descripcion"] = "Emitir Nota Cred. sin Enviar";
            dt.Rows.Add(dr);

            //Cbo_DestinoSunat.DataSource = dt;
            //Cbo_DestinoSunat.ValueMember = "Codigo";
            //Cbo_DestinoSunat.DisplayMember = "Descripcion";
        }
        public void cargarComboMotivo()
        {

            DataTable dt;
            dt = new DataTable("Tabla");
            dt.Columns.Add("Codigo");
            dt.Columns.Add("Descripcion");

            DataRow dr;
            // '0
            dr = dt.NewRow();
            dr["Codigo"] = "01";
            dr["Descripcion"] = "Anulación de la Operación";
            dt.Rows.Add(dr);

            // '1
            dr = dt.NewRow();
            dr["Codigo"] = "02";
            dr["Descripcion"] = "Anulación por Error en el RUC";
            dt.Rows.Add(dr);

            // '2
            dr = dt.NewRow();
            dr["Codigo"] = "04";
            dr["Descripcion"] = "Descuento Global";
            dt.Rows.Add(dr);

            // '3
            dr = dt.NewRow();
            dr["Codigo"] = "07";
            dr["Descripcion"] = "Devolucion por Item";
            dt.Rows.Add(dr);

            // '4
            dr = dt.NewRow();
            dr["Codigo"] = "00";
            dr["Descripcion"] = "Reimprimir Nota Credito";
            dt.Rows.Add(dr);


            //cbo_MotivoEmis.DataSource = dt;
            //cbo_MotivoEmis.ValueMember = "Codigo";
            //cbo_MotivoEmis.DisplayMember = "Descripcion";
            //cbo_MotivoEmis.SelectedIndex = -1;
        }
        //private void Config_ListView()
        //{
        //    {
        //        var lis = lsv_Det;
        //        lis.Columns.Clear();
        //        lis.Items.Clear();
        //        lis.View = View.Details;
        //        lis.GridLines = true;
        //        lis.FullRowSelect = true;
        //        lis.Scrollable = true;
        //        lis.HideSelection = false;
        //        // Agregar Columnas a ListView
        //        lis.Columns.Add("ID producto", 80, HorizontalAlignment.Left); //0
        //        lis.Columns.Add("Descripcion producto", 400, HorizontalAlignment.Left);  //1
        //        lis.Columns.Add("cantidad", 80, HorizontalAlignment.Left);  //2
        //        lis.Columns.Add("precio Unit", 90, HorizontalAlignment.Right);  //3
        //        lis.Columns.Add("Importe", 90, HorizontalAlignment.Right);  //4
        //        lis.Columns.Add("Tipo Producto", 0, HorizontalAlignment.Right);  //5
        //        lis.Columns.Add("Und", 0, HorizontalAlignment.Right);  //6
        //        lis.Columns.Add("Utilidad Unit", 0, HorizontalAlignment.Right);  //7
        //        lis.Columns.Add("Total Utilidad", 0, HorizontalAlignment.Right);  //8
        //                                                                          //campos que se requiere para la FE:
        //        lis.Columns.Add("Afec. Igv", 90, HorizontalAlignment.Left);  //8

        //        lis.Columns.Add("PreUni sinIgv", 0, HorizontalAlignment.Left);  //3.0
        //        lis.Columns.Add("SubTotal SinIgv", 0, HorizontalAlignment.Left);  // 0.40
        //        lis.Columns.Add("Igv", 0, HorizontalAlignment.Left);  //3.40
        //        lis.Columns.Add("Tipo", 110, HorizontalAlignment.Left);
        //        lis.Columns.Add("cantidad_origen", 80, HorizontalAlignment.Left);
        //    }
        //}
        string idPedido;
        private void Buscar_Documento_paraGeneraN_C(string nroDoc)
        {
            RN_Documento obj = new RN_Documento();
            DataTable dato = new DataTable();

            string descripProd = "";
            //string nroSerie = "";
            string Descripcion = "";
            string xtipoProd;
            /*
            try
            {
                dato = obj.RN_Buscar_Documento_y_Detalle2(nroDoc.Trim());
                if (dato.Rows.Count > 0)
                {
                    var dt = dato.Rows[0];
                    Lbl_Nro_Doc.Text = Convert.ToString(dt["id_Doc"]);
                    Lbl_NroPedido.Text = Convert.ToString(dt["id_Ped"]);
                    idPedido = Lbl_NroPedido.Text;
                    Lbl_IdTipo.Text = dt["Id_Tipo"].ToString();
                    Lbl_TipoDocName.Text = Convert.ToString(dt["Documento"]);
                    if (Lbl_TipoDocName.Text.Trim() == "Nota Venta")
                    {
                        Frm_Filtro fil = new Frm_Filtro();
                        Frm_Advertencia adv = new Frm_Advertencia();

                        fil.Show();

                        adv.lbl_msm.Text = "La Nota de Venta ingresada no es valida para una Nota de Credito.";
                        adv.ShowDialog();

                        fil.Hide();
                        return;
                    }
                    if (Lbl_IdTipo.Text.Trim() == "3")
                    {
                        Lbl_TipoFac_Id.Text = "00"; //nota de venta
                    }
                    else if (Lbl_IdTipo.Text.Trim() == "1")
                    {
                        Lbl_TipoFac_Id.Text = "01";  //es una Factura:
                    }
                    else if (Lbl_IdTipo.Text.Trim() == "2")
                    {
                        Lbl_TipoFac_Id.Text = "03";  //esuna Boleta
                    }
                    Lbl_TipoDocName.Text = Convert.ToString(dt["Documento"]); //.Item("Documento");
                    Dtp_FechaDoc.Value = Convert.ToDateTime(dt["Fecha_Emi"]);
                    cbo_tipoPago.Text = Convert.ToString(dt["TipoPago"]);
                    Lbl_IdCliente.Text = Convert.ToString(dt["id_cliente"]);
                    txt_ClienteNom.Text = Convert.ToString(dt["Razon_Social_Nombres"]);
                    Lbl_direccion.Text = Convert.ToString(dt["Direccion"]);
                    Lbl_ruc.Text = Convert.ToString(dt["DNI"]);

                    if (Lbl_ruc.Text.Trim().Length == 8)
                    {
                        Lbl_IDTipoDoc_Cli.Text = "1";
                    }
                    else if (Lbl_ruc.Text.Trim().Length == 11)
                    {
                        Lbl_IDTipoDoc_Cli.Text = "6";
                    }

                    if (cbo_MotivoEmis.SelectedIndex != 2)
                    {
                        //detalle del documento:
                        double cant_origen;
                        double cant_actualizada;
                        double canTotal;
                        foreach (DataRow xitem in dato.Rows)
                        {
                            ListViewItem xlist;
                            xlist = lsv_Det.Items.Add(xitem["Id_Pro"].ToString().Trim());
                            descripProd = xitem["Descripcion_Larga"].ToString();
                            xlist.SubItems.Add(descripProd.Trim());
                            cant_origen = Convert.ToDouble(xitem["P_Cant_Original"]);
                            cant_actualizada = Convert.ToDouble(xitem["Cantidad"]);
                            canTotal = cant_actualizada - cant_origen;
                            xlist.SubItems.Add(canTotal.ToString());// xlist.SubItems.Add(xitem["P_Cant_Original"].ToString());
                            xlist.SubItems.Add(xitem["Precio_ConIgv"].ToString());
                            xlist.SubItems.Add(xitem["Importe_ConIgv"].ToString());
                            xlist.SubItems.Add("Descripcion_Larga".ToString());// xlist.SubItems.Add("Descripcion_Larga".ToString());
                            xlist.SubItems.Add(xitem["Und_Medida"].ToString());
                            xlist.SubItems.Add(xitem["Utilidad_Unit"].ToString());
                            xlist.SubItems.Add(xitem["TotalUtilidad"].ToString());

                            xlist.SubItems.Add(xitem["AfectoIgv"].ToString());
                            xlist.SubItems.Add(xitem["Precio_sinIgv"].ToString());
                            xlist.SubItems.Add(xitem["subtotal_sinIgv"].ToString());
                            xlist.SubItems.Add(xitem["Igv_subtotal"].ToString());
                            xlist.SubItems.Add("NIU");  //NIU -- ZZ


                            //actualizar las cantidades originales antes de editar
                        }
                        Calcular();
                    }

                    pnl_sinProd.Visible = false;
                    //'Activaciones:
                    Btn_Emitir_NotaCred.Enabled = true;
                    btn_cancelar.Enabled = true;
                    btn_reimprimir.Enabled = false;
                    Lbl_NroNotaCredito.Text = RN_TipoDoc.Sp_Listado_Tipo(14);
                    Lbl_TipoNotaCre.Text = cbo_MotivoEmis.Text;

                    if (cbo_MotivoEmis.SelectedIndex == 3) //Devolucion de Items
                    {
                        Btn_Quitar.Enabled = true;
                        Btn_Add_Moti.Enabled = false;
                    }
                    else if (cbo_MotivoEmis.SelectedIndex == 2) //Descuento
                    {
                        Btn_Quitar.Enabled = false;
                        Btn_Add_Moti.Enabled = true;
                    }
                    else
                    {
                        Btn_Quitar.Enabled = false;
                        Btn_Add_Moti.Enabled = false;
                    }
                }
                else
                {
                    Frm_Filtro fil = new Frm_Filtro();
                    Frm_Advertencia ver = new Frm_Advertencia();
                    fil.Show();
                    ver.lbl_msm.Text = "El Documento ya se encuentra sin productos para Devolver y/o realizar Descuento.";
                    ver.ShowDialog();
                    fil.Hide();
                    return;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error al leer: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            */

        }
        /*
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

            Lbl_SubTotal.Text = xsubtotal.ToString("###0.00");
            Lbl_Igv.Text = xigv.ToString("###0.00");
            Lbl_Total_ACobrar.Text = xtotal.ToString("###0.00");

            //=============== Totales del Pie de la FE ===================//
            lbl_subtotalGravado.Text = xsubtotal_sinIgv.ToString("###0.00");
            lbl_igvgravado.Text = xigv_total.ToString("###0.00");
            double totalGravado = xsubtotal_sinIgv + xigv_total;
            Lbl_totalGravado.Text = totalGravado.ToString("###0.00");


            Lbl_Son.Text = Numalet.ToString(Lbl_Total_ACobrar.Text);
            let.LetraCapital = chkCapital.Checked;
            if (!actualizado) ActualizarCong();




        }
        */
        Numalet let = new Numalet();
        Boolean actualizado = false;
        private void ActualizarCong()
        {
         /*   actualizado = true;
            chkCapital.Checked = let.LetraCapital;
            if (Lbl_Son.Text.Length > 0)
            {
                Lbl_Son.Text = let.ToCustomString(Lbl_Total_ACobrar.Text);
                actualizado = false;
            }
         */
        }
        private void btn_Nuevo_Notacre_Click(object sender, EventArgs e)
        {
            Frm_Filtro fil = new Frm_Filtro();
            Frm_Advertencia ver = new Frm_Advertencia();
            RN_Caja ca = new RN_Caja();
            RN_Notacredito nc = new RN_Notacredito();
            
            //if (ca.RN_Estado_Documento_enCaja(Txt_buscarFac.Text))
            //{
            //    fil.Show(); ver.lbl_msm.Text = "El Documento ingresado ya se encuentra anulado."; ver.ShowDialog(); fil.Hide(); cbo_MotivoEmis.Focus(); return;
            //}
            //else
            //{
            //    if (cbo_MotivoEmis.SelectedIndex == -1)
            //    {
            //        fil.Show(); ver.lbl_msm.Text = "Selecciona el Tipo de Nota de Credito a Emitir"; ver.ShowDialog(); fil.Hide(); cbo_MotivoEmis.Focus(); return;
            //    }
            //    if (Txt_buscarFac.Text.Trim().Length < 11)
            //    {
            //        ver.lbl_msm.Text = "Ingresa el Nro de Factura, Por Favor"; ver.ShowDialog(); Txt_buscarFac.Focus(); return;
            //    }

            //    if (cbo_MotivoEmis.SelectedIndex == 4)
            //    {
            //        Buscar_NotaCredito_Para_Reimprimir(Txt_buscarFac.Text);
            //    }
            //    else
            //    {
            //        if (nc.RN_Verificar_SiFactura_Tiene_NotaCredito(Txt_buscarFac.Text)==true)
            //        {
            //            fil.Show();
            //            ver.lbl_msm.Text = "El Documento ingresado ya cuenta con una Nota de  Credito, Aceptar para continuar.";
            //            ver.ShowDialog();
            //            fil.Hide();
            //        }
            //        Buscar_Documento_paraGeneraN_C(Txt_buscarFac.Text.Trim());
            //    }
            //}
            
        }
        private bool Validar_NotaCredito()
        {
            /*
            Frm_Advertencia ver = new Frm_Advertencia();
            Frm_Filtro fil = new Frm_Filtro();
            /*

            if (lsv_Det.Items.Count == 0)
            {
                fil.Show(); ver.lbl_msm.Text = "Te Falta Agregar Detalle a la Nota de Credito"; ver.ShowDialog(); fil.Hide(); return false;
            }
            if (cbo_MotivoEmis.SelectedIndex == -1)
            {
                fil.Show(); ver.lbl_msm.Text = "Por Favor Marca Uno de los Tantos Motivos de Emision"; ver.ShowDialog(); fil.Hide(); return false;
            }
            if (Convert.ToDouble(Lbl_Total_ACobrar.Text) == 0)
            {
                fil.Show(); ver.lbl_msm.Text = "El Importe de la Nota de Credito debe Ser mayor a Cero"; ver.ShowDialog(); fil.Hide(); return false;
            }

            if (Lbl_TipoDocName.Text.Trim() == "Boleta")
            {
                if (Lbl_ruc.Text.Trim().Length < 8)
                {
                    fil.Show(); ver.lbl_msm.Text = "El Nro de Ruc del Cliente, está incompleto"; ver.ShowDialog(); fil.Hide(); return false;
                }
                if (Lbl_direccion.Text.Trim().Length < 1)
                {
                    fil.Show(); ver.lbl_msm.Text = "Por Favor Revisa el Cliente, NO se cargó su Direccion"; ver.ShowDialog(); fil.Hide(); return false;
                }
            }
            else
            {
                if (Lbl_ruc.Text.Trim().Length < 11)
                {
                    fil.Show(); ver.lbl_msm.Text = "El Nro de Ruc del Cliente, está incompleto"; ver.ShowDialog(); fil.Hide(); return false;
                }
                if (Lbl_direccion.Text.Trim().Length < 4)
                {
                    fil.Show(); ver.lbl_msm.Text = "Por Favor Revisa el Cliente, NO se cargó su Direccion"; ver.ShowDialog(); fil.Hide(); return false;
                }
            }

            if (Lbl_IdCliente.Text.Trim() == "")
            {
                fil.Show(); ver.lbl_msm.Text = "Por Favor Revisa el Cliente, NO se cargó su ID Unico"; ver.ShowDialog(); fil.Hide(); return false;
            }
            if (txt_descripcionMotivo.Text.Trim().Length < 4)
            {
                fil.Show(); ver.lbl_msm.Text = "Agrega una Breve Descripcion del Motivo de Emision"; ver.ShowDialog(); fil.Hide(); return false;
            }
            if (Lbl_RucEmisor.Text.Trim().Length == 0)
            {
                fil.Show(); ver.lbl_msm.Text = "El Nro de Ruc de la Empresa Emisor no se ha Cargado"; ver.ShowDialog(); fil.Hide(); return false;
            }
            if (Lbl_EmpresaEmisor.Text.Trim().Length == 0)
            {
                fil.Show(); ver.lbl_msm.Text = "El Nombre de la Empresa Emisor no se ha Cargado"; ver.ShowDialog(); fil.Hide(); return false;
            }
            */
            return true;
            
        }
        string EstadoDinero = "";
        string estadoNotaCredito = "";
        string TipoServidor = "";
        int header;
        int det;
        private void Registrar_NotaCredito()
        {
            /*
            EN_notacredito Obj = new EN_notacredito();
            RN_Notacredito ObjCre = new RN_Notacredito();

            Lbl_NroNotaCredito.Text = RN_TipoDoc.Sp_Listado_Tipo(14);
            string inicioNC = Txt_buscarFac.Text.Substring(0, 1);
            string serie = Lbl_NroNotaCredito.Text.Substring(2, 2);
            string NotaCredito = Lbl_NroNotaCredito.Text.Substring(4);
            string NotaCredito_Modificado = inicioNC + "C" + serie + NotaCredito;
            v_NC_Enviado_Sunat = NotaCredito_Modificado;

            int rpt;
            try
            {

                Obj.idcre = Lbl_NroNotaCredito.Text;
                Obj.nrodoc = Lbl_Nro_Doc.Text;
                // Obj.Ruc = Lbl_ruc.Text
                Obj.TipoComprobnte = Lbl_TipoDocName.Text;
                Obj.OtrosDatos = txt_descripcionMotivo.Text.Trim();
                Obj.Fechaemi = dtp_fechaActual.Value;
                Obj.total = System.Convert.ToSingle(Lbl_Total_ACobrar.Text);
                Obj.Igv = Convert.ToDouble(Lbl_Igv.Text);
                Obj.SubTotal = Convert.ToDouble(Lbl_SubTotal.Text);
                Obj.idusu = Convert.ToInt32(Cls_UsuLogin.IdUsu); // ObjSesionUsuario.IdUsu;
                Obj.motivoEmisio = cbo_MotivoEmis.Text;
                Obj.son = Lbl_Son.Text;
                Obj.EstadoDinero = EstadoDinero;
                Obj.Id_Cliente = Lbl_IdCliente.Text;
                Obj.CdrSunat = "Pendiente";
                Obj.HasCpe = "-";
                Obj.NC_Enviado_Sunat = v_NC_Enviado_Sunat;

                rpt = ObjCre.RN_Agregar_NotaCredito(Obj);

                // 'Registro de DEtalle de Nota de Credito:
                if (rpt == 1)
                {

                    EN_DetNotacredito ObjD = new EN_DetNotacredito();
                    RN_Pedido ped = new RN_Pedido();

                    if (cbo_MotivoEmis.SelectedIndex == 3 || cbo_MotivoEmis.SelectedIndex == 0 || cbo_MotivoEmis.SelectedIndex == 1)
                    {
                        for (int i = 0; i <= lsv_Det.Items.Count - 1; i++)
                        {
                            ObjD.idcre = Lbl_NroNotaCredito.Text.Trim();
                            {
                                var withBlock = lsv_Det.Items[i];
                                ObjD.idpro = withBlock.SubItems[0].Text;
                                ObjD.Detalle_Prodcto = withBlock.SubItems[1].Text;
                                ObjD.Cantidadc = Convert.ToDouble(withBlock.SubItems[2].Text); //cantidad origen
                                ObjD.PrecioUnit = Convert.ToDouble(withBlock.SubItems[3].Text);
                                ObjD.ImporteCre = Convert.ToDouble(withBlock.SubItems[4].Text);
                                ObjD.TipoProdcto = withBlock.SubItems[13].Text;
                                ObjD.Cant_Origen = 0;

                            }
                            //agregar condicion de los productos ya entregados
                            det = ObjCre.RN_Agregar_Items_Detalle_notacredito(ObjD);
                            Registrar_Entrada_Kardex(ObjD.idpro.Trim(), ObjD.Cantidadc, ObjD.TipoProdcto);
                            ped.RN_ActualizarPedidoMontoDescontar(idPedido, ObjD.idpro, ObjD.Cantidadc);

                        }
                        idPedido = "";
                    }
                }
                header = rpt;
                det = rpt;

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            */
        }
        private void Registrar_Entrada_Kardex(string xxxidpro, double xxxcant, string xxxtipoprod)
        {
            RN_Kardex objk = new RN_Kardex();
            EN_Kardex obji = new EN_Kardex();
            RN_Producto objpro = new RN_Producto();
            DataTable Dta_Kard = new DataTable();
            DataTable Dta_Prod = new DataTable();
            RN_Pedido ped = new RN_Pedido();

            int Total_item = 0;
            double TotalIn = 0;
            double Total_Sldo = 0;
            string xId_karde = "";
            double Stock_Saldo = 0;

            try
            {
                if (xxxtipoprod.Trim() == "Producto" || xxxtipoprod.Trim() == "NIU")
                {
                    if (objk.RN_Sp_Ver_sihay_Kardex(xxxidpro.Trim()) == false)
                    {
                    }
                    else
                    {
                        Dta_Kard = objk.RN_BuscarKardexDetalleProducto(xxxidpro.Trim()); // 'Leemos el kardex del producto por su IDProd
                        if (Dta_Kard.Rows.Count > 0)
                        {
                            xId_karde = Dta_Kard.Rows[0]["Id_krdx"].ToString();
                            Total_item = Dta_Kard.Rows.Count;

                            // '=========== Ahora Leemos EL Stock del Producto ================
                            Dta_Prod = objpro.RN_Buscar_Producto(xxxidpro.Trim());
                            lbl_stock_Prod.Text = Dta_Prod.Rows[0]["Stock_Actual"].ToString();
                            Lbl_Pre_compra.Text = Dta_Prod.Rows[0]["Pre_CompraS"].ToString();
                            // '================Ahora registramos el detalle ===================
                            obji.Id_Krdx = xId_karde;
                            obji.Item = Total_item + 1;
                            //obji.Doc_Soport = Lbl_NroNotaCredito.Text;
                            obji.Det_Operacion = "Por Devolucion con Nota Credito";
                            // 'Èntrada                        
                            obji.Cantidad_In = xxxcant;
                            obji.Precio_Unt_In = Convert.ToDouble(Lbl_Pre_compra.Text); // xpreCompra;
                            obji.Costo_Total_In = xxxcant * Convert.ToDouble(Lbl_Pre_compra.Text);
                            //salida:
                            obji.Cantidad_Out = 0;
                            obji.Precio_Unt_Out = 0;
                            obji.Importe_Total_Out = 0;
                            //saldos:
                            obji.Cantidad_Saldo = Convert.ToDouble(lbl_stock_Prod.Text) + xxxcant;
                            obji.Promedio = Convert.ToDouble(Lbl_Pre_compra.Text);
                            obji.Costo_Total_Saldo = Convert.ToDouble(Lbl_Pre_compra.Text) * obji.Cantidad_Saldo;

                            objk.RN_Registrar_det_Kardex(obji);
                            //ahora acrtalizamos nuestro stock de la tabla productos:
                            objpro.RN_SumarStock_Producto(xxxidpro.Trim(), xxxcant);

                            ped.RN_ActualizarEstadoProducto(idPedido, "Entrada Devolucion", xxxidpro, xxxcant);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Registrar_SalidaCaja(string tipopago, string conceptocaja)
        {

            RN_Caja obj = new RN_Caja();
            EN_Caja cja = new EN_Caja();

            try
            {

                //cja.Fecha_Caja = dtp_fechaActual.Value;
                //cja.Tipo_Caja = "Salida";
                //cja.Concepto = conceptocaja;
                //cja.De_Para = txt_ClienteNom.Text;
                //cja.Nro_Doc = Lbl_Nro_Doc.Text; // txt_nroD.Text;
                //cja.ImporteCaja = Convert.ToDouble(Lbl_Total_ACobrar.Text);
                cja.Id_Usu = Cls_UsuLogin.IdUsu;
                cja.TotalUti = 0;
                cja.TipoPago = tipopago;
                cja.GeneradoPor = "Otros";

                obj.RN_Ingresar_Caja(cja);//************************************************************************

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }


        }
        double Canti_Ingre = 0;
        private void Btn_Emitir_NotaCred_Click(object sender, EventArgs e)
        {

            // SI SE ELIMINA EN LA NC UNOS PRODUCTOS DE UN COMPROBANTE EN LA SEGUIENTE YA NO DEBE APARECER EL PRODUCTO.
            RN_cliente objC = new RN_cliente();
            RN_Documento objdoc = new RN_Documento();
            RN_Caja objk = new RN_Caja();
            RN_Credito objcredi = new RN_Credito();
            RN_Notacredito objNC = new RN_Notacredito();
            int veces = 0;
            int Nrofila = 0;
            string tipoguardado = "";
            Frm_Print_NotaVentaTicket nota = new Frm_Print_NotaVentaTicket();

            Frm_Filtro fil = new Frm_Filtro();
            Frm_Advertencia ver = new Frm_Advertencia();
            Frm_Msm_Bueno ok = new Frm_Msm_Bueno();
            Frm_Terminar_Venta_SMS terminar = new Frm_Terminar_Venta_SMS();


            if (Validar_NotaCredito() == false)
                return;

            //try
            //{
            //    if (cbo_MotivoEmis.SelectedIndex == 3)
            //    {
            //        //es una Devolucion por Item:
            //        //if (Canti_Ingre == 0)
            //        //{
            //        //    fil.Show(); 
            //        //    ver.lbl_msm.Text = "Aún no has Editado el Producto a Devolver";
            //        //    ver.ShowDialog();
            //        //    fil.Hide();
            //        //    return;
            //        //}

            //        Frm_TerminarNotaCred ter = new Frm_TerminarNotaCred();

            //        fil.Show();
            //        ter.lbl_totalDoc.Text = Lbl_Total_ACobrar.Text;
            //        ter.ShowDialog();
            //        fil.Hide();

            //        tipoguardado = ter.lbl_op.Text;

            //        //Para que va servir la Nota de Credito que se va emitir
            //        if (tipoguardado.Trim() == "Nada")
            //        {
            //            EstadoDinero = "No Pago";
            //        }
            //        else if (tipoguardado.Trim() == "Salida")
            //        {
            //            EstadoDinero = "No Pago";
            //        }
            //        else if (tipoguardado.Trim() == "Vale")
            //        {
            //            EstadoDinero = "De Pago";
            //        }
            //    }
            //    else
            //    {
            //        EstadoDinero = "No Pago";//devolver pago
            //    }
            //    // 'guardamos la nota de credito
            //    Registrar_NotaCredito();
            //    if (header == 1 & det == 1)
            //    {
            //        // 'Actualizamos el Correlativo:
            //        RN_TipoDoc.RN_Actualizar_SiguienteNro_correlativo(14);

            //        if (cbo_MotivoEmis.SelectedIndex == 3)
            //        {
            //            //esto es una DEvolucion:
            //            if (tipoguardado.Trim() == "Salida")
            //            {
            //                Registrar_SalidaCaja("Efectivo", "Salida de Dinero por Devolucion de Producto");
            //                //volver a ingresar el producto
            //            }

            //        }
            //        else if (cbo_MotivoEmis.SelectedIndex == 2)
            //        {
            //            Registrar_SalidaCaja("Efectivo", "Descuento Global a una Factura");
            //        }
            //        else if (cbo_MotivoEmis.SelectedIndex == 0 | cbo_MotivoEmis.SelectedIndex == 1)
            //        {
            //            // que pasa si el documento f o b se pago en partes como se concidera el deposito o pago en efectivo. 
            //            // falta devolver el producto
            //            if (cbo_tipoPago.Text.Trim() == "Credito")
            //            {
            //                objcredi.RN_Eliminar_credito_Permanente(Lbl_IdCredi_fiado.Text.Trim());
            //                //devolver lo abonado
            //            }
            //            //if (tipoguardado.Trim() == "Salida")
            //            //{
            //            //    Registrar_SalidaCaja("Efectivo", "Salida de Dinero por Devolucion de Producto");
            //            //    //volver a ingresar el producto
            //            //}
            //            objk.RN_AnularMovCaja(Lbl_Nro_Doc.Text.Trim(), "Anulado");

            //        }

            //        if (Cbo_DestinoSunat.SelectedIndex == 0 || Cbo_DestinoSunat.SelectedIndex == 1)
            //        {
            //            // 'Enviamos el documento a la Sunat:
            //            Enviar_NotaCreditoElectronico();

            //            // 'Subimos el Archivo al Internet:
            //            if (TXTCOD_SUNAT.Text.Trim() == "0" || TXTCOD_SUNAT.Text.Trim() == "1")
            //            {
            //                RN_Temporal tem = new RN_Temporal();

            //                // 'Mandamos a Imprimir
            //                Registrar_archivos_Temporales();
            //                tem.RN_ActualizarEstadoSunat_NC_Temporal(Lbl_NroNotaCredito.Text, TXTHASHCPE.Text);
            //                objNC.RN_Actualizar_EstadoSunat_NC(Lbl_NroNotaCredito.Text.Trim(), "Aprobado", TXTHASHCPE.Text);


            //                fil.Show();
            //                ok.Lbl_msm1.Text = "La Nota de Credito Fue Guardado y Aprobado por la Sunat";
            //                ok.ShowDialog();
            //                fil.Hide();


            //                fil.Show();
            //                //nota.tipoImpre = "nc";
            //                //nota.RucEmisor = Lbl_RucEmisor.Text;
            //                //nota.tipoCompro = "07";  //nota de credito
            //                nota.lbl_nroDoc.Text = "Nota Credito : " + Lbl_NroNotaCredito.Text;
            //                nota.Tag = Lbl_NroNotaCredito.Text;
            //                nota.RutaPPF = rutaPDF_Export_Ventas + Lbl_RucEmisor.Text.Trim() + "-" + "07" + "-" + Lbl_NroNotaCredito.Text + ".pdf";
            //                rutaPDF_Export_Ventas = rutaPDF_Export_Ventas + Lbl_RucEmisor.Text.Trim() + "-" + "07" + "-" + Lbl_NroNotaCredito.Text + ".pdf";
            //                nota.ShowDialog();
            //                fil.Hide();

            //                fil.Show();
            //                terminar.lbl_Documento.Text = Lbl_NroNotaCredito.Text;
            //                terminar.lbl_rutaPDF.Text = rutaPDF_Export_Ventas;
            //                terminar.lbl_rutaXML.Text = obj.RutaCompleta_XML;
            //                terminar.ShowDialog();
            //                fil.Hide();

            //                Restablecer_ventana();
            //                pnl_sinProd.Visible = true;
            //                Txt_buscarFac.Text = "";

            //            }
            //            else
            //            {
            //                // 'Mandamos a Imprimir
            //                Registrar_archivos_Temporales();

            //                fil.Show();
            //                ver.lbl_msm.Text = "El Comprobante fue Enviado y Rechazado por la Sunat.  --" + TXT_MSJ_SUNAT.Text;
            //                ver.ShowDialog();
            //                fil.Hide();


            //                fil.Show();
            //                //nota.tipoImpre = "nc";
            //                //nota.RucEmisor = Lbl_RucEmisor.Text;
            //                //nota.tipoCompro = "07";  //nota de credito
            //                nota.lbl_nroDoc.Text = "Nota Credito : " + Lbl_NroNotaCredito.Text;
            //                nota.Tag = Lbl_NroNotaCredito.Text;
            //                nota.RutaPPF = rutaPDF_Export_Ventas + Lbl_RucEmisor.Text.Trim() + "-" + "07" + "-" + Lbl_Nro_Doc.Text + ".pdf";
            //                rutaPDF_Export_Ventas = rutaPDF_Export_Ventas + Lbl_RucEmisor.Text.Trim() + "-" + "07" + "-" + Lbl_Nro_Doc.Text + ".pdf";
            //                nota.ShowDialog();
            //                fil.Hide();

            //                fil.Show();
            //                terminar.lbl_Documento.Text = Lbl_Nro_Doc.Text;
            //                terminar.lbl_rutaPDF.Text = rutaPDF_Export_Ventas;
            //                terminar.lbl_rutaXML.Text = obj.RutaCompleta_XML;
            //                terminar.ShowDialog();
            //                fil.Hide();

            //                Restablecer_ventana();
            //                pnl_sinProd.Visible = true;
            //                Txt_buscarFac.Text = "";
            //            }
            //        }
            //        else
            //        {
            //            // 'sino quiere enviar Aun a la Sunat, Entonces.. Solo se debe Imprimir
            //            Registrar_archivos_Temporales();


            //            fil.Show();
            //            //nota.tipoImpre = "nc";
            //            //nota.RucEmisor = Lbl_RucEmisor.Text;
            //            //nota.tipoCompro = "07";  //nota de credito
            //            nota.lbl_nroDoc.Text = "Nota Credito : " + Lbl_NroNotaCredito.Text;
            //            nota.Tag = Lbl_NroNotaCredito.Text;
            //            nota.ShowDialog();
            //            fil.Hide();

            //            Restablecer_ventana();
            //            pnl_sinProd.Visible = true;
            //            Txt_buscarFac.Text = "";

            //        }

            //        header = 0;
            //        det = 0;
            //        v_NC_Enviado_Sunat = "";
            //    }  // 'Hasta el Documento es Correcto
            //}


            //catch (Exception ex)
            //{
            //    MessageBox.Show("Hay algunos problemas: " + ex.Message, "Aviso de Seguridad", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //}
            //lsv_Det.Items.Clear();
        }
        string rutaPDF_Export_Ventas = "C:\\Sln_MicrosellLite\\CPE_2\\BETA\\";
        #region kardex copia
        //void RegistrarMovimientoKardex(string idprod, double cant, double xprecioCompra)
        //{
        //    RN_Kardex n_kar = new RN_Kardex();
        //    EN_Kardex e_kar = new EN_Kardex();
        //    RN_Producto n_prod = new RN_Producto();
        //    DataTable dt = new DataTable();
        //    DataTable dt2 = new DataTable();
        //    string xidkardex;
        //    int xitem;
        //    double stockProd;
        //    double PrecioCompraProd;
        //    try
        //    {
        //        if (n_kar.RN_Sp_Ver_sihay_Kardex(idprod))
        //        {
        //            dt = n_kar.RN_BuscarKardexDetalleProducto(idprod.Trim());
        //            xidkardex = dt.Rows[0]["Id_krdx"].ToString();
        //            xitem = dt.Rows.Count;
        //            dt2 = n_prod.RN_Buscar_Producto(idprod.Trim());
        //            stockProd = Convert.ToDouble(dt2.Rows[0]["Stock_Actual"]);
        //            PrecioCompraProd = Convert.ToDouble(dt2.Rows[0]["Pre_CompraS"]);
        //            //Registrar Detalle Kardex
        //            e_kar.Id_Krdx = xidkardex;
        //            e_kar.Item = xitem + 1;
        //            e_kar.Doc_Soport = Lbl_NroNotaCredito.Text;
        //            e_kar.Det_Operacion = "Devolucion de Mercaderia con NC";
        //            //Entrada
        //            e_kar.Cantidad_In = cant;
        //            e_kar.Precio_Unt_In = xprecioCompra;
        //            e_kar.Costo_Total_In = cant * PrecioCompraProd;
        //            //Salida
        //            e_kar.Cantidad_Out = 0;
        //            e_kar.Precio_Unt_Out = 0;
        //            e_kar.Importe_Total_Out = 0;
        //            //saldos
        //            e_kar.Cantidad_Saldo = stockProd + cant;
        //            e_kar.Promedio = xprecioCompra;
        //            e_kar.Costo_Total_Saldo = xprecioCompra * (stockProd + cant);
        //            n_kar.RN_Registrar_det_Kardex(e_kar);
        //            //Actualizar Stock Productos
        //            n_prod.RN_SumarStock_Producto(idprod, cant);
        //            // MessageBox.Show("El Producto " + xnomproducto + " ya fue agregado al carrito", "Advertencia de seguridad", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //        }
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}
        #endregion
        private void Restablecer_ventana()
        {
            //lbl_descuento.Text = "0";
            //Lbl_direccion.Text = "";
            //lbl_dscntoSunat.Text = "0";
            //Lbl_IdCliente.Text = "";
            //Lbl_EstadoBaja.Text = "";
            //lbl_estado.Text = "";
            //Lbl_IDTipoDoc_Cli.Text = "";
            //Lbl_IdTipo.Text = "";
            //Lbl_IDTipoDoc_Cli.Text = "";
            //Lbl_Nro_Doc.Text = "";
            //Lbl_NroPedido.Text = "";
            //Lbl_NroNotaCredito.Text = "";
            //txt_ClienteNom.Text = "";
            //txt_descripcionMotivo.Text = "-";
            //TXT_MSJ_SUNAT.Text = "";
            //TXTCOD_SUNAT.Text = "";
            //cbo_MotivoEmis.SelectedIndex = -1;
            //Cbo_DestinoSunat.SelectedIndex = -1;


        }
        private void Registrar_archivos_Temporales()
        {
            RN_Temporal obj = new RN_Temporal();
            EN_Temporal tem = new EN_Temporal();

            //string dias = dtp_fechaActual.Value.Day.ToString();
            //string mes = dtp_fechaActual.Value.Month.ToString();
            //string año = dtp_fechaActual.Value.Year.ToString();

            //int totalEspacio = 0;
            //int totalFila = lsv_Det.Items.Count;

            //string tipoCompronte = "";

            //string RutaQr = "C:\\Sln_MicrosellLite\\CPE_2\\QR_TEMP\\" + Lbl_NroNotaCredito.Text + ".BMP";
            //GenerarQR("Nota Credito", Lbl_Total_ACobrar.Text, txt_ClienteNom.Text, Lbl_NroNotaCredito.Text, RutaQr);

            //pic_qr.Load(RutaQr);

            //try
            //{
            //    tem.CodTem = Lbl_NroNotaCredito.Text;
            //    tem.FechaEmi = dtp_fechaActual.Value.ToString();
            //    tem.Cliente = txt_ClienteNom.Text;
            //    tem.Ruc = Lbl_ruc.Text;
            //    tem.Direccion = Lbl_direccion.Text;
            //    tem.SubTtal = Lbl_SubTotal.Text;
            //    tem.IgvT = Lbl_Igv.Text;
            //    tem.TotalT = Lbl_Total_ACobrar.Text;
            //    tem.SonT = Lbl_Son.Text;
            //    tem.Vendedor = Cls_UsuLogin.xNombres;
            //    tem.CodigoQR = Convertir_Imagen_Bytes(pic_qr.Image);
            //    tem.TipoComprobante = "Nota Credito Electrónica";

            //    tem.Hash_cpe = "Falta Enviar a Sunat"; //TXTHASHCPE.Text; 
            //    tem.MotivoEmis = cbo_MotivoEmis.Text;  //esto es opcional.. en algun momento cuando haga guia de remision
            //    tem.TipoPago = Lbl_Nro_Doc.Text;

            //    int rpt = obj.RN_Ingresar_Temporal_Header(tem);


            //    if (rpt == 1)
            //    {
            //        string codTem;
            //        string CodProd;
            //        string Cantidad;
            //        string Producto;
            //        string PreUnt;
            //        string Importe;
            //        string UnidMedida;
            //        //guardar el detalle:  for (int i =0; i < lsv_Det.Items.Count; i++)
            //        for (int i = 0; i < lsv_Det.Items.Count; i++)
            //        {

            //            var lis = lsv_Det.Items[i];

            //            codTem = Lbl_NroNotaCredito.Text;
            //            CodProd = lis.SubItems[0].Text;
            //            Cantidad = lis.SubItems[2].Text;
            //            Producto = lis.SubItems[1].Text;
            //            PreUnt = lis.SubItems[3].Text;
            //            Importe = lis.SubItems[4].Text;
            //            UnidMedida = lis.SubItems[13].Text;
            //            obj.BD_Ingresar_Temporal_Det(codTem, CodProd, Cantidad, Producto, PreUnt, Importe, UnidMedida);

            //        }
            //        /*
            //        codTem = Lbl_NroNotaCredito.Text;
            //        CodProd = "";
            //        Cantidad = "";
            //        Producto = "";
            //        PreUnt = "";
            //        Importe = "";
            //        obj.BD_Ingresar_Temporal_Det(codTem, CodProd, Cantidad, Producto, PreUnt, Importe);*/
            //    }

            //}

            //catch (Exception ex)
            //{
            //    MessageBox.Show("Error: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            //}

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
        BE.CPE objCPE = new BE.CPE();
        BE.CPE_DETALLE objCPE_DETALLE = new BE.CPE_DETALLE();
        CPEConfig obj = new CPEConfig();
        DataTable vObjTempComprobante = new DataTable();
        DataRow vObjTempFilaComprobante;
        string v_NC_Enviado_Sunat;
        private void Enviar_NotaCreditoElectronico()
        {
            //Frm_Filtro fil = new Frm_Filtro();
            //Frm_Advertencia ver = new Frm_Advertencia();
            //Frm_Msm_Bueno ok = new Frm_Msm_Bueno();

            //try
            //{
            //    objCPE.TIPO_OPERACION = "0101";
            //    objCPE.TOTAL_GRAVADAS = Convert.ToDecimal(Lbl_SubTotal.Text);  // ' TXTSUBTOTAL.Text  'SUB TOTAL
            //    objCPE.SUB_TOTAL = Convert.ToDecimal(Lbl_SubTotal.Text); // ' TXTSUBTOTAL.Text 'SUB TOTAL
            //    objCPE.POR_IGV = 18; // NUEVO UBL 2.1
            //    objCPE.TOTAL_IGV = Convert.ToDecimal(Lbl_Igv.Text); // ' TXTIGV.Text  'TOTAL IGV
            //    objCPE.TOTAL_ISC = 0;
            //    objCPE.TOTAL_OTR_IMP = 0;
            //    objCPE.TOTAL = Convert.ToDecimal(Lbl_Total_ACobrar.Text); // ' TXTTOTAL.Text  'TOTAL COMPROBANTE
            //    objCPE.TOTAL_EXPORTACION = 0; // NUEVO UBL 2.1
            //    objCPE.TOTAL_LETRAS = Lbl_Son.Text;  // '  TXTTOTAL_LETRAS.Text
            //    objCPE.NRO_GUIA_REMISION = "";
            //    objCPE.FECHA_GUIA_REMISION = ""; // NUEVO UBL 2.1
            //    objCPE.COD_GUIA_REMISION = "";
            //    objCPE.NRO_OTR_COMPROBANTE = "";
            //    objCPE.COD_OTR_COMPROBANTE = "";
            //    objCPE.NRO_COMPROBANTE = v_NC_Enviado_Sunat;  // '  TXTSERIE.Text & "-" & TXTNUMERO.Text

            //    objCPE.FECHA_DOCUMENTO = dtp_fechaActual.Value.ToString("yyyy-MM-dd"); // ' DTPFECHA.Value.ToString("yyyy-MM-dd") '"2018-01-18"
            //    objCPE.FECHA_VTO = dtp_fechaActual.Value.ToString("yyyy-MM-dd"); // ' DTPFECHA.Value.ToString("yyyy-MM-dd") 'NUEVO UBL 2.1
            //    objCPE.COD_TIPO_DOCUMENTO = "07"; // ' CBOTIPOCOMPROBANTE.SelectedValue  '01=FACTURA, 03=BOLETA, 07=NOTA CREDITO, 08=NOTA DEBITO
            //    objCPE.COD_MONEDA = "PEN"; // ' CBOMONEDA.SelectedValue
            //                               // ==============PARA PLAA DE VEHICULO=============
            //    objCPE.PLACA_VEHICULO = "-";
            //    // ========================DATOS NOTA CREDITO/NOTA DEBITO==========================
            //    objCPE.TIPO_COMPROBANTE_MODIFICA = Lbl_TipoFac_Id.Text;  // ' CBOTIPODOCMODIFICA.SelectedValue
            //    objCPE.NRO_DOCUMENTO_MODIFICA = Lbl_Nro_Doc.Text;  // '  TXTNRODOCMODIFICA.Text
            //    objCPE.COD_TIPO_MOTIVO = cbo_MotivoEmis.SelectedValue.ToString(); // ' CBOMOTIVO_MODIFICA.SelectedValue
            //    objCPE.DESCRIPCION_MOTIVO = cbo_MotivoEmis.Text; // ' CBOMOTIVO_MODIFICA.Text
            //                                                     // ========================DATOS DEL CIENTE==========================
            //    objCPE.NRO_DOCUMENTO_CLIENTE = Lbl_ruc.Text.Trim(); // ' TXTNUMERODOCUMENTO.Text
            //    objCPE.RAZON_SOCIAL_CLIENTE = txt_ClienteNom.Text.Trim();
            //    objCPE.TIPO_DOCUMENTO_CLIENTE = Lbl_IDTipoDoc_Cli.Text; // '    '1=DNI,6=RUC
            //    objCPE.DIRECCION_CLIENTE = Lbl_direccion.Text; // ' TXTDIRECCION.Text
            //    objCPE.CIUDAD_CLIENTE = "LIMA";
            //    objCPE.COD_PAIS_CLIENTE = "PE";
            //    objCPE.COD_UBIGEO_CLIENTE = ""; // //NUEVO UBL2.1
            //    objCPE.DEPARTAMENTO_CLIENTE = ""; // //NUEVO UBL2.1
            //    objCPE.PROVINCIA_CLIENTE = ""; // //NUEVO UBL2.1
            //    objCPE.DISTRITO_CLIENTE = ""; // //NUEVO UBL2.1
            //    // =============================DATOS EMPRESA===========================
            //    objCPE.NRO_DOCUMENTO_EMPRESA = Lbl_RucEmisor.Text.Trim(); // ' "10447915125"
            //    objCPE.TIPO_DOCUMENTO_EMPRESA = "6"; // 1=DNI,6=RUC
            //    objCPE.NOMBRE_COMERCIAL_EMPRESA = Lbl_EmpresaEmisor.Text.Trim(); // ' "JOSE LUIS ZAMBRANO YACHA"
            //    objCPE.CODIGO_UBIGEO_EMPRESA = "150101"; // TABLA UBIGEO
            //    objCPE.DIRECCION_EMPRESA = Lbl_DireccionEmpresa.Text.Trim(); // ' "DIRECCION DE PRUEBA"
            //    objCPE.DEPARTAMENTO_EMPRESA = "LIMA";
            //    objCPE.PROVINCIA_EMPRESA = "LIMA";
            //    objCPE.DISTRITO_EMPRESA = "LIMA";
            //    objCPE.CODIGO_PAIS_EMPRESA = "PE";
            //    objCPE.RAZON_SOCIAL_EMPRESA = Lbl_EmpresaEmisor.Text.Trim(); // ' "JOSE LUIS ZAMBRANO YACHA"
            //    objCPE.CONTACTO_EMPRESA = ""; // NUEVO UBL 2.1
            //    objCPE.USUARIO_SOL_EMPRESA = Lbl_UsuarioSol.Text.Trim(); // '  "MODDATOS"
            //    objCPE.PASS_SOL_EMPRESA = Lbl_ClaveSol.Text.Trim(); // "moddatos"
            //    objCPE.CONTRA_FIRMA = Lbl_CertificadoClave.Text.Trim(); // ' "YLnfXVGjhNmcixBi"  ''YLnfXVGjhNmcixBi  ''123456
            //    var xtip = Cbo_DestinoSunat.SelectedValue;
            //    objCPE.TIPO_PROCESO = System.Convert.ToInt32(xtip); // 'Cbo_DestinoSunat.SelectedValue  '1=PRODUCCION, 2=HOMOLOGACION, 3=BETA
            //                                                        // ===================VARIABLE PARA LAS LISTAS==================
            //    List<businessEntities.CPE_DETALLE> OBJCPE_DETALLE_LIST = new List<businessEntities.CPE_DETALLE>();

            //    for (int i = 0; i <= lsv_Det.Items.Count - 1; i++)
            //    {

            //        objCPE_DETALLE = new businessEntities.CPE_DETALLE();
            //        objCPE_DETALLE.ITEM = i + 1;
            //        objCPE_DETALLE.UNIDAD_MEDIDA = lsv_Det.Items[i].SubItems[13].Text; //'[ª0000ª] ''.SubItems(2).Text '' vObjTempComprobante.Rows(Z)([ª0001ª]).ToString 'UNIDAD MEDIDA SEGUN CATALOGO 8
            //        objCPE_DETALLE.CANTIDAD = Convert.ToDecimal(lsv_Det.Items[i].SubItems[2].Text); //'
            //        objCPE_DETALLE.PRECIO = Convert.ToDecimal(lsv_Det.Items[i].SubItems[10].Text); //'   Sin IGV
            //        objCPE_DETALLE.PRECIO_CONIGV = Convert.ToDecimal(lsv_Det.Items[i].SubItems[3].Text); //'precio con IGV .. solo para la Impresion del PDF
            //        objCPE_DETALLE.IMPORTE = Convert.ToDecimal(lsv_Det.Items[i].SubItems[11].Text); //'  sub Total sin IGV
            //        objCPE_DETALLE.IMPORTE_CONIGV = Convert.ToDecimal(lsv_Det.Items[i].SubItems[4].Text); //'importe con IGV solo para la Impresion del PDF
            //        objCPE_DETALLE.PRECIO_TIPO_CODIGO = "01"; //'01=Precio que Incluye el IGV ---
            //        objCPE_DETALLE.IGV = Convert.ToDecimal(lsv_Det.Items[i].SubItems[12].Text); //' Igv sacado del SubTotal sin IGV
            //        objCPE_DETALLE.ISC = 0; //'
            //        objCPE_DETALLE.COD_TIPO_OPERACION = "10"; //'10= gravado -- 20=exonerado
            //        objCPE_DETALLE.CODIGO = lsv_Det.Items[i].SubItems[0].Text; //' vObjTempComprobante.Rows(Z)([ª0000ª]).ToString
            //        objCPE_DETALLE.DESCRIPCION = lsv_Det.Items[i].SubItems[1].Text; //' vObjTempComprobante.Rows(Z)([ª0000ª]).ToString
            //        objCPE_DETALLE.SUB_TOTAL = Convert.ToDecimal(lsv_Det.Items[i].SubItems[11].Text); //subtotal sin IGV
            //        objCPE_DETALLE.PRECIO_SIN_IMPUESTO = Convert.ToDecimal(lsv_Det.Items[i].SubItems[10].Text); //' [ª0000ª] ''CDec(vObjTempComprobante.Rows(Z)([ª0001ª]))
            //        OBJCPE_DETALLE_LIST.Add(objCPE_DETALLE);

            //        //==============================================

            //    }

            //    objCPE.detalle = OBJCPE_DETALLE_LIST;
            //    // ======================================RESPUESTA====================================
            //    Dictionary<string, string> dictionaryEnv = new Dictionary<string, string>();
            //    dictionaryEnv = obj.Enviar_NotaCredito_aSunat(objCPE);//********************************************************


            //    TXTCOD_SUNAT.Text = dictionaryEnv["cod_sunat"];
            //    //xcodsunat = dictionaryEnv["cod_sunat"];
            //    //xMsg = dictionaryEnv.Item["msj_sunat"];
            //    TXT_MSJ_SUNAT.Text = dictionaryEnv["msj_sunat"];
            //    TXTHASHCPE.Text = dictionaryEnv["hash_cpe"];
            //    TXTHASHCDR.Text = dictionaryEnv["hash_cdr"];
            //}

            //catch (Exception ex)
            //{
            //    fil.Show();

            //    ver.lbl_msm.Text = "Revise la Falla: " + ex.Message;
            //    ver.ShowDialog();
            //    fil.Hide();
            //}
        }
        private void Btn_Quitar_Click(object sender, EventArgs e)
        {
            Frm_Filtro fil = new Frm_Filtro();
            Frm_SINO sino = new Frm_SINO();
            Frm_Solo_Cant solo = new Frm_Solo_Cant(); //********************************************************

            double canti_Vendida;
            double Nueva_Cantidad;

            //if (lsv_Det.SelectedIndices.Count == 0)
            //{
            //    MessageBox.Show("Seleccionar el Producto a Quitar", "Quitar Precio", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //}
            //else
            //{

            //    canti_Vendida = Convert.ToDouble(lsv_Det.SelectedItems[0].SubItems[2].Text);

            //    if (canti_Vendida > 1)
            //    {
            //        fil.Show();
            //        solo.txt_Cantidad.Text = canti_Vendida.ToString("###0.00");
            //        solo.ShowDialog();
            //        fil.Hide();

            //        if (solo.Tag.ToString() == "A")
            //        {
            //            //2: 
            //            Nueva_Cantidad = Convert.ToDouble(solo.txt_Cantidad.Text);
            //            if (Nueva_Cantidad == canti_Vendida)
            //            {
            //                //quiere quitar Todo:
            //                int i;
            //                var lis = lsv_Det.SelectedItems[0];
            //                for (i = lsv_Det.SelectedItems.Count - 1; i >= 0; i--)
            //                {
            //                    lsv_Det.Items.Remove(lsv_Det.SelectedItems[i]);
            //                }
            //            }
            //            else
            //            {
            //                if (Nueva_Cantidad > canti_Vendida)
            //                {
            //                    MessageBox.Show("La Cantidad a Devolver NO puede SEr MAyor a la Cantidad Vendida", "Validacion de Cantidad", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //                    return;
            //                }
            //                else
            //                {
            //                    lsv_Det.SelectedItems[0].SubItems[2].Text = Nueva_Cantidad.ToString("###0.00");
            //                }
            //            }
            //        }
            //    }
            //    else
            //    {
            //        int i;
            //        var lis = lsv_Det.SelectedItems[0];
            //        for (i = lsv_Det.SelectedItems.Count - 1; i >= 0; i--)
            //        {
            //            lsv_Det.Items.Remove(lsv_Det.SelectedItems[i]);
            //        }
            //    }

            //    Canti_Ingre = 1;

            //    Calcular();

            //    if (cbo_MotivoEmis.SelectedIndex == 2)
            //    {
            //        Btn_Add_Moti.Enabled = true;
            //    }

            //}


        }
        private void btn_Comprobar_Click(object sender, EventArgs e)
        {
            //Lbl_NroNotaCredito.Text = RN_TipoDoc.Sp_Listado_Tipo(14);

            //Frm_Filtro fil = new Frm_Filtro();
            //Frm_Advertencia ver = new Frm_Advertencia();
            //Frm_Msm_Bueno ok = new Frm_Msm_Bueno();


            //try
            //{
            //    objCPE.TIPO_OPERACION = "0101";
            //    objCPE.TOTAL_GRAVADAS = Convert.ToDecimal(Lbl_SubTotal.Text);  // ' TXTSUBTOTAL.Text  'SUB TOTAL
            //    objCPE.SUB_TOTAL = Convert.ToDecimal(Lbl_SubTotal.Text); // ' TXTSUBTOTAL.Text 'SUB TOTAL
            //    objCPE.POR_IGV = 18; // NUEVO UBL 2.1
            //    objCPE.TOTAL_IGV = Convert.ToDecimal(Lbl_Igv.Text); // ' TXTIGV.Text  'TOTAL IGV
            //    objCPE.TOTAL_ISC = 0;
            //    objCPE.TOTAL_OTR_IMP = 0;
            //    objCPE.TOTAL = Convert.ToDecimal(Lbl_Total_ACobrar.Text); // ' TXTTOTAL.Text  'TOTAL COMPROBANTE
            //    objCPE.TOTAL_EXPORTACION = 0; // NUEVO UBL 2.1
            //    objCPE.TOTAL_LETRAS = Lbl_Son.Text;  // '  TXTTOTAL_LETRAS.Text
            //    objCPE.NRO_GUIA_REMISION = "";
            //    objCPE.FECHA_GUIA_REMISION = ""; // NUEVO UBL 2.1
            //    objCPE.COD_GUIA_REMISION = "";
            //    objCPE.NRO_OTR_COMPROBANTE = "";
            //    objCPE.COD_OTR_COMPROBANTE = "";
            //    objCPE.NRO_COMPROBANTE = Lbl_NroNotaCredito.Text;  // '  TXTSERIE.Text & "-" & TXTNUMERO.Text
            //    objCPE.FECHA_DOCUMENTO = dtp_fechaActual.Value.ToString("yyyy-MM-dd"); // ' DTPFECHA.Value.ToString("yyyy-MM-dd") '"2018-01-18"
            //    objCPE.FECHA_VTO = dtp_fechaActual.Value.ToString("yyyy-MM-dd"); // ' DTPFECHA.Value.ToString("yyyy-MM-dd") 'NUEVO UBL 2.1
            //    objCPE.COD_TIPO_DOCUMENTO = "07"; // ' CBOTIPOCOMPROBANTE.SelectedValue  '01=FACTURA, 03=BOLETA, 07=NOTA CREDITO, 08=NOTA DEBITO
            //    objCPE.COD_MONEDA = "PEN"; // ' CBOMONEDA.SelectedValue
            //                               // ==============PARA PLAA DE VEHICULO=============
            //    objCPE.PLACA_VEHICULO = "-";
            //    // ========================DATOS NOTA CREDITO/NOTA DEBITO==========================
            //    objCPE.TIPO_COMPROBANTE_MODIFICA = Lbl_TipoFac_Id.Text;  // ' CBOTIPODOCMODIFICA.SelectedValue
            //    objCPE.NRO_DOCUMENTO_MODIFICA = Lbl_Nro_Doc.Text;  // '  TXTNRODOCMODIFICA.Text
            //    objCPE.COD_TIPO_MOTIVO = cbo_MotivoEmis.SelectedValue.ToString(); // ' CBOMOTIVO_MODIFICA.SelectedValue
            //    objCPE.DESCRIPCION_MOTIVO = cbo_MotivoEmis.Text; // ' CBOMOTIVO_MODIFICA.Text
            //                                                     // ========================DATOS DEL CIENTE==========================
            //    objCPE.NRO_DOCUMENTO_CLIENTE = Lbl_ruc.Text.Trim(); // ' TXTNUMERODOCUMENTO.Text
            //    objCPE.RAZON_SOCIAL_CLIENTE = txt_ClienteNom.Text.Trim();
            //    objCPE.TIPO_DOCUMENTO_CLIENTE = Lbl_IDTipoDoc_Cli.Text; // '    '1=DNI,6=RUC
            //    objCPE.DIRECCION_CLIENTE = Lbl_direccion.Text; // ' TXTDIRECCION.Text
            //    objCPE.CIUDAD_CLIENTE = "LIMA";
            //    objCPE.COD_PAIS_CLIENTE = "PE";
            //    objCPE.COD_UBIGEO_CLIENTE = ""; // //NUEVO UBL2.1
            //    objCPE.DEPARTAMENTO_CLIENTE = ""; // //NUEVO UBL2.1
            //    objCPE.PROVINCIA_CLIENTE = ""; // //NUEVO UBL2.1
            //    objCPE.DISTRITO_CLIENTE = ""; // //NUEVO UBL2.1
            //                                  // =============================DATOS EMPRESA===========================
            //    objCPE.NRO_DOCUMENTO_EMPRESA = Lbl_RucEmisor.Text.Trim(); // ' "10447915125"
            //    objCPE.TIPO_DOCUMENTO_EMPRESA = "6"; // 1=DNI,6=RUC
            //    objCPE.NOMBRE_COMERCIAL_EMPRESA = Lbl_EmpresaEmisor.Text.Trim(); // ' "JOSE LUIS ZAMBRANO YACHA"
            //    objCPE.CODIGO_UBIGEO_EMPRESA = "150101"; // TABLA UBIGEO
            //    objCPE.DIRECCION_EMPRESA = Lbl_DireccionEmpresa.Text.Trim(); // ' "DIRECCION DE PRUEBA"
            //    objCPE.DEPARTAMENTO_EMPRESA = "LIMA";
            //    objCPE.PROVINCIA_EMPRESA = "LIMA";
            //    objCPE.DISTRITO_EMPRESA = "LIMA";
            //    objCPE.CODIGO_PAIS_EMPRESA = "PE";
            //    objCPE.RAZON_SOCIAL_EMPRESA = Lbl_EmpresaEmisor.Text.Trim(); // ' "JOSE LUIS ZAMBRANO YACHA"
            //    objCPE.CONTACTO_EMPRESA = ""; // NUEVO UBL 2.1
            //    objCPE.USUARIO_SOL_EMPRESA = Lbl_UsuarioSol.Text.Trim(); // '  "MODDATOS"
            //    objCPE.PASS_SOL_EMPRESA = Lbl_ClaveSol.Text.Trim(); // "moddatos"
            //    objCPE.CONTRA_FIRMA = Lbl_CertificadoClave.Text.Trim(); // ' "YLnfXVGjhNmcixBi"  ''YLnfXVGjhNmcixBi  ''123456
            //    var xtip = Cbo_DestinoSunat.SelectedValue;
            //    objCPE.TIPO_PROCESO = 3; // System.Convert.ToInt32(xtip); // 'Cbo_DestinoSunat.SelectedValue  '1=PRODUCCION, 2=HOMOLOGACION, 3=BETA
            //                             // ===================VARIABLE PARA LAS LISTAS==================
            //    List<businessEntities.CPE_DETALLE> OBJCPE_DETALLE_LIST = new List<businessEntities.CPE_DETALLE>();

            //    for (int i = 0; i <= lsv_Det.Items.Count - 1; i++)
            //    {

            //        objCPE_DETALLE = new businessEntities.CPE_DETALLE();
            //        objCPE_DETALLE.ITEM = i + 1;
            //        objCPE_DETALLE.UNIDAD_MEDIDA = lsv_Det.Items[i].SubItems[13].Text; //'[ª0000ª] ''.SubItems(2).Text '' vObjTempComprobante.Rows(Z)([ª0001ª]).ToString 'UNIDAD MEDIDA SEGUN CATALOGO 8
            //        objCPE_DETALLE.CANTIDAD = Convert.ToDecimal(lsv_Det.Items[i].SubItems[2].Text); //'
            //        objCPE_DETALLE.PRECIO = Convert.ToDecimal(lsv_Det.Items[i].SubItems[10].Text); //'   Sin IGV
            //        objCPE_DETALLE.PRECIO_CONIGV = Convert.ToDecimal(lsv_Det.Items[i].SubItems[3].Text); //'precio con IGV .. solo para la Impresion del PDF
            //        objCPE_DETALLE.IMPORTE = Convert.ToDecimal(lsv_Det.Items[i].SubItems[11].Text); //'  sub Total sin IGV
            //        objCPE_DETALLE.IMPORTE_CONIGV = Convert.ToDecimal(lsv_Det.Items[i].SubItems[4].Text); //'importe con IGV solo para la Impresion del PDF
            //        objCPE_DETALLE.PRECIO_TIPO_CODIGO = "01"; //'01=Precio que Incluye el IGV ---
            //        objCPE_DETALLE.IGV = Convert.ToDecimal(lsv_Det.Items[i].SubItems[12].Text); //' Igv sacado del SubTotal sin IGV
            //        objCPE_DETALLE.ISC = 0; //'
            //        objCPE_DETALLE.COD_TIPO_OPERACION = "10"; //'10= gravado -- 20=exonerado
            //        objCPE_DETALLE.CODIGO = lsv_Det.Items[i].SubItems[0].Text; //' vObjTempComprobante.Rows(Z)([ª0000ª]).ToString
            //        objCPE_DETALLE.DESCRIPCION = lsv_Det.Items[i].SubItems[1].Text; //' vObjTempComprobante.Rows(Z)([ª0000ª]).ToString
            //        objCPE_DETALLE.SUB_TOTAL = Convert.ToDecimal(lsv_Det.Items[i].SubItems[11].Text); //subtotal sin IGV
            //        objCPE_DETALLE.PRECIO_SIN_IMPUESTO = Convert.ToDecimal(lsv_Det.Items[i].SubItems[10].Text); //' [ª0000ª] ''CDec(vObjTempComprobante.Rows(Z)([ª0001ª]))
            //        OBJCPE_DETALLE_LIST.Add(objCPE_DETALLE);

            //        //==============================================

            //    }

            //    objCPE.detalle = OBJCPE_DETALLE_LIST;
            //    // ======================================RESPUESTA====================================
            //    Dictionary<string, string> dictionaryEnv = new Dictionary<string, string>();
            //    dictionaryEnv = obj.Enviar_NotaCredito_aSunat(objCPE);//********************************************************


            //    TXTCOD_SUNAT.Text = dictionaryEnv["cod_sunat"];
            //    //xcodsunat = dictionaryEnv["cod_sunat"];
            //    //xMsg = dictionaryEnv.Item["msj_sunat"];
            //    TXT_MSJ_SUNAT.Text = dictionaryEnv["msj_sunat"];
            //    TXTHASHCPE.Text = dictionaryEnv["hash_cpe"];
            //    TXTHASHCDR.Text = dictionaryEnv["hash_cdr"];
            //    MessageBox.Show(TXT_MSJ_SUNAT.Text);

            //}

            //catch (Exception ex)
            //{
            //    fil.Show();

            //    ver.lbl_msm.Text = "Revise la Falla: " + ex.Message;
            //    ver.ShowDialog();
            //    fil.Hide();
            //}

        }
        private void Agregar_DetallenotaCredito_alCarrito(string xidprod, string MotivoCred, double ximporte)
        {
            /*
            try
            {


                if (lsv_Det.Items.Count == 0)
                {
                    ListViewItem item = new ListViewItem();
                    item = lsv_Det.Items.Add(xidprod);
                    item.SubItems.Add(MotivoCred.Trim());
                    item.SubItems.Add("1");
                    item.SubItems.Add(ximporte.ToString("###0.00"));
                    item.SubItems.Add(ximporte.ToString("###0.00"));
                    item.SubItems.Add("Servicio");
                    item.SubItems.Add("Und");
                    item.SubItems.Add("0");
                    item.SubItems.Add("00");

                    //afecto:
                    item.SubItems.Add("Gravado");
                    item.SubItems.Add("0.00");
                    item.SubItems.Add("0.00");
                    item.SubItems.Add("0.00");
                    item.SubItems.Add("ZZ");  //tipo produvto:

                    Calcular();
                    lsv_Det.Focus();
                    lsv_Det.Items[0].Selected = true;
                    pnl_sinProd.Visible = false;
                }
                else
                {
                    //validar de que el producvto no se ingrese dos veces
                    for (int i = 0; i < lsv_Det.Items.Count; i++)
                    {
                        if (lsv_Det.Items[i].Text.Trim() == xidprod.Trim())
                        {
                            MessageBox.Show("El Producvto ya fue Agregado al Carrito de Compras", "ADveretencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return;
                        }
                    }

                    //lo añadimos:
                    ListViewItem item = new ListViewItem();
                    item = lsv_Det.Items.Add(xidprod);
                    item.SubItems.Add(MotivoCred.Trim());
                    item.SubItems.Add("1");
                    item.SubItems.Add(ximporte.ToString("###0.00"));
                    item.SubItems.Add(ximporte.ToString("###0.00"));
                    item.SubItems.Add("Servicio");
                    item.SubItems.Add("Und");
                    item.SubItems.Add("0");
                    item.SubItems.Add("00");
                    //afecto:
                    item.SubItems.Add("Gravado");
                    item.SubItems.Add("0.00");
                    item.SubItems.Add("0.00");
                    item.SubItems.Add("0.00");
                    item.SubItems.Add("ZZ");  //tipo produvto:

                    Calcular();
                    lsv_Det.Focus();
                    lsv_Det.Items[0].Selected = true;

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            */
        }
        private void Btn_Add_Moti_Click(object sender, EventArgs e)
        {
            //Frm_Filtro fil = new Frm_Filtro();
            //Frm_Advertencia ver = new Frm_Advertencia();
            //Frm_Msm_Bueno ok = new Frm_Msm_Bueno();
            //Frm_add_motivo_Nc moti = new Frm_add_motivo_Nc();

            //if (cbo_MotivoEmis.SelectedIndex == 2)
            //{
            //    if (lsv_Det.Items.Count >= 1)
            //    {
            //        //mostarr msm
            //        return;
            //    }
            //    else
            //    {
            //        fil.Show();
            //        moti.ShowDialog();
            //        fil.Hide();

            //        if (moti.Tag.ToString() == "A")
            //        {
            //            string xxmotiv = moti.txt_motivo.Text;
            //            double xximport = Convert.ToDouble(moti.txt_importe.Text);

            //            Agregar_DetallenotaCredito_alCarrito("NC-001", xxmotiv, xximport);
            //            Btn_Quitar.Enabled = true;
            //            Btn_Add_Moti.Enabled = false;
            //        }
            //    }

            //}


        }
        private void btn_cerrar_Click(object sender, EventArgs e)
        {
            this.Close();

        }
        private void btn_minimi_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }
        public void Buscar_NotaCredito_Para_Reimprimir(string Nro_Doc)
        {
            DataTable dta_doc = new DataTable();
            RN_Notacredito obj = new RN_Notacredito();

            Frm_Filtro fil = new Frm_Filtro();
            Frm_Advertencia ver = new Frm_Advertencia();
            Frm_Msm_Bueno ok = new Frm_Msm_Bueno();

            /*
            try
            {
                dta_doc = obj.RN_Cargar_NotaCredito_Detalle(Nro_Doc);
                if (dta_doc.Rows.Count > 0)
                {
                    {
                        var withBlock = dta_doc.Rows[0];
                        Lbl_NroNotaCredito.Text = withBlock["Id_Cre"].ToString();
                        Lbl_Nro_Doc.Text = withBlock["id_Doc"].ToString();
                        Lbl_ruc.Text = withBlock["DNI"].ToString();
                        Lbl_IdCliente.Text = withBlock["Id_Cliente"].ToString();
                        txt_ClienteNom.Text = withBlock["Razon_Social_Nombres"].ToString();
                        Lbl_TipoDocName.Text = withBlock["Tipocomprobnte"].ToString();
                        dtp_fechaActual.Value = Convert.ToDateTime(withBlock["Fecha_Emision"]);
                        Lbl_Total_ACobrar.Text = withBlock["Vlr_Total"].ToString();
                        // Lbl_Motivo.Text = .Item("Motivo_Emis")
                        // If Lbl_Motivo.Text.Trim = "Por Descuento" Then
                        // Rdb_PorDescuento.Checked = True

                        // ElseIf Lbl_Motivo.Text.Trim = "Por Devolucion" Then
                        // rdb_porDevolu.Checked = True
                        // End If


                        lsv_Det.Items.Clear();
                        foreach (DataRow xitem in dta_doc.Rows)
                        {
                            double xpre = 0;
                            double xcant = 0;
                            double ximport = 0;
                            string xidProd = "";
                            xpre = Convert.ToDouble(xitem["PrecioUniC"]);
                            xcant = Convert.ToDouble(xitem["CantidadC"]);
                            ximport = Convert.ToDouble(xitem["ImporteC"]);
                            xidProd = xitem["Id_Pro"].ToString();
                            ListViewItem xlist;
                            xlist = lsv_Det.Items.Add(xitem["Id_Pro"].ToString(), 0);
                            {
                                var withBlock1 = xlist;
                                withBlock1.SubItems.Add(xitem["DetalleNotaCredi"].ToString());
                                withBlock1.SubItems.Add(xcant.ToString("###0.00"));
                                withBlock1.SubItems.Add(xpre.ToString("###0.00"));
                                withBlock1.SubItems.Add(ximport.ToString("###0.00"));
                                withBlock1.SubItems.Add(xitem["TipoProdctonc"].ToString());
                                withBlock1.SubItems.Add("Und");
                                withBlock1.SubItems.Add("0");
                                withBlock1.SubItems.Add("0");
                                withBlock1.SubItems.Add("Gravado");
                                withBlock1.SubItems.Add("0");
                                withBlock1.SubItems.Add("0");
                                withBlock1.SubItems.Add("0");
                                withBlock1.SubItems.Add(xitem["TipoProdctonc"].ToString());
                            }
                        }
                        // ' llamamos a calcular
                        Calcular();

                    }

                    // 'Habilitamos los controles
                    btn_reimprimir.Enabled = true;
                    pnl_sinProd.Visible = false;
                    btn_cancelar.Enabled = true;
                    Btn_Emitir_NotaCred.Enabled = false;
                }
                else
                {
                    fil.Show();
                    ver.lbl_msm.Text = "I'm Sorry; No hay ninguna Nota de Credito que coincidan con tu Busqueda, Intentalo otra vez";
                    //Tocar_audioError();
                    ver.ShowDialog();
                    fil.Hide();
                }
            }
            catch (Exception ex)
            {
                fil.Show();
                ver.lbl_msm.Text = "Problemas al Buscar la Nota Credito: " + ex.Message;
                ver.ShowDialog();
                fil.Hide();
            }
       */
        }
        private void btn_reimprimir_Click(object sender, EventArgs e)
        {
            Frm_Filtro fil = new Frm_Filtro();
            Frm_Print_NotaVentaTicket nota = new Frm_Print_NotaVentaTicket();
            Frm_Advertencia ver = new Frm_Advertencia();

            /*
            if (lsv_Det.Items.Count > 0)
            {
                Registrar_archivos_Temporales();

                fil.Show();
                //nota.tipoImpre = "nc";
                //nota.RucEmisor = Lbl_RucEmisor.Text;
                //nota.tipoCompro = "07";  //nota de credito
                nota.lbl_nroDoc.Text = "Nota Credito : " + Lbl_NroNotaCredito.Text;
                nota.Tag = Lbl_NroNotaCredito.Text;
                nota.ShowDialog();
                fil.Hide();

                Restablecer_ventana();
                pnl_sinProd.Visible = true;
                Txt_buscarFac.Text = "";
            }*/
        }
    

        private void txt_soloNumero_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilitario uti = new Utilitario();
            e.KeyChar = Convert.ToChar(uti.SoloNumeros(e.KeyChar));
        }
    }
}
