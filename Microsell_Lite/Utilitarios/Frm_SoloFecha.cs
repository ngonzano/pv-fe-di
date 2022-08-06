using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Microsell_Lite.Utilitarios
{
    public partial class Frm_SoloFecha : Form
    {
        public Frm_SoloFecha()
        {
            InitializeComponent();
        }

        private void btn_cancelPago_Click(object sender, EventArgs e)
        {
            this.Tag = "";
            this.Close();

        }

        private void btn_Generar_Click(object sender, EventArgs e)
        {
            this.Tag = "A";
            this.Close();
        }

        private void pnl_titulo_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button ==MouseButtons.Left )
            {
                Utilitario u = new Utilitario();
                u.Mover_formulario(this);
            }

        }

        private void Frm_SoloFecha_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode ==Keys.Escape )
            {
                this.Tag = "";
                this.Close();
            }
        }

        private void Frm_SoloFecha_Load(object sender, EventArgs e)
        {

        }
    }
}
