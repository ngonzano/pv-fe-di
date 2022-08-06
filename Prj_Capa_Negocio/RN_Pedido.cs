using SPV_Capa_Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SPV_Capa_Datos;
using System.Data;

namespace SPV_Capa_Negocio
{
    public class RN_Pedido
    {
        BD_Pedido d_pedido = new BD_Pedido();
        public int RN_Registrar_Pedido_Header(EN_Pedido e_ped)
        {
            return d_pedido.BD_Registrar_Pedido_Header(e_ped);
        }
        public int RN_Registrar_Pedido_Det(EN_Det_Pedido e_det_ped)
        {
            return d_pedido.BD_Registrar_Pedido_Det(e_det_ped);
        }
        public int RN_Eliminar_Pedido_Det(string id_ped)
        {
            return d_pedido.BD_Eliminar_Pedido_Det(id_ped);
        }
        public int RN_Editar_Pedido_Header(EN_Pedido e_ped)
        {
            return d_pedido.BD_Editar_Pedido_Header(e_ped);
        }
        public bool RN_Validar_NroPedido(string NroPedido)
        {
            return d_pedido.BD_Validar_NroPedido(NroPedido);
        }
        public int RN_Poner_Pedido_Atendido(string id_ped)
        {
            return d_pedido.BD_Poner_Pedido_Atendido(id_ped);
        }
        public int RN_Cambiar_cliente_pedido(string id_ped, string id_cliente)
        {
            return d_pedido.BD_Cambiar_cliente_pedido(id_ped, id_cliente);
        }
        public int RN_Eliminar_Pedido_Permanente(string id_ped)
        {
            return d_pedido.BD_Eliminar_Pedido_Permanente(id_ped);
        }
        //Consultas
        public DataTable RN_Buscar_Pedido_Editar(string IdPedido)
        {
            return d_pedido.BD_Buscar_Pedido_Editar(IdPedido);
        }
        public DataTable RN_Buscar_Pedido_valor(string valor)
        {
            return d_pedido.BD_Buscar_Pedido_valor(valor);
        }
        public DataTable RN_Mostrar_pedido_fecha(string tipo, string xfecha)
        {
            return d_pedido.BD_Mostrar_pedido_fecha(tipo,xfecha);
        }
        public DataTable RN_Mostrar_pedido_Atender()
        {
            return d_pedido.BD_Mostrar_pedido_Atender();
        }
        public void RN_ActualizarEstadoProducto(string id_ped, string Estado,string idProd,double Cantidad)
        {
            d_pedido.BD_ActualizarEstadoProducto(id_ped,Estado,idProd,Cantidad);
        }
        public void RN_ActualizarPedidoMontoDescontar(string id_ped, string idProd, double montoDescuento)
        {
            d_pedido.BD_ActualizarPedidoMontoDescontar(id_ped,idProd,montoDescuento);
        }
    }
}
