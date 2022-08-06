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
    public class BD_Credito
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString);
        public int BD_Ingresar_Credito_Header(EN_Credito e_cred)
        {

            int rpt;
            try
            {

                SqlCommand cmd = new SqlCommand("Sp_Registrar_Credito", cn);
                cmd.CommandTimeout = 15;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idnotacredito", e_cred.Idnotacredito);
                cmd.Parameters.AddWithValue("@idDoc", e_cred.IdDoc);
                cmd.Parameters.AddWithValue("@Fecha_Credito", e_cred.Fecha_Credito);
                cmd.Parameters.AddWithValue("@nomcliente", e_cred.Nomcliente);
                cmd.Parameters.AddWithValue("@total_ped", e_cred.Total_ped);
                cmd.Parameters.AddWithValue("@Saldo_Pdnte", e_cred.Saldo_Pdnte);
                cmd.Parameters.AddWithValue("@Fecha_vncmnto", e_cred.Fecha_vncmnto);

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
                MessageBox.Show("Error al Registrar: " + ex.Message, "Sp_Registrar_Credito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            return rpt;
        }
        public int BD_Ingresar_Credito_Det(EN_Det_Credito e_detcred)
        {

            int rpt;
            try
            {

                SqlCommand cmd = new SqlCommand("Sp_ingresar_det_Credito", cn);
                cmd.CommandTimeout = 15;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idnotacredito", e_detcred.Idnotacredito);
                cmd.Parameters.AddWithValue("@Acuenta", e_detcred.Acuenta);
                cmd.Parameters.AddWithValue("@saldoactual", e_detcred.Saldoactual);
                cmd.Parameters.AddWithValue("@Fecha_Pago", e_detcred.Fecha_Pago);
                cmd.Parameters.AddWithValue("@TipoPago", e_detcred.TipoPago);
                cmd.Parameters.AddWithValue("@nroOpera", e_detcred.NroOpera);
                cmd.Parameters.AddWithValue("@idUsu", e_detcred.IdUsu);

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
                MessageBox.Show("Error al Registrar: " + ex.Message, "Sp_ingresar_det_Credito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            return rpt;
        }
        //public DataTable BD_Mostrar_Todo_Credito()
        //{
        //    try
        //    {
        //        SqlDataAdapter da = new SqlDataAdapter("Sp_Ver_Todo_Credito", cn);
        //        da.SelectCommand.CommandTimeout = 15;
        //        da.SelectCommand.CommandType = CommandType.StoredProcedure;

        //        DataTable dt = new DataTable();
        //        da.Fill(dt);
        //        da = null;
        //        return dt;
        //    }
        //    catch (Exception ex)
        //    {
        //        if (cn.State == ConnectionState.Open)
        //        {
        //            cn.Close();
        //        }
        //        MessageBox.Show("Error al Mostrar: " + ex.Message, "Capa Datos Detalle Credito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        //        return null;
        //    }

        //}
        public double BD_Mostrar_Credito_Cliente(string xvalor)
        {
            double rpt ;
            
            try
            {
                SqlCommand cmd = new SqlCommand();

                cmd.CommandText = "Sp_Ver_SumaTotal_credito_xcliente";
                cmd.Connection = cn;
                cmd.CommandTimeout = 15;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@valor", xvalor);
                cn.Open();
               
                rpt = Convert.ToDouble(cmd.ExecuteScalar());
                
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
                MessageBox.Show("Error al validar: " + ex.Message, "Sp_Ver_SumaTotal_credito_xcliente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return rpt=0;
            }
            return rpt;
        }
        public int BD_Validar_Credito(string iddoc)
        {
            int rpt;

            try
            {
                SqlCommand cmd = new SqlCommand();

                cmd.CommandText = "Sp_validar_credito";
                cmd.Connection = cn;
                cmd.CommandTimeout = 15;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id_Doc", iddoc);
                cn.Open();

                rpt = Convert.ToInt32(cmd.ExecuteScalar());

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
                MessageBox.Show("Error al validar Kardex: " + ex.Message, "Sp_validar_credito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return rpt = 0;
            }
            return rpt;
        }
        public int BD_Validar_Vencimiento_credito(string codCredit)
        {
            int rpt;

            try
            {
                SqlCommand cmd = new SqlCommand();

                cmd.CommandText = "Sp_verificar_vencimiento_credito";
                cmd.Connection = cn;
                cmd.CommandTimeout = 15;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Cod_credito", codCredit);
                cn.Open();

                rpt = Convert.ToInt32(cmd.ExecuteScalar());

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
                MessageBox.Show("Error al validar : " + ex.Message, "Sp_verificar_vencimiento_credito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return rpt = 0;
            }
            return rpt;
        }
        public int BD_Actualizar_Saldo_Pendiente(string idNotCred,double SaldoPendiente, string Estado)
        {

            int rpt;
            try
            {

                SqlCommand cmd = new SqlCommand("Sp_Actualizar_Saldo_Pdnte", cn);
                cmd.CommandTimeout = 15;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idnotacredito", idNotCred);
                cmd.Parameters.AddWithValue("@Saldo_Pndte", SaldoPendiente);
                cmd.Parameters.AddWithValue("@Stado", Estado);
                
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
                MessageBox.Show("Error al Actualizar: " + ex.Message, "Sp_Actualizar_Saldo_Pdnte", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            return rpt;
        }
        public int BD_Actualizar_Estado_Credito(string idCredito, string Estado)
        {

            int rpt;
            try
            {

                SqlCommand cmd = new SqlCommand("Sp_Actualizar_Estado_credito", cn);
                cmd.CommandTimeout = 15;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id_credito", idCredito);
                cmd.Parameters.AddWithValue("@xstado", Estado);

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
                MessageBox.Show("Error al Actualizar: " + ex.Message, "Sp_Actualizar_Estado_credito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            return rpt;
        }
        public DataTable BD_Mostrar_Credito_Estado(string estado)
        {

            try
            {
                SqlDataAdapter da = new SqlDataAdapter("Sp_Filtrar_creditos_xEstado", cn);
                da.SelectCommand.CommandTimeout = 15;
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@Stado", estado);

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
                MessageBox.Show("Error al Mostrar: " + ex.Message, "Sp_Filtrar_creditos_xEstado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return null;
            }

        }
        public DataTable BD_Mostrar_Credito_Mes(DateTime mes)
        {

            try
            {
                SqlDataAdapter da = new SqlDataAdapter("Sp_Filtrar_creditos_delMes", cn);
                da.SelectCommand.CommandTimeout = 15;
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@xmes", mes);

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
                MessageBox.Show("Error al Mostrar: " + ex.Message, "Sp_Filtrar_creditos_delMes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return null;
            }

        }
        public DataTable BD_Mostrar_Credito_Dia(DateTime dia)
        {

            try
            {
                SqlDataAdapter da = new SqlDataAdapter("Sp_Filtrar_creditos_deldia", cn);
                da.SelectCommand.CommandTimeout = 15;
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@xdia", dia);

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
                MessageBox.Show("Error al Mostrar: " + ex.Message, "Sp_Filtrar_creditos_deldia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return null;
            }

        }
        public DataTable BD_Buscar_Creditos(string nomCliente)//buscar credito por nombre del cliente
        {

            try
            {
                SqlDataAdapter da = new SqlDataAdapter("Sp_Buscador_creditos", cn);
                da.SelectCommand.CommandTimeout = 15;
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@nomcliente", nomCliente);

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
                MessageBox.Show("Error al Mostrar: " + ex.Message, "Sp_Buscador_creditos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return null;
            }

        }
        public DataTable BD_Mostrar_Detalle_Credito(string id_Cred)
        {

            try
            {
                SqlDataAdapter da = new SqlDataAdapter("Sp_Ver_Det_credito", cn);
                da.SelectCommand.CommandTimeout = 15;
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@id_Cred", id_Cred);

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
                MessageBox.Show("Error al Mostrar: " + ex.Message, "Sp_Ver_Det_credito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return null;
            }

        }
        public int BD_Eliminar_credito_Permanente(string Idcredito)
        {

            int rpt;
            try
            {

                SqlCommand cmd = new SqlCommand("Sp_eliminar_Credito_Permanente", cn);
                cmd.CommandTimeout = 15;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Idcredito", Idcredito);

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
                MessageBox.Show("Error al Eliminar: " + ex.Message, "Sp_eliminar_Credito_Permanente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            return rpt;
        }
        public DataTable BD_Mostrar_TodoCredito(DateTime fi,DateTime ff, string nom)
        {

            try
            {
                SqlDataAdapter da = new SqlDataAdapter("Sp_Buscador_TodoCreditos", cn);
                da.SelectCommand.CommandTimeout = 15;
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@fechaInicio", fi);
                da.SelectCommand.Parameters.AddWithValue("@fechaFin", ff);
                da.SelectCommand.Parameters.AddWithValue("@nomcliente", nom);

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
                MessageBox.Show("Error al Mostrar: " + ex.Message, "Sp_Buscador_TodoCreditos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return null;
            }

        }
        public DataTable BD_Buscar_CreditoPrint(DateTime fi, DateTime ff, string idCod)
        {

            try
            {
                SqlDataAdapter da = new SqlDataAdapter("Sp_Buscador_Credito_Print", cn);
                da.SelectCommand.CommandTimeout = 15;
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@fechaInicio", fi);
                da.SelectCommand.Parameters.AddWithValue("@fechaFin", ff);
                da.SelectCommand.Parameters.AddWithValue("@idnotacred", idCod);

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
                MessageBox.Show("Error al Mostrar: " + ex.Message, "Sp_Buscador_Credito_Print", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return null;
            }

        }
        public DataTable BD_Buscar_Credito_Documento(string idDoc)
        {

            try
            {
                SqlDataAdapter da = new SqlDataAdapter("Sp_Buscar_Credito_Documento", cn);
                da.SelectCommand.CommandTimeout = 15;
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@Id_Doc", idDoc);

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
                MessageBox.Show("Error: " + ex.Message, "Sp_Buscar_Credito_Documento", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return null;
            }

        }
    }
}
