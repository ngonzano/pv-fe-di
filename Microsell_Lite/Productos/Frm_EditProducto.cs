using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsell_Lite.Utilitarios;
using SPV_Capa_Negocio;
using SPV_Capa_Entidad;
using Microsell_Lite.Proveedor;

namespace Microsell_Lite.Producto
{
    public partial class Frm_EditProducto : Form
    {
        RN_Producto n_prod = new RN_Producto();
        EN_Producto e_prod = new EN_Producto();
        public Frm_EditProducto()
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
                var cbb = CBB_Medida2;
                cbb.DataSource = dt;
                cbb.DisplayMember = "descripcion";
                cbb.ValueMember = "codigo";
                cbb.SelectedIndex = 8;
            }
        }
        private void Frm_Reg_Prod_Load(object sender, EventArgs e)
        {
            listar_ComboBox_UnidadMedida();
            txt_idProd2.Focus();
            CBB_Medida2.DropDownStyle = ComboBoxStyle.DropDownList;
            CBB_tipProduc2.DropDownStyle = ComboBoxStyle.DropDownList;

            lbl_numtipicambio.Text = RN_TipoDoc.Sp_Listado_TipoCambio(7).ToString("###0.00");

            Buscar_Producto_Edit(this.Tag.ToString());
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
            if (txt_idProd2.Text.Trim().Length <= 0) { fil.Show(); adv.lbl_msm.Text = "Ingresa o Genera el Id del Productor"; adv.ShowDialog(); fil.Hide(); txt_idProd2.Focus(); return false; }
            if (txt_descriProd2.Text.Trim().Length < 2) { fil.Show(); adv.lbl_msm.Text = "Ingresa o Genera el Nombre del Producto"; adv.ShowDialog(); fil.Hide(); txt_descriProd2.Focus(); return false; }
            if (txt_prove2.Text.Trim().Length < 2) { fil.Show(); adv.lbl_msm.Text = "Ingresa o Genera la Descripcion del Producto"; adv.ShowDialog(); fil.Hide(); txt_prove2.Focus(); return false; }
            if (txt_Marca2.Text.Trim().Length < 2) { fil.Show(); adv.lbl_msm.Text = "Ingresa o Genera la Marca"; adv.ShowDialog(); fil.Hide(); txt_Marca2.Focus(); return false; }
            if (txt_catego2.Text.Trim().Length < 2) { fil.Show(); adv.lbl_msm.Text = "Ingresa o Genera la Categoria"; adv.ShowDialog(); fil.Hide(); txt_catego2.Focus(); return false; }
            if (txt_PesoUnit2.Text.Trim().Length < 1) { fil.Show(); adv.lbl_msm.Text = "Ingrese el peso por unidad"; adv.ShowDialog(); fil.Hide(); txt_PesoUnit2.Text = "0"; return false; }
            if (CBB_tipProduc2.SelectedIndex == -1) { fil.Show(); adv.lbl_msm.Text = "Selecciona el tipo de Producto "; adv.ShowDialog(); fil.Hide(); CBB_tipProduc2.Focus(); return false; }
            if (CBB_Medida2.SelectedIndex == -1) { fil.Show(); adv.lbl_msm.Text = "Selecciona el tipo de unidad de Medida"; adv.ShowDialog(); fil.Hide(); CBB_Medida2.Focus(); return false; }
            if (txt_precioCompraSol2.Text.Trim().Length <= 0) { fil.Show(); adv.lbl_msm.Text = "Ingresa el precio de compra en soles"; adv.ShowDialog(); fil.Hide(); txt_precioCompraSol2.Focus(); return false; }
            if (txt_frankUtilidad2.Text.Trim().Length < 2) { fil.Show(); adv.lbl_msm.Text = "Ingresa el margen"; adv.ShowDialog(); fil.Hide(); txt_frankUtilidad2.Focus(); return false; }
            if (txt_precioVentaMayor2.Text.Trim().Length < 1) { fil.Show(); adv.lbl_msm.Text = "Ingresa el precio de venta al por mayor"; adv.ShowDialog(); fil.Hide(); txt_precioVentaMayor2.Text = "0"; return false; }

            return true;
        }
        private void Editar_Producto()
        {
            try
            {//txt_Marca
                int rpt;
                e_prod.Idpro = txt_idProd2.Text;
                e_prod.Descripcion = txt_descriProd2.Text;
                e_prod.Frank = Convert.ToDouble(txt_frankUtilidad2.Text);
                e_prod.Pre_compraSol = Convert.ToDouble(txt_precioCompraSol2.Text);
                e_prod.Pre_CompraDolar = Convert.ToDouble(txt_PrecioCompDolar2.Text);

                e_prod.Idprove = lbl_idprov.Text;
                e_prod.IdMar = Convert.ToInt32(lbl_IDMarca.Text);
                e_prod.IdCat = Convert.ToInt32(lbl_idCategoria.Text);
                e_prod.Pre_Venta_Menor = Convert.ToDouble(txt_precioVentaMenor2.Text);
                e_prod.Pre_Venta_Mayor = Convert.ToDouble(txt_precioVentaMayor2.Text);
                e_prod.Pre_Venta_Dolar = Convert.ToDouble(txt_precioVentaMenDolar2.Text);
                e_prod.UndMdida = CBB_Medida2.SelectedValue.ToString();
                e_prod.PesoUnit = Convert.ToDouble(txt_PesoUnit2.Text);
                e_prod.Utilidad = Convert.ToDouble(txt_Utili2.Text);
                e_prod.TipoProd = CBB_tipProduc2.SelectedItem.ToString();

                e_prod.Foto = xfotoRuta;

                rpt = n_prod.RN_Editar_Producto(e_prod);
                if (rpt == 1)
                {
                    if (CBB_tipProduc2.SelectedIndex == 0)
                    {
                        //Registrar_Kardex(txt_idProd.Text);
                        //RN_TipoDoc.RN_Actualizar_SiguienteNro_correlativoProducto(4);

                        Principal.Frm_Filtro fil = new Principal.Frm_Filtro();
                        fil.Show();
                        this.Tag = "A";
                        MessageBox.Show("Se Edito el Producto correctamente:", "PRODUCTO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Limpiar_text();
                        fil.Hide();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Debe seleccionar como tipo PRODUCTO.", "PRODUCTO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CBB_tipProduc2.Focus();
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al Guardar msj:" + ex, "PRODUCTO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        #region Kardex
        /* private void Registrar_Kardex(string idprod)
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
        */
        #endregion

        private void Limpiar_text()
        {
            txt_idProd2.Text = "";
            txt_descriProd2.Text = "";
            txt_frankUtilidad2.Text = "";
            txt_precioCompraSol2.Text = "";
            txt_PrecioCompDolar2.Text = ""; 

            pb_Product.Load(Application.StartupPath + @"\focus.png");
            xfotoRuta = Application.StartupPath + @"\focus.png";

            txt_prove2.Text ="";
            txt_Marca2.Text = "";
            txt_catego2.Text = "";
            CBB_tipProduc2.SelectedItem = 0;

            CBB_Medida2.SelectedItem = 8;
            txt_PesoUnit2.Text = "";
            txt_Utili2.Text = "";
            txt_precioCompraSol2.Text = "";
            txt_PrecioCompDolar2.Text = "";
            txt_frankUtilidad2.Text = "";

            txt_precioVentaMenor2.Text = "";
            txt_precioVentaMayor2.Text = "";
            txt_precioVentaMenDolar2.Text = "";

            lbl_idCategoria.Text = "";
            lbl_IDMarca.Text = "";
            lbl_idprov.Text = "";
        }

        private void btn_listo_Click(object sender, EventArgs e)
        {
            if (validar_textbox() == true)
            {
                Editar_Producto();
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
            Principal.Frm_Filtro fil = new Principal.Frm_Filtro();
            Frm_ListadoProveedor lis = new Frm_ListadoProveedor();

            fil.Show();
            lis.ShowDialog();
            fil.Hide();

            if (lis.Tag.ToString() == "A")
            {
                txt_prove2.Text = lis.lbl_nomb.Text;
                lbl_idprov.Text = lis.lbl_id.Text;
            }
        }

        private void Pb_Marca_Click(object sender, EventArgs e)
        {
            Principal.Frm_Filtro fil = new Principal.Frm_Filtro();
            Utilitarios.Frm_Marca mar = new Utilitarios.Frm_Marca();

            fil.Show();
            mar.ShowDialog();
            fil.Hide();

            if (mar.Tag.ToString() == "A")
            {
                txt_Marca2.Text = mar.txt_NomMarca.Text;
                lbl_IDMarca.Text = mar.txt_IDMarca.Text;
            }
        }

        private void pb_categoria_Click(object sender, EventArgs e)
        {
            Principal.Frm_Filtro fil = new Principal.Frm_Filtro();
            Utilitarios.Frm_Categoria cat = new Utilitarios.Frm_Categoria();

            fil.Show();
            cat.ShowDialog();
            fil.Hide();

            if (cat.Tag.ToString() == "A")
            {
                txt_catego2.Text = cat.txt_NomCateg.Text;
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
            txt_precioCompraSol2.Text = txt_precioCompraSol2.Text.Replace(",", ".");
            txt_precioCompraSol2.SelectionStart = txt_precioCompraSol2.Text.Length;
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
            txt_PrecioCompDolar2.Text = txt_PrecioCompDolar2.Text.Replace(",", ".");
            txt_PrecioCompDolar2.SelectionStart = txt_PrecioCompDolar2.Text.Length;

            //Calcular Precio Venta en soles

            try
            {
                if (txt_frankUtilidad2.Text.Trim() == "") return;
                if (txt_PrecioCompDolar2.Text.Trim() == "") return;

                double Precom_sol = 0;
                double preVenta_dolar = 0;
                double Utilidad_unid = 0;

                //Hallar el precio de compra en soles
                Precom_sol = Convert.ToDouble(txt_PrecioCompDolar2.Text) * Convert.ToDouble(lbl_numtipicambio.Text);
                txt_precioCompraSol2.Text = Precom_sol.ToString("###0.00");

                //Hallar PRECIO DE VENTA AL POR MENOR
                Precom_sol = Convert.ToDouble(txt_precioCompraSol2.Text) * Convert.ToDouble(txt_frankUtilidad2.Text);
                txt_precioVentaMenor2.Text = Precom_sol.ToString("###0.00");

                //precio de venta en dolar
                preVenta_dolar = Convert.ToDouble(txt_PrecioCompDolar2.Text) * Convert.ToDouble(txt_frankUtilidad2.Text);
                txt_precioVentaMenDolar2.Text = preVenta_dolar.ToString("###0.00");

                //Calcular Utilidad
                Utilidad_unid = Convert.ToDouble(txt_precioVentaMenor2.Text) - Convert.ToDouble(txt_precioCompraSol2.Text);
                txt_Utili2.Text = Utilidad_unid.ToString("###0.00");

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
            txt_frankUtilidad2.Text = txt_frankUtilidad2.Text.Replace(",", ".");
            txt_frankUtilidad2.SelectionStart = txt_frankUtilidad2.Text.Length;

            try
            {
                if (txt_frankUtilidad2.Text.Trim() == "") return;
                if (txt_precioCompraSol2.Text.Trim() == "") return;

                double Precom_sol = 0;
                double Utilidad_unid = 0;
                double preVenta_dolar = 0;

                Precom_sol = Convert.ToDouble(txt_precioCompraSol2.Text) * Convert.ToDouble(txt_frankUtilidad2.Text);
                txt_precioVentaMenor2.Text = Precom_sol.ToString("###0.00");

                //Calcular Utilidad
                Utilidad_unid = Convert.ToDouble(txt_precioVentaMenor2.Text) - Convert.ToDouble(txt_precioCompraSol2.Text);
                txt_Utili2.Text = Utilidad_unid.ToString("###0.00");

                //precio de venta en dolar
                preVenta_dolar = Convert.ToDouble(txt_PrecioCompDolar2.Text) * Convert.ToDouble(txt_frankUtilidad2.Text);
                txt_precioVentaMenDolar2.Text = preVenta_dolar.ToString("###0.00");
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
            txt_precioVentaMenor2.Text = txt_precioVentaMenor2.Text.Replace(",", ".");
            txt_precioVentaMenor2.SelectionStart = txt_precioVentaMenor2.Text.Length;
        }

        private void txt_precioVentaMayor_TextChanged(object sender, EventArgs e)
        {
            txt_precioVentaMayor2.Text = txt_precioVentaMayor2.Text.Replace(",", ".");
            txt_precioVentaMayor2.SelectionStart = txt_precioVentaMayor2.Text.Length;
        }

        private void txt_precioVentaDolar_TextChanged(object sender, EventArgs e)
        {
            txt_precioVentaMenDolar2.Text = txt_precioVentaMenDolar2.Text.Replace(",", ".");
            txt_precioVentaMenDolar2.SelectionStart = txt_precioVentaMenDolar2.Text.Length;
        }

        private void txt_PrecioUnit_TextChanged(object sender, EventArgs e)
        {
            txt_PesoUnit2.Text = txt_PesoUnit2.Text.Replace(",", ".");
            txt_PesoUnit2.SelectionStart = txt_PesoUnit2.Text.Length;
        }

        private void CheckB_PrecioDolar_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckB_PrecioDolar2.Checked == true)
            {//txt_precioVentaMayor
                txt_PrecioCompDolar2.Enabled = true;
                txt_precioCompraSol2.Enabled = false;
                txt_precioVentaMenor2.Enabled = false;
                //txt_precioVentaMayor.Enabled = false;
                txt_precioVentaMenDolar2.Enabled = false;
                txt_Utili2.Text = "0";
                txt_precioCompraSol2.Text = "0";
                txt_frankUtilidad2.Text = "0";
                txt_precioVentaMenor2.Text = "0";
                txt_precioVentaMayor2.Text = "0";
                //txt_precioVentaMenDolar.Text = "0";
                txt_PrecioCompDolar2.Text = "0";
                txt_PrecioCompDolar2.Focus();

            }
            else
            {
                Limpiar_Precio();
            }
        }
        private void Limpiar_Precio()
        {//txt_precioVentaMayor
            txt_Utili2.Text = "0";
            txt_precioCompraSol2.Text = "0";
            txt_frankUtilidad2.Text = "0";
            txt_precioVentaMenor2.Text = "0";
            txt_precioVentaMayor2.Text = "0";
            txt_precioVentaMenDolar2.Text = "0";
            txt_PrecioCompDolar2.Enabled = false;
            txt_precioCompraSol2.Enabled = true;
            txt_PrecioCompDolar2.Text = "0";
            txt_precioCompraSol2.Focus();


        }

        private void txt_precioCompraSol_Click(object sender, EventArgs e)
        {
            if (txt_precioCompraSol2.Text == "0")
            {
                txt_precioCompraSol2.Text = "";
            }

        }

        private void txt_frankUtilidad_Click(object sender, EventArgs e)
        {
            if (txt_frankUtilidad2.Text == "0")
            {
                txt_frankUtilidad2.Text = "";
            }

        }

        private void txt_precioVentaMayor_MouseClick(object sender, MouseEventArgs e)
        {
            if (txt_precioVentaMayor2.Text == "0")
            {
                txt_precioVentaMayor2.Text = "";
            }

        }
       private void Buscar_Producto_Edit(string idpro)
        {
             DataTable dt = new DataTable();
            try
            {
                dt = n_prod.RN_Buscar_Producto(idpro);
                if (dt.Rows.Count > 0)
                {
                    txt_idProd2.Text= Convert.ToString(dt.Rows[0]["Id_Pro"]);
                    txt_descriProd2.Text= Convert.ToString(dt.Rows[0]["Descripcion_Larga"]);
                    txt_prove2.Text= Convert.ToString(dt.Rows[0]["NOMBRE"]);
                    txt_Marca2.Text= Convert.ToString(dt.Rows[0]["Marca"]);
                    txt_catego2.Text= Convert.ToString(dt.Rows[0]["Categoria"]);
                    CBB_tipProduc2.Text = Convert.ToString(dt.Rows[0]["TipoProdcto"]);

                    CBB_Medida2.Text = Convert.ToString(dt.Rows[0]["UndMedida"]).ToString().Trim();
                    txt_PesoUnit2.Text = Convert.ToString(dt.Rows[0]["PesoUnit"]);
                    txt_Utili2.Text = Convert.ToString(dt.Rows[0]["UtilidadUnit"]);
                    txt_precioCompraSol2.Text = Convert.ToString(dt.Rows[0]["Pre_CompraS"]);
                    txt_PrecioCompDolar2.Text = Convert.ToString(dt.Rows[0]["Pre_Compra$"]);
                    txt_frankUtilidad2.Text = Convert.ToString(dt.Rows[0]["Frank"]);

                    txt_precioVentaMenor2.Text = Convert.ToString(dt.Rows[0]["Pre_vntaxMayor"]);
                    txt_precioVentaMayor2.Text = Convert.ToString(dt.Rows[0]["Pre_vntaxMenor"]);
                    txt_precioVentaMenDolar2.Text = Convert.ToString(dt.Rows[0]["Pre_Vntadolar"]);

                    lbl_idCategoria.Text= Convert.ToString(dt.Rows[0]["Id_Cat"]);
                    lbl_IDMarca.Text = Convert.ToString(dt.Rows[0]["Id_Marca"]);
                    lbl_idprov.Text = Convert.ToString(dt.Rows[0]["IDPROVEE"]);

                    try
                    {
                        xfotoRuta = Convert.ToString(dt.Rows[0]["Foto"]);
                        pb_Product.Load(xfotoRuta);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Error al Buscar la Foto en la ruta: "+xfotoRuta, "Error de Archivo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                    MessageBox.Show("Error al Editar msj: el Logotipo fue ELIMINADO Ó MOVIDO " + ex, "frm Proveedor", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void label33_Click(object sender, EventArgs e)
        {

        }

        private void txt_PrecioCompDolar_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilitario uti = new Utilitario();
            e.KeyChar = Convert.ToChar(uti.SoloNumeros(e.KeyChar));
        }
    }
}
