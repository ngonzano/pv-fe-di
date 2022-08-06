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
    public class BD_Documento
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString);
        public int BD_Ingresar_Documento(EN_Documento e_doc)
        {

            int rpt;
            try
            {

                SqlCommand cmd = new SqlCommand("Sp_Insert_Documento", cn);
                cmd.CommandTimeout = 15;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_Doc", e_doc.Id_Doc.Trim());
                cmd.Parameters.AddWithValue("@id_Ped",e_doc.Id_Ped.Trim());
                cmd.Parameters.AddWithValue("@Id_Tipo",e_doc.Id_Tipo);
                cmd.Parameters.AddWithValue("@Fecha_Emi",e_doc.Fecha_Emi);
                cmd.Parameters.AddWithValue("@Importe", e_doc.Importe);
                cmd.Parameters.AddWithValue("@TipoPago",e_doc.TipoPago);
                cmd.Parameters.AddWithValue("@NroOpera",e_doc.NroOpera);
                cmd.Parameters.AddWithValue("@id_Usu", e_doc.Id_Usu);
                cmd.Parameters.AddWithValue("@Igv", e_doc.Igv);
                cmd.Parameters.AddWithValue("@son", e_doc.Son);
                cmd.Parameters.AddWithValue("@TotalGanancia",e_doc.TotalGanancia);

                cmd.Parameters.AddWithValue("@CDR_Sunat", e_doc.CDR_Sunat);
                cmd.Parameters.AddWithValue("@Hash_CPE", e_doc.Hash_CPE);
                cmd.Parameters.AddWithValue("@EstadoBajada", e_doc.EstadoBajada);
                cmd.Parameters.AddWithValue("@NroTicket_Baja", e_doc.NroTicket_Baja);
                cmd.Parameters.AddWithValue("@Hash_CPE_Baja", e_doc.Hash_CPE_Baja);

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
                MessageBox.Show("Error al Registrar: " + ex.Message, "Sp_Insert_Documento", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            return rpt;
        }
        public int BD_Editar_Documento(EN_Documento e_doc)
        {

            int rpt;
            try
            {

                SqlCommand cmd = new SqlCommand("Sp_Actualizar_documento", cn);
                cmd.CommandTimeout = 15;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_Doc", e_doc.Id_Doc.Trim());
                cmd.Parameters.AddWithValue("@Importe", e_doc.Importe);
                cmd.Parameters.AddWithValue("@Igv", e_doc.Igv);
                cmd.Parameters.AddWithValue("@son", e_doc.Son);

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
                MessageBox.Show("Error al Editar: " + ex.Message, "Sp_Actualizar_documento", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            return rpt;
        }
        public bool BD_Verificar_Nro_Documento(string idDoc)
        {
            //SqlConnection cn = new SqlConnection();
            bool rpt = false;
            Int32 getvalue = 0;
            try
            {
                SqlCommand cmd = new SqlCommand();
                //cn.ConnectionString = Conectar();

                cmd.CommandText = "Sp_Validar_Id_Doc";
                cmd.Connection = cn;
                cmd.CommandTimeout = 15;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id_Doc", idDoc);
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
                MessageBox.Show("Error al validar Documento: " + ex.Message, "Sp_Validar_Id_Doc", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            return rpt;
        }
        public DataTable BD_BuscarDocumentoValor(DateTime fi,DateTime ff, string valor)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("Sp_Buscador_Documentos_xValor", cn);
                da.SelectCommand.CommandTimeout = 15;
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@fechaInicio", ff);
                da.SelectCommand.Parameters.AddWithValue("@fechaFin", fi);
                da.SelectCommand.Parameters.AddWithValue("@Xvalor", valor);

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
                MessageBox.Show("Error al Buscar: " + ex.Message, "Sp_Buscador_Documentos_xValor", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return null;
            }

        }
        public DataTable BD_BuscarDocumentoValorUnico(string valor)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("Sp_Buscador_Documentos_xValorUnico", cn);
                da.SelectCommand.CommandTimeout = 15;
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@Xvalor", valor);

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
                MessageBox.Show("Error al Buscar: " + ex.Message, "Sp_Buscador_Documentos_xValorUnico", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return null;
            }

        }
        public DataTable BD_Buscar_Documento_Dia(DateTime fecha)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("Sp_Listar_Doc_emitoshoy", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@FechaActual", fecha);
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
                MessageBox.Show("Error al Mostrar: " + ex.Message, "Sp_Listar_Doc_emitoshoy", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return null;
            }
        }
        public DataTable BD_Buscar_Documento_Mes(DateTime fecha)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("Sp_Leer_Fcturas_Emtidas_EnunMes", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@Fecha_Mes", fecha);
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
                MessageBox.Show("Error al Mostrar: " + ex.Message, "Sp_Leer_Fcturas_Emtidas_EnunMes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return null;
            }
        }
        public DataTable BD_Buscar_Comprobantes_Mes_Documento( DateTime fecha, string iddocum)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("Sp_Leer_Comprobantes_Emtidas_EnunMes", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@Fecha_Mes", fecha); 
                da.SelectCommand.Parameters.AddWithValue("@Docu", iddocum);
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
                MessageBox.Show("Error al Mostrar: " + ex.Message, "Sp_Leer_Comprobantes_Emtidas_EnunMes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return null;
            }
        }
        public DataTable BD_Buscar_Documento_y_Detalle(string nroDoc)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("Sp_Buscar_Documento_yDetalle", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@Nro_Doc", nroDoc);
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
                MessageBox.Show("Error al Mostrar: " + ex.Message, "Sp_Buscar_Documento_yDetalle", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return null;
            }
        }
        public int BD_Anular_Documento(string iddocum, string estado)
        {

            int rpt;
            try
            {

                SqlCommand cmd = new SqlCommand("Sp_Anular_Documento", cn);
                cmd.CommandTimeout = 15;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id_Doc", iddocum.Trim());
                cmd.Parameters.AddWithValue("@estado", estado);

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
                MessageBox.Show("Error al Anular: " + ex.Message, "Sp_Anular_Documento", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            return rpt;
        }
        public int BD_Cambiar_TipoPago_Documento(string iddocum, string tipopago)
        {

            int rpt;
            try
            {

                SqlCommand cmd = new SqlCommand("Sp_Cambiar_TipoPago_Documento", cn);
                cmd.CommandTimeout = 15;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id_Doc", iddocum.Trim());
                cmd.Parameters.AddWithValue("@tipoPago", tipopago);

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
                MessageBox.Show("Error al Cambiar tipo Documento: " + ex.Message, "Sp_Cambiar_TipoPago_Documento", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            return rpt;
        }

        public int BD_Cambiar_RPT_EstadoSunat(string iddocum, string EstadoCDR,string hash_CPE)
        {

            int rpt;
            try
            {

                SqlCommand cmd = new SqlCommand("SP_Cambiar_RespuestaSunat", cn);
                cmd.CommandTimeout = 15;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", iddocum.Trim());
                cmd.Parameters.AddWithValue("@EstadoCDR", EstadoCDR);
                cmd.Parameters.AddWithValue("@hash_CPE", hash_CPE); 

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
                MessageBox.Show("Error: " + ex.Message, "SP_Cambiar_RespuestaSunat", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            return rpt;
        }
        public DataTable BD_Buscar_Documento_y_Detalle2(string nroDoc)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("Sp_Buscar_Documento_yDetalle2", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@Nro_Doc", nroDoc);
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
                MessageBox.Show("Error al Mostrar: " + ex.Message, "Sp_Buscar_Documento_yDetalle2", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return null;
            }
        }
        public DataTable BD_Leer_Docs_delDia_PorTiopoDoc(DateTime fecha,int docu)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("SP_Leer_Docs_delDia_PorTiopoDoc", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@fecha_mes", fecha);
                da.SelectCommand.Parameters.AddWithValue("@Docu", docu);
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
                MessageBox.Show("Error al Mostrar: " + ex.Message, "SP_Leer_Docs_delDia_PorTiopoDoc", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return null;
            }
        }
        public bool BD_Validar_FechaDoc_EnResumenBoleta(DateTime fechaElegida,DateTime fecha_doc)
        {
            //SqlConnection cn = new SqlConnection();
            bool rpt = false;
            Int32 getvalue = 0;
            try
            {
                SqlCommand cmd = new SqlCommand();
                //cn.ConnectionString = Conectar();

                cmd.CommandText = "SP_Validar_FechaDoc_EnResumenBoleta";
                cmd.Connection = cn;
                cmd.CommandTimeout = 15;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@fechaElegida", fechaElegida);
                cmd.Parameters.AddWithValue("@fecha_doc", fecha_doc);
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
                MessageBox.Show("Error al validar Documento: " + ex.Message, "SP_Validar_FechaDoc_EnResumenBoleta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            return rpt;
        }
        public int BD_ActualizarBajasSunat(string id_Doc, string EstadoBajada, string NroTicket_Baja, string Hash_CPE_Baja)
        {

            int rpt;
            try
            {

                SqlCommand cmd = new SqlCommand("SP_ActualizarBajasSunat", cn);
                cmd.CommandTimeout = 15;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_Doc", id_Doc.Trim());
                cmd.Parameters.AddWithValue("@EstadoBajada", EstadoBajada.Trim());
                cmd.Parameters.AddWithValue("@NroTicket_Baja", NroTicket_Baja);
                cmd.Parameters.AddWithValue("@Hash_CPE_Baja", Hash_CPE_Baja);

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
                MessageBox.Show("Error: " + ex.Message, "SP_ActualizarBajasSunat", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            return rpt;
        }
    }
}
