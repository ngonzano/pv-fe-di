using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using SPV_Capa_Datos;

namespace SPV_Capa_Negocio
{
    public class RN_GuiaRemision
    {
        BD_GuiaRemision b_guia = new BD_GuiaRemision();
        public DataTable RN_Listar_Departamento()
        {
            return b_guia.BD_Listar_Departamento();
        }
        public DataTable RN_Listar_Provincia(string departamento)
        {
            return b_guia.BD_Buscar_Provincia(departamento);
        }
        public DataTable RN_Listar_Distrito(string provincia)
        {
            return b_guia.BD_Buscar_Distrito(provincia);
        }
        public DataTable RN_Listar_Mot_traslado()
        {
            return b_guia.BD_Listar_Mot_traslado();
        }
        public DataTable RN_Listar_Establecimiento()
        {
            return b_guia.BD_Listar_Establecimiento();
        }
        public DataTable RN_Listar_Tipo_doc()
        {
            return b_guia.BD_Listar_Tipo_doc();
        }
    }
}
