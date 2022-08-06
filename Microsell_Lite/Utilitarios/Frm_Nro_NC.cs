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

namespace Microsell_Lite.Utilitarios
{
    public partial class Frm_Nro_NC : Form
    {
        public Frm_Nro_NC()
        {
            InitializeComponent();
        }
        
        private void Frm_Solo_Cant_Load(object sender, EventArgs e)
        {
            txt_Cantidad.Focus();
        }

        private void txt_Cantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Utilitario uti = new Utilitario();
            //e.KeyChar = Convert.ToChar(uti.SoloNumeros(e.KeyChar));
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
            //txt_Cantidad.Text = txt_Cantidad.Text.Replace(",",".");
            //txt_Cantidad.SelectionStart = txt_Cantidad.Text.Length;
        }
    }
}
