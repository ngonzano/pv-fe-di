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

namespace Microsell_Lite.Caja
{
    public partial class Frm_CerrarCaja : Form
    {
        public Frm_CerrarCaja()
        {
            InitializeComponent();
        }

        private void Pnl_Titulo_MouseMove(object sender, MouseEventArgs e)
        {
            Utilitario ui = new Utilitario();
            if (e.Button == MouseButtons.Left)
            {
                ui.Mover_formulario(this);
            }
        }
        private void btn_cerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btn_minimi_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private void Frm_CerrarCaja_Load(object sender, EventArgs e)
        {
            BuscarDatosCajaDIA();
        }
        Principal.Frm_Filtro fil = new Principal.Frm_Filtro();
        Utilitarios.Frm_Advertencia adv = new Utilitarios.Frm_Advertencia();
        void ListarCajaDelDia()
        {
            DataTable dt = new DataTable();
            RN_CierreCaja n_cie = new RN_CierreCaja();

            try
            {
                dt = n_cie.RN_Mostrar_CierreCaja_Dia();
                if (dt.Rows.Count > 0)
                {
                    lbl_idcaja.Text = dt.Rows[0]["Id_cierre"].ToString();
                    Lbl_aperturaCaja.Text = dt.Rows[0]["Apertura_Caja"].ToString();
                    Lbl_estado.Text = dt.Rows[0]["Estado_cierre"].ToString();
                    Lbl_fechaCaja.Text = dt.Rows[0]["Fecha_Cierre"].ToString();

                    if (Lbl_estado.Text == "Cerrado")
                    {
                        btn_aceptar.Enabled = false;
                    }
                    else
                    {
                        btn_aceptar.Enabled = true;
                    }
                }
                else
                {
                    fil.Show();
                    adv.lbl_msm.Text = "No inicio la apertura de caja para acceder al cierre.";
                    adv.ShowDialog();
                    fil.Hide();
                    btn_aceptar.Enabled = false;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Error: " + e.Message, "Cerrar Caja", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        void BuscarCajaBoleta_Dia()
        {
            RN_CierreCaja n_cie = new RN_CierreCaja();
            DataTable dt = new DataTable();

            double subImport = 0;

            dt = n_cie.RN_Ventas_TipoDocumento_Dia("Boleta", "Efectivo");
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow dr = dt.Rows[i];
                    subImport = subImport + Convert.ToDouble(dr["ImporteCaja"]);
                }
                Lbl_Efectivo_boleta.Text = subImport.ToString("###0.00");
            }
            else
            {
                Lbl_Efectivo_boleta.Text = "0.00";
            }
        }
        void BuscarCajaFactura_Dia()
        {
            RN_CierreCaja n_cie = new RN_CierreCaja();
            DataTable dt = new DataTable();

            double subImport = 0;
            dt = n_cie.RN_Ventas_TipoDocumento_Dia("Factura", "Efectivo");
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow dr = dt.Rows[i];
                    subImport = subImport + Convert.ToDouble(dr["ImporteCaja"]);
                }
                Lbl_Efectivo_factura.Text = subImport.ToString("###0.00");
            }
            else
            {
                Lbl_Efectivo_factura.Text = "0.00";
            }
        }
        void BuscarCajaNotaCredito_Dia()
        {
            RN_CierreCaja n_cie = new RN_CierreCaja();
            DataTable dt = new DataTable();

            double subImport = 0;
            dt = n_cie.RN_Ventas_TipoDocumento_Dia("Nota Venta", "Efectivo");
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow dr = dt.Rows[i];
                    subImport = subImport + Convert.ToDouble(dr["ImporteCaja"]);
                }
                Lbl_Efectivo_Notas.Text = subImport.ToString("###0.00");
            }
            else
            {
                Lbl_Efectivo_Notas.Text = "0.00";
            }
        }
        void BuscarCajaOtros_Dia()
        {
            RN_CierreCaja n_cie = new RN_CierreCaja();
            DataTable dt = new DataTable();

            double subImport = 0;
            dt = n_cie.RN_Ventas_TipoDocumento_Dia("Otros Ingresos", "Efectivo");
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow dr = dt.Rows[i];
                    subImport = subImport + Convert.ToDouble(dr["ImporteCaja"]);
                }
                Lbl_otroIngresoEfectivo.Text = subImport.ToString("###0.00");
            }
            else
            {
                Lbl_otroIngresoEfectivo.Text = "0.00";
            }
        }
        void BuscarCajaAbono_Dia()
        {
            RN_CierreCaja n_cie = new RN_CierreCaja();
            DataTable dt = new DataTable();

            double subImport = 0;
            dt = n_cie.RN_Ventas_TipoDocumento_Dia("Abono", "Efectivo");
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow dr = dt.Rows[i];
                    subImport = subImport + Convert.ToDouble(dr["ImporteCaja"]);
                }
                Lbl_CreditoAbonado.Text = subImport.ToString("###0.00");
            }
            else
            {
                Lbl_CreditoAbonado.Text = "0.00";
            }
        }
        void BuscarCajaDeposito_Dia()
        {
            RN_CierreCaja n_cie = new RN_CierreCaja();
            DataTable dt = new DataTable();

            double subImport = 0;
            dt = n_cie.RN_Venta_Deposito_Dia();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow dr = dt.Rows[i];
                    subImport = subImport + Convert.ToDouble(dr["ImporteCaja"]);
                }
                Lbl_Ingreso_Deposito.Text = subImport.ToString("###0.00");
            }
            else
            {
                Lbl_Ingreso_Deposito.Text = "0.00";
            }
        }
        void BuscarCajaCredit_Dia()
        {
            RN_CierreCaja n_cie = new RN_CierreCaja();
            DataTable dt = new DataTable();

            double subImport = 0;
            dt = n_cie.RN_Venta_Credito_Dia();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow dr = dt.Rows[i];
                    subImport = subImport + Convert.ToDouble(dr["ImporteCaja"]);
                }
                Lbl_TotalCreditos.Text = subImport.ToString("###0.00");
            }
            else
            {
                Lbl_TotalCreditos.Text = "0.00";
            }
        }
        void BuscarUtilidad_Dia()
        {
            RN_CierreCaja n_cie = new RN_CierreCaja();
            DataTable dt = new DataTable();

            double subImport = 0;
            dt = n_cie.RN_Venta_Utilidades_dia();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow dr = dt.Rows[i];
                    subImport = subImport + Convert.ToDouble(dr["TotalUti"]);
                }
                Lbl_UtilidadTotal.Text = subImport.ToString("###0.00");
            }
            else
            {
                Lbl_UtilidadTotal.Text = "0.00";
            }
        }
        //RN_Gastos_TipoPago_Dia
        void BuscarGastosDiaDeposito()
        {
            RN_CierreCaja n_cie = new RN_CierreCaja();
            DataTable dt = new DataTable();

            double subImport = 0;
            dt = n_cie.RN_Gastos_TipoPago_Dia("Deposito");
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow dr = dt.Rows[i];
                    subImport = subImport + Convert.ToDouble(dr["ImporteCaja"]);
                }
                lbl_SalienDeposi.Text = subImport.ToString("###0.00");
            }
            else
            {
                lbl_SalienDeposi.Text = "0.00";
            }
        }
        void BuscarGastosDiaEfectivo()
        {
            RN_CierreCaja n_cie = new RN_CierreCaja();
            DataTable dt = new DataTable();

            double subImport = 0;
            dt = n_cie.RN_Gastos_TipoPago_Dia("Efectivo");
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow dr = dt.Rows[i];
                    subImport = subImport + Convert.ToDouble(dr["ImporteCaja"]);
                }
                Lbl_SalidaEfectivo.Text = subImport.ToString("###0.00");
            }
            else
            {
                Lbl_SalidaEfectivo.Text = "0.00";
            }
        }
        void BuscarCajaVale_Dia()//Falta Implentar vales
        {
            RN_CierreCaja n_cie = new RN_CierreCaja();
            DataTable dt = new DataTable();

            double subImport = 0;
            dt = n_cie.RN_Venta_Credito_Dia();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow dr = dt.Rows[i];
                    subImport = subImport + Convert.ToDouble(dr["ImporteCaja"]);
                }
                lbl_IngresoValeTotal_Pas.Text = subImport.ToString("###0.00");
            }
            else
            {
                lbl_IngresoValeTotal_Pas.Text = "0.00";
            }
        }
        void BuscarDatosCajaDIA()
        {
            BuscarGastosDiaEfectivo();
            BuscarGastosDiaDeposito();
            ListarCajaDelDia();
            BuscarCajaBoleta_Dia();
            BuscarCajaFactura_Dia();
            BuscarCajaNotaCredito_Dia();
            BuscarCajaOtros_Dia();
            BuscarCajaAbono_Dia();
            BuscarCajaDeposito_Dia();
            BuscarCajaCredit_Dia();
            BuscarCajaVale_Dia();
            BuscarUtilidad_Dia();
        }
        private void Btn_calcular_Click(object sender, EventArgs e)
        {
            Calcular();
        }
        void Calcular()
        {
            double xxtotalIngreso = 0;
            double xxtotalegreso = 0;
            double IngresoBruto = 0;
            double ventaTotalNeto = 0;

            try
            {
                double efectivo_boleta = Convert.ToDouble(Lbl_Efectivo_boleta.Text);
                double efectivo_factura = Convert.ToDouble(Lbl_Efectivo_factura.Text);
                double efectivo_Notas = Convert.ToDouble(Lbl_Efectivo_Notas.Text);
                double otroIngresoEfectivo = Convert.ToDouble(Lbl_otroIngresoEfectivo.Text);
                double ingresoDeposito = Convert.ToDouble(Lbl_Ingreso_Deposito.Text);
                double ing_AperturaCaja = Convert.ToDouble(Lbl_aperturaCaja.Text);
                double egreso_Efectivo = Convert.ToDouble(Lbl_SalidaEfectivo.Text);
                double egreso_deposito = Convert.ToDouble(lbl_SalienDeposi.Text);

                //total ingreso bruto
                IngresoBruto = efectivo_boleta + efectivo_factura + efectivo_Notas + otroIngresoEfectivo; //+ingresoDeposito
                Lbl_totalIngreso.Text = IngresoBruto.ToString("###0.00");

                xxtotalIngreso = IngresoBruto + ing_AperturaCaja + ingresoDeposito;
                lbl_totalingre_bruto.Text = xxtotalIngreso.ToString("###0.00");

                //Salidas
                double SalidaEfectivo = Convert.ToDouble(Lbl_SalidaEfectivo.Text);
                double SalidaDeposito = Convert.ToDouble(lbl_SalienDeposi.Text);
                double totalSalida = Convert.ToDouble(Lbl_Total_Salida.Text);

                xxtotalegreso = SalidaEfectivo;
                totalSalida = xxtotalegreso + SalidaDeposito;
                lbl_xTotalEgreso.Text = (xxtotalegreso + SalidaDeposito).ToString("###0.00");
                Lbl_Total_Salida.Text = lbl_xTotalEgreso.Text;
                //neto
                ventaTotalNeto = xxtotalIngreso - totalSalida;
                lbl_IngresoEfectivo_Neto.Text = ventaTotalNeto.ToString("###0.00"); ;

            }
            catch (Exception)
            {

                throw;
            }
        }
        private void txt_totalEntregar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                double saldoNext;
                saldoNext = Convert.ToDouble(lbl_IngresoEfectivo_Neto.Text) - Convert.ToDouble(txt_totalEntregar.Text);
                txt_SaldoNext.Text = saldoNext.ToString("###0.00");
            }
        }
        private void btn_aceptar_Click(object sender, EventArgs e)
        {
            GuardarCierreCaja();
        }
        void GuardarCierreCaja()
        {
            RN_CierreCaja n_cie = new RN_CierreCaja();
            EN_CierreCaja e_cli = new EN_CierreCaja();
            int rpt;
            try
            {
                e_cli.IdCierre = lbl_idcaja.Text;
                e_cli.Apertura_Caja = Convert.ToDouble(Lbl_aperturaCaja.Text);
                e_cli.Total_Ingreso = Convert.ToDouble(Lbl_totalIngreso.Text);
                e_cli.TotalEgreso = Convert.ToDouble(lbl_xTotalEgreso.Text);
                e_cli.Id_usu = Cls_UsuLogin.IdUsu;
                e_cli.TodoDeposito = Convert.ToDouble(Lbl_Ingreso_Deposito.Text);
                e_cli.TotalGanancia = Convert.ToDouble(Lbl_UtilidadTotal.Text);
                e_cli.TotalEntregado = Convert.ToDouble(lbl_xTotalEgreso.Text);
                e_cli.SaldoSiguiente = Convert.ToDouble(txt_SaldoNext.Text);
                e_cli.TotalFactura = Convert.ToDouble(Lbl_Efectivo_factura.Text);
                e_cli.TotalBoleta = Convert.ToDouble(Lbl_Efectivo_boleta.Text);
                e_cli.Totalnota = Convert.ToDouble(Lbl_Efectivo_Notas.Text);
                e_cli.TotalCreditoCobrado = Convert.ToDouble(Lbl_CreditoAbonado.Text);
                e_cli.TotalCreditoEmitido = Convert.ToDouble(Lbl_TotalCreditos.Text);

                rpt = n_cie.RN_Registrar_Fin_CierreCaja(e_cli);
                if (rpt == 1)
                {
                    fil.Show();
                    adv.lbl_msm.Text = "Cierre de caja de: " + e_cli.Id_usu.ToUpper() + " se Cerro satisfactoriamente.";
                    adv.ShowDialog();
                    fil.Hide();
                }
                this.Close();//validar
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
