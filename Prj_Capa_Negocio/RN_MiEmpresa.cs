using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SPV_Capa_Entidad;
using SPV_Capa_Datos;
using System.Data;

namespace SPV_Capa_Negocio
{
  public class RN_MiEmpresa
    {
        BD_MiEmpresa d_emp = new BD_MiEmpresa();
        public int RN_Editar_Empresa(EN_MiEmpresa emp)
        {
            return d_emp.BD_Editar_Empresa(emp);
        }
        public DataTable RN_Mostrar_Empresa(int idemp)
        {
            return d_emp.BD_Mostrar_Empresa(idemp);
        }
    }
}
