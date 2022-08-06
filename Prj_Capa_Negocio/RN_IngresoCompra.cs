using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SPV_Capa_Entidad;
using SPV_Capa_Datos;
using System.Data;

namespace SPV_Capa_Negocio
{
    public class RN_IngresoCompra
    {
        BD_IngresoCompra n_ingCompra = new BD_IngresoCompra();
        public DataTable BD_Buscar_Documento_Detalle(string xvalor)
        {
            return n_ingCompra.BD_Buscar_Documento_Detalle(xvalor);
        }
        public int RN_Ingresar_HeaderRegistroCompra(EN_IngresarCompra e_ingCompra)
        {
            return n_ingCompra.BD_Ingresar_Header_RegistroCompra(e_ingCompra);
        }
        public int RN_Ingresar_Detalle_RegistroCompra(EN_Det_IngresoCompra e_DetaingCompra)
        {
            return n_ingCompra.BD_Ingresar_Detalle_RegistroCompra(e_DetaingCompra);
        }
        public bool RN_Validar_NroDocumento_fisico(string NroDocumento)
        {
            return n_ingCompra.BD_Validar_NroDocumento_fisico(NroDocumento);
        }
        public DataTable RN_Buscar_Compras_Explorador(string valor)
        {
            return n_ingCompra.BD_Buscar_Compras_Explorador(valor);
        }
        public DataTable RN_MostrarTodoCompras_Explo(DateTime fi,DateTime ff,string valor)
        {
            return n_ingCompra.BD_MostrarTodoCompras_Explo(fi,ff,valor);
        }
        public DataTable RN_Buscar_Compras_Expl_MES_DIA(string tipo,DateTime fecha)
        {
            return n_ingCompra.BD_Buscar_Compras_Expl_MES_DIA(tipo,fecha);
        }
        public int RN_Borrar_Compra(string idcompra)
        {
            return n_ingCompra.BD_Borrar_Compra(idcompra);
        }
    }
}
