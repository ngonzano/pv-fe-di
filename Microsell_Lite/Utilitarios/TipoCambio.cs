using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Microsell_Lite.Utilitarios
{
    public partial class TipoCambio : Form
    {
        public TipoCambio()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            WebClient wc = new WebClient();
            string data;
            string[] ATC;
            data = wc.DownloadString("https://www.sunat.gob.pe/a/txt/tipoCambio.txt");
            ATC = data.Split('|');
            MessageBox.Show("Fecha:" + ATC[0] + " T.Compra: " + ATC[1] + " T.Venta: " + ATC[2]);
        }
    }
}
