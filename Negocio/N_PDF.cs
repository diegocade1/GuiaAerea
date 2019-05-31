using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.collection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ionic.Zip;
using Entity;

namespace Negocio
{
    public class N_PDF
    {
        /** The filename of the PDF */
        private string DIR = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) ;
        private string FILENAME = "AWB";
        private string FILE_EXTENSION = ".pdf";

        public string dir_final { get; set; }

        public void GenerarPDF(E_Guide guide2, E_Shipper shipper2, E_Consignee consignee2, E_Accounting_Info accounting2, E_Carrier_Agent agent2, E_Airport salida2,
            E_Airport destino2, string ruta_solicitada, E_Airline first2, E_Airline second2, E_Airport segundocarrierdestino2, E_Airline third2, E_Airport tercercarrierdestino2,
            string optional_number, string optional_info, string flight_number, string flight_date, string insurance, E_Currency currency2, string CHGS_code, string WT_VAL, string Otros, string declared_value_carriage,
            string declared_value_custom, string handling_info, E_ULD uld2, E_Product producto1, string nature, string InvoicePo, string exportacion, string shipper_signature, string executed_date, string at_place,
            string signature_issuing_carrier_agent)
        {
            string path = DIR + Path.DirectorySeparatorChar + FILENAME + guide2.Aerial_guide + FILE_EXTENSION;
            dir_final = path;
            byte[] bytesarray = null;
            string RESOURCE = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName, "Resources");
            using (var stream = new MemoryStream())
            {
                
                // step 1
                using (Document document = new Document(PageSize.A4, 30, 30, 30, 30))
                {
                    // step 2
                    using (PdfWriter writer = PdfWriter.GetInstance(document, stream))
                    {
                        // step 3
                        document.Open();
                        // step 4
                        // Pie
                        string[] pie = new string[] { "Original 2 (For Consignee)","Copy 4 (Delivery Receipt)","Original 3 (For Shipper)","Copy 9 (For Agent)","Copy 10 (Extra Copy For Carrier)",
                        "Copy 11 (Extra Copy For Carrier)","Original 1 (For Issuing Carrier)", "Copy 8 (For First Carrier)", "Copy 7 (For Second Carrier)", "Copy 6 (For Third Carrier)",
                        "Copy 5 (For Airport of Destination)"};

                        //1ra Imagen
                        Image img = Image.GetInstance(Path.Combine(
                          RESOURCE, "airwaybill.jpg"
                        ));

                        img.ScaleAbsolute(PageSize.A4.Width - 40, PageSize.A4.Height - 40);
                        img.Alignment = Element.ALIGN_CENTER;
                        img.SetAbsolutePosition(30f, 65f);
                        img.RotationDegrees=0.1f;
                        
                        // Para añadir text encima de la imagen
                        PdfContentByte over = writer.DirectContent;
                        
                        // 2da Imagen
                        
                        Image img2 = Image.GetInstance(Path.Combine(  
                            RESOURCE, "pagina 2.png"
                            ));
                        img2.ScaleAbsolute(PageSize.A4.Width - 10, PageSize.A4.Height - 30);
                        img2.Alignment = Element.ALIGN_CENTER;
                        
                        // Paginas
                        for(int index = 0; index<pie.Length;index++)
                        {
                            if(index>0)
                            {
                                document.NewPage();
                            }
                            document.Add(img);
                            Text(over,pie[index],guide2,shipper2,consignee2,
                                accounting2,agent2,salida2,destino2,ruta_solicitada,first2,second2,segundocarrierdestino2,
                                third2,tercercarrierdestino2,optional_number,optional_info,flight_number,flight_date,insurance,currency2,CHGS_code,WT_VAL,Otros,declared_value_carriage,
                                declared_value_custom,handling_info,uld2,producto1,nature,InvoicePo,exportacion,shipper_signature,executed_date,at_place,signature_issuing_carrier_agent);
                            document.NewPage();
                            document.Add(img2);
                        }

                        document.Close();
                    }
                    bytesarray = stream.ToArray();
                    stream.Close();

                    using (FileStream fs = File.Create(path))
                    {
                        fs.Write(bytesarray, 0, (int)bytesarray.Length);
                    }
                }
            }           
        }

        private void Text(PdfContentByte writer, string pie, E_Guide guide2, E_Shipper shipper2, E_Consignee consignee2, E_Accounting_Info accounting2, E_Carrier_Agent agent2, E_Airport salida2,
            E_Airport destino2, string ruta_solicitada, E_Airline first2, E_Airline second2, E_Airport segundocarrierdestino2, E_Airline third2, E_Airport tercercarrierdestino2,
            string optional_number, string optional_info, string flight_number, string flight_date, string insurance, E_Currency currency2, string CHGS_code, string WT_VAL, string Otros, string declared_value_carriage,
            string declared_value_custom, string handling_info, E_ULD uld2, E_Product producto1, string nature, string InvoicePo, string exportacion, string shipper_signature, string executed_date, string at_place,
            string signature_issuing_carrier_agent)
        {

            //Font
            BaseFont bf = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            //
            PdfContentByte over = writer;
            over.SaveState();

            over.BeginText();
            over.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);
            over.SetLineWidth(1f);
            over.SetRGBColorStroke(4, 28, 163);
            over.SetRGBColorFill(4, 28, 163);
            over.SetFontAndSize(bf, 10);

            float Y = 0;

            #region Linea 1
            Y = 820f;
            over.ShowTextAligned(PdfContentByte.ALIGN_LEFT, first2.Code.ToUpper(), 59f, Y, 0f);
            over.ShowTextAligned(PdfContentByte.ALIGN_LEFT, salida2.Prefix.ToUpper(), 82f, Y, 0f);
            over.ShowTextAligned(PdfContentByte.ALIGN_LEFT, guide2.Aerial_guide.ToUpper(), 109f, Y, 0f);
            over.ShowTextAligned(PdfContentByte.ALIGN_LEFT, first2.Code.ToUpper() + "-" + guide2.Aerial_guide.ToUpper(), 470f, Y, 0f);
            #endregion
            #region Linea 2 Shipper
            Y = Y - 24f;
            over.ShowTextAligned(PdfContentByte.ALIGN_LEFT, shipper2.Account_Number.ToUpper(), 198f, Y, 0f);
            over.ShowTextAligned(PdfContentByte.ALIGN_LEFT, first2.Prefix_airline.ToUpper(), 381f, Y, 0f);
            #endregion
            #region Linea 3
            Y = Y - 20f;
            over.ShowTextAligned(PdfContentByte.ALIGN_LEFT, shipper2.Name.ToUpper(), 59f, Y, 0f);
            #endregion
            #region Linea 4
            Y = Y - 11f;
            over.ShowTextAligned(PdfContentByte.ALIGN_LEFT, shipper2.Address.ToUpper(), 59f, Y, 0f);
            #endregion
            #region Linea 5
            Y = Y - 11f;
            over.ShowTextAligned(PdfContentByte.ALIGN_LEFT, shipper2.Comuna.ToUpper() + "  PH:" + shipper2.Telephone.ToUpper(), 59f, Y, 0f);
            #endregion
            #region Linea 6 Consignee
            Y = Y - 28f;
            over.ShowTextAligned(PdfContentByte.ALIGN_LEFT, consignee2.Name.ToUpper(), 59f, Y, 0f);
            over.ShowTextAligned(PdfContentByte.ALIGN_LEFT, consignee2.Account_Number.ToUpper(), 198f, Y, 0f);
            #endregion
            #region Linea 7
            Y = Y - 13f;
            over.ShowTextAligned(PdfContentByte.ALIGN_LEFT, consignee2.Address.Split(',')[0].ToUpper(), 59f, Y, 0f);
            #endregion
            #region Linea 8
            Y = Y - 11f;
            over.ShowTextAligned(PdfContentByte.ALIGN_LEFT, consignee2.Address.Split(',')[1].ToUpper(), 59f, Y, 0f);
            #endregion
            #region Linea 9
            Y = Y - 11f;
            over.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "EMAIL:" + consignee2.Email.ToUpper(), 59f, Y, 0f);
            #endregion
            #region Linea 10
            Y = Y - 11f;
            over.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "PH:" + consignee2.Telephone.ToUpper(), 59f, Y, 0f);
            #endregion 
            #region Linea 11 Carrier Agent &  Accounting Info
            Y = Y - 26f;
            over.ShowTextAligned(PdfContentByte.ALIGN_LEFT, agent2.Name.ToUpper() + " * RUT. " + agent2.Rut.ToUpper(), 59f, Y, 0f);

            //

            over.ShowTextAligned(PdfContentByte.ALIGN_LEFT, accounting2.Name.ToUpper() + "//", 311f, Y, 0f);
            #endregion
            #region Linea 12
            Y = Y - 11f;
            over.ShowTextAligned(PdfContentByte.ALIGN_LEFT, agent2.Address.ToUpper(), 59f, Y, 0f);

            //

            over.ShowTextAligned(PdfContentByte.ALIGN_LEFT, accounting2.Address_1.ToUpper(), 311f, Y, 0f);
            #endregion
            #region Linea 13
            Y = Y - 11f;
            over.ShowTextAligned(PdfContentByte.ALIGN_LEFT, agent2.Comuna.ToUpper(), 59f, Y, 0f);

            //

            over.ShowTextAligned(PdfContentByte.ALIGN_LEFT, accounting2.Address_2.ToUpper(), 311f, Y, 0f);
            #endregion
            #region Linea 14
            Y = Y - 11f;
            over.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "EMAIL:" + accounting2.Email.ToUpper(), 311f, Y, 0f);
            #endregion
            #region Linea 15
            Y = Y - 11f;
            over.ShowTextAligned(PdfContentByte.ALIGN_LEFT, agent2.IATA_Code.ToUpper(), 59f, Y, 0f);
            over.ShowTextAligned(PdfContentByte.ALIGN_LEFT, agent2.Account_Number.ToUpper(), 198f, Y, 0f);

            //

            over.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "PH: " + accounting2.Telephone.ToUpper(), 311f, Y, 0f);
            #endregion
            #region Linea 16 Departure Airport & Optional Shipping Information
            Y = Y - 25f;
            over.ShowTextAligned(PdfContentByte.ALIGN_LEFT, salida2.City.ToUpper() + "      " + ruta_solicitada.ToUpper(), 59f, Y, 0f);

            //

            over.ShowTextAligned(PdfContentByte.ALIGN_LEFT, optional_number.ToUpper(), 311f, Y, 0f);
            over.ShowTextAligned(PdfContentByte.ALIGN_LEFT, !string.IsNullOrEmpty(optional_info) ? optional_info.Substring(0, 28).ToUpper() : "", 415f, Y, 0f);
            over.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "", 500f, Y, 0f);
            #endregion
            #region Linea 17 Routing and Destination - Currency - CHgs - WT/VAL - OTHER - Declared Value of Carriage - Declared Value for Customs 
            Y = Y - 23f;
            over.ShowTextAligned(PdfContentByte.ALIGN_LEFT, destino2.Prefix.ToUpper(), 57f, Y, 0f);
            over.ShowTextAligned(PdfContentByte.ALIGN_LEFT, first2.Prefix_airline.ToUpper(), 92f, Y, 0f);
            over.ShowTextAligned(PdfContentByte.ALIGN_LEFT, segundocarrierdestino2.Prefix.ToUpper(), 210f, Y, 0f);
            over.ShowTextAligned(PdfContentByte.ALIGN_LEFT, second2.Prefix_airline.ToUpper(), 237f, Y, 0f);
            over.ShowTextAligned(PdfContentByte.ALIGN_LEFT, tercercarrierdestino2.Prefix.ToUpper(), 259f, Y, 0f);
            over.ShowTextAligned(PdfContentByte.ALIGN_LEFT, third2.Prefix_airline.ToUpper(), 287f, Y, 0f);

            //

            over.ShowTextAligned(PdfContentByte.ALIGN_LEFT, currency2.Prefix.ToUpper(), 308f, Y, 0f);
            over.ShowTextAligned(PdfContentByte.ALIGN_LEFT, CHGS_code.ToUpper(), 332f, Y, 0f);
            if(WT_VAL.ToUpper() != "COLL")
            {
                over.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "X", 348f, Y, 0f);
            }
            else
            {
                over.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "X", 363f, Y, 0f);
            }
                     
            if(Otros.ToUpper() != "COLL")
            {
                over.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "X", 378f, Y, 0f);
            }
            else
            {
                over.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "X", 391f, Y, 0f);
            }
                   
            over.ShowTextAligned(PdfContentByte.ALIGN_LEFT, declared_value_carriage.ToUpper(), 438f, Y, 0f);
            over.ShowTextAligned(PdfContentByte.ALIGN_LEFT, declared_value_custom.ToUpper(), 522f, Y, 0f);
            #endregion
            #region Linea 18 Destination Airpor - Requested Flight/Date - Insurance 
            Y = Y - 26f;
            over.ShowTextAligned(PdfContentByte.ALIGN_LEFT, destino2.Name.Substring(0,20).ToUpper(), 59f, Y, 0f);
            over.ShowTextAligned(PdfContentByte.ALIGN_LEFT, flight_number.ToUpper(), 180f, Y, 0f);
            over.ShowTextAligned(PdfContentByte.ALIGN_LEFT, flight_date.ToUpper(), 243f, Y, 0f);

            //

            over.ShowTextAligned(PdfContentByte.ALIGN_LEFT, insurance.ToUpper(), 328f, Y, 0f);
            #endregion
            #region Linea 19 Handling Information
            Y = Y - 26f;
            over.ShowTextAligned(PdfContentByte.ALIGN_LEFT, handling_info.Substring(0, 76).ToUpper(), 59f, Y, 0f);
            #endregion
            #region Linea 20
            Y = Y - 11f;
            over.ShowTextAligned(PdfContentByte.ALIGN_LEFT, handling_info.Substring(76).ToUpper(), 59f, Y, 0f);
            #endregion
            #region Linea 21
            Y = Y - 10f;
            over.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "SCI".Remove(0, 3), 510f, Y, 0f);
            #endregion

            string tempNature = "";
            string tempNature2 = "";
            string tempNature3 = "";
            if (nature.Length >= 51 && nature.Length <= 75)
            {
                tempNature = nature.Substring(0, 25);
                tempNature2 = nature.Substring(25, 25).ToUpper();
                tempNature3 = nature.Substring(50).ToUpper();
            }
            else if(nature.Length >= 26 && nature.Length <= 50)
            {
                tempNature = nature.Substring(0, 25);
                tempNature2 = nature.Substring(25).ToUpper();
            }
            else
            {
                tempNature = nature;
            }

            #region Linea 22 Product - Nature
            Y = Y - 45f;
            over.ShowTextAligned(PdfContentByte.ALIGN_LEFT, producto1.Num_Pieces.ToString().ToUpper(), 59f, Y, 0f);
            over.ShowTextAligned(PdfContentByte.ALIGN_LEFT, producto1.Gross_Weight.ToString().ToUpper(), 92f, Y, 0f);
            over.ShowTextAligned(PdfContentByte.ALIGN_LEFT, producto1.Kg_Lb.ToUpper(), 131f, Y, 0f);
            over.ShowTextAligned(PdfContentByte.ALIGN_LEFT, producto1.Commodity_Item.ToUpper(), 165f, Y, 0f);
            over.ShowTextAligned(PdfContentByte.ALIGN_LEFT, producto1.Chargable_Weight.ToString().ToUpper(), 217f, Y, 0f);
            over.ShowTextAligned(PdfContentByte.ALIGN_LEFT, producto1.Rate_Charge.ToString().ToUpper(), 277f, Y, 0f);
            over.ShowTextAligned(PdfContentByte.ALIGN_LEFT, producto1.Total.ToString().ToUpper(), 340f, Y, 0f);

            //

            over.ShowTextAligned(PdfContentByte.ALIGN_LEFT, tempNature, 420f, Y, 0f);
            #endregion
            #region Linea 23 Nature
            Y = Y - 11f;
            over.ShowTextAligned(PdfContentByte.ALIGN_LEFT, tempNature2, 420f, Y, 0f);
            #endregion
            #region Linea 24
            Y = Y - 11f;
            over.ShowTextAligned(PdfContentByte.ALIGN_LEFT, tempNature3, 420f, Y, 0f);
            #endregion
            #region Linea 25 Product Below Description
            Y = Y - 11f;
            over.ShowTextAligned(PdfContentByte.ALIGN_LEFT, uld2.Code.ToUpper()+" // "+producto1.Num_Pieces.ToString().ToUpper() + " PCS // "+producto1.Gross_Weight.ToString().ToUpper()+" KG", 59f, Y, 0f);
            #endregion

            #region Linea 26 Invoice
            Y = Y - 11f;
            over.ShowTextAligned(PdfContentByte.ALIGN_LEFT, InvoicePo.Split('|')[0].ToUpper(), 420f, Y, 0f);
            #endregion
            #region Linea 27 PO
            Y = Y - 11f;
            over.ShowTextAligned(PdfContentByte.ALIGN_LEFT, InvoicePo.Split('|')[1].ToUpper(), 420f, Y, 0f);
            #endregion
            #region Linea 28 Exportacion
            Y = Y - 22f;
            over.ShowTextAligned(PdfContentByte.ALIGN_LEFT, exportacion.Substring(0, 11).ToUpper(), 420f, Y, 0f);
            #endregion
            #region Linea 29
            Y = Y - 11f;
            over.ShowTextAligned(PdfContentByte.ALIGN_LEFT, exportacion.Substring(11).ToUpper(), 420f, Y, 0f);
            #endregion
            #region Linea 30 Invoice Inferior
            over.SetFontAndSize(bf, 8);
            Y = Y - 35f;
            over.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "INVOICE".Remove(0, 7), 420f, Y, 0f);
            #endregion
            #region Linea 31 Invoice Inferior - Product Totales
            over.SetFontAndSize(bf, 8);
            Y = Y - 11f;
            over.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "31024685".Remove(0, 8), 420f, Y, 0f);

            //

            over.SetFontAndSize(bf, 10);
            over.ShowTextAligned(PdfContentByte.ALIGN_LEFT, producto1.Num_Pieces.ToString().ToUpper(), 59f, Y, 0f);
            over.ShowTextAligned(PdfContentByte.ALIGN_LEFT, producto1.Gross_Weight.ToString().ToUpper(), 92f, Y, 0f);
            over.ShowTextAligned(PdfContentByte.ALIGN_LEFT, producto1.Kg_Lb.ToUpper(), 131f, Y, 0f);
            over.ShowTextAligned(PdfContentByte.ALIGN_LEFT, producto1.Total.ToString().ToUpper(), 340f, Y, 0f);
            #endregion
            #region Linea 32 PO Inferior
            over.SetFontAndSize(bf, 8);
            Y = Y - 11f;
            over.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "P.O.".Remove(0, 4), 420f, Y, 0f);
            #endregion
            #region Linea 33 Weight Charge - Due Agent
            over.SetFontAndSize(bf, 10);
            Y = Y - 22f;
            if(CHGS_code.ToUpper() != "CC")
            {              
                over.ShowTextAligned(PdfContentByte.ALIGN_LEFT, producto1.Weight_Charge.ToString().ToUpper(), 90f, Y, 0f);
            }
            else
            {
                over.ShowTextAligned(PdfContentByte.ALIGN_LEFT, producto1.Weight_Charge.ToString().ToUpper(), 190f, Y, 0f);
            }
            
            //

            over.SetFontAndSize(bf, 6);
            over.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Due Agent", 250f, Y, 0f);
            #endregion
            #region Linea 34 Due Agent amount
            Y = Y - 11f;
            over.SetFontAndSize(bf, 10);
            if(producto1.Total_Other_Charges_Agent>0)
            {
                over.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "STO " + producto1.Total_Other_Charges_Agent.ToString().ToUpper(), 250f, Y, 0f);
            }
            #endregion
            #region Linea 35 Valuation Charge - Due Carrier
            over.SetFontAndSize(bf, 10);
            Y = Y - 10f;
            if (CHGS_code.ToUpper() != "CC")
            {
                over.ShowTextAligned(PdfContentByte.ALIGN_LEFT, producto1.Valuation_Charge.ToString().ToUpper().Remove(0, producto1.Valuation_Charge.ToString().Length), 90f, Y, 0f);             
            }
            else
            {
                over.ShowTextAligned(PdfContentByte.ALIGN_LEFT, producto1.Valuation_Charge.ToString().ToUpper().Remove(0, producto1.Valuation_Charge.ToString().Length), 190f, Y, 0f);
            }
                       
            //

            over.SetFontAndSize(bf, 6);
            over.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Due Carrier", 250f, Y, 0f);
            #endregion
            #region Linea 36 Due Carrier amount
            Y = Y - 10f;
            over.SetFontAndSize(bf, 10);
            if(producto1.Total_Other_Charges_Carrier>0)
            {
                over.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "STO "+producto1.Total_Other_Charges_Carrier.ToString().ToUpper(), 250f, Y, 0f);
            }
            
            #endregion
            #region Linea 37 Tax
            over.SetFontAndSize(bf, 10);
            Y = Y - 13f;
            if (CHGS_code.ToUpper() != "CC")
            {               
                over.ShowTextAligned(PdfContentByte.ALIGN_LEFT, producto1.Tax.ToString().ToUpper().Remove(0, producto1.Tax.ToString().Length), 90f, Y, 0f);
            }
            else
            {
                over.ShowTextAligned(PdfContentByte.ALIGN_LEFT, producto1.Tax.ToString().ToUpper().Remove(0, producto1.Tax.ToString().Length), 190f, Y, 0f);
            }       
            
            #endregion
            #region Linea 38 Total Other Charges Due Agent
            over.SetFontAndSize(bf, 10);
            Y = Y - 23f;
            if (CHGS_code.ToUpper() != "CC")
            {
                over.ShowTextAligned(PdfContentByte.ALIGN_LEFT, producto1.Total_Other_Charges_Agent.ToString().ToUpper(), 90f, Y, 0f);
            }
            else
            {
                over.ShowTextAligned(PdfContentByte.ALIGN_LEFT, producto1.Total_Other_Charges_Agent.ToString().ToUpper(), 190f, Y, 0f);
            }
                      
            #endregion
            #region Linea 39 Total Other Charges Due Carrier
            over.SetFontAndSize(bf, 10);
            Y = Y - 25f;
            if (CHGS_code.ToUpper() != "CC")
            {
                over.ShowTextAligned(PdfContentByte.ALIGN_LEFT, producto1.Total_Other_Charges_Carrier.ToString().ToUpper(), 90f, Y, 0f);
            }
            else
            {
                over.ShowTextAligned(PdfContentByte.ALIGN_LEFT, producto1.Total_Other_Charges_Carrier.ToString().ToUpper(), 190f, Y, 0f);
            }         
            
            #endregion
            #region Linea 40 Signature Shipper Agent
            over.SetFontAndSize(bf, 10);
            Y = Y - 15f;
            over.ShowTextAligned(PdfContentByte.ALIGN_LEFT, shipper_signature.ToUpper(), 340f, Y, 0f);
            #endregion
            #region Linea 41 Total Prepaid - Total Collect
            over.SetFontAndSize(bf, 10);
            Y = Y - 33f;
            if (CHGS_code.ToUpper() != "CC")
            {
                over.ShowTextAligned(PdfContentByte.ALIGN_LEFT, producto1.Total_Prepaid.ToString().ToUpper(), 90f, Y, 0f);
            }
            else
            {
                over.ShowTextAligned(PdfContentByte.ALIGN_LEFT, producto1.Total_Collect.ToString().ToUpper(), 190f, Y, 0f);
            }
                       
            #endregion
            #region Linea 42 Executed on - at place - Signature Issuing Carrier - Currency conversion rate - CC Charges in Dest. Currency
            over.SetFontAndSize(bf, 10);
            Y = Y - 17f;
            over.ShowTextAligned(PdfContentByte.ALIGN_LEFT, executed_date.ToUpper(), 270f, Y, 0f);
            over.ShowTextAligned(PdfContentByte.ALIGN_LEFT, at_place.ToUpper(), 340f, Y, 0f);
            over.ShowTextAligned(PdfContentByte.ALIGN_LEFT, signature_issuing_carrier_agent.ToUpper(), 460f, Y, 0f);
            //
            Y = Y - 5f;
            over.ShowTextAligned(PdfContentByte.ALIGN_LEFT, producto1.Currency_Conversion_Rate.ToString().ToUpper(), 90f, Y, 0f);
            over.ShowTextAligned(PdfContentByte.ALIGN_LEFT, producto1.CC_Charges_Dest_Currency.ToString().ToUpper(), 190f, Y, 0f);
            #endregion
            #region Linea 43 Charges at Destination - Total Collect Charges - Pie de Pagina 
            over.SetFontAndSize(bf, 10);
            Y = Y - 25f;
            over.ShowTextAligned(PdfContentByte.ALIGN_LEFT, producto1.Charges_At_Destination.ToString().ToUpper(), 190f, Y, 0f);
            over.ShowTextAligned(PdfContentByte.ALIGN_LEFT, producto1.Total_Collect_Charges.ToString().ToUpper(), 290f, Y, 0f);

            bf = BaseFont.CreateFont(BaseFont.HELVETICA_BOLD, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            over.SetFontAndSize(bf, 18);
            over.ShowTextAligned(PdfContentByte.ALIGN_LEFT, first2.Code.ToUpper() + "-" + guide2.Aerial_guide.ToUpper(), 360f, Y, 0f);
            #endregion
            #region Linea 44
            Y = Y - 25f;

            bf = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            over.SetFontAndSize(bf, 10);
            if(pie.Length>26)
            {
                over.ShowTextAligned(PdfContentByte.ALIGN_LEFT, pie.ToUpper(), 216f, Y, 0f);
            }
            else
            {
                over.ShowTextAligned(PdfContentByte.ALIGN_LEFT, pie.ToUpper(), 240f, Y, 0f);
            }
            
            #endregion

            over.EndText();
            over.RestoreState();
        }
    }
}
