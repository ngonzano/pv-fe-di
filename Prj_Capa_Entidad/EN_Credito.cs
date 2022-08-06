using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPV_Capa_Entidad
{
   public class EN_Credito
    {

        private string _idnotacredito;
        private string _idDoc;
        private DateTime _Fecha_Credito;
        private string _nomcliente;
        private double _total_ped;
        private double _Saldo_Pdnte;
        private DateTime _Fecha_vncmnto;
        private string _TipoPagoCredito;

        public string Idnotacredito { get => _idnotacredito; set => _idnotacredito = value; }
        public string IdDoc { get => _idDoc; set => _idDoc = value; }
        public DateTime Fecha_Credito { get => _Fecha_Credito; set => _Fecha_Credito = value; }
        public string Nomcliente { get => _nomcliente; set => _nomcliente = value; }
        public double Total_ped { get => _total_ped; set => _total_ped = value; }
        public double Saldo_Pdnte { get => _Saldo_Pdnte; set => _Saldo_Pdnte = value; }
        public DateTime Fecha_vncmnto { get => _Fecha_vncmnto; set => _Fecha_vncmnto = value; }
        public string TipoPagoCredito { get => _TipoPagoCredito; set => _TipoPagoCredito = value; }
    }
}
