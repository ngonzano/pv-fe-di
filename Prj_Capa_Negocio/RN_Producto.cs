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
   public class RN_Producto
    {
        BD_Producto b_prod = new BD_Producto();

        public int RN_Registrar_Producto(EN_Producto e_prod )
        {
            return b_prod.BD_Registrar_Producto(e_prod);
        }
        //EDITAR
        public int RN_Editar_Producto(EN_Producto e_prod)
        {
          return b_prod.BD_Editar_Producto(e_prod);
        }
        //MOSTRAR
        public DataTable RN_Mostrar_Todas_Producto()
        {
            return b_prod.BD_Mostrar_Todas_Producto();
        }
        public DataTable RN_Mostrar_UnidMedida()
        {
            return b_prod.BD_Mostrar_UnidMedida();
        }
        public DataTable RN_Buscar_UniMedia_Todos()
        {
            return b_prod.BD_Buscar_UniMedia_Todos();
        }
        public DataTable RN_Buscar_UniMedia(string Valor)
        {
            return b_prod.BD_Buscar_UniMedia(Valor);
        }
        //BUSCAR PROVEEDOR
        public DataTable RN_Buscar_Producto(string Valor)
        {
            return b_prod.BD_Buscar_Producto(Valor);
        }
        //ELIMINAR
        public void RN_Eliminar_Producto(string idprod)
        {
            b_prod.BD_Eliminar_Producto(idprod);
        }
        //DAR DE BAJA
        public void RN_DarBaja_Producto(string idProd)
        {
            b_prod.BD_DarBaja_Producto(idProd);
        }

        //CONTROL STOCK
        public void RN_SumarStock_Producto(string idprod, double stock)
        {
            b_prod.BD_SumarStock_Producto(idprod,stock);
        }
        public void RN_RestarStock_Producto(string idprod, double stock)
        {
            b_prod.BD_RestarStock_Producto(idprod,stock);
        }
        //Actualizar Compra Venta
        public void RN_ActPrec_CompraVenta_Producto(string idprod, double precompraSol, double PrecVenta_menor, double utili, double valorAlmacen)
        {
            b_prod.BD_ActPrec_CompraVenta_Producto(idprod, precompraSol, PrecVenta_menor, utili, valorAlmacen);
        }
        public double RN_Buscar_Stock_Producto(string idprod)
        {
            return b_prod.BD_Buscar_Stock_Producto(idprod);
        }
    }
}
