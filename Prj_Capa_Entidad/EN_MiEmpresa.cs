using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPV_Capa_Entidad
{
    public class EN_MiEmpresa
    {
       private int _idrancho;
       private string _nombrerancho;
       private string _nroRuc;
       private string _direccionran;
       private string _correo;
       private string _clavecorreo;
       private string _clavesol;
       private string _usuariosol;
       private string _clavecertificado;
       private string _obs;

        public int Idrancho { get => _idrancho; set => _idrancho = value; }
        public string Nombrerancho { get => _nombrerancho; set => _nombrerancho = value; }
        public string NroRuc { get => _nroRuc; set => _nroRuc = value; }
        public string Direccionran { get => _direccionran; set => _direccionran = value; }
        public string Correo { get => _correo; set => _correo = value; }
        public string Clavecorreo { get => _clavecorreo; set => _clavecorreo = value; }
        public string Clavesol { get => _clavesol; set => _clavesol = value; }
        public string Usuariosol { get => _usuariosol; set => _usuariosol = value; }
        public string Clavecertificado { get => _clavecertificado; set => _clavecertificado = value; }
        public string Obs { get => _obs; set => _obs = value; }
    }
}
