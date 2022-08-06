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
using Microsell_Lite.Producto;
using Microsell_Lite.Compras;


namespace Microsell_Lite.Productos
{
    //muestra todos los datos de los productos linea 497
    public partial class Frm_Listar_ProductoCompra2 : Form
    {
        RN_Producto obj = new RN_Producto();
        public Frm_Listar_ProductoCompra2()
        {
            InitializeComponent();
        }
        public string TipoVenta;
        private void Frm_Listar_Producto_Compra_Load(object sender, EventArgs e)
        {
            rb_llenarCaeSinSalir.Checked = true;
            pnl_Carrito.Visible = true;
            Configurar_listView();
            config_list_pedido();

            if (TipoVenta.Trim() == "compra" || TipoVenta.Trim() == "coti")
            {
                rb_verSinExcep.Checked = true;
            }
            else
            {
                rb_verSinExcep.Checked = false;
                rb_verSinExcep.Enabled = false;//borrar opcional
                rb_AddModoCoti.Enabled = false;
                rb_AddModoCoti.Checked = false;
            }
            Cargar_Todos_Productos();
            txt_buscar.Focus();
        }
        private void btn_cerrar_Click(object sender, EventArgs e)
        {
            this.Tag = "";
            this.Close();
        }
        private void btn_minimi_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private void pnl_titu_MouseMove(object sender, MouseEventArgs e)
        {
            Utilitario obj = new Utilitario();

            if (e.Button == MouseButtons.Left)
            {
                obj.Mover_formulario(this);

            }
        }
        private void Configurar_listView()
        {
            var lis = List_Producto;
            List_Producto.Items.Clear();
            lis.Columns.Clear();
            lis.View = View.Details;
            lis.GridLines = true;
            lis.FullRowSelect = true;
            lis.Scrollable = true;
            lis.HideSelection = false;
            //CONFIGURAR COLUMNA
            lis.Columns.Add("ID PROD.", 100, HorizontalAlignment.Left);//0
            lis.Columns.Add("NOMBRE DE PRODUCTO", 235, HorizontalAlignment.Left);//1
            lis.Columns.Add("STOCK", 107, HorizontalAlignment.Left);//2
            lis.Columns.Add("PRECIO COMPRA", 103, HorizontalAlignment.Left);//3
            lis.Columns.Add("MARCA", 200, HorizontalAlignment.Left);//4
            lis.Columns.Add("VENTA MNR", 105, HorizontalAlignment.Left);//5
            lis.Columns.Add("VENTA MYR", 105, HorizontalAlignment.Left);//6
            lis.Columns.Add("ESTADO", 90, HorizontalAlignment.Left);//7

            lis.Columns.Add("foto", 0, HorizontalAlignment.Left);////////////////////6
            lis.Columns.Add("Unidad", 0, HorizontalAlignment.Left);//////////////////8
            lis.Columns.Add("Utilidad Unidad", 0, HorizontalAlignment.Left);///////////9
            lis.Columns.Add("tipo producto", 0, HorizontalAlignment.Left);///////////11
        }

