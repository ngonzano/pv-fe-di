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
using System.IO;
using Microsell_Lite.Productos;
using Microsell_Lite.Utilitarios;

namespace Microsell_Lite.Compras
{
    public partial class Frm_Compras : Form
    {
        public Frm_Compras()
        {
            InitializeComponent();
        }
       
        private void Frm_Ventana_Ventas_Load(object sender, EventArgs e)
        {
            Configurar_listView();
            listar_ComboBox_Proveedores();
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
            this.Tag = "";
            this.Close();
        }

        private void btn_minimi_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void bt_Delete_Click(object sender, EventArgs e)
        {
            Principal.Frm_Filtro fil = new Principal.Frm_Filtro();
            Utilitarios.Frm_SINO sino = new Utilitarios.Frm_SINO();
            if (lsv_Det.SelectedIndices.Count == 0)
            {
                MessageBox.Show("Seleccione un producto para eliminar del carrito.", "Advertencia de seguridad", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                fil.Show();
                sino.lbl_msm.Text = "¿Estas seguro de eliminar el producto: "+ lsv_Det.SelectedItems[0].SubItems[1].Text + " del carrito? ";
                sino.ShowDialog();
                fil.Hide();
                if (sino.Tag.ToString()=="SI")
                {
                    int i;
                    var lis = lsv_Det.SelectedItems[0];
                    for (i = lsv_Det.SelectedItems.Count - 1; i >= 0; i--)
                    {
                        lsv_Det.Items.Remove(lsv_Det.SelectedItems[i]);
                    }
                    calcular();
                    if (lsv_Det.Items.Count == 0)
                    {
                        pnl_sinProd.Visible = true;
                    }
                }
            }
        }
        void buscar_producto()
        {
            Principal.Frm_Filtro fil = new Principal.Frm_Filtro();
            Frm_Listar_ProductoCompra2 proC = new Frm_Listar_ProductoCompra2();

            fil.Show();
            proC.rb_AddModoCoti.Checked = true;
            proC.TipoVenta = "compra"; 
            proC.txt_buscar.Focus();
            proC.ShowDialog();
            fil.Hide();

            if (proC.Tag.ToString() == "A")
            {
                string _idprod ;
                string _nomprod;
                double _cant;
                double _precio;
                double _import;

                if (proC.lsv_pedido.Items.Count > 0)
                {
                    for (int i = 0; i < proC.lsv_pedido.Items.Count; i++)
                    {
                        var item = proC.lsv_pedido.Items[i];
                        _idprod = item.SubItems[0].Text;
                        _nomprod = item.SubItems[1].Text;
                        _cant= Convert.ToDouble(item.SubItems[3].Text);
                        _precio= Convert.ToDouble(item.SubItems[4].Text);//precio de compra
                        _import= Convert.ToDouble(item.SubItems[5].Text);
                        Agregar_Productos_Carrito(_idprod.Trim(), _nomprod, _cant, _precio, _import);
                    }
                }
                else //
                {
                    _idprod = proC.lbl_idpro.Text;
                    _nomprod = proC.lbl_NomProd.Text;
                    _cant = Convert.ToDouble(proC.lbl_Cant.Text);
                    _precio = Convert.ToDouble(proC.lbl_precioCompra.Text); //precio de compra quitado lbl_Pre_Unt.Text
                    _import = Convert.ToDouble(proC.lbl_import.Text);

                    Agregar_Productos_Carrito(_idprod.Trim(), _nomprod, _cant, _precio, _import);
                }
            }
        }
        private void btn_Nuevo_buscarProd_Click(object sender, EventArgs e)
        {
            buscar_producto();            
        }
        private void Configurar_listView()
        {
            var lis = lsv_Det;
            lsv_Det.Items.Clear();
            lis.Columns.Clear();
            lis.View = View.Details;
            lis.GridLines = true;
            lis.FullRowSelect = true;
            lis.Scrollable = true;
            lis.HideSelection = false;
            //CONFIGURAR COLUMNA
            lis.Columns.Add("ID PROD", 80, HorizontalAlignment.Left);//0
            lis.Columns.Add("DESCRIPCION PRODUCTO", 380, HorizontalAlignment.Left);//1
            lis.Columns.Add("CANTIDAD", 65, HorizontalAlignment.Center);//2
            lis.Columns.Add("PRECIO UNIT", 95, HorizontalAlignment.Right);//3
            lis.Columns.Add("IMPORTE", 95, HorizontalAlignment.Right);//4
            lis.Columns.Add("PRECIO_COMPRA", 0, HorizontalAlignment.Right);

        }
        void Agregar_Productos_Carrito(string xidprod,string xnomprod,double xcant,double xprecio,double ximport)
        {
            try
            {
                if (lsv_Det.Items.Count==0)
                {
                    ListViewItem list_item = new ListViewItem();
                    list_item = lsv_Det.Items.Add(xidprod);
                    list_item.SubItems.Add(xnomprod.Trim());
                    list_item.SubItems.Add(xcant.ToString());
                    list_item.SubItems.Add(xprecio.ToString("###0.00"));
                    list_item.SubItems.Add(ximport.ToString("###0.00"));

                    calcular();
                    lsv_Det.Focus();
                    lsv_Det.Items[0].Selected = true;
                    pnl_sinProd.Visible = false;
                    pintar_listView();
                }
                else
                {
                    //validar que el producto no se ingrese dos veces
                    for (int i = 0; i < lsv_Det.Items.Count; i++)
                    {
                        if (lsv_Det.Items[i].Text.Trim()==xidprod.Trim())
                        {
                            MessageBox.Show("El Producto "+xnomprod+" ya fue agregado al carrito","Advertencia de seguridad",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                            return;
                        }
                    }
                    ListViewItem list_item = new ListViewItem();
                    list_item = lsv_Det.Items.Add(xidprod);
                    list_item.SubItems.Add(xnomprod.Trim());
                    list_item.SubItems.Add(xcant.ToString());
                    list_item.SubItems.Add(xprecio.ToString("###0.00"));
                    list_item.SubItems.Add(ximport.ToString("###0.00"));
                    calcular();
                    lsv_Det.Focus();
                    lsv_Det.Items[0].Selected = true;
                    pintar_listView();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        void pintar_listView()
        {
            int cont = 1;
            for (int i = 0; i < lsv_Det.Items.Count; i++)
            {
                if (cont % 2 != 0)
                {
                    lsv_Det.Items[i].BackColor = Color.DarkSeaGreen;
                    lsv_Det.Items[i].ForeColor = Color.White;
                }
                i++;
            }
        }
        void calcular()
        {
            double xtotal = 0;
            double xcantidad = 0;
            double xprecio = 0;
            double ximporte = 0;
            double xigv = 0;
            double xsubtotal = 0;

            for (int i = 0; i < lsv_Det.Items.Count; i++)
            {
                xcantidad = Convert.ToDouble(lsv_Det.Items[i].SubItems[2].Text);
                xprecio = Convert.ToDouble(lsv_Det.Items[i].SubItems[3].Text);
                //calcular
                ximporte = xcantidad * xprecio;
                lsv_Det.Items[i].SubItems[4].Text = ximporte.ToString("###0.00");

                //calculo del total
                xtotal = xtotal + Convert.ToDouble(lsv_Det.Items[i].SubItems[4].Text);
            }
            //calcular IGV
            
            xsubtotal = xtotal / 1.18;
            xigv = xsubtotal * 0.18;
            
            lbl_subtotal.Text = xsubtotal.ToString("###0.00");
            lbl_igv.Text = xigv.ToString("###0.00");
            lbl_TotalPagar.Text = xtotal.ToString("###0.00");
        }
        private void bt_add_Click(object sender, EventArgs e)
        {
            buscar_producto();
        }
        private void bt_editPre_Click(object sender, EventArgs e)
        {
            Principal.Frm_Filtro fil = new Principal.Frm_Filtro();
            Frm_Solo_Precio solo_Precio = new Frm_Solo_Precio();
            if (lsv_Det.SelectedIndices.Count == 0)
            {
                MessageBox.Show("Seleccione un producto para editar precio.", "Advertencia de seguridad", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                double precio_ingresado;
                double precio_editado;
                precio_ingresado = Convert.ToDouble(lsv_Det.SelectedItems[0].SubItems[3].Text);
                fil.Show();
                solo_Precio.txt_cant.Text = precio_ingresado.ToString();
                solo_Precio.ShowDialog();
                fil.Hide();
                if (solo_Precio.Tag.ToString() == "A")
                {
                    precio_editado = Convert.ToDouble(solo_Precio.txt_cant.Text);
                    lsv_Det.SelectedItems[0].SubItems[3].Text = precio_editado.ToString("###0.00");
                    calcular();
                }
            }
        }
        private void bt_editCant_Click(object sender, EventArgs e)
        {
            Principal.Frm_Filtro fil = new Principal.Frm_Filtro();
            Frm_Solo_Cant solo = new Frm_Solo_Cant();
            if (lsv_Det.SelectedIndices.Count == 0)
            {
                MessageBox.Show("Seleccione un producto para editar Cantidad.", "Advertencia de seguridad", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                double Cant_ingresado;
                double Cant_editado;
                Cant_ingresado = Convert.ToDouble(lsv_Det.SelectedItems[0].SubItems[2].Text);
                fil.Show();
                solo.txt_Cantidad.Text = Cant_ingresado.ToString();
                solo.ShowDialog();
                fil.Hide();
                if (solo.Tag.ToString() == "A")
                {
                    Cant_editado = Convert.ToDouble(solo.txt_Cantidad.Text);
                    lsv_Det.SelectedItems[0].SubItems[2].Text = Cant_editado.ToString("###0.00");
                    calcular();
                }
            }
        }

        private void Frm_Compras_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                if (pnl_sinProd.Visible==true)
                {
                    btn_Nuevo_buscarProd_Click(sender, e);
                }
            }
            if (e.KeyCode == Keys.F4)
            {
                if (pnl_sinProd.Visible == false)
                {
                    bt_add_Click(sender, e);
                }
            }
            if (e.KeyCode == Keys.F5)
            {
                if (pnl_sinProd.Visible == false)
                {
                    btn_procesar_Click(sender, e);
                }
            }
            if ((int)(e.KeyData)==(int)(Keys.Control)+ (int)(Keys.P))
            {
                cbo_provee.Focus();
            }
        }

        private void Frm_Compras_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }

        void listar_ComboBox_Proveedores()
        {
            DataTable dt = new DataTable();
            RN_Proveedor n_prov = new RN_Proveedor();
            dt = n_prov.RN_Mostrar_Todas_Proveedor();
            if (dt.Rows.Count>0)
            {
                var cbb = cbo_provee;
                cbb.DataSource = dt;
                cbb.DisplayMember = "NOMBRE";
                cbb.ValueMember = "IDPROVEE";
                cbb.SelectedIndex = -1;
            }
        }
        bool Validar_compra()
        {
            Principal.Frm_Filtro fil = new Principal.Frm_Filtro();
            Utilitarios.Frm_Advertencia adv = new Utilitarios.Frm_Advertencia();
            if (lsv_Det.Items.Count== 0) { fil.Show(); adv.lbl_msm.Text = "Selecciona un proveedor."; adv.ShowDialog(); fil.Hide(); adv.ShowDialog(); return false; }
            if (cbo_provee.SelectedIndex == -1) { fil.Show(); adv.lbl_msm.Text = "Selecciona un proveedor."; adv.ShowDialog(); fil.Hide(); cbo_provee.Focus(); return false; }
            if (txt_NroFisico.Text.Trim().Length <= 0) { fil.Show(); adv.lbl_msm.Text = "Seleccione un número fisico."; adv.ShowDialog(); fil.Hide(); txt_NroFisico.Focus(); return false; }
            if (cbo_tipoPago.SelectedIndex == -1) { fil.Show(); adv.lbl_msm.Text = "Selecciona un tipo de pago."; adv.ShowDialog(); fil.Hide(); cbo_tipoPago.Focus(); return false; }
            if (cbo_tipoDoc.SelectedIndex == -1) { fil.Show(); adv.lbl_msm.Text = "Selecciona un tipo de documento."; adv.ShowDialog(); fil.Hide(); cbo_tipoDoc.Focus(); return false; }
            
            return true;
        }
        void RegistrarCompra()
        {
            EN_IngresarCompra e_ingCompr = new EN_IngresarCompra();
            EN_Det_IngresoCompra e_det_ingCom = new EN_Det_IngresoCompra();
            RN_IngresoCompra n_inComp = new RN_IngresoCompra();
            RN_Producto n_prod = new RN_Producto();
            
            try
            {
                txt_IdComp.Text = RN_TipoDoc.Sp_Listado_Tipo(9);
                e_ingCompr.Idcom = txt_IdComp.Text;
                e_ingCompr.Nro_Fac_Fisico = txt_NroFisico.Text;
                e_ingCompr.IdProvee = cbo_provee.SelectedValue.ToString();//por que viene de la base de datos va el selectedtValue
                e_ingCompr.SubTotal_Com = Convert.ToDouble(lbl_subtotal.Text);
                e_ingCompr.FechaIngre = dtp_FechaCom.Value;
                e_ingCompr.TotalCompra = Convert.ToDouble(lbl_TotalPagar.Text);
                e_ingCompr.IdUsu =Cls_UsuLogin.IdUsu.ToString();
                e_ingCompr.ModalidadPago = cbo_tipoPago.Text;
                e_ingCompr.TiempoEspera = 0;
                e_ingCompr.FechaVence = dtp_FechaVenc.Value;
                e_ingCompr.EstadoIngre = "Activo";
                e_ingCompr.RecibiConforme = ckb_RecConforme.Checked;
                e_ingCompr.Datos_Adicional = txt_obser.Text;
                e_ingCompr.Tipo_Doc_Compra = cbo_tipoDoc.Text;
                e_ingCompr.Tipo_ingreso = "Compras";
                
                if (n_inComp.RN_Ingresar_HeaderRegistroCompra(e_ingCompr)==1)
                {
                    int repeticion=0;
                    RN_TipoDoc.RN_Actualizar_SiguienteNro_correlativo(9);

                    //guardar detalle
                    for (int i = 0; i < lsv_Det.Items.Count ; i++)
                    {
                        var item = lsv_Det.Items[i];
                        e_det_ingCom.Id_ingreso = txt_IdComp.Text;
                        e_det_ingCom.Id_pro = item.SubItems[0].Text;
                        e_det_ingCom.Precio = Convert.ToDouble(item.SubItems[3].Text); //REVISAR ESTA DANDO EL PRECIO DE VENTA, DEBERIA SER EL PRECIO DE COMPRA.
                        e_det_ingCom.Cantidad= Convert.ToDouble(item.SubItems[2].Text);
                        e_det_ingCom.Importe= Convert.ToDouble(item.SubItems[4].Text);

                        if (n_inComp.RN_Ingresar_Detalle_RegistroCompra(e_det_ingCom)==1)
                        {
                            RegistrarMovimientoKardex(e_det_ingCom.Id_pro.Trim(), e_det_ingCom.Cantidad, e_det_ingCom.Precio);
                            //Actualizar el Precio del Producto
                            double utilidad;
                            double ValorAlmacen;
                            double preVenta;
                            double preCompra = e_det_ingCom.Precio;
                            double xfrank;
                            xfrank=Buscar_Producto_frank(e_det_ingCom.Id_pro.Trim());
                            preVenta = xfrank * preCompra; //Calculamos el valor Venta
                            utilidad = preVenta - preCompra;
                            ValorAlmacen = e_det_ingCom.Cantidad * preCompra;
                            n_prod.RN_ActPrec_CompraVenta_Producto(e_det_ingCom.Id_pro.Trim(),
                                Convert.ToDouble(preCompra.ToString("###0.00")), 
                                Convert.ToDouble(preVenta.ToString("###0.00")), 
                                Convert.ToDouble(utilidad.ToString("###0.00")), 
                                Convert.ToDouble(ValorAlmacen.ToString("###0.00")));
                        }

                        repeticion++;
                    }
                    Principal.Frm_Filtro fil = new Principal.Frm_Filtro();
                    Frm_Msm_Bueno bueno = new Frm_Msm_Bueno();
                    fil.Show();
                    bueno.Lbl_msm1.Text = "Se realizo la compra de: " + repeticion + " Producto(s).";
                    bueno.ShowDialog();
                    fil.Hide();
                    lsv_Det.Items.Clear();
                    cbo_provee.SelectedIndex = -1;
                    txt_NroFisico.Text = "";
                    cbo_tipoDoc.SelectedIndex = -1;
                    cbo_tipoPago.SelectedIndex = -1;
                    this.Tag = "A";
                    this.Close();
                    //MessageBox.Show("Se realizo la compra de: " + repeticion + " Producto(s).", "Advertencia de Seguridad.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al Registrar la Compra: " + ex.Message, "Advertencia de Seguridad", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        double Buscar_Producto_frank(string idprod)
        {
            RN_Producto n_prod = new RN_Producto();
            DataTable dt = new DataTable();
            dt = n_prod.RN_Buscar_Producto(idprod);
            double frank;
            if (dt.Rows.Count>0)
            {
                //Margen de Utilidad
                frank = Convert.ToDouble(dt.Rows[0]["Frank"]);
            }
            else
            {
                 frank=0;
            }
            return frank;
        }
        void RegistrarMovimientoKardex(string idprod,double cant,double xprecioCompra)
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
            try
            {
                if (n_kar.RN_Sp_Ver_sihay_Kardex(idprod))
                {
                    dt = n_kar.RN_BuscarKardexDetalleProducto(idprod.Trim());
                    xidkardex = dt.Rows[0]["Id_krdx"].ToString();
                    xitem = dt.Rows.Count;
                    dt2 = n_prod.RN_Buscar_Producto(idprod.Trim());
                    stockProd = Convert.ToDouble(dt2.Rows[0]["Stock_Actual"]);
                    PrecioCompraProd=Convert.ToDouble(dt2.Rows[0]["Pre_CompraS"]);
                    //Registrar Detalle Kardex
                    e_kar.Id_Krdx = xidkardex;
                    e_kar.Item = xitem + 1;
                    e_kar.Doc_Soport = txt_NroFisico.Text;
                    e_kar.Det_Operacion = "Compra De Mercaderia ";
                    //Entrada
                    e_kar.Cantidad_In = cant;
                    e_kar.Precio_Unt_In = xprecioCompra;
                    e_kar.Costo_Total_In = cant * PrecioCompraProd;
                    //Salida
                    e_kar.Cantidad_Out = 0;
                    e_kar.Precio_Unt_Out = 0; 
                    e_kar.Importe_Total_Out = 0;
                    //saldos
                    e_kar.Cantidad_Saldo = stockProd + cant;
                    e_kar.Promedio = xprecioCompra;
                    e_kar.Costo_Total_Saldo = xprecioCompra * (stockProd + cant);
                    n_kar.RN_Registrar_det_Kardex(e_kar);
                    //Actualizar Stock Productos
                    n_prod.RN_SumarStock_Producto(idprod,cant);
                   // MessageBox.Show("El Producto " + xnomproducto + " ya fue agregado al carrito", "Advertencia de seguridad", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        private void btn_procesar_Click(object sender, EventArgs e)
        {
            if (Validar_compra())
            {
                RegistrarCompra();
            }
        }
    }
}
