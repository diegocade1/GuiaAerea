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

namespace Negocio
{
    public class N_PDF
    {
        /** The filename of the PDF */
        public string DIR = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) ;
        public string FILENAME = "Guide.pdf";

        public void GenerarPDF()
        {
            string path = DIR + Path.DirectorySeparatorChar + FILENAME;
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
                            Text(over,pie[index]);
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

        private void Text (PdfContentByte writer , string pie)
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
            over.ShowTextAligned(PdfContentByte.ALIGN_LEFT,"045",59f,Y,0f);
            over.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "SCL", 82f, Y, 0f);
            over.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "06532132123", 109f, Y, 0f);
            over.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "045-06532132123", 470f, Y, 0f);
            #endregion
            #region Linea 2
            Y = Y-24f;
            over.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "79.784.980-4", 198f, Y, 0f);
            over.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "LAN", 381f, Y, 0f);
            #endregion
            #region Linea 3
            Y = Y - 20f;
            over.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "CERMAQ CHILE S.A", 59f, Y, 0f);
            #endregion
            #region Linea 4
            Y = Y - 11f;
            over.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "AVDA. DIEGO PORTALES N°2000 PISO 10", 59f, Y, 0f);
            #endregion
            #region Linea 5
            Y = Y - 11f;
            over.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "PUERTO MONTT - CHILE   PH:56 65 2563200", 59f, Y, 0f);
            #endregion
            #region Linea 6
            Y = Y - 28f;
            over.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "CERMAQ US LLC", 59f, Y, 0f);
            over.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "79.784.980-4", 198f, Y, 0f);
            #endregion
            #region Linea 7
            Y = Y - 13f;
            over.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "5835 BLUE LAGOON DRIVE", 59f, Y, 0f);
            #endregion
            #region Linea 8
            Y = Y - 11f;
            over.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "SUITE # 204 MIAMI FL 33126 U.S.A", 59f, Y, 0f);
            #endregion
            #region Linea 9
            Y = Y - 11f;
            over.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "EMAIL:Andre.Rojter@Cermaq.com", 59f, Y, 0f);
            #endregion
            #region Linea 10
            Y = Y - 11f;
            over.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "PH:1 786 542 5544", 59f, Y, 0f);
            #endregion
            #region Linea 11
            Y = Y - 26f;
            over.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "CARGO NET CENTER S.A * RUT. 76.558.820-0", 59f, Y, 0f);

            //

            over.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "ALPHA BROKERS//", 311f, Y, 0f);
            #endregion
            #region Linea 12
            Y = Y - 11f;
            over.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "AV.AMERICO VESPUCIO ORIENTE 1309 OF 202", 59f, Y, 0f);

            //

            over.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "2875 N.W. 82 AVENUE MIAMI", 311f, Y, 0f);
            #endregion
            #region Linea 13
            Y = Y - 11f;
            over.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "PUDAHUEL - SANTIAGO - CHILE", 59f, Y, 0f);

            //

            over.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "FLORIDA 33122 MIAMI-U.S.A", 311f, Y, 0f);
            #endregion
            #region Linea 14
            Y = Y - 11f;
            over.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "EMAIL:FISH@ALPHABROKERS.COM", 311f, Y, 0f);
            #endregion
            #region Linea 15
            Y = Y - 11f;
            over.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "75 - 1 - 0041/0011", 59f, Y, 0f);
            over.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "75 - 1 - 0041/0011", 198f, Y, 0f);

            //

            over.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "PH: 305-594-9290", 311f, Y, 0f);
            #endregion
            #region Linea 16
            Y = Y - 25f;
            over.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "SANTIAGO DE CHILE" + "     " + " SCL-MIA", 59f, Y, 0f);

            //

            over.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Reference number", 311f, Y, 0f);
            over.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Reference", 425f, Y, 0f);
            over.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "number", 500f, Y, 0f);
            #endregion
            #region Linea 17
            Y = Y - 23f;
            over.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "MIA", 57f, Y, 0f);
            over.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "LAN", 92f, Y, 0f);
            over.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "TO", 210f, Y, 0f);
            over.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "BY", 237f, Y, 0f);
            over.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "TO", 259f, Y, 0f);
            over.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "BY", 287f, Y, 0f);

            //

            over.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "USD", 308f, Y, 0f);
            over.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "PP", 332f, Y, 0f);
            over.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "X", 348f, Y, 0f);
            over.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "X", 363f, Y, 0f);
            over.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "X", 378f, Y, 0f);
            over.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "X", 391f, Y, 0f);
            over.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "NVD", 438f, Y, 0f);
            over.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "NCV", 522f, Y, 0f);
            #endregion
            #region Linea 18
            Y = Y - 26f;
            over.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "MIAMI INTERNATIONAL", 59f, Y, 0f);
            over.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "UC-1102", 180f, Y, 0f);
            over.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "06-05-2019", 243f, Y, 0f);

            //

            over.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "NIL", 328f, Y, 0f);
            #endregion
            #region Linea 19
            Y = Y - 26f;
            over.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "PLEASE NOTIFY UPON ARRIVAL AT DESTINATION *** KEEP COOL ***", 59f, Y, 0f);
            #endregion
            #region Linea 20
            Y = Y - 11f;
            over.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "THIS SHIPMENT DO NOT CONTAIN DANGEROUS GOODS", 59f, Y, 0f);
            #endregion
            #region Linea 21
            Y = Y - 10f;
            over.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "SCI", 510f, Y, 0f);
            #endregion
            #region Linea 22
            Y = Y - 45f;
            over.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "180", 59f, Y, 0f);
            over.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "3272", 92f, Y, 0f);
            over.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "K", 131f, Y, 0f);
            over.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "GEN", 165f, Y, 0f);
            over.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "3272", 217f, Y, 0f);
            over.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "1,19", 277f, Y, 0f);
            over.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "3893,68", 340f, Y, 0f);

            //

            over.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "PERISHABLE CARGO CONTAINS", 420f, Y, 0f);
            #endregion
            #region Linea 23
            Y = Y - 11f;
            over.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "FRESH ATLANTIC ", 420f, Y, 0f);
            #endregion
            #region Linea 24
            Y = Y - 11f;
            over.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "SALMON", 420f, Y, 0f);
            #endregion
            #region Linea 25
            Y = Y - 11f;
            over.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "PAG33475 // 180 PCS // 3272 KG", 59f, Y, 0f);
            #endregion
            #region Linea 26
            Y = Y - 11f;
            over.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "INVOICE :31024685", 420f, Y, 0f);
            #endregion
            #region Linea 27
            Y = Y - 11f;
            over.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "PO:", 420f, Y, 0f);
            #endregion
            #region Linea 28
            Y = Y - 22f;
            over.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "EXPORTATION", 420f, Y, 0f);
            #endregion
            #region Linea 29
            Y = Y - 11f;
            over.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "PRODUCT OF CHILE", 420f, Y, 0f);
            #endregion
            #region Linea 30
            over.SetFontAndSize(bf, 8);
            Y = Y - 35f;        
            over.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "INVOICE", 420f, Y, 0f);
            #endregion
            #region Linea 31
            over.SetFontAndSize(bf, 8);
            Y = Y - 11f;
            over.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "31024685", 420f, Y, 0f);

            //

            over.SetFontAndSize(bf, 10);
            over.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "180", 59f, Y, 0f);
            over.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "3272", 92f, Y, 0f);
            over.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "K", 131f, Y, 0f);
            over.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "3893,68", 340f, Y, 0f);
            #endregion
            #region Linea 32
            over.SetFontAndSize(bf, 8);
            Y = Y - 11f;
            over.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "P.O.", 420f, Y, 0f);
            #endregion
            #region Linea 33
            over.SetFontAndSize(bf, 10);
            Y = Y - 22f;
            over.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "0", 90f, Y, 0f);
            over.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "0", 190f, Y, 0f);

            //

            over.SetFontAndSize(bf, 6);
            over.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Due Agent", 250f, Y, 0f);
            #endregion
            #region Linea 34
            Y = Y - 11f;
            over.SetFontAndSize(bf, 10);
            over.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "STO 130,88", 250f, Y, 0f);
            #endregion
            #region Linea 35
            over.SetFontAndSize(bf, 10);
            Y = Y - 10f;
            over.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "0", 90f, Y, 0f);
            over.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "0", 190f, Y, 0f);

            //

            over.SetFontAndSize(bf, 6);
            over.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Due Carrier", 250f, Y, 0f);
            #endregion
            #region Linea 36
            Y = Y - 10f;
            over.SetFontAndSize(bf, 10);
            over.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "STO 130,88", 250f, Y, 0f);
            #endregion
            #region Linea 37
            over.SetFontAndSize(bf, 10);
            Y = Y - 13f;
            over.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "0", 90f, Y, 0f);
            over.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "0", 190f, Y, 0f);
            #endregion
            #region Linea 38
            over.SetFontAndSize(bf, 10);
            Y = Y - 23f;
            over.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "130,88", 90f, Y, 0f);
            over.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "0", 190f, Y, 0f);
            #endregion
            #region Linea 39
            over.SetFontAndSize(bf, 10);
            Y = Y - 25f;
            over.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "130,88", 90f, Y, 0f);
            over.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "0", 190f, Y, 0f);
            #endregion
            #region Linea 40
            over.SetFontAndSize(bf, 10);
            Y = Y - 15f;
            over.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "CERMAQ CHILE S.A.", 340f, Y, 0f);
            #endregion
            #region Linea 41
            over.SetFontAndSize(bf, 10);
            Y = Y - 33f;
            over.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "0", 90f, Y, 0f);
            over.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "0", 190f, Y, 0f);
            #endregion
            #region Linea 42
            over.SetFontAndSize(bf, 10);
            Y = Y - 17f;
            over.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "05-05-2019", 270f, Y, 0f);
            over.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "SANTIAGO DE CHILE", 340f, Y, 0f);
            over.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "SCABRERA", 460f, Y, 0f);
            //
            Y = Y - 5f;
            over.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "0", 90f, Y, 0f);
            over.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "0", 190f, Y, 0f);
            #endregion
            #region Linea 43
            over.SetFontAndSize(bf, 10);
            Y = Y - 25f;
            over.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "0", 190f, Y, 0f);
            over.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "0", 290f, Y, 0f);

            bf = BaseFont.CreateFont(BaseFont.HELVETICA_BOLD, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            over.SetFontAndSize(bf, 18);
            over.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "045-06532132123", 360f, Y, 0f);
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
