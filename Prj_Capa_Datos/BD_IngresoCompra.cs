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
    public class BD_IngresoCompra
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString);
        public int BD_Ingresar_Header_RegistroCompra(EN_IngresarCompra e_ingCompra)
        {
            int rpt;
            try
            {
                SqlCommand cmd = new SqlCommand("Sp_Registrar_Compra", cn);
                cmd.CommandTimeout = 15;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idCom", e_ingCompra.Idcom);
                cmd.Parameters.AddWithValue("@Nro_Fac_Fisico", e_ingCompra.Nro_Fac_Fisico);
                cmd.Parameters.AddWithValue("@IdProvee", e_ingCompra.IdProvee);
                cmd.Parameters.AddWithValue("@SubTotal_Com", e_ingCompra.SubTotal_Com);
                cmd.Parameters.AddWithValue("@FechaIngre", e_ingCompra.FechaIngre);
                cmd.Parameters.AddWithValue("@TotalCompra", e_ingCompra.TotalCompra);
                cmd.Parameters.AddWithValue("@IdUsu", e_ingCompra.IdUsu);
                cmd.Parameters.AddWithValue("@ModalidadPago", e_ingCompra.ModalidadPago);
                cmd.Parameters.AddWithValue("@TiempoEspera", e_ingCompra.TiempoEspera);
                cmd.Parameters.AddWithValue("@FechaVence", e_ingCompra.FechaVence);
                cmd.Parameters.AddWithValue("@EstadoIngre", e_ingCompra.EstadoIngre);
                cmd.Parameters.AddWithValue("@RecibiConforme", e_ingCompra.RecibiConforme);
                cmd.Parameters.AddWithValue("@Datos_Adicional", e_ingCompra.Datos_Adicional);
                cmd.Parameters.AddWithValue("@Tipo_Doc_Compra", e_ingCompra.Tipo_Doc_Compra);
                cmd.Parameters.AddWithValue("@Tipo_Ingreso", e_ingCompra.Tipo_ingreso);

                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
                rpt = 1;
                MessageBox.Show("La compra se registro con exito.", "COMPRAS", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                MessageBox.Show("Error al Registrar: " + ex.Message, "Sp_Registrar_Compra", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                rpt = 0;
            }
            return rpt;
        }
        public int BD_Ingresar_Detalle_RegistroCompra(EN_Det_IngresoCompra e_DetaingCompra)
        {
            int rpt;
            try
            {
                SqlCommand cmd = new SqlCommand("Sp_Insert_Detalle_ingreso", cn);
                cmd.CommandTimeout = 15;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id_ingreso", e_DetaingCompra.Id_ingreso);
                cmd.Parameters.AddWithValue("@Id_Pro", e_DetaingCompra.Id_pro);
                cmd.Parameters.AddWithValue("@Precio", e_DetaingCompra.Precio);
                cmd.Parameters.AddWithValue("@Cantidad", e_DetaingCompra.Cantidad);
                cmd.Parameters.AddWithValue("@Importe", e_DetaingCompra.Importe);

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
                MessageBox.Show("Error al Registrar: " + ex.Message, "Sp_Insert_Detalle_ingreso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                rpt = 0;
            }
            return rpt;
        }
        public bool BD_Validar_NroDocumento_fisico(string NroDocumento)
        {
            bool rpt;
            Int32 getvalue = 0;
            try
            {
                SqlCommand cmd = new SqlCommand();

                cmd.CommandText = "sp_validar_NroFisico_Compra";
                cmd.Connection = cn;
                cmd.CommandTimeout = 15;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Nro_Doc_fisico", NroDocumento);
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
                MessageBox.Show("Error al validar Compra: " + ex.Message, "sp_validar_NroFisico_Compra", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            return rpt;
        }
        public DataTable BD_Buscar_Compras_Explorador(string valor)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("Sp_Buscador_Gnral_deCompras", cn);
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
                MessageBox.Show("Error al Mostrar: " + ex.Message, "Sp_Buscador_Gnral_deCompras", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return null;
            }
        }
        public DataTable BD_MostrarTodoCompras_Explo(DateTime fi,DateTime ff,string valor)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("Sp_Leer_Todas_Facturas_Compras", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@fi", fi);
                da.SelectCommand.Parameters.AddWithValue("@ff", ff);
                da.SelectCommand.Parameters.AddWithValue("@valor", valor);
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
                MessageBox.Show("Error al Mostrar: " + ex.Message, "Sp_Leer_Todas_Facturas_Compras", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return null;
            }
        }
        public DataTable BD_Buscar_Compras_Expl_MES_DIA(string tipo,DateTime fecha)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("Sp_Facturas_Ingresadas_alDia", cn);
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
                MessageBox.Show("Error al Mostrar: " + ex.Message, "Sp_Facturas_Ingresadas_alDia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return null;
            }
        }
        public int BD_Borrar_Compra(string idcompra)
        {
            int rpt;
            try
            {
                SqlCommand cmd = new SqlCommand("SP_Borrar_Factura_Ingresada", cn);
                cmd.CommandTimeout = 15;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id_Fac", idcompra);

                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
                rpt = 1;
                MessageBox.Show("Se borro la conpra con exito.", "COMPRAS", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                MessageBox.Show("Error al borrar compra: " + ex.Message, "SP_Borrar_Factura_Ingresada", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                rpt = 0;
            }
            return rpt;
        }
        
        public DataTable BD_Buscar_Documento_Detalle(string xvalor)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("Sp_Buscar_FacturasCompras_Detalle", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@xvalor", xvalor);
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
                MessageBox.Show("Error al Buscar: " + ex.Message, "Sp_Buscar_FacturasCompras_Detalle", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return null;
            }
        }
    }
}
