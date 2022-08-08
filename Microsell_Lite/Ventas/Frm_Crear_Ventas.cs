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
using ThoughtWorks.QRCode.Codec;

//importar:
using SPV_Capa_Entidad;
using SPV_Capa_Negocio;
using System.IO;
using Microsell_Lite.Utilitarios;
using Microsell_Lite.Productos;
using Microsell_Lite.Cliente;
using Microsell_Lite.Informe;

//FE
using BE = businessEntities;
using CrearXML;
using CPEEnvio;
using Signature;
using Microsell_Lite.Principal;
using System.Net;
using Gma.QrCodeNet.Encoding;
using Gma.QrCodeNet.Encoding.Windows.Render;
using System.Drawing.Imaging;

namespace Microsell_Lite.Ventas
{
    public partial class Frm_Crear_Ventas : Form
    {
        public Frm_Crear_Ventas()
        {
            InitializeComponent();
        }
        #region Datos Enviar Sunat
        DataTable objtemComprobante;
        DataRow objtTemFilaomprobante;

        BE.CPE objCPE = new BE.CPE();
        BE.CPE_DETALLE objCPE_DETALLE = new BE.CPE_DETALLE();
        CPEConfig obj = new CPEConfig();
        #endregion
        #region Variable DatosEmpresa
        string v_empresaEmisor;
        string v_rucEmisor;
        string v_direccionEmpresa;
        string v_usuarioSol;
        string v_claveSol;
        string v_correoEmi;
        string v_claveCorreo;
        string v_certificadoClave;
        #endregion
        #region Tipos
        string tipoServidor; //2:Local - 1:Sunat - 3:Prueba
        string tipoDocumentoCliente; //6:RUC - 1:DNI
        string tipoDocumentoSunat; // 03:boletas - 01:facturas - 00:NotaVenta
        #endregion
        #region respuesta sunat
        string rpt_codSunat;
        string rpt_msjSunat;
        string rpt_hashCPE;
        string rpt_hashCDR;
        #endregion
        private void Frm_Ventana_Ventas_Load(object sender, EventArgs e)
        {

            Configurar_listView();
            listar_ComboBox_TipoDocumento();
            DatosEmpresa();
            tipoCambio();
            rbt_servLocal.Checked = true;
            txt_Cantidad.Text = "0";
        }
        void tipoCambio()
        {
            WebClient wc = new WebClient();
            string data;
            string[] ATC;
            data = wc.DownloadString("https://www.sunat.gob.pe/a/txt/tipoCambio.txt");
            ATC = data.Split('|');
            // MsgBox("Fecha:" & ATC(0) & " T.Compra: " & ATC(1) & " T.Venta: " & ATC(2))
            lbl_tipoCambio.Text= "Fecha:" + ATC[0] + " T.Compra: " + ATC[1] + " T.Venta: " + ATC[2];
        }
        void listar_ComboBox_TipoDocumento()
        {
            DataTable dt = new DataTable();
            RN_TipoDoc n_tipo = new RN_TipoDoc();
            dt = n_tipo.RN_Mostrar_TipoDocumento();
            if (dt.Rows.Count > 0)
            {
                var cbb = cbb_tipoDocumento;
                cbb.DataSource = dt;
                cbb.DisplayMember = "Documento";
                cbb.ValueMember = "Id_Tipo";
                cbb.SelectedIndex = -1;
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
            lis.Columns.Add("ID producto", 90, HorizontalAlignment.Left); //0
            lis.Columns.Add("Descripcion producto", 370, HorizontalAlignment.Left);  //1
            lis.Columns.Add("cantidad", 80, HorizontalAlignment.Left);  //2
            lis.Columns.Add("precio Unit", 80, HorizontalAlignment.Right);  //3
            lis.Columns.Add("Importe", 80, HorizontalAlignment.Right);  //4
            lis.Columns.Add("Tipo Producto", 0, HorizontalAlignment.Right);  //5
            lis.Columns.Add("Und", 0, HorizontalAlignment.Right);  //6
            lis.Columns.Add("Utilidad Unit", 0, HorizontalAlignment.Right);  //7
            lis.Columns.Add("Total Utilidad", 0, HorizontalAlignment.Right);  //8

            lis.Columns.Add("Afec. IGV", 70, HorizontalAlignment.Center);  //9
            lis.Columns.Add("Precio_sinIgv", 0, HorizontalAlignment.Right);  //10
            lis.Columns.Add("subtotal_sinIgv", 0, HorizontalAlignment.Right);  //11
            lis.Columns.Add("Igv_subtotal", 0, HorizontalAlignment.Center);  //12
            lis.Columns.Add("tipo", 130, HorizontalAlignment.Center);  //13 --bien o servicio

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
        Principal.Frm_Filtro fil = new Principal.Frm_Filtro();
        private void btn_Nuevo_buscarProd_Click(object sender, EventArgs e)
        {

            RN_Producto n_prod = new RN_Producto();
            Frm_Listar_ProductoCompra2 xpro = new Frm_Listar_ProductoCompra2();
            DataTable dt = new DataTable();

            fil.Show();
            xpro.TipoVenta = "venta";
            xpro.txt_buscar.Focus();
            xpro.rb_AddModoCoti.Checked = false;
            xpro.ShowDialog();

            fil.Hide();

            if (xpro.Tag.ToString() == "A")
            {
                string _idprod;
                string _nomprod;
                double _cant = 0;
                double _precio = 0;
                double _importe = 0;
                string _und;
                string _tipoProd;
                Double _Utili_Unit;
                string _UniMedida;

                if (xpro.lsv_pedido.Items.Count > 0)
                {
                    for (int i = 0; i < xpro.lsv_pedido.Items.Count; i++)
                    {
                        var item = xpro.lsv_pedido.Items[i];
                        _idprod = item.SubItems[0].Text;
                        _nomprod = item.SubItems[1].Text;
                        _cant = Convert.ToDouble(item.SubItems[3].Text);
                        _precio = Convert.ToDouble(item.SubItems[4].Text);
                        _importe = Convert.ToDouble(item.SubItems[5].Text);
                        _und = item.SubItems[2].Text;
                        _tipoProd = item.SubItems[7].Text;

                        dt = n_prod.RN_Buscar_UniMedia(_und);
                        DataRow dr = dt.Rows[0];
                        _UniMedida = dr["descripcion"].ToString();
                        _Utili_Unit = Convert.ToDouble(item.SubItems[6].Text);
                        //Gravado: ya incluye el igv para los precios que no incluya el igv ir a xplo producto y revisar
                        Agregar_Productos_alCarrito(_idprod, _nomprod, _cant, _precio, _importe, _und, _tipoProd, _Utili_Unit, "Gravado", _UniMedida);
                    }

                }
                else
                {
                    //para agregar de uno en Uno:
                    _idprod = xpro.lbl_idpro.Text;
                    _nomprod = xpro.lbl_NomProd.Text;
                    _cant = Convert.ToDouble(xpro.lbl_Cant.Text);
                    _precio = Convert.ToDouble(xpro.lbl_Pre_Unt.Text);
                    _importe = Convert.ToDouble(xpro.lbl_import.Text);
                    _tipoProd = xpro.lbl_tipoProd.Text;
                    _und = xpro.lbl_Und.Text;

                    dt = n_prod.RN_Buscar_UniMedia(_und);
                    DataRow dr = dt.Rows[0];
                    _UniMedida = dr["descripcion"].ToString();

                    _Utili_Unit = Convert.ToDouble(xpro.lbl_Uti_unit.Text);
                    Agregar_Productos_alCarrito(_idprod, _nomprod, _cant, _precio, _importe, _und, _tipoProd, _Utili_Unit, "Gravado", _UniMedida);

                }

            }
            if (txt_Cantidad.Text.Length > 0)
            {
                if (txt_Cantidad.Text == "" | txt_Cantidad.Text == null)
                {
                    txt_Cantidad.Text = "0";
                }
                lbl_vuelto.Text = (Convert.ToDouble(txt_Cantidad.Text) - Convert.ToDouble(lbl_TotalPagar.Text) - Convert.ToDouble(lbl_saldoPendiente.Text)).ToString("##0.00");
                lbl_pagaCon.Text = txt_Cantidad.Text;
            }
            xpro.LimpiarLabels();
        }
        private void Agregar_Productos_alCarrito(string xidprod, string xnomprod, double xcant, double xprecio, double ximporte, string xund, string xtipoProd, double xutili_unit, string xafecto, string uniMedida)
        {
            try
            {


                if (lsv_Det.Items.Count == 0)
                {
                    ListViewItem item = new ListViewItem();
                    item = lsv_Det.Items.Add(xidprod);
                    item.SubItems.Add(xnomprod.Trim());
                    item.SubItems.Add(xcant.ToString());
                    item.SubItems.Add(xprecio.ToString("###0.00"));
                    item.SubItems.Add(ximporte.ToString("###0.00"));
                    item.SubItems.Add(xtipoProd.ToString());
                    item.SubItems.Add(xund.ToString());
                    item.SubItems.Add(xutili_unit.ToString("###0.00"));
                    item.SubItems.Add(xutili_unit.ToString("###0.00"));

                    item.SubItems.Add(xafecto);
                    item.SubItems.Add("0.00");
                    item.SubItems.Add("0.00");
                    item.SubItems.Add("0.00");
                    item.SubItems.Add(uniMedida.ToString());

                    Calcular();
                    lsv_Det.Focus();
                    lsv_Det.Items[0].Selected = true;
                    pnl_sinProd.Visible = false;
                }
                else
                {
                    //validar de que el producuto no se ingrese dos veces
                    for (int i = 0; i < lsv_Det.Items.Count; i++)
                    {
                        if (lsv_Det.Items[i].Text.Trim() == xidprod.Trim())
                        {
                            MessageBox.Show("El Producto " + xnomprod + " con " + xcant + " Und(s) ya fue Agregado al Carrito de Compras", "Adveretencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return;
                        }
                    }

                    //lo añadimos:
                    ListViewItem item = new ListViewItem();
                    item = lsv_Det.Items.Add(xidprod);
                    item.SubItems.Add(xnomprod.Trim());
                    item.SubItems.Add(xcant.ToString());
                    item.SubItems.Add(xprecio.ToString("###0.00"));
                    item.SubItems.Add(ximporte.ToString("###0.00"));
                    item.SubItems.Add(xtipoProd.ToString());
                    item.SubItems.Add(xund.ToString());
                    item.SubItems.Add(xutili_unit.ToString("###0.00"));
                    item.SubItems.Add(xutili_unit.ToString("###0.00"));

                    item.SubItems.Add(xafecto);
                    item.SubItems.Add("0.00");
                    item.SubItems.Add("0.00");
                    item.SubItems.Add("0.00");
                    item.SubItems.Add(uniMedida.ToString());

                    Calcular();
                    lsv_Det.Focus();
                    lsv_Det.Items[0].Selected = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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
        private void bt_add_Click(object sender, EventArgs e)
        {
            Frm_Listar_ProductoCompra2 xpro = new Frm_Listar_ProductoCompra2();
            RN_Producto n_prod = new RN_Producto();


            fil.Show();
            xpro.TipoVenta = "venta";
            xpro.ShowDialog();

            fil.Hide();

            if (xpro.Tag.ToString() == "A")
            {
                DataTable dt = new DataTable();
                string _idprod;
                string _nomprod;
                double _cant = 0;
                double _precio = 0;
                double _importe = 0;
                string _und;
                string _tipoProd;
                Double _Utili_Unit;
                string _UniMedida;

                if (xpro.lsv_pedido.Items.Count > 0)
                {
                    //Agregar del lsv sin salir
                    for (int i = 0; i < xpro.lsv_pedido.Items.Count; i++)
                    {
                        var item = xpro.lsv_pedido.Items[i];
                        _idprod = item.SubItems[0].Text;
                        _nomprod = item.SubItems[1].Text;
                        _cant = Convert.ToDouble(item.SubItems[3].Text);
                        _precio = Convert.ToDouble(item.SubItems[4].Text);
                        _importe = Convert.ToDouble(item.SubItems[5].Text);
                        _und = item.SubItems[2].Text;
                        _tipoProd = item.SubItems[7].Text;
                        _Utili_Unit = Convert.ToDouble(item.SubItems[6].Text);

                        dt = n_prod.RN_Buscar_UniMedia(_und);
                        DataRow dr = dt.Rows[0];
                        _UniMedida = dr["descripcion"].ToString();

                        Agregar_Productos_alCarrito(_idprod, _nomprod, _cant, _precio, _importe, _und, _tipoProd, _Utili_Unit, "Gravado", _UniMedida);
                    }

                }
                else
                {
                    //para agregar de uno en Uno:
                    _idprod = xpro.lbl_idpro.Text;
                    _nomprod = xpro.lbl_NomProd.Text;
                    _cant = Convert.ToDouble(xpro.lbl_Cant.Text);
                    _precio = Convert.ToDouble(xpro.lbl_Pre_Unt.Text);
                    _importe = Convert.ToDouble(xpro.lbl_import.Text);
                    _und = xpro.lbl_Und.Text;
                    _tipoProd = xpro.lbl_tipoProd.Text;
                    
                    _Utili_Unit = Convert.ToDouble(xpro.lbl_Uti_unit.Text);

                    dt = n_prod.RN_Buscar_UniMedia(_und);
                    DataRow dr = dt.Rows[0];
                    _UniMedida = dr["descripcion"].ToString();

                    Agregar_Productos_alCarrito(_idprod, _nomprod, _cant, _precio, _importe, _und, _tipoProd, _Utili_Unit, "Gravado", _UniMedida);

                }

            }
            if (txt_Cantidad.Text.Length > 0)
            {
                if (txt_Cantidad.Text == "" | txt_Cantidad.Text == null)
                {
                    txt_Cantidad.Text = "0";
                }
                lbl_vuelto.Text = (Convert.ToDouble(txt_Cantidad.Text) - Convert.ToDouble(lbl_TotalPagar.Text) - Convert.ToDouble(lbl_saldoPendiente.Text)).ToString("##0.00");
                lbl_pagaCon.Text = txt_Cantidad.Text;
            }

            xpro.LimpiarLabels();
        }
        public static string xid_prod;
        private void bt_editPre_Click(object sender, EventArgs e)
        {
            /*como se registra la utilidad de un descuento y como se contabiliza*/
            Frm_Edit_Precio solo = new Frm_Edit_Precio();

            if (lsv_Det.SelectedIndices.Count == 0)
            {
                MessageBox.Show("Seleccionar el Producto a Editar su Precio", "Editar Precio", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                double precio_Ingresado;
                double Precio_Editado;
                double cant_ingresado;
                double Cant_Editado;
                string xidprod;
                double xUti_unit;
                double xprecioCompra;

                xidprod = lsv_Det.SelectedItems[0].SubItems[0].Text;
                xid_prod = xidprod;
                precio_Ingresado = Convert.ToDouble(lsv_Det.SelectedItems[0].SubItems[3].Text);
                cant_ingresado = Convert.ToDouble(lsv_Det.SelectedItems[0].SubItems[2].Text);
                xprecioCompra = Convert.ToDouble(solo.Lbl_precompra.Text);

                fil.Show();
                solo.txt_precio.Text = precio_Ingresado.ToString("###0.00");
                solo.txt_cant.Text = cant_ingresado.ToString("###0.00");
                solo.lbl_tipoProd.Text = xidprod.Trim();
                solo.ShowDialog();
                fil.Hide();

                if (solo.Tag.ToString() == "A")
                {
                    Precio_Editado = Convert.ToDouble(solo.txt_precio.Text);
                    Cant_Editado = Convert.ToDouble(solo.txt_cant.Text);
                    xUti_unit = Convert.ToDouble(solo.Lbl_UtilidadUnit.Text);
                    //falta importe
                    if (xprecioCompra < Precio_Editado) //solo permitira vender si el costo es igual o mayor al precio de la venta.
                    {
                        lsv_Det.SelectedItems[0].SubItems[3].Text = Precio_Editado.ToString("###0.00");
                        lsv_Det.SelectedItems[0].SubItems[2].Text = Cant_Editado.ToString("###0.00");
                        lsv_Det.SelectedItems[0].SubItems[7].Text = (xUti_unit).ToString("###0.00");
                        Calcular();
                    }
                    else
                    {
                        MessageBox.Show("El producto tiene un Precio de Compra de " + xprecioCompra + "soles y el precio a sido editado en " + Precio_Editado + " soles.",
                            "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }
            if (txt_Cantidad.Text.Length >= 0)
            {
                if (txt_Cantidad.Text == "" | txt_Cantidad.Text==null)
                {
                    txt_Cantidad.Text = "0";
                }
                lbl_vuelto.Text = (Convert.ToDouble(txt_Cantidad.Text) - Convert.ToDouble(lbl_TotalPagar.Text) - Convert.ToDouble(lbl_saldoPendiente.Text)).ToString("##0.00");
                lbl_pagaCon.Text = txt_Cantidad.Text;
            }
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

            //FE
            double igvProd = 0;
            double subtotal_SinIGV = 0;
            double preUnit_SinIGV = 0;

            double xsubtotal_SinIGV = 0;
            double xigv_total = 0;

            for (int i = 0; i < lsv_Det.Items.Count; i++)
            {
                xcant = Convert.ToDouble(lsv_Det.Items[i].SubItems[2].Text);
                xprecio = Convert.ToDouble(lsv_Det.Items[i].SubItems[3].Text);

                //calculo:
                ximporte = xprecio * xcant;
                lsv_Det.Items[i].SubItems[4].Text = ximporte.ToString("###0.00");

                //utilidad:
                xuti_unit = Convert.ToDouble(lsv_Det.Items[i].SubItems[7].Text);
                ximport_Uti = xuti_unit * xcant;


                //caluclo del total:
                xtotal = xtotal + Convert.ToDouble(lsv_Det.Items[i].SubItems[4].Text);

                xTotalGanancia = xTotalGanancia + Convert.ToDouble(lsv_Det.Items[i].SubItems[7].Text) * xcant; //OJO

                //preUnit_SinIGV = xprecio * 0.82;
                preUnit_SinIGV = xprecio / 1.18;
                lsv_Det.Items[i].SubItems[10].Text = preUnit_SinIGV.ToString("###0.00");

                subtotal_SinIGV = preUnit_SinIGV * xcant;
                lsv_Det.Items[i].SubItems[11].Text = subtotal_SinIGV.ToString("###0.00");

                igvProd = subtotal_SinIGV * 0.18;
                //igvProd = subtotal_SinIGV * 0.18;
                lsv_Det.Items[i].SubItems[12].Text = igvProd.ToString("###0.00");

                //Pie para sunat
                xsubtotal_SinIGV = xsubtotal_SinIGV + Convert.ToDouble(lsv_Det.Items[i].SubItems[11].Text);
                xigv_total = xigv_total + Convert.ToDouble(lsv_Det.Items[i].SubItems[12].Text);
            }
            //calcular el IGV: 
            //xsubtotal = xtotal * 0.82;
            xsubtotal = xtotal / 1.18;
            xigv = xsubtotal * 0.18;
            //xigv = xsubtotal * 0.18;

            lbl_subtotal.Text = xsubtotal.ToString("###0.00");
            lbl_igv.Text = xigv.ToString("###0.00");
            lbl_TotalPagar.Text = xtotal.ToString("###0.00");
            lbl_totalGanancia.Text = xTotalGanancia.ToString("###0.00");

            lbl_son.Text = Numalet.ToString(lbl_TotalPagar.Text);
            let.LetraCapital = chkCapital.Checked;
            if (!actualizado) ActualizarCong();
            // totales FE
            lbl_subtotalGravado.Text = xsubtotal_SinIGV.ToString("###0.00");
            lbl_IGVgravado.Text = xigv_total.ToString("###0.00");

            double totalGravado = xsubtotal_SinIGV + xigv_total;
            lbl_TotalGravado.Text = totalGravado.ToString("###0.00");
            lbl_totalItems.Text = lsv_Det.Items.Count.ToString();
        }
        private void bt_editCant_Click(object sender, EventArgs e)
        {
            Frm_Filtro fil = new Frm_Filtro();
            Frm_Solo_Cant solo = new Frm_Solo_Cant();

            if (lsv_Det.SelectedIndices.Count == 0)
            {
                MessageBox.Show("Seleccionar el Producto a Editar su Cantidad", "Editar Precio", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                double cant_Ingresado = 0;
                double cant_Editado = 0;
                cant_Ingresado = Convert.ToDouble(lsv_Det.SelectedItems[0].SubItems[2].Text);

                fil.Show();
                solo.txt_Cantidad.Text = cant_Ingresado.ToString();
                solo.ShowDialog();
                fil.Hide();


                if (solo.Tag.ToString() == "A")
                {
                    cant_Editado = Convert.ToDouble(solo.txt_Cantidad.Text);
                    lsv_Det.SelectedItems[0].SubItems[2].Text = cant_Editado.ToString("###0.00");
                    Calcular();
                }

            }
        }
        private void bt_Delete_Click(object sender, EventArgs e)
        {
            Utilitarios.Frm_SINO sino = new Utilitarios.Frm_SINO();
            if (lsv_Det.SelectedIndices.Count == 0)
            {
                MessageBox.Show("Seleccione un producto para eliminar del carrito.", "Advertencia de seguridad", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                fil.Show();
                sino.lbl_msm.Text = "¿Estas seguro de eliminar el producto: " + lsv_Det.SelectedItems[0].SubItems[1].Text + " del carrito? ";
                sino.ShowDialog();
                fil.Hide();
                if (sino.Tag.ToString() == "SI")
                {
                    int i;
                    var lis = lsv_Det.SelectedItems[0];
                    for (i = lsv_Det.SelectedItems.Count - 1; i >= 0; i--)
                    {
                        lsv_Det.Items.Remove(lsv_Det.SelectedItems[i]);
                    }
                    Calcular();
                    if (lsv_Det.Items.Count == 0)
                    {
                        pnl_sinProd.Visible = true;
                    }
                }
            }
            if (txt_Cantidad.Text.Length >= 0)
            {
                if (txt_Cantidad.Text == "" | txt_Cantidad.Text == null)
                {
                    txt_Cantidad.Text = "0";
                }
                lbl_vuelto.Text = (Convert.ToDouble(txt_Cantidad.Text) - Convert.ToDouble(lbl_TotalPagar.Text) - Convert.ToDouble(lbl_saldoPendiente.Text)).ToString("##0.00");
                lbl_pagaCon.Text = txt_Cantidad.Text;
            }
        }
        int header = 0;
        int det = 0;
        private void Guardar_PedidoExistente()
        {
            RN_Pedido n_pedi = new RN_Pedido();
            EN_Pedido e_ped = new EN_Pedido();
            EN_Det_Pedido e_det = new EN_Det_Pedido();

            try
            {
                //txt_nroPed.Text = RN_TipoDoc.Sp_Listado_Tipo(10);

                e_ped.Id_Ped = txt_nroPed.Text;
                e_ped.Id_Cliente = lbl_idcliente.Text;
                e_ped.SubTotal = Convert.ToDouble(lbl_subtotal.Text);
                e_ped.IgvPed = Convert.ToDouble(lbl_igv.Text);
                e_ped.TotalPed = Convert.ToDouble(lbl_TotalPagar.Text);
                e_ped.Id_Usu = Cls_UsuLogin.IdUsu.ToString();
                e_ped.TotalGancia = Convert.ToDouble(lbl_totalGanancia.Text);
                e_ped.Estado_Ped = "Activo";
                e_ped.Fecha_Ped = DateTime.Now;

                e_ped.Subtotal_Gravado = Convert.ToDouble(lbl_subtotalGravado.Text);
                e_ped.IgvGravado = Convert.ToDouble(lbl_IGVgravado.Text);
                e_ped.TotalGravado = Convert.ToDouble(lbl_TotalGravado.Text);

                header = n_pedi.RN_Editar_Pedido_Header(e_ped);
                if (header == 1)
                {
                    n_pedi.RN_Eliminar_Pedido_Det(txt_nroPed.Text);
                    //guardar el detalle del pedido:
                    e_det.Id_Ped = txt_nroPed.Text;

                    for (int i = 0; i < lsv_Det.Items.Count; i++)
                    {
                        var lis = lsv_Det.Items[i];

                        e_det.Id_Pro = lis.SubItems[0].Text;
                        e_det.Precio = Convert.ToDouble(lis.SubItems[3].Text);
                        e_det.Cantidad = Convert.ToDouble(lis.SubItems[2].Text);
                        e_det.Importe = Convert.ToDouble(lis.SubItems[4].Text);
                        e_det.Tipo_Prod = lis.SubItems[5].Text;
                        e_det.Und_Medida = lis.SubItems[6].Text;
                        e_det.Utilidad_Unit = Convert.ToDouble(lis.SubItems[7].Text);//validar
                        e_det.TotalUtilidad = Convert.ToDouble(lis.SubItems[8].Text) * Convert.ToDouble(lis.SubItems[2].Text);//validar

                        e_det.AfectoIGV = lis.SubItems[9].Text;
                        e_det.Precio_sinIgv = Convert.ToDouble(lis.SubItems[10].Text);
                        e_det.Subtotal_sinIgv = Convert.ToDouble(lis.SubItems[11].Text);
                        e_det.Igv_subtotal = Convert.ToDouble(lis.SubItems[12].Text);
                        e_det.P_Cant_Original = 0;

                        n_pedi.RN_Registrar_Pedido_Det(e_det);
                        det = 1;
                    }
                }

            }
            catch (Exception ex)
            {
                string msm = ex.Message;
                MessageBox.Show("Error al Guardar: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }


        }
        private void Guardar_Pedido()
        {
            RN_Pedido n_pedi = new RN_Pedido();
            EN_Pedido e_ped = new EN_Pedido();
            EN_Det_Pedido e_det = new EN_Det_Pedido();

            try
            {
                txt_nroPed.Text = RN_TipoDoc.Sp_Listado_Tipo(10);

                e_ped.Id_Ped = txt_nroPed.Text;
                e_ped.Id_Cliente = lbl_idcliente.Text;
                e_ped.SubTotal = Convert.ToDouble(lbl_subtotal.Text);
                e_ped.IgvPed = Convert.ToDouble(lbl_igv.Text);
                e_ped.TotalPed = Convert.ToDouble(lbl_TotalPagar.Text);
                e_ped.Id_Usu = Cls_UsuLogin.IdUsu.ToString();
                e_ped.TotalGancia = Convert.ToDouble(lbl_totalGanancia.Text);
                e_ped.Estado_Ped = "Activo";

                e_ped.Subtotal_Gravado = Convert.ToDouble(lbl_subtotalGravado.Text);
                e_ped.IgvGravado = Convert.ToDouble(lbl_IGVgravado.Text);
                e_ped.TotalGravado = Convert.ToDouble(lbl_TotalGravado.Text);

                header = n_pedi.RN_Registrar_Pedido_Header(e_ped);
                if (header == 1)
                {
                    RN_TipoDoc.RN_Actualizar_SiguienteNro_correlativo(10);
                    //guardar el detalle del pedido:

                    e_det.Id_Ped = txt_nroPed.Text;

                    for (int i = 0; i < lsv_Det.Items.Count; i++)
                    {
                        var lis = lsv_Det.Items[i];

                        e_det.Id_Pro = lis.SubItems[0].Text;
                        e_det.Precio = Convert.ToDouble(lis.SubItems[3].Text);
                        e_det.Cantidad = Convert.ToDouble(lis.SubItems[2].Text);
                        e_det.Importe = Convert.ToDouble(lis.SubItems[4].Text);
                        e_det.Tipo_Prod = lis.SubItems[5].Text;
                        e_det.Und_Medida = lis.SubItems[6].Text;
                        e_det.Utilidad_Unit = Convert.ToDouble(lis.SubItems[7].Text);//validar
                        e_det.TotalUtilidad = Convert.ToDouble(lis.SubItems[8].Text) * Convert.ToDouble(lis.SubItems[2].Text);//validar

                        e_det.AfectoIGV = lis.SubItems[9].Text;
                        e_det.Precio_sinIgv = Convert.ToDouble(lis.SubItems[10].Text);
                        e_det.Subtotal_sinIgv = Convert.ToDouble(lis.SubItems[11].Text);
                        e_det.Igv_subtotal = Convert.ToDouble(lis.SubItems[12].Text);
                        e_det.P_Cant_Original = 0;

                        n_pedi.RN_Registrar_Pedido_Det(e_det);
                        det = 1;
                    }
                }

            }
            catch (Exception ex)
            {
                string msm = ex.Message;
                MessageBox.Show("Error al Guardar: " + msm, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }


        }
        private void txt_cliente_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                lbl_BusClien_Click(sender, e);
            }


        }

        private void cbb_tipoPago_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
        int GuardarDocumento()
        {
            EN_Documento e_doc = new EN_Documento();
            RN_Documento n_doc = new RN_Documento();
            int rpt;
            try
            {
                txt_NroDocumento.Text = RN_TipoDoc.Sp_Listado_Tipo(Convert.ToInt32(cbb_tipoDocumento.SelectedValue));
                e_doc.Id_Doc = txt_NroDocumento.Text;
                e_doc.Id_Ped = txt_nroPed.Text;
                e_doc.Id_Tipo = Convert.ToInt32(cbb_tipoDocumento.SelectedValue);
                e_doc.Fecha_Emi = dtp_FechaEmi.Value;
                e_doc.Importe = Convert.ToDouble(lbl_TotalPagar.Text);
                e_doc.TipoPago = cbb_tipoPago.Text;
                e_doc.NroOpera = txt_NumOperacion.Text;
                e_doc.Id_Usu = Cls_UsuLogin.IdUsu;
                e_doc.Igv = Convert.ToDouble(lbl_igv.Text);
                e_doc.Son = lbl_son.Text;
                e_doc.TotalGanancia = Convert.ToDouble(lbl_totalGanancia.Text);
                e_doc.CDR_Sunat = "Pendiente";
                e_doc.Hash_CPE = "-";
                e_doc.EstadoBajada = "Activo";
                e_doc.NroTicket_Baja = "-";
                e_doc.Hash_CPE_Baja = "-";

                rpt = n_doc.RN_Ingresar_Documento(e_doc);
                if (rpt == 1)
                {
                    RN_TipoDoc.RN_Actualizar_SiguienteNro_correlativo(Convert.ToInt32(cbb_tipoDocumento.SelectedValue));
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al Guardar: " + ex.Message, "Form Add Documento", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                rpt = 0;
            }
            return rpt;
        }
        private void btn_procesar_Click(object sender, EventArgs e)
        {
            Frm_Msm_Bueno msm = new Frm_Msm_Bueno();
            Frm_TipoPago_Credito tipo = new Frm_TipoPago_Credito();
            Frm_Print_NotaVenta_A5 cpb_A5 = new Frm_Print_NotaVenta_A5();
            Frm_Print_NotaVenta_A4 cpb_A4 = new Frm_Print_NotaVenta_A4();
            Frm_Print_NotaVentaTicket cpb_ticket = new Frm_Print_NotaVentaTicket();
            RN_Documento doc = new RN_Documento();
            RN_Notacredito nc = new RN_Notacredito();
            Frm_Terminar_Venta_SMS ter = new Frm_Terminar_Venta_SMS();
            Frm_Formato formato = new Frm_Formato();

            fil.Show();
            cpb_ticket.RutaPPF = "";
            cpb_A5.RutaPPF = "";
            ter.lbl_rutaPDF.Text = "";

            formato.ShowDialog();

            if (Validar_compra())
            {
                //if (cbb_tipoPago.SelectedIndex==0)
                //{
                //    fil.Show();
                //    //me llevo el label
                //    //muestro la ventana
                //    //billete de pago
                //    fil.Hide();

                //}
                if (cbb_tipoPago.SelectedIndex == 2)
                {
                    fil.Show();
                    tipo.Limpiar_Frm_Credito();
                    tipo.lbl_totalACobrar.Text = lbl_TotalPagar.Text;
                    tipo.ShowDialog();
                    fil.Hide();
                    if (tipo.Tag.ToString() == "A")
                    {
                        lbl_Acuenta.Text = tipo.txt_ACuenta.Text;
                        lbl_saldoCredito.Text = tipo.lbl_SaldoAPagarCredito.Text;
                        dtp_VenciCredito.Value = tipo.dtp_FechaEmi_vec.Value;
                        lbl_tipopagoCred.Text = tipo.cbb_tipoPago.Text;
                    }
                }

                if (txt_buscar.Enabled == false)
                {
                    Guardar_PedidoExistente();
                }
                else
                {
                    Guardar_Pedido();
                }

                if (header == 1 && det == 1)
                {
                    if (GuardarDocumento() == 1)
                    {

                        if (cbb_tipoPago.SelectedIndex == 0 || cbb_tipoPago.SelectedIndex == 1)/*EFECTIVO-DEPOSITO el combobox tipo de documento sepuede traer de una tabla*/
                        {
                            Guardar_Ingreso_Caja();
                        }
                        else if (cbb_tipoPago.SelectedIndex == 2)
                        {
                            //Movimiento de caja a credito
                            //registro de credito al cliente
                            Crear_Registro_Credito();
                        }
                        else if (cbb_tipoPago.SelectedIndex == 3)
                        {
                            //actualizar y verificar vale
                            MessageBox.Show("Medio de Pago Vale no se encuentra disponible","Mensaje",MessageBoxButtons.OK,MessageBoxIcon.Information);
                        }
                        else if (cbb_tipoPago.SelectedIndex == 4)
                        {
                            //actualizar y verificar NC
                            nc.RN_Actualizar_EstadoDinero_NC(lbl_idNC.Text, "No Pago");
                            Guardar_Ingreso_Caja_NC();
                        }

                        //registrar movimiento de kardex
                        RegistrarMovimientoKardex();
                        //Frm_Filtro fil = new Frm_Filtro();
                        if (tipoServidor == "2")
                        {
                            if (formato.rbt_for_A4.Checked)
                            {
                                RegistrarArchivosTemporales("A4");
                            }
                            else
                            {
                                RegistrarArchivosTemporales("A5 y ticket");
                            }
                            

                            //cambiar estado de cotizacion
                            if (txt_buscar.Text.Length > 6)
                            {
                                RN_Cotizacion n_coti = new RN_Cotizacion();
                                n_coti.RN_Cambiar_Estado_Cotizacion(txt_NroCotiza.Text, "Atendido");
                            }

                            //InicioTicket 
                            /*
                            fil.Show();
                            cpb_ticket.RutaPPF = "";
                            cpb_A5.RutaPPF = "";
                            ter.lbl_rutaPDF.Text = "";

                            formato.ShowDialog();
                             */

                            if (formato.Tag.ToString() == "A")
                            {
                                if (formato.rbt_for_ticket.Checked)
                                {
                                    fil.Show();
                                    cpb_ticket.lbl_nroDoc.Text = cbb_tipoDocumento.Text + " - " + txt_NroDocumento.Text;
                                    cpb_ticket.Tag = txt_NroDocumento.Text;
                                    cpb_ticket.RutaPPF = rutaPDF_Export_Ventas + v_rucEmisor.Trim() + "-" + tipoDocumentoSunat.Trim() + "-" + txt_NroDocumento.Text.Trim() + ".pdf";
                                    //rutaPDF_Export_Ventas = rutaPDF_Export_Ventas + v_rucEmisor.Trim() + "-" + tipoDocumentoSunat + "-" + txt_NroDocumento.Text + ".pdf";
                                    cpb_ticket.ShowDialog();
                                    fil.Hide();

                                    fil.Show();
                                    ter.lbl_Documento.Text = txt_NroDocumento.Text;
                                    //.lbl_rutaPDF.Text = rutaPDF_Export_Ventas;
                                    ter.lbl_rutaPDF.Text = cpb_ticket.RutaPPF;
                                    //ter.lbl_rutaXML.Text = obj.RutaCompleta_XML;
                                    ter.ShowDialog();
                                    fil.Hide();
                                }
                                else if (formato.rbt_for_A5.Checked)
                                {
                                    fil.Show();
                                    cpb_A5.lbl_nroDoc.Text = cbb_tipoDocumento.Text + " - " + txt_NroDocumento.Text;
                                    cpb_A5.Tag = txt_NroDocumento.Text;
                                    cpb_A5.RutaPPF = rutaPDF_Export_Ventas + v_rucEmisor.Trim() + "-" + tipoDocumentoSunat.Trim() + "-" + txt_NroDocumento.Text.Trim() + ".pdf";
                                    cpb_A5.ShowDialog();
                                    fil.Hide();

                                    fil.Show();
                                    ter.lbl_Documento.Text = txt_NroDocumento.Text;
                                    //.lbl_rutaPDF.Text = rutaPDF_Export_Ventas;
                                    ter.lbl_rutaPDF.Text = cpb_A5.RutaPPF;
                                    //ter.lbl_rutaXML.Text = obj.RutaCompleta_XML;
                                    ter.ShowDialog();
                                    fil.Hide();
                                }
                                else if (formato.rbt_for_A4.Checked)
                                {
                                    fil.Show();
                                    cpb_A4.lbl_nroDoc.Text = cbb_tipoDocumento.Text + " - " + txt_NroDocumento.Text;
                                    cpb_A4.Tag = txt_NroDocumento.Text;
                                    cpb_A4.RutaPPF = rutaPDF_Export_Ventas + v_rucEmisor.Trim() + "-" + tipoDocumentoSunat.Trim() + "-" + txt_NroDocumento.Text.Trim() + ".pdf";
                                    cpb_A4.ShowDialog();
                                    fil.Hide();

                                    fil.Show();
                                    ter.lbl_Documento.Text = txt_NroDocumento.Text;
                                    //.lbl_rutaPDF.Text = rutaPDF_Export_Ventas;
                                    ter.lbl_rutaPDF.Text = cpb_A4.RutaPPF;
                                    //ter.lbl_rutaXML.Text = obj.RutaCompleta_XML;
                                    ter.ShowDialog();
                                    fil.Hide();
                                }
                            }
                            /*
                            nv_ticket.lbl_nroDoc.Text = cbb_tipoDocumento.Text + " - " + txt_NroDocumento.Text;
                            nv_ticket.Tag = txt_NroDocumento.Text;
                            nv_ticket.RutaPPF = rutaPDF_Export_Ventas + v_rucEmisor.Trim() + "-" + tipoDocumentoSunat + "-" + txt_NroDocumento.Text + ".pdf";
                            //rutaPDF_Export_Ventas = rutaPDF_Export_Ventas + v_rucEmisor.Trim() + "-" + tipoDocumentoSunat + "-" + txt_NroDocumento.Text + ".pdf";
                            nv_ticket.ShowDialog();
                            
                            fil.Hide();

                            fil.Show();
                            ter.lbl_Documento.Text = txt_NroDocumento.Text;
                            //.lbl_rutaPDF.Text = rutaPDF_Export_Ventas;
                            ter.lbl_rutaPDF.Text = nv_ticket.RutaPPF;
                            //ter.lbl_rutaXML.Text = obj.RutaCompleta_XML;
                            ter.ShowDialog();
                            fil.Hide();
                            */
                            //fin ticket

                            header = 0;
                            det = 0;
                            fil.Hide();

                            LimpiarTodo();
                            return;
                        }

                        //VALIDACION FACTURA ELECTRNICA
                        #region Comprobar envio a la sunat

                        if (cbb_tipoDocumento.SelectedIndex == 0 || cbb_tipoDocumento.Text == "Nota Venta")
                        {
                            //fil.Show();
                            //MessageBox.Show("El Documento sera una Nota de venta.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            //fil.Hide();
                        }
                        else if (Convert.ToInt32(lbl_Dni.Text.Length) == 8 && cbb_tipoDocumento.Text == "Boleta")
                        {
                            //txt_NroDocumento.Text = RN_TipoDoc.Sp_Listado_Tipo(Convert.ToInt32(cbb_tipoDocumento.SelectedValue));
                            EnviarDocumento_Sunat();
                        }
                        else if (Convert.ToInt32(lbl_Dni.Text.Length) == 11 && cbb_tipoDocumento.Text == "Factura")
                        {
                            //txt_NroDocumento.Text = RN_TipoDoc.Sp_Listado_Tipo(Convert.ToInt32(cbb_tipoDocumento.SelectedValue));
                            EnviarDocumento_Sunat();
                        }
                        else
                        {
                            fil.Show();
                            MessageBox.Show("El Documento " + lbl_Dni.Text + " no es valido para la " + cbb_tipoDocumento.Text + " Verificar el numero de documento del cliente corresponda al tipo de Documento a emitir", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            fil.Hide();
                            return;
                        }
                        #endregion
                        if (tipoServidor == "1" || tipoServidor == "3")
                        {
                            //Enviar documento a la sunat
                            //btn_Comprobar_Click(sender, e);
                            if (rpt_codSunat == "0" || rpt_codSunat == "1")
                            {
                                doc.RN_Cambiar_RPT_EstadoSunat(txt_NroDocumento.Text, "Aprobado", rpt_hashCPE);
                                fil.Show();
                                msm.Lbl_msm1.Text = "La venta se realizo exitosamente y aprobada por la Sunat." + "\r\n" + rpt_msjSunat;
                                msm.ShowDialog();
                                fil.Hide();
                                header = 0;
                                det = 0;
                                if (formato.rbt_for_A4.Checked)
                                {
                                    RegistrarArchivosTemporales("A4");
                                }
                                else
                                {
                                    RegistrarArchivosTemporales("A5 y ticket");
                                }
                            }
                            else if (cbb_tipoDocumento.Text != "Nota Venta")
                            {
                                doc.RN_Cambiar_RPT_EstadoSunat(txt_NroDocumento.Text, "Rechazado MSJ: " + rpt_msjSunat, rpt_hashCPE);
                                fil.Show();
                                msm.Lbl_msm1.Text = "La venta se realizo, pero fue rechazada por la Sunat. " + "\r\n" + rpt_msjSunat;
                                msm.ShowDialog();
                                fil.Hide();
                                header = 0;
                                det = 0;
                                if (formato.rbt_for_A4.Checked)
                                {
                                    RegistrarArchivosTemporales("A4");
                                }
                                else
                                {
                                    RegistrarArchivosTemporales("A5 y ticket");
                                }
                            }
                            if (cbb_tipoDocumento.SelectedIndex == 0 || cbb_tipoDocumento.Text == "Nota Venta")
                            {

                            }
                            else
                            {
                                //cambiar estado de cotizacion
                                if (txt_buscar.Text.Length > 6)
                                {
                                    RN_Cotizacion n_coti = new RN_Cotizacion();
                                    n_coti.RN_Cambiar_Estado_Cotizacion(txt_NroCotiza.Text, "Atendido");
                                }

                                //InicioTicket 
                                fil.Show();
                                cpb_ticket.RutaPPF = "";
                                ter.lbl_rutaPDF.Text = "";

                                //formato.ShowDialog();

                                if (formato.Tag.ToString() == "A")
                                {
                                    if (formato.rbt_for_ticket.Checked)
                                    {
                                        cpb_ticket.lbl_nroDoc.Text = cbb_tipoDocumento.Text + " - " + txt_NroDocumento.Text;
                                        cpb_ticket.Tag = txt_NroDocumento.Text;
                                        cpb_ticket.RutaPPF = rutaPDF_Export_Ventas + v_rucEmisor.Trim() + "-" + tipoDocumentoSunat.Trim() + "-" + txt_NroDocumento.Text.Trim() + ".pdf";
                                        //rutaPDF_Export_Ventas = rutaPDF_Export_Ventas + v_rucEmisor.Trim() + "-" + tipoDocumentoSunat + "-" + txt_NroDocumento.Text + ".pdf";
                                        cpb_ticket.ShowDialog();
                                        fil.Hide();
                                        //fin ticket

                                        fil.Show();
                                        ter.lbl_Documento.Text = txt_NroDocumento.Text;
                                        //.lbl_rutaPDF.Text = rutaPDF_Export_Ventas;
                                        ter.lbl_rutaPDF.Text = cpb_ticket.RutaPPF;

                                        ter.lbl_rutaXML.Text = obj.RutaCompleta_XML;
                                        ter.ShowDialog();
                                        fil.Hide();
                                    }
                                    else if (formato.rbt_for_A5.Checked)
                                    {
                                        cpb_A5.lbl_nroDoc.Text = cbb_tipoDocumento.Text + " - " + txt_NroDocumento.Text;
                                        cpb_A5.Tag = txt_NroDocumento.Text;
                                        cpb_A5.RutaPPF = rutaPDF_Export_Ventas + v_rucEmisor.Trim() + "-" + tipoDocumentoSunat.Trim() + "-" + txt_NroDocumento.Text.Trim() + ".pdf";
                                        cpb_A5.ShowDialog();
                                        fil.Hide();
                                        //fin ticket

                                        fil.Show();
                                        ter.lbl_Documento.Text = txt_NroDocumento.Text;
                                        //.lbl_rutaPDF.Text = rutaPDF_Export_Ventas;
                                        ter.lbl_rutaPDF.Text = cpb_A5.RutaPPF;

                                        ter.lbl_rutaXML.Text = obj.RutaCompleta_XML;
                                        ter.ShowDialog();
                                        fil.Hide();
                                    }
                                    else if (formato.rbt_for_A4.Checked)
                                    {
                                        cpb_A4.lbl_nroDoc.Text = cbb_tipoDocumento.Text + " - " + txt_NroDocumento.Text;
                                        cpb_A4.Tag = txt_NroDocumento.Text;
                                        cpb_A4.RutaPPF = rutaPDF_Export_Ventas + v_rucEmisor.Trim() + "-" + tipoDocumentoSunat.Trim() + "-" + txt_NroDocumento.Text.Trim() + ".pdf";
                                        cpb_A4.ShowDialog();
                                        fil.Hide();
                                        //fin ticket

                                        fil.Show();
                                        ter.lbl_Documento.Text = txt_NroDocumento.Text;
                                        //.lbl_rutaPDF.Text = rutaPDF_Export_Ventas;
                                        ter.lbl_rutaPDF.Text = cpb_A4.RutaPPF;

                                        ter.lbl_rutaXML.Text = obj.RutaCompleta_XML;
                                        ter.ShowDialog();
                                        fil.Hide();
                                    }
                                }
                                /*
                                nv_ticket.lbl_nroDoc.Text = cbb_tipoDocumento.Text + " - " + txt_NroDocumento.Text;
                                nv_ticket.Tag = txt_NroDocumento.Text;
                                nv_ticket.RutaPPF = rutaPDF_Export_Ventas + v_rucEmisor.Trim() + "-" + tipoDocumentoSunat + "-" + txt_NroDocumento.Text + ".pdf";
                                //rutaPDF_Export_Ventas = rutaPDF_Export_Ventas + v_rucEmisor.Trim() + "-" + tipoDocumentoSunat + "-" + txt_NroDocumento.Text + ".pdf";
                                nv_ticket.ShowDialog();
                                */
                                /*fil.Hide();
                                //fin ticket

                                fil.Show();
                                ter.lbl_Documento.Text = txt_NroDocumento.Text;
                                //.lbl_rutaPDF.Text = rutaPDF_Export_Ventas;
                                ter.lbl_rutaPDF.Text = cpb_ticket.RutaPPF;

                                ter.lbl_rutaXML.Text = obj.RutaCompleta_XML;
                                ter.ShowDialog();
                                fil.Hide();
                                */

                                LimpiarTodo();
                            }
                        }

                        if (cbb_tipoDocumento.Text == "Nota Venta")
                        {
                            if (formato.rbt_for_A4.Checked)
                            {
                                RegistrarArchivosTemporales("A4");
                            }
                            else
                            {
                                RegistrarArchivosTemporales("A5 y ticket");
                            }

                            //cambiar estado de cotizacion
                            if (txt_buscar.Text.Length > 6)
                            {
                                RN_Cotizacion n_coti = new RN_Cotizacion();
                                n_coti.RN_Cambiar_Estado_Cotizacion(txt_NroCotiza.Text, "Atendido");
                            }

                            //InicioTicket
                            fil.Show();
                            //nv_ticket.lbl_nroDoc.Text = cbb_tipoDocumento.Text + " - " + txt_NroDocumento.Text;
                            //nv_ticket.Tag = txt_NroDocumento.Text;
                            //nv_ticket.ShowDialog();

                            //formato.ShowDialog();

                            if (formato.Tag.ToString() == "A")
                            {
                                if (formato.rbt_for_ticket.Checked)
                                {
                                    cpb_ticket.lbl_nroDoc.Text = cbb_tipoDocumento.Text + " - " + txt_NroDocumento.Text;
                                    cpb_ticket.Tag = txt_NroDocumento.Text;
                                    cpb_ticket.RutaPPF = rutaPDF_Export_Ventas + v_rucEmisor.Trim() + "-" + tipoDocumentoSunat.Trim() + "-" + txt_NroDocumento.Text.Trim() + ".pdf";
                                    //rutaPDF_Export_Ventas = rutaPDF_Export_Ventas + v_rucEmisor.Trim() + "-" + tipoDocumentoSunat + "-" + txt_NroDocumento.Text + ".pdf";
                                    cpb_ticket.ShowDialog();
                                }
                                else if (formato.rbt_for_A5.Checked)
                                {
                                    cpb_A5.lbl_nroDoc.Text = cbb_tipoDocumento.Text + " - " + txt_NroDocumento.Text;
                                    cpb_A5.Tag = txt_NroDocumento.Text;
                                    cpb_A5.RutaPPF = rutaPDF_Export_Ventas + v_rucEmisor.Trim() + "-" + tipoDocumentoSunat.Trim() + "-" + txt_NroDocumento.Text.Trim() + ".pdf";
                                    cpb_A5.ShowDialog();
                                }
                                else if (formato.rbt_for_A4.Checked)
                                {
                                    cpb_A4.lbl_nroDoc.Text = cbb_tipoDocumento.Text + " - " + txt_NroDocumento.Text;
                                    cpb_A4.Tag = txt_NroDocumento.Text;
                                    cpb_A4.RutaPPF = rutaPDF_Export_Ventas + v_rucEmisor.Trim() + "-" + tipoDocumentoSunat.Trim() + "-" + txt_NroDocumento.Text.Trim() + ".pdf";
                                    cpb_A4.ShowDialog();
                                }
                            }

                            //fin ticket
                            header = 0;
                            det = 0;
                            fil.Hide();
                            LimpiarTodo();
                        }


                        //Mandar  Imprimir A5
                        // descomentar si se va imprimir PreImpreso y comentar la del ticket
                        /*
                        nv.lbl_nroDoc.Text = cbb_tipoDocumento.Text + " - " + txt_NroDocumento.Text;
                        nv.Tag = txt_NroDocumento.Text;
                        nv.ShowDialog();
                        */
                        //fin Pre impreso
                    }

                }
            }
        }
        void EnviarDocumento_Sunat()
        {
            try
            {
                Frm_TipoPago_Credito tipo = new Frm_TipoPago_Credito();
                objCPE.TIPO_OPERACION = "0101";//Venta Interna 0102:Exportacion
                objCPE.TOTAL_GRAVADAS = Convert.ToDecimal(lbl_subtotal.Text);
                objCPE.SUB_TOTAL = Convert.ToDecimal(lbl_subtotal.Text);
                objCPE.POR_IGV = 18;
                objCPE.TOTAL_IGV = Convert.ToDecimal(lbl_igv.Text);
                objCPE.TOTAL_ISC = 0;//Impuesto selectivo al consumidor
                objCPE.TOTAL_OTR_IMP = 0;
                objCPE.TOTAL_DESCUENTOGLO = 0;
                objCPE.TOTAL = Convert.ToDecimal(lbl_TotalPagar.Text);

                /*NUEVO 15/11/2021*/
                if (cbb_tipoPago.Text=="Credito")
                {
                    objCPE.FORMA_PAGO = "Credito";
                    objCPE.MONTO_DEUDA = Convert.ToDecimal(lbl_saldoCredito.Text);
                    objCPE.FECHA_VEC_CREDITO = dtp_VenciCredito.Value.ToString("yyyy-MM-dd");
                }
                else
                {
                    objCPE.FORMA_PAGO = "Contado";
                }
                
                /*FIN 15/11/2021*/

                objCPE.TOTAL_EXPORTACION = 0;
                objCPE.TOTAL_LETRAS = lbl_son.Text;
                objCPE.NRO_GUIA_REMISION = "";
                objCPE.FECHA_GUIA_REMISION = "";
                objCPE.COD_GUIA_REMISION = "";
                objCPE.NRO_OTR_COMPROBANTE = "";
                objCPE.COD_OTR_COMPROBANTE = "";
                objCPE.TOTAL_OTR_IMP = 0;
                objCPE.NRO_COMPROBANTE = txt_NroDocumento.Text.Trim(); // txt_NroDocumento.Text.Trim();//FE001-00001
                objCPE.FECHA_DOCUMENTO = dtp_FechaEmi.Value.ToString("yyyy-MM-dd");
                objCPE.FECHA_VTO = dtp_FechaEmi.Value.ToString("yyyy-MM-dd");
                objCPE.COD_TIPO_DOCUMENTO = tipoDocumentoSunat;//01:Factura - 03:Boleta
                objCPE.COD_MONEDA = "PEN";
                objCPE.TIPO_COMPROBANTE_MODIFICA = "";
                objCPE.COD_TIPO_MOTIVO = "";
                objCPE.DESCRIPCION_MOTIVO = "";
                //datos Cliente
                objCPE.NRO_DOCUMENTO_CLIENTE = lbl_Dni.Text.Trim();
                objCPE.RAZON_SOCIAL_CLIENTE = txt_cliente.Text;
                objCPE.TIPO_DOCUMENTO_CLIENTE = tipoDocumentoCliente.Trim(); //1:DNI 6:RUC
                objCPE.DIRECCION_CLIENTE = lbl_direccion.Text;
                //ubigeo
                objCPE.CIUDAD_CLIENTE = "LIMA";
                objCPE.COD_PAIS_CLIENTE = "PE";
                objCPE.COD_UBIGEO_CLIENTE = "";
                objCPE.DEPARTAMENTO_CLIENTE = "";
                objCPE.PROVINCIA_CLIENTE = "";
                objCPE.DISTRITO_CLIENTE = "";
                //Datos de la empresa
                objCPE.NRO_DOCUMENTO_EMPRESA = v_rucEmisor.Trim();
                objCPE.TIPO_DOCUMENTO_EMPRESA = "6";
                objCPE.NOMBRE_COMERCIAL_EMPRESA = v_empresaEmisor.Trim();
                objCPE.CODIGO_UBIGEO_EMPRESA = "150101";
                objCPE.DIRECCION_EMPRESA = v_direccionEmpresa.Trim();
                objCPE.DEPARTAMENTO_EMPRESA = "LIMA";
                objCPE.PROVINCIA_EMPRESA = "LIMA";
                objCPE.DISTRITO_EMPRESA = "LIMA";
                objCPE.CODIGO_PAIS_EMPRESA = "PE";
                objCPE.RAZON_SOCIAL_EMPRESA = v_empresaEmisor.Trim();
                objCPE.CONTACTO_EMPRESA = ""; //responsable de la empresa
                objCPE.USUARIO_SOL_EMPRESA = v_usuarioSol.Trim();
                objCPE.PASS_SOL_EMPRESA = v_claveSol.Trim();
                objCPE.CONTRA_FIRMA = v_certificadoClave.Trim();
                objCPE.TIPO_PROCESO = Convert.ToInt32(tipoServidor);//3:servidor prueba

                //Detalle de FE//
                List<businessEntities.CPE_DETALLE> objCPEdetalle_list = new List<BE.CPE_DETALLE>();
                //List<BE.CPE_DETALLE> objCPEdetalle = new List<BE.CPE_DETALLE>();

                for (int i = 0; i < lsv_Det.Items.Count; i++)
                {
                    objCPE_DETALLE = new BE.CPE_DETALLE();
                    objCPE_DETALLE.ITEM = i + 1;
                    objCPE_DETALLE.UNIDAD_MEDIDA = lsv_Det.Items[i].SubItems[6].Text; //bien o servicio 13
                    objCPE_DETALLE.CANTIDAD = Convert.ToDecimal(lsv_Det.Items[i].SubItems[2].Text);
                    objCPE_DETALLE.PRECIO = Convert.ToDecimal(lsv_Det.Items[i].SubItems[10].Text);//Sin IGV
                    objCPE_DETALLE.PRECIO_CONIGV = Convert.ToDecimal(lsv_Det.Items[i].SubItems[3].Text);
                    objCPE_DETALLE.IMPORTE = Convert.ToDecimal(lsv_Det.Items[i].SubItems[11].Text);//Sin IGV
                    objCPE_DETALLE.IMPORTE_CONIGV = Convert.ToDecimal(lsv_Det.Items[i].SubItems[4].Text);
                    objCPE_DETALLE.PRECIO_TIPO_CODIGO = "01";//todos los producto incluyen igv 02: Valor referencial unitario en operacioines no onerosas - exonerado del igv
                    objCPE_DETALLE.IGV = Convert.ToDecimal(lsv_Det.Items[i].SubItems[12].Text);
                    objCPE_DETALLE.ISC = 0;//no aplica
                    objCPE_DETALLE.COD_TIPO_OPERACION = "10"; //10:Gravado 20:Exonerado
                    objCPE_DETALLE.CODIGO = lsv_Det.Items[i].SubItems[0].Text;//codigo del producto
                    objCPE_DETALLE.DESCRIPCION = lsv_Det.Items[i].SubItems[1].Text;
                    objCPE_DETALLE.SUB_TOTAL = Convert.ToDecimal(lsv_Det.Items[i].SubItems[11].Text);
                    objCPE_DETALLE.PRECIO_SIN_IMPUESTO = Convert.ToDecimal(lsv_Det.Items[i].SubItems[10].Text);

                    objCPEdetalle_list.Add(objCPE_DETALLE);
                }
                objCPE.detalle = objCPEdetalle_list;
                //Obtener respuesta//
                Dictionary<string, string> dicionaryEnvio = new Dictionary<string, string>();
                dicionaryEnvio = obj.Enviar_Boleta_Factura_Sunat(objCPE);

                //Respuesta Sunat
                rpt_codSunat = dicionaryEnvio["cod_sunat"];
                rpt_msjSunat = dicionaryEnvio["msj_sunat"];
                rpt_hashCPE = dicionaryEnvio["hash_cpe"];
                rpt_hashCDR = dicionaryEnvio["hash_cdr"];
                //Frm_Msm_Respuesta rpt_S = new Frm_Msm_Respuesta();
                //fil.Show();
                //rpt_S.txt_CodSunat.Text = rpt_codSunat;
                //rpt_S.txt_msj_Sunat.Text = rpt_msjSunat;
                //rpt_S.txt_hashCPE.Text = rpt_hashCPE;
                //rpt_S.txt_hashCDR.Text = rpt_hashCDR;
                //rpt_S.ShowDialog();
                //fil.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Creando Variable Para el XML: " + "\r\n" + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        void Crear_Registro_Credito()
        {
            RN_Credito n_cred = new RN_Credito();
            EN_Credito e_cred = new EN_Credito();
            EN_Det_Credito e_dCre = new EN_Det_Credito();

            EN_Caja e_caja = new EN_Caja();
            EN_Caja e_caja2 = new EN_Caja();
            RN_Caja n_caja = new RN_Caja();
            RN_Caja n_caja2 = new RN_Caja();

            string idCredito;
            int rpt;
            try
            {
                idCredito = RN_TipoDoc.Sp_Listado_Tipo(12);

                e_cred.Idnotacredito = idCredito;
                e_cred.IdDoc = txt_NroDocumento.Text;
                e_cred.Fecha_Credito = dtp_FechaEmi.Value;
                e_cred.Nomcliente = txt_cliente.Text;
                e_cred.Total_ped = Convert.ToDouble(lbl_TotalPagar.Text);

                if (Convert.ToDouble(lbl_Acuenta.Text) == 0)
                {
                    e_cred.Saldo_Pdnte = Convert.ToDouble(lbl_TotalPagar.Text);
                }
                else if (Convert.ToDouble(lbl_Acuenta.Text) > 0)
                {
                    e_cred.Saldo_Pdnte = Convert.ToDouble(lbl_saldoCredito.Text);
                }
                e_cred.Fecha_vncmnto = dtp_VenciCredito.Value;
                rpt = n_cred.RN_Ingresar_Credito_Header(e_cred);

                if (rpt == 1)
                {
                    RN_TipoDoc.RN_Actualizar_SiguienteNro_correlativo(12);

                    if (Convert.ToDouble(lbl_Acuenta.Text) > 0)
                    {
                        Crear_Registro_Credito_Detealle(idCredito);
                        // se crea un movimiento de caja
                        //MOV DE ABONO
                        e_caja.Fecha_Caja = dtp_FechaEmi.Value;
                        e_caja.Tipo_Caja = "Entrada";
                        e_caja.Concepto = "Abono de Credito";
                        e_caja.De_Para = txt_cliente.Text;
                        e_caja.ImporteCaja = Convert.ToDouble(lbl_Acuenta.Text);
                        e_caja.Id_Usu = Cls_UsuLogin.IdUsu;
                        e_caja.TotalUti = 0;
                        e_caja.TipoPago = lbl_tipopagoCred.Text;
                        e_caja.GeneradoPor = "Abono";
                        e_caja.Nro_Doc = txt_NroDocumento.Text;
                        int H = n_caja.RN_Ingresar_Caja(e_caja);

                        //MOV DE LA VENTA A CREDITO
                        e_caja2.Fecha_Caja = dtp_FechaEmi.Value;
                        e_caja2.Tipo_Caja = "Entrada";
                        e_caja2.Concepto = "Por Venta al Publico - Credito";
                        e_caja2.De_Para = txt_cliente.Text;
                        e_caja2.ImporteCaja = Convert.ToDouble(lbl_TotalPagar.Text) - Convert.ToDouble(lbl_Acuenta.Text);
                        e_caja2.Id_Usu = Cls_UsuLogin.IdUsu;
                        e_caja2.TotalUti = Convert.ToDouble(lbl_totalGanancia.Text);
                        e_caja2.TipoPago = lbl_tipopagoCred.Text;
                        e_caja2.GeneradoPor = cbb_tipoDocumento.Text;
                        e_caja2.Nro_Doc = lbl_Dni.Text.Trim();
                        int D = n_caja2.RN_Ingresar_Caja(e_caja2);

                    }
                    else
                    {
                        //MOV DE LA VENTA A CREDITO
                        e_caja2.Fecha_Caja = dtp_FechaEmi.Value;
                        e_caja2.Tipo_Caja = "Entrada";
                        e_caja2.Concepto = "Por Venta al Publico";
                        e_caja2.De_Para = txt_cliente.Text;
                        e_caja2.ImporteCaja = Convert.ToDouble(lbl_TotalPagar.Text);
                        e_caja2.Id_Usu = Cls_UsuLogin.IdUsu;
                        e_caja2.TotalUti = Convert.ToDouble(lbl_totalGanancia.Text);
                        e_caja2.TipoPago = "Efectivo";//por defecto cuando se cancela el pago a credito
                        e_caja2.GeneradoPor = cbb_tipoDocumento.Text;
                        e_caja2.Nro_Doc = lbl_Dni.Text.Trim();
                        int D = n_caja2.RN_Ingresar_Caja(e_caja2);
                        MessageBox.Show("La venta se guardo por defecto a efectivo.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

            }
            catch (Exception)
            {

                throw;
            }
        }
        void Crear_Registro_Credito_Detealle(string idCredito)
        {
            EN_Det_Credito e_dCre = new EN_Det_Credito();
            RN_Credito n_Cred = new RN_Credito();
            try
            {
                e_dCre.Idnotacredito = idCredito;
                e_dCre.Acuenta = Convert.ToDouble(lbl_Acuenta.Text);
                e_dCre.Saldoactual = Convert.ToDouble(lbl_saldoCredito.Text);
                e_dCre.Fecha_Pago = dtp_VenciCredito.Value;
                e_dCre.TipoPago = lbl_tipopagoCred.Text;
                e_dCre.NroOpera = "Primer Abono";
                e_dCre.IdUsu = Cls_UsuLogin.IdUsu;

                n_Cred.RN_Ingresar_Credito_Det(e_dCre);
            }
            catch (Exception)
            {

                throw;
            }
        }
        private void Guardar_Ingreso_Caja()
        {
            EN_Caja e_caja = new EN_Caja();
            RN_Caja n_caja = new RN_Caja();
            int rpt;
            try
            {
                e_caja.Fecha_Caja = dtp_FechaEmi.Value;
                e_caja.Tipo_Caja = "Entrada";
                e_caja.Concepto = "Por Venta al Publico";
                e_caja.De_Para = txt_cliente.Text;
                e_caja.ImporteCaja = Convert.ToDouble(lbl_TotalPagar.Text);
                e_caja.Id_Usu = Cls_UsuLogin.IdUsu;
                e_caja.TotalUti = Convert.ToDouble(lbl_totalGanancia.Text);
                e_caja.TipoPago = cbb_tipoPago.Text;
                e_caja.GeneradoPor = cbb_tipoDocumento.Text;
                e_caja.Nro_Doc = txt_NroDocumento.Text;
                rpt = n_caja.RN_Ingresar_Caja(e_caja);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al Guardar: " + ex.Message, "Form Add Caja", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void Guardar_Ingreso_Caja_NC()
        {
            EN_Caja e_caja = new EN_Caja();
            RN_Caja n_caja = new RN_Caja();
            int rpt;
            try
            {
                e_caja.Fecha_Caja = dtp_FechaEmi.Value;
                e_caja.Tipo_Caja = "Entrada";
                e_caja.Concepto = "Por Venta al Publico con: " + lbl_idNC.Text;
                e_caja.De_Para = txt_cliente.Text;
                e_caja.ImporteCaja = Convert.ToDouble(lbl_saldoPendiente.Text);
                e_caja.Id_Usu = Cls_UsuLogin.IdUsu;
                e_caja.TotalUti = Convert.ToDouble(lbl_totalGanancia.Text);
                e_caja.TipoPago = cbb_tipoPago.Text; //Pendiente
                e_caja.GeneradoPor = cbb_tipoDocumento.Text;
                e_caja.Nro_Doc = txt_NroDocumento.Text;
                rpt = n_caja.RN_Ingresar_Caja(e_caja);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al Guardar: " + ex.Message, "Form Add Caja", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        void RegistrarMovimientoKardex()//investigar los tipos de kardex
        {
            RN_Kardex n_kar = new RN_Kardex();
            EN_Kardex e_kar = new EN_Kardex();
            RN_Producto n_prod = new RN_Producto();
            DataTable dt = new DataTable();
            DataTable dt2 = new DataTable();
            string xidkardex;
            int xitem;
            double stockProd;
            double PrecioCompraProd;

            string xxidpro;
            double xcant;
            string xxtipoproducto;
            try
            {
                for (int i = 0; i < lsv_Det.Items.Count; i++)
                {
                    var lis = lsv_Det.Items[i];
                    xxidpro = lis.SubItems[0].Text;
                    xcant = Convert.ToDouble(lis.SubItems[2].Text);
                    xxtipoproducto = lis.SubItems[5].Text;

                    if (n_kar.RN_Sp_Ver_sihay_Kardex(xxidpro) == true)
                    {
                        dt = n_kar.RN_BuscarKardexDetalleProducto(xxidpro.Trim());
                        if (dt.Rows.Count > 0)
                        {
                            xidkardex = dt.Rows[0]["Id_krdx"].ToString();
                            xitem = dt.Rows.Count;
                            dt2 = n_prod.RN_Buscar_Producto(xxidpro.Trim());
                            stockProd = Convert.ToDouble(dt2.Rows[0]["Stock_Actual"]);
                            PrecioCompraProd = Convert.ToDouble(dt2.Rows[0]["Pre_CompraS"]);

                            //Registrar Detalle Kardex
                            e_kar.Id_Krdx = xidkardex;
                            e_kar.Item = xitem + 1;
                            e_kar.Doc_Soport = txt_NroDocumento.Text;
                            e_kar.Det_Operacion = "Por Venta al Publico";
                            //Entrada
                            e_kar.Cantidad_In = 0;
                            e_kar.Precio_Unt_In = 0;
                            e_kar.Costo_Total_In = 0;
                            //Salida
                            e_kar.Cantidad_Out = xcant;
                            e_kar.Precio_Unt_Out = PrecioCompraProd;
                            e_kar.Importe_Total_Out = xcant * PrecioCompraProd;
                            //saldos
                            e_kar.Cantidad_Saldo = stockProd - xcant;
                            e_kar.Promedio = PrecioCompraProd;
                            e_kar.Costo_Total_Saldo = PrecioCompraProd * (stockProd + xcant);
                            n_kar.RN_Registrar_det_Kardex(e_kar);

                            //Actualizar Stock Productos
                            n_prod.RN_RestarStock_Producto(xxidpro, xcant);
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        bool Validar_compra()
        {
            Utilitarios.Frm_Advertencia adv = new Utilitarios.Frm_Advertencia();
            if (cbb_tipoDocumento.SelectedIndex == -1) { fil.Show(); adv.lbl_msm.Text = "Selecciona un tipo de documento"; adv.ShowDialog(); fil.Hide(); cbb_tipoDocumento.Focus(); return false; }
            if (txt_cliente.Text.Trim().Length <= 0) { fil.Show(); adv.lbl_msm.Text = "Seleccione un Cliente."; adv.ShowDialog(); fil.Hide(); txt_cliente.Focus(); return false; }
            if (cbb_tipoPago.SelectedIndex == -1) { fil.Show(); adv.lbl_msm.Text = "Selecciona un tipo de pago."; adv.ShowDialog(); fil.Hide(); cbb_tipoPago.Focus(); return false; }
            if (lsv_Det.Items.Count == 0) { fil.Show(); adv.lbl_msm.Text = "Debes agregar un producto al carrito."; adv.ShowDialog(); fil.Hide(); return false; }

            
            

            if (tipoServidor == "1" || tipoServidor == "3")
            {
                if (cbb_tipoDocumento.SelectedIndex == 0 || cbb_tipoDocumento.Text == "Nota Venta")
                {
                    MessageBox.Show("El Documento NOTA DE VENTA no es considerado para la Sunat, favor de elegir el servidor Local. si NO va emitir una Boleta o Factura.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
            }

            if (Convert.ToInt32(lbl_Dni.Text.Length) == 8 && cbb_tipoDocumento.Text == "Boleta")
            {

            }
            else if (Convert.ToInt32(lbl_Dni.Text.Length) == 11 && cbb_tipoDocumento.Text == "Factura")
            {

            }
            else if (tipoServidor == "2" || cbb_tipoDocumento.SelectedIndex == 0 || cbb_tipoDocumento.Text == "Nota Venta")
            {
                if (Convert.ToInt32(lbl_Dni.Text.Length) == 11)
                {
                    MessageBox.Show("El Documento " + lbl_Dni.Text + " no es valido para la " + cbb_tipoDocumento.Text + " Verificar el numero de documento del cliente corresponda al tipo de Documento a emitir", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }
            else
            {
                fil.Show();
                MessageBox.Show("El Documento " + lbl_Dni.Text + " no es valido para la " + cbb_tipoDocumento.Text + " Verificar el numero de documento del cliente corresponda al tipo de Documento a emitir", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                fil.Hide();
                return false;
            }


            return true;
        }
        void LimpiarTodo()
        {
            lsv_Det.Items.Clear();
            txt_cliente.Text = "";
            lbl_idcliente.Text = "";
            lbl_totalGanancia.Text = "00.00";
            lbl_subtotal.Text = "00.00";
            lbl_igv.Text = "00.00";
            lbl_limitCredito.Text = "00.00";
            lbl_Dni.Text = "";
            cbb_tipoPago.SelectedIndex = -1;
            cbb_tipoDocumento.SelectedIndex = -1;
            lbl_saldoPendiente.Text = "00.00";
            lbl_pagaCon.Text = "00.00";
            pnl_sinProd.Visible = true;
            txt_buscar.Enabled = true;
            txt_buscar.Text = "";
            lbl_BusCotiza.Enabled = true;
            lbl_TotalPagar.Text = "00.00";
            lbl_StockX.Text = "";
            lbl_prodX.Text = "";

            monto100 = 100;

            monto20 = 20;

            monto50 = 50;
            MontoTotal = 0;

            txt_Cantidad.Text = "00.00";

        }
        void Guardar_Cotizacion()
        {
            RN_Cotizacion n_coti = new RN_Cotizacion();
            EN_Cotizacion e_coti = new EN_Cotizacion();
            Frm_Msm_Bueno msm = new Frm_Msm_Bueno();
            Informe.Frm_PrintCoti printCoti = new Informe.Frm_PrintCoti();

            try
            {
                //primero se guarda el pedido
                Guardar_Pedido();
                if (header == 1 && det == 1)
                {
                    txt_NroDocumento.Text = RN_TipoDoc.Sp_Listado_Tipo(11);
                    e_coti.Id_Cotiza = txt_NroDocumento.Text;
                    e_coti.Id_Ped = txt_nroPed.Text;
                    e_coti.FechaCoti = dtp_FechaEmi.Value;
                    e_coti.Vigencia = 15;
                    e_coti.Condiciones = "Cotizacion creada a partir de una venta pausada.";
                    e_coti.TotalCotiza = Convert.ToDouble(lbl_TotalPagar.Text);
                    e_coti.PrecioconIgv = "SI";
                    e_coti.EstadoCoti = "Pendiente";
                    if (n_coti.RN_Registrar_Cotizacion(e_coti) == 1)
                    {
                        RN_TipoDoc.RN_Actualizar_SiguienteNro_correlativo(11);
                        fil.Show();
                        msm.Lbl_msm1.Text = "La Cotizacion Nro: " + txt_NroDocumento.Text + " se guardo con exito, mientras una venta se encuentra pendiente por un cliente.";
                        msm.ShowDialog();
                        fil.Hide();
                        txt_buscar.Text = txt_NroCotiza.Text;
                        //Imprimir Cotizacion
                        fil.Show();
                        printCoti.Tag = txt_NroDocumento.Text;
                        printCoti.ShowDialog();
                        fil.Hide();

                        pnl_sinProd.Visible = true;
                        lsv_Det.Items.Clear();
                        txt_cliente.Text = "";
                        txt_NroDocumento.Text = "";
                        txt_nroPed.Text = "";

                    }
                    header = 0;
                    det = 0;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        private void btn_atenderOtro_Click(object sender, EventArgs e)
        {
            Guardar_Cotizacion();
        }
        string rutaPDF_Export_Ventas = "C:\\Sln_MicrosellLite\\CPE_2\\BETA\\";
        void RegistrarArchivosTemporales(string formatoimp)
        {
            RN_Temporal n_tem = new RN_Temporal();
            EN_Temporal e_tem = new EN_Temporal();
            int rpt;

            string dia = dtp_FechaEmi.Value.Day.ToString();
            string mes = dtp_FechaEmi.Value.Month.ToString();
            string año = dtp_FechaEmi.Value.Year.ToString();

            string rutaQR = "C:\\Sln_MicrosellLite\\CPE\\QR_TEMP\\" + txt_NroDocumento.Text + ".BMP";
            GenerarCodigoQR(cbb_tipoDocumento.Text, lbl_TotalPagar.Text, txt_cliente.Text, txt_NroDocumento.Text, rutaQR);

            objCPE.FECHA_VEC_CREDITO = dtp_VenciCredito.Value.ToString("yyyy-MM-dd");

            if (cbb_tipoPago.Text=="Credito")
            {
                e_tem.Forma_pago = "Credito";
                e_tem.Monto_deuda = lbl_saldoCredito.Text;
                e_tem.Fecha_venc_credito = dtp_VenciCredito.Value.ToString("yyyy-MM-dd");
            }
            else
            {
                e_tem.Forma_pago = "Contado";
                e_tem.Monto_deuda = "0.00";
                e_tem.Fecha_venc_credito = DateTime.Now.ToString("yyyy-MM-dd");
            }
            

            e_tem.CodTem = txt_NroDocumento.Text.Trim();
            e_tem.FechaEmi = dtp_FechaEmi.Value.ToString();
            e_tem.Cliente = txt_cliente.Text.Trim();
            e_tem.Ruc = lbl_Dni.Text.Trim();
            e_tem.Direccion = lbl_direccion.Text.Trim();
            e_tem.SubTtal = lbl_subtotal.Text.Trim();
            e_tem.IgvT = lbl_igv.Text.Trim();
            e_tem.TotalT = lbl_TotalPagar.Text.Trim();
            e_tem.SonT = lbl_son.Text.Trim();
            e_tem.Vendedor = Cls_UsuLogin.IdUsu.ToString();
            e_tem.CodigoQR = Convertir_ImagenByte(pb_QR.Image);


            //pendiente ingreso sin enviar a la sunat
            if (cbb_tipoDocumento.Text.Trim() == "Factura")
            {
                e_tem.TipoComprobante = "FACTURA ELECTRONICA";

                if (rpt_hashCPE == null)
                {
                    e_tem.Hash_cpe = "-";
                }
                else
                {
                    e_tem.Hash_cpe = rpt_hashCPE;
                }
            }
            else if (cbb_tipoDocumento.Text.Trim() == "Boleta")
            {
                e_tem.TipoComprobante = "BOLETA ELECTRONICA";

                if (rpt_hashCPE == null)
                {
                    e_tem.Hash_cpe = "-";
                }
                else
                {
                    e_tem.Hash_cpe = rpt_hashCPE;
                }
            }
            else
            {
                e_tem.TipoComprobante = "NOTA VENTA";
                e_tem.Hash_cpe = "Sin Resuesta Sunat.";
            }

            e_tem.MotivoEmis = "-";
            e_tem.TipoPago = cbb_tipoPago.Text.Trim();

            rpt = n_tem.RN_Ingresar_Temporal_Header(e_tem);
            if (rpt == 1)
            {
                string codTem;
                string CodProd;
                string Cantidad;
                string Producto;
                string PreUnt;
                string Importe;
                string UnidMedida;
                codTem = txt_NroDocumento.Text.Trim();
                for (int i = 0; i < lsv_Det.Items.Count; i++)
                {
                    var lis = lsv_Det.Items[i];

                    CodProd = lis.SubItems[0].Text.Trim();
                    Cantidad = lis.SubItems[2].Text.Trim();
                    Producto = lis.SubItems[1].Text.Trim();
                    PreUnt = lis.SubItems[3].Text.Trim();
                    Importe = lis.SubItems[4].Text.Trim();
                    UnidMedida = lis.SubItems[13].Text.Trim();
                    n_tem.BD_Ingresar_Temporal_Det(codTem, CodProd, Cantidad, Producto, PreUnt, Importe, UnidMedida);
                }

                //descomentar si se va imprimir en un documento pre impreso
                // agregar espacios vacios
                if (formatoimp == "A4")
                {
                    int totalEspacioVacio;
                    int totalFila = lsv_Det.Items.Count;
                    totalEspacioVacio = 27 - totalFila;

                    if (totalEspacioVacio < 27)
                    {
                        for (int i = 0; i <= totalEspacioVacio; i++)
                        {

                            CodProd = "";
                            Cantidad = "";
                            Producto = "";
                            PreUnt = "";
                            Importe = "";
                            UnidMedida = "";
                            n_tem.BD_Ingresar_Temporal_Det(codTem, CodProd, Cantidad, Producto, PreUnt, Importe, UnidMedida);
                        }
                    }
                }
                //FIN
            }
        }
        void Buscar_Cotizacion_Atender(string nroCot)
        {
            RN_Cotizacion n_coti = new RN_Cotizacion();
            DataTable dt = new DataTable();
            DataTable dt2 = new DataTable();
            RN_Producto n_prod = new RN_Producto();
            Utilitarios.Frm_Advertencia adv = new Utilitarios.Frm_Advertencia();

            try
            {
                dt = n_coti.RN_Buscar_Cotizacion_Para_Editar(nroCot.Trim());
                if (dt.Rows.Count > 0)
                {
                    var dato = dt.Rows[0];
                    txt_estCoti.Text = dato["EstadoCoti"].ToString();
                    if (txt_estCoti.Text == "Atendido")
                    {
                        fil.Show();
                        adv.lbl_msm.Text = "Esta Cotizacion ya fue atendida, por favor, cargue que se encuentre pendiente.";
                        adv.ShowDialog();
                        fil.Hide();
                        txt_estCoti.Text = "";
                        pnl_sinProd.Visible = true;
                        txt_buscar.Text = "";
                        lsv_Det.Items.Clear();
                        return;
                    }
                    txt_nroPed.Text = dato["id_Ped"].ToString();
                    txt_NroCotiza.Text = dato["Id_Cotiza"].ToString();
                    dtp_FechaEmi.Value = Convert.ToDateTime(dato["FechaCoti"].ToString());
                    lbl_idcliente.Text = dato["Id_Cliente"].ToString();
                    txt_cliente.Text = dato["Razon_Social_Nombres"].ToString();
                    lbl_direccion.Text = dato["Direccion"].ToString();
                    lbl_Dni.Text = dato["DNI"].ToString().Trim();
                    Leer_Datos_DelCliente(lbl_Dni.Text);

                    foreach (DataRow xitem in dt.Rows)
                    {
                        ListViewItem xlist;
                        string idprod = xitem["Id_Pro"].ToString();
                        string _uni_medida;
                        string _uni_medida_desc;
                        double xcant = Convert.ToDouble(xitem["Stock_Actual"].ToString());

                        _uni_medida = xitem["Und_Medida"].ToString();
                        dt2 = n_prod.RN_Buscar_UniMedia(_uni_medida);
                        DataRow dr = dt2.Rows[0];
                        _uni_medida_desc = dr["descripcion"].ToString();

                        Buscar_Producto_Cotizacion(idprod.Trim());

                        if (xcant > Convert.ToDouble(lbl_StockX.Text) && lbl_prodX.Text.Trim() == "Producto")
                        {
                            if (Convert.ToDouble(lbl_StockX.Text) > 0 && Convert.ToDouble(lbl_StockX.Text) < xcant)
                            {
                                xlist = lsv_Det.Items.Add(xitem["Id_Pro"].ToString());
                                xlist.SubItems.Add(xitem["Descripcion_Larga"].ToString());
                                xlist.SubItems.Add(xitem["Cantidad"].ToString());
                                xlist.SubItems.Add(xitem["Precio_ConIgv"].ToString());
                                xlist.SubItems.Add(xitem["Importe_ConIgv"].ToString());
                                xlist.SubItems.Add(xitem["Tipo_Prod"].ToString());
                                xlist.SubItems.Add(xitem["Und_Medida"].ToString());
                                xlist.SubItems.Add(xitem["Utilidad_Unit"].ToString());
                                xlist.SubItems.Add(xitem["Utilidad_Unit"].ToString());
                                xlist.SubItems.Add("Gravado");
                                xlist.SubItems.Add("0.00");
                                xlist.SubItems.Add("0.00");
                                xlist.SubItems.Add("0.00");
                                xlist.SubItems.Add(_uni_medida_desc.ToString());
                            }
                        }
                        else
                        {
                            xlist = lsv_Det.Items.Add(xitem["Id_Pro"].ToString());
                            xlist.SubItems.Add(xitem["Descripcion_Larga"].ToString());
                            xlist.SubItems.Add(xitem["Cantidad"].ToString());
                            xlist.SubItems.Add(xitem["Precio_ConIgv"].ToString());
                            xlist.SubItems.Add(xitem["Importe_ConIgv"].ToString());
                            xlist.SubItems.Add(xitem["Tipo_Prod"].ToString());
                            xlist.SubItems.Add(xitem["Und_Medida"].ToString());
                            xlist.SubItems.Add(xitem["Utilidad_Unit"].ToString());
                            xlist.SubItems.Add(xitem["Utilidad_Unit"].ToString());

                            xlist.SubItems.Add("Gravado");
                            xlist.SubItems.Add("0.00");
                            xlist.SubItems.Add("0.00");
                            xlist.SubItems.Add("0.00");
                            xlist.SubItems.Add(_uni_medida_desc.ToString());
                         }
                    }
                    
                    Calcular();
                    pnl_sinProd.Visible = false;
                    txt_buscar.Enabled = false;
                    lbl_BusCotiza.Enabled = false;
                }
                else
                {
                    fil.Show();
                    adv.lbl_msm.Text = "No se encontro la cotizacion: " + txt_buscar.Text + ", intentar con otra Cotizacion. ";
                    adv.ShowDialog();
                    fil.Hide();
                    txt_buscar.Enabled = true;
                    lbl_BusCotiza.Enabled = true;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        private void Buscar_Producto_Cotizacion(string idpro)
        {
            RN_Producto n_prod = new RN_Producto();
            DataTable dt = new DataTable();
            try
            {
                dt = n_prod.RN_Buscar_Producto(idpro);
                if (dt.Rows.Count > 0)
                {
                    lbl_StockX.Text = Convert.ToString(dt.Rows[0]["Stock_Actual"]);
                    lbl_prodX.Text = Convert.ToString(dt.Rows[0]["TipoProdcto"]);//Und_Medida
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void label3_Click(object sender, EventArgs e)
        {
            if (txt_buscar.Text.Length > 6)
            {
                Buscar_Cotizacion_Atender(txt_buscar.Text);

            }
        }
        private void btn_imprimir_Click(object sender, EventArgs e)
        {

        }

        #region dos formas de generar codigo QR
        void GenerarCodigoQR(string tipoDoc, string totalDoc, string Cliente, string nroDoc, string rutaQR)
        {
            QRCodeEncoder generarCodigoQR = new QRCodeEncoder();
            generarCodigoQR.QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.BYTE;
            generarCodigoQR.QRCodeScale = Int32.Parse("4");

            try
            {
                generarCodigoQR.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.M;
                //0 calcula automatico el tamaño del QR
                generarCodigoQR.QRCodeVersion = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar QR 1:" + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            string contenido;

            /*
             * RUC-TIPO_COMPROBANTE-NUMDOCUMENTO-TOTALIGV-IMPORTETOTAL-FECHAEMI-TIPODOCUMENTOCLIENTE-NROCLIENTE
             RUC | TIPO DE DOCUMENTO | SERIE | NUMERO | MTO TOTAL IGV |
             MTO TOTAL DEL COMPROBANTE | FECHA DE EMISION | TIPO DE DOCUMENTO ADQUIRENTE | 
             NUMERO DE DOCUMENTO ADQUIRENTE 
             */
            string tipoDocClienteNom="";
             
            if (tipoDocumentoCliente=="1")
            {
                tipoDocClienteNom = "DNI";
            }
            else if (tipoDocumentoCliente == "6")
            {
                tipoDocClienteNom = "RUC";
            }
            contenido = "RUC|"+v_rucEmisor+ "|" +
                        "TIPO DE DOCUMENTO|" + tipoDocumentoSunat+"-"+ cbb_tipoDocumento.Text + "|" +
                        "SERIE|" + txt_NroDocumento.Text.Substring(0, 4) + "|" +
                        "NUMERO|" + txt_NroDocumento.Text.Substring(5) + "|" +
                        "MTO TOTAL IGV|" + lbl_IGVgravado.Text + "\n"+
                        "MTO TOTAL DEL COMPROBANTE|"+ lbl_TotalPagar.Text+ "|" +
                        "FECHA DE EMISION|" + dtp_FechaEmi.Value + "\n" +
                        "TIPO DE DOCUMENTO ADQUIRENTE|" + tipoDocClienteNom + "|" +
                        "NUMERO DE DOCUMENTO ADQUIRENTE|" + lbl_Dni.Text
                ;
            Bitmap imgQR;
            try
            {
                imgQR = new Bitmap(generarCodigoQR.Encode(contenido, Encoding.UTF8)); 
                pb_QR.Image = imgQR;
                imgQR.Save(rutaQR);//Aqui guarda la primera imagen QR en .bmp

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar QR 2:" + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        void GenerarCodigoQR2(string tipoDoc, string totalDoc, string Cliente, string nroDoc, string rutaQR)
        {
            try
            {
                
                //String contenido;
                //contenido = "Nro: " + nroDoc + "\r\n" + "Documento: " + tipoDoc + "\r\n" + "Total: " + totalDoc + "\r\n" + "Cliente: " + Cliente;
                string contenido = string.Format("Nro:{0}|Documento:{1}|Total:{2}|Cliente:{3}",nroDoc.ToString(), tipoDoc.ToString(),totalDoc.ToString(), Cliente.ToString());
                string nombreArchivo = Application.StartupPath + $@"\{contenido}.png";
                if (File.Exists(nombreArchivo))
                    File.Delete(nombreArchivo);
                QrEncoder qrEncoder = new QrEncoder(ErrorCorrectionLevel.Q);
                QrCode qrCode = qrEncoder.Encode(contenido);
                GraphicsRenderer renderer = new GraphicsRenderer(new FixedModuleSize(8, QuietZoneModules.Two), Brushes.Black, Brushes.White);
                using (FileStream stream = new FileStream(nombreArchivo, FileMode.Create))
                {
                    renderer.WriteToStream(qrCode.Matrix, ImageFormat.Png, stream);
                }
                pb_QR.Image = Image.FromFile(nombreArchivo);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en CodigoQR(): " + ex.Message);
            }
        }
        #endregion
        public static byte[] Convertir_ImagenByte(Image img)
        {
            string stemp = Path.GetTempFileName();
            FileStream fs = new FileStream(stemp, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            img.Save(fs, System.Drawing.Imaging.ImageFormat.Png);
            fs.Position = 0;

            int imgLength = Convert.ToInt32(fs.Length);
            byte[] bytes = new byte[imgLength];
            fs.Read(bytes, 0, imgLength);
            fs.Close();
            return bytes;
        }
        private void DatosEmpresa()
        {
            RN_MiEmpresa n_emp = new RN_MiEmpresa();
            DataTable dt = new DataTable();
            try
            {
                dt = n_emp.RN_Mostrar_Empresa(1);
                if (dt.Rows.Count > 0)
                {
                    v_empresaEmisor = dt.Rows[0]["nombrerancho"].ToString();
                    v_rucEmisor = dt.Rows[0]["nroRuc"].ToString();
                    v_direccionEmpresa = dt.Rows[0]["direccionran"].ToString();
                    v_usuarioSol = dt.Rows[0]["usuariosol"].ToString();
                    v_claveSol = dt.Rows[0]["clavesol"].ToString();
                    v_correoEmi = dt.Rows[0]["correo"].ToString();
                    v_claveCorreo = dt.Rows[0]["clavecorreo"].ToString();
                    v_certificadoClave = dt.Rows[0]["clavecertificado"].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "DatosEmpresa", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void lbl_BusClien_Click(object sender, EventArgs e)
        {
            Frm_ListadoClientes lis = new Frm_ListadoClientes();

            fil.Show();
            lis.xxvalor = txt_cliente.Text;
            lis.ShowDialog();
            fil.Hide();

            if (lis.Tag.ToString() == "A")
            {
                lbl_idcliente.Text = lis.lblID.Text;
                txt_cliente.Text = lis.lblnom.Text;
                lbl_xDNI.Text = lis.lblRUC.Text;
                Leer_Datos_DelCliente(lbl_xDNI.Text);
            }
        }
        private void Leer_Datos_DelCliente(string dni)
        {
            RN_cliente n_cliente = new RN_cliente();
            DataTable data = new DataTable();
            double xlimit_credit;
            try
            {
                data = n_cliente.RN_Buscar_cliente(dni);
                if (data.Rows.Count > 0)
                {
                    lbl_Dni.Text = Convert.ToString(data.Rows[0]["DNI"]).Trim();
                    xlimit_credit = Convert.ToDouble(data.Rows[0]["Limit_Credit"]);
                    lbl_direccion.Text = Convert.ToString(data.Rows[0]["Direccion"]);
                    lbl_idcliente.Text = Convert.ToString(data.Rows[0]["Id_Cliente"]);
                    lbl_limitCredito.Text = xlimit_credit.ToString("###0.00");

                    if (Convert.ToInt32(lbl_Dni.Text.Length) == 8)
                    {
                        tipoDocumentoCliente = "1";
                    }
                    else if (Convert.ToInt32(lbl_Dni.Text.Length) == 11)
                    {
                        tipoDocumentoCliente = "6";
                    }
                    else
                    {
                        Frm_Advertencia adv = new Frm_Advertencia();
                        fil.Show();
                        adv.lbl_msm.Text = "Favor de Validar el numero de documento: " + lbl_Dni.Text + " el cual tiene: " + lbl_Dni.Text.Length.ToString() + " Digt. si es DNI debe tener 8 Dig. si es RUC debe contener 11 Digt.";
                        adv.ShowDialog();
                        fil.Hide();
                    }
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show("Error al Guardar: " + ex.Message, "Form Add Proveedor", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void rbt_servLocal_CheckedChanged(object sender, EventArgs e)
        {
            if (rbt_servLocal.Checked)
            {
                tipoServidor = "2";
            }
        }
        private void rbt_servSunat_CheckedChanged(object sender, EventArgs e)
        {
            if (rbt_servSunat.Checked)
            {
                tipoServidor = "1";
            }
        }
        private void rbt_servPrueba_CheckedChanged(object sender, EventArgs e)
        {
            if (rbt_servPrueba.Checked)
            {
                tipoServidor = "3";
            }
        }
        private void cbb_tipoDocumento_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbb_tipoDocumento.SelectedIndex == 0)  //nota venta
            {
                tipoDocumentoSunat = "00";
            }
            if (cbb_tipoDocumento.SelectedIndex == 1) //boleta
            {
                tipoDocumentoSunat = "03";
            }
            if (cbb_tipoDocumento.SelectedIndex == 2) //factura
            {
                tipoDocumentoSunat = "01";
            }
        }
        private void btn_Comprobar_Click(object sender, EventArgs e)
        {
            Frm_Filtro fil = new Frm_Filtro();
            if (cbb_tipoDocumento.SelectedIndex == 0 || cbb_tipoDocumento.Text == "Nota Venta")
            {
                fil.Show();
                MessageBox.Show("El Documento ingresado no es valido para la Sunat.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                fil.Hide();
                return;
            }
            else if (Convert.ToInt32(lbl_Dni.Text.Length) == 8 && cbb_tipoDocumento.Text == "Boleta")
            {
                txt_NroDocumento.Text = RN_TipoDoc.Sp_Listado_Tipo(Convert.ToInt32(cbb_tipoDocumento.SelectedValue));
                EnviarDocumento_Sunat();
            }
            else if (Convert.ToInt32(lbl_Dni.Text.Length) == 11 && cbb_tipoDocumento.Text == "Factura")
            {
                txt_NroDocumento.Text = RN_TipoDoc.Sp_Listado_Tipo(Convert.ToInt32(cbb_tipoDocumento.SelectedValue));
                EnviarDocumento_Sunat();
            }
            else
            {
                fil.Show();
                MessageBox.Show("El Documento " + lbl_Dni.Text + " no es valido para la " + cbb_tipoDocumento.Text + " Verificar el numero de documento del cliente corresponda al tipo de Documento a emitir", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                fil.Hide();
                return;
            }

        }
        private void cbb_tipoPago_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbb_tipoPago.Text.Trim() == "Deposito")
            {
                txt_NumOperacion.ReadOnly = false;
                txt_NumOperacion.Focus();
            }
            else if (cbb_tipoPago.Text.Trim() == "Nota Credito")
            {
                //Buscar NC
                Frm_Filtro fil = new Frm_Filtro();
                Frm_Nro_NC cant = new Frm_Nro_NC();

                fil.Show();
                cant.ShowDialog();
                fil.Hide();
                if (cant.Tag.ToString() == "A")
                {
                    string NroNC = cant.txt_Cantidad.Text.Trim();
                    Buscar_NC_ParaPago(NroNC);
                }
            }
            else if (cbb_tipoPago.Text.Trim() == "Vale")
            {
                //Buscar vale
            }
            else
            {
                txt_NumOperacion.Text = "-";
                txt_NumOperacion.ReadOnly = true;
            }
        }
        void Buscar_NC_ParaPago(string nroDoc)
        {
            RN_Notacredito nc = new RN_Notacredito();
            DataTable dt = new DataTable();
            Frm_Filtro fil = new Frm_Filtro();
            Frm_Advertencia adv = new Frm_Advertencia();
            double ImporteNC;
            double SaldoaPagar;

            try
            {
                if (nc.RN_Verificar_NC_PendientePago(nroDoc) == true)
                {
                    dt = nc.RN_Buscar_NC_PendientePago(nroDoc);
                    if (dt.Rows.Count > 0)
                    {
                        lbl_idNC.Text = dt.Rows[0]["Id_Cre"].ToString();
                        lbl_ImporteNC.Text = dt.Rows[0]["Vlr_Total"].ToString();
                        ImporteNC = Convert.ToDouble(lbl_ImporteNC.Text);
                        //Calculo Saldo Pendiente de Pago
                        SaldoaPagar = Convert.ToDouble(lbl_TotalPagar.Text) - ImporteNC;
                        lbl_saldoPendiente.Text = SaldoaPagar.ToString("###0.00");

                        fil.Show();
                        adv.lbl_msm.Text = "El saldo a pagar es: " + SaldoaPagar.ToString("###0.00");
                        adv.ShowDialog();
                        fil.Hide();

                    }
                }
                else
                {
                    fil.Show();
                    adv.lbl_msm.Text = "El Documento seleccionado no Existe o no es Válido para Pagos.";
                    adv.ShowDialog();
                    fil.Hide();
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #region Variables de Billetes
        double monto100 = 100;

        double monto20 = 20;

        double monto50 = 50;

        double MontoTotal = 0;
        #endregion
        private void btn_20_Click(object sender, EventArgs e)
        {
            MontoTotal = MontoTotal + monto20;
            txt_Cantidad.Text = MontoTotal.ToString("##0.00");
            lbl_vuelto.Text = (Convert.ToDouble(txt_Cantidad.Text) - Convert.ToDouble(lbl_TotalPagar.Text) - Convert.ToDouble(lbl_saldoPendiente.Text)).ToString("##0.00");
            lbl_pagaCon.Text = txt_Cantidad.Text;
        }

        private void btn_50_Click(object sender, EventArgs e)
        {
            MontoTotal = MontoTotal + monto50;
            txt_Cantidad.Text = MontoTotal.ToString("##0.00");
            lbl_vuelto.Text = (Convert.ToDouble(txt_Cantidad.Text) - Convert.ToDouble(lbl_TotalPagar.Text) - Convert.ToDouble(lbl_saldoPendiente.Text)).ToString("##0.00");
            lbl_pagaCon.Text = txt_Cantidad.Text;
        }

        
        private void btn_100_Click(object sender, EventArgs e)
        {
            MontoTotal = MontoTotal + monto100;
            txt_Cantidad.Text = MontoTotal.ToString("##0.00");
            lbl_vuelto.Text = (Convert.ToDouble(txt_Cantidad.Text) - Convert.ToDouble(lbl_TotalPagar.Text) - Convert.ToDouble(lbl_saldoPendiente.Text)).ToString("##0.00");
            lbl_pagaCon.Text = txt_Cantidad.Text;
        }

        private void txt_Cantidad_KeyDown(object sender, KeyEventArgs e)
        {
            if (txt_Cantidad.Text.Length>0)
            {
                lbl_vuelto.Text = (Convert.ToDouble(txt_Cantidad.Text)-Convert.ToDouble(lbl_TotalPagar.Text) - Convert.ToDouble(lbl_saldoPendiente.Text)).ToString("##0.00");
                lbl_pagaCon.Text = txt_Cantidad.Text;
            }
           
        }

        private void txt_Cantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilitario uti = new Utilitario();
            e.KeyChar = Convert.ToChar(uti.SoloNumeros(e.KeyChar));
        }

        private void txt_Cantidad_KeyUp(object sender, KeyEventArgs e)
        {
            if (txt_Cantidad.Text.Length > 0)
            {
                lbl_vuelto.Text = (Convert.ToDouble(txt_Cantidad.Text) - Convert.ToDouble(lbl_TotalPagar.Text) - Convert.ToDouble(lbl_saldoPendiente.Text)).ToString("##0.00");
                lbl_pagaCon.Text = txt_Cantidad.Text;
            }
        }

    }
}