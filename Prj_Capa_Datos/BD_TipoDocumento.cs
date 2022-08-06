using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SPV_Capa_Datos
{
    public class BD_TipoDocumento : BDConexion
    {
        SqlConnection cn2 = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString);
        public static string Sp_Listado_Tipo(int idtipo)
        {
            SqlConnection cn = new SqlConnection();

            try
            {
                cn.ConnectionString = Conectar2();
                SqlCommand cmd = new SqlCommand("Sp_Listado_Tipo", cn);
                cmd.CommandTimeout = 15;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id_Tipo", idtipo);
                
                string NroDoc;

                cn.Open();
                NroDoc =Convert.ToString(cmd.ExecuteScalar());
                cn.Close();

                return NroDoc;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Sp_Listado_Tipo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                cn.Dispose();
                cn = null;
                return null;
                
            }
        }
        public DataTable BD_Mostrar_TipoDocumento()
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("Sp_Tipod_Doc_Spcial", cn2);
                da.SelectCommand.CommandTimeout = 15;
                da.SelectCommand.CommandType = CommandType.StoredProcedure;

                DataTable dt = new DataTable();
                da.Fill(dt);
                da = null;
                return dt;
            }
            catch (Exception ex)
            {
                if (cn2.State == ConnectionState.Open)
                {
                    cn2.Close();
                }
                MessageBox.Show("Error al Mostrar tipo documento: " + ex.Message, "Sp_Tipod_Doc_Spcial", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return null;
            }
        }
        public static void BD_Actualizar_SiguienteNro_correlativo(int idtipo)
        {
            SqlConnection cn = new SqlConnection();
            

            try
            {
                cn.ConnectionString = Conectar2();
                SqlCommand cmd = new SqlCommand("Sp_Actualiza_Tipo_Doc", cn);
                cmd.CommandTimeout = 15;
                cmd.Parameters.AddWithValue("@Id_Tipo", idtipo);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                MessageBox.Show("Error Actualizar Nro Correlativo: " + ex.Message, "Sp_Actualiza_Tipo_Doc", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }
        public static void BD_Actualizar_TipoCambio(int idtipo,double TipoCambio)
        {
            SqlConnection cn = new SqlConnection();


            try
            {
                cn.ConnectionString = Conectar2();
                SqlCommand cmd = new SqlCommand("Sp_Editar_TipoCambio", cn);
                cmd.CommandTimeout = 15;
                cmd.Parameters.AddWithValue("@idtipo", idtipo);
                cmd.Parameters.AddWithValue("@numero", TipoCambio);

                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                MessageBox.Show("Error Actualizar Tipo Cambio: " + ex.Message, "Sp_Editar_TipoCambio", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }
        public static double Sp_Listado_TipoCambio(int idtipo)
        {
            SqlConnection cn = new SqlConnection();

            try
            {
                cn.ConnectionString = Conectar2();
                SqlCommand cmd = new SqlCommand("Sp_Listado_TipoCambio", cn);
                cmd.CommandTimeout = 15;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id_Tipo", idtipo);

                double TipoCambio;

                cn.Open();
                TipoCambio = Convert.ToDouble(cmd.ExecuteScalar());
                cn.Close();

                return TipoCambio;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Sp_Listado_TipoCambio", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                cn.Dispose();
                cn = null;
                return 0;

            }
        }
        public static void BD_Actualizar_SiguienteNro_correlativoProducto(int idtipo)
        {
            SqlConnection cn = new SqlConnection();

            try
            {
                cn.ConnectionString = Conectar2();
                SqlCommand cmd = new SqlCommand("Sp_Actualiza_Tipo_Prodcto", cn);
                cmd.CommandTimeout = 15;
                cmd.Parameters.AddWithValue("@Id_Tipo", idtipo);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                MessageBox.Show("Error Actualizar Nro Correlativo: " + ex.Message, "Sp_Actualiza_Tipo_Prodcto", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }
        public void BD_Editar_Nro_correlativo(int idtipo,string documento,string serie, string numero)
        {
            SqlConnection cn = new SqlConnection();


            try
            {
                cn.ConnectionString = Conectar2();
                SqlCommand cmd = new SqlCommand("Sp_Editar_Tipo_Doc", cn);
                cmd.CommandTimeout = 15;
                cmd.Parameters.AddWithValue("@idtipo", idtipo);
                cmd.Parameters.AddWithValue("@documento", documento);
                cmd.Parameters.AddWithValue("@serie", serie);
                cmd.Parameters.AddWithValue("@numero", numero);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                MessageBox.Show("Error Actualizar Nro Correlativo: " + ex.Message, "Sp_Editar_Tipo_Doc", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }
        public DataTable BD_Listar_TipoDocumento()
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("SP_Listar_Tipo_Doc", cn2);
                da.SelectCommand.CommandTimeout = 15;
                da.SelectCommand.CommandType = CommandType.StoredProcedure;

                DataTable dt = new DataTable();
                da.Fill(dt);
                da = null;
                return dt;
            }
            catch (Exception ex)
            {
                if (cn2.State == ConnectionState.Open)
                {
                    cn2.Close();
                }
                MessageBox.Show("Error al Listar tipo documento: " + ex.Message, "SP_Listar_Tipo_Doc", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return null;
            }
        }
        public int BD_Actualizar_TipoCambio(int idtipo,string numero)
        {
            // SqlConnection cn = new SqlConnection();
            int rpt;
            try
            {
                // cn.ConnectionString = Conectar();
                SqlCommand cmd = new SqlCommand("Sp_Editar_TipoCambio", cn2);
                cmd.CommandTimeout = 15;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idtipo", idtipo);
                cmd.Parameters.AddWithValue("@numero", numero);

                cn2.Open();
                cmd.ExecuteNonQuery();
                cn2.Close();
                rpt = 1;

            }
            catch (Exception ex)
            {
                if (cn2.State == ConnectionState.Open)
                {
                    cn2.Close();
                }
                MessageBox.Show("Error al Registrar: " + ex.Message, "Sp_Editar_TipoCambio", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                rpt = 0;
            }
            return rpt;
        }
        public DataTable BD_Buscar_TipoDocumento(string nom_Tipo)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("Sp_Buscar_TipoDocumento", cn2);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@nom_Tipo", nom_Tipo);
                DataTable dt = new DataTable();
                da.Fill(dt);
                da = null;
                return dt;
            }
            catch (Exception ex)
            {
                if (cn2.State == ConnectionState.Open)
                {
                    cn2.Close();
                }
                MessageBox.Show("Error al Buscar: " + ex.Message, "Sp_Buscar_TipoDocumento", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return null;
            }
        }
    }
}
