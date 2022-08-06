using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPV_Capa_Entidad
{
   public class EN_Det_Credito
    {
        private string _idnotacredito;
        private double _Acuenta;
        private double _saldoactual;
        private DateTime _Fecha_Pago;
        private string _TipoPago;
        private string _nroOpera;
        private string _idUsu;

        public string Idnotacredito { get => _idnotacredito; set => _idnotacredito = value; }
        public double Acuenta { get => _Acuenta; set => _Acuenta = value; }
        public double Saldoactual { get => _saldoactual; set => _saldoactual = value; }
        public DateTime Fecha_Pago { get => _Fecha_Pago; set => _Fecha_Pago = value; }
        public string TipoPago { get => _TipoPago; set => _TipoPago = value; }
        public string NroOpera { get => _nroOpera; set => _nroOpera = value; }
        public string IdUsu { get => _idUsu; set => _idUsu = value; }
    }
}
