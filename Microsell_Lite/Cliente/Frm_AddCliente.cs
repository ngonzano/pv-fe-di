using SPV_Capa_Entidad;
using SPV_Capa_Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsell_Lite.Utilitarios;

namespace Microsell_Lite.Cliente
{
    public partial class Frm_AddCliente : Form
    {
        public Frm_AddCliente()
        {
            InitializeComponent();
        }
        RN_Distrito n_dis = new RN_Distrito();
        RN_cliente n_cli = new RN_cliente();
        EN_Cliente e_cli = new EN_Cliente();
      
        private void pnl_titu_MouseMove(object sender, MouseEventArgs e)
        {
            Utilitario obj = new Utilitario();

            if (e.Button == MouseButtons.Left)
            {
                obj.Mover_formulario(this);
            }
        }

        private void btn_listo_Click(object sender, EventArgs e)
        {
            if (validar_textbox() == true)
            {
                Registrar_Cliente();
            }
        }
        private void Frm_AddProveedor_Load(object sender, EventArgs e)
        {
            txt_idCliente.Focus();
            Cargar_Todos_Distrito();
            
        }
        private void Cargar_Todos_Distrito()
        {
            DataTable dt = new DataTable();
            dt = n_dis.RN_Mostrar_Todas_Distrito();
            CBB_Distrito.DisplayMember = "Distrito";
            CBB_Distrito.ValueMember = "Id_Dis";
            CBB_Distrito.DataSource = dt;
            CBB_Distrito.DropDownStyle = ComboBoxStyle.DropDownList;
            CBB_Distrito.SelectedIndex = -1;
        }
        private void btn_cerrar_Click(object sender, EventArgs e)
        {
            this.Tag = "";
            this.Close();
        }
        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Tag = "";
            this.Close();
        }
        private bool validar_textbox()
        {
            Principal.Frm_Filtro fil = new Principal.Frm_Filtro();
            Frm_Advertencia adv = new Frm_Advertencia();
            if (txt_Nombre.Text.Trim().Length <= 0) { fil.Show(); adv.lbl_msm.Text = "Ingresa la Razon Social."; adv.ShowDialog(); fil.Hide(); txt_Nombre.Focus(); return false; }
            if (txt_DNI.Text.Trim().Length < 8) { fil.Show(); adv.lbl_msm.Text = "Ingresa el DNI valido."; adv.ShowDialog(); fil.Hide(); txt_DNI.Focus(); return false; }
            if (txt_Direccion.Text.Trim().Length < 1) { fil.Show(); adv.lbl_msm.Text = "Ingresa la Direccion."; adv.ShowDialog(); fil.Hide(); txt_Direccion.Focus(); return false; }
            if (txt_Telefono.Text.Trim().Length < 1) { fil.Show(); adv.lbl_msm.Text = "Ingresa el telefono."; adv.ShowDialog(); fil.Hide(); txt_Telefono.Focus(); return false; }
            if (txt_Email.Text.Trim().Length < 1) { fil.Show(); adv.lbl_msm.Text = "Ingresa un email."; adv.ShowDialog(); fil.Hide(); txt_Email.Focus(); return false; }
            if (txtContacto.Text.Trim().Length < 1) { fil.Show(); adv.lbl_msm.Text = "Ingresa el contacto"; adv.ShowDialog(); fil.Hide(); txtContacto.Focus(); return false; }
            if (txt_limCredito.Text.Trim().Length < 1) { fil.Show(); adv.lbl_msm.Text = "Ingresa el limite de credito"; adv.ShowDialog(); fil.Hide(); txt_limCredito.Focus(); return false; }
            return true;
        }
        private void Registrar_Cliente()
        {
            try
            {
                txt_idCliente.Text = RN_TipoDoc.Sp_Listado_Tipo(8).ToString();
                e_cli.Idcliente = txt_idCliente.Text;
                e_cli.Razonsocial= txt_Nombre.Text;
                e_cli.Dni= txt_Nombre.Text;
                e_cli.Direccion= txt_Direccion.Text;
                e_cli.Telefono= txt_Telefono.Text;
                e_cli.Email= txt_Email.Text;
                e_cli.IdDis =Convert.ToInt32(CBB_Distrito.SelectedValue);
                e_cli.FechaAniver =Convert.ToDateTime(dtp_fechaAni.Text);
                e_cli.Contacto = txtContacto.Text;
                e_cli.LimiteCred =Convert.ToDouble(txt_limCredito.Text);
                e_cli.Foto = xfotoRuta;

                if (n_cli.RN_Validar_Cliente(e_cli.Dni) == false)
                {
                    if (n_cli.RN_Registrar_Cliente(e_cli) == 1)
                    {
                        RN_TipoDoc.RN_Actualizar_SiguienteNro_correlativo(8);
                        Limpiar_text();
                        this.Tag = "A";
                        this.Close();
                    }
                } else {
                    string NomCliente;
                    DataTable dt = new DataTable();
                    dt = n_cli.RN_Buscar_cliente(e_cli.Dni);
                    DataRow dr = dt.Rows[0];
                    NomCliente = dr["Razon_Social_Nombres"].ToString();
                    MessageBox.Show("El DNI " + e_cli.Dni + " ya se encuentra registrado por: "+ NomCliente,
                        "CLIENTE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al Registrar msj:" + ex, "frm Cliente", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void Limpiar_text()
        {
            txt_idCliente.Text = "";
            txt_Nombre.Text = "";
            txt_Nombre.Text = "";
            txt_Direccion.Text = "";
            txt_Telefono.Text = ""; ;

            txt_Email.Text = "";
            

        }

        string xfotoRuta;

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
                MessageBox.Show("Error al guardar el Foto", "LOGO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txt_limCredito_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilitario uti = new Utilitario();
            e.KeyChar = Convert.ToChar(uti.SoloNumeros(e.KeyChar));
        }

        private void txt_DNI_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilitario uti = new Utilitario();
            e.KeyChar = Convert.ToChar(uti.SoloNumeros(e.KeyChar));
        }

        private void txt_Telefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilitario uti = new Utilitario();
            e.KeyChar = Convert.ToChar(uti.SoloNumeros(e.KeyChar));
        }

        private void bunifuSeparator1_Load(object sender, EventArgs e)
        {

        }

        private void txt_Direccion_Enter(object sender, EventArgs e)
        {
            if (txt_Direccion.Text == "Ingresa un Direccion")
            {
                txt_Direccion.Text = "";
                txt_Direccion.ForeColor = Color.LightGray;
            }
           
        }

        private void txt_Direccion_Leave(object sender, EventArgs e)
        {
            if (txt_Direccion.Text == "")
            {
                txt_Direccion.Text = "Ingresa un Direccion";
                txt_Direccion.ForeColor = Color.DimGray;
            }
           
        }

        private void txt_Nombre_Enter(object sender, EventArgs e)
        {
            if (txt_Nombre.Text == "Ingresa un Nombre")
            {
                txt_Nombre.Text = "";
                txt_Nombre.ForeColor = Color.LightGray;
            }
        }

        private void txt_Nombre_Leave(object sender, EventArgs e)
        {
            if (txt_Nombre.Text == "")
            {
                txt_Nombre.Text = "Ingresa un Nombre";
                txt_Nombre.ForeColor = Color.DimGray;
            }
        }

        private void txt_DNI_Enter(object sender, EventArgs e)
        {
            if (txt_DNI.Text == "Ingresa un DNI")
            {
                txt_DNI.Text = "";
                txt_DNI.ForeColor = Color.LightGray;
            }
        }

        private void txt_DNI_Leave(object sender, EventArgs e)
        {
            if (txt_DNI.Text == "")
            {
                txt_DNI.Text = "Ingresa un DNI";
                txt_DNI.ForeColor = Color.DimGray;
            }
        }

        private void txt_Telefono_Enter(object sender, EventArgs e)
        {
            if (txt_Telefono.Text == "Ingresa un Telefono")
            {
                txt_Telefono.Text = "";
                txt_Telefono.ForeColor = Color.LightGray;
            }
        }

        private void txt_Telefono_Leave(object sender, EventArgs e)
        {
            if (txt_Telefono.Text == "")
            {
                txt_Telefono.Text = "Ingresa un Telefono";
                txt_Telefono.ForeColor = Color.DimGray;
            }
        }
        private void txt_Email_Enter(object sender, EventArgs e)
        {
            if (txt_Email.Text == "Ingresa un Correo")
            {
                txt_Email.Text = "";
                txt_Email.ForeColor = Color.LightGray;
            }
        }
        private void txt_Email_Leave(object sender, EventArgs e)
        {
            if (txt_Email.Text == "")
            {
                txt_Email.Text = "Ingresa un Correo";
                txt_Email.ForeColor = Color.DimGray;
            }
        }

        private void txtContacto_Enter(object sender, EventArgs e)
        {
            if (txtContacto.Text == "Ingresa un Contacto")
            {
                txtContacto.Text = "";
                txtContacto.ForeColor = Color.LightGray;
            }
        }

        private void txtContacto_Leave(object sender, EventArgs e)
        {
            if (txtContacto.Text == "")
            {
                txtContacto.Text = "Ingresa un Contacto";
                txtContacto.ForeColor = Color.DimGray;
            }
        }

        private void txt_limCredito_Enter(object sender, EventArgs e)
        {
            if (txt_limCredito.Text == "Ingresa un Limite Credito")
            {
                txt_limCredito.Text = "";
                txt_limCredito.ForeColor = Color.LightGray;
            }
        }

        private void txt_limCredito_Leave(object sender, EventArgs e)
        {
            if (txt_limCredito.Text == "")
            {
                txt_limCredito.Text = "Ingresa un Limite Credito";
                txt_limCredito.ForeColor = Color.DimGray;
            }
        }
    }
}
