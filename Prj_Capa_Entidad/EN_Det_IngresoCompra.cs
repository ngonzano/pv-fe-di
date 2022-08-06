using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPV_Capa_Entidad
{
   public class EN_Det_IngresoCompra
    {
        private string id_ingreso;
        private string _id_pro;
        private double precio;
        private double _Cantidad;
		private double _Importe;

        public string Id_ingreso { get => id_ingreso; set => id_ingreso = value; }
        public double Precio { get => precio; set => precio = value; }
        public string Id_pro { get => _id_pro; set => _id_pro = value; }
        public double Cantidad { get => _Cantidad; set => _Cantidad = value; }
        public double Importe { get => _Importe; set => _Importe = value; }
    }
}
