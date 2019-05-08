using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;
using KatherinePorras_FINBANK.Modelo;
using KatherinePorras_FINBANK.Acceso_Dato.query;

namespace KatherinePorras_FINBANK.Infraestructra
{
    public class GeneradorPDF
    {


        private sfb_amortizacionDAO _amortizacionDoa = new sfb_amortizacionDAO();
        public string PrintFile(string path, ModeloCotizacion _modelosolicitud, ModeloCalculoAmortizacion _modeloAmortizacion)
        {
            try
            {


                #region variable de estilo
                var normalFont = FontFactory.GetFont(FontFactory.HELVETICA, 12);
                var boldFont1 = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 11);
                var boldFont2 = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12);
                var boldFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 7);
                #endregion

                if (!Directory.Exists(path)) Directory.CreateDirectory(path);
                string pathFull = path + "\\Content\\" + _modelosolicitud.id.ToString()+ ".pdf";
                System.IO.FileStream fs = new FileStream(pathFull, FileMode.Create);

                Document document = new Document(PageSize.A4, 10, 10, 10, 10);

                PdfWriter writer = PdfWriter.GetInstance(document, fs);
                document.AddAuthor("Katherine Porras");
                document.AddCreator("Katherine Porras");
                document.AddKeywords("UTE");
                document.AddSubject("Documentacion Amortización");
                document.AddTitle("Documentacion Amortización");
                document.AddHeader("Header", "Header Text");

                //#region CuerpoPDF
                document.Open();

                // CabeceraC:\Users\dsamueza\Source\Repos\dsamueza\ComplexivoKP\KatherinePorras_FINBANK\Content\image\finbank.png
                var logo = iTextSharp.text.Image.GetInstance((path + "\\Content\\image\\finbank.png"));
                logo.Alignment = Element.ALIGN_LEFT;
                logo.ScaleAbsoluteHeight(50);
                logo.ScaleAbsoluteWidth(50);

                PdfPTable tblCuerpo = new PdfPTable(1);
                PdfPCell clLogo = new PdfPCell(logo);
                clLogo.Border = 0;
                clLogo.HorizontalAlignment = Element.ALIGN_LEFT;
                //PdfPCell clPieLogo = new PdfPCell(new Phrase("Mardis Research", FontFactory.GetFont("Arial", 10, 1)));
                //clPieLogo.Border = 0;
                //clPieLogo.HorizontalAlignment = Element.ALIGN_LEFT;
                tblCuerpo.AddCell(clLogo);
                //tblCuerpo.AddCell(clPieLogo);
                PdfPCell saltoLinea = new PdfPCell(new Paragraph("\n"));
                saltoLinea.Border = 0;

