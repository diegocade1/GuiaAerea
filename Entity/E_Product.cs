using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class E_Product
    {
        public int Num_Pieces { get; set; }
        public double Gross_Weight { get; set; }
        public string Kg_Lb { get; set; }
        public string Commodity_Item { get; set; }
        public double Chargable_Weight { get; set; }
        public double Rate_Charge { get; set; }
        public double Total { get; set; }
        public double Weight_Charge { get; set; }
        public double Valuation_Charge { get; set; }
        public double Tax { get; set; }
        public double Total_Other_Charges_Agent { get; set; }
        public double Total_Other_Charges_Carrier { get; set; }
        public double Total_Prepaid { get; set; }
        public double Total_Collect { get; set; }
        public double Currency_Conversion_Rate { get; set; }
        public double CC_Charges_Dest_Currency { get; set; }
        public double Charges_At_Destination { get; set; }
        public double Total_Collect_Charges { get; set; }

    }
}
