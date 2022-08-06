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
   public class RN_Caja
    {
        BD_Caja d_caja = new BD_Caja();
        public int RN_Ingresar_Caja(EN_Caja e_caja)
        {
            return d_caja.BD_Ingresar_Caja(e_caja);
        }
        public int RN_Editar_Total_Caja(EN_Caja e_caja)
        {
            return d_caja.BD_Editar_Total_Caja(e_caja);
        }
        public DataTable RN_Mostrar_Todo_Caja(string concepto)
        {
            return d_caja.BD_Mostrar_Todo_Caja(concepto);
        }
        public DataTable RN_Mostrar_Caja_Dia()
        {
            return d_caja.BD_Mostrar_Caja_Dia();
        }
        public DataTable RN_Mostrar_Caja_Mes(DateTime fecha)
        {
            return d_caja.BD_Mostrar_Caja_Mes(fecha);
        }
        public DataTable RN_Mostrar_Movi_Caja(string valor)
        {
            return d_caja.BD_Mostrar_Movi_Caja(valor);
        }
        public DataTable RN_Buscar_Caja_RangoFechas(DateTime fi, DateTime ff, string concepto)
        {
            return d_caja.BD_Buscar_Caja_RangoFechas(fi,ff,concepto);
        }
        public int RN_AnularMovCaja(string Nro_Doc, string EstadoCaja)
        {
            return d_caja.BD_AnularMovCaja(Nro_Doc,EstadoCaja);
        }
        public bool RN_Estado_Documento_enCaja(string idDoc)
        {
            return d_caja.BD_Estado_Documento_enCaja(idDoc);
        }
     
    }
}
