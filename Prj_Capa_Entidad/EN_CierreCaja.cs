using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPV_Capa_Entidad
{
    public class EN_CierreCaja
    {
        private string _idCierre;
        private double _Apertura_Caja;
        private double _Total_Ingreso;
        private double _TotalEgreso;
        private string _Id_usu;
        private double _TodoDeposito;
        private double _TotalGanancia;
        private double _TotalEntregado;
        private double _SaldoSiguiente;
        private double _TotalFactura;
        private double _TotalBoleta;
        private double _Totalnota;
        private double _TotalCreditoCobrado;
        private double _TotalCreditoEmitido;

        public string IdCierre { get => _idCierre; set => _idCierre = value; }
        public double Apertura_Caja { get => _Apertura_Caja; set => _Apertura_Caja = value; }
        public double Total_Ingreso { get => _Total_Ingreso; set => _Total_Ingreso = value; }
        public double TotalEgreso { get => _TotalEgreso; set => _TotalEgreso = value; }
        public string Id_usu { get => _Id_usu; set => _Id_usu = value; }
        public double TodoDeposito { get => _TodoDeposito; set => _TodoDeposito = value; }
        public double TotalGanancia { get => _TotalGanancia; set => _TotalGanancia = value; }
        public double TotalEntregado { get => _TotalEntregado; set => _TotalEntregado = value; }
        public double SaldoSiguiente { get => _SaldoSiguiente; set => _SaldoSiguiente = value; }
        public double TotalFactura { get => _TotalFactura; set => _TotalFactura = value; }
        public double TotalBoleta { get => _TotalBoleta; set => _TotalBoleta = value; }
        public double Totalnota { get => _Totalnota; set => _Totalnota = value; }
        public double TotalCreditoCobrado { get => _TotalCreditoCobrado; set => _TotalCreditoCobrado = value; }
        public double TotalCreditoEmitido { get => _TotalCreditoEmitido; set => _TotalCreditoEmitido = value; }
    }
}