        void Agregar_producto_pedido(string xxidpro, string xxnombre, string xxund, double xxcant, double xxprecio, double xximporte, double xxutili_uni, string xxtipoproducto)
        {
            if (lsv_pedido.SelectedIndices.Count == 0)
            {
                ListViewItem item = new ListViewItem();
                item = lsv_pedido.Items.Add(xxidpro);
                item.SubItems.Add(xxnombre.Trim().ToString());
                item.SubItems.Add(xxund.Trim().ToString());//unidade de medida
                item.SubItems.Add(xxcant.ToString("###0.00"));
                item.SubItems.Add((xxprecio).ToString("###0.00")); //precio venta x menor - modificado al restar por la utilid para obtener el precio de compra - xxutili_uni
                item.SubItems.Add(xximporte.ToString("###0.00"));
                item.SubItems.Add(xxutili_uni.ToString("###0.00"));
                item.SubItems.Add(xxtipoproducto.ToString());

                // _uni_med = xpro.lsv_pedido.Items[i].SubItems[2].Text;
                //_utilid_unit = Convert.ToDouble(item.SubItems[6]);
                calcular();
            }
            else
            {
                for (int i = 0; i < lsv_pedido.Items.Count; i++)
                {
                    if (lsv_pedido.Items[i].Text.Trim() == xxidpro.Trim())
                    {
                        MessageBox.Show("El Producto " + xxnombre + " ya fue agregado al carrito", "Advertencia de seguridad", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
                ListViewItem item = new ListViewItem();
                item = lsv_pedido.Items.Add(xxidpro);
                item.SubItems.Add(xxnombre.Trim().ToString());
                item.SubItems.Add(xxund.Trim().ToString());
                item.SubItems.Add(xxcant.ToString("###0.00"));
                item.SubItems.Add(xxprecio.ToString("###0.00"));
                item.SubItems.Add(xximporte.ToString("###0.00"));
                item.SubItems.Add(xxutili_uni.ToString("###0.00"));
                item.SubItems.Add(xxtipoproducto.ToString());
                calcular();

            }

        }
        void config_list_pedido() //productos seleccionados listos para agregar craer laventa
        {
            var lis = lsv_pedido;
            lsv_pedido.Items.Clear();
            lis.Columns.Clear();
            lis.View = View.Details;
            lis.GridLines = true;
            lis.FullRowSelect = true;
            lis.Scrollable = true;
            lis.HideSelection = false;
            //CONFIGURAR COLUMNA
            lis.Columns.Add("ID producto", 0, HorizontalAlignment.Left);//0
            lis.Columns.Add("Nombre del producto", 170, HorizontalAlignment.Left);//1
            lis.Columns.Add("Und", 0, HorizontalAlignment.Left);//2
            lis.Columns.Add("Cant", 50, HorizontalAlignment.Left);//3
            lis.Columns.Add("Pre", 70, HorizontalAlignment.Left);//4
            lis.Columns.Add("Importe", 65, HorizontalAlignment.Left);//5
            lis.Columns.Add("Utilidad Unit", 0, HorizontalAlignment.Left);//6
            lis.Columns.Add("Ganancia Total", 0, HorizontalAlignment.Left);//7
            lis.Columns.Add("Tipo Producto", 0, HorizontalAlignment.Left);////////////////////8
            lis.Columns.Add("Estado", 0, HorizontalAlignment.Left);////////////////////9
        }
        void calcular()
        {//cotizador calculo
            double xtotal = 0;
            double xcantidad = 0;
            double xprecio = 0;
            double ximporte = 0;
            double xigv = 0;
            double xsubtotal = 0;

            for (int i = 0; i < lsv_pedido.Items.Count; i++)
            {
                xcantidad = Convert.ToDouble(lsv_pedido.Items[i].SubItems[3].Text);
                xprecio = Convert.ToDouble(lsv_pedido.Items[i].SubItems[4].Text); //precio de compra
                //calcular
                ximporte = xcantidad * xprecio;
                lsv_pedido.Items[i].SubItems[5].Text = ximporte.ToString("###0.00");
                //calculo del total
                xtotal = xtotal + Convert.ToDouble(lsv_pedido.Items[i].SubItems[5].Text);
            }

            lbl_total.Text = xtotal.ToString("###0.00");
            lbl_totalItems.Text = lsv_pedido.Items.Count.ToString("##00");
            btn_Pedido.Text = lsv_pedido.Items.Count.ToString("##00");
        }

        void Seleccionar_Producto_Modo_Cotizador()
        {
            Principal.Frm_Filtro fil = new Principal.Frm_Filtro();
            Frm_Solo_Cant solo = new Frm_Solo_Cant();
            Utilitarios.Frm_Advertencia adv = new Utilitarios.Frm_Advertencia();

            if (List_Producto.SelectedIndices.Count == 0)
            {
                fil.Show();
                adv.lbl_msm.Text = "Seleccionar un producto de la lista";
                adv.ShowDialog();
                fil.Hide();
                return;
            }

            else
            {

                string EstadoProducto;
                double stock;
                double xxprecom;

                var lis = List_Producto.SelectedItems[0];

                lbl_idpro.Text = lis.SubItems[0].Text;
                lbl_NomProd.Text = lis.SubItems[1].Text;
                lbl_Pre_Unt.Text = lis.SubItems[5].Text;
                lbl_precioCompra.Text = lis.SubItems[3].Text;//agregue este label
                stock = Convert.ToDouble(lis.SubItems[2].Text);
                lbl_Uti_unit.Text = lis.SubItems[10].Text;
                EstadoProducto = lis.SubItems[7].Text;//
                xxprecom = Convert.ToDouble(lis.SubItems[5].Text);
                lbl_tipoProd.Text = lis.SubItems[11].Text;
                lbl_Und.Text = lis.SubItems[9].Text;


                for (int i = 0; i < lsv_pedido.Items.Count; i++)
                {
                    if (lsv_pedido.Items[i].Text.Trim() == lbl_idpro.Text.Trim())
                    {
                        MessageBox.Show("El Producto " + lbl_NomProd.Text + " ya fue agregado al carrito", "Advertencia de seguridad", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                if (EstadoProducto.Trim() == "Eliminado")
                {
                    fil.Show();
                    MessageBox.Show("El Producto esta eliminado, no apto para esta transaccion, elige otro.", "Advertencia de Seguridad", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    fil.Hide();
                    return;
                }
                if (rb_llenarCaeSinSalir.Checked == true)
                {
                    fil.Show();
                    solo.lbl_stock.Text = stock.ToString();
                    solo.lbl_nom.Text = lbl_NomProd.Text;
                    solo.lbl_idprod.Text = lis.SubItems[0].Text;
                    solo.txt_Cantidad.Text = "1";
                    solo.lbl_tipo.Text = TipoVenta;
                    solo.ShowDialog();
                    fil.Hide();
                    if (solo.Tag.ToString() == "A")
                    {
                        lbl_Cant.Text = solo.txt_Cantidad.Text;
                        solo.txt_Cantidad.Text = "";
                        if (TipoVenta.Trim() == "compra")
                        {
                            Agregar_producto_pedido(lbl_idpro.Text,
                                                lbl_NomProd.Text,
                                                lbl_Und.Text,
                                                Convert.ToDouble(lbl_Cant.Text),
                                                Convert.ToDouble(lbl_precioCompra.Text),
                                                Convert.ToDouble(lbl_import.Text),
                                                Convert.ToDouble(lbl_Uti_unit.Text),
                                                lbl_tipoProd.Text);
                        }
                        else
                        {
                            Agregar_producto_pedido(lbl_idpro.Text,
                                                lbl_NomProd.Text,
                                                lbl_Und.Text,
                                                Convert.ToDouble(lbl_Cant.Text),
                                                Convert.ToDouble(lbl_Pre_Unt.Text),
                                                Convert.ToDouble(lbl_import.Text),
                                                Convert.ToDouble(lbl_Uti_unit.Text),
                                                lbl_tipoProd.Text);
                        }


                    }
                }
                else
                {
                    fil.Show();
                    solo.lbl_stock.Text = stock.ToString();
                    solo.lbl_nom.Text = lbl_NomProd.Text;
                    solo.txt_Cantidad.Text = "1";
                    solo.lbl_tipo.Text = TipoVenta;
                    solo.ShowDialog();
                    fil.Hide();
                    if (solo.Tag.ToString() == "A")
                    {
                        lbl_Cant.Text = solo.txt_Cantidad.Text;
                        solo.txt_Cantidad.Text = "";
                        this.Tag = "A";
                        this.Close();
                    }
                }
            }
        }
        void Seleccionar_Producto_Para_vender()
        {
            Principal.Frm_Filtro fil = new Principal.Frm_Filtro();
            Frm_Solo_Cant solo = new Frm_Solo_Cant();
            Utilitarios.Frm_Advertencia adv = new Utilitarios.Frm_Advertencia();

            if (List_Producto.SelectedIndices.Count == 0)
            {
                fil.Show();
                adv.lbl_msm.Text = "Seleccionar un producto de la lista";
                adv.ShowDialog();
                fil.Hide();
                return;
            }

            else
            {

                if (rb_AddModoCoti.Checked == true)
                {
                    Seleccionar_Producto_Modo_Cotizador();
                }
                else
                {

                    string EstadoProducto;
                    double stock;
                    double xxprecom;

                    var lis = List_Producto.SelectedItems[0];

                    lbl_idpro.Text = lis.SubItems[0].Text.Trim();
                    lbl_NomProd.Text = lis.SubItems[1].Text.Trim();
                    lbl_Pre_Unt.Text = lis.SubItems[5].Text.Trim();//3 precio de compra 4:precio a la venta
                    stock = Convert.ToDouble(lis.SubItems[2].Text.Trim());
                    lbl_Uti_unit.Text = lis.SubItems[10].Text.Trim();
                    EstadoProducto = lis.SubItems[7].Text.Trim();//
                    xxprecom = Convert.ToDouble(lis.SubItems[5].Text.Trim());
                    lbl_tipoProd.Text = lis.SubItems[11].Text.Trim();
                    
                    lbl_Und.Text = lis.SubItems[9].Text.Trim();


                    for (int i = 0; i < lsv_pedido.Items.Count; i++)
                    {
                        if (lsv_pedido.Items[i].Text.Trim() == lbl_idpro.Text.Trim())
                        {
                            MessageBox.Show("El Producto " + lbl_NomProd.Text + " ya fue agregado al carrito", "Advertencia de seguridad", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }

                    if (EstadoProducto.Trim() == "Eliminado")
                    {
                        fil.Show();
                        MessageBox.Show("El Producto esta eliminado, no apto para esta transaccion, elige otro.", "Advertencia de Seguridad", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        fil.Hide();
                        return;
                    }
                    if (lbl_tipoProd.Text.Trim() == "Producto")
                    {
                        if (stock == 0)
                        {
                            fil.Show();
                            MessageBox.Show("El Producto no tiene suficiente Stock para la venta.", "Advertencia de Seguridad", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            fil.Hide();
                            return;
                        }
                    }

                    if (rb_llenarCaeSinSalir.Checked == true)
                    {
                        fil.Show();
                        solo.lbl_stock.Text = stock.ToString();
                        solo.lbl_nom.Text = lbl_NomProd.Text;
                        solo.txt_Cantidad.Text = "1";
                        solo.lbl_idprod.Text = lbl_idpro.Text;
                        solo.lbl_tipo.Text = TipoVenta;
                        solo.ShowDialog();
                        fil.Hide();
                        if (solo.Tag.ToString() == "A")
                        {
                            lbl_Cant.Text = solo.txt_Cantidad.Text;
                            solo.txt_Cantidad.Text = "";
                            //xxUtilidad_Unit = Convert.ToDouble(lbl_Cant.Text) * (Convert.ToDouble(lbl_Pre_Unt.Text) - xxprecom);
                            //lbl_Uti_unit.Text = xxUtilidad_Unit.ToString("##0.00");

                            Agregar_producto_pedido(lbl_idpro.Text,
                                                    lbl_NomProd.Text,
                                                    lbl_Und.Text,
                                                    Convert.ToDouble(lbl_Cant.Text),
                                                    Convert.ToDouble(lbl_Pre_Unt.Text),
                                                    Convert.ToDouble(lbl_import.Text),
                                                    Convert.ToDouble(lbl_Uti_unit.Text),
                                                    lbl_tipoProd.Text);
                            //LimpiarLabels();

                        }

                    }
                    else
                    {
                        fil.Show();
                        solo.lbl_stock.Text = stock.ToString();
                        solo.lbl_nom.Text = lbl_NomProd.Text;
                        solo.txt_Cantidad.Text = "1";
                        solo.lbl_idprod.Text = lbl_idpro.Text;
                        solo.lbl_tipo.Text = TipoVenta;
                        solo.ShowDialog();
                        fil.Hide();
                        if (solo.Tag.ToString() == "A")
                        {
                            lbl_Cant.Text = solo.txt_Cantidad.Text;
                            solo.txt_Cantidad.Text = "";
                            this.Tag = "A";
                            this.Close();
                        }
                    }
                }
            }
        }

        private void Llenar_ListView(DataTable dt)
        {
            try
            {
                string idprod;
                double stockReal;
                string TipoProdServi;

                List_Producto.Items.Clear();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow dr = dt.Rows[i];
                    idprod = dr["Id_Pro"].ToString();
                    stockReal = Convert.ToDouble(dr["Stock_Actual"]);
                    TipoProdServi = dr["TipoProdcto"].ToString();

                    if (rb_verSinExcep.Checked == true)
                    {
                        if (TipoProdServi != "Servicio" || TipoVenta.Trim() == "coti")
                        {
                            ListViewItem list = new ListViewItem(dr["Id_Pro"].ToString().Trim());
                            list.SubItems.Add(dr["Descripcion_Larga"].ToString());
                            list.SubItems.Add(dr["Stock_Actual"].ToString());
                            list.SubItems.Add(dr["Pre_CompraS"].ToString());
                            list.SubItems.Add(dr["Marca"].ToString());
                            list.SubItems.Add(dr["Pre_vntaxMenor"].ToString());
                            list.SubItems.Add(dr["Pre_vntaxMayor"].ToString());
                            list.SubItems.Add(dr["Estado_Pro"].ToString());
                            list.SubItems.Add(dr["Foto"].ToString());
                            list.SubItems.Add(dr["UndMedida"].ToString());
                            list.SubItems.Add(dr["UtilidadUnit"].ToString());
                            list.SubItems.Add(dr["TipoProdcto"].ToString());
                            List_Producto.Items.Add(list);// SI NO SE PONE ESTO EL LIST VIEW NO SE LLENARA
                            pintar_listView();
                            lblcont.Text = List_Producto.Items.Count.ToString();
                        }
                    }
                    else
                    {//va agregar solo los que tienen stock mayor a 0
                        if (stockReal > 0)
                        {
                            ListViewItem list = new ListViewItem(dr["Id_Pro"].ToString().Trim());//0
                            list.SubItems.Add(dr["Descripcion_Larga"].ToString());//1
                            list.SubItems.Add(dr["Stock_Actual"].ToString());//2
                            list.SubItems.Add(dr["Pre_CompraS"].ToString());//3
                            list.SubItems.Add(dr["Marca"].ToString());//4
                            list.SubItems.Add(dr["Pre_vntaxMenor"].ToString());//5
                            list.SubItems.Add(dr["Pre_vntaxMayor"].ToString());//6
                            list.SubItems.Add(dr["Estado_Pro"].ToString());//7
                            list.SubItems.Add(dr["Foto"].ToString());//8
                            list.SubItems.Add(dr["UndMedida"].ToString());//9
                            list.SubItems.Add(dr["UtilidadUnit"].ToString());//10
                            list.SubItems.Add(dr["TipoProdcto"].ToString());//11
                            List_Producto.Items.Add(list);// SI NO SE PONE ESTO EL LIST VIEW NO SE LLENARA
                            pintar_listView();
                            lblcont.Text = List_Producto.Items.Count.ToString();
                        }

                    }
                }

            }
            catch (Exception)
            {

                throw;
            }


        }
        public void LimpiarLabels()
        {
            lbl_idpro.Text = "";
            lbl_NomProd.Text = "";
            lbl_Und.Text = "0";
            lbl_Cant.Text = "0";
            lbl_Pre_Unt.Text = "0";
            lbl_import.Text = "0";
            lbl_Uti_unit.Text = "0";
            lbl_tipoProd.Text = "";
        }
        private void Cargar_Todos_Productos()
        {
            DataTable dt = new DataTable();
            dt = obj.RN_Mostrar_Todas_Producto();//13 TipoProdcto
            if (dt.Rows.Count >= 0)
            {
                Llenar_ListView(dt);
            }
            else
            {
                List_Producto.Items.Clear();
            }
        }
        private void Buscar_Producto(string valor)
        {
            DataTable dt = new DataTable();
            dt = obj.RN_Buscar_Producto(valor);
            if (dt.Rows.Count > 0)
            {
                Llenar_ListView(dt);
                pnl_msn.Visible = false;
                pb_Product.Visible = true;
                pnl_Carrito.Visible = true;
                lsv_pedido.Visible = true;
            }
            else
            {
                List_Producto.Items.Clear();
                pnl_msn.Visible = true;
                pb_Product.Visible = false;
                pnl_Carrito.Visible = false;
                lsv_pedido.Visible = false;
            }
        }
        private void bt_copiarIDProveedor_Click(object sender, EventArgs e)
        {
            Principal.Frm_Filtro fil = new Principal.Frm_Filtro();
            Utilitarios.Frm_Advertencia adv = new Utilitarios.Frm_Advertencia();

            if (List_Producto.SelectedItems.Count == 0)
            {
                fil.Show();
                adv.lbl_msm.Text = "Seleccionar el Item que deseas copiar.";
                adv.ShowDialog();
                fil.Hide();
                //fil.Close();
            }
            else
            {
                var lis = List_Producto.SelectedItems[0];
                string idProv = lis.SubItems[0].Text;
                Clipboard.Clear();
                Clipboard.SetText(idProv.Trim());
            }
        }
        public void pintar_listView()
        {
            //pintar Horizontal
            /*int cont = 1;
           
             for (int i = 0; i < List_Producto.Items.Count; i++)
             {
                 if (cont % 2 != 0)
                 {
                     List_Producto.Items[i].BackColor = Color.MintCream;
                 }
                 i++;
             }*/

            //pintar Horizontal
            for (int i = 0; i < List_Producto.Items.Count; i++)
            {
                List_Producto.Items[i].SubItems[5].BackColor = Color.LightGray;
                List_Producto.Items[i].SubItems[2].BackColor = Color.Azure;
                List_Producto.Items[i].SubItems[3].BackColor = Color.Ivory;
                List_Producto.Items[i].SubItems[4].BackColor = Color.MintCream;

                List_Producto.Items[i].SubItems[2].Font = new System.Drawing.Font("Verdana", 10, FontStyle.Bold);
                List_Producto.Items[i].SubItems[5].Font = new System.Drawing.Font("Verdana", 10, FontStyle.Bold);

                List_Producto.Items[i].UseItemStyleForSubItems = false;
            }


        }
        private void txt_buscar_KeyDown(object sender, KeyEventArgs e)
        {
            Buscar_Producto(txt_buscar.Text);
        }
        private void txt_buscar_KeyUp(object sender, KeyEventArgs e)
        {
            Buscar_Producto(txt_buscar.Text);
        }
        private void List_Producto_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Seleccionar_Producto_Para_vender();
        }
        private void List_Producto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Seleccionar_Producto_Para_vender();
            }
        }
        private void txt_buscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                if (List_Producto.Items.Count > 0)
                {
                    List_Producto.Focus();
                    List_Producto.Items[0].Selected = true;
                }
            }
        }
        private void Frm_Listar_Producto_Compra_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Tag = "";
                this.Close();
            }
            if (e.KeyCode == Keys.F5)
            {
                Btn_Carrito_Click(sender, e);
            }
            if ((int)(e.KeyData) == (int)(Keys.Control) + (int)(Keys.A))
            {
                txt_buscar.Focus();
            }
        }

        private void rb_verSinExcep_OnChange(object sender, EventArgs e)
        {
            if (rb_verSinExcep.Checked == true)
            {
                Cargar_Todos_Productos();
            }
            else
            {
                Cargar_Todos_Productos();
            }
        }

        private void lsv_pedido_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Principal.Frm_Filtro fil = new Principal.Frm_Filtro();

            if (lsv_pedido.SelectedIndices.Count == 0)
            {
                MessageBox.Show("Seleccione un producto para eliminar del carrito.", "Advertencia de seguridad", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                int i;
                var lis = lsv_pedido.SelectedItems[0];
                for (i = lsv_pedido.SelectedItems.Count - 1; i >= 0; i--)
                {
                    lsv_pedido.Items.Remove(lsv_pedido.SelectedItems[i]);
                }
                calcular();

            }
        }

        private void btn_Pedido_Click(object sender, EventArgs e)
        {
            /*
            if (pnl_Carrito.Visible == true)
            {
                pnl_Carrito.Visible = false;
            }
            else
            {
                pnl_Carrito.Visible = true;
            }
            */
        }

        private void rb_llenarCaeSinSalir_OnChange(object sender, EventArgs e)
        {
        }

        private void Btn_Carrito_Click(object sender, EventArgs e)
        {
            if (lsv_pedido.Items.Count > 0)
            {
                rb_llenarCaeSinSalir.Checked = true;
                this.Tag = "A";
                this.Close();
            }
        }

        private void btn_add2_Click(object sender, EventArgs e)
        {
            Seleccionar_Producto_Para_vender();
        }
        string xfotoRuta;
        private void List_Producto_MouseClick(object sender, MouseEventArgs e)
        {
            DataTable dt = new DataTable();
            RN_Producto ne = new RN_Producto();
            try
            {
                var lis = List_Producto.SelectedItems[0];

                string idpro = lis.SubItems[0].Text;

                dt = ne.RN_Buscar_Producto(idpro);

                xfotoRuta = Convert.ToString(dt.Rows[0]["Foto"]);
                pb_Product.Load(xfotoRuta);
                pb_Product.Visible = true;
                pnl_Carrito.Visible = true;
                lsv_pedido.Visible = true;
            }
            catch (Exception)
            {
                MessageBox.Show("No se encontro la foto del producto en la ruta: " + xfotoRuta, "Error de Archivo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
