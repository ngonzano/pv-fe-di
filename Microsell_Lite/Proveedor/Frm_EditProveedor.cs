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
using SPV_Capa_Entidad;
using Microsell_Lite.Utilitarios;

namespace Microsell_Lite.Proveedor
{
    public partial class Frm_EditProveedor : Form
    {
        public Frm_EditProveedor()
        {
            InitializeComponent();
        }
        RN_Proveedor N_prov = new RN_Proveedor();
        EN_Proveedor e_prov = new EN_Proveedor();
        private void Frm_Reg_Prod_Load(object sender, EventArgs e)
        {
            txt_idProve.Focus();
            Buscar_Provee_Edit(this.Tag.ToString());
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

        String xfotoRuta;

        OpenFileDialog OpenFileDialog1 = new OpenFileDialog();
        private void lbl_Abrir_Click(object sender, EventArgs e)
        {
            var FilePath = string.Empty;
            try
            {
                if (OpenFileDialog1.ShowDialog()==DialogResult.OK)
                {
                    xfotoRuta = OpenFileDialog1.FileName;
                    Pic_Logo.Load(xfotoRuta);
                }
            }
            catch (Exception)
            {
                Pic_Logo.Load(Application.StartupPath + @"\focus.png");
                xfotoRuta = Application.StartupPath + @"\focus.png";
                //MessageBox.Show("Error al guardar el logo","LOGO",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
        }
        private bool validar_textbox()
        {
            Principal.Frm_Filtro fil = new Principal.Frm_Filtro();
            Frm_Advertencia adv = new Frm_Advertencia();
            if (txt_idProve.Text.Trim().Length <=0 ){fil.Show();adv.lbl_msm.Text = "Ingresa o Genera el Id del Proveedor";adv.ShowDialog();fil.Hide();txt_idProve.Focus(); return false;}
            if (txt_NomProv.Text.Trim().Length < 2) { fil.Show(); adv.lbl_msm.Text = "Ingresa o Genera el Nombre del Proveedor"; adv.ShowDialog(); fil.Hide(); txt_NomProv.Focus(); return false;}
            if (txt_Direc.Text.Trim().Length < 2) { fil.Show(); adv.lbl_msm.Text = "Ingresa o Genera la Direccion del Proveedor"; adv.ShowDialog(); fil.Hide(); txt_Direc.Focus(); return false; }
            if (txt_Telef.Text.Trim().Length < 2) { fil.Show(); adv.lbl_msm.Text = "Ingresa o Genera el telefono del Proveedor"; adv.ShowDialog(); fil.Hide(); txt_Telef.Focus(); return false; }
            if (txt_rubro.Text.Trim().Length < 2) { fil.Show(); adv.lbl_msm.Text = "Ingresa o Genera el rubro del Proveedor"; adv.ShowDialog(); fil.Hide(); txt_rubro.Focus(); return false; }
            if (txt_Ruc.Text.Trim().Length < 8) { fil.Show(); adv.lbl_msm.Text = "Ingresa o Genera el DNI o RUC del Proveedor"; adv.ShowDialog(); fil.Hide(); txt_Ruc.Focus(); return false; }
            if (txt_Correo.Text.Trim().Length < 2) { fil.Show(); adv.lbl_msm.Text = "Ingresa o Genera el Correo del Proveedor"; adv.ShowDialog(); fil.Hide(); txt_Correo.Focus(); return false; }
            if (txt_contac.Text.Trim().Length < 2) { fil.Show(); adv.lbl_msm.Text = "Ingresa o Genera el Contacto del Proveedor"; adv.ShowDialog(); fil.Hide(); txt_contac.Focus(); return false; }

            return true;
        }
        private void Editar_proveedor()
        {
            try
            {
                e_prov.Idproveedor = txt_idProve.Text;
                e_prov.Nombre = txt_NomProv.Text;
                e_prov.Direccion = txt_Direc.Text;
                e_prov.Telefono = txt_Telef.Text;
                e_prov.Rubro = txt_rubro.Text;
                e_prov.Ruc = txt_Ruc.Text;
                e_prov.Correo = txt_Correo.Text;
                e_prov.Contacto = txt_contac.Text;

                e_prov.Fotologo = xfotoRuta;

                N_prov.RN_Editar_Proveedor(e_prov);
                MessageBox.Show("El Proveedor se edito correctamente","PROVEEDOR",MessageBoxButtons.OK,MessageBoxIcon.Information);
                Limpiar_text();
                this.Tag = "A";
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al Editar msj:"+ex,"frm Proveedor",  MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
        }
        private void Limpiar_text()
        {
            txt_idProve.Text = "";
            txt_NomProv.Text = "";
            txt_Direc.Text = "";
            txt_Telef.Text = "";
            txt_rubro.Text = "";
            txt_Ruc.Text = "";
            txt_Correo.Text = "";
            txt_contac.Text = "";
        }

        private void btn_listo_Click(object sender, EventArgs e)
        {
            if (validar_textbox()==true)
            {
                Editar_proveedor();
            }
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Tag = "";
            this.Close();
        }
        private void Buscar_Provee_Edit(string idpro)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = N_prov.BN_Buscar_Proveedor(idpro);
                if (dt.Rows.Count > 0)
                {
                    txt_idProve.Text = Convert.ToString(dt.Rows[0]["IDPROVEE"]);
                    txt_NomProv.Text = Convert.ToString(dt.Rows[0]["NOMBRE"].ToString());
                    txt_Direc.Text = Convert.ToString(dt.Rows[0]["DIRECCION"]);
                    txt_Telef.Text = Convert.ToString(dt.Rows[0]["TELEFONO"]);
                    txt_rubro.Text = Convert.ToString(dt.Rows[0]["RUBRO"]);
                    txt_Ruc.Text = Convert.ToString(dt.Rows[0]["RUC"]);
                    txt_Correo.Text = Convert.ToString(dt.Rows[0]["CORREO"]);
                    txt_contac.Text = Convert.ToString(dt.Rows[0]["CONTACTO"]);
                    
                    try
                    {
                        xfotoRuta = Convert.ToString(dt.Rows[0]["FOTO_LOGO"]);
                        Pic_Logo.Load(xfotoRuta);
                    }
                    catch (Exception)
                    {
                        //MessageBox.Show("Error al Buscar la Foto en la ruta: "+ xfotoRuta, "Error De Archivo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Error al Editar msj: el Logotipo fue ELIMINADO Ó MOVIDO " + ex, "frm Proveedor", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
