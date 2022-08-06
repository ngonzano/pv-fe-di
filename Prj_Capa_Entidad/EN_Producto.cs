using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPV_Capa_Entidad
{
  public class EN_Producto
    {
        private string _idpro;
        private string _idprove;
        private string _descripcion;
        private double _frank;
        private double _Pre_compraSol;
        private double _pre_CompraDolar;
        private double _StockActual;
        private int _idCat;
        private int _idMar;

        private string _Foto;
        private double _Pre_Venta_Menor;
        private double _Pre_Venta_Mayor;
        private double _Pre_Venta_Dolar;
        private string _UndMdida;
        private double _PesoUnit;
        private double _Utilidad;
        private string _TipoProd;
        private double _ValorporProd;

        public string Idpro { get => _idpro; set => _idpro = value; }
        public string Idprove { get => _idprove; set => _idprove = value; }
        public string Descripcion { get => _descripcion; set => _descripcion = value; }
        public double Frank { get => _frank; set => _frank = value; }
        public double Pre_compraSol { get => _Pre_compraSol; set => _Pre_compraSol = value; }
        public double Pre_CompraDolar { get => _pre_CompraDolar; set => _pre_CompraDolar = value; }
        public double StockActual { get => _StockActual; set => _StockActual = value; }
        public int IdCat { get => _idCat; set => _idCat = value; }
        public int IdMar { get => _idMar; set => _idMar = value; }
        public string Foto { get => _Foto; set => _Foto = value; }
        public double Pre_Venta_Menor { get => _Pre_Venta_Menor; set => _Pre_Venta_Menor = value; }
        public double Pre_Venta_Mayor { get => _Pre_Venta_Mayor; set => _Pre_Venta_Mayor = value; }
        public double Pre_Venta_Dolar { get => _Pre_Venta_Dolar; set => _Pre_Venta_Dolar = value; }
        public string UndMdida { get => _UndMdida; set => _UndMdida = value; }
        public double PesoUnit { get => _PesoUnit; set => _PesoUnit = value; }
        public double Utilidad { get => _Utilidad; set => _Utilidad = value; }
        public string TipoProd { get => _TipoProd; set => _TipoProd = value; }
        public double ValorporProd { get => _ValorporProd; set => _ValorporProd = value; }
    }
}
