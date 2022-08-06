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
    public class RN_CierreCaja
    {
        BD_CierreCaja d_cie = new BD_CierreCaja();
        public int RN_Registrar_Inicio_CierreCaja(EN_CierreCaja e_cie)
        {
            return d_cie.BD_Registrar_Inicio_CierreCaja(e_cie);
        }
        //Cierre de Caja - Actualizar
        public int RN_Registrar_Fin_CierreCaja(EN_CierreCaja e_cie)
        {
            return d_cie.BD_Registrar_Fin_CierreCaja(e_cie);
        }
        public DataTable RN_Mostrar_CierreCaja_Dia()
        {
            return d_cie.BD_Mostrar_CierreCaja_Dia();
        }
        public bool RN_Validar_Registro_Caja()
        {
            return d_cie.BD_Validar_Registro_Caja();
        }
        //entradas
        public DataTable RN_Ventas_TipoDocumento_Dia(string tipoDoc, string tipoPago)
        {
            return d_cie.BD_Ventas_TipoDocumento_Dia(tipoDoc,tipoPago);
        }
        //salidas
        public DataTable RN_Gastos_TipoPago_Dia(string tipoPago)
        {
            return d_cie.BD_Gastos_TipoPago_Dia(tipoPago);
        }
        public DataTable RN_Venta_Credito_Dia()
        {
            return d_cie.BD_Venta_Credito_Dia();
        }
        public DataTable RN_Venta_Deposito_Dia()
        {
            return d_cie.BD_Venta_Deposito_Dia();
        }
        public DataTable RN_Venta_Utilidades_dia()
        {
            return d_cie.BD_Venta_Utilidades_dia();
        }
    }
}
