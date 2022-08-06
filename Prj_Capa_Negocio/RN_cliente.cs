using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SPV_Capa_Datos;
using SPV_Capa_Entidad;

namespace SPV_Capa_Negocio
{
   public class RN_cliente
    {
        BD_Cliente d_cli = new BD_Cliente();
        EN_Cliente e_cli = new EN_Cliente();
        public DataTable RN_Buscar_cliente(string dni)
        {
            return d_cli.BD_Buscar_cliente(dni);
        }
        public int RN_Registrar_Cliente(EN_Cliente e_cli)
        {
            return d_cli.BD_Registrar_Cliente(e_cli);
        }
        public int RN_Editar_Cliente(EN_Cliente e_cli)
        {
            return d_cli.BD_Editar_Cliente(e_cli);
        }
        public DataTable RN_Listar_Todos_clientes(string estado)
        {
            return d_cli.BD_Listar_Todos_clientes(estado);
        }
        public DataTable RN_Listar_clientes_Valor(string valor, string estado)
        {
            return d_cli.BD_Listar_clientes_Valor(valor,estado);
        }
        public int RN_Baja_cliente(string id_cliente)
        {
            return d_cli.BD_Baja_cliente(id_cliente);
        }
        public int RN_Eliminar_cliente(string id_cliente)
        {
            return d_cli.BD_Eliminar_cliente(id_cliente);
        }
        public bool RN_Validar_Cliente(string dni)
        {
            return d_cli.BD_Validar_Cliente(dni);
        }
        public DataTable RN_Buscar_cliente_exp(string idcliente)
        {
            return d_cli.BD_Buscar_cliente_exp(idcliente);
        }
    }
}
