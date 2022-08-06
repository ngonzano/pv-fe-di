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
   public class BD_Distrito 
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString);
        public DataTable BD_Mostrar_Todas_Distrito()
        {
            try
            {
                // cn.ConnectionString = Conectar();
                SqlDataAdapter da = new SqlDataAdapter("sp_Listar_Todos_Distritos", cn);
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
                MessageBox.Show("Error al Mostrar: " + ex.Message, "sp_Listar_Todos_Distritos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return null;
            }

        }
        public void BD_Registrar_Distrito(string nomDistrito)
        {
            //SqlConnection cn = new SqlConnection();

            try
            {
                // cn.ConnectionString = Conectar();
                SqlCommand cmd = new SqlCommand("sp_addDistrito", cn);
                cmd.CommandTimeout = 15;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@distrito", nomDistrito);
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
                MessageBox.Show("Error al guardar: " + ex.Message, "sp_addDistrito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        //REGISTRAR
        public void bd_registrar(int id)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandTimeout = 15;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("tabla",id);

                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
            }
            catch (Exception ex )
            {
                MessageBox.Show(ex.Message);
            }
        }
        //EDITAR
        public void BD_Editar_Distrito(int idDistrito, string nomDistrito)
        {
           // SqlConnection cn = new SqlConnection();

            try
            {
               // cn.ConnectionString = Conectar();
                SqlCommand cmd = new SqlCommand("sp_Editar_Distrito", cn);
                cmd.CommandTimeout = 15;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idDis", idDistrito);
                cmd.Parameters.AddWithValue("@nomdis", nomDistrito);
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
                MessageBox.Show("Error al editar: " + ex.Message, "sp_Editar_Distrito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        //ELIMINAR
        public void BD_Eliminar_Distrito(int idDistrito)
        {
            //SqlConnection cn = new SqlConnection();

            try
            {
               // cn.ConnectionString = Conectar();
                SqlCommand cmd = new SqlCommand("sp_eliminar_distrito", cn);
                cmd.CommandTimeout = 15;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idDis", idDistrito);
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
                MessageBox.Show("Error al Eliminar: " + ex.Message, "sp_eliminar_distrito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        //MOSTRAR
        
    }
}
