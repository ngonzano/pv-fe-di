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

namespace Microsell_Lite.Compras
{
    public partial class Frm_Solo_Cant : Form
    {
        public Frm_Solo_Cant()
        {
            InitializeComponent();
        }
        
        private void Frm_Solo_Cant_Load(object sender, EventArgs e)
        {
            txt_Cantidad.Focus();
        }

        private void txt_Cantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilitario uti = new Utilitario();
            e.KeyChar = Convert.ToChar(uti.SoloNumeros(e.KeyChar));
        }
        private void txt_Cantidad_KeyDown(object sender, KeyEventArgs e)
        {
                if (e.KeyCode == Keys.Enter)
                {
                    if (txt_Cantidad.Text.Trim() == "")
                    {
                    MessageBox.Show("La cantidad no debe estar sin dato.", "Validacion de seguridad", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                    }

                    if (lbl_tipo.Text == "venta")
                    {
                        RN_Producto n_Producto = new RN_Producto();
                        double xstock;
                    
                        if (Convert.ToDouble(txt_Cantidad.Text) == 0)
                        {
                            MessageBox.Show("La cantidad debe ser mayor a CERO.", "Validacion de seguridad", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txt_Cantidad.Focus();
                            return;
                        }
                        xstock = n_Producto.RN_Buscar_Stock_Producto(lbl_idprod.Text);
                        
                        if (xstock < Convert.ToDouble(txt_Cantidad.Text))
                        {
                            MessageBox.Show("La cantidad que se quiere vender es: " + txt_Cantidad.Text + " Und(s), sin embargo, se tiene en almacen: " + xstock + " Und(s).", "Validacion de seguridad", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txt_Cantidad.Focus();
                            return;
                        }
                        this.Tag = "A";
                        this.Close();
                    }
                     else
                     {
                         this.Tag = "A";
                         this.Close();
                     }
                }
            
        }

        private void Frm_Solo_Cant_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Tag = "";
                this.Close();
            }
        }

        private void txt_Cantidad_TextChanged(object sender, EventArgs e)
        {
            txt_Cantidad.Text = txt_Cantidad.Text.Replace(",",".");
            txt_Cantidad.SelectionStart = txt_Cantidad.Text.Length;
        }

        private void pb_Product_Click(object sender, EventArgs e)
        {

        }
    }
}
