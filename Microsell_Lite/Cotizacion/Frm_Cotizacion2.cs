using Microsell_Lite.Productos;
using System;
using System.Drawing;
using System.Windows.Forms;

using SPV_Capa_Entidad;
using SPV_Capa_Negocio;
using Microsell_Lite.Utilitarios;
using Microsell_Lite.Compras;
using Microsell_Lite.Cliente;
using System.Data;

namespace Microsell_Lite.Cotizacion
{
    public partial class Frm_Cotizacion2 : Form
    {
        public Frm_Cotizacion2()
        {
            InitializeComponent();
        }
        private void Frm_Ventana_Ventas_Load(object sender, EventArgs e)
        {
            Configurar_listView();
            DatosEmpresa();
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
            //configurar las columnas:
            lis.Columns.Add("ID producto", 80, HorizontalAlignment.Left); //0
            lis.Columns.Add("Descripcion producto", 400, HorizontalAlignment.Left);  //1
            lis.Columns.Add("cantidad", 60, HorizontalAlignment.Center);  //2
            lis.Columns.Add("precio Unit", 90, HorizontalAlignment.Right);  //3
            lis.Columns.Add("Importe", 90, HorizontalAlignment.Right);  //4
            lis.Columns.Add("Tipo Producto", 0, HorizontalAlignment.Right);  //5
            lis.Columns.Add("Und", 0, HorizontalAlignment.Right);  //6
            lis.Columns.Add("Utilidad Unit", 0, HorizontalAlignment.Right);  //7
            lis.Columns.Add("Total Utilidad", 0, HorizontalAlignment.Right);  //8

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
        private bool Validar_Cotizacion()
        {
            Principal.Frm_Filtro fil = new Principal.Frm_Filtro();

            if (lsv_Det.Items.Count == 0) { fil.Show(); MessageBox.Show("Ingresa Almenos un Producto", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); fil.Hide(); lsv_Det.Focus(); return false; }
            if (txt_cliente.Text == "") { fil.Show(); MessageBox.Show("Ingresa un cliente", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); fil.Hide(); txt_cliente.Focus(); return false; }
            
            return true;
        }

        private void Frm_Cotizacion_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void pnl_subtitu_MouseMove(object sender, MouseEventArgs e)
        {
            Utilitario obj = new Utilitario();

            if (e.Button == MouseButtons.Left)
            {
                obj.Mover_formulario(this);

            }
        }
        void Buscar_Producto()
        {
            Principal.Frm_Filtro fil = new Principal.Frm_Filtro();
            Frm_Listar_ProductoCompra2 xpro = new Frm_Listar_ProductoCompra2();

            fil.Show();
            xpro.rb_AddModoCoti.Checked = true;
            xpro.TipoVenta = "coti";
            xpro.txt_buscar.Focus();
            xpro.ShowDialog();
            fil.Hide();

            if (xpro.Tag.ToString() == "A")
            {
                string _idprod;
                string _nomprod;
                double _cant;
                double _precio;
                string _uni_med;
                string _tipoProd;
                double _import;
                double _utilid_unit;

                if (xpro.lsv_pedido.Items.Count > 0)
                {
                    for (int i = 0; i < xpro.lsv_pedido.Items.Count ; i++)
                    {
                        //var item =xpro.lsv_pedido.Items[i];
                        _idprod = xpro.lsv_pedido.Items[i].SubItems[0].Text;
                        _nomprod = xpro.lsv_pedido.Items[i].SubItems[1].Text;
                        _cant = Convert.ToDouble(xpro.lsv_pedido.Items[i].SubItems[3].Text);
                        _precio= Convert.ToDouble(xpro.lsv_pedido.Items[i].SubItems[4].Text);
                        _import= Convert.ToDouble(xpro.lsv_pedido.Items[i].SubItems[5].Text);
                        _uni_med= xpro.lsv_pedido.Items[i].SubItems[2].Text;
                        _tipoProd= xpro.lsv_pedido.Items[i].SubItems[7].Text;
                        _utilid_unit = Convert.ToDouble(xpro.lsv_pedido.Items[i].SubItems[6].Text);
                        Agregar_Productos_Carrito(_idprod.Trim(), _nomprod, _cant, _precio, _import, _uni_med, _tipoProd, _utilid_unit);
                    }
                }
                else
                {
                    _idprod = xpro.lbl_idpro.Text;
                    _nomprod = xpro.lbl_NomProd.Text;
                    _cant = Convert.ToDouble(xpro.lbl_Cant.Text);
                    _precio = Convert.ToDouble(xpro.lbl_Pre_Unt.Text);
                    _import = Convert.ToDouble(xpro.lbl_import.Text);
                    _uni_med = xpro.lbl_Und.Text;//validar si es la unidad de medida.
                    _tipoProd = xpro.lbl_tipoProd.Text;
                    _utilid_unit = Convert.ToDouble(xpro.lbl_Uti_unit.Text);
                    Agregar_Productos_Carrito(_idprod.Trim(), _nomprod, _cant, _precio, _import, _uni_med, _tipoProd, _utilid_unit); 
                }

               
            }
        }

        private void btn_Nuevo_buscarProd_Click(object sender, EventArgs e)
        {
            Buscar_Producto();
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
        void Calcular()
        {

            double xtotal = 0;
            double xcantidad = 0;
            double xprecio = 0;
            double ximporte = 0;
            double xigv = 0;
            double xsubtotal = 0;
            double xuti_unit = 0;
            double ximport_uti = 0;
            double xtotalGanancia = 0;

            for (int i = 0; i < lsv_Det.Items.Count; i++)
            {
                xcantidad = Convert.ToDouble(lsv_Det.Items[i].SubItems[2].Text);
                xprecio = Convert.ToDouble(lsv_Det.Items[i].SubItems[3].Text);

                //calcular
                ximporte = xcantidad * xprecio;
                lsv_Det.Items[i].SubItems[4].Text = ximporte.ToString("###0.00");

                //utilidad: en compras no hay esta linea
                xuti_unit = Convert.ToDouble(lsv_Det.Items[i].SubItems[7].Text);
                ximport_uti = xuti_unit * xcantidad;

                //calculo del total
                xtotal = xtotal + Convert.ToDouble(lsv_Det.Items[i].SubItems[4].Text);
                xtotalGanancia = xtotalGanancia + Convert.ToDouble(lsv_Det.Items[i].SubItems[8].Text) * xcantidad;//

            }
            //calcular IGV
            xsubtotal = xtotal / 1.18;
            xigv = xsubtotal * 0.18;
            lbl_subtotal.Text = xsubtotal.ToString("###0.00");
            lbl_igv.Text = xigv.ToString("###0.00");
            lbl_TotalPagar.Text = xtotal.ToString("###0.00");
            lbl_totalGanancia.Text = xtotalGanancia.ToString("###0.00");

            lbl_TotalItem.Text = lsv_Det.Items.Count.ToString("#0");
            lbl_son.Text = Numalet.ToString(lbl_TotalPagar.Text);
            nu.LetraCapital = chkCapital.Checked;
            if (!actualizado)
            {
                ActualizarConf(); 
            }
        }
        Numalet nu = new Numalet();
        bool actualizado = false;
        void ActualizarConf() 
        {
            actualizado = true;
            chkCapital.Checked = nu.LetraCapital;
            if (lbl_son.Text.Length>0)
            {
                lbl_son.Text = nu.ToCustomString(lbl_TotalPagar.Text);
                actualizado = false;
            }
        }
        void Agregar_Productos_Carrito(string xidprod, string xnomprod, double xcant, double xprecio, double ximport, string xuni_med, string xtipoprod, double xutilidad_unit)
        {
            try
            {
                if (lsv_Det.Items.Count == 0)
                {
                    ListViewItem list_item = new ListViewItem();
                    list_item = lsv_Det.Items.Add(xidprod);
                    list_item.SubItems.Add(xnomprod.Trim());
                    list_item.SubItems.Add(xcant.ToString());
                    list_item.SubItems.Add(xprecio.ToString("###0.00"));
                    list_item.SubItems.Add(ximport.ToString("###0.00"));
                    list_item.SubItems.Add(xtipoprod.Trim());
                    list_item.SubItems.Add(xuni_med.ToString());
                    list_item.SubItems.Add(xutilidad_unit.ToString("###0.00"));
                    list_item.SubItems.Add(xutilidad_unit.ToString("###0.00"));

                    Calcular();
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
                        if (lsv_Det.Items[i].Text.Trim() == xidprod.Trim())
                        {
                            MessageBox.Show("El Producto " + xnomprod + " ya fue agregado al carrito", "Advertencia de seguridad", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                    ListViewItem list_item = new ListViewItem();
                    list_item = lsv_Det.Items.Add(xidprod);
                    list_item.SubItems.Add(xnomprod.Trim());
                    list_item.SubItems.Add(xcant.ToString());
                    list_item.SubItems.Add(xprecio.ToString("###0.00"));
                    list_item.SubItems.Add(ximport.ToString("###0.00"));
                    list_item.SubItems.Add(xtipoprod.Trim());
                    list_item.SubItems.Add(xuni_med.ToString());
                    list_item.SubItems.Add(xutilidad_unit.ToString("###0.00"));
                    list_item.SubItems.Add(xutilidad_unit.ToString("###0.00"));
                    Calcular();
                    lsv_Det.Focus();
                    lsv_Det.Items[0].Selected = true;

                }
                lbl_TotalItem.Text = lsv_Det.Items.Count.ToString("#0");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_cerrar_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_minimi_Click_1(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void lsv_Det_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void bt_add_Click(object sender, EventArgs e)
        {
            Buscar_Producto();
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
                solo_Precio.lbl_nom.Text = lsv_Det.SelectedItems[0].SubItems[1].Text;
                solo_Precio.ShowDialog();
                fil.Hide();
                if (solo_Precio.Tag.ToString() == "A")
                {
                    precio_editado = Convert.ToDouble(solo_Precio.txt_cant.Text);
                    lsv_Det.SelectedItems[0].SubItems[3].Text = precio_editado.ToString("###0.00");
                    Calcular();
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
                solo.lbl_nom.Text = lsv_Det.SelectedItems[0].SubItems[1].Text;
                solo.lbl_stock.Text = lsv_Det.SelectedItems[0].SubItems[2].Text;
                solo.ShowDialog();
                fil.Hide();
                if (solo.Tag.ToString() == "A")
                {
                    Cant_editado = Convert.ToDouble(solo.txt_Cantidad.Text);
                    lsv_Det.SelectedItems[0].SubItems[2].Text = Cant_editado.ToString("###0.00");
                    Calcular();
                }
            }
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
        }
        string rutaPDF_Export_Ventas = "C:\\Sln_MicrosellLite\\CPE_2\\BETA\\";
        private void btn_procesar_Click(object sender, EventArgs e)
        {
            if (lsv_Det.Items.Count==0)
            {
                MessageBox.Show("Agregar al menos un producto al carrito","Advertencia de seguridad.",MessageBoxButtons.OK,MessageBoxIcon.Information);
                return;
            }
            if (lbl_idCliente.Text.Length < 2)
            {
                MessageBox.Show("Agregar un cliente", "Advertencia de seguridad.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            Guardar_Cotizacion();
        }
        void Guardar_Cotizacion()
        {
            RN_Cotizacion n_coti = new RN_Cotizacion();
            EN_Cotizacion e_coti = new EN_Cotizacion();
            Principal.Frm_Filtro fil = new Principal.Frm_Filtro();
            Frm_Msm_Bueno msm = new Frm_Msm_Bueno();
            Informe.Frm_PrintCoti printCoti = new Informe.Frm_PrintCoti();
            Frm_Terminar_Venta_SMS ter = new Frm_Terminar_Venta_SMS();

            try
            {
                //primero se guarda el pedido
                Guardar_Pedido();
                if (header ==1 && detalle==1)
                {
                    txt_NroCotizacion.Text = RN_TipoDoc.Sp_Listado_Tipo(11);
                    e_coti.Id_Cotiza = txt_NroCotizacion.Text;
                    e_coti.Id_Ped = txt_numPedido.Text;
                    e_coti.FechaCoti = dtp_FechaEmi.Value;
                    e_coti.Vigencia = Convert.ToInt32(nud_vigencia.Value);
                    e_coti.Condiciones = txt_condicion.Text;
                    e_coti.TotalCotiza =Convert.ToDouble(lbl_TotalPagar.Text);
                    if (chk_sinIgv.Checked == true)
                    {
                        e_coti.PrecioconIgv = "NO";
                    }
                    else
                    {
                        e_coti.PrecioconIgv = "SI";
                    }
                    e_coti.EstadoCoti = "Pendiente";
                    if (n_coti.RN_Registrar_Cotizacion(e_coti) == 1)
                    {
                        RN_TipoDoc.RN_Actualizar_SiguienteNro_correlativo(11);
                        fil.Show();
                        msm.Lbl_msm1.Text = "La Cotizacion Nro: " + txt_NroCotizacion.Text + " se guardo con exito";
                        msm.ShowDialog();
                        fil.Hide();

                        //Imprimir Cotizacion
                        fil.Show();
                        printCoti.Tag = txt_NroCotizacion.Text;

                        printCoti.RutaPPF = rutaPDF_Export_Ventas + v_rucEmisor.Trim() + "-" + txt_NroCotizacion.Text + ".pdf";
                        rutaPDF_Export_Ventas = rutaPDF_Export_Ventas + v_rucEmisor.Trim() + "-" + txt_NroCotizacion.Text + ".pdf";

                        printCoti.ShowDialog();
                        fil.Hide();

                        fil.Show();
                        ter.lbl_Documento.Text = txt_NroCotizacion.Text;
                        ter.lbl_rutaPDF.Text = rutaPDF_Export_Ventas;
                        ter.lbl_rutaXML.Text = "-";
                        ter.ShowDialog();
                        fil.Hide();


                        pnl_sinProd.Visible = true;
                        lsv_Det.Items.Clear();
                        txt_cliente.Text = "";
                        txt_NroCotizacion.Text = "";
                        txt_numPedido.Text = "";
                        lbl_idCliente.Text = "";
                        txt_condicion.Text = "";
                        chk_sinIgv.Checked = false;
                        nud_vigencia.Value = 1;
                    }
                    header = 0;
                    detalle = 0;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        int header=0;
        int detalle=0;
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
        void Guardar_Pedido()
        {
            RN_Pedido n_ped = new RN_Pedido();
            EN_Pedido e_ped = new EN_Pedido();
            EN_Det_Pedido E_det_ped = new EN_Det_Pedido();
            try
            {
                txt_numPedido.Text = RN_TipoDoc.Sp_Listado_Tipo(10);

                e_ped.Id_Ped = txt_numPedido.Text.Trim();
                e_ped.Id_Cliente = lbl_idCliente.Text.Trim();
                e_ped.SubTotal =Convert.ToDouble(lbl_subtotal.Text);
                e_ped.IgvPed= Convert.ToDouble(lbl_igv.Text);
                e_ped.TotalPed= Convert.ToDouble(lbl_TotalPagar.Text);
                e_ped.Id_Usu = Cls_UsuLogin.IdUsu.Trim().ToString();
                e_ped.TotalGancia= Convert.ToDouble(lbl_totalGanancia.Text);
                e_ped.Estado_Ped = "Activo";
                
                e_ped.Subtotal_Gravado = 0;
                e_ped.IgvGravado = 0;
                e_ped.TotalGravado = 0;


                if (n_ped.RN_Registrar_Pedido_Header(e_ped)==1)
                {
                    RN_TipoDoc.RN_Actualizar_SiguienteNro_correlativo(10);
                    E_det_ped.Id_Ped = txt_numPedido.Text;
                    for (int i = 0; i < lsv_Det.Items.Count; i++)
                    {
                        var lis = lsv_Det.Items[i];
                        E_det_ped.Id_Pro = lis.SubItems[0].Text;
                        E_det_ped.Precio = Convert.ToDouble(lis.SubItems[3].Text);//precio con igv
                        E_det_ped.Cantidad = Convert.ToDouble(lis.SubItems[2].Text);
                        E_det_ped.Importe= Convert.ToDouble(lis.SubItems[4].Text);
                        E_det_ped.Tipo_Prod= lis.SubItems[5].Text;
                        E_det_ped.Und_Medida= lis.SubItems[6].Text;
                        E_det_ped.Utilidad_Unit= Convert.ToDouble(lis.SubItems[7].Text);
                        E_det_ped.TotalUtilidad= Convert.ToDouble(lis.SubItems[8].Text)* Convert.ToDouble(lis.SubItems[2].Text);
                       
                        E_det_ped.AfectoIGV = "-";
                        E_det_ped.Precio_sinIgv = 0;
                        E_det_ped.Subtotal_sinIgv = 0;
                        E_det_ped.Igv_subtotal = 0;
                        E_det_ped.P_Cant_Original=0;
                        
                        n_ped.RN_Registrar_Pedido_Det(E_det_ped);
                    }
                    header = 1;
                    detalle = 1;
                    Principal.Frm_Filtro fil = new Principal.Frm_Filtro();
                    //Frm_Msm_Bueno msm = new Frm_Msm_Bueno();
                    //fil.Show();
                    //msm.Lbl_msm1.Text = "Se ingreso el pedido " + txt_numPedido.Text + " Satisfactoriamente.";
                    //msm.ShowDialog();
                    //fil.Hide();
                  
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:"+ex, "Guardar_Pedido", MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void txt_cliente_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Enter)
            {
                lbl_BusCli_Click(sender,e);
            }
        }

        private void lbl_BusCli_Click(object sender, EventArgs e)
        {
            Frm_ListadoClientes list = new Cliente.Frm_ListadoClientes();
            Principal.Frm_Filtro fil = new Principal.Frm_Filtro();

            fil.Show();
            list.xxvalor = txt_cliente.Text;
            list.ShowDialog();
            fil.Hide();
            if (list.Tag.ToString()=="A")
            {
                lbl_idCliente.Text = list.lblID.Text;
                txt_cliente.Text = list.lblnom.Text;
            }
            
        }
    }
}
