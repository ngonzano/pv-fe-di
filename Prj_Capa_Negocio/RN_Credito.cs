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
    public class RN_Credito
    {
        BD_Credito b_credi = new BD_Credito();
        public int RN_Ingresar_Credito_Header(EN_Credito e_cre)
        {
            return b_credi.BD_Ingresar_Credito_Header(e_cre);
        }
        public int RN_Ingresar_Credito_Det(EN_Det_Credito  e_detcred)
        {
            return b_credi.BD_Ingresar_Credito_Det(e_detcred);
        }
       
        public double RN_Mostrar_Credito_Cliente(string xvalor)
        {
            return b_credi.BD_Mostrar_Credito_Cliente(xvalor);
        }
        public int RN_Validar_Credito(string iddoc)
        {
            return b_credi.BD_Validar_Credito(iddoc);
        }
        public int RN_Validar_Vencimiento_credito(string codCredit)
        {
            return b_credi.BD_Validar_Vencimiento_credito(codCredit);
        }
        public int RN_Actualizar_Saldo_Pendiente(string idNotCred, double SaldoPendiente, string Estado)
        {
            return b_credi.BD_Actualizar_Saldo_Pendiente(idNotCred,SaldoPendiente,Estado);
        }
        public int RN_Actualizar_Estado_Credito(string idCredito, string Estado)
        {
            return b_credi.BD_Actualizar_Estado_Credito(idCredito,Estado);
        }
        public DataTable RN_Mostrar_Credito_Estado(string estado)
        {
            return b_credi.BD_Mostrar_Credito_Estado(estado);
        }
        public DataTable RN_Mostrar_Credito_Mes(DateTime mes)
        {
            return b_credi.BD_Mostrar_Credito_Mes(mes);
        }
        public DataTable RN_Mostrar_Credito_Dia(DateTime dia)
        {
            return b_credi.BD_Mostrar_Credito_Dia(dia);
        }
        public DataTable RN_Buscar_Creditos(string nomCliente)
        {
            return b_credi.BD_Buscar_Creditos(nomCliente);
        }
        public DataTable RN_Mostrar_Detalle_Credito(string id_Cred)
        {
            return b_credi.BD_Mostrar_Detalle_Credito(id_Cred);
        }
        public int RN_Eliminar_credito_Permanente(string Idcredito)
        {
            return b_credi.BD_Eliminar_credito_Permanente(Idcredito);
        }
        public DataTable RN_Mostrar_TodoCredito(DateTime fi, DateTime ff, string nom)
        {
            return b_credi.BD_Mostrar_TodoCredito(fi,ff,nom);
        }
        public DataTable BD_Buscar_CreditoPrint(DateTime fi, DateTime ff, string idCod)
        {
            return b_credi.BD_Buscar_CreditoPrint(fi,ff,idCod);
        }
        public DataTable RN_Buscar_Credito_Documento(string idDoc)
        {
            return b_credi.BD_Buscar_Credito_Documento(idDoc);
        }
    }
}