                // Escribimos el encabezamiento en el documento
                PdfPCell cltitulo = new PdfPCell(new Paragraph("Detalle de Solicitud", boldFont2));
                cltitulo.Colspan = 2;
                cltitulo.Border = 0;
                cltitulo.PaddingTop = 10;
                cltitulo.PaddingBottom = 10;
                cltitulo.HorizontalAlignment = 1;
                tblCuerpo.AddCell(saltoLinea);
                tblCuerpo.AddCell(saltoLinea);
                tblCuerpo.AddCell(cltitulo);
                tblCuerpo.AddCell(saltoLinea);
                tblCuerpo.WidthPercentage = 100;
                iTextSharp.text.Font _standardFont = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 7, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);

                //Datos Local
                PdfPTable tblInformación = new PdfPTable(3);

                PdfPCell clDato = null;
                var phraseDato = new Phrase();
                phraseDato.Add(new Chunk("Cliente: ", boldFont));
                phraseDato.Add(new Chunk(_modelosolicitud.nombre, _standardFont));
                clDato = new PdfPCell(phraseDato);
                clDato.BorderWidth = 0;
                clDato.PaddingTop = 3;
                clDato.PaddingBottom = 3;
                tblInformación.AddCell(clDato);

                clDato = null;
                phraseDato = new Phrase();
                phraseDato.Add(new Chunk("Cédula: ", boldFont));
                phraseDato.Add(new Chunk(_modelosolicitud.cedula, _standardFont));
                clDato = new PdfPCell(phraseDato);
                clDato.BorderWidth = 0;
                clDato.PaddingTop = 3;
                clDato.PaddingBottom = 3;
                tblInformación.AddCell(clDato);

                clDato = null;
                phraseDato = new Phrase();
                phraseDato.Add(new Chunk("Mail: ", boldFont));
                phraseDato.Add(new Chunk(_modelosolicitud.Mail, _standardFont));
                clDato = new PdfPCell(phraseDato);
                clDato.BorderWidth = 0;
                clDato.PaddingTop = 3;
                clDato.PaddingBottom = 3;
                tblInformación.AddCell(clDato);
                var Sucursal = _amortizacionDoa.ObtenerDatosSucursal()
                          .Where(x => x.Value == _modelosolicitud.idinteres.ToString())
                          .Select(x => x.Text).First();

                clDato = null;
                phraseDato = new Phrase();
                phraseDato.Add(new Chunk("Sucursal: ", boldFont));
                phraseDato.Add(new Chunk(Sucursal, _standardFont));
                clDato = new PdfPCell(phraseDato);
                clDato.BorderWidth = 0;
                clDato.PaddingTop = 3;
                clDato.PaddingBottom = 3;
                tblInformación.AddCell(clDato);

                var Interes = _amortizacionDoa.ObtenerDatosInteres()
                            .Where(x => x.Value == _modelosolicitud.idinteres.ToString())
                            .Select(x => x.Text).First();
                clDato = null;
                phraseDato = new Phrase();
                phraseDato.Add(new Chunk("Tipo Interes: ", boldFont));
                phraseDato.Add(new Chunk(Interes, _standardFont));
                clDato = new PdfPCell(phraseDato);
                clDato.BorderWidth = 0;
                clDato.PaddingTop = 3;
                clDato.PaddingBottom = 3;
                tblInformación.AddCell(clDato);

                var Amortizacion = _amortizacionDoa.ObtenerDatosAmortizacion()
                      .Where(x => x.Value == _modelosolicitud.idinteres.ToString())
                      .Select(x => x.Text).First();
                clDato = null;
                phraseDato = new Phrase();
                phraseDato.Add(new Chunk("Tipo Amortizacion: ", boldFont));
                phraseDato.Add(new Chunk(Amortizacion, _standardFont));
                clDato = new PdfPCell(phraseDato);
                clDato.BorderWidth = 0;
                clDato.PaddingTop = 3;
                clDato.PaddingBottom = 3;
                tblInformación.AddCell(clDato);

                tblCuerpo.AddCell(tblInformación);

                //Numero de Orden
                PdfPTable tblInfoOrden = new PdfPTable(2);

                clDato = null;
                phraseDato = new Phrase();
                phraseDato.Add(new Chunk("Orden # ", boldFont));
                phraseDato.Add(new Chunk(_modeloAmortizacion.idSolicitud.ToString(), _standardFont));
                clDato = new PdfPCell(phraseDato);
                clDato.BorderWidth = 0;
                clDato.PaddingTop = 5;
                clDato.PaddingBottom = 5;
                tblInfoOrden.AddCell(clDato);


                PdfPCell clTablaPedido;
                //Datos Pedidos
                PdfPCell clTitulotabla = new PdfPCell(new Phrase("Pedidos"));
                clTitulotabla.HorizontalAlignment = Element.ALIGN_CENTER;

                PdfPTable tblPedido = new PdfPTable(10);
                tblPedido.WidthPercentage = 100;

                PdfPCell clPago = new PdfPCell(new Phrase("Pago#", boldFont));
                clPago.BorderWidth = 0;
                clPago.BorderWidthBottom = 0.75f;

                PdfPCell clCuota = new PdfPCell(new Phrase("Cuota", boldFont));
                clCuota.BorderWidth = 0;
                clCuota.BorderWidthBottom = 0.75f;

                PdfPCell clCantInteres = new PdfPCell(new Phrase("Interés.", boldFont));
                clCantInteres.BorderWidth = 0;
                clCantInteres.BorderWidthBottom = 0.75f;

                PdfPCell clCapital = new PdfPCell(new Phrase("Capital", boldFont));
                clCapital.BorderWidth = 0;
                clCapital.BorderWidthBottom = 0.75f;

                PdfPCell clSaldo = new PdfPCell(new Phrase("Saldo", boldFont));
                clSaldo.BorderWidth = 0;
                clSaldo.BorderWidthBottom = 0.75f;


                tblPedido.AddCell(clPago);
                tblPedido.AddCell(clCuota);
                tblPedido.AddCell(clCantInteres);
                tblPedido.AddCell(clCapital);
                tblPedido.AddCell(clSaldo);


                var subtotalPedido = 0.00;
                var ivatotalPedido = 0.00;
                var totalPedido = 0.00;

                foreach (var item in _modeloAmortizacion.ListaDatosAmortizacion)
                {
                    clPago = new PdfPCell(new Phrase(item.mumeroPago.ToString(), _standardFont));
                    clPago.BorderWidth = 0;
                    clCuota = new PdfPCell(new Phrase(item.cuota.ToString(), _standardFont));
                    clCuota.BorderWidth = 0;
                    clCantInteres = new PdfPCell(new Phrase(item.interes.ToString(), _standardFont));
                    clCantInteres.BorderWidth = 0;
                    clCapital = new PdfPCell(new Phrase(item.capital.ToString(), _standardFont));
                    clCapital.BorderWidth = 0;
                    clSaldo = new PdfPCell(new Phrase(item.Saldo.ToString(), _standardFont));
                    clSaldo.BorderWidth = 0;


                    tblPedido.AddCell(clPago);
                    tblPedido.AddCell(clCuota);
                    tblPedido.AddCell(clCantInteres);
                    tblPedido.AddCell(clCapital);
                    tblPedido.AddCell(clSaldo);



                }
                clTablaPedido = new PdfPCell(tblPedido);

                //Totales Factura(Detalle Pedido)
                ivatotalPedido = Math.Round(ivatotalPedido, 2);
                totalPedido = ivatotalPedido + subtotalPedido;
                PdfPTable tblDatosPedido = new PdfPTable(1);

                clDato = null;
                phraseDato = new Phrase();
                phraseDato.Add(new Chunk("Monto solicitado: ", boldFont));
                phraseDato.Add(new Chunk(_modelosolicitud.monto.ToString(), _standardFont));
                clDato = new PdfPCell(phraseDato);
                clDato.BorderWidth = 0;
                clDato.PaddingTop = 3;
                clDato.PaddingBottom = 3;
                tblDatosPedido.AddCell(clDato);

                clDato = null;
                phraseDato = new Phrase();
                phraseDato.Add(new Chunk("Plazo en meses ", boldFont));
                phraseDato.Add(new Chunk(_modelosolicitud.plazo.ToString(), _standardFont));
                clDato = new PdfPCell(phraseDato);
                clDato.BorderWidth = 0;
                clDato.PaddingTop = 3;
                clDato.PaddingBottom = 3;
                tblDatosPedido.AddCell(clDato);

                clDato = null;
                phraseDato = new Phrase();
                phraseDato.Add(new Chunk("Total: ", boldFont));
                phraseDato.Add(new Chunk(_modeloAmortizacion.Pagototal.ToString(), _standardFont));
                clDato = new PdfPCell(phraseDato);
                clDato.BorderWidth = 0;
                clDato.PaddingTop = 3;
                clDato.PaddingBottom = 3;
                tblDatosPedido.AddCell(clDato);

                tblCuerpo.AddCell(clTablaPedido);
                tblCuerpo.AddCell(tblDatosPedido);

                document.Add(tblCuerpo);

                document.Close();
                writer.Close();
                fs.Close();



                // loading bytes from a file is very easy in C#. The built in System.IO.File.ReadAll* methods take care of making sure every byte is read properly.

                return pathFull;

            }
            catch (Exception ex)
            {

                return "";
            }
        }

    }
}
