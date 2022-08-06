using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPV_Capa_Entidad
{
   public  class EN_notacredito
    {

        private string _IdCre;
        // Private _Ruc As String
        private string _TipoConpronte;
        private string _OtroDatos;
        private DateTime _Fecha_Emi;
        // Private _cliente As String
        private string _NroDoc;
        private double _total;
        private double _Igv;
        private double _SubTotal;
        private int _Idusu;
        private string _MotivoEmisi;
        private string _Son;
        private string _Estadodinero;

        private string _idcliente;
        private string _CdrSunat;
        private string _HashCpe;
        private string _NC_Enviado_Sunat;
        



        public string HasCpe
        {
            get
            {
                return _HashCpe;
            }
            set
            {
                _HashCpe = value;
            }
        }

        public string CdrSunat
        {
            get
            {
                return _CdrSunat;
            }
            set
            {
                _CdrSunat = value;
            }
        }


        public string Id_Cliente
        {
            get
            {
                return _idcliente;
            }
            set
            {
                _idcliente = value;
            }
        }


        public string EstadoDinero
        {
            get
            {
                return _Estadodinero;
            }
            set
            {
                _Estadodinero = value;
            }
        }

        public string son
        {
            get
            {
                return _Son;
            }
            set
            {
                _Son = value;
            }
        }

        public string motivoEmisio
        {
            get
            {
                return _MotivoEmisi;
            }
            set
            {
                _MotivoEmisi = value;
            }
        }

        public double SubTotal
        {
            get
            {
                return _SubTotal;
            }
            set
            {
                _SubTotal = value;
            }
        }

        public double Igv
        {
            get
            {
                return _Igv;
            }
            set
            {
                _Igv = value;
            }
        }

        public string OtrosDatos
        {
            get
            {
                return _OtroDatos;
            }
            set
            {
                _OtroDatos = value;
            }
        }

        public string TipoComprobnte
        {
            get
            {
                return _TipoConpronte;
            }
            set
            {
                _TipoConpronte = value;
            }
        }

        // Public Property Ruc As String
        // Get
        // Return _Ruc
        // End Get
        // Set(ByVal value As String)
        // _Ruc = value
        // End Set
        // End Property




        public int idusu
        {
            get
            {
                return _Idusu;
            }
            set
            {
                _Idusu = value;
            }
        }


        public double total
        {
            get
            {
                return _total;
            }
            set
            {
                _total = value;
            }
        }


        public string nrodoc
        {
            get
            {
                return _NroDoc;
            }
            set
            {
                _NroDoc = value;
            }
        }


        // Public Property cliente As String
        // Get
        // Return _cliente
        // End Get
        // Set(ByVal value As String)
        // _cliente = value
        // End Set
        // End Property

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


        public DateTime Fechaemi
        {
            get
            {
                return _Fecha_Emi;
            }
            set
            {
                _Fecha_Emi = value;
            }
        }

        public string NC_Enviado_Sunat { get => _NC_Enviado_Sunat; set => _NC_Enviado_Sunat = value; }
    }
}
