using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Data;
//using System.Drawing;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
using System.Windows.Forms;
//using SPV_Capa_Negocio;
//using SPV_Capa_Entidad;
//using Microsell_Lite.Proveedor;
//using Microsell_Lite.Utilitarios;
using Newtonsoft.Json;
//using Newtonsoft.Json.Linq;
using System.Net;
using System.IO;
//using Microsell_Lite.Principal;
//using System.Threading;
//using System.IO;
//using Newtonsoft.Json;
//using System.Drawing.Imaging;
//using Gma.QrCodeNet.Encoding;
//using Gma.QrCodeNet.Encoding.Windows.Render;

namespace Microsell_Lite.Utilitarios
{
    public partial class FormAPIS : Form
    {
        public FormAPIS()
        {
            InitializeComponent();
        }

        private void FormAPIS_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string url = "https://api.reniec.cloud/dni/"+textBox1.Text;
            string respuest = GetHttp(url);
            VariableConsultDNI oObject = JsonConvert.DeserializeObject<VariableConsultDNI>(respuest);
            MessageBox.Show(oObject.nombres);
        }
        public static string GetHttp(string url)
        {
            System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12;
            WebRequest oRequest = WebRequest.Create(url);
            WebResponse oResponse = oRequest.GetResponse();
            StreamReader sr = new StreamReader(oResponse.GetResponseStream());
            return sr.ReadToEnd().Trim();
        }
        public class VariableConsultDNI
        {
            public string dni { get; set; }
            public int cui { get; set; }
            public string apellido_paterno { get; set; }
            public string apellido_materno { get; set; }
            public string nombres { get; set; }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string url = "https://api.apis.net.pe/v1/ruc?numero="+textBox1.Text;
            string respuest = GetHttp(url);
            VariableConsultRUC oObject = JsonConvert.DeserializeObject<VariableConsultRUC>(respuest);
            MessageBox.Show(oObject.nombre);
        }
        public class VariableConsultRUC
        {
            public string nombre { get; set; }
            public string tipoDocumento { get; set; }
            public string numeroDocumento { get; set; }
            public string estado { get; set; }
            public string condicion { get; set; }
            public string direccion { get; set; }
            public string ubigeo { get; set; }
            public string viaTipo { get; set; }
            public string viaNombre { get; set; }
            public string zonaCodigo { get; set; }
            public string zonaTipo { get; set; }
            public string numero { get; set; }
            public string interior { get; set; }
            public string lote { get; set; }
            public string dpto { get; set; }
            public string manzana { get; set; }
            public string kilometro { get; set; }
            public string distrito { get; set; }
            public string provincia { get; set; }
            public string departamento { get; set; }
        }
    }
    
}
