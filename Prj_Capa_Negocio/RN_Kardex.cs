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
   public class RN_Kardex
    {
        BD_Kardex d_kardex = new BD_Kardex();
        EN_Kardex e_kardex = new EN_Kardex();

        public int RN_Registrar_det_Kardex(EN_Kardex e_Kardex)
        {
            return d_kardex.BD_Registrar_det_Kardex(e_Kardex);
        }
        public int RN_Crear_Kardex(string idkardex, string idprod, string idprovee)
        {
            return d_kardex.BD_Crear_Kardex(idkardex,idprod,idprovee);
        }
        public bool RN_Sp_Ver_sihay_Kardex(string idprod)
        {
            return d_kardex.BD_Sp_Ver_sihay_Kardex(idprod);
        }
        public DataTable RN_BuscarKardexDetalleProducto(string IdProd)
        {
            return d_kardex.BD_BuscarKardexDetalleProducto(IdProd);
        }
        public DataTable RN_Buscar_ProductoKardex(DateTime fi, DateTime ff, string nom)
        {
            return d_kardex.BD_Buscar_ProductoKardex(fi,ff,nom);
        }
        public DataTable RN_Entrada_Salida_Kardex(DateTime fi, DateTime ff)
        {
            return d_kardex.BD_Entrada_Salida_Kardex(fi,ff);
        }
    }
}
