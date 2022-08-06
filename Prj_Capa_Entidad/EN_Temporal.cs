using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPV_Capa_Entidad
{
    public class EN_Temporal
    {
        /*
         @codTem Nchar (12),
        @FechaEmi varchar (20),
        @cliente varchar (150),
        @Ruc varchar (20),
        @Direccion varchar (150),
        @SubTtal varchar (10),
        @IgvT varchar (10),
        @TotalT varchar (10),
        @SonT varchar (200),
        @vendedor varchar (120)
         */
        private string _codTem;
        private string _FechaEmi;
        private string _cliente;
        private string _Ruc;
        private string _Direccion;
        private string _SubTtal;
        private string _IgvT;
        private string _TotalT;
        private string _SonT;
        private string _vendedor;
        private object _CodigoQR;
        private string _tipoComprobante;
        private string _hash_cpe;
        private string _tipoPago;
        private string _motivoEmis;
        private string _forma_pago;
        private string _monto_deuda;
        private string _fecha_venc_credito;

        public string CodTem { get => _codTem; set => _codTem = value; }
        public string FechaEmi { get => _FechaEmi; set => _FechaEmi = value; }
        public string Cliente { get => _cliente; set => _cliente = value; }
        public string Ruc { get => _Ruc; set => _Ruc = value; }
        public string Direccion { get => _Direccion; set => _Direccion = value; }
        public string SubTtal { get => _SubTtal; set => _SubTtal = value; }
        public string IgvT { get => _IgvT; set => _IgvT = value; }
        public string TotalT { get => _TotalT; set => _TotalT = value; }
        public string SonT { get => _SonT; set => _SonT = value; }
        public string Vendedor { get => _vendedor; set => _vendedor = value; }
        public object CodigoQR { get => _CodigoQR; set => _CodigoQR = value; }
        public string TipoComprobante { get => _tipoComprobante; set => _tipoComprobante = value; }
        public string Hash_cpe { get => _hash_cpe; set => _hash_cpe = value; }
        public string TipoPago { get => _tipoPago; set => _tipoPago = value; }
        public string MotivoEmis { get => _motivoEmis; set => _motivoEmis = value; }
        public string Forma_pago { get => _forma_pago; set => _forma_pago = value; }
        public string Monto_deuda { get => _monto_deuda; set => _monto_deuda = value; }
        public string Fecha_venc_credito { get => _fecha_venc_credito; set => _fecha_venc_credito = value; }
    }
}
