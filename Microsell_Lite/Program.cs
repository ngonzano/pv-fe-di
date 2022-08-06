using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsell_Lite.Productos;
using Microsell_Lite.Utilitarios;
using Microsell_Lite.Producto;
using Microsell_Lite.Proveedor;
using Microsell_Lite.Cliente;
using Microsell_Lite.Compras;
using Microsell_Lite.Ventas;
using Microsell_Lite.Caja;
using Microsell_Lite.Principal;
using Microsell_Lite.Cotizacion;
using Microsell_Lite.GuiaRemision;

namespace Microsell_Lite
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Frm_login_2());
        }
    }
}
