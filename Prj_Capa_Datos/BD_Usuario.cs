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
  public class BD_Usuario //: BDConexion
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString);
        public bool BD_Login(string usu,string pass)
        {
            //SqlConnection cn = new SqlConnection();
            bool rpt = false;
            Int32 getvalue = 0;
            try
            {
                SqlCommand cmd = new SqlCommand();
                //cn.ConnectionString = Conectar();

                cmd.CommandText = "Sp_Login";
                cmd.Connection = cn;
                cmd.CommandTimeout = 15;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Usuario", usu);
                cmd.Parameters.AddWithValue("@Contraseña", pass);
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
                MessageBox.Show("Error al ingresar Login: " + ex.Message, "Capa Datos Login", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            return rpt;
        }
        public DataTable BD_Buscar_usuario(string nomusu)
        {

            try
            {
                SqlDataAdapter da = new SqlDataAdapter("Sp_Usuario_Login2", cn);

                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@Usuario", nomusu);
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
                MessageBox.Show("Error al Mostrar usuario: " + ex.Message, "Capa Datos usuario", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return null;
            }

        }
        public bool BD_Validar_Usuario(string dni)
        {
            bool rpt = false;
            Int32 getvalue = 0;
            try
            {
                SqlCommand cmd = new SqlCommand();

                cmd.CommandText = "sp_Validar_NroDNI_Usuario2";
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
                MessageBox.Show("Error al validar DNI: " + ex.Message, "Capa Datos USUARIO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            return rpt;
        }
        #region Login
        public bool isValidPassword(string username, string password)
        {
            UserBE user = getUserFromDB(username);
            bool isValid = false;

            if (!string.IsNullOrEmpty(user.user))
            {
                byte[] hashedPassword = Cryptographic.HashPasswordWithSalt(Encoding.UTF8.GetBytes(password), user.salt);

                if (hashedPassword.SequenceEqual(user.pass))
                    isValid = true;
            }

            return isValid;

        }

        public UserBE getUserFromDB(string username)
        {
            UserBE user = new UserBE();

            var cn = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(cn))
            {
                string saltSaved = "Sp_MostrarUsuario2";

                

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = connection;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = saltSaved;
                    cmd.CommandTimeout = 15;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@username", SqlDbType.VarChar, 50).Value = username;

                    try
                    {
                        connection.Open();
                        using (SqlDataReader oReader = cmd.ExecuteReader())
                        {
                            if (oReader.Read())
                            {
                                user.user = oReader["Usuario"].ToString();
                                user.salt = (byte[])oReader["salt"];
                                user.pass = (byte[])oReader["Contraseña"];
                            }
                        }
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show("Se presento un error: "+ex.Message,"ERROR MOSTRAR USUARIO",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }

            return user;
        }

        public bool saveUser(string user, string password,EN_Usuario usuario)
        {
            bool isSaved = false;
            byte[] salt = Cryptographic.GenerateSalt();
            var hashedPassword = Cryptographic.HashPasswordWithSalt(Encoding.UTF8.GetBytes(password), salt);

            var cn = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(cn))
            {
                string saveUser = "Sp_RegistrarUsuario2";

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = connection;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = saveUser;
                    cmd.CommandTimeout = 15;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@Id_Usu", SqlDbType.VarChar, 10).Value = usuario.Id_Usu;
                    cmd.Parameters.Add("@Nombres", SqlDbType.VarChar, 50).Value = usuario.Nombres;
                    cmd.Parameters.Add("@Apellidos", SqlDbType.VarChar, 50).Value = usuario.Apellidos;
                    cmd.Parameters.Add("@Id_Dis", SqlDbType.Int, 100).Value = usuario.Id_Dis;
                    cmd.Parameters.Add("@username", SqlDbType.VarChar,20).Value = user;
                    cmd.Parameters.Add("@pass", SqlDbType.VarBinary).Value = hashedPassword;
                    cmd.Parameters.Add("@Ubicacion_Foto", SqlDbType.VarChar,180).Value = usuario.Ubicacion_Foto;
                    cmd.Parameters.Add("@Fecha_Ncmiento", SqlDbType.Date).Value = usuario.Fecha_Ncmiento;
                    cmd.Parameters.Add("@Id_Rol", SqlDbType.Int, 3).Value = usuario.Id_Rol;
                    cmd.Parameters.Add("@Correo", SqlDbType.VarChar,100).Value = usuario.Correo;
                    cmd.Parameters.Add("@Estado_Usu", SqlDbType.VarChar,12).Value = usuario.Estado_Usu;
                    cmd.Parameters.Add("@salt", SqlDbType.VarBinary).Value = salt;
                    try
                    {
                        connection.Open();
                        int recordsAffected = cmd.ExecuteNonQuery();
                        if (recordsAffected > 0)
                            isSaved = true;

                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show("Se presento un error: " + ex.Message, "ERROR INGRESAR USUARIO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }

            return isSaved;
        }

        #endregion
    }
}
