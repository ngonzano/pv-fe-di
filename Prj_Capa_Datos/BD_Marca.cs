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
   public class BD_Marca //: BDConexion
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString);
        //REGISTRAR
        public void BD_Registrar_Marca(string nomMarca)
        {
            //SqlConnection cn = new SqlConnection();

            try
            {
                //cn.ConnectionString = Conectar();
                SqlCommand cmd = new SqlCommand("sp_addMarca", cn);
                cmd.CommandTimeout = 15;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@marca", nomMarca);
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
                MessageBox.Show("Error al guardar: " + ex.Message, "sp_addMarca", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        //EDITAR
        public void BD_Editar_Marca(int idMarca, string nomMarca)
        {
           // SqlConnection cn = new SqlConnection();

            try
            {
              //  cn.ConnectionString = Conectar();
                SqlCommand cmd = new SqlCommand("sp_Editar_Marca", cn);
                cmd.CommandTimeout = 15;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idmar", idMarca);
                cmd.Parameters.AddWithValue("@nom_marca", nomMarca);
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
                MessageBox.Show("Error al editar: " + ex.Message, "sp_Editar_Marca", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        
        //ELIMINAR
        public void BD_Eliminar_Marca(int idMarca)
        {
            //SqlConnection cn = new SqlConnection();

            try
            {
                //cn.ConnectionString = Conectar();
                SqlCommand cmd = new SqlCommand("sp_eliminar_Marca", cn);
                cmd.CommandTimeout = 15;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idmar", idMarca);
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
                MessageBox.Show("Error al Eliminar: " + ex.Message, "sp_eliminar_Marca", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        //MOSTRAR
        public DataTable BD_Mostrar_Todas_Marcas()
        {
          //  SqlConnection cn = new SqlConnection();

            try
            {
               // cn.ConnectionString = Conectar();
                SqlDataAdapter da = new SqlDataAdapter("sp_Listar_Todos_Marcas", cn);
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
                MessageBox.Show("Error al Mostrar: " + ex.Message, "sp_Listar_Todos_Marcas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return null;
            }

        }
    }
}
