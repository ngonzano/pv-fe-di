using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPV_Capa_Entidad
{
   public class EN_Kardex
    {
      
        private string _Id_Krdx;
        private int _Item;
        private string _Doc_Soport;
        private string _Det_Operacion;
        private double _Cantidad_In;
        private double _Precio_Unt_In;
        private double _Costo_Total_In;
        private double _Cantidad_Out;
        private double _Precio_Unt_Out;
        private double _Importe_Total_Out;
        private double _Cantidad_Saldo;
        private double _Promedio;
        private double _Costo_Total_Saldo;

        public string Id_Krdx { get => _Id_Krdx; set => _Id_Krdx = value; }
        public int Item { get => _Item; set => _Item = value; }
        public string Doc_Soport { get => _Doc_Soport; set => _Doc_Soport = value; }
        public string Det_Operacion { get => _Det_Operacion; set => _Det_Operacion = value; }
        public double Cantidad_In { get => _Cantidad_In; set => _Cantidad_In = value; }
        public double Precio_Unt_In { get => _Precio_Unt_In; set => _Precio_Unt_In = value; }
        public double Costo_Total_In { get => _Costo_Total_In; set => _Costo_Total_In = value; }
        public double Cantidad_Out { get => _Cantidad_Out; set => _Cantidad_Out = value; }
        public double Precio_Unt_Out { get => _Precio_Unt_Out; set => _Precio_Unt_Out = value; }
        public double Importe_Total_Out { get => _Importe_Total_Out; set => _Importe_Total_Out = value; }
        public double Cantidad_Saldo { get => _Cantidad_Saldo; set => _Cantidad_Saldo = value; }
        public double Promedio { get => _Promedio; set => _Promedio = value; }
        public double Costo_Total_Saldo { get => _Costo_Total_Saldo; set => _Costo_Total_Saldo = value; }
    }
}
