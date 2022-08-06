using SPV_Capa_Entidad;
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
    public class BD_Cotizacion
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString);
        public int BD_Registrar_Cotizacion(EN_Cotizacion e_coti)
        {
            
            int rpt;
            try
            {
            
                SqlCommand cmd = new SqlCommand("Sp_Registrar_Cotizacion", cn);
                cmd.CommandTimeout = 15;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id_Cotiza", e_coti.Id_Cotiza);
                cmd.Parameters.AddWithValue("@Id_Ped", e_coti.Id_Ped);
                cmd.Parameters.AddWithValue("@Vigencia", e_coti.Vigencia);
                cmd.Parameters.AddWithValue("@TotalCotiza", e_coti.TotalCotiza);
                cmd.Parameters.AddWithValue("@Condiciones", e_coti.Condiciones);
                cmd.Parameters.AddWithValue("@PrecioconIgv",e_coti.PrecioconIgv);

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
                MessageBox.Show("Error al Registrar: " + ex.Message, "Sp_Registrar_Cotizacion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            return rpt;
        }
        public int BD_Editar_Cotizacion(EN_Cotizacion e_coti)
        {

            int rpt;
            try
            {

                SqlCommand cmd = new SqlCommand("Sp_Editar_Cotizacion", cn);
                cmd.CommandTimeout = 15;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id_Cotiza", e_coti.Id_Cotiza);
                cmd.Parameters.AddWithValue("@Id_Ped", e_coti.Id_Ped);
                cmd.Parameters.AddWithValue("@Vigencia", e_coti.Vigencia);
                cmd.Parameters.AddWithValue("@FechaCoti", e_coti.FechaCoti);
                cmd.Parameters.AddWithValue("@TotalCotiza", e_coti.TotalCotiza);
                cmd.Parameters.AddWithValue("@Condiciones", e_coti.Condiciones);
                cmd.Parameters.AddWithValue("@PrecioconIgv", e_coti.PrecioconIgv);

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
                MessageBox.Show("Error al Editar: " + ex.Message, "Sp_Editar_Cotizacion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            return rpt;
        }
        public int BD_Cambiar_Estado_Cotizacion(string id_coti,string xestado)
        {

            int rpt;
            try
            {

                SqlCommand cmd = new SqlCommand("Sp_Cambiar_Estado_Cotizacion", cn);
                cmd.CommandTimeout = 15;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id_coti", id_coti);
                cmd.Parameters.AddWithValue("@Estadocoti", xestado);

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
                MessageBox.Show("Error al Cambiar Estado Cotizacion: " + ex.Message, "Sp_Cambiar_Estado_Cotizacion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            return rpt;
        }
        //Consultas
        public DataTable BD_Buscar_Cotizacion_Para_Editar(string nro_Coti)
        {

            try
            {
                SqlDataAdapter da = new SqlDataAdapter("Sp_Buscar_Cotizaciones_yDetalle", cn);
                da.SelectCommand.CommandTimeout = 15;
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@Nro_coti", nro_Coti);

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
                MessageBox.Show("Error al Buscar Cotizacion: " + ex.Message, "Sp_Buscar_Cotizaciones_yDetalle", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return null;
            }

        }
        public DataTable BD_Buscar_Cotizacion_Dia_Mes(string tipo,DateTime fecha)
        {

            try
            {
                SqlDataAdapter da = new SqlDataAdapter("Sp_Listar_Cotizacion_porFecha", cn);
                da.SelectCommand.CommandTimeout = 15;
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@tipo", tipo);
                da.SelectCommand.Parameters.AddWithValue("@fecha", fecha);

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
                MessageBox.Show("Error al Buscar: " + ex.Message, "Sp_Listar_Cotizacion_porFecha", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return null;
            }

        }
        public DataTable BD_Buscar_CotizacionRangoFecha(DateTime fi,DateTime ff, string nombre)
        {

            try
            {
                SqlDataAdapter da = new SqlDataAdapter("Sp_Listar_Cotizacion_PorRangoFecha", cn);
                da.SelectCommand.CommandTimeout = 15;
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@fechaInicio", fi);
                da.SelectCommand.Parameters.AddWithValue("@fechaFin", ff);
                da.SelectCommand.Parameters.AddWithValue("@RazonSocial", nombre);

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
                MessageBox.Show("Error al Buscar: " + ex.Message, "Sp_Listar_Cotizacion_PorRangoFecha", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return null;
            }

        }

    }
}
