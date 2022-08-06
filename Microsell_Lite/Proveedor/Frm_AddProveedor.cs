using Microsell_Lite.Utilitarios;
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

namespace Microsell_Lite.Proveedor
{
    public partial class Frm_AddProveedor : Form
    {
        public Frm_AddProveedor()
        {
            InitializeComponent();
        }
        RN_Proveedor N_prov = new RN_Proveedor();
        EN_Proveedor e_prov = new EN_Proveedor();
        private void pnl_titu_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btn_listo_Click(object sender, EventArgs e)
        {
            if (validar_textbox() == true)
            {
                Registrar_Proveedor();
            }
        }
        String xfotoRuta;

        OpenFileDialog OpenFileDialog1 = new OpenFileDialog();
        private void Frm_AddProveedor_Load(object sender, EventArgs e)
        {
            txt_idProv.Focus();
            
        }
        private void pnl_titu_MouseMove(object sender, MouseEventArgs e)
        {
            Utilitario obj = new Utilitario();

            if (e.Button == MouseButtons.Left)
            {
                obj.Mover_formulario(this);

            }
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
            if (txt_idProv.Text.Trim().Length <=0 ){fil.Show();adv.lbl_msm.Text = "Ingresa o Genera el Id del Proveedor.";adv.ShowDialog();fil.Hide();txt_idProv.Focus(); return false;}
            if (txt_NomProv.Text.Trim().Length < 2) { fil.Show(); adv.lbl_msm.Text = "Ingresa el Nombre del Proveedor."; adv.ShowDialog(); fil.Hide(); txt_NomProv.Focus(); return false;}
            if (txt_Direccio.Text.Trim().Length < 2) { fil.Show(); adv.lbl_msm.Text = "Ingresa la Direccion del Proveedor."; adv.ShowDialog(); fil.Hide(); txt_Direccio.Focus(); return false; }
            if (txt_Telefo.Text.Trim().Length < 2) { fil.Show(); adv.lbl_msm.Text = "Ingresa el telefono del Proveedor."; adv.ShowDialog(); fil.Hide(); txt_Telefo.Focus(); return false; }
            if (txt_Rubro.Text.Trim().Length < 2) { fil.Show(); adv.lbl_msm.Text = "Ingresa el rubro del Proveedor."; adv.ShowDialog(); fil.Hide(); txt_Rubro.Focus(); return false; }
            if (txt_RUCDNI.Text.Trim().Length < 1) { fil.Show(); adv.lbl_msm.Text = "Ingrese el RUC - DNI."; adv.ShowDialog(); fil.Hide(); txt_RUCDNI.Text = "0";  return false; }
            if (txt_correo.Text.Trim().Length <5) { fil.Show(); adv.lbl_msm.Text = "Ingrese un correo."; adv.ShowDialog(); fil.Hide(); txt_correo.Focus(); return false; }
            if (txt_contacto.Text.Trim().Length <= 0) { fil.Show(); adv.lbl_msm.Text = "Ingresa el contacto del Proveedor"; adv.ShowDialog(); fil.Hide(); txt_contacto.Focus(); return false; }
           
            return true;
        }
        private void Registrar_Proveedor()
        {
            try
            {
                txt_idProv.Text = RN_TipoDoc.Sp_Listado_Tipo(5).ToString();
                e_prov.Idproveedor = txt_idProv.Text;
                e_prov.Nombre = txt_NomProv.Text;
                e_prov.Direccion = txt_Direccio.Text;
                e_prov.Telefono = txt_Telefo.Text;
                e_prov.Rubro = txt_Rubro.Text;
                e_prov.Ruc = txt_RUCDNI.Text;
                e_prov.Correo = txt_correo.Text;
                e_prov.Contacto = txt_contacto.Text;

                e_prov.Fotologo = xfotoRuta;

                if (N_prov.RN_Registrar_Proveedor(e_prov)==1)
                {
                    RN_TipoDoc.RN_Actualizar_SiguienteNro_correlativo(5);
                    MessageBox.Show("El Proveedor se Registro correctamente", "PROVEEDOR", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Limpiar_text();
                    this.Tag = "A";
                    this.Close();
                }
               
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al Editar msj:" + ex, "frm Proveedor", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void Limpiar_text()
        {
            txt_idProv.Text = "";
            txt_NomProv.Text = "";
            txt_Direccio.Text = "";
            txt_Telefo.Text = "";
            txt_Rubro.Text = ""; ;

            txt_RUCDNI.Text = "";
            txt_correo.Text = "";
            txt_contacto.Text = "";
            pb_Proveedor.Load(Application.StartupPath + @"\focus.png");
            xfotoRuta = Application.StartupPath + @"\focus.png";

        }

        private void lk_BuscarImagen_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var FilePath = string.Empty;
            try
            {
                if (OpenFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    xfotoRuta = OpenFileDialog1.FileName;
                    pb_Proveedor.Load(xfotoRuta);
                }
            }
            catch (Exception)
            {
                pb_Proveedor.Load(Application.StartupPath + @"\focus.png");
                xfotoRuta = Application.StartupPath + @"\focus.png";
                MessageBox.Show("Error al guardar el logo", "LOGO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txt_Telefo_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilitario uti = new Utilitario();
            e.KeyChar = Convert.ToChar(uti.SoloNumeros(e.KeyChar));
        }

        private void txt_RUCDNI_KeyPress(object sender, KeyPressEventArgs e)
        {
            txt_Telefo_KeyPress(sender,e);
        }

        private void txt_NomProv_Enter(object sender, EventArgs e)
        {
            if (txt_NomProv.Text == "Ingresa un Nombre")
            {
                txt_NomProv.Text = "";
                txt_NomProv.ForeColor = Color.LightGray;
            }
        }

        private void txt_Direccio_Enter(object sender, EventArgs e)
        {
            if (txt_Direccio.Text == "Ingresa un Direccion")
            {
                txt_Direccio.Text = "";
                txt_Direccio.ForeColor = Color.LightGray;
            }
        }

        private void txt_Telefo_Enter(object sender, EventArgs e)
        {
            if (txt_Telefo.Text == "Ingresa un Telefono")
            {
                txt_Telefo.Text = "";
                txt_Telefo.ForeColor = Color.LightGray;
            }
        }

        private void txt_Rubro_Enter(object sender, EventArgs e)
        {
            if (txt_Rubro.Text == "Ingresa un Rubro")
            {
                txt_Rubro.Text = "";
                txt_Rubro.ForeColor = Color.LightGray;
            }
        }

        private void txt_RUCDNI_Enter(object sender, EventArgs e)
        {
            if (txt_RUCDNI.Text == "Ingresa un DNI o RUC")
            {
                txt_RUCDNI.Text = "";
                txt_RUCDNI.ForeColor = Color.LightGray;
            }
        }

        private void txt_correo_Enter(object sender, EventArgs e)
        {
            if (txt_correo.Text == "Ingresa un Correo")
            {
                txt_correo.Text = "";
                txt_correo.ForeColor = Color.LightGray;
            }
        }

        private void txt_contacto_Enter(object sender, EventArgs e)
        {
            if (txt_contacto.Text == "Ingresa un contacto")
            {
                txt_contacto.Text = "";
                txt_contacto.ForeColor = Color.LightGray;
            }
        }

        private void txt_contacto_Leave(object sender, EventArgs e)
        {
            if (txt_contacto.Text == "")
            {
                txt_contacto.Text = "Ingresa un contacto";
                txt_contacto.ForeColor = Color.DimGray;
            }

        }

        private void txt_correo_Leave(object sender, EventArgs e)
        {
            if (txt_correo.Text == "")
            {
                txt_correo.Text = "Ingresa un Correo";
                txt_correo.ForeColor = Color.DimGray;
            }
        }

        private void txt_RUCDNI_Leave(object sender, EventArgs e)
        {
            if (txt_RUCDNI.Text == "")
            {
                txt_RUCDNI.Text = "Ingresa un DNI o RUC";
                txt_RUCDNI.ForeColor = Color.DimGray;
            }
        }

        private void txt_Rubro_Leave(object sender, EventArgs e)
        {
            if (txt_Rubro.Text == "")
            {
                txt_Rubro.Text = "Ingresa un Rubro";
                txt_Rubro.ForeColor = Color.DimGray;
            }
        }

        private void txt_Telefo_Leave(object sender, EventArgs e)
        {
            if (txt_Telefo.Text == "")
            {
                txt_Telefo.Text = "Ingresa un Telefono";
                txt_Telefo.ForeColor = Color.DimGray;
            }
        }

        private void txt_Direccio_Leave(object sender, EventArgs e)
        {
            if (txt_Direccio.Text == "")
            {
                txt_Direccio.Text = "Ingresa un Direccion";
                txt_Direccio.ForeColor = Color.DimGray;
            }
        }

        private void txt_NomProv_Leave(object sender, EventArgs e)
        {
            if (txt_NomProv.Text == "")
            {
                txt_NomProv.Text = "Ingresa un Nombre";
                txt_NomProv.ForeColor = Color.DimGray;
            }
        }
    }
}
