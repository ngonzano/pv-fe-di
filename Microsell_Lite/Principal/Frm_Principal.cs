using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsell_Lite.Productos;
using Microsell_Lite.Ventas;
using Microsell_Lite.Cliente;
using Microsell_Lite.Compras;
using Microsell_Lite.Caja;
using Microsell_Lite.Principal;
using Microsell_Lite.NotaCredito;
using Microsell_Lite.GuiaRemision;

namespace Microsell_Lite.Principal
{
    public partial class Frm_Principal : Form
    {
        public Frm_Principal()
        {
            InitializeComponent();
        }
        
        private void Frm_Principal_Load(object sender, EventArgs e)
        {
            lbl_user.Text = Cls_UsuLogin.Usuario;
            timer1.Enabled = true;
        }
        
        private void bt_almacen_Click(object sender, EventArgs e)
        {
            Frm_Explo_Producto prod = new Frm_Explo_Producto();
            prod.MdiParent = this;
            prod.Show();
            prod.txt_buscar.Focus();
            Ocultar();
        }

        private void btn_cerrar_Click(object sender, EventArgs e)
        {
            Utilitarios.Frm_SINO sino = new Utilitarios.Frm_SINO();

            sino.lbl_msm.Text = "Esta Seguro de Cerrar el Sistema";
            sino.ShowDialog();
            
            if (sino.Tag.ToString()=="SI")
            {
                this.Tag = "";
                this.Close();
                Application.Exit();
            }
            
        }

        private void Pnl_Menu_MouseMove(object sender, MouseEventArgs e)
        {
            Utilitario obj = new Utilitario();
           if (e.Button ==MouseButtons.Left )
            {
                obj.Mover_formulario(this);
            }
        }

        private void btn_minimi_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        void Ocultar()
        {
            if (PanelLateral.Width == 247)
            {
                PanelLateral.Width = 40;
                PicUser.Visible = true;
                PicUser_2.Visible = false;
            }
            
        }
        private void btn_hide_Click(object sender, EventArgs e)
        {

          if( PanelLateral.Width == 247)
            {
                PanelLateral.Width = 40;
                PicUser_2.Visible = true;
            }
          else
            {
                PanelLateral.Width = 247;
                PicUser.Visible = true ;
                PicUser_2.Visible = false;
            }
        }

        private void Bt_ventas_Click(object sender, EventArgs e)
        {
            Frm_Crear_Ventas ven = new Frm_Crear_Ventas();
            ven.MdiParent = this;
            ven.Show();
            Ocultar();
        }

        private void bt_cliente_Click(object sender, EventArgs e)
        {
            Frm_Explo_Cliente cli = new Frm_Explo_Cliente();
            cli.MdiParent = this;
            cli.Show();
            cli.txt_buscar.Focus();
            Ocultar();
        }

        private void bt_compras_Click(object sender, EventArgs e)
        {
            Frm_Compras com = new Frm_Compras();
            com.MdiParent = this;
            com.Show();
            Ocultar();
        }

        private void Bt_cotizar_Click(object sender, EventArgs e)
        {
            Cotizacion.Frm_Cotizacion2 coti = new Cotizacion.Frm_Cotizacion2();
            coti.MdiParent = this;
            coti.Show();
            Ocultar();
        }

        private void bt_DocEmitidos_Click(object sender, EventArgs e)
        {
            Frm_Explo_Documento coti = new Frm_Explo_Documento();
            coti.MdiParent = this;
            coti.Show();
            Ocultar();
        }

        private void mantenimientoProveedorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Proveedor.Frm_Explo_Proveedor com = new Proveedor.Frm_Explo_Proveedor();
            com.MdiParent = this;
            com.Show();
            com.txtBuscar.Focus();
            Ocultar();
        }

        private void Bt_AbrirExploradorDeCompras_Click(object sender, EventArgs e)
        {
            Compras.Frm_Explo_Compras com = new Compras.Frm_Explo_Compras();
            com.MdiParent = this;
            com.Show();
            com.txt_buscar.Focus();
            Ocultar();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lbl_Hora.Text = DateTime.Now.ToString("hh:mm:ss");
            
            lbl_Fecha.Text = DateTime.Now.ToLongDateString();
        }

