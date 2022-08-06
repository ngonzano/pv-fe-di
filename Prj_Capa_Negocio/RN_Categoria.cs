using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SPV_Capa_Datos;


namespace SPV_Capa_Negocio
{
  public class RN_Categoria
    {
        BD_Categoria obj = new BD_Categoria();
        public void RN_Registrar_Categoria(string nomCateg)
        {
            obj.BD_Registrar_Categoria(nomCateg);
        }

        //EDITAR
        public void RN_Editar_Categoria(int idCateg, string nomCateg)
        {
            obj.BD_Editar_Categoria(idCateg, nomCateg);
        }
        //MOSTRAR
        public DataTable RN_Mostrar_Todas_Categorias()
        {
            return obj.BD_Mostrar_Todas_Categorias();
        }
        public void RN_Eliminar_Categoria(int idMarca)
        {
            obj.BD_Eliminar_Categoria(idMarca);
        }
    }
}
