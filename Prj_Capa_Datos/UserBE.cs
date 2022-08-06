using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPV_Capa_Datos
{
    public class UserBE
    {
        public string user { get; set; }
        public byte[] pass { get; set; }
        public byte[] salt { get; set; }
        public UserBE()
        {

        }
    }
}
