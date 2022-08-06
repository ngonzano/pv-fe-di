using Microsell_Lite.Caja;
using SPV_Capa_Entidad;
using SPV_Capa_Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Microsell_Lite.Principal
{
    public partial class Frm_login_2 : Form
    {
        public Frm_login_2()
        {
            InitializeComponent();
        }
        RN_Usuario n_usu = new RN_Usuario();
        EN_Usuario e_usu = new EN_Usuario();
        private void txt_Usu_Enter(object sender, EventArgs e)
        {
            if (txtUser.Text=="Usuario")
            {
                txtUser.Text = "";
                txtUser.ForeColor = Color.LightGray;
            }
        }

        private void txt_Usu_Leave(object sender, EventArgs e)
        {
            if (txtUser.Text=="")
            {
                txtUser.Text = "Usuario";
                txtUser.ForeColor = Color.DimGray;
            }
        }

        private void txt_pass_Enter(object sender, EventArgs e)
        {
            if (txtPassword.Text == "Contraseña")
            {
                txtPassword.Text = "";
                txtPassword.ForeColor = Color.LightGray;
               txtPassword.UseSystemPasswordChar = true;
            }
        }

        private void txt_pass_Leave(object sender, EventArgs e)
        {
            if (txtPassword.Text == "")
            {
                txtPassword.Text = "Contraseña";
                txtPassword.ForeColor = Color.DimGray;
                txtPassword.UseSystemPasswordChar = false;
            }
        }

        private void btn_cerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btn_minimi_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void panel2_MouseMove(object sender, MouseEventArgs e)
        {
            Utilitario obj = new Utilitario();

            if (e.Button == MouseButtons.Left)
            {
                obj.Mover_formulario(this);
            }
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            if (validar_textBox() == true)
            {
                hacer_login2();
            }
           
        }
        int intentos = 0;
        string xfotoRuta;
        OpenFileDialog OpenFileDialog1 = new OpenFileDialog();
        void hacer_login2()
        {
            if (validar_textBox() == false)
            {
                return;
            }
            string username = txtUser.Text.Trim();
            string pass = txtPassword.Text.Trim();


            if (n_usu.RN_isValidPassword(username, pass))
            {
                DataTable dt = new DataTable();
                dt = n_usu.RN_Buscar_usuario(txtUser.Text);
                if (dt.Rows.Count > 0)
                {
                    DataRow dr = dt.Rows[0];
                    Cls_UsuLogin.IdUsu = dr["Id_Usu"].ToString();
                    Cls_UsuLogin.IdRol = dr["Id_Rol"].ToString();
                    Cls_UsuLogin.xNombres = dr["Nombres"].ToString();
                    Cls_UsuLogin.Apellidos = dr["Apellidos"].ToString();
                    Cls_UsuLogin.Foto = dr["Ubicacion_Foto"].ToString();
                    Cls_UsuLogin.Rol = dr["Rol"].ToString();
                    Cls_UsuLogin.Usuario= dr["Usuario"].ToString();
                    Cls_UsuLogin.Foto = dr["Ubicacion_Foto"].ToString();

                    this.Hide();
                    
                    //Frm_Welcome w = new Frm_Welcome();
                    //w.lbl_usu.Text =Cls_UsuLogin.IdUsu;
                    //w.lbl_nombre.Text =Cls_UsuLogin.Apellidos+", "+ Cls_UsuLogin.xNombres;

                    try
                    {
                        xfotoRuta = Convert.ToString(dt.Rows[0]["Ubicacion_Foto"]);
                        //w.pic_foto.Load(xfotoRuta);
                    }
                    catch (Exception)
                    {
                        //MessageBox.Show("Error al Buscar la Foto en la ruta: "+ xfotoRuta, "Error De Archivo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    //w.pic_foto.l
                    //w.ShowDialog();

                    //Frm_Menu_Principal pri = new Frm_Menu_Principal();
                    //pri.Show();

                    Frm_Principal pri = new Frm_Principal();
                    pri.Show();
                    InicioCaja();
                }

            }
            else
            {
                intentos++;
                txtUser.Text = "";
                txtPassword.Text = "";
                txtUser.Focus();
                MessageBox.Show("Login o Password incorrecto.", "Advertencia de Login -> Intento " + intentos, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                if (intentos == 3)
                {
                    MessageBox.Show("Ud ha sobrepasado los limites permitidos de intentos.", "Advertencia de Login", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    Application.Exit();
                }
            }
        }
        void InicioCaja()
        {
            Frm_Filtro fil = new Frm_Filtro();
            Frm_InicioCaja c = new Frm_InicioCaja();
            RN_CierreCaja n_cie = new RN_CierreCaja();

            if (n_cie.RN_Validar_Registro_Caja() == false)
            {
                fil.Show();
                c.ShowDialog();
                fil.Hide();
            }
        }
        bool validar_textBox()
        {
            Frm_Filtro fil = new Frm_Filtro();
            Utilitarios.Frm_Advertencia adv = new Utilitarios.Frm_Advertencia();
            if (txtUser.Text.Trim().Length <= 0) { fil.Show(); adv.lbl_msm.Text = "Ingresa un usuario."; adv.ShowDialog(); fil.Hide(); txtUser.Focus(); return false; }
            if (txtPassword.Text.Trim().Length <= 0) { fil.Show(); adv.lbl_msm.Text = "Ingresa un password."; adv.ShowDialog(); fil.Hide(); txtPassword.Focus(); return false; }

            return true;
        }

        private void txtUser_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                txtPassword.Focus();
            }
        }

        private void Frm_login_2_Load(object sender, EventArgs e)
        {
            txtUser.Focus();
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_login_Click(sender, e);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.Show();
         }

        private void button1_KeyDown(object sender, KeyEventArgs e)
        {
           
            if ((int)(e.KeyData) == (int)(Keys.Control) + (int)(Keys.Shift) + (int)(Keys.F12))
            {
                button1_Click(sender,e);
            }
        }
    }
}
