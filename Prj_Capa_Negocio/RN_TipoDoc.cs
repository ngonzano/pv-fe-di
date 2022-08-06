using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SPV_Capa_Datos;

namespace SPV_Capa_Negocio
{
   public class RN_TipoDoc
    {
        BD_TipoDocumento tp = new BD_TipoDocumento();
        public static string Sp_Listado_Tipo(int idtipo)
        {
            return BD_TipoDocumento.Sp_Listado_Tipo(idtipo);
        }
        public static void RN_Actualizar_SiguienteNro_correlativo(int idtipo)
        {
            BD_TipoDocumento.BD_Actualizar_SiguienteNro_correlativo(idtipo);
        }
        public static void RN_Actualizar_TipoCambio(int idtipo, double TipoCambio)
        {
            BD_TipoDocumento.BD_Actualizar_TipoCambio(idtipo, TipoCambio);
        }
        public static double Sp_Listado_TipoCambio(int idtipo)
        {
           return BD_TipoDocumento.Sp_Listado_TipoCambio(idtipo);
        }
        public static void RN_Actualizar_SiguienteNro_correlativoProducto(int idtipo)
        {
            BD_TipoDocumento.BD_Actualizar_SiguienteNro_correlativoProducto(idtipo);
        }
        public DataTable RN_Mostrar_TipoDocumento()
        {
            return tp.BD_Mostrar_TipoDocumento();
        }
        public DataTable RN_Listar_TipoDocumento()
        {
            return tp.BD_Listar_TipoDocumento();
        }
        public int RN_Actualizar_TipoCambio(int idtipo, string numero)
        {
            return tp.BD_Actualizar_TipoCambio(idtipo,numero);
        }
        public DataTable RN_Buscar_TipoDocumento(string nom_Tipo)
        {
            return tp.BD_Buscar_TipoDocumento(nom_Tipo);
        }
        public void RN_Editar_Nro_correlativo(int idtipo, string documento, string serie, string numero)
        {
            tp.BD_Editar_Nro_correlativo(idtipo,documento,serie,numero);
        }
    }
}
