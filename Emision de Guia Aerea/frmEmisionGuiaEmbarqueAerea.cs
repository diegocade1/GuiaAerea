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
        private string route1 { get; set; }
        private static string guion = "-";
        private string route2 { get; set; }
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

            route1 = "";
            route2 = "";

            N_Shipper shipper1 = new N_Shipper();
            cbShipper.DataSource = shipper1.Lista();
            cbShipper.DisplayMember = "Name";
            cbShipper.ValueMember = "ID";
            cbShipper.SelectedIndex = -1;

            N_Consignee consignee1 = new N_Consignee();
            cbConsignee.DataSource = consignee1.Lista();
            cbConsignee.DisplayMember = "Name";
            cbConsignee.ValueMember = "ID";
            cbConsignee.SelectedIndex = -1;

            N_Accounting_Info accounting1 = new N_Accounting_Info();
            cbAccountingInfo.DataSource = accounting1.Lista();
            cbAccountingInfo.DisplayMember = "Name";
            cbAccountingInfo.ValueMember = "ID";
            cbAccountingInfo.SelectedIndex = -1;

            N_Carrier_Agent agent1 = new N_Carrier_Agent();
            cbCarrierAgent.DataSource = agent1.Lista();
            cbCarrierAgent.DisplayMember = "Name";
            cbCarrierAgent.ValueMember = "ID";
            cbCarrierAgent.SelectedIndex = -1;

            N_Airline airline1 = new N_Airline();
            cbAerolinea.DataSource = airline1.Lista();
            cbAerolinea.DisplayMember = "Name";
            cbAerolinea.ValueMember = "Code";
            cbAerolinea.SelectedIndex = -1;

            cbSegundoCarrier.DataSource = airline1.Lista();
            cbSegundoCarrier.DisplayMember = "Name";
            cbSegundoCarrier.ValueMember = "Code";
            cbSegundoCarrier.SelectedIndex = -1;

            cbTercerCarrier.DataSource = airline1.Lista();
            cbTercerCarrier.DisplayMember = "Name";
            cbTercerCarrier.ValueMember = "Code";
            cbTercerCarrier.SelectedIndex = -1;

            N_Airport airport1 = new N_Airport();
            cbAirportDeparture.DataSource = airport1.Lista();
            cbAirportDeparture.DisplayMember = "Name";
            cbAirportDeparture.ValueMember = "ID";
            cbAirportDeparture.SelectedIndex = -1;

            cbAirportDestination.DataSource = airport1.Lista();
            cbAirportDestination.DisplayMember = "Name";
            cbAirportDestination.ValueMember = "ID";
            cbAirportDestination.SelectedIndex = -1;

            cbSegundoCarrierDestino.DataSource = airport1.Lista();
            cbSegundoCarrierDestino.DisplayMember = "Name";
            cbSegundoCarrierDestino.ValueMember = "ID";
            cbSegundoCarrierDestino.SelectedIndex = -1;

            cbTercerCarrierDestino.DataSource = airport1.Lista();
            cbTercerCarrierDestino.DisplayMember = "Name";
            cbTercerCarrierDestino.ValueMember = "ID";
            cbTercerCarrierDestino.SelectedIndex = -1;

            N_Currency currency1 = new N_Currency();
            cbCurrency.DataSource = currency1.Lista();
            cbCurrency.DisplayMember = "Name";
            cbCurrency.ValueMember = "ID";
            cbCurrency.SelectedIndex = -1;

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            N_PDF pdf = new N_PDF();


            N_Guide guide1 = new N_Guide();
            E_Guide guide2 = guide1.ObtenerGuide(txtGuide.Text);
            if(guide2==null)
            {
                MessageBox.Show("Guia no encontrada");
                txtGuide.SelectAll();
                txtGuide.Focus();
                return;
            }

            N_Shipper shipper1 = new N_Shipper();
            E_Shipper shipper2 = shipper1.ObtenerShipper(cbShipper.SelectedValue.ToString());

            if (shipper2 == null)
            {
                MessageBox.Show("Exportador no encontrado");
                cbShipper.Focus();
                return;
            }

            N_Consignee consignee1 = new N_Consignee();
            E_Consignee consignee2 = consignee1.ObtenerConsignee(cbConsignee.SelectedValue.ToString());

            if (consignee2 == null)
            {
                MessageBox.Show("Consignatario no encontrada");
                cbConsignee.Focus();
                return;
            }

            N_Accounting_Info accounting1 = new N_Accounting_Info();
            E_Accounting_Info accounting2 = accounting1.ObtenerAccountingInfo(cbAccountingInfo.SelectedValue.ToString());

            if (accounting2 == null)
            {
                MessageBox.Show("Notify no encontrado");
                cbAccountingInfo.Focus();
                return;
            }

            N_Carrier_Agent agent1 = new N_Carrier_Agent();
            E_Carrier_Agent agent2 = agent1.ObtenerCarrierAgent(cbCarrierAgent.SelectedValue.ToString());

            if (agent2 == null)
            {
                MessageBox.Show("Agente no encontrado");
                cbCarrierAgent.Focus();
                return;
            }

            N_Airport salida1 = new N_Airport();
            E_Airport salida2 = salida1.ObtenerAirport(cbAirportDeparture.SelectedValue.ToString());

            if (salida2 == null)
            {
                MessageBox.Show("Aereopuerto de Salida no encontrado");
                cbAirportDeparture.Focus();
                return;
            }

            N_Airport destino1 = new N_Airport();
            E_Airport destino2 = destino1.ObtenerAirport(cbAirportDestination.SelectedValue.ToString());

            if (destino2 == null)
            {
                MessageBox.Show("Aereopuerto de Destino no encontrado");
                cbAirportDestination.Focus();
                return;
            }

            string ruta_solicitada = IsStringNullorEmpty(txtRutaSolicitada.Text);

            N_Airline first1 = new N_Airline();
            E_Airline first2 = first1.ObtenerAirline(cbAerolinea.SelectedValue.ToString());

            N_Airport segundocarrierdestino1 = new N_Airport();
            E_Airport segundocarrierdestino2 = new E_Airport();

            N_Airline second1 = new N_Airline();
            E_Airline second2 = new E_Airline();

            if(cbSegundoCarrier.SelectedIndex >-1)
            {
                second2 = second1.ObtenerAirline(cbSegundoCarrier.SelectedValue.ToString());
                segundocarrierdestino2 = segundocarrierdestino1.ObtenerAirport(cbSegundoCarrierDestino.SelectedValue.ToString());
            }
            else
            {
                second2.Address = "";
                second2.Code = "";
                second2.Fax = "";
                second2.Name = "";
                second2.Prefix_airline = "";
                second2.Rut = "";
                second2.Telephone = "";

                //segundocarrierdestino2.ID = 0;
                segundocarrierdestino2.City = "";
                segundocarrierdestino2.Country = "";
                segundocarrierdestino2.Name = "";
                segundocarrierdestino2.Prefix = "";
            }

            N_Airport tercercarrierdestino1 = new N_Airport();
            E_Airport tercercarrierdestino2 = new E_Airport();

            N_Airline third1 = new N_Airline();
            E_Airline third2 = new E_Airline();

            if (cbTercerCarrier.SelectedIndex > -1)
            {
                third2 = third1.ObtenerAirline(cbTercerCarrier.SelectedValue.ToString());
                tercercarrierdestino2 = tercercarrierdestino1.ObtenerAirport(cbTercerCarrierDestino.SelectedValue.ToString());
            }
            else
            {
                third2.Address = "";
                third2.Code = "";
                third2.Fax = "";
                third2.Name = "";
                third2.Prefix_airline = "";
                third2.Rut = "";
                third2.Telephone = "";

                tercercarrierdestino2.City = "";
                tercercarrierdestino2.Country = "";
                tercercarrierdestino2.Name = "";
                tercercarrierdestino2.Prefix = "";
            }

            string optional_number = IsStringNullorEmpty(txtInformacionOpcionalNumeroReferencia.Text);
            string optional_info = IsStringNullorEmpty(txtInformacionOpcional.Text);

            string flight_number = IsStringNullorEmpty(txtNumeroVuelo.Text);
            string flight_date = dtpFechaVuelo.Value.ToString("yyyy-MM-dd");
            string insurance = IsStringNullorEmpty(txtInsurance.Text);

            N_Currency currency1 = new N_Currency();
            E_Currency currency2 = currency1.ObtenerCurrency(cbCurrency.SelectedValue.ToString());

            string CHGS_code = IsStringNullorEmpty(cbCHGS.Text);
            string WT_VAL = IsStringNullorEmpty(cbWRT_VAL.Text);
            string Otros = IsStringNullorEmpty(cbOtros.Text);
            string declared_value_carriage = IsStringNullorEmpty(txtValorDeclaradoTransporte.Text);
            string declared_value_custom = IsStringNullorEmpty(txtValorDeclaradoCustom.Text);
            string handling_info = IsStringNullorEmpty(txtInformacionManejo.Text);

            N_ULD uld1 = new N_ULD();
            E_ULD uld2 = uld1.ObtenerULD(IsStringNullorEmpty(txtULD.Text));

            if (uld2 == null)
            {
                MessageBox.Show("Numero ULD no encontrado");
                txtULD.SelectAll();
                txtULD.Focus();
                return;
            }

            E_Product producto1 = new E_Product();
            producto1 = Producto();

            string nature = IsStringNullorEmpty(txtNature.Text);
            string InvoicePo = IsStringNullorEmpty(txtInvoice.Text)+"|"+ IsStringNullorEmpty(txtPO.Text);
            string exportacion = IsStringNullorEmpty(txtExportation.Text);

            producto1.Weight_Charge = TryParse(txtWeightCharge.Text);
            producto1.Valuation_Charge = TryParse(txtValuationCharge.Text);
            producto1.Tax = TryParse(txtTax.Text);
            producto1.Total_Other_Charges_Agent = TryParse(txtTotalTOtherChargesAgent.Text);
            producto1.Total_Other_Charges_Carrier = TryParse(txtTotalTOtherChargesCarrier.Text);
            producto1.Total_Prepaid = TryParse(txtTotalPrepaid.Text);
            producto1.Total_Collect = TryParse(txtTotalCollect.Text);
            producto1.Currency_Conversion_Rate = TryParse(txtCurrencyConversionRates.Text);
            producto1.CC_Charges_Dest_Currency = TryParse(txtCCChargesDestCurrency.Text);
            producto1.Charges_At_Destination = TryParse(txtChargesDestination.Text);
            producto1.Total_Collect_Charges = TryParse(txtTotalCollectCharges.Text);

            string shipper_signature = IsStringNullorEmpty(shipper2.Name);
            string executed_date = dtpExecutedDate.Value.ToString("yyyy-MM-dd");
            string at_place = IsStringNullorEmpty(txtAtPlace.Text);
            string signature_issuing_carrier_agent = agent2.Firma_Representante;

            E_Shipment_Guide shipment1 = new E_Shipment_Guide()
            {
                Accounting_info = accounting2.ID.ToString(),
                Aerial_guide = guide2.Aerial_guide,
                Amount_insurance = insurance,
                At_Place = at_place,
                Carrier_Agent = agent2.ID.ToString(),
                Charges_at_destination = producto1.Charges_At_Destination.ToString(),
                Code_first_carrier = first2.Code,
                Code_second_carrier = second2.Code,
                Airport_Destination_second_carrier = segundocarrierdestino2.ID.ToString(),
                Code_third_carrier = third2.Code,
                Airport_Destination_third_carrier = tercercarrierdestino2.ID.ToString(),
                Collect_Charges_Dest_Currency = producto1.CC_Charges_Dest_Currency.ToString(),
                Consignee = consignee2.ID,
                Currency = currency2.ID,
                Currency_conversion_rate = producto1.Currency_Conversion_Rate.ToString(),
                Declared_value_carriage = declared_value_carriage,
                Declared_value_customs = declared_value_custom,
                Departure_airport = salida2.ID.ToString(),
                Destination_airport = destino2.ID.ToString(),
                Elemento_ULD = uld2.ID.ToString(),
                Executed_date = executed_date,
                Gross_weight = producto1.Gross_Weight.ToString(),
                Handling_information = handling_info,
                Nature_Quantity_Goods = nature + "|" + InvoicePo + "|" + exportacion,
                Num_Pieces = producto1.Num_Pieces.ToString(),
                Optional_shipping_number = optional_number,
                Optional_shipping_info = optional_info,
                Other_charges_due_agent = producto1.Total_Other_Charges_Agent.ToString(),
                Other_charges_due_carrier = producto1.Total_Other_Charges_Carrier.ToString(),
                Payment_methods = CHGS_code,
                Requested_flight_date = flight_date,
                Requested_flight_num = flight_number,
                Requested_routing = ruta_solicitada,
                Shipper = shipper2.ID.ToString(),
                Signature_issuing_carrier = signature_issuing_carrier_agent,
                Signature_shipper = shipper_signature,
                Tax = producto1.Tax.ToString(),
                Total = producto1.Total.ToString(),
                Total_collect = producto1.Total_Collect.ToString(),
                Total_collect_charges = producto1.Total_Collect_Charges.ToString(),
                Total_prepaid = producto1.Total_Prepaid.ToString(),
                Valuation_charge = producto1.Valuation_Charge.ToString(),
                Weight_charge= producto1.Weight_Charge.ToString()
            };

            try
            {
                N_Shipment_Guide shipment2 = new N_Shipment_Guide();             
                if(shipment2.Agregar(shipment1))
                {
                    pdf.GenerarPDF(guide2,shipper2,consignee2,accounting2,agent2,salida2,destino2,ruta_solicitada,first2,second2,segundocarrierdestino2,third2,tercercarrierdestino2,optional_number,optional_info,
                        flight_number,flight_date,insurance,currency2,CHGS_code,WT_VAL,Otros,declared_value_carriage,declared_value_custom,handling_info,uld2,producto1,nature,InvoicePo,exportacion,
                        shipper_signature,executed_date,at_place,signature_issuing_carrier_agent);
                    MessageBox.Show("El archivo ha sido generado en: " + pdf.dir_final);
                }
                else
                {
                    MessageBox.Show(shipment2.Mensaje);
                }
                
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private E_Product Producto()
        {
            E_Product temp = new E_Product();
            foreach(DataGridViewRow row in dataGridViewDatos.Rows)
            {
                temp.Num_Pieces = Convert.ToInt32(IsStringNullorEmpty(row.Cells[colNum_Pieces.Index].Value));
                temp.Gross_Weight = TryParse(IsStringNullorEmpty(row.Cells[colPesoBruto.Index].Value));
                temp.Kg_Lb = IsStringNullorEmpty(row.Cells[colKg_Lb.Index].Value);
                temp.Commodity_Item = IsStringNullorEmpty(row.Cells[colCommodityItemNum.Index].Value);
                temp.Chargable_Weight = TryParse(IsStringNullorEmpty(row.Cells[colPesoCobrable.Index].Value));
                temp.Rate_Charge = TryParse(IsStringNullorEmpty(row.Cells[colPesoBruto.Index].Value)); 
                temp.Total = TryParse(IsStringNullorEmpty(row.Cells[colRate_Charge.Index].Value));
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

        private void cbAirportDeparture_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cbAirportDeparture.SelectedIndex != -1)
            {
                N_Airport airport1 = new N_Airport();
                route1 = airport1.ObtenerAirport(cbAirportDeparture.SelectedValue.ToString()).Prefix;
                txtRutaSolicitada.Text = route1 + " " + guion + " " + route2;
            }
        }

        private void cbAirportDestination_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cbAirportDestination.SelectedIndex != -1)
            {
                N_Airport airport1 = new N_Airport();
                route2 = airport1.ObtenerAirport(cbAirportDestination.SelectedValue.ToString()).Prefix;
                txtRutaSolicitada.Text = route1 + " " + guion + " " + route2;
            }
        }

        private void cbAerolinea_SelectionChangeCommitted(object sender, EventArgs e)
        {
            txtPrimerCarrier.Text = cbAerolinea.Text;
        }
    }
}
