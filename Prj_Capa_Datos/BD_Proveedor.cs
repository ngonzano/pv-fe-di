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
   public class BD_Proveedor //: BDConexion
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString);
        //REGISTRAR
        public int BD_Registrar_Proveedor(EN_Proveedor e_prov)
        {
            //SqlConnection cn = new SqlConnection();
            int rpt;
            try 
            {
                //cn.ConnectionString = Conectar();
                SqlCommand cmd = new SqlCommand("sp_registrar_Proveedor", cn);
                cmd.CommandTimeout = 15;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idproveedor", e_prov.Idproveedor);
                cmd.Parameters.AddWithValue("@nombre", e_prov.Nombre);
                cmd.Parameters.AddWithValue("@direccion", e_prov.Direccion);
                cmd.Parameters.AddWithValue("@telefono", e_prov.Telefono);
                cmd.Parameters.AddWithValue("@rubro", e_prov.Rubro);
                cmd.Parameters.AddWithValue("@ruc", e_prov.Ruc);
                cmd.Parameters.AddWithValue("@correo", e_prov.Correo);
                cmd.Parameters.AddWithValue("@contacto", e_prov.Contacto);
                if (e_prov.Fotologo != null)
                {
                    cmd.Parameters.AddWithValue("@fotologo", e_prov.Fotologo);
                    //MessageBox.Show("El Proveedor se registro correctamente", "PROVEEDOR", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@fotologo", Application.StartupPath + @"\focus.png");
                    MessageBox.Show("El Proveedor se registro Sin Logo", "sp_registrar_Proveedor", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                
                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
                rpt = 1;
                
            }
            catch(Exception ex) 
            {
                if (cn.State==ConnectionState.Open)
                {
                    cn.Close();
                    
                }
                rpt = 0;
                MessageBox.Show("Error al guardar: " + ex.Message, "Capa Datos Proveedor", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            return rpt;
        }

        //EDITAR
        public void BD_Editar_Proveedor(EN_Proveedor e_prov)
        {
            //SqlConnection cn = new SqlConnection();
            //int rpt;
            try
            {
                //cn.ConnectionString = Conectar();
                SqlCommand cmd = new SqlCommand("sp_Modificar_Proveedor", cn);
                cmd.CommandTimeout = 15;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idproveedor", e_prov.Idproveedor);
                cmd.Parameters.AddWithValue("@nombre", e_prov.Nombre);
                cmd.Parameters.AddWithValue("@direccion", e_prov.Direccion);
                cmd.Parameters.AddWithValue("@telefono", e_prov.Telefono);
                cmd.Parameters.AddWithValue("@rubro", e_prov.Rubro);
                cmd.Parameters.AddWithValue("@ruc", e_prov.Ruc);
                cmd.Parameters.AddWithValue("@correo", e_prov.Correo);
                cmd.Parameters.AddWithValue("@contacto", e_prov.Contacto);
                cmd.Parameters.AddWithValue("@fotologo", e_prov.Fotologo);
                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
                //rpt = 1;
            }
            catch (Exception ex)
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
               // rpt = 0;
                MessageBox.Show("Error al editar: " + ex.Message, "sp_Modificar_Proveedor", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
           // return rpt;
        }
        //MOSTRAR
        public DataTable BD_Mostrar_Todas_Proveedor()
        {
            //SqlConnection cn = new SqlConnection();

            try
            {
                //cn.ConnectionString = Conectar();
                SqlDataAdapter da = new SqlDataAdapter("sp_Listar_Todos_Proveedores", cn);
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
                MessageBox.Show("Error al Mostrar: " + ex.Message, "sp_Listar_Todos_Proveedores", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
           return null;
            }
            
        }
        //BUSCAR PROVEEDOR
        public DataTable BD_Buscar_Proveedor(string Valor)
        {
            //SqlConnection cn = new SqlConnection();

            try
            {
                //cn.ConnectionString = Conectar();
                SqlDataAdapter da = new SqlDataAdapter("sp_buscar_proveedor_porvalor", cn);

                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@valor", Valor);
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
                MessageBox.Show("Error al Mostrar: " + ex.Message, "sp_buscar_proveedor_porvalor", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return null;
            }

        }
        //ELIMINAR
        public void BD_Eliminar_Proveedor(EN_Proveedor e_prov)
        {
           // SqlConnection cn = new SqlConnection();

            try
            {
                //cn.ConnectionString = Conectar();
                SqlCommand cmd = new SqlCommand("sp_eliminar_PROVEEDOR", cn);
                cmd.CommandTimeout = 15;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IDPROVEE", e_prov.Idproveedor);
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
                MessageBox.Show("Error al Eliminar: " + ex.Message, "sp_eliminar_PROVEEDOR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

    }
}
