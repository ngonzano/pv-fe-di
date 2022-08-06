using SPV_Capa_Entidad;
using SPV_Capa_Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Microsell_Lite.Principal
{
    public partial class Frm_Exptar_Producto : Form
    {
        public Frm_Exptar_Producto()
        {
            InitializeComponent();
        }

        private void Dgv_Datos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int columIndex = e.ColumnIndex;
            string nomColum = Dgv_Datos.Columns[columIndex].Name;
            Dgv_Datos.Columns.Remove(nomColum);
        }

        private void btn_cerrar_Click(object sender, EventArgs e)
        {
            this.Tag = "";
            this.Close();
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            this.Tag = "";
            this.Close();
        }

        private void btn_Quitar_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in Dgv_Datos.SelectedRows)
            {
                Dgv_Datos.Rows.Remove(row);
                lbl_fila.Text = Dgv_Datos.Rows.Count.ToString();
            }
        }

        private void btn_CargarArchivo_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            if (openFileDialog1.ShowDialog()==DialogResult.OK)
            {
                string filename = openFileDialog1.FileName;
                txt_ruta.Text = filename.Trim();
                txt_nomLibro.Text = "Hoja1";
                if (txt_ruta.Text.Length==0)
                {
                    MessageBox.Show("Cargar la ruta del libro excel","Advertencia de seguridad",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                    return;
                }
                if (txt_nomLibro.Text.Length == 0)
                {
                    MessageBox.Show("Cargar el nombre del libro excel", "Advertencia de seguridad", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                ImportarExcel(txt_ruta.Text.Trim(),txt_nomLibro.Text.Trim());
            }
        }

        private void ImportarExcel(string path,string libroName)
        {
            try
            {
                System.Data.OleDb.OleDbConnection MyConnection;
                System.Data.DataSet dataSet;
                System.Data.OleDb.OleDbDataAdapter MyCommand;

                MyConnection = new System.Data.OleDb.OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path +";Extended Properties=Excel 12.0;");
                MyCommand = new System.Data.OleDb.OleDbDataAdapter("select * from [" + libroName + "$]",MyConnection);

                dataSet = new DataSet();
                MyCommand.Fill(dataSet);
                Dgv_Datos.DataSource = ""; //probar - borrar
                Dgv_Datos.DataSource = dataSet.Tables[0];

                int xnro = Dgv_Datos.RowCount;
                lbl_fila.Text = (xnro - 1).ToString();

                MyConnection.Close();
                btn_Quitar.Enabled =true;
            }
            catch (Exception)
            {
                MessageBox.Show("El nombre de la Pestaña del excel debe ser Hoja1", "Advertencia de seguridad", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            } 
        }
        private void btn_aceptar_Click(object sender, EventArgs e)
        {
            Obtener_Registro();
        }
        string NomProd = "";
        double precioVenta = 0;
        double preCompra = 0;
        double Cant = 0;
        private void Obtener_Registro()
        {
            int xitem = 0;
            int totalFila = 0;
            totalFila = Convert.ToInt32(lbl_fila.Text);
            int xtotal = 0;

            if (Dgv_Datos.Rows.Count==0)
            {
                return;
            }
            try
            {
                foreach (DataGridViewRow fila in Dgv_Datos.Rows)
                {
                    if (Convert.IsDBNull(fila.Cells[0].Value)) //Nombre Producto
                    {
                        break;
                        this.Tag = "A";
                        this.Close();
                    }
                    else
                    {
                        NomProd = fila.Cells[0].Value.ToString();
                    }

                    if (Convert.IsDBNull(fila.Cells[1].Value)) //Precio Compra
                    {
                        break;
                        this.Tag = "A";
                        this.Close();
                    }
                    else
                    {
                        preCompra = Convert.ToDouble(fila.Cells[1].Value);
                    }
                    if (Convert.IsDBNull(fila.Cells[2].Value)) //Precio Venta
                    {
                        break;
                        this.Tag = "A";
                        this.Close();
                    }
                    else
                    {
                        precioVenta = Convert.ToDouble(fila.Cells[2].Value);
                    }
                    if (Convert.IsDBNull(fila.Cells[3].Value)) //Stock
                    {
                        break;
                        this.Tag = "A";
                        this.Close();
                    }
                    else
                    {
                        precioVenta = Convert.ToDouble(fila.Cells[3].Value);
                    }
                    Registrar_Producto(NomProd,preCompra,precioVenta,Cant);
                    xitem++;
                    lbl_Guardado.Text = xitem.ToString();
                    lbl_Guardado.Refresh();

                }
                if (Convert.ToInt32(lbl_fila.Text)==Convert.ToInt32(lbl_Guardado.Text))
                {
                    Frm_Filtro fil = new Frm_Filtro();
                    Utilitarios.Frm_Msm_Bueno bueno = new Utilitarios.Frm_Msm_Bueno();

                    fil.Show();
                    bueno.Lbl_msm1.Text = "La importacion a finalizado, revisar tu exportador de productos";
                    bueno.ShowDialog();
                    fil.Hide();

                    this.Tag = "A";

                }
            }
            catch (Exception)
            {
                MessageBox.Show("Verificar que la Data del producto a ingresar sea valida.", "Advertencia de seguridad", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void Registrar_Producto(string nomProd, double preCompra, double precioVenta, double cant)
        {
            int rpt;
            try
            {//txt_Marca
                RN_Producto n_prod = new RN_Producto();
                EN_Producto e_prod = new EN_Producto();

                e_prod.Idpro = RN_TipoDoc.Sp_Listado_Tipo(4).ToString();
                e_prod.Descripcion = nomProd;
                e_prod.Frank = 1.2;
                e_prod.Pre_compraSol = preCompra;
                e_prod.Pre_CompraDolar = 0;
                e_prod.StockActual = cant;
                e_prod.Idprove = "X-0000000";
                e_prod.IdMar = 4;
                e_prod.IdCat = 6;
                e_prod.Pre_Venta_Menor = precioVenta;
                e_prod.Pre_Venta_Mayor = 0;
                e_prod.Pre_Venta_Dolar = 0;
                e_prod.UndMdida = "Uni";
                e_prod.PesoUnit = 0;
                e_prod.Utilidad = 1;
                e_prod.TipoProd = "Producto";
                e_prod.ValorporProd = 0;
                e_prod.Foto = "-";

                rpt = n_prod.RN_Registrar_Producto(e_prod);
                if (rpt == 1)
                {
                    RN_TipoDoc.RN_Actualizar_SiguienteNro_correlativo(4);
                    Registrar_Kardex(e_prod.Idpro);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al Guardar msj:" + ex, "PRODUCTO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void Registrar_Kardex(string idprod)
        {
            RN_Kardex n_kar = new RN_Kardex();
            EN_Kardex e_kar = new EN_Kardex();

            try
            {
                if (n_kar.RN_Sp_Ver_sihay_Kardex(idprod) == true)
                {
                    return;//ya tiene kardex no hace falta crear otro.

                }
                else
                {
                    string idKardex = RN_TipoDoc.Sp_Listado_Tipo(6);
                    string idProv= RN_TipoDoc.Sp_Listado_Tipo(5);
                    n_kar.RN_Crear_Kardex(idKardex, idprod, idProv);

                    //Detalle del Kardex
                    e_kar.Id_Krdx = idKardex;
                    e_kar.Item = 1;
                    e_kar.Doc_Soport = "000";
                    e_kar.Det_Operacion = "Inicio de Kardex";

                    //Entradas
                    e_kar.Cantidad_In = 0;
                    e_kar.Precio_Unt_In = 0;
                    e_kar.Costo_Total_In = 0;
                    //Salidas
                    e_kar.Cantidad_Out = 0;
                    e_kar.Precio_Unt_Out = 0;
                    e_kar.Importe_Total_Out = 0;
                    //Saldos
                    e_kar.Cantidad_Saldo = 0;
                    e_kar.Promedio = 0;
                    e_kar.Costo_Total_Saldo = 0;
                    if (n_kar.RN_Registrar_det_Kardex(e_kar) == 1)
                    {
                        //Actualizar el siguiente numero correlativo
                        RN_TipoDoc.RN_Actualizar_SiguienteNro_correlativo(6);
                    }


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al Registrar Kardex:" + ex, "KARDEX", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
       
    }
}
