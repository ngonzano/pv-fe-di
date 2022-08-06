using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;
using SPV_Capa_Negocio;
using SPV_Capa_Entidad;

namespace Microsell_Lite.Principal
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        RN_Usuario n_usu = new RN_Usuario();
        EN_Usuario e_usu = new EN_Usuario();
        private void btnIngresar_Click(object sender, EventArgs e)
        {
            string username = txtUser.Text.Trim();
            string pass = txtPassword.Text.Trim();

            if (rdLogin.Checked)
            {
                if (n_usu.RN_isValidPassword(username, pass))
                {
                    lblResultado.Text = $"Bienvenido {username} , su password ingresado es correcto";
                }
                else
                {
                    lblResultado.Text = $"Usuario y/o password son incorrectos";
                }
            }
            else
            {
                e_usu.Id_Usu = txt_dni.Text;
                e_usu.Nombres = txt_nombre.Text;
                e_usu.Apellidos=txt_apellido.Text;
                e_usu.Id_Dis =Convert.ToInt32(txt_idDistrito.Text);
                e_usu.Ubicacion_Foto = xfotoRuta;
                e_usu.Fecha_Ncmiento =Convert.ToDateTime(txt_fechaNaci.Text.ToString());
                e_usu.Id_Rol = Convert.ToInt32(txt_idrol.Text);
                e_usu.Correo = txt_correo.Text;
                e_usu.Estado_Usu = txt_estado.Text;

                if (n_usu.RN_saveUser(username, pass,e_usu))
                    lblResultado.Text = $"Se registro correctamente al usuario {username} con su password {pass}";

            }

        }
        private void rdLogin_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.PasswordChar = '*';
            btnIngresar.Text = "Ingresar";
        }
        private void rdRegistrar_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.PasswordChar = '\0';
            btnIngresar.Text = "Registrar";
        }
        String xfotoRuta;
        OpenFileDialog OpenFileDialog1 = new OpenFileDialog();
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

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Tag = "";
            this.Close();
        }
    }
}
