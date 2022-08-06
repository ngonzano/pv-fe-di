using SPV_Capa_Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SPV_Capa_Datos;
using System.Data;

namespace SPV_Capa_Negocio
{
    public class RN_Documento
    {
        BD_Documento d_docu = new BD_Documento();
        public DataTable RN_Leer_Docs_delDia_PorTiopoDoc(DateTime fecha, int docu)
        {
            return d_docu.BD_Leer_Docs_delDia_PorTiopoDoc(fecha, docu);
        }
        public int RN_Ingresar_Documento(EN_Documento e_doc)
        {
            return d_docu.BD_Ingresar_Documento(e_doc);
        }
        public int RN_Editar_Documento(EN_Documento e_doc)
        {
            return d_docu.BD_Editar_Documento(e_doc);
        }
        public bool RN_Verificar_Nro_Documento(string idDoc)
        {
            return d_docu.BD_Verificar_Nro_Documento(idDoc);
        }
        public DataTable RN_BuscarDocumentoValor(DateTime fi, DateTime ff, string valor)
        {
            return d_docu.BD_BuscarDocumentoValor(ff, fi, valor);
        }
        public DataTable RN_Buscar_Documento_Dia(DateTime fecha)
        {
            return d_docu.BD_Buscar_Documento_Dia(fecha);
        }
        public DataTable RN_Buscar_Documento_Mes(DateTime fecha)
        {
            return d_docu.BD_Buscar_Documento_Mes(fecha);
        }
        public DataTable RN_Buscar_Comprobantes_Mes_Documento(DateTime fecha, string iddocum)
        {
            return d_docu.BD_Buscar_Comprobantes_Mes_Documento(fecha, iddocum);
        }
        public DataTable RN_Buscar_Documento_y_Detalle(string nroDoc)
        {
            return d_docu.BD_Buscar_Documento_y_Detalle(nroDoc);
        }
        public int RN_Anular_Documento(string iddocum, string estado)
        {
            return d_docu.BD_Anular_Documento(iddocum, estado);
        }
        public int RN_Cambiar_TipoPago_Documento(string iddocum, string tipopago)
        {
            return d_docu.BD_Cambiar_TipoPago_Documento(iddocum, tipopago);
        }
        public int RN_Cambiar_RPT_EstadoSunat(string iddocum, string EstadoCDR, string hash_CPE)
        {
            return d_docu.BD_Cambiar_RPT_EstadoSunat(iddocum, EstadoCDR, hash_CPE);
        }
        public DataTable BD_BuscarDocumentoValorUnico(string valor)
        {
            return d_docu.BD_BuscarDocumentoValorUnico(valor);
        }
        public DataTable RN_Buscar_Documento_y_Detalle2(string nroDoc)
        {
            return d_docu.BD_Buscar_Documento_y_Detalle2(nroDoc);
        }
        public bool RN_Validar_FechaDoc_EnResumenBoleta(DateTime fechaElegida, DateTime fecha_doc)
        {
            return d_docu.BD_Validar_FechaDoc_EnResumenBoleta(fechaElegida,fecha_doc);
        }
        public int RN_ActualizarBajasSunat(string id_Doc, string EstadoBajada, string NroTicket_Baja, string Hash_CPE_Baja)
        {
            return d_docu.BD_ActualizarBajasSunat( id_Doc,  EstadoBajada,  NroTicket_Baja,  Hash_CPE_Baja);
        }

    }
}
