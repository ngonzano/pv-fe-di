using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SPV_Capa_Datos;

namespace SPV_Capa_Negocio
{
  public class RN_Distrito
    {
        BD_Distrito obj = new BD_Distrito();
        //REGISTRAR
        public void RN_Registrar_Distrito(string nomCateg)
        {
            obj.BD_Registrar_Distrito(nomCateg);
        }
        //EDITAR
        public void RN_Editar_Distrito(int idCateg, string nomCateg)
        {
            obj.BD_Editar_Distrito(idCateg,nomCateg);
        }
        //MOSTRAR
        public DataTable RN_Mostrar_Todas_Distrito()
        {
            return obj.BD_Mostrar_Todas_Distrito();
        }
        public void RN_Eliminar_Distrito(int idMarca)
        {
            obj.BD_Eliminar_Distrito(idMarca);
        }
    }
}
