using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPV_Capa_Entidad
{
   public class EN_Caja
    {
        private DateTime _Fecha_Caja;
        private string _Tipo_Caja;
        private string _Concepto;
        private string _De_Para;
        private string _Nro_Doc;
        private double _ImporteCaja;
        private string _Id_Usu;
        private double _TotalUti;
        private string _TipoPago;
        private string _GeneradoPor;

        public DateTime Fecha_Caja { get => _Fecha_Caja; set => _Fecha_Caja = value; }
        public string Tipo_Caja { get => _Tipo_Caja; set => _Tipo_Caja = value; }
        public string Concepto { get => _Concepto; set => _Concepto = value; }
        public string De_Para { get => _De_Para; set => _De_Para = value; }
        public string Nro_Doc { get => _Nro_Doc; set => _Nro_Doc = value; }
        public double ImporteCaja { get => _ImporteCaja; set => _ImporteCaja = value; }
        public string Id_Usu { get => _Id_Usu; set => _Id_Usu = value; }
        public double TotalUti { get => _TotalUti; set => _TotalUti = value; }
        public string TipoPago { get => _TipoPago; set => _TipoPago = value; }
        public string GeneradoPor { get => _GeneradoPor; set => _GeneradoPor = value; }
    }
}
