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
    public partial class Frm_Formato : Form
    {
        public Frm_Formato()
        {
            InitializeComponent();
        }
        
        private void Frm_Formato_Load(object sender, EventArgs e)
        {
            
        }

        private void Frm_Formato_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (rbt_for_A5.Checked == false & rbt_for_A4.Checked == false & rbt_for_ticket.Checked == false)
                {
                    MessageBox.Show("Debe seleccionar un formato para imprimir su comprobante.","Imprimir comprobante",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                }
                else
                {
                    if (rbt_for_A5.Checked == true || rbt_for_A4.Checked == true || rbt_for_ticket.Checked == true)
                    {
                        this.Tag = "A";
                        this.Close();
                    }
                    else
                    {
                        this.Tag = "";
                        this.Close();
                    }
                }
            }
        }
    }
}
