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
    public class BD_Producto //: BDConexion
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString);
        EN_Producto e_prod = new EN_Producto();
        public static bool SeAgrego = false;
        public static bool SeEdito = false;
        //REGISTRAR
        public int BD_Registrar_Producto(EN_Producto e_prod)
        {
           // SqlConnection cn = new SqlConnection();

            try
            {
                //cn.ConnectionString = Conectar();
                SqlCommand cmd = new SqlCommand("Sp_registrar_Producto", cn);
                cmd.CommandTimeout = 15;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idpro", e_prod.Idpro);
                cmd.Parameters.AddWithValue("@idprove", e_prod.Idprove);
                cmd.Parameters.AddWithValue("@descripcion", e_prod.Descripcion);
                cmd.Parameters.AddWithValue("@frank", e_prod.Frank);
                cmd.Parameters.AddWithValue("@Pre_compraSol", e_prod.Pre_compraSol);
                cmd.Parameters.AddWithValue("@pre_CompraDolar", e_prod.Pre_CompraDolar);
                cmd.Parameters.AddWithValue("@StockActual", e_prod.StockActual);
                cmd.Parameters.AddWithValue("@idCat", e_prod.IdCat);
                cmd.Parameters.AddWithValue("@idMar", e_prod.IdMar);
                cmd.Parameters.AddWithValue("@Pre_Venta_Menor", e_prod.Pre_Venta_Menor);
                cmd.Parameters.AddWithValue("@Pre_Venta_Mayor", e_prod.Pre_Venta_Mayor);
                cmd.Parameters.AddWithValue("@Pre_Venta_Dolar", e_prod.Pre_Venta_Dolar);
                cmd.Parameters.AddWithValue("@UndMdida", e_prod.UndMdida);
                cmd.Parameters.AddWithValue("@PesoUnit", e_prod.PesoUnit);
                cmd.Parameters.AddWithValue("@Utilidad", e_prod.Utilidad);
                cmd.Parameters.AddWithValue("@TipoProd", e_prod.TipoProd);
                cmd.Parameters.AddWithValue("@ValorporProd", e_prod.ValorporProd);

                if (e_prod.Foto != null)
                {
                    cmd.Parameters.AddWithValue("@Foto", e_prod.Foto);
                    //MessageBox.Show("El Producto se registro correctamente", "PRODUCTO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Foto", Application.StartupPath + @"\focus.png");
                   // MessageBox.Show("El Producto se registro Sin Foto", "PRODUCTO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                
                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
                return 1;
            }
            catch (Exception ex)
            {
                SeAgrego = false;
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                MessageBox.Show("Error: " + ex.Message, "Sp_registrar_Producto", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }
        }
        //EDITAR
        public int BD_Editar_Producto(EN_Producto e_prod)
        {
           // SqlConnection cn = new SqlConnection();
            int rpt;
            try
            {
               // cn.ConnectionString = Conectar();
                SqlCommand cmd = new SqlCommand("Sp_Editar_Producto", cn);
                cmd.CommandTimeout = 15;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idpro", e_prod.Idpro);
                cmd.Parameters.AddWithValue("@idprove", e_prod.Idprove);
                cmd.Parameters.AddWithValue("@descripcion", e_prod.Descripcion);
                cmd.Parameters.AddWithValue("@frank", e_prod.Frank);
                cmd.Parameters.AddWithValue("@Pre_compraSol", e_prod.Pre_compraSol);
                cmd.Parameters.AddWithValue("@pre_CompraDolar", e_prod.Pre_CompraDolar);
                cmd.Parameters.AddWithValue("@idCat", e_prod.IdCat);
                cmd.Parameters.AddWithValue("@idMar", e_prod.IdMar);
                cmd.Parameters.AddWithValue("@Pre_Venta_Menor", e_prod.Pre_Venta_Menor);
                cmd.Parameters.AddWithValue("@Pre_Venta_Mayor", e_prod.Pre_Venta_Mayor);
                cmd.Parameters.AddWithValue("@Pre_Venta_Dolar", e_prod.Pre_Venta_Dolar);
                cmd.Parameters.AddWithValue("@UndMdida", e_prod.UndMdida);
                cmd.Parameters.AddWithValue("@PesoUnit", e_prod.PesoUnit);
                cmd.Parameters.AddWithValue("@Utilidad", e_prod.Utilidad);
                cmd.Parameters.AddWithValue("@TipoProd", e_prod.TipoProd);

                if (e_prod.Foto != null)
                {
                    cmd.Parameters.AddWithValue("@Foto", e_prod.Foto);
                   // MessageBox.Show("El Producto se registro correctamente", "PRODUCTO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                   // cmd.Parameters.AddWithValue("@Foto", Application.StartupPath + @"\focus.png");
                   // MessageBox.Show("El Producto se registro Sin Foto", "PRODUCTO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
                rpt = 1;
            }
            catch (Exception ex)
            {
                SeEdito = false;
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                MessageBox.Show("Error: " + ex.Message, "Sp_Editar_Producto", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                rpt = 0;
            }
            return rpt;
        }
        //MOSTRAR
        public DataTable BD_Mostrar_Todas_Producto()
        {
          
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_cargar_Todos_Productos", cn);
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
                MessageBox.Show("Error al Mostrar: " + ex.Message, "sp_cargar_Todos_Productos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return null;
            }

        }
        public DataTable BD_Mostrar_UnidMedida()
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("Sp_Listado_UniMedida", cn);
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
                MessageBox.Show("Error en: " + ex.Message, "Sp_Listado_UniMedida - BD_Producto.cs", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return null;
            }

        }
        public DataTable BD_Buscar_UniMedia(string Valor)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("SP_Buscar_UniMedida", cn);

                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@id", Valor);
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
                MessageBox.Show("Error al Mostrar: " + ex.Message, "SP_Buscar_UniMedida - BD_Producto.cs", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return null;
            }

        }
        public DataTable BD_Buscar_UniMedia_Todos()
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("Sp_Listar_UniMedida_todos", cn);

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
                MessageBox.Show("Error al Mostrar: " + ex.Message, "Sp_Listar_UniMedida_todos - BD_Producto.cs", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return null;
            }

        }
        //BUSCAR PROVEEDOR
        public DataTable BD_Buscar_Producto(string Valor)
        {
           try
            {
                SqlDataAdapter da = new SqlDataAdapter("Sp_buscador_Productos", cn);

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
                MessageBox.Show("Error al Mostrar: " + ex.Message, "Sp_buscador_Productos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return null;
            }

        }
        //ELIMINAR
        public void BD_Eliminar_Producto(string idpro)
        {
            //SqlConnection cn = new SqlConnection();

            try
            {
                //cn.ConnectionString = Conectar();
                SqlCommand cmd = new SqlCommand("sp_Eliminar_Producto", cn);
                cmd.CommandTimeout = 15;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idpro", idpro);
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
                MessageBox.Show("Error al Eliminar: " + ex.Message, "sp_Eliminar_Producto", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        //DAR DE BAJA
        public void BD_DarBaja_Producto(string idProd)
        {
           // SqlConnection cn = new SqlConnection();

            try
            {
                //cn.ConnectionString = Conectar();
                SqlCommand cmd = new SqlCommand("Sp_Darbaja_Producto", cn);
                cmd.CommandTimeout = 15;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idpro", idProd);
               

                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
                SeEdito = true;
            }
            catch (Exception ex)
            {
                SeEdito = false;
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                MessageBox.Show("Error al dar de baja: " + ex.Message, "Sp_Darbaja_Producto", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }       
        //CONTROL STOCK
        public void BD_SumarStock_Producto(string idprod, double stock)
        {
           // SqlConnection cn = new SqlConnection();

            try
            {
               // cn.ConnectionString = Conectar();
                SqlCommand cmd = new SqlCommand("sp_SumarStock", cn);
                cmd.CommandTimeout = 15;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idpro", idprod);
                cmd.Parameters.AddWithValue("@stock", stock);

                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
                SeEdito = true;
            }
            catch (Exception ex)
            {
                SeEdito = false;
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                MessageBox.Show("Error al Sumar Stock: " + ex.Message, "sp_SumarStock", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        public void BD_RestarStock_Producto(string idprod, double stock)
        {
           // SqlConnection cn = new SqlConnection();

            try
            {
               // cn.ConnectionString = Conectar();
                SqlCommand cmd = new SqlCommand("sp_Restar_Stock", cn);
                cmd.CommandTimeout = 15;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idpro", idprod);
                cmd.Parameters.AddWithValue("@stock", stock);

                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
                SeEdito = true;
            }
            catch (Exception ex)
            {
                SeEdito = false;
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                MessageBox.Show("Error al Restar Stock: " + ex.Message, "sp_Restar_Stock", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        //Actualizar Compra Venta
        public void BD_ActPrec_CompraVenta_Producto(string idprod, double precompraSol, double PrecVenta_menor,double utili, double valorAlmacen)
        {

            try
            {
                SqlCommand cmd = new SqlCommand("Sp_Actulizar_Precios_CompraVenta_Producto", cn);
                cmd.CommandTimeout = 15;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id_Pro", idprod);
                cmd.Parameters.AddWithValue("@Pre_CompraS", precompraSol);
                cmd.Parameters.AddWithValue("@Pre_vntaxMenor", PrecVenta_menor);
                cmd.Parameters.AddWithValue("@Utilidad", utili);
                cmd.Parameters.AddWithValue("@ValorAlmacen", valorAlmacen);

                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
                SeEdito = true;
            }
            catch (Exception ex)
            {
                SeEdito = false;
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                MessageBox.Show("Error al Restar Stock: " + ex.Message, "Sp_Actulizar_Precios_CompraVenta_Producto", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        //BUSCAR PROVEEDOR
        public double BD_Buscar_Stock_Producto(string idprod)
        {
            int stock_actual;
            try
            {
                SqlCommand cmd = new SqlCommand();
                //cn.ConnectionString = Conectar();

                cmd.CommandText = "SP_MOSTRAR_STOCK_PRODUCTO";
                cmd.Connection = cn;
                cmd.CommandTimeout = 15;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IDPROD", idprod);
                cn.Open();
                stock_actual = Convert.ToInt32(cmd.ExecuteScalar());
               
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
                MessageBox.Show("Error al validar Kardex: " + ex.Message, "SP_MOSTRAR_STOCK_PRODUCTO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                stock_actual = 0;
            }
            return stock_actual;
        }
    }
}
