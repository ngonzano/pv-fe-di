using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPV_Capa_Entidad
{
   public class EN_Cotizacion
    {
		private string _Id_Cotiza;
		private string _Id_Ped;
		private DateTime _FechaCoti;
		private int _Vigencia;
		private double _TotalCotiza;
		private string _Condiciones;
		private string _PrecioconIgv;
		private string _EstadoCoti;

        public string Id_Cotiza { get => _Id_Cotiza; set => _Id_Cotiza = value; }
        public string Id_Ped { get => _Id_Ped; set => _Id_Ped = value; }
        public DateTime FechaCoti { get => _FechaCoti; set => _FechaCoti = value; }
        public int Vigencia { get => _Vigencia; set => _Vigencia = value; }
        public double TotalCotiza { get => _TotalCotiza; set => _TotalCotiza = value; }
        public string Condiciones { get => _Condiciones; set => _Condiciones = value; }
        public string PrecioconIgv { get => _PrecioconIgv; set => _PrecioconIgv = value; }
        public string EstadoCoti { get => _EstadoCoti; set => _EstadoCoti = value; }
    }
}
