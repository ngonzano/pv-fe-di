﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SPV_Capa_Datos
{
   public class BDConexion
    {
        public string Conectar()
        {
            //return "data source=mssql-84892-0.cloudclusters.net,11919; initial Catalog=DI_ZEUS_FE;uid=ngonzano;pwd=14@qweszxC";
            //return "data source=192.168.18.17; initial Catalog=ZEUS_POS_FE;uid=SPV;pwd=1234";
            return "data source=DESKTOP-QMH5FG3; initial Catalog=master";

            // PC-NILTON
            //return "Server=tcp:softzeusposbd.database.windows.net,1433;Initial Catalog=ZEUS_POS_FE;Persist Security Info=False;User ID=ngonzano;Password=14@qweszxc;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30";
            //return "data source=JUNIOR; initial Catalog=ZEUS_POS_FE;uid=sa;pwd=1234";
            /* StreamReader leer;
             string ruta = Application.StartupPath;
             leer = new StreamReader(ruta+@"DLLConectar.txt");
             string linea;
             linea = leer.ReadLine();
             return linea;*/
        }
        public static string Conectar2()
        {
            //return "data source=mssql-84892-0.cloudclusters.net,11919; initial Catalog=DI_ZEUS_FE;uid=ngonzano;pwd=14@qweszxC";
            //return "data source=192.168.18.17; initial Catalog=ZEUS_POS_FE;uid=SPV;pwd=1234";
            return "data source=DESKTOP-QMH5FG3; initial Catalog=master";
            // PC-NILTON
            //return "data source=JUNIOR; initial Catalog=ZEUS_POS_FE;uid=sa;pwd=1234";
            //return "Server=tcp:softzeusposbd.database.windows.net,1433;Initial Catalog=ZEUS_POS_FE;Persist Security Info=False;User ID=ngonzano;Password=14@qweszxc;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30";
            /* StreamReader leer;
             string ruta = Application.StartupPath;
             leer = new StreamReader(ruta + @"DLLConectar.txt");
             string linea;
             linea = leer.ReadLine();
             return linea;*/
        }
    }
}
