using Microsell_Lite.Menu;
using SPV_Capa_Entidad;
using SPV_Capa_Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Microsell_Lite
{
    public partial class Frm_login : Form
    {
        public Frm_login()
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
                    Cls_UsuLogin.Foto = dr["Ubicacion_Foto"].ToString();
                    Cls_UsuLogin.Rol = dr["Rol"].ToString();

                    this.Hide();
                    Principal.Frm_Welcome w = new Principal.Frm_Welcome();
                    w.ShowDialog();
                    Frm_Menu_Principal pri = new Frm_Menu_Principal();
                    pri.Show();
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
        bool validar_textBox()
        {
            Principal.Frm_Filtro fil = new Principal.Frm_Filtro();
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
    }
}
