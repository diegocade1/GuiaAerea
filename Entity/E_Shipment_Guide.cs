using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class E_Shipment_Guide
    {
        public string Shipper { get; set; }
        public string Aerial_guide { get; set; }
        public string Consignee { get; set; }
        public string Carrier_Agent { get; set; }
        public string Accounting_info { get; set; }
        public string Departure_airport { get; set; }
        public string Requested_routing { get; set; }
        public string Optional_shipping_number { get; set; }
        public string Optional_shipping_info { get; set; }
        public string Code_first_carrier { get; set; }
        public string Code_second_carrier { get; set; }
        public string Airport_Destination_second_carrier { get; set; }
        public string Code_third_carrier { get; set; }
        public string Airport_Destination_third_carrier { get; set; }
        public string Currency { get; set; }
        public string Payment_methods { get; set; } //Prepaid(PP) or Collect(CC)
        public string Declared_value_carriage { get; set; }
        public string Declared_value_customs { get; set; }
        public string Destination_airport { get; set; }
        public string Requested_flight_num { get; set; }
        public string Requested_flight_date { get; set; }
        public string Amount_insurance { get; set; }
        public string Handling_information { get; set; }
        public string Elemento_ULD { get; set; }
        public string Nature_Quantity_Goods { get; set; }
        public string Num_Pieces { get; set; }
        public string Gross_weight { get; set; }
        public string Total { get; set; }
        public string Weight_charge { get; set; }
        public string Valuation_charge { get; set; }
        public string Tax { get; set; }
        public string Other_charges_due_agent { get; set; }
        public string Other_charges_due_carrier { get; set; }
        public string Total_prepaid { get; set; }
        public string Total_collect { get; set; }
        public string Currency_conversion_rate { get; set; }
        public string Collect_Charges_Dest_Currency { get; set; }
        public string Charges_at_destination { get; set; }
        public string Total_collect_charges { get; set; }
        public string Signature_shipper { get; set; }
        public string Executed_date { get; set; }
        public string At_Place { get; set; }
        public string Signature_issuing_carrier { get; set; }
    }
}
