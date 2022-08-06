using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SPV_Capa_Entidad;

namespace SPV_Capa_Datos
{
    public class BD_Pedido
    {

        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString);
        public int BD_Registrar_Pedido_Header(EN_Pedido e_ped)
        {
            int rpt;
            try
            {
                SqlCommand cmd = new SqlCommand("Sp_Registrar_Pedido", cn);
                cmd.CommandTimeout = 15;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_Ped", e_ped.Id_Ped);
                cmd.Parameters.AddWithValue("@Id_Cliente", e_ped.Id_Cliente);
                cmd.Parameters.AddWithValue("@SubTotal", e_ped.SubTotal);
                cmd.Parameters.AddWithValue("@IgvPed", e_ped.IgvPed);
                cmd.Parameters.AddWithValue("@TotalPed", e_ped.TotalPed);
                cmd.Parameters.AddWithValue("@id_Usu", e_ped.Id_Usu);
                cmd.Parameters.AddWithValue("@TotalGancia", e_ped.TotalGancia);
                cmd.Parameters.AddWithValue("@Estado_ped", e_ped.Estado_Ped);

                cmd.Parameters.AddWithValue("@subtotal_Gravado", e_ped.Subtotal_Gravado);
                cmd.Parameters.AddWithValue("@IgvGravado", e_ped.IgvGravado);
                cmd.Parameters.AddWithValue("@totalGravado", e_ped.TotalGravado);

                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
                rpt = 1;

            }
            catch (Exception ex)
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                MessageBox.Show("Error al Registrar Header: " + ex.Message, "Sp_Registrar_Pedido", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                rpt = 0;
            }
            return rpt;
        }
        public int BD_Registrar_Pedido_Det(EN_Det_Pedido e_det_ped)
        {
            int rpt;
            try
            {
                SqlCommand cmd = new SqlCommand("sp_Registrar_detalle_Pedido", cn);
                cmd.CommandTimeout = 15;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_Ped", e_det_ped.Id_Ped);
                cmd.Parameters.AddWithValue("@Id_Pro", e_det_ped.Id_Pro);
                cmd.Parameters.AddWithValue("@Precio", e_det_ped.Precio);
                cmd.Parameters.AddWithValue("@Cantidad", e_det_ped.Cantidad);
                cmd.Parameters.AddWithValue("@Importe", e_det_ped.Importe);
                cmd.Parameters.AddWithValue("@Tipo_Prod", e_det_ped.Tipo_Prod);
                cmd.Parameters.AddWithValue("@Und_Medida", e_det_ped.Und_Medida);
                cmd.Parameters.AddWithValue("@Utilidad_Unit", e_det_ped.Utilidad_Unit);
                cmd.Parameters.AddWithValue("@TotalUtilidad", e_det_ped.TotalUtilidad);

                cmd.Parameters.AddWithValue("@AfectoIGV", e_det_ped.AfectoIGV);
                cmd.Parameters.AddWithValue("@Precio_sinIgv", e_det_ped.Precio_sinIgv);
                cmd.Parameters.AddWithValue("@subtotal_sinIgv", e_det_ped.Subtotal_sinIgv);
                cmd.Parameters.AddWithValue("@Igv_subtotal", e_det_ped.Igv_subtotal);

                cmd.Parameters.AddWithValue("@P_Cant_Original", e_det_ped.P_Cant_Original);

                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
                rpt = 1;

            }
            catch (Exception ex)
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                MessageBox.Show("Error al Registrar Det: " + ex.Message, "sp_Registrar_detalle_Pedido", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                rpt = 0;
            }
            return rpt;
        }
        public int BD_Eliminar_Pedido_Det(string id_ped)
        {
            int rpt;
            try
            {
                SqlCommand cmd = new SqlCommand("sp_eliminar_detalle_Pedido", cn);
                cmd.CommandTimeout = 15;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_Ped", id_ped);


                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
                rpt = 1;

            }
            catch (Exception ex)
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                MessageBox.Show("Error al Eliminar Det: " + ex.Message, "sp_eliminar_detalle_Pedido", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                rpt = 0;
            }
            return rpt;
        }
        public int BD_Editar_Pedido_Header(EN_Pedido e_ped)
        {
            int rpt;
            try
            {
                SqlCommand cmd = new SqlCommand("Sp_Editar_Pedido", cn);
                cmd.CommandTimeout = 15;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_Ped", e_ped.Id_Ped);
                cmd.Parameters.AddWithValue("@Id_Cliente", e_ped.Id_Cliente);
                cmd.Parameters.AddWithValue("@fechaPed", e_ped.Fecha_Ped);
                cmd.Parameters.AddWithValue("@SubTotal", e_ped.SubTotal);
                cmd.Parameters.AddWithValue("@IgvPed", e_ped.IgvPed);
                cmd.Parameters.AddWithValue("@TotalPed", e_ped.TotalPed);
                cmd.Parameters.AddWithValue("@id_Usu", e_ped.Id_Usu);
                cmd.Parameters.AddWithValue("@TotalGancia", e_ped.TotalGancia);
                cmd.Parameters.AddWithValue("@Estado_ped", e_ped.Estado_Ped);

                cmd.Parameters.AddWithValue("@subtotal_Gravado", e_ped.Subtotal_Gravado);
                cmd.Parameters.AddWithValue("@IgvGravado", e_ped.IgvGravado);
                cmd.Parameters.AddWithValue("@totalGravado", e_ped.TotalGravado);

                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
                rpt = 1;

            }
            catch (Exception ex)
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                MessageBox.Show("Error al Editar Header: " + ex.Message, "Sp_Editar_Pedido", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                rpt = 0;
            }
            return rpt;
        }
        public bool BD_Validar_NroPedido(string NroPedido)
        {
            bool rpt = false;
            Int32 getvalue = 0;
            try
            {
                SqlCommand cmd = new SqlCommand();

                cmd.CommandText = "Sp_Verificar_Id_Pedido";
                cmd.Connection = cn;
                cmd.CommandTimeout = 15;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id_Ped", NroPedido);
                cn.Open();
                getvalue = Convert.ToInt32(cmd.ExecuteScalar());
                if (getvalue > 0)
                {
                    rpt = true;
                }
                else
                {
                    rpt = false;
                }
                cmd.Parameters.Clear();
                cmd.Dispose();
                cmd = null;
                cn.Close();
            }
            catch (Exception ex)
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                MessageBox.Show("Error al validar Pedido: " + ex.Message, "Sp_Verificar_Id_Pedido", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            return rpt;
        }
        public int BD_Poner_Pedido_Atendido(string id_ped)
        {
            int rpt;
            try
            {
                SqlCommand cmd = new SqlCommand("Sp_Pedido_Atendido", cn);
                cmd.CommandTimeout = 15;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id_Ped", id_ped);


                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
                rpt = 1;

            }
            catch (Exception ex)
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                MessageBox.Show("Error al poner pedido como atendido " + ex.Message, "Sp_Pedido_Atendido", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                rpt = 0;
            }
            return rpt;
        }
        public int BD_Cambiar_cliente_pedido(string id_ped, string id_cliente)
        {
            int rpt;
            try
            {
                SqlCommand cmd = new SqlCommand("Sp_Actu_clien_Ped", cn);
                cmd.CommandTimeout = 15;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id_Ped", id_ped);
                cmd.Parameters.AddWithValue("@Id_cli", id_cliente);

                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
                rpt = 1;

            }
            catch (Exception ex)
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                MessageBox.Show("Error al Eliminar Det: " + ex.Message, "Sp_Actu_clien_Ped", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                rpt = 0;
            }
            return rpt;
        }
        public int BD_Eliminar_Pedido_Permanente(string id_ped)
        {
            int rpt;
            try
            {
                SqlCommand cmd = new SqlCommand("Sp_Eliminar_Pedido_Completo", cn);
                cmd.CommandTimeout = 15;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id_Ped", id_ped);

                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
                rpt = 1;

            }
            catch (Exception ex)
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                MessageBox.Show("Error al Eliminar pedido permanente " + ex.Message, "Sp_Eliminar_Pedido_Completo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                rpt = 0;
            }
            return rpt;
        }
        //Consultas
        public DataTable BD_Buscar_Pedido_Editar(string IdPedido)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("Sp_Buscar_Pedido_Para_Editar", cn);
                da.SelectCommand.CommandTimeout = 15;
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@Id_Ped", IdPedido);

                DataTable dt = new DataTable();
                da.Fill(dt);
                da = null;
                return dt;
            }
            catch (Exception ex)
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                MessageBox.Show("Error al Mostrar: " + ex.Message, "Sp_Buscar_Pedido_Para_Editar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return null;
            }

        }
        public DataTable BD_Buscar_Pedido_valor(string valor)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("Sp_buscar_Pedidos_porValor", cn);
                da.SelectCommand.CommandTimeout = 15;
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@valor", valor);

                DataTable dt = new DataTable();
                da.Fill(dt);
                da = null;
                return dt;
            }
            catch (Exception ex)
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                MessageBox.Show("Error al Mostrar: " + ex.Message, "Sp_buscar_Pedidos_porValor", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return null;
            }

        }
        public DataTable BD_Mostrar_pedido_fecha(string tipo, string xfecha)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("Sp_Listar_Pedidos_porFecha", cn);
                da.SelectCommand.CommandTimeout = 15;
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@tipo", tipo);
                da.SelectCommand.Parameters.AddWithValue("@fecha", xfecha);

                DataTable dt = new DataTable();
                da.Fill(dt);
                da = null;
                return dt;
            }
            catch (Exception ex)
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                MessageBox.Show("Error al Mostrar: " + ex.Message, "Sp_Listar_Pedidos_porFecha", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return null;
            }

        }
        public DataTable BD_Mostrar_pedido_Atender()
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("Sp_Leer_Pedidos_PorAtender", cn);
                da.SelectCommand.CommandTimeout = 15;
                da.SelectCommand.CommandType = CommandType.StoredProcedure;

                DataTable dt = new DataTable();
                da.Fill(dt);
                da = null;
                return dt;
            }
            catch (Exception ex)
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                MessageBox.Show("Error al Mostrar: " + ex.Message, "Sp_Leer_Pedidos_PorAtender", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return null;
            }

        }
        public void BD_ActualizarEstadoProducto(string id_ped, string Estado, string idProd, double Cantidad)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SP_Actualizar_EstadoProducto", cn);
                cmd.CommandTimeout = 15;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_ped", id_ped);
                cmd.Parameters.AddWithValue("@Estado", Estado);
                cmd.Parameters.AddWithValue("@Id_Pro", idProd);
                cmd.Parameters.AddWithValue("@cantidad", Cantidad);

                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();

            }
            catch (Exception ex)
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                MessageBox.Show("Error: " + ex.Message, "SP_Actualizar_EstadoProducto", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        public void BD_ActualizarPedidoMontoDescontar(string id_ped, string idProd, double montoDescuento)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SP_Actualizar_Cant_Origen_Pedi", cn);
                cmd.CommandTimeout = 15;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_Ped", id_ped);
                cmd.Parameters.AddWithValue("@Id_Pro", idProd);
                cmd.Parameters.AddWithValue("@P_Cant_Original", montoDescuento);

                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();

            }
            catch (Exception ex)
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                MessageBox.Show("Error: " + ex.Message, "SP_Actualizar_Cant_Origen_Pedi", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }


    }
}
