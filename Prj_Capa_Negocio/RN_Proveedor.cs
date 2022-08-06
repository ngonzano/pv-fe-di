using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SPV_Capa_Datos;
using SPV_Capa_Entidad;

namespace SPV_Capa_Negocio
{
  public class RN_Proveedor
    {
        BD_Proveedor obj = new BD_Proveedor();
        //REGISTRAR
        public int RN_Registrar_Proveedor(EN_Proveedor e_prov)
        {
            return obj.BD_Registrar_Proveedor(e_prov); 
        }

        //EDITAR
        public void RN_Editar_Proveedor(EN_Proveedor e_prov)
        {
            obj.BD_Editar_Proveedor(e_prov);
        }
        //MOSTRAR
        public DataTable RN_Mostrar_Todas_Proveedor()
        {
            return obj.BD_Mostrar_Todas_Proveedor();
        }
        //ELIMINAR
        public void RN_Eliminar_Proveedor(EN_Proveedor e_prov)
        {
            obj.BD_Eliminar_Proveedor(e_prov);
        }
        public DataTable BN_Buscar_Proveedor(string Valor)
        {
            return obj.BD_Buscar_Proveedor(Valor);
        }
    }
}
