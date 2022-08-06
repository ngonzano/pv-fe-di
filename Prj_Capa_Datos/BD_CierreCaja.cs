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
    public class BD_CierreCaja
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString);
        //Registrar Inicio de Caja
        public int BD_Registrar_Inicio_CierreCaja(EN_CierreCaja e_cie)
        {
            int rpt;
            try
            {
                SqlCommand cmd = new SqlCommand("Reg_Cierre_Caja", cn);
                cmd.CommandTimeout = 15;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdCierre", e_cie.IdCierre);
                cmd.Parameters.AddWithValue("@Apertura_Caja", e_cie.Apertura_Caja);
                cmd.Parameters.AddWithValue("@Total_Ingreso", e_cie.Total_Ingreso);
                cmd.Parameters.AddWithValue("@TotalEgreso", e_cie.TotalEgreso);
                cmd.Parameters.AddWithValue("@Id_usu", e_cie.Id_usu);
                cmd.Parameters.AddWithValue("@TodoDeposito", e_cie.TodoDeposito);
                cmd.Parameters.AddWithValue("@TotalGanancia", e_cie.TotalGanancia);
                cmd.Parameters.AddWithValue("@TotalEntregado", e_cie.TotalEntregado);
                cmd.Parameters.AddWithValue("@SaldoSiguiente", e_cie.SaldoSiguiente);
                cmd.Parameters.AddWithValue("@TotalFactura", e_cie.TotalFactura);
                cmd.Parameters.AddWithValue("@TotalBoleta", e_cie.TotalBoleta);
                cmd.Parameters.AddWithValue("@Totalnota", e_cie.Totalnota);
                cmd.Parameters.AddWithValue("@TotalCreditoCobrado", e_cie.TotalCreditoCobrado);
                cmd.Parameters.AddWithValue("@TotalCreditoEmitido", e_cie.TotalCreditoEmitido);

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
                MessageBox.Show("Error al Registrar: " + ex.Message, "Reg_Cierre_Caja", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                rpt = 0;
            }
            return rpt;
        }
        //Cierre de Caja - Actualizar
        public int BD_Registrar_Fin_CierreCaja(EN_CierreCaja e_cie)
        {
            int rpt;
            try
            {
                SqlCommand cmd = new SqlCommand("sp_registrar_Cierre_Caja", cn);
                cmd.CommandTimeout = 15;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdCierre", e_cie.IdCierre);
                cmd.Parameters.AddWithValue("@Apertura_Caja", e_cie.Apertura_Caja);
                cmd.Parameters.AddWithValue("@Total_Ingreso", e_cie.Total_Ingreso);
                cmd.Parameters.AddWithValue("@TotalEgreso", e_cie.TotalEgreso);
                cmd.Parameters.AddWithValue("@Id_usu", e_cie.Id_usu);
                cmd.Parameters.AddWithValue("@TodoDeposito", e_cie.TodoDeposito);
                cmd.Parameters.AddWithValue("@TotalGanancia", e_cie.TotalGanancia);
                cmd.Parameters.AddWithValue("@TotalEntregado", e_cie.TotalEntregado);
                cmd.Parameters.AddWithValue("@SaldoSiguiente", e_cie.SaldoSiguiente);
                cmd.Parameters.AddWithValue("@TotalFactura", e_cie.TotalFactura);
                cmd.Parameters.AddWithValue("@TotalBoleta", e_cie.TotalBoleta);
                cmd.Parameters.AddWithValue("@Totalnota", e_cie.Totalnota);
                cmd.Parameters.AddWithValue("@TotalCreditoCobrado", e_cie.TotalCreditoCobrado);
                cmd.Parameters.AddWithValue("@TotalCreditoEmitido", e_cie.TotalCreditoEmitido);

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
                MessageBox.Show("Error al Registrar: " + ex.Message, "sp_registrar_Cierre_Caja", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                rpt = 0;
            }
            return rpt;
        }
        public DataTable BD_Mostrar_CierreCaja_Dia()
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("Sp_Cargar_CierreCaja_delDia", cn);
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
                MessageBox.Show("Error al Mostrar: " + ex.Message, "Sp_Cargar_CierreCaja_delDia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return null;
            }
        }
        public bool BD_Validar_Registro_Caja()
        {
            bool rpt = false;
            Int32 getvalue = 0;
            try
            {
                SqlCommand cmd = new SqlCommand();

                cmd.CommandText = "SP_VALIDAR_REGISTRO_CAJA";
                cmd.Connection = cn;
                cmd.CommandTimeout = 15;
                cmd.CommandType = CommandType.StoredProcedure;
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
                MessageBox.Show("Error al validar: " + ex.Message, "SP_VALIDAR_REGISTRO_CAJA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            return rpt;
        }
        //entradas
        public DataTable BD_Ventas_TipoDocumento_Dia(string tipoDoc, string tipoPago)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("Sp_Calcular_Ventas_PorTipoDoc", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@tipodoc", tipoDoc);
                da.SelectCommand.Parameters.AddWithValue("@tipoPago", tipoPago);
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
                MessageBox.Show("Error al Mostrar: " + ex.Message, "Sp_Calcular_Ventas_PorTipoDoc", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return null;
            }
        }
        //salidas
        public DataTable BD_Gastos_TipoPago_Dia(string tipoPago)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("Sp_Calcular_Gastos_porTipoPago", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@tipoPago", tipoPago);
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
                MessageBox.Show("Error al Mostrar: " + ex.Message, "Sp_Calcular_Gastos_porTipoPago", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return null;
            }
        }
        public DataTable BD_Venta_Credito_Dia()
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("Sp_Calcular_Ventas_aCredito", cn);
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
                MessageBox.Show("Error al Mostrar: " + ex.Message, "Sp_Calcular_Ventas_aCredito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return null;
            }
        }
        public DataTable BD_Venta_Deposito_Dia()
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("Sp_Calcular_Ventas_aDeposito", cn);
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
                MessageBox.Show("Error al Mostrar: " + ex.Message, "Sp_Calcular_Ventas_aDeposito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return null;
            }
        }
        public DataTable BD_Venta_Utilidades_dia()
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("Sp_Calcular_Ventas_GananciadelDia", cn);
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
                MessageBox.Show("Error al Mostrar: " + ex.Message, "Sp_Calcular_Ventas_GananciadelDia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return null;
            }
        }
    }
}
