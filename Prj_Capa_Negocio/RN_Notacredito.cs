using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using SPV_Capa_Datos;
using SPV_Capa_Entidad;


namespace SPV_Capa_Negocio
{
  public   class RN_Notacredito
    {
        public DataTable RN_Buscar_NC_PendientePago(string xvalor)
        {
            BD_notaCredito nc = new BD_notaCredito();
            return nc.BD_Buscar_NC_PendientePago(xvalor);
        }
        public bool RN_Verificar_NC_PendientePago(string nroDoc)
        {
            BD_notaCredito nc = new BD_notaCredito();
            return nc.BD_Verificar_NC_PendientePago(nroDoc);
        }
        public int RN_Agregar_NotaCredito(EN_notacredito ObjPed)
        {
            BD_notaCredito obj = new BD_notaCredito();
          return  obj.BD_Agregar_NotaCredito(ObjPed);
        }


        public DataTable RN_Cargar_NotaCredito_Detalle(string xvalor)
        {
            BD_notaCredito obj = new BD_notaCredito();
            return obj.BD_Cargar_NotaCredito_Detalle(xvalor);
        }

        public int RN_Agregar_Items_Detalle_notacredito(EN_DetNotacredito  ObjDet)
        {
            BD_notaCredito  obj = new BD_notaCredito();
           return obj.BD_Agregar_Items_Detalle_notacredito(ObjDet);
        }

        public DataTable RN_Buscardor_Gneral_NotasCreditos(string xvalor)
        {
            BD_notaCredito  obj = new BD_notaCredito ();
            return obj.BD_Buscardor_Gneral_NotasCreditos(xvalor);
        }

        public DataTable RN_Buscar_NotaCredito_Pormes(DateTime xvalor)
        {
            BD_notaCredito obj = new BD_notaCredito();
            return obj.BD_Buscar_NotaCredito_Pormes(xvalor);
        }

        public int RN_Actualizar_EstadoDinero_NC(string nroDoc_NC, string xstadodinero)
        {
            BD_notaCredito obj = new BD_notaCredito();
           return obj.BD_Actualizar_EstadoDinero_NC(nroDoc_NC, xstadodinero);
        }        

        // 'todas las notas de credito
        public DataTable RN_Leer_Todas_notadecredito()
        {
            BD_notaCredito obj = new BD_notaCredito();
            return obj.BD_Leer_Todas_notadecredito();
        }

        // 'solo los emitidos hoy
        public DataTable RN_Leer_Todas_notadecredito_emitidosHOy()
        {
            BD_notaCredito  obj = new BD_notaCredito();
            return obj.BD_Leer_Todas_notadecredito_emitidosHOy();
        }


        public int RN_Actualizar_EstadoSunat_NC(string nroDoc_NC, string CdrSunat, string HashCpe)
        {
            BD_notaCredito obj = new BD_notaCredito();
          return  obj.BD_Actualizar_EstadoSunat_NC(nroDoc_NC, CdrSunat, HashCpe);
        }

        public bool RN_Verificar_SiFactura_Tiene_NotaCredito(string numFactu)
        {
            BD_notaCredito obj = new BD_notaCredito();
            return obj.BD_Verificar_SiFactura_Tiene_NotaCredito(numFactu);
        }


    }
}
