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
    public class BD_Caja
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString);
        public int BD_Ingresar_Caja(EN_Caja e_caja)
        {

            int rpt;
            try
            {

                SqlCommand cmd = new SqlCommand("sp_registrar_Caja", cn);
                cmd.CommandTimeout = 15;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Fecha_Caja", e_caja.Fecha_Caja);
                cmd.Parameters.AddWithValue("@Tipo_Caja", e_caja.Tipo_Caja);
                cmd.Parameters.AddWithValue("@Concepto", e_caja.Concepto);
                cmd.Parameters.AddWithValue("@De_Para", e_caja.De_Para);
                cmd.Parameters.AddWithValue("@Nro_Doc", e_caja.Nro_Doc);
                cmd.Parameters.AddWithValue("@ImporteCaja", e_caja.ImporteCaja);

                cmd.Parameters.AddWithValue("@Id_Usu", e_caja.Id_Usu);
                cmd.Parameters.AddWithValue("@TotalUti", e_caja.TotalUti);
                cmd.Parameters.AddWithValue("@TipoPago", e_caja.TipoPago);
                cmd.Parameters.AddWithValue("@GeneradoPor", e_caja.GeneradoPor);

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
                MessageBox.Show("Error al Registrar: " + ex.Message, "sp_registrar_Caja", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            return rpt;
        }
        public int BD_Editar_Total_Caja(EN_Caja e_caja)
        {

            int rpt;
            try
            {

                SqlCommand cmd = new SqlCommand("Sp_Actualizar_Total_Caja", cn);
                cmd.CommandTimeout = 15;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Nro_Doc", e_caja.Nro_Doc);
                cmd.Parameters.AddWithValue("@ImporteCaja", e_caja.ImporteCaja);
                cmd.Parameters.AddWithValue("@TotalUti", e_caja.TotalUti);
                cmd.Parameters.AddWithValue("@TipoPago", e_caja.TipoPago);

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
                MessageBox.Show("Error al Editar: " + ex.Message, "Sp_Actualizar_Total_Caja", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            return rpt;
        }
        public DataTable BD_Mostrar_Todo_Caja(string Concepto)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("Sp_Listar_Todas_Cajas", cn);
                da.SelectCommand.CommandTimeout = 15;
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@Concepto", Concepto);

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
                MessageBox.Show("Error al Mostrar: " + ex.Message, "Sp_Listar_Todas_Cajas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return null;
            }

        }
        public DataTable BD_Mostrar_Caja_Dia()
        {

            try
            {
                SqlDataAdapter da = new SqlDataAdapter("Sp_Listar_Cajas_delDia", cn);
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
                MessageBox.Show("Error al Mostrar Caja Dia: " + ex.Message, "Sp_Listar_Cajas_delDia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return null;
            }

        }
        public DataTable BD_Mostrar_Caja_Mes(DateTime fecha)
        {

            try
            {
                SqlDataAdapter da = new SqlDataAdapter("Sp_Listar_Cajas_del_Mes", cn);
                da.SelectCommand.CommandTimeout = 15;
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@fechas", fecha);

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
                MessageBox.Show("Error al Mostrar Caja Dia: " + ex.Message, "Sp_Listar_Cajas_del_Mes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return null;
            }

        }
        public DataTable BD_Mostrar_Movi_Caja(string valor)
        {

            try
            {
                SqlDataAdapter da = new SqlDataAdapter("Sp_Buscador_MoviCaja_xValor", cn);
                da.SelectCommand.CommandTimeout = 15;
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@xvalor", valor);

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
                MessageBox.Show("Error al Mostrar Caja Dia: " + ex.Message, "Sp_Buscador_MoviCaja_xValor", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return null;
            }

        }
        public DataTable BD_Buscar_Caja_RangoFechas(DateTime fi, DateTime ff, string nom)
        {

            try
            {
                SqlDataAdapter da = new SqlDataAdapter("Sp_Listar_Todas_Cajas_RangoFechas", cn);
                da.SelectCommand.CommandTimeout = 15;
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@fechaInicio", fi);
                da.SelectCommand.Parameters.AddWithValue("@fechaFin", ff);
                da.SelectCommand.Parameters.AddWithValue("@Concepto", nom);

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
                MessageBox.Show("Error al Buscar: " + ex.Message, "Sp_Listar_Todas_Cajas_RangoFechas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return null;
            }

        }
        public int BD_AnularMovCaja(string Nro_Doc,string EstadoCaja)
        {

            int rpt;
            try
            {

                SqlCommand cmd = new SqlCommand("sp_anular_moviCaja", cn);
                cmd.CommandTimeout = 15;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Nro_Doc", Nro_Doc);
                cmd.Parameters.AddWithValue("@EstadoCaja", EstadoCaja);

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
                MessageBox.Show("Error al Editar: " + ex.Message, "sp_anular_moviCaja", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            return rpt;
        }
        public bool BD_Estado_Documento_enCaja(string idDoc)
        {
            //SqlConnection cn = new SqlConnection();
            bool rpt = false;
            int getvalue;
            try
            {
                SqlCommand cmd = new SqlCommand();
                //cn.ConnectionString = Conectar();

                cmd.CommandText = "Sp_Estado_Documento";
                cmd.Connection = cn;
                cmd.CommandTimeout = 15;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@nro_doc", idDoc);
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
                MessageBox.Show("Error: " + ex.Message, "Sp_Estado_Documento", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            return rpt;
        }
    }
}
