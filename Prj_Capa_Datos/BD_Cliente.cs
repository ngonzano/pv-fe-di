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
    public class BD_Cliente
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString);
        public DataTable BD_Buscar_cliente(string dni)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_Buscar_Cliente", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@DNI", dni);
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
                MessageBox.Show("Error al Mostrar: " + ex.Message, "sp_Buscar_Cliente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return null;
            }
        }
        public DataTable BD_Buscar_cliente_exp(string idcliente)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("SP_Buscar_Cliente_exp", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@Id_Cliente", idcliente);
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
                MessageBox.Show("Error al Mostrar: " + ex.Message, "SP_Buscar_Cliente_exp", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return null;
            }
        }
        public int BD_Registrar_Cliente(EN_Cliente e_cli)
        {
            // SqlConnection cn = new SqlConnection();
            int rpt;
            try
            {
                // cn.ConnectionString = Conectar();
                SqlCommand cmd = new SqlCommand("Sp_Registrar_Cliente", cn);
                cmd.CommandTimeout = 15;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idcliente", e_cli.Idcliente);
                cmd.Parameters.AddWithValue("@razonsocial", e_cli.Razonsocial);
                cmd.Parameters.AddWithValue("@dni", e_cli.Dni);
                cmd.Parameters.AddWithValue("@direccion", e_cli.Direccion);
                cmd.Parameters.AddWithValue("@telefono", e_cli.Telefono);
                cmd.Parameters.AddWithValue("@email", e_cli.Email);
                cmd.Parameters.AddWithValue("@idDis", e_cli.IdDis);
                cmd.Parameters.AddWithValue("@fechaAniver", e_cli.FechaAniver);
                cmd.Parameters.AddWithValue("@contacto", e_cli.Contacto);
                cmd.Parameters.AddWithValue("@limiteCred", e_cli.LimiteCred);
                

                if (e_cli.Foto != null)
                {
                    cmd.Parameters.AddWithValue("@foto", e_cli.Foto);
                    MessageBox.Show("El Cliente se registro correctamente", "CLIENTE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Foto", Application.StartupPath + @"\focus.png");
                    MessageBox.Show("El Cliente se registro Sin Foto", "CLIENTE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

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
                MessageBox.Show("Error al Registrar: " + ex.Message, "Sp_Registrar_Cliente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                rpt = 0;
            }
            return rpt;
        }
        public int BD_Editar_Cliente(EN_Cliente e_cli)
        {
            // SqlConnection cn = new SqlConnection();
            int rpt;
            try
            {
                // cn.ConnectionString = Conectar();
                SqlCommand cmd = new SqlCommand("Sp_Modificar_Cliente", cn);
                cmd.CommandTimeout = 15;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idcliente", e_cli.Idcliente);
                cmd.Parameters.AddWithValue("@razonsocial", e_cli.Razonsocial);
                cmd.Parameters.AddWithValue("@dni", e_cli.Dni);
                cmd.Parameters.AddWithValue("@direccion", e_cli.Direccion);
                cmd.Parameters.AddWithValue("@telefono", e_cli.Telefono);
                cmd.Parameters.AddWithValue("@email", e_cli.Email);
                cmd.Parameters.AddWithValue("@idDis", e_cli.IdDis);
                cmd.Parameters.AddWithValue("@fechaAniver", e_cli.FechaAniver);
                cmd.Parameters.AddWithValue("@contacto", e_cli.Contacto);
                cmd.Parameters.AddWithValue("@limiteCred", e_cli.LimiteCred);

                if (e_cli.Foto != null)
                {
                    cmd.Parameters.AddWithValue("@foto", e_cli.Foto);
                    MessageBox.Show("El Cliente se edito correctamente", "CLIENTE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
               

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
                MessageBox.Show("Error al Editar: " + ex.Message, "Sp_Modificar_Cliente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            return rpt;
        }
        public DataTable BD_Listar_Todos_clientes(string estado)
        {
            //SqlConnection cn = new SqlConnection();

            try
            {
                // cn.ConnectionString = Conectar();
                SqlDataAdapter da = new SqlDataAdapter("sp_Listar_Todos_Clientes", cn);
                da.SelectCommand.CommandTimeout = 15;
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@estado", estado);

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
                MessageBox.Show("Error al Mostrar: " + ex.Message, "sp_Listar_Todos_Clientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return null;
            }

        }
        public DataTable BD_Listar_clientes_Valor(string valor,string estado)
        {
            //SqlConnection cn = new SqlConnection();

            try
            {
                // cn.ConnectionString = Conectar();
                SqlDataAdapter da = new SqlDataAdapter("Sp_Buscar_Cliente_porValor", cn);
                da.SelectCommand.CommandTimeout = 15;
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@Valor", valor);
                da.SelectCommand.Parameters.AddWithValue("@estado", estado);

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
                MessageBox.Show("Error al Buscar: " + ex.Message, "Sp_Buscar_Cliente_porValor", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return null;
            }

        }
        public int BD_Baja_cliente(string id_cliente)
        {
            // SqlConnection cn = new SqlConnection();
            int rpt;
            try
            {
                // cn.ConnectionString = Conectar();
                SqlCommand cmd = new SqlCommand("Sp_DarBajar_Cliente", cn);
                cmd.CommandTimeout = 15;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idcliente", id_cliente);
                
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
                MessageBox.Show("Error al dar de Baja: " + ex.Message, "Sp_DarBajar_Cliente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            return rpt;
        }
        public int BD_Eliminar_cliente(string id_cliente)
        {
            // SqlConnection cn = new SqlConnection();
            int rpt;
            try
            {
                // cn.ConnectionString = Conectar();
                SqlCommand cmd = new SqlCommand("Sp_Eliminar_Cliente", cn);
                cmd.CommandTimeout = 15;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idcliente", id_cliente);


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
                MessageBox.Show("Error al Eliminar: " + ex.Message, "Sp_Eliminar_Cliente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            return rpt;
        }
        public bool BD_Validar_Cliente(string dni)
        {
            bool rpt = false;
            Int32 getvalue = 0;
            try
            {
                SqlCommand cmd = new SqlCommand();

                cmd.CommandText = "sp_Validar_NroDNI_Cliente";
                cmd.Connection = cn;
                cmd.CommandTimeout = 15;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@DNI", dni);
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
                MessageBox.Show("Error al validar Cliente: " + ex.Message, "sp_Validar_NroDNI_Cliente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            return rpt;
        }

    }
}
