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
    public class BD_MiEmpresa
    {

        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString);
        public int BD_Editar_Empresa(EN_MiEmpresa emp)
        {
            int rpt;
            try
            {
                SqlCommand cmd = new SqlCommand("SP_editar_miempresa", cn);
                cmd.CommandTimeout = 15;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idrancho", emp.Idrancho);
                cmd.Parameters.AddWithValue("@nombrerancho", emp.Nombrerancho);
                cmd.Parameters.AddWithValue("@nroRuc", emp.NroRuc);
                cmd.Parameters.AddWithValue("@direccionran", emp.Direccionran);
                cmd.Parameters.AddWithValue("@correo", emp.Correo);
                cmd.Parameters.AddWithValue("@clavecorreo", emp.Clavecorreo);

                cmd.Parameters.AddWithValue("@clavesol", emp.Clavesol);
                cmd.Parameters.AddWithValue("@usuariosol", emp.Usuariosol);
                cmd.Parameters.AddWithValue("@clavecertificado", emp.Clavecertificado);
                cmd.Parameters.AddWithValue("@obs", emp.Obs);

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
                MessageBox.Show("Error al Editar: " + ex.Message, "SP_editar_miempresa", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            return rpt;
        }
        public DataTable BD_Mostrar_Empresa(int idemp)
        {

            try
            {
                SqlDataAdapter da = new SqlDataAdapter("SP_Buscar_miempresa", cn);
                da.SelectCommand.CommandTimeout = 15;
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@id", idemp);

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
                MessageBox.Show("Error al Mostrar: " + ex.Message, "SP_Buscar_miempresa", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return null;
            }

        }
    }
}
