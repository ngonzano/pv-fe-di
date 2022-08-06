using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

using SPV_Capa_Entidad;
using System.Windows.Forms;
using System.Configuration;

namespace SPV_Capa_Datos
{
    public class BD_notaCredito
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString);
        public int BD_Agregar_NotaCredito(EN_notacredito ObjPed)
        {
            SqlCommand Cmd = new SqlCommand("Sp_Insert_NotaCredito", cn);
            int rpt;
            try
            {
                Cmd.CommandTimeout = 20;
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.Parameters.AddWithValue("@Id_cre", ObjPed.idcre);
                Cmd.Parameters.AddWithValue("@Id_Doc", ObjPed.nrodoc);
                // Cmd.Parameters.AddWithValue("@Ruc", ObjPed.Ruc)
                Cmd.Parameters.AddWithValue("@TipoComprabnte", ObjPed.TipoComprobnte);
                Cmd.Parameters.AddWithValue("@OtrosDatos", ObjPed.OtrosDatos);
                Cmd.Parameters.AddWithValue("@Fecha_Cred", ObjPed.Fechaemi);
                // Cmd.Parameters.AddWithValue("@Cliente", ObjPed.cliente)
                Cmd.Parameters.AddWithValue("@Total", ObjPed.total);
                Cmd.Parameters.AddWithValue("@IgvC", ObjPed.Igv);
                Cmd.Parameters.AddWithValue("@Subtotal", ObjPed.SubTotal);
                Cmd.Parameters.AddWithValue("@id_Usu", ObjPed.idusu);
                Cmd.Parameters.AddWithValue("@MotivoEmision", ObjPed.motivoEmisio);
                Cmd.Parameters.AddWithValue("@soncre", ObjPed.son);
                Cmd.Parameters.AddWithValue("@EstadoDinero", ObjPed.EstadoDinero);
                Cmd.Parameters.AddWithValue("@IdCliente", ObjPed.Id_Cliente);
                Cmd.Parameters.AddWithValue("@CdrSunat_NotaCre", ObjPed.CdrSunat);
                Cmd.Parameters.AddWithValue("@HashCpe_NotaCre", ObjPed.HasCpe);
                Cmd.Parameters.AddWithValue("@NC_Enviado_Sunat", ObjPed.NC_Enviado_Sunat);
                cn.Open();
                Cmd.ExecuteNonQuery();
                cn.Close();

                Cmd.Dispose();
                Cmd = null/* TODO Change to default(_) if this is not a reference type */;
                cn = null/* TODO Change to default(_) if this is not a reference type */;
                rpt = 1;
            }
            // MsgBox("La Nota de Credito" & "Nro: " & ObjPed.idcre & "se guardo con Exito", MsgBoxStyle.Information, "Aviso")
            catch (Exception ex)
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                    Cmd.Dispose();
                    Cmd = null/* TODO Change to default(_) if this is not a reference type */;
                    MessageBox.Show("Error: " + ex.Message, "Sp_Insert_NotaCredito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                rpt = 0;
            }

            return rpt;
        }
        //Detalle:
        public int BD_Agregar_Items_Detalle_notacredito(EN_DetNotacredito ObjDet)
        {
            SqlCommand Cmd = new SqlCommand("Sp_Insert_Detalle_notacredito", cn);
            int rpt;
            try
            {
                Cmd.CommandTimeout = 20;
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.Parameters.AddWithValue("@Id_cre", ObjDet.idcre);
                Cmd.Parameters.AddWithValue("@Id_Pro", ObjDet.idpro);
                Cmd.Parameters.AddWithValue("@Precio", ObjDet.PrecioUnit);
                Cmd.Parameters.AddWithValue("@Cantidad", ObjDet.Cantidadc);
                Cmd.Parameters.AddWithValue("@Importe", ObjDet.ImporteCre);
                Cmd.Parameters.AddWithValue("@TipoProdcto", ObjDet.TipoProdcto);
                Cmd.Parameters.AddWithValue("@DetalleNotaCredi", ObjDet.Detalle_Prodcto);

                Cmd.Parameters.AddWithValue("@Cant_Origen", ObjDet.Cant_Origen);

                cn.Open();
                Cmd.ExecuteNonQuery();
                cn.Close();

                Cmd.Dispose();
                Cmd = null/* TODO Change to default(_) if this is not a reference type */;
                cn = null/* TODO Change to default(_) if this is not a reference type */;
                rpt = 1;
            }
            catch (Exception ex)
            {
                rpt = 0;
                if (cn.State == ConnectionState.Open)
                    cn.Close();
                Cmd.Dispose();
                Cmd = null/* TODO Change to default(_) if this is not a reference type */;
                MessageBox.Show("Error al Guardar: " + ex.Message, "Sp_Insert_Detalle_notacredito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            return rpt;
        }
        public int BD_Actualizar_EstadoDinero_NC(string nroDoc_NC, string xstadodinero)
        {
            SqlCommand Cmd = new SqlCommand("Sp_Actualizar_EstadoDinero_NC", cn);
            int rpt;
            try
            {
                Cmd.CommandTimeout = 20;
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.Parameters.AddWithValue("@NroNotaCredi", nroDoc_NC);
                Cmd.Parameters.AddWithValue("@EstadoDinero", xstadodinero);

                cn.Open();
                Cmd.ExecuteNonQuery();
                cn.Close();

                Cmd.Dispose();
                Cmd = null/* TODO Change to default(_) if this is not a reference type */;
                cn = null/* TODO Change to default(_) if this is not a reference type */;
                rpt = 1;
            }
            catch (Exception ex)
            {
                rpt = 0;
                if (cn.State == ConnectionState.Open)
                    cn.Close();
                Cmd.Dispose();
                Cmd = null/* TODO Change to default(_) if this is not a reference type */;
                MessageBox.Show("Error: " + ex.Message, "Sp_Actualizar_EstadoDinero_NC", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            return rpt;
        }
        public int BD_Actualizar_EstadoSunat_NC(string nroDoc_NC, string CdrSunat, string HashCpe)
        {
            SqlCommand Cmd = new SqlCommand("Sp_ActualizarEstadoSunat_NotaCre", cn);
            int rpt;
            try
            {
                Cmd.CommandTimeout = 20;
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.Parameters.AddWithValue("@IdNotaCre", nroDoc_NC);
                Cmd.Parameters.AddWithValue("@CdrSunat", CdrSunat);
                Cmd.Parameters.AddWithValue("@HashCpe", HashCpe);

                cn.Open();
                Cmd.ExecuteNonQuery();
                cn.Close();

                Cmd.Dispose();
                Cmd = null/* TODO Change to default(_) if this is not a reference type */;
                cn = null/* TODO Change to default(_) if this is not a reference type */;
                rpt = 1;
            }
            catch (Exception ex)
            {
                rpt = 0;
                if (cn.State == ConnectionState.Open)
                    cn.Close();
                Cmd.Dispose();
                Cmd = null/* TODO Change to default(_) if this is not a reference type */;
                MessageBox.Show("Error: " + ex.Message, "Sp_ActualizarEstadoSunat_NotaCre", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            return rpt;
        }
        public DataTable BD_Leer_Todas_notadecredito()
        {
            SqlConnection Cn = new SqlConnection();
            try
            {
                SqlDataAdapter Da = new SqlDataAdapter("SP_Cargar_Todas_Las_Notacredito", cn);
                Da.SelectCommand.CommandType = CommandType.StoredProcedure;

                DataTable Datos = new DataTable();
                Da.Fill(Datos);
                Da = null/* TODO Change to default(_) if this is not a reference type */;
                return Datos;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "SP_Cargar_Todas_Las_Notacredito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                if (cn.State == ConnectionState.Open)
                    cn.Close();
                Cn.Dispose();
                cn = null/* TODO Change to default(_) if this is not a reference type */;
                return null/* TODO Change to default(_) if this is not a reference type */;
            }
        }

        public DataTable BD_Leer_Todas_notadecredito_emitidosHOy()
        {
            SqlConnection Cn = new SqlConnection();
            try
            {
                SqlDataAdapter Da = new SqlDataAdapter("Sp_Listar_NotaCredito_EitidosHoy", cn);
                Da.SelectCommand.CommandType = CommandType.StoredProcedure;

                DataTable Datos = new DataTable();
                Da.Fill(Datos);
                Da = null/* TODO Change to default(_) if this is not a reference type */;
                return Datos;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Sp_Listar_NotaCredito_EitidosHoy", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                if (cn.State == ConnectionState.Open)
                    cn.Close();
                Cn.Dispose();
                cn = null/* TODO Change to default(_) if this is not a reference type */;
                return null/* TODO Change to default(_) if this is not a reference type */;
            }
        }
        public DataTable BD_Buscardor_Gneral_NotasCreditos(string xvalor)
        {
            SqlConnection Cn = new SqlConnection();
            try
            {
                SqlDataAdapter Da = new SqlDataAdapter("SP_Buscador_Gneral_NotasCredito", cn);
                Da.SelectCommand.CommandType = CommandType.StoredProcedure;
                Da.SelectCommand.Parameters.AddWithValue("@xValor", xvalor);

                DataTable Datos = new DataTable();
                Da.Fill(Datos);
                Da = null/* TODO Change to default(_) if this is not a reference type */;
                return Datos;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "SP_Buscador_Gneral_NotasCredito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                if (cn.State == ConnectionState.Open)
                    cn.Close();
                Cn.Dispose();
                cn = null/* TODO Change to default(_) if this is not a reference type */;
                return null/* TODO Change to default(_) if this is not a reference type */;
            }
        }
        public DataTable BD_Buscar_NotaCredito_Pormes(DateTime xvalor)
        {
            SqlConnection Cn = new SqlConnection();
            try
            {
                SqlDataAdapter Da = new SqlDataAdapter("Sp_Listar_NotaCredito_delMes", cn);
                Da.SelectCommand.CommandType = CommandType.StoredProcedure;
                Da.SelectCommand.Parameters.AddWithValue("@fecha", xvalor);

                DataTable Datos = new DataTable();
                Da.Fill(Datos);
                Da = null/* TODO Change to default(_) if this is not a reference type */;
                return Datos;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Sp_Listar_NotaCredito_delMes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                if (cn.State == ConnectionState.Open)
                    cn.Close();
                Cn.Dispose();
                cn = null/* TODO Change to default(_) if this is not a reference type */;
                return null/* TODO Change to default(_) if this is not a reference type */;
            }
        }
        //====================0
        // '4 cargar detalle de la nota de credito
        public DataTable BD_Cargar_NotaCredito_Detalle(string xvalor)
        {
            SqlConnection Cn = new SqlConnection();
            try
            {
                SqlDataAdapter Da = new SqlDataAdapter("SP_Cargar_NotaCredito_Detalle", cn);
                Da.SelectCommand.CommandType = CommandType.StoredProcedure;
                Da.SelectCommand.Parameters.AddWithValue("@nronotacred", xvalor);

                DataTable Datos = new DataTable();
                Da.Fill(Datos);
                Da = null/* TODO Change to default(_) if this is not a reference type */;
                return Datos;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "SP_Cargar_NotaCredito_Detalle", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                if (cn.State == ConnectionState.Open)
                    cn.Close();
                Cn.Dispose();
                cn = null/* TODO Change to default(_) if this is not a reference type */;
                return null/* TODO Change to default(_) if this is not a reference type */;
            }
        }
        //verificar:        
        public bool BD_Verificar_SiFactura_Tiene_NotaCredito(string nroDoc)
        {
            bool respuesta = false;
            Int32 getvalue = 0;
            try
            {

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "Sp_Validar_Factura_enNotaCredito";
                cmd.Connection = cn;
                cmd.CommandTimeout = 20;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@nrFactu", nroDoc);
                cn.Open();
                getvalue = Convert.ToInt32(cmd.ExecuteScalar());
                if (getvalue > 0)
                {
                    respuesta = true;
                }
                else
                {
                    respuesta = false;
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
                MessageBox.Show("Error: " + ex.Message, "Sp_Validar_Factura_enNotaCredito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                respuesta = false;
            }

            return respuesta;
        }

        public DataTable BD_Buscar_NC_PendientePago(string xvalor)
        {
            SqlConnection Cn = new SqlConnection();
            try
            {
                SqlDataAdapter Da = new SqlDataAdapter("SP_buscarNC_PendientePago", cn);
                Da.SelectCommand.CommandType = CommandType.StoredProcedure;
                Da.SelectCommand.Parameters.AddWithValue("@idCred", xvalor);

                DataTable Datos = new DataTable();
                Da.Fill(Datos);
                Da = null/* TODO Change to default(_) if this is not a reference type */;
                return Datos;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "SP_buscarNC_PendientePago", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                if (cn.State == ConnectionState.Open)
                    cn.Close();
                Cn.Dispose();
                cn = null/* TODO Change to default(_) if this is not a reference type */;
                return null/* TODO Change to default(_) if this is not a reference type */;
            }
        }
        //verificar:        
        public bool BD_Verificar_NC_PendientePago(string nroDoc)
        {
            bool respuesta = false;
            Int32 getvalue = 0;
            try
            {

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SP_VerificarNC_PendientePago";
                cmd.Connection = cn;
                cmd.CommandTimeout = 20;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idCred", nroDoc);
                cn.Open();
                getvalue = Convert.ToInt32(cmd.ExecuteScalar());
                if (getvalue > 0)
                {
                    respuesta = true;
                }
                else
                {
                    respuesta = false;
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
                MessageBox.Show("Error: " + ex.Message, "SP_VerificarNC_PendientePago", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                respuesta = false;
            }

            return respuesta;
        }
    }
}
