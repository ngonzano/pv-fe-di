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
    public partial class Frm_TerminarNotaCred : Form
    {
        public Frm_TerminarNotaCred()
        {
            InitializeComponent();
        }

        private void Frm_TerminarNotaCred_Load(object sender, EventArgs e)
        {
            rbn_GenVale.Checked = false;
            rdb_salida.Checked = false;
            rdb_nada.Checked = false;
        }

        private void btn_cerrar_Click(object sender, EventArgs e)
        {
            this.Tag = "";
            this.Close();
        }

        private void rdb_nada_CheckedChanged(object sender, EventArgs e)
        {
            if (rdb_nada.Checked ==true )
            {
                lbl_op.Text = "Nada";
            }
        }

        private void rdb_salida_CheckedChanged(object sender, EventArgs e)
        {
            if (rdb_salida.Checked ==true )
            {
                lbl_op.Text = "Salida";
            }
        }
        private void btn_comprobar_Click(object sender, EventArgs e)
        {
            if (lbl_op.Text.Trim().Length > 1)
            {
                this.Tag = "A";
                this.Close();
            }
            else
            {
                return;
            }
        }

        private void rbn_GenVale_CheckedChanged(object sender, EventArgs e)
        {
            if (rbn_GenVale.Checked == true)
            {
                lbl_op.Text = "Vale";
            }
        }
    }
}