        private void Frm_Principal_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                Frm_Compras com = new Frm_Compras();
                com.MdiParent = this;
                com.Show();
                Ocultar();
            }
        }

        private void bt_VerExploradorDeProductos_Click(object sender, EventArgs e)
        {
            bt_almacen_Click(sender,e);
        }

        private void SeccionAlmacenToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void Bt_VerDocumentosEmitidos_Click(object sender, EventArgs e)
        {
            Ventas.Frm_Explo_Documento doc = new Ventas.Frm_Explo_Documento();
            doc.MdiParent = this;
            doc.Show();
            doc.txt_buscar.Focus();
            Ocultar();
        }

        private void Bt_HacerCierreDeCaja_Click(object sender, EventArgs e)
        {
            Frm_CerrarCaja cerrar=new Frm_CerrarCaja();
            cerrar.MdiParent = this;
            cerrar.Show();
            Ocultar();
        }

        private void Bt_EditarCorrelativos_Click(object sender, EventArgs e)
        {
            Frm_Filtro fil = new Frm_Filtro();
            fil.Show();
            Utilitarios.Frm_Correlativo corr = new Utilitarios.Frm_Correlativo();
            //corr.MdiParent = this;
            corr.ShowDialog();
            fil.Hide();
            
        }

        private void Bt_EditarTipoDeCambio_Click(object sender, EventArgs e)
        {
            Frm_Filtro fil = new Frm_Filtro();
            fil.Show();
            Utilitarios.Frm_EditTipoCambio tc = new Utilitarios.Frm_EditTipoCambio();
            //corr.MdiParent = this;
            tc.ShowDialog();
            fil.Hide();
        }

        private void Bt_RegistrarUnaCompra_Click(object sender, EventArgs e)
        {
            Frm_Compras com = new Frm_Compras();
            com.MdiParent = this;
            com.Show();
            Ocultar();
        }

        private void Bt_AbrirExploradorDeProveedores_Click(object sender, EventArgs e)
        {
            Frm_Explo_Producto prod = new Frm_Explo_Producto();
            prod.MdiParent = this;
            prod.Show();
            prod.txt_buscar.Focus();
            Ocultar();
        }

        private void Bt_RegistrarGastos_Click(object sender, EventArgs e)
        {
            Frm_Registrar_Gastos gasto = new Frm_Registrar_Gastos();
            gasto.MdiParent = this;
            gasto.Show();
            Ocultar();
        }

        private void Bt_RegistrarOtrosIngresos_Click(object sender, EventArgs e)
        {
            Frm_Reg_otroIngresos ingreso = new Frm_Reg_otroIngresos();
            ingreso.MdiParent = this;
            ingreso.Show();
            Ocultar();
        }

        private void Bt_VentanaDeFacturación_Click(object sender, EventArgs e)
        {
            Frm_Crear_Ventas ven = new Frm_Crear_Ventas();
            ven.MdiParent = this;
            ven.Show();
            Ocultar();
        }

        private void Bt_crearUnaCotización_Click(object sender, EventArgs e)
        {
            Cotizacion.Frm_Cotizacion2 coti = new Cotizacion.Frm_Cotizacion2();
            coti.MdiParent = this;
            coti.Show();
            Ocultar();
        }

        private void bt_VerMovimientoDeProductos_Click(object sender, EventArgs e)
        {
            Frm_Explo_Kardex krx = new Frm_Explo_Kardex();
            krx.MdiParent = this;
            krx.Show();
            Ocultar();
        }

        private void Bt_VerMovimientoDeCaja_Click(object sender, EventArgs e)
        {
            Frm_Explo_MovimientoCaja caj = new Frm_Explo_MovimientoCaja();
            caj.MdiParent = this;
            caj.Show();
            Ocultar();
        }

        private void bt_VerListadoDeClientes_Click(object sender, EventArgs e)
        {
            Frm_Explo_Cliente cli = new Frm_Explo_Cliente();
            cli.MdiParent = this;
            cli.Show();
            cli.txt_buscar.Focus();
            Ocultar();
        }

        private void Bt_VerCotizacionesEmitidas_Click(object sender, EventArgs e)
        {
            Cotizacion.Frm_Explo_Cotizacion coti = new Cotizacion.Frm_Explo_Cotizacion();
            coti.MdiParent = this;
            coti.Show();
            coti.txt_buscar.Focus();
            Ocultar();
        }

        private void Bt_VerCreditoDeClientes_Click(object sender, EventArgs e)
        {
            Ventas.Frm_Explo_Credito cre = new Frm_Explo_Credito();
            cre.MdiParent = this;
            cre.Show();
            cre.txt_buscar.Focus();
            Ocultar();
        }

        private void limpiarCotizacionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //eliminar cotizaciones permanente mente.
        }

        private void btn_normal_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            btn_normal.Visible = false;
            bt_Max.Visible = true;
        }

        private void bt_Max_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            bt_Max.Visible = false;
            btn_normal.Visible = true;
        }

        private void lbl_Rol_Click(object sender, EventArgs e)
        {

        }

        private void Bt_VerCierreDeCaja_Click(object sender, EventArgs e)
        {
            
        }

        private void Bt_MantenimientoCategoria_Click(object sender, EventArgs e)
        {
            Utilitarios.Frm_Categoria cat = new Utilitarios.Frm_Categoria();
            cat.MdiParent = this;
            cat.Show();
            Ocultar();
        }

        private void Bt_MantenimientoMarca_Click(object sender, EventArgs e)
        {
            Utilitarios.Frm_Marca mar = new Utilitarios.Frm_Marca();
            mar.MdiParent = this;
            mar.Show();
            Ocultar();
        }

        private void bt_EntradaDinero_Click(object sender, EventArgs e)
        {
            Frm_Reg_otroIngresos ing = new Frm_Reg_otroIngresos();
            ing.MdiParent = this;
            ing.Show();
            Ocultar();
        }

        private void bt_salidadinero_Click(object sender, EventArgs e)
        {
            Frm_Registrar_Gastos gas = new Frm_Registrar_Gastos();
            gas.MdiParent = this;
            gas.Show();
            Ocultar();
        }

        private void Bt_ConvertirVentaACredito_Click(object sender, EventArgs e)
        {
            Frm_NotaCredito gas = new Frm_NotaCredito();
            gas.MdiParent = this;
            gas.Show();
            Ocultar();
        }

        private void exploradorNotaCreditoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_Explorador_notaCreditos nc = new Frm_Explorador_notaCreditos();
            nc.MdiParent = this;
            nc.Show();
            Ocultar();
        }

        private void enviarNCToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_Send_NC_FC nc = new Frm_Send_NC_FC();
            nc.MdiParent = this;
            nc.Show();
            Ocultar();
        }

        private void enviarFEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_Send_FE nc = new frm_Send_FE();
            nc.MdiParent = this;
            nc.Show();
            Ocultar();
        }

        private void enviarBoletaElectronicaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_ResumenBoleta nc = new Frm_ResumenBoleta();
            nc.MdiParent = this;
            nc.Show();
            Ocultar();
        }

        private void enviarBajaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_DarBaja_FE nc = new Frm_DarBaja_FE();
            nc.MdiParent = this;
            nc.Show();
            Ocultar();
        }

        private void anularDocumentoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_Anular_FE nc = new Frm_Anular_FE();
            nc.MdiParent = this;
            nc.Show();
            Ocultar();
        }

       
        private void Bt_EditEmpresa_Click(object sender, EventArgs e)
        {
            MiEmpresa.Frm_EditEmpresa nc = new MiEmpresa.Frm_EditEmpresa();
            nc.MdiParent = this;
            nc.Show();
            Ocultar();
        }

        private void enviarGuiaDeRemesionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_GuiaRemision guia = new Frm_GuiaRemision();
            guia.MdiParent = this;
            guia.Show();
            Ocultar();
        }
    }
}
