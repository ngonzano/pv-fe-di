using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPV_Capa_Entidad
{
  public  class EN_DetNotacredito
    {

        private string _IdCre;
        private string _Idpro;
        private double _PrecioUnit;
        private double _Improtecre;
        private double _Cantidad;
        private string _TipoProdcto;
        private string _DetalleProdcto;
        private double _Cant_Origen;


        public string Detalle_Prodcto
        {
            get
            {
                return _DetalleProdcto;
            }
            set
            {
                _DetalleProdcto = value;
            }
        }
        public double ImporteCre
        {
            get
            {
                return _Improtecre;
            }
            set
            {
                _Improtecre = value;
            }
        }

        public string idcre
        {
            get
            {
                return _IdCre;
            }
            set
            {
                _IdCre = value;
            }
        }

        public string TipoProdcto
        {
            get
            {
                return _TipoProdcto;
            }
            set
            {
                _TipoProdcto = value;
            }
        }

        public double Cantidadc
        {
            get
            {
                return _Cantidad;
            }
            set
            {
                _Cantidad = value;
            }
        }

        public double PrecioUnit
        {
            get
            {
                return _PrecioUnit;
            }
            set
            {
                _PrecioUnit = value;
            }
        }

        public string idpro
        {
            get
            {
                return _Idpro;
            }
            set
            {
                _Idpro = value;
            }
        }

        public double Cant_Origen { get => _Cant_Origen; set => _Cant_Origen = value; }
    }
}
