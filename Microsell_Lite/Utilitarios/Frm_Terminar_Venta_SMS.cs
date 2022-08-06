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
using System.Net.Mail;
using System.Diagnostics;
using System.Net;
using Microsell_Lite.Ventas;

namespace Microsell_Lite.Utilitarios
{
    public partial class Frm_Terminar_Venta_SMS : Form
    {
        public Frm_Terminar_Venta_SMS()
        {
            InitializeComponent();
        }

        private void Frm_Terminar_Venta_SMS_Load(object sender, EventArgs e)
        {
            DatosEmpresa();
            lbl_msn.Text = "";
        }
        #region Variable DatosEmpresa
        public string v_empresaEmisor;
        public string v_rucEmisor;
        public string v_direccionEmpresa;
        public string v_usuarioSol;
        public string v_claveSol;
        public string v_correoEmi;
        public string v_claveCorreo;
        public string v_certificadoClave;
        #endregion

        #region Variables
        bool enviado = false;
        MailMessage correo = new MailMessage();
        SmtpClient envio = new SmtpClient();

        ProcessStartInfo xpdf;
        Process procesoPDF;

        #endregion
        private void DatosEmpresa()
        {
            RN_MiEmpresa n_emp = new RN_MiEmpresa();
            DataTable dt = new DataTable();
            try
            {
                dt = n_emp.RN_Mostrar_Empresa(1);
                if (dt.Rows.Count > 0)
                {
                    v_empresaEmisor = dt.Rows[0]["nombrerancho"].ToString();
                    v_rucEmisor = dt.Rows[0]["nroRuc"].ToString();
                    v_direccionEmpresa = dt.Rows[0]["direccionran"].ToString();
                    v_usuarioSol = dt.Rows[0]["usuariosol"].ToString();
                    v_claveSol = dt.Rows[0]["clavesol"].ToString();
                    v_correoEmi = dt.Rows[0]["correo"].ToString();
                    v_claveCorreo = dt.Rows[0]["clavecorreo"].ToString();
                    v_certificadoClave = dt.Rows[0]["clavecertificado"].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "DatosEmpresa", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private int xseg = 0;
        private void txt_enviar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_Email.Text.Trim().Length < 8)
                {
                    return;
                }
                lbl_msn.Text = "Espere, estamos enviando el correo";
                lbl_msn.Visible = true;
                lbl_msn.Refresh();

                if (lbl_rutaPDF.Text.Trim().Length > 4 && lbl_rutaXML.Text.Trim().Length == 1)
                {
                    string valor = lbl_Documento.Text.Substring(0,2);

                    if (valor == "NV")
                    {
                        Enviar_Solo_PDF(v_correoEmi, v_claveCorreo, "Se Envia un PDF de la Nota De Venta realizada en: " + v_empresaEmisor, "NOTA VENTA: " + lbl_Documento.Text, txt_Email.Text, lbl_rutaPDF.Text);              
                    }
                    else if (valor == "CO") 
                    {
                        Enviar_Solo_PDF(v_correoEmi, v_claveCorreo, "Se Envia un PDF de la Cotizacion que realizo en: " + v_empresaEmisor, "Cotizacion: " + lbl_Documento.Text, txt_Email.Text, lbl_rutaPDF.Text);
                    }
                    else if (valor == "B0")
                    {
                       Enviar_Solo_PDF(v_correoEmi, v_claveCorreo, "Gracias por su compra en "+ v_empresaEmisor + ".\n\r Se Envia un PDF de la Boleta realizada el dia "+ Convert.ToString(DateTime.Now) , "Boleta: " + lbl_Documento.Text, txt_Email.Text, lbl_rutaPDF.Text);  
                    }
                    else if (valor == "F0")
                    {
                        Enviar_Solo_PDF(v_correoEmi, v_claveCorreo, "Se Envia un PDF de la Factura realizada en: " + v_empresaEmisor, "Factura: " + lbl_Documento.Text, txt_Email.Text, lbl_rutaPDF.Text);
                    }

                    if (enviado == true)
                    {
                        //MessageBox.Show("El Email se envió correctamoente", "Informe", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        lbl_msn.Text = "";
                        lbl_msn.Visible = false;
                    }
                }
                else if(lbl_rutaXML.Text.Trim().Length>4)
                {
                    Enviar_PDF_XML(v_correoEmi, v_claveCorreo, "Se Envia un PDF del comprobante Electronico que realizo en: " + v_empresaEmisor,
                                  "Comprobante Electronico: " + lbl_Documento.Text, txt_Email.Text, lbl_rutaPDF.Text, lbl_rutaXML.Text);

                    if (enviado == true)
                    {
                        //MessageBox.Show("El Email se envió correctamoente", "Informe", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        lbl_msn.Text = "";
                        lbl_msn.Visible = false;
                    }
                }
                MensajeWP();
            }
            catch (Exception)
            {

                throw;
            }
        }
        private void Enviar_Solo_PDF(string emisor, string clave, string mensaje, string asunto, string destinatario, string rutaPDF)
        {
            try
            {
                correo.To.Clear();
                correo.Body = "";
                correo.Subject = "";
                correo.Attachments.Clear();
                correo.Body = mensaje;
                correo.Subject = asunto;
                correo.IsBodyHtml = true;
                correo.To.Add(destinatario.Trim());
               

                if (rutaPDF.Trim() != "")
                {
                    Attachment archivo = new Attachment(rutaPDF);
                    correo.Attachments.Add(archivo);
                }

                correo.From = new MailAddress(emisor);
                envio.Credentials = new NetworkCredential(emisor, clave);
                //aqui encontraras el host de Gmail---------------https://www.hostinger.es/tutoriales/como-usar-el-servidor-smtp-gmail-gratuito/
                //recordar que se tiene que permitir el "Acceso de aplicaciones menos seguras" de Gmail.
                envio.Host = "smtp.gmail.com"; //smtp.live.com || outlook  -------------> smtp.gmail.com || Gmail
                envio.Port = 587; //mismo puerto
                envio.EnableSsl = true;
             

                envio.Send(correo);
                enviado = true;
                MessageBox.Show("Se envio un PDF con el documento electronico Satisfactoriamente.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error Correo", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void Enviar_PDF_XML(string emisor, string clave, string mensaje, string asunto, string destinatario, string rutaPDF, string rutaXML)
        {
            try
            {
                correo.To.Clear();
                correo.Body = "";
                correo.Subject = "";
                correo.Attachments.Clear();
                correo.Body = mensaje;
                correo.Subject = asunto;
                correo.IsBodyHtml = true;
                correo.To.Add(destinatario.Trim());

                if (rutaPDF.Trim() != "")
                {
                    Attachment archivo = new Attachment(rutaPDF);
                    correo.Attachments.Add(archivo);
                }
                if (rutaXML.Trim() != "")
                {
                    Attachment archivo2 = new Attachment(rutaXML);
                    correo.Attachments.Add(archivo2);
                }

                correo.From = new MailAddress(emisor);
                envio.Credentials = new NetworkCredential(emisor, clave);

                //aqui encontraras el host de Gmail---------------https://www.hostinger.es/tutoriales/como-usar-el-servidor-smtp-gmail-gratuito/
                //recordar que se tiene que permitir el "Acceso de aplicaciones menos seguras" de Gmail.
                envio.Host = "smtp.gmail.com"; //smtp.live.com || outlook  -------------> smtp.gmail.com || Gmail
                envio.Port = 587;//587
                envio.EnableSsl = true;

                envio.Send(correo);
                enviado = true;
                MessageBox.Show("Se envio un PDF con el documento electronico Satisfactoriamente.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error Correo", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
     
        private void btn_listo_Click(object sender, EventArgs e)
        {
            Frm_Crear_Ventas ven = new Frm_Crear_Ventas();
            ven.Show();
        }

        private void btn_cancel2_Click(object sender, EventArgs e)
        {
            this.Tag = "";
            this.Close();
        }
        int sec = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            sec += 1;
            
            if (sec == 10)
            {
                SendKeys.Send("{ENTER}");
                timer1.Stop();
                sec = 0;
            }
        }
        void MensajeWP()
        {
            try
            {
                WebBrowser web = new WebBrowser();
                web.Navigate("whatsapp://send?phone=" + "51" + txt_telefono.Text + "&text=" + txt_Mensaje.Text.Replace(" ", "+") + "");
                timer1.Start();
            }
            catch (Exception)
            {
                timer1.Stop();
            }
        }
    }
}
