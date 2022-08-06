using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPV_Capa_Entidad
{
    public class EN_Usuario
    {
        private string _Id_Usu;
        private string _Nombres;
        private string _Apellidos;
        private int _Id_Dis;
        private string _Ubicacion_Foto;
        private DateTime _Fecha_Ncmiento;
        private int _Id_Rol;
        private string _Correo;
        private string _Estado_Usu;

        public string Id_Usu { get => _Id_Usu; set => _Id_Usu = value; }
        public string Nombres { get => _Nombres; set => _Nombres = value; }
        public string Apellidos { get => _Apellidos; set => _Apellidos = value; }
        public int Id_Dis { get => _Id_Dis; set => _Id_Dis = value; }
        public string Ubicacion_Foto { get => _Ubicacion_Foto; set => _Ubicacion_Foto = value; }
        public DateTime Fecha_Ncmiento { get => _Fecha_Ncmiento; set => _Fecha_Ncmiento = value; }
        public int Id_Rol { get => _Id_Rol; set => _Id_Rol = value; }
        public string Correo { get => _Correo; set => _Correo = value; }
        public string Estado_Usu { get => _Estado_Usu; set => _Estado_Usu = value; }
    }
}
