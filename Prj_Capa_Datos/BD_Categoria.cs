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
   public class BD_Categoria //: BDConexion
    {
        //REGISTRAR
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString);
        public void BD_Registrar_Categoria(string nomCateg)
        {
            //SqlConnection cn = new SqlConnection();

            try 
            {
                //cn.ConnectionString = Conectar();
                SqlCommand cmd = new SqlCommand("sp_registrar_categoria", cn);
                cmd.CommandTimeout = 15;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@nombre", nomCateg);
                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
                
            }
            catch(Exception ex) 
            {
                if (cn.State==ConnectionState.Open)
                {
                    cn.Close();
                }
                MessageBox.Show("Error al guardar: "+ex.Message, "sp_registrar_categoria", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        //EDITAR
        public void BD_Editar_Categoria(int idCateg, string nomCateg)
        {
           // SqlConnection cn = new SqlConnection();

            try
            {
                //cn.ConnectionString = Conectar();
                SqlCommand cmd = new SqlCommand("sp_modificar_categoria", cn);
                cmd.CommandTimeout = 15;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idcat", idCateg);
                cmd.Parameters.AddWithValue("@nombre", nomCateg);
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
                MessageBox.Show("Error al editar: " + ex.Message, "sp_modificar_categoria", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        //MOSTRAR
        public DataTable BD_Mostrar_Todas_Categorias()
        {
            //SqlConnection cn = new SqlConnection();

            try
            {
                //cn.ConnectionString = Conectar();
                SqlDataAdapter da = new SqlDataAdapter("sp_listar_todas_Categorias", cn);
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
                MessageBox.Show("Error al Mostrar: " + ex.Message, "sp_listar_todas_Categorias", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
           return null;
            }
            
        }
        //ELIMINAR
        public void BD_Eliminar_Categoria(int idMarca)
        {
            //SqlConnection cn = new SqlConnection();

            try
            {
                //cn.ConnectionString = Conectar();
                SqlCommand cmd = new SqlCommand("sp_eliminar_Categoria", cn);
                cmd.CommandTimeout = 15;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idCateg", idMarca);
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
                MessageBox.Show("Error al Eliminar: " + ex.Message, "sp_eliminar_Categoria", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

    }
}
