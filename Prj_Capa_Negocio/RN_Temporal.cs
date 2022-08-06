using SPV_Capa_Entidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SPV_Capa_Datos;

namespace SPV_Capa_Negocio
{
    public class RN_Temporal
    {
        BD_Temporal d_tem = new BD_Temporal();
        public int RN_Ingresar_Temporal_Header(EN_Temporal e_tem)
        {
            return d_tem.BD_Ingresar_Temporal_Header(e_tem);
        }
        public int BD_Ingresar_Temporal_Det(string codTem, string CodProd, string Cantidad, string Producto, string PreUnt, string Importe, string UnidMedida)
        {
            return d_tem.BD_Ingresar_Temporal_Det(codTem,  CodProd,  Cantidad,  Producto,  PreUnt, Importe, UnidMedida);
        }
        public DataTable BD_Mostrar_Temporales(string id)
        {
            return d_tem.BD_Mostrar_Temporales(id);
        }
        public int BD_Validar_Credito(string Id_tem)
        {
            return d_tem.BD_Validar_Credito(Id_tem);
        }
        public int BD_Eliminar_Temporal(string idTem)
        {
            return d_tem.BD_Eliminar_Temporal(idTem);
        }
        public int RN_ActualizarEstadoSunat_NC_Temporal(string idTem, string hash_cpe)
        {
            return d_tem.BD_ActualizarEstadoSunat_NC_Temporal(idTem,hash_cpe);
        }
    }
}
