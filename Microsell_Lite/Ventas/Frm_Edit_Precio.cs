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

namespace Microsell_Lite.Ventas
{
    public partial class Frm_Edit_Precio : Form
    {
        public Frm_Edit_Precio()
        {
            InitializeComponent();
        }


        //public string idprod="";
        private void Frm_Edit_Precio_Load(object sender, EventArgs e)
        {
            Buscar_Producto(Frm_Crear_Ventas.xid_prod);
            txt_precio.Focus();
        }
        private void Buscar_Producto(string xidprod)
        {
            RN_Producto prod = new RN_Producto();
            DataTable dt = new DataTable();
            try
            {
                dt = prod.RN_Buscar_Producto(xidprod);
                if (dt.Rows.Count > 0)
                {
                    lbl_idprod.Text = Convert.ToString(dt.Rows[0]["Id_Pro"]);
                    Lbl_stockActual.Text = Convert.ToString(dt.Rows[0]["Stock_Actual"].ToString());
                    Lbl_precompra.Text = Convert.ToString(dt.Rows[0]["Pre_CompraS"]);
                    lbl_producto.Text = Convert.ToString(dt.Rows[0]["Descripcion_Larga"]);
                    lbl_tipoProd.Text = dt.Rows[0]["TipoProdcto"].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al Editar msj: " + ex, "Advertencia de seguridad", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void bt_cancelar_Click(object sender, EventArgs e)
        {
            this.Tag = "";
            this.Close();
        }

        private void btn_aceptar_Click(object sender, EventArgs e)
        {
            if (txt_precio.Text == "")
            {
                txt_precio.Focus();
                return;
            }
            if (Convert.ToDouble(txt_precio.Text) == 0)
            {
                txt_precio.Focus();
                return;
            }
            if (txt_cant.Text == "")
            {
                txt_cant.Focus();
                return;
            }
            if (Convert.ToDouble(txt_cant.Text) == 0)
            {
                txt_cant.Focus();
                return;
            }

            try
            {
                double preComp = Convert.ToDouble(Lbl_precompra.Text);
                double preVenta = Convert.ToDouble(txt_precio.Text);
                double Utilid_unit;
                RN_Producto n_Producto = new RN_Producto();
                double xstock;

                Utilid_unit = preVenta - preComp;
                Lbl_UtilidadUnit.Text =Utilid_unit.ToString("##0.00");

                //Validar Stock
                if (lbl_tipoProd.Text.Trim().ToString()=="Producto")
                {
                    if (preComp > Convert.ToDouble(txt_precio.Text))
                    {
                        txt_cant.Text = Lbl_stockActual.Text;
                        MessageBox.Show("El precio de compra es: "+ preComp.ToString() +" Soles, sin embargo, no se puede vender a: "+txt_precio.Text+" Soles por ser un precio menor al precio de compra..","Advertencia de Seguridad",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                        txt_cant.Focus();
                        return;
                    }
                    xstock = n_Producto.RN_Buscar_Stock_Producto(lbl_idprod.Text);
                    if (xstock < Convert.ToDouble(txt_cant.Text))
                    {
                        MessageBox.Show("La cantidad que se quiere vender es: " + txt_cant.Text + " Und(s), sin embargo, se tiene en almacen: " + xstock + " Und(s).", "Validacion de seguridad", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txt_cant.Focus();
                        return;
                    }
                    else
                    {
                        this.Tag = "A";
                        this.Close();
                    }
                }
                else
                {
                    this.Tag = "A";
                    this.Close();
                }
            }
            catch (Exception)
            {

                throw;
            }


           
        }

        private void txt_precio_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilitario uti = new Utilitario();
            e.KeyChar = Convert.ToChar(uti.SoloNumeros(e.KeyChar));
        }

        private void txt_cant_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilitario uti = new Utilitario();
            e.KeyChar = Convert.ToChar(uti.SoloNumeros(e.KeyChar));
        }

        private void txt_cant_TextChanged(object sender, EventArgs e)
        {
            txt_cant.Text = txt_cant.Text.Replace(",", ".");
            txt_cant.SelectionStart = txt_cant.Text.Length;
        }

        private void txt_precio_TextChanged(object sender, EventArgs e)
        {
            txt_precio.Text = txt_precio.Text.Replace(",", ".");
            txt_precio.SelectionStart = txt_precio.Text.Length;
        }
    }
}
