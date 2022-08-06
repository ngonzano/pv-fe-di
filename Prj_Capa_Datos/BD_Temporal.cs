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
    public class BD_Temporal
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString);
        public int BD_Ingresar_Temporal_Header(EN_Temporal e_tem)
        {

            int rpt;
            try
            {

                SqlCommand cmd = new SqlCommand("Sp_Insertar_Temporal", cn);
                cmd.CommandTimeout = 15;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@codTem", e_tem.CodTem);
                cmd.Parameters.AddWithValue("@FechaEmi", e_tem.FechaEmi);
                cmd.Parameters.AddWithValue("@cliente", e_tem.Cliente);
                cmd.Parameters.AddWithValue("@Ruc", e_tem.Ruc);
                cmd.Parameters.AddWithValue("@Direccion", e_tem.Direccion);
                cmd.Parameters.AddWithValue("@SubTtal", e_tem.SubTtal);
                cmd.Parameters.AddWithValue("@IgvT", e_tem.IgvT);

                cmd.Parameters.AddWithValue("@TotalT", e_tem.TotalT);
                cmd.Parameters.AddWithValue("@SonT", e_tem.SonT);
                cmd.Parameters.AddWithValue("@vendedor", e_tem.Vendedor);
                cmd.Parameters.AddWithValue("@CodigoRQ", e_tem.CodigoQR);

                cmd.Parameters.AddWithValue("@tipoComprobante", e_tem.TipoComprobante);
                cmd.Parameters.AddWithValue("@hash_cpe", e_tem.Hash_cpe);
                cmd.Parameters.AddWithValue("@tipoPago", e_tem.TipoPago);
                cmd.Parameters.AddWithValue("@motivoEmis", e_tem.MotivoEmis);

                cmd.Parameters.AddWithValue("@forma_pago", e_tem.Forma_pago);
                cmd.Parameters.AddWithValue("@monto_deuda", e_tem.Monto_deuda);
                cmd.Parameters.AddWithValue("@fecha_venc_credito", e_tem.Fecha_venc_credito);

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
                rpt = 0;
                MessageBox.Show("Error al Registrar: " + ex.Message, "Sp_Insertar_Temporal", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            return rpt;
        }
        public int BD_Ingresar_Temporal_Det(string codTem, string CodProd, string Cantidad, string Producto, string PreUnt, string Importe, string UnidMedida)
        {
            int rpt;
            try
            {
                SqlCommand cmd = new SqlCommand("Sp_registrar_Det_Temporal", cn);
                cmd.CommandTimeout = 15;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@codTem", codTem);
                cmd.Parameters.AddWithValue("@CodProd", CodProd);
                cmd.Parameters.AddWithValue("@Cantidad", Cantidad);
                cmd.Parameters.AddWithValue("@Producto", Producto);
                cmd.Parameters.AddWithValue("@PreUnt", PreUnt);
                cmd.Parameters.AddWithValue("@Importe", Importe); 
                cmd.Parameters.AddWithValue("@UnidMedida", UnidMedida);

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
                rpt = 0;
                MessageBox.Show("Error al Registrar: " + ex.Message, "Sp_registrar_Det_Temporal", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            return rpt;
        }
        public DataTable BD_Mostrar_Temporales(string id)
        {

            try
            {
                SqlDataAdapter da = new SqlDataAdapter("Sp_Listar_Temporales", cn);
                da.SelectCommand.CommandTimeout = 15;
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@id", id);

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
                MessageBox.Show("Error al Mostrar: " + ex.Message, "Sp_Listar_Temporales", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return null;
            }

        }
        public int BD_Validar_Credito(string Id_tem)
        {
            int rpt;

            try
            {
                SqlCommand cmd = new SqlCommand();

                cmd.CommandText = "Sp_Validar_Archivos_Temporales";
                cmd.Connection = cn;
                cmd.CommandTimeout = 15;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id_tem", Id_tem);
                cn.Open();

                rpt = Convert.ToInt32(cmd.ExecuteScalar());

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
                MessageBox.Show("Error al validar: " + ex.Message, "Sp_Validar_Archivos_Temporales", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return rpt = 0;
            }
            return rpt;
        }
        public int BD_Eliminar_Temporal(string idTem)
        {

            int rpt;
            try
            {

                SqlCommand cmd = new SqlCommand("Sp_Delete_Det_Temporal", cn);
                cmd.CommandTimeout = 15;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", idTem);
                

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
                rpt = 0;
                MessageBox.Show("Error al Eliminar: " + ex.Message, "Sp_Delete_Det_Temporal", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            return rpt;
        }
        public int BD_ActualizarEstadoSunat_NC_Temporal(string idTem,string hash_cpe)
        {

            int rpt;
            try
            {

                SqlCommand cmd = new SqlCommand("SP_Actualizar_EstadoTemporal", cn);
                cmd.CommandTimeout = 15;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@codTem", idTem);
                cmd.Parameters.AddWithValue("@hash_cpe", hash_cpe);

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
                rpt = 0;
                MessageBox.Show("Error al Eliminar: " + ex.Message, "SP_Actualizar_EstadoTemporal", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            return rpt;
        }
    }
}
