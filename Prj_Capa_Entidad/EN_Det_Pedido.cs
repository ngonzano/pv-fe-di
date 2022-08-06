using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPV_Capa_Entidad
{
   public class EN_Det_Pedido
    {
		private string _id_Ped;
		private string _Id_Pro; 
		private double _Precio;
		private double _Cantidad;
		private double _Importe;
		private string _Tipo_Prod;
		private string _Und_Medida;
		private double _Utilidad_Unit;
		private double _TotalUtilidad;
        private string _AfectoIGV;
        private double _Precio_sinIgv;
        private double _subtotal_sinIgv;
        private double _Igv_subtotal;
        private string _Estado;
        private double _P_Cant_Original;

        public string Id_Ped { get => _id_Ped; set => _id_Ped = value; }
        public string Id_Pro { get => _Id_Pro; set => _Id_Pro = value; }
        public double Precio { get => _Precio; set => _Precio = value; }
        public double Cantidad { get => _Cantidad; set => _Cantidad = value; }
        public double Importe { get => _Importe; set => _Importe = value; }
        public string Tipo_Prod { get => _Tipo_Prod; set => _Tipo_Prod = value; }
        public string Und_Medida { get => _Und_Medida; set => _Und_Medida = value; }
        public double Utilidad_Unit { get => _Utilidad_Unit; set => _Utilidad_Unit = value; }
        public double TotalUtilidad { get => _TotalUtilidad; set => _TotalUtilidad = value; }
        public double Igv_subtotal { get => _Igv_subtotal; set => _Igv_subtotal = value; }
        public double Subtotal_sinIgv { get => _subtotal_sinIgv; set => _subtotal_sinIgv = value; }
        public double Precio_sinIgv { get => _Precio_sinIgv; set => _Precio_sinIgv = value; }
        public string AfectoIGV { get => _AfectoIGV; set => _AfectoIGV = value; }
        public string Estado { get => _Estado; set => _Estado = value; }
        public double P_Cant_Original { get => _P_Cant_Original; set => _P_Cant_Original = value; }
    }
}
