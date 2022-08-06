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
using Microsell_Lite.Utilitarios;
using Microsell_Lite.Proveedor;
using Microsell_Lite.Compras;
using Microsell_Lite.Principal;

namespace Microsell_Lite.Producto
{
    public partial class Frm_AddProducto : Form
    {
        RN_Producto n_prod = new RN_Producto();
        EN_Producto e_prod = new EN_Producto();
        public Frm_AddProducto()
        {
            InitializeComponent();
        }
        void listar_ComboBox_UnidadMedida()
        {
            DataTable dt = new DataTable();
            RN_Producto n_prod = new RN_Producto();
            dt = n_prod.RN_Mostrar_UnidMedida();
            if (dt.Rows.Count > 0)
            {
                var cbb = CBB_Medida;
                cbb.DataSource = dt;
                cbb.DisplayMember = "descripcion";
                cbb.ValueMember = "codigo";
                cbb.SelectedIndex = 8;
            }
        }

        private void Frm_Reg_Prod_Load(object sender, EventArgs e)
        {
            //txt_idProd.Focus();
            CBB_Medida.DropDownStyle = ComboBoxStyle.DropDownList;
            CBB_tipProduc.DropDownStyle = ComboBoxStyle.DropDownList;

            lbl_numtipicambio.Text = RN_TipoDoc.Sp_Listado_TipoCambio(7).ToString("###0.00");

            listar_ComboBox_UnidadMedida();

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

        String xfotoRuta;

        OpenFileDialog OpenFileDialog1 = new OpenFileDialog();

        private bool validar_textbox()
        {
            Principal.Frm_Filtro fil = new Principal.Frm_Filtro();
            Frm_Advertencia adv = new Frm_Advertencia();
            
            //if (txt_idProd.Text.Trim().Length <=0 ){fil.Show();adv.lbl_msm.Text = "Ingresa o Genera el Id del Productor";adv.ShowDialog();fil.Hide();txt_idProd.Focus(); return false;}
            if (txt_descriProd.Text.Trim().Length < 2 || txt_descriProd.Text == "Descripcion del Producto") { fil.Show(); adv.lbl_msm.Text = "Ingresa o Genera el Nombre del Producto"; adv.ShowDialog(); fil.Hide(); txt_descriProd.Focus(); return false; }
            if (txt_prove.Text.Trim().Length < 2) { fil.Show(); adv.lbl_msm.Text = "Ingresa o Genera la Descripcion del Producto"; adv.ShowDialog(); fil.Hide(); txt_prove.Focus(); return false; }
            if (txt_Marca.Text.Trim().Length < 2) { fil.Show(); adv.lbl_msm.Text = "Ingresa o Genera la Marca"; adv.ShowDialog(); fil.Hide(); txt_Marca.Focus(); return false; }
            if (txt_catego.Text.Trim().Length < 2) { fil.Show(); adv.lbl_msm.Text = "Ingresa o Genera la Categoria"; adv.ShowDialog(); fil.Hide(); txt_catego.Focus(); return false; }
            if (txt_PesoUnit.Text.Trim().Length < 1) { fil.Show(); adv.lbl_msm.Text = "Ingrese el peso por unidad"; adv.ShowDialog(); fil.Hide(); txt_PesoUnit.Text = "0"; return false; }
            if (CBB_tipProduc.SelectedIndex == -1) { fil.Show(); adv.lbl_msm.Text = "Selecciona el tipo de Producto "; adv.ShowDialog(); fil.Hide(); CBB_tipProduc.Focus(); return false; }
            if (CBB_Medida.SelectedIndex == -1) { fil.Show(); adv.lbl_msm.Text = "Selecciona el tipo de unidad de Medida"; adv.ShowDialog(); fil.Hide(); CBB_Medida.Focus(); return false; }
            if (txt_precioCompraSol.Text.Trim().Length <= 0) { fil.Show(); adv.lbl_msm.Text = "Ingresa el precio de compra en soles"; adv.ShowDialog(); fil.Hide(); txt_precioCompraSol.Focus(); return false; }
            if (txt_frankUtilidad.Text.Trim().Length < 1) { fil.Show(); adv.lbl_msm.Text = "Ingresa el margen"; adv.ShowDialog(); fil.Hide(); txt_frankUtilidad.Focus(); return false; }
            if (txt_precioVentaMayor.Text.Trim().Length < 1) { fil.Show(); adv.lbl_msm.Text = "Ingresa el precio de venta al por mayor"; adv.ShowDialog(); fil.Hide(); txt_precioVentaMayor.Text = "0"; return false; }

            return true;
        }
        private void Registrar_Producto()
        {
            try
            {//txt_Marca

                int rpt;
                if (CheckB_CodBarra.Checked == true)
                {
                    Principal.Frm_Filtro fil = new Principal.Frm_Filtro();
                    Frm_Advertencia adv = new Frm_Advertencia();
                    if (txt_idProd.Text.Trim().Length <= 0) { fil.Show(); adv.lbl_msm.Text = "Ingresa o Genera el Id del Producto"; adv.ShowDialog(); fil.Hide(); txt_idProd.Focus(); return; }
                    e_prod.Idpro = txt_idProd.Text;
                }
                else
                {
                    txt_idProd.Text = RN_TipoDoc.Sp_Listado_Tipo(4).ToString();
                    e_prod.Idpro = txt_idProd.Text;
                }
                e_prod.Descripcion = txt_descriProd.Text;
                
                e_prod.Pre_compraSol = Convert.ToDouble(txt_precioCompraSol.Text);
                e_prod.Pre_CompraDolar = Convert.ToDouble(txt_PrecioCompDolar.Text);

                if (CBB_tipProduc.SelectedIndex == 0)
                {
                    e_prod.StockActual = 0;
                    e_prod.Pre_Venta_Menor = Convert.ToDouble(txt_precioVentaMenor.Text);
                    
                    e_prod.Frank = Convert.ToDouble(txt_frankUtilidad.Text);
                }
                else
                {
                    e_prod.StockActual = 100;
                    e_prod.Pre_Venta_Menor = precioServicio;
                    e_prod.Frank = 1;
                }

                e_prod.Idprove = lbl_idprov.Text;
                e_prod.IdMar = Convert.ToInt32(lbl_IDMarca.Text);
                e_prod.IdCat = Convert.ToInt32(lbl_idCategoria.Text);

                e_prod.Pre_Venta_Mayor = Convert.ToDouble(txt_precioVentaMayor.Text);
                e_prod.Pre_Venta_Dolar = Convert.ToDouble(txt_precioVentaMenDolar.Text);
                e_prod.UndMdida = CBB_Medida.SelectedValue.ToString();
                e_prod.PesoUnit = Convert.ToDouble(txt_PesoUnit.Text);
                e_prod.Utilidad = Convert.ToDouble(txt_Utili.Text);
                e_prod.TipoProd = CBB_tipProduc.SelectedItem.ToString();
                e_prod.ValorporProd = 0;
                e_prod.Foto = xfotoRuta;

                rpt = n_prod.RN_Registrar_Producto(e_prod);
                if (rpt == 1)
                {
                    if (CheckB_CodBarra.Checked == false)
                    {
                        RN_TipoDoc.RN_Actualizar_SiguienteNro_correlativo(4);
                    }

                    if (CBB_tipProduc.SelectedIndex == 0)
                    {
                        Registrar_Kardex(txt_idProd.Text);
                        Principal.Frm_Filtro fil = new Principal.Frm_Filtro();
                        fil.Show();
                        this.Tag = "A";
                        MessageBox.Show("Se registro el Producto correctamente:", "PRODUCTO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Limpiar_text();
                        fil.Hide();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Se registro el Servicio: " + txt_descriProd.Text + " correctamente, con un Costo de Servicio de: S/." + precioServicio + " Nuevos Soles", "SERVICIO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //CBB_tipProduc.Focus();
                        this.Tag = "";
                        this.Close();
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al Guardar msj:" + ex, "PRODUCTO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void Registrar_Kardex(string idprod)
        {
            RN_Kardex n_kar = new RN_Kardex();
            EN_Kardex e_kar = new EN_Kardex();

            try
            {
                if (n_kar.RN_Sp_Ver_sihay_Kardex(idprod) == true)
                {
                    return;//ya tiene kardex no hace falta crear otro.

                }
                else
                {

                    string idKardex = RN_TipoDoc.Sp_Listado_Tipo(6);
                    n_kar.RN_Crear_Kardex(idKardex, idprod, lbl_idprov.Text);

                    //Detalle del Kardex
                    e_kar.Id_Krdx = idKardex;
                    e_kar.Item = 1;
                    e_kar.Doc_Soport = "000";
                    e_kar.Det_Operacion = "Inicio de Kardex";

                    //Entradas
                    e_kar.Cantidad_In = 0;
                    e_kar.Precio_Unt_In = 0;
                    e_kar.Costo_Total_In = 0;
                    //Salidas
                    e_kar.Cantidad_Out = 0;
                    e_kar.Precio_Unt_Out = 0;
                    e_kar.Importe_Total_Out = 0;
                    //Saldos
                    e_kar.Cantidad_Saldo = 0;
                    e_kar.Promedio = 0;
                    e_kar.Costo_Total_Saldo = 0;
                    if (n_kar.RN_Registrar_det_Kardex(e_kar) == 1)
                    {
                        //Actualizar el siguiente numero correlativo
                        RN_TipoDoc.RN_Actualizar_SiguienteNro_correlativo(6);
                    }


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al Registrar Kardex:" + ex, "KARDEX", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void Limpiar_text()
        {
            txt_idProd.Text = "";
            txt_descriProd.Text = "";
            txt_frankUtilidad.Text = "";
            txt_precioCompraSol.Text = "";
            txt_PrecioCompDolar.Text = "";
            CBB_Medida.SelectedIndex = 8;
            e_prod.StockActual = 0;
            e_prod.Idprove = lbl_idprov.Text;
            e_prod.IdCat = Convert.ToInt32(lbl_idCategoria.Text);
            e_prod.Pre_Venta_Menor = Convert.ToDouble(txt_precioVentaMenor.Text);
            e_prod.Pre_Venta_Mayor = Convert.ToDouble(txt_precioVentaMayor.Text);
            e_prod.Pre_Venta_Dolar = Convert.ToDouble(txt_precioVentaMenDolar.Text);
            e_prod.UndMdida = "NIU";
            e_prod.PesoUnit = Convert.ToDouble(txt_PesoUnit.Text);
            e_prod.Utilidad = Convert.ToDouble(txt_Utili.Text);
            e_prod.TipoProd = CBB_tipProduc.SelectedItem.ToString();

            pb_Product.Load(Application.StartupPath + @"\focus.png");
            xfotoRuta = Application.StartupPath + @"\focus.png";
        }

        private void btn_listo_Click(object sender, EventArgs e)
        {
            if (validar_textbox() == true)
            {
                Registrar_Producto();
            }
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Tag = "";
            this.Close();
        }

        private void Pic_Logo_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pb_buscarProv_Click(object sender, EventArgs e)
        {
            txt_descriProd.Focus();
            Principal.Frm_Filtro fil = new Principal.Frm_Filtro();
            Frm_ListadoProveedor lis = new Frm_ListadoProveedor();

            fil.Show();
            lis.ShowDialog();
            fil.Hide();

            if (lis.Tag.ToString() == "A")
            {
                txt_prove.Text = lis.lbl_nomb.Text;
                lbl_idprov.Text = lis.lbl_id.Text;
            }
        }

        private void Pb_Marca_Click(object sender, EventArgs e)
        {
            txt_Marca.Focus();
            Principal.Frm_Filtro fil = new Principal.Frm_Filtro();
            Utilitarios.Frm_Marca mar = new Utilitarios.Frm_Marca();

            fil.Show();
            mar.ShowDialog();
            fil.Hide();

            if (mar.Tag.ToString() == "A")
            {
                txt_Marca.Text = mar.txt_NomMarca.Text;
                lbl_IDMarca.Text = mar.txt_IDMarca.Text;
            }
        }

        private void pb_categoria_Click(object sender, EventArgs e)
        {
            txt_catego.Focus();
            Principal.Frm_Filtro fil = new Principal.Frm_Filtro();
            Utilitarios.Frm_Categoria cat = new Utilitarios.Frm_Categoria();

            fil.Show();
            cat.ShowDialog();
            fil.Hide();

            if (cat.Tag.ToString() == "A")
            {
                txt_catego.Text = cat.txt_NomCateg.Text;
                lbl_idCategoria.Text = cat.txtCateg.Text;
            }
        }

        private void lk_BuscarImagen_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var FilePath = string.Empty;
            try
            {
                if (OpenFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    xfotoRuta = OpenFileDialog1.FileName;
                    pb_Product.Load(xfotoRuta);
                }
            }
            catch (Exception)
            {
                pb_Product.Load(Application.StartupPath + @"\focus.png");
                xfotoRuta = Application.StartupPath + @"\focus.png";
                MessageBox.Show("Error al guardar el logo", "LOGO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txt_precioCompra_TextChanged(object sender, EventArgs e)
        {
            txt_precioCompraSol.Text = txt_precioCompraSol.Text.Replace(",", ".");
            txt_precioCompraSol.SelectionStart = txt_precioCompraSol.Text.Length;
            txt_frankUtilidad_TextChanged(sender, e);
        }

        private void txt_precioCompra_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilitario uti = new Utilitario();
            e.KeyChar = Convert.ToChar(uti.SoloNumeros(e.KeyChar));
        }

        private void txt_frankUtilidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            txt_precioCompra_KeyPress(sender, e);
        }

        private void txt_precioVentaMenor_KeyPress(object sender, KeyPressEventArgs e)
        {
            txt_precioCompra_KeyPress(sender, e);
        }

        private void txt_precioVentaMayor_KeyPress(object sender, KeyPressEventArgs e)
        {
            txt_precioCompra_KeyPress(sender, e);
        }

        private void txt_precioVentaDolar_KeyPress(object sender, KeyPressEventArgs e)
        {
            txt_precioCompra_KeyPress(sender, e);
        }

        private void txt_PrecioDolar_KeyPress(object sender, KeyPressEventArgs e)
        {
            txt_precioCompra_KeyPress(sender, e);
        }

        private void txt_PrecioUnit_KeyPress(object sender, KeyPressEventArgs e)
        {
            txt_precioCompra_KeyPress(sender, e);
        }

        private void txt_PrecioDolar_TextChanged(object sender, EventArgs e)
        {
            txt_PrecioCompDolar.Text = txt_PrecioCompDolar.Text.Replace(",", ".");
            txt_PrecioCompDolar.SelectionStart = txt_PrecioCompDolar.Text.Length;

            //Calcular Precio Venta en soles

            try
            {
                if (txt_frankUtilidad.Text.Trim() == "") return;
                if (txt_PrecioCompDolar.Text.Trim() == "") return;

                double Precom_sol = 0;
                double preVenta_dolar = 0;
                double Utilidad_unid = 0;

                //Hallar el precio de compra en soles
                Precom_sol = Convert.ToDouble(txt_PrecioCompDolar.Text) * Convert.ToDouble(lbl_numtipicambio.Text);
                txt_precioCompraSol.Text = Precom_sol.ToString("###0.00");

                //Hallar PRECIO DE VENTA AL POR MENOR
                Precom_sol = Convert.ToDouble(txt_precioCompraSol.Text) * Convert.ToDouble(txt_frankUtilidad.Text);
                txt_precioVentaMenor.Text = Precom_sol.ToString("###0.00");

                //precio de venta en dolar
                preVenta_dolar = Convert.ToDouble(txt_PrecioCompDolar.Text) * Convert.ToDouble(txt_frankUtilidad.Text);
                txt_precioVentaMenDolar.Text = preVenta_dolar.ToString("###0.00");

                //Calcular Utilidad
                Utilidad_unid = Convert.ToDouble(txt_precioVentaMenor.Text) - Convert.ToDouble(txt_precioCompraSol.Text);
                txt_Utili.Text = Utilidad_unid.ToString("###0.00");

            }
            catch (Exception ex)
            {
                string sms = ex.Message;
            }
            if (true)
            {
            }
            else
            {

            }

        }

        private void txt_frankUtilidad_TextChanged(object sender, EventArgs e)
        {
            txt_frankUtilidad.Text = txt_frankUtilidad.Text.Replace(",", ".");
            txt_frankUtilidad.SelectionStart = txt_frankUtilidad.Text.Length;

            try
            {
                if (txt_frankUtilidad.Text.Trim() == "") return;
                if (txt_precioCompraSol.Text.Trim() == "") return;

                double Precom_sol = 0;
                double Utilidad_unid = 0;
                double preVenta_dolar = 0;

                Precom_sol = Convert.ToDouble(txt_precioCompraSol.Text) * Convert.ToDouble(txt_frankUtilidad.Text);
                txt_precioVentaMenor.Text = Precom_sol.ToString("###0.00");

                //Calcular Utilidad
                Utilidad_unid = Convert.ToDouble(txt_precioVentaMenor.Text) - Convert.ToDouble(txt_precioCompraSol.Text);
                txt_Utili.Text = Utilidad_unid.ToString("###0.00");

                //precio de venta en dolar
                preVenta_dolar = Convert.ToDouble(txt_PrecioCompDolar.Text) * Convert.ToDouble(txt_frankUtilidad.Text);
                txt_precioVentaMenDolar.Text = preVenta_dolar.ToString("###0.00");
            }
            catch (Exception ex)
            {
                string sms = ex.Message;
            }

            if (true)
            {

            }
            else
            {

            }


        }

        private void txt_precioVentaMenor_TextChanged(object sender, EventArgs e)
        {
            txt_precioVentaMenor.Text = txt_precioVentaMenor.Text.Replace(",", ".");
            txt_precioVentaMenor.SelectionStart = txt_precioVentaMenor.Text.Length;
        }

        private void txt_precioVentaMayor_TextChanged(object sender, EventArgs e)
        {
            txt_precioVentaMayor.Text = txt_precioVentaMayor.Text.Replace(",", ".");
            txt_precioVentaMayor.SelectionStart = txt_precioVentaMayor.Text.Length;
        }

        private void txt_precioVentaDolar_TextChanged(object sender, EventArgs e)
        {
            txt_precioVentaMenDolar.Text = txt_precioVentaMenDolar.Text.Replace(",", ".");
            txt_precioVentaMenDolar.SelectionStart = txt_precioVentaMenDolar.Text.Length;
        }

        private void txt_PrecioUnit_TextChanged(object sender, EventArgs e)
        {
            txt_PesoUnit.Text = txt_PesoUnit.Text.Replace(",", ".");
            txt_PesoUnit.SelectionStart = txt_PesoUnit.Text.Length;
        }

        private void CheckB_PrecioDolar_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckB_PrecioDolar.Checked == true)
            {//txt_precioVentaMayor
                txt_PrecioCompDolar.Enabled = true;
                txt_precioCompraSol.Enabled = false;
                txt_precioVentaMenor.Enabled = false;
                //txt_precioVentaMayor.Enabled = false;
                txt_precioVentaMenDolar.Enabled = false;
                txt_Utili.Text = "0";
                txt_precioCompraSol.Text = "0";
                txt_frankUtilidad.Text = "0";
                txt_precioVentaMenor.Text = "0";
                txt_precioVentaMayor.Text = "0";
                //txt_precioVentaMenDolar.Text = "0";
                txt_PrecioCompDolar.Text = "0";
                txt_PrecioCompDolar.Focus();

            }
            else
            {
                Limpiar_Precio();
            }
        }
        private void Limpiar_Precio()
        {//txt_precioVentaMayor
            txt_Utili.Text = "0";
            txt_precioCompraSol.Text = "0";
            txt_frankUtilidad.Text = "0";
            txt_precioVentaMenor.Text = "0";
            txt_precioVentaMayor.Text = "0";
            txt_precioVentaMenDolar.Text = "0";
            txt_PrecioCompDolar.Enabled = false;
            txt_precioCompraSol.Enabled = true;
            txt_PrecioCompDolar.Text = "0";
            txt_precioCompraSol.Focus();


        }

        private void txt_precioCompraSol_Click(object sender, EventArgs e)
        {
            if (txt_precioCompraSol.Text == "0")
            {
                txt_precioCompraSol.Text = "";
            }

        }

        private void txt_frankUtilidad_Click(object sender, EventArgs e)
        {
            if (txt_frankUtilidad.Text == "0")
            {
                txt_frankUtilidad.Text = "";
            }

        }

        private void txt_precioVentaMayor_MouseClick(object sender, MouseEventArgs e)
        {
            if (txt_precioVentaMayor.Text == "0")
            {
                txt_precioVentaMayor.Text = "";
            }

        }

        private void pb_Product_Click(object sender, EventArgs e)
        {

        }

        private void CheckB_CodBarra_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckB_CodBarra.Checked == true)
            {
                txt_idProd.Enabled = true;
            }
            else
            {
                txt_idProd.Enabled = false;
            }
        }
        private double precioServicio;
        private void CBB_tipProduc_SelectedIndexChanged(object sender, EventArgs e)
        {
            Frm_Solo_Precio soloPrecio = new Frm_Solo_Precio();
            Frm_Filtro fil = new Frm_Filtro();

            if (CBB_tipProduc.SelectedIndex == 0)
            {
                txt_frankUtilidad.Text = "0";
                lbl_Tipo_Producto.Text = "Costo y/o Precio Del Producto";
                label16.Text = "Precio Compra S/.";
                txt_precioCompraSol.Enabled = true;
                CheckB_PrecioDolar.Enabled = true;
                txt_frankUtilidad.Enabled = true;
                txt_precioVentaMayor.Enabled = true;
                txt_precioVentaMenor.Text = "0";
            }
            else
            {
                txt_frankUtilidad.Text = "1";
                lbl_Tipo_Producto.Text = "Precio Del Servicio";
                label16.Text = "Precio del Servicio";
                BloquearServicio();
                fil.Show();
                soloPrecio.txt_cant.Focus();
                soloPrecio.ShowDialog();

                if (soloPrecio.Tag.ToString() == "A")
                {
                    precioServicio = Convert.ToDouble(soloPrecio.txt_cant.Text);
                    txt_precioVentaMenor.Text = precioServicio.ToString();
                }
                fil.Hide();
            }

        }
        void BloquearServicio()
        {
            txt_precioCompraSol.Enabled = false;
            CheckB_PrecioDolar.Enabled = false;
            txt_frankUtilidad.Enabled = false;
            txt_precioVentaMayor.Enabled = false;
        }
        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void txt_descriProd_Enter(object sender, EventArgs e)
        {
            if (txt_descriProd.Text == "Descripcion del Producto")
            {
                txt_descriProd.Text = "";
                txt_descriProd.ForeColor = Color.LightGray;
            }
        }

        private void txt_descriProd_Leave(object sender, EventArgs e)
        {
            if (txt_descriProd.Text == "")
            {
                txt_descriProd.Text = "Descripcion del Producto";
                txt_descriProd.ForeColor = Color.DimGray;
            }
        }


        private void txt_precioCompraSol_Enter(object sender, EventArgs e)
        {
            if (txt_precioCompraSol.Text == "0")
            {
                txt_precioCompraSol.Text = "";
                txt_precioCompraSol.ForeColor = Color.LightGray;
            }
        }

        private void txt_frankUtilidad_Enter(object sender, EventArgs e)
        {
            if (txt_frankUtilidad.Text == "0")
            {
                txt_frankUtilidad.Text = "";
                txt_frankUtilidad.ForeColor = Color.LightGray;
            }
        }

        private void txt_PrecioCompDolar_Enter(object sender, EventArgs e)
        {
            if (txt_PrecioCompDolar.Text == "0")
            {
                txt_PrecioCompDolar.Text = "";
                txt_PrecioCompDolar.ForeColor = Color.LightGray;
            }
        }

        private void txt_precioVentaMayor_Enter(object sender, EventArgs e)
        {
            if (txt_precioVentaMayor.Text == "0")
            {
                txt_precioVentaMayor.Text = "";
                txt_precioVentaMayor.ForeColor = Color.LightGray;
            }
        }

        private void txt_precioCompraSol_Leave(object sender, EventArgs e)
        {
            if (txt_precioCompraSol.Text == "")
            {
                txt_precioCompraSol.Text = "0";
                txt_precioCompraSol.ForeColor = Color.DimGray;
            }
        }

        private void txt_frankUtilidad_Leave(object sender, EventArgs e)
        {
            if (txt_frankUtilidad.Text == "")
            {
                txt_frankUtilidad.Text = "0";
                txt_frankUtilidad.ForeColor = Color.DimGray;
            }
        }

        private void txt_precioVentaMayor_Leave(object sender, EventArgs e)
        {
            if (txt_precioVentaMayor.Text == "")
            {
                txt_precioVentaMayor.Text = "0";
                txt_precioVentaMayor.ForeColor = Color.DimGray;
            }
        }

        private void txt_PrecioCompDolar_Leave(object sender, EventArgs e)
        {
            if (txt_PrecioCompDolar.Text == "")
            {
                txt_PrecioCompDolar.Text = "0";
                txt_PrecioCompDolar.ForeColor = Color.DimGray;
            }
        }

        private void txt_precioCompraSol_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilitario uti = new Utilitario();
            e.KeyChar = Convert.ToChar(uti.SoloNumeros(e.KeyChar));
        }

        private void txt_frankUtilidad_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            Utilitario uti = new Utilitario();
            e.KeyChar = Convert.ToChar(uti.SoloNumeros(e.KeyChar));
        }

        private void txt_precioVentaMayor_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            Utilitario uti = new Utilitario();
            e.KeyChar = Convert.ToChar(uti.SoloNumeros(e.KeyChar));
        }

        private void txt_PrecioCompDolar_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilitario uti = new Utilitario();
            e.KeyChar = Convert.ToChar(uti.SoloNumeros(e.KeyChar));
        }
    }
}
