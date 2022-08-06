using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SPV_Capa_Datos;

namespace SPV_Capa_Negocio
{
  public class RN_Marca
    {
        BD_Marca obj = new BD_Marca();
        //REGISTRAR
        public void RN_Registrar_Marca(string nomCateg)
        {
            obj.BD_Registrar_Marca(nomCateg);
        }
        //EDITAR
        public void RN_Editar_Marca(int idCateg, string nomCateg)
        {
            obj.BD_Editar_Marca(idCateg,nomCateg);
        }
        //MOSTRAR
        public DataTable RN_Mostrar_Todas_Marca()
        {
            return obj.BD_Mostrar_Todas_Marcas();
        }
        public void RN_Eliminar_Marca(int idMarca)
        {
            obj.BD_Eliminar_Marca(idMarca);
        }
    }
}
