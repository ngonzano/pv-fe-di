using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPV_Capa_Entidad
{
    public class EN_Documento
    {

        private string _id_Doc;
        private string _id_Ped;
        private int _Id_Tipo;
        private DateTime _Fecha_Emi;
        private double _Importe;
        private string _TipoPago;
        private string _NroOpera;
        private string _id_Usu;
        private double _Igv;
        private string _son;
        private double _TotalGanancia;
        private string _CDR_Sunat;
        private string _Hash_CPE;
        private string _EstadoBajada;
        private string _NroTicket_Baja;
        private string _Hash_CPE_Baja;

        public string Id_Doc { get => _id_Doc; set => _id_Doc = value; }
        public string Id_Ped { get => _id_Ped; set => _id_Ped = value; }
        public int Id_Tipo { get => _Id_Tipo; set => _Id_Tipo = value; }
        public DateTime Fecha_Emi { get => _Fecha_Emi; set => _Fecha_Emi = value; }
        public double Importe { get => _Importe; set => _Importe = value; }
        public string TipoPago { get => _TipoPago; set => _TipoPago = value; }
        public string NroOpera { get => _NroOpera; set => _NroOpera = value; }
        public string Id_Usu { get => _id_Usu; set => _id_Usu = value; }
        public double Igv { get => _Igv; set => _Igv = value; }
        public string Son { get => _son; set => _son = value; }
        public double TotalGanancia { get => _TotalGanancia; set => _TotalGanancia = value; }
        public string CDR_Sunat { get => _CDR_Sunat; set => _CDR_Sunat = value; }
        public string Hash_CPE { get => _Hash_CPE; set => _Hash_CPE = value; }
        public string EstadoBajada { get => _EstadoBajada; set => _EstadoBajada = value; }
        public string NroTicket_Baja { get => _NroTicket_Baja; set => _NroTicket_Baja = value; }
        public string Hash_CPE_Baja { get => _Hash_CPE_Baja; set => _Hash_CPE_Baja = value; }
    }
}
