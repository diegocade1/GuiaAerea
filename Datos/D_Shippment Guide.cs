using Entity;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
   public class D_Shippment_Guide : D_MySQL
    {
        public string Mensaje { get; set; }
        public bool Agregar(E_Shipment_Guide guide)
        {
            string query;
            MySqlCommand cmd;

            query = "insert into tbl_shipment_guide_prueba" +
                    "(" +
                    "aerial_guide,id_shipper,id_consignee,id_carrier_agent,id_accounting_info,id_departure_airport,requested_routing,optional_shipping_info,code_first_carrier,code_second_carrier,"+
                    "code_third_carrier,id_currency,payment_methods,declared_value_carriage,declared_value_customs,id_destination_airport,requested_flight_num,requested_flight_date,amount_insurance,"+
                    "handling_info,id_ULD,nature_quantity_goods,number_pieces,gross_weight,weight_charge,valuation_charge,tax,other_charges_due_agent,other_charges_due_carrier,total_prepaid,total_collect,"+
                    "currency_conversion_rate,collect_charges_dest_currency,charges_at_destination,total_collect_charges,signature_shipper,executed_date,at_place,signature_issuing_carrier" +
                    ")" +
                    "@aerial_guide,@id_shipper,@id_consignee,@id_carrier_agent,@id_accounting_info,@id_departure_airport,@requested_routing,@optional_shipping_info,@code_first_carrier,@code_second_carrier," +
                    "@code_third_carrier,@id_currency,@payment_methods,@declared_value_carriage,@declared_value_customs,@id_destination_airport,@requested_flight_num,@requested_flight_date,@amount_insurance," +
                    "@handling_info,@id_ULD,@nature_quantity_goods,@number_pieces,@gross_weight,@weight_charge,@valuation_charge,@tax,@other_charges_due_agent,@other_charges_due_carrier,@total_prepaid,@total_collect," +
                    "@currency_conversion_rate,@collect_charges_dest_currency,@charges_at_destination,@total_collect_charges,@signature_shipper,@executed_date,@at_place,@signature_issuing_carrier" +
                    ")";
            try
            {
                if (Conectar() == true)
                {
                    cmd = new MySqlCommand(query, MySQLConexion);
                    //Primera Linea
                    cmd.Parameters.AddWithValue("@aerial_guide", guide.Aerial_guide);
                    cmd.Parameters.AddWithValue("@id_shipper", guide.Shipper);
                    cmd.Parameters.AddWithValue("@id_consignee", guide.Consignee);
                    cmd.Parameters.AddWithValue("@id_carrier_agent", guide.Carrier_Agent);
                    cmd.Parameters.AddWithValue("@id_accounting_info", guide.Accounting_info);
                    cmd.Parameters.AddWithValue("@id_departure_airport", guide.Departure_airport);
                    cmd.Parameters.AddWithValue("@requested_routing", guide.Requested_routing);
                    cmd.Parameters.AddWithValue("@optional_shipping_info", guide.Optional_shipping_info);
                    cmd.Parameters.AddWithValue("@code_first_carrier", guide.Code_first_carrier);
                    cmd.Parameters.AddWithValue("@code_second_carrier", guide.Code_second_carrier);
                    //Segunda Linea
                    cmd.Parameters.AddWithValue("@code_third_carrier", guide.Code_third_carrier);
                    cmd.Parameters.AddWithValue("@id_currency", guide.Currency);
                    cmd.Parameters.AddWithValue("@payment_methods", guide.Payment_methods);
                    cmd.Parameters.AddWithValue("@declared_value_carriage", guide.Declared_value_carriage);
                    cmd.Parameters.AddWithValue("@declared_value_customs", guide.Declared_value_customs);
                    cmd.Parameters.AddWithValue("@id_destination_airport", guide.Destination_airport);
                    cmd.Parameters.AddWithValue("@requested_flight_num", guide.Requested_flight_num);
                    cmd.Parameters.AddWithValue("@requested_flight_date", guide.Requested_flight_date);
                    cmd.Parameters.AddWithValue("@amount_insurance", guide.Amount_insurance);
                    //Tercera Linea
                    cmd.Parameters.AddWithValue("@handling_info", guide.Handling_information);
                    cmd.Parameters.AddWithValue("@id_ULD", guide.Elemento_ULD);
                    cmd.Parameters.AddWithValue("@nature_quantity_goods", guide.Nature_Quantity_Goods);
                    cmd.Parameters.AddWithValue("@number_pieces", guide.Num_Pieces);
                    cmd.Parameters.AddWithValue("@gross_weight", guide.Gross_weight);
                    cmd.Parameters.AddWithValue("@weight_charge", guide.Weight_charge);
                    cmd.Parameters.AddWithValue("@valuation_charge", guide.Valuation_charge);
                    cmd.Parameters.AddWithValue("@tax", guide.Tax);
                    cmd.Parameters.AddWithValue("@other_charges_due_agent", guide.Other_charges_due_agent);
                    cmd.Parameters.AddWithValue("@other_charges_due_carrier", guide.Other_charges_due_carrier);
                    cmd.Parameters.AddWithValue("@total_prepaid", guide.Total_prepaid);
                    cmd.Parameters.AddWithValue("@total_collect", guide.Total_collect);
                    //Cuarta Linea
                    cmd.Parameters.AddWithValue("@currency_conversion_rate", guide.Currency_conversion_rate);
                    cmd.Parameters.AddWithValue("@collect_charges_dest_currency", guide.Collect_Charges_Dest_Currency);
                    cmd.Parameters.AddWithValue("@charges_at_destination", guide.Charges_at_destination);
                    cmd.Parameters.AddWithValue("@total_collect_charges", guide.Total_collect_charges);
                    cmd.Parameters.AddWithValue("@signature_shipper", guide.Signature_shipper);
                    cmd.Parameters.AddWithValue("@executed_date", guide.Executed_date);
                    cmd.Parameters.AddWithValue("@at_place", guide.At_Place);
                    cmd.Parameters.AddWithValue("@signature_issuing_carrier", guide.Signature_issuing_carrier);

                    cmd.ExecuteNonQuery();
                    Desconectar();
                    return true;
                }
                else
                {
                    Mensaje = "Error en Conexion";
                    return false;
                }
            }
            catch (Exception ex)
            {
                Mensaje = ex.Message;
                Desconectar();
                return false;
            }
        }
    }
}
