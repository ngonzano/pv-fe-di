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
  public class BD_Kardex //: BDConexion
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString);
        public int BD_Registrar_det_Kardex(EN_Kardex e_Kardex)
        {
           //SqlConnection cn = new SqlConnection();

            try
            {
                //cn.ConnectionString = Conectar();
                SqlCommand cmd = new SqlCommand("Sp_registrar_detalle_kardex", cn);
                cmd.CommandTimeout = 15;
                //cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id_Krdx", e_Kardex.Id_Krdx);
                cmd.Parameters.AddWithValue("@Item", e_Kardex.Item);
                cmd.Parameters.AddWithValue("@Doc_Soport", e_Kardex.Doc_Soport);
                cmd.Parameters.AddWithValue("@Det_Operacion", e_Kardex.Det_Operacion);
                cmd.Parameters.AddWithValue("@Cantidad_In", e_Kardex.Cantidad_In);
                cmd.Parameters.AddWithValue("@Precio_Unt_In", e_Kardex.Cantidad_Out);
                cmd.Parameters.AddWithValue("@Costo_Total_In", e_Kardex.Costo_Total_In);
                cmd.Parameters.AddWithValue("@Cantidad_Out", e_Kardex.Cantidad_Out);
                cmd.Parameters.AddWithValue("@Precio_Unt_Out", e_Kardex.Precio_Unt_Out);
                cmd.Parameters.AddWithValue("@Importe_Total_Out", e_Kardex.Importe_Total_Out);
                cmd.Parameters.AddWithValue("@Cantidad_Saldo", e_Kardex.Cantidad_Saldo);
                cmd.Parameters.AddWithValue("@Promedio", e_Kardex.Promedio);
                cmd.Parameters.AddWithValue("@Costo_Total_Saldo", e_Kardex.Costo_Total_Saldo);
                
                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
                return 1;
            }
            catch (Exception ex)
            {
                
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                MessageBox.Show("Error al guardar detalle Kardex: " + ex.Message, "Capa Datos Det. Kardex", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }
        }
        public int BD_Crear_Kardex(string idkardex, string idprod, string idprovee)
        {
            //SqlConnection cn = new SqlConnection();

            try
            {
               // cn.ConnectionString = Conectar();
                SqlCommand cmd = new SqlCommand("sp_crear_kardex", cn);
                cmd.CommandTimeout = 15;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idkardex", idkardex);
                cmd.Parameters.AddWithValue("@idprod", idprod);
                cmd.Parameters.AddWithValue("@idprovee", idprovee);
                

                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
                return 1;
            }
            catch (Exception ex)
            {

                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                MessageBox.Show("Error al guardar Kardex: " + ex.Message, "Capa Datos Kardex", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }
        }
        public bool BD_Sp_Ver_sihay_Kardex(string idprod)
        {
            //SqlConnection cn = new SqlConnection();
            bool rpt = false;
            Int32 getvalue = 0;
            try
            {
                SqlCommand cmd = new SqlCommand();
                //cn.ConnectionString = Conectar();

                cmd.CommandText = "Sp_Ver_sihay_Kardex";
                cmd.Connection = cn;
                cmd.CommandTimeout = 15;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id_Prod", idprod);
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
                MessageBox.Show("Error al validar Kardex: " + ex.Message, "Capa Datos Kardex", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            return rpt;
        }
        public DataTable BD_BuscarKardexDetalleProducto(string IdProd)
        {

            try
            {
                SqlDataAdapter da = new SqlDataAdapter("Sp_Buscador_DeKardex_Principal_yDetalle", cn);
                da.SelectCommand.CommandTimeout = 15;
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@xvalor", IdProd);

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
                MessageBox.Show("Error al Buscar: " + ex.Message, "Capa Datos Kardex", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return null;
            }

        }
        public DataTable BD_Buscar_ProductoKardex(DateTime fi,DateTime ff, string nom)
        {

            try
            {
                SqlDataAdapter da = new SqlDataAdapter("SP_Kardex_Detalle2", cn);
                da.SelectCommand.CommandTimeout = 15;
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@fechaInicio", fi);
                da.SelectCommand.Parameters.AddWithValue("@fechaFin", ff);
                da.SelectCommand.Parameters.AddWithValue("@nomProd", nom);

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
                MessageBox.Show("Error al Buscar: " + ex.Message, "Capa Datos Kardex Producto", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return null;
            }

        }
        public DataTable BD_Entrada_Salida_Kardex(DateTime fi,DateTime ff)
        {

            try
            {
                SqlDataAdapter da = new SqlDataAdapter("SP_Kardex_Detalle_Print", cn);
                da.SelectCommand.CommandTimeout = 15;
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@fechaInicio", fi);
                da.SelectCommand.Parameters.AddWithValue("@fechaFin", ff);

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
                MessageBox.Show("Error al Buscar: " + ex.Message, "Capa Datos Kardex", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return null;
            }

        }
    }
}
