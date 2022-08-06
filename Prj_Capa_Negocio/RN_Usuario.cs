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
   public class RN_Usuario
    {
        BD_Usuario usua = new BD_Usuario();
        public bool RN_Login(string usu, string pass)
        {
            return usua.BD_Login(usu,pass);
        }
        public DataTable RN_Buscar_usuario(string nomusu)
        {
            return usua.BD_Buscar_usuario(nomusu);
        }
        public bool RN_isValidPassword(string username, string password)
        {
            return usua.isValidPassword(username,password);
        }
        public UserBE RN_getUserFromDB(string username)
        {
            return usua.getUserFromDB(username);
        }
        public bool RN_saveUser(string user, string password, EN_Usuario usuario)
        {
            return usua.saveUser(user,password,usuario);
        }
        public bool RN_Validar_Usuario(string dni)
        {
            return usua.BD_Validar_Usuario(dni);
        }
    }
}
