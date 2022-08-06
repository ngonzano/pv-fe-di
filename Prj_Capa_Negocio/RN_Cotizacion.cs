using SPV_Capa_Datos;
using SPV_Capa_Entidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPV_Capa_Negocio
{
    public class RN_Cotizacion
    {
        BD_Cotizacion d_coti = new BD_Cotizacion();

       public int RN_Registrar_Cotizacion(EN_Cotizacion e_coti)
        {
            return d_coti.BD_Registrar_Cotizacion(e_coti);
        }
        public int RN_Editar_Cotizacion(EN_Cotizacion e_coti)
        {
            return d_coti.BD_Editar_Cotizacion(e_coti);
        }
        public int RN_Cambiar_Estado_Cotizacion(string id_coti, string xestado)
        {
            return d_coti.BD_Cambiar_Estado_Cotizacion(id_coti,xestado);
        }
        //Consultas
        public DataTable RN_Buscar_Cotizacion_Para_Editar(string nro_Coti)
        {
            return d_coti.BD_Buscar_Cotizacion_Para_Editar(nro_Coti);
        }
        public DataTable RN_Buscar_Cotizacion_Dia_Mes(string tipo, DateTime fecha)
        {
            return d_coti.BD_Buscar_Cotizacion_Dia_Mes(tipo,fecha);
        }
        public DataTable RN_Buscar_CotizacionRangoFecha(DateTime fi, DateTime ff, string nombre)
        {
            return d_coti.BD_Buscar_CotizacionRangoFecha(fi,ff,nombre);
        }
    }
}
