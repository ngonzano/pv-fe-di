using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SPV_Capa_Entidad;
using SPV_Capa_Negocio;
using Microsell_Lite.Utilitarios;
using Microsell_Lite.Principal;

namespace Microsell_Lite.MiEmpresa
{
    public partial class Frm_EditEmpresa : Form
    {
        public Frm_EditEmpresa()
        {
            InitializeComponent();
        }

        private void Frm_EditEmpresa_Load(object sender, EventArgs e)
        {
            Leer_Empresa(1);
        }



        private void Leer_Empresa(int idprove)
        {
            RN_MiEmpresa obj = new RN_MiEmpresa();
            DataTable data = new DataTable();

            try
            {
                data = obj.RN_Mostrar_Empresa(idprove);
                if (data.Rows.Count > 0)
                {
                    txt_id.Text = Convert.ToString(data.Rows[0]["idrancho"]);
                    txt_razonsocial.Text = Convert.ToString(data.Rows[0]["nombreRancho"]);
                    txt_direccion.Text = Convert.ToString(data.Rows[0]["Direccionran"]);
                    txt_correo.Text = Convert.ToString(data.Rows[0]["CORREO"]);
                    txt_clavecorreo.Text = Convert.ToString(data.Rows[0]["clavecorreo"]);
                    txt_Usuariosol.Text = Convert.ToString(data.Rows[0]["usuariosol"]);
                    txt_clavesol.Text = Convert.ToString(data.Rows[0]["clavesol"]);
                    txt_ruc.Text = Convert.ToString(data.Rows[0]["nroRuc"]);
                    txt_claveCertifi.Text = Convert.ToString(data.Rows[0]["clavecertificado"]);

                }

            }
            catch (Exception ex)
            {

                MessageBox.Show("Error al Guardar: " + ex.Message, "Form Add Proveedor", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }


        }

        private void btn_cerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_reload_Click(object sender, EventArgs e)
        {
            Leer_Empresa(1);
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }




        private bool Validar_Textobox()
        {
            Frm_Filtro fil = new Frm_Filtro();
            Frm_Advertencia ver = new Frm_Advertencia();

            if (txt_id.Text.Trim().Length ==0) { fil.Show(); ver.lbl_msm.Text = "Ingresa el ID"; ver.ShowDialog(); fil.Hide(); return false; }
            if (txt_razonsocial.Text.Trim().Length < 2) { fil.Show(); ver.lbl_msm.Text = "Ingresa la Razon Social"; ver.ShowDialog(); fil.Hide(); txt_razonsocial.Focus(); return false; }
            if (txt_ruc.Text.Trim().Length < 8) { fil.Show(); ver.lbl_msm.Text = "Ingresa el Nro de RUC"; ver.ShowDialog(); fil.Hide(); txt_ruc.Focus(); return false; }
            if (txt_Usuariosol.Text.Trim().Length < 4) { fil.Show(); ver.lbl_msm.Text = "Ingresa el Usuario Sol"; ver.ShowDialog(); fil.Hide(); txt_Usuariosol.Focus(); return false; }
            if (txt_clavesol.Text.Trim().Length < 4) { fil.Show(); ver.lbl_msm.Text = "Ingresa la Clave Sol"; ver.ShowDialog(); fil.Hide(); txt_clavesol.Focus(); return false; }
            if (txt_claveCertifi.Text.Trim().Length < 4) { fil.Show(); ver.lbl_msm.Text = "Ingresa la Clave de Certificado Digital"; ver.ShowDialog(); fil.Hide(); txt_claveCertifi.Focus(); return false; }
            return true;
        }




        private void Registrar_Empresa()
        {
            RN_MiEmpresa obj = new RN_MiEmpresa();
            EN_MiEmpresa pro = new EN_MiEmpresa();
            int rpt;
            try
            {
                pro.Idrancho =Convert.ToInt32( txt_id.Text);
                pro.Nombrerancho = txt_razonsocial.Text;
                pro.Direccionran = txt_direccion.Text;
                pro.NroRuc= txt_ruc.Text;
                pro.Correo = txt_correo.Text;
                pro.Clavecorreo = txt_clavecorreo.Text;
                pro.Clavesol  = txt_clavesol.Text;
                pro.Usuariosol  = txt_Usuariosol.Text;
                pro.Clavecertificado= txt_claveCertifi.Text;
                pro.Obs = "-";

                rpt=obj.RN_Editar_Empresa(pro);

                if (rpt==1)
                {
                    Frm_Filtro fil = new Frm_Filtro();
                    Frm_Msm_Bueno ok = new Frm_Msm_Bueno();


                    fil.Show();
                    ok.Lbl_msm1.Text = "Los Datos se Actualizaron";
                    ok.ShowDialog();
                    fil.Hide();
                                    
                    this.Tag = "A";
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al Guardar: " + ex.Message, "Form Add Proveedor", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }


        }




        private void btn_listo_Click(object sender, EventArgs e)
        {
            if (Validar_Textobox()==true )
            {
                Registrar_Empresa();
            }




        }

        private void pnl_titu_MouseMove(object sender, MouseEventArgs e)
        {
            Utilitario uti = new Utilitario();

            if (e.Button ==MouseButtons.Left )
            {
                uti.Mover_formulario(this);
            }

            
        }

        private void btn_ver_Click(object sender, EventArgs e)
        {
            if (txt_claveCertifi.UseSystemPasswordChar==true )
            {
                txt_claveCertifi.UseSystemPasswordChar = false;
                txt_clavecorreo.UseSystemPasswordChar = false;
            }
            else
            {
                txt_claveCertifi.UseSystemPasswordChar = true;
                txt_clavecorreo.UseSystemPasswordChar = true;
            }
        }
    }
}
