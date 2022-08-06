using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Microsell_Lite.NotaCredito
{
    public partial class Frm_add_motivo_Nc : Form
    {
        public Frm_add_motivo_Nc()
        {
            InitializeComponent();
        }

        private void btn_cerrar_Click(object sender, EventArgs e)
        {
            this.Tag = "";
            this.Close();

        }

        private void btn_comprobar_Click(object sender, EventArgs e)
        {
            if (txt_importe.Text == "") return;
            if (txt_motivo.Text == "") return;

            this.Tag = "A";
            this.Close();
        }
    }
}
