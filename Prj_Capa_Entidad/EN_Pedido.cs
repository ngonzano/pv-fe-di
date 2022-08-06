using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPV_Capa_Entidad
{
public class EN_Pedido
    {

        private string _id_Ped;
        private string _id_Prod;
        private string _Id_Cliente;
        private DateTime _Fecha_Ped;
        private double _SubTotal;
        private double _IgvPed;
        private double _TotalPed;
        private string _id_Usu;
        private double _TotalGancia;
        private string _Estado_Ped;
        private double _subtotal_Gravado;
        private double _IgvGravado;
        private double _totalGravado;

        public string Id_Ped { get => _id_Ped; set => _id_Ped = value; }
        public string Id_Cliente { get => _Id_Cliente; set => _Id_Cliente = value; }
        public DateTime Fecha_Ped { get => _Fecha_Ped; set => _Fecha_Ped = value; }
        public double SubTotal { get => _SubTotal; set => _SubTotal = value; }
        public double IgvPed { get => _IgvPed; set => _IgvPed = value; }
        public double TotalPed { get => _TotalPed; set => _TotalPed = value; }
        public string Id_Usu { get => _id_Usu; set => _id_Usu = value; }
        public double TotalGancia { get => _TotalGancia; set => _TotalGancia = value; }
        public string Estado_Ped { get => _Estado_Ped; set => _Estado_Ped = value; }
        public string Id_Prod { get => _id_Prod; set => _id_Prod = value; }
        public double Subtotal_Gravado { get => _subtotal_Gravado; set => _subtotal_Gravado = value; }
        public double IgvGravado { get => _IgvGravado; set => _IgvGravado = value; }
        public double TotalGravado { get => _totalGravado; set => _totalGravado = value; }
    }
}
