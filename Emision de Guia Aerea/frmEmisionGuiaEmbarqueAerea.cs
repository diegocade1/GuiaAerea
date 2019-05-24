using Entity;
using Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Emision_de_Guia_Aerea
{
    public partial class frmEmisionGuiaEmbarqueAerea : Form
    {
        private double tempTotal { get; set; }
        public frmEmisionGuiaEmbarqueAerea()
        {
            InitializeComponent();
        }

        private void frmEmisionGuiaEmbarqueAerea_Load(object sender, EventArgs e)
        {
            dataGridViewDatos.Rows.Add();
            
            btnAgregarRow.Visible = false;
            btnBorrarRow.Visible = false;
            
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            N_PDF pdf = new N_PDF();

            E_Guide guide = new E_Guide();
            guide.Airline_Code = txtAirlineCode.Text;
            guide.Aerial_guide = txtGuide.Text;
            guide.ID_Guide_Type = "";

            E_Shipper shipper = new E_Shipper();
            shipper.Account_Number = txtExportadorNumeroCuenta.Text;
            shipper.Name = txtExportadorNombre.Text;
            shipper.Address = txtExportadorDireccion1.Text;
            shipper.Comuna = txtExportadorDireccion2.Text;
            shipper.Email = "";
            shipper.Telephone = txtExportadorTelefono.Text;

            E_Consignee consignee = new E_Consignee();
            consignee.Account_Number = "";
            consignee.Address = txtConsignatarioDireccion1.Text;
            consignee.Comuna = txtConsignatarioDireccion2.Text;
            consignee.Name = txtConsignatarioNombre.Text;
            consignee.Email = txtConsignatarioEmail.Text;
            consignee.Telephone = txtConsignatarioTelefono.Text;

            E_Accounting_Info accounting = new E_Accounting_Info();

            accounting.Address_1 = txtNotifyDireccion1.Text;
            accounting.Address_2 = txtNotifyDireccion2.Text;
            accounting.Email = txtNotifyEmail.Text;
            accounting.Name = txtNotifyNombre.Text;
            accounting.Telephone = txtNotifyTelefono.Text;

            E_Carrier_Agent agent = new E_Carrier_Agent();
            agent.Account_Number = "";
            agent.Address = txtAgenteDireccion.Text;
            agent.Comuna = txtAgenteComuna.Text;
            agent.Email = "";
            agent.IATA_Code = txtAgenteIATA.Text;
            agent.Name = txtAgenteNombre.Text;
            agent.Rut = txtAgenteRut.Text;
            agent.Telephone = "";

            E_Airport salida = new E_Airport();
            salida.Name = txtAeropuertoSalida.Text;
            salida.City = "";
            salida.Country = "";
            salida.Prefix = "";

            E_Airport destino = new E_Airport();
            destino.Name = txtAeropuertoDestino.Text;
            destino.City = "";
            destino.Country = "";
            destino.Prefix = "";

            string ruta_solicitada = txtRutaSolicitada.Text;

            string informacion_opcional_numero = txtInformacionOpcionalNumeroReferencia.Text;
            string informacion_opcional_text = txtInformacionOpcional.Text;

            E_Airline first = new E_Airline();
            first.Address = "";
            first.Code = "";
            first.Fax = "";
            first.Name = "";
            first.Prefix_airline = txtPrimerCarrier.Text;
            first.Rut = "";
            first.Telephone = "";

            E_Airline second = new E_Airline();
            second.Address = "";
            second.Code = "";
            second.Fax = "";
            second.Name = "";
            second.Prefix_airline = txtSegundoCarrier.Text;
            second.Rut = "";
            second.Telephone = "";

            E_Airline third = new E_Airline();
            third.Address = "";
            third.Code = "";
            third.Fax = "";
            third.Name = "";
            third.Prefix_airline = txtSegundoCarrier.Text;
            third.Rut = "";
            third.Telephone = "";

            string flight_number = txtNumeroVuelo.Text;
            string flight_date = dtpFechaVuelo.Value.ToString("yyyy-MM-dd");

            E_Currency currency = new E_Currency();
            currency.Clp_value = "";
            currency.Name = "";
            currency.Prefix = txtMonedaPrefijo.Text;

            string CHGS_code = cbCHGS.Text;
            string WRT_VAL = cbWRT_VAL.Text;
            string Otros = cbOtros.Text;
            string declared_value_carriage = txtValorDeclaradoTransporte.Text;
            string declare_value_custom = txtValorDeclaradoCustom.Text;
            string handling_info = txtInformacionManejo.Text;

            string producto = Productos();

            string nature = txtNature.Text;
            string InvoicePo = txtInvoicePO.Text;
            string exportacion = txtExportation.Text;

            string weight_charge = txtWeightCharge.Text;
            string valuation_charges = txtValuationCharge.Text;
            string tax = txtTax.Text;
            string total_other_charges_agent = txtTotalTOtherChargesAgent.Text;
            string total_other_charges_carrier = txtTotalTOtherChargesCarrier.Text;
            string total_prepaid = txtTotalPrepaid.Text;
            string total_collect = txtTotalCollect.Text;
            string currency_conversion_rate = txtCurrencyConversionRates.Text;
            string cc_charges_destiny = txtCCChargesDestCurrency.Text;
            string chargest_at_destination = txtChargesDestination.Text;
            string total_collect_charges = txtTotalCollectCharges.Text;

            string shipper_signature = txtSignatureShipper.Text;
            string executed_date = dtpExecutedDate.Value.ToString("yyyy-MM-dd");
            string at_place = txtAtPlace.Text;
            string signature_issuing_carrier_agent = txtSignatureIssuingCarrierAgent.Text;


            try
            {
                pdf.GenerarPDF();
                MessageBox.Show(pdf.FILENAME + " ha sido generado en: " + pdf.DIR);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private string Productos()
        {
            string temp = "";
            foreach(DataGridViewRow row in dataGridViewDatos.Rows)
            {
                temp= IsStringNullorEmpty(row.Cells[colNum_Pieces.Index].Value) + ";"+ IsStringNullorEmpty(row.Cells[colPesoBruto.Index].Value) + ";" + 
                    IsStringNullorEmpty(row.Cells[colKg_Lb.Index].Value) + ";" + IsStringNullorEmpty(row.Cells[colCommodityItemNum.Index].Value) + ";" + 
                    IsStringNullorEmpty(row.Cells[colPesoCobrable.Index].Value) + ";" + IsStringNullorEmpty(row.Cells[colPesoBruto.Index].Value) + ";" + 
                    IsStringNullorEmpty(row.Cells[colRate_Charge.Index].Value);
            }

            return temp;
        }

        private void DGVNumberTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Para obligar a que sólo se introduzcan números
            if (Char.IsDigit(e.KeyChar) || e.KeyChar == '.')
            {
                e.Handled = false;
            }
            else
              if (Char.IsControl(e.KeyChar)) //permitir teclas de control como retroceso
            {
                e.Handled = false;
            }
            else
            {
                //el resto de teclas pulsadas se desactivan
                e.Handled = true;
            }
        }

        private void DGVTextTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = false;
        }

        private void dataGridViewDatos_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if((e.ColumnIndex==colPesoBruto.Index && e.RowIndex !=-1) || (e.ColumnIndex== colRate_Charge.Index && e.RowIndex != -1))
            {
                string peso_bruto = IsStringNullorEmpty(dataGridViewDatos.Rows[e.RowIndex].Cells[colPesoBruto.Index].Value.ToString());
                dataGridViewDatos.Rows[e.RowIndex].Cells[colPesoCobrable.Index].Value = peso_bruto;
                string ratio_cargo = IsStringNullorEmpty(dataGridViewDatos.Rows[e.RowIndex].Cells[colRate_Charge.Index].Value);

                double gross_weight = TryParse(peso_bruto);
                double rate_charge = TryParse(ratio_cargo);

                double operation = gross_weight*rate_charge;
                double subtotal = TryParse(IsStringNullorEmpty(dataGridViewDatos.Rows[e.RowIndex].Cells[colTotal.Index].Value));
                if ( subtotal > 0)
                {
                    tempTotal -= TryParse(String.Format("{0:0.00}", subtotal));
                    dataGridViewDatos.Rows[e.RowIndex].Cells[colTotal.Index].Value = TryParse(String.Format("{0:0.00}",operation));
                }
                else
                {
                    dataGridViewDatos.Rows[e.RowIndex].Cells[colTotal.Index].Value = TryParse(String.Format("{0:0.00}", operation));
                }            
            }

            if(e.ColumnIndex == colTotal.Index && e.RowIndex != -1)
            {
                double subtotal = 0;
                foreach (DataGridViewRow row in dataGridViewDatos.Rows)
                {                   
                    subtotal += TryParse(IsStringNullorEmpty(row.Cells[colTotal.Index].Value));                                    
                }

                tempTotal = TryParse(String.Format("{0:0.00}", subtotal));
                txtWeightCharge.Text = tempTotal.ToString();
            }
        }

        private double TryParse(string value)
        {
            double result;
            return double.TryParse(String.Format("{0:0.00}", value.Replace(".", ",")), out result) ? result : 0.00;
        }

        private string IsStringNullorEmpty(object value)
        {
            if(value != null)
            {
                return value.ToString();
            }
            else
            {
                return "";
            }
        }

        private void dataGridViewDatos_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (dataGridViewDatos.CurrentCell.ColumnIndex == colNum_Pieces.Index)
            { 
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(DGVNumberTextBox_KeyPress);
                }
            }

            if (dataGridViewDatos.CurrentCell.ColumnIndex == colPesoBruto.Index)
            {
                TextBox tb2 = e.Control as TextBox;
                if (tb2 != null)
                {
                    tb2.KeyPress += new KeyPressEventHandler(DGVNumberTextBox_KeyPress);
                }
            }

            if (dataGridViewDatos.CurrentCell.ColumnIndex == colRate_Charge.Index)
            {
                TextBox tb3 = e.Control as TextBox;
                if (tb3 != null)
                {
                    tb3.KeyPress += new KeyPressEventHandler(DGVNumberTextBox_KeyPress);
                }
            }

            if (dataGridViewDatos.CurrentCell.ColumnIndex == colCommodityItemNum.Index)
            {
                TextBox tb3 = e.Control as TextBox;
                if (tb3 != null)
                {
                    tb3.KeyPress += new KeyPressEventHandler(DGVTextTextBox_KeyPress);
                }
            }
        }

        private void btnAgregarRow_Click(object sender, EventArgs e)
        {
            dataGridViewDatos.Rows.Add();
        }

        private void btnBorrarRow_Click(object sender, EventArgs e)
        {
            tempTotal -= TryParse(IsStringNullorEmpty(dataGridViewDatos.Rows[dataGridViewDatos.CurrentRow.Index].Cells[colTotal.Index].Value));
            txtWeightCharge.Text = tempTotal.ToString();
            dataGridViewDatos.Rows.Remove(dataGridViewDatos.CurrentRow);
        }
    }
}
