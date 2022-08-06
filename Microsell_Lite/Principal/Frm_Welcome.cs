using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Microsell_Lite.Principal
{
    public partial class Frm_Welcome : Form
    {
        public Frm_Welcome()
        {
            InitializeComponent();
        }
        
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (this.Opacity < 1) this.Opacity += 0.02;
            bunifuProgressBar1.Value += 1; //aqui progres
            circularProgressBar1.Value += 1;
            circularProgressBar1.Text = circularProgressBar1.Value.ToString();
            if (bunifuProgressBar1.Value == 100) //aqui progres
            {
             timer1.Stop();
             timer2.Start();
            }       
        }
        private void timer2_Tick(object sender, EventArgs e)
        {
            this.Opacity -= 0.02;
            if (this.Opacity==0)
            {
                timer2.Stop();
                this.Close();
            }
        }

        private void Frm_Welcome_Load(object sender, EventArgs e)
        {
            //lbl_IdUsu.Text= Cls_UsuLogin.IdUsu.ToString();
            //pb_foto.Load(Cls_UsuLogin.Foto);
            //lbl_usu.Text = Cls_UsuLogin.xNombres;

            this.Opacity = 0.0;

            circularProgressBar1.Value = 0;
            circularProgressBar1.Minimum = 0;
            circularProgressBar1.Maximum = 100;

            timer1.Start();
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            Utilitario obj = new Utilitario();

            if (e.Button == MouseButtons.Left)
            {
                obj.Mover_formulario(this);

            }
        }
    }
}
