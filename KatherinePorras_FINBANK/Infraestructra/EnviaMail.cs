using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using EASendMail;

namespace KatherinePorras_FINBANK.Infraestructra
{

    public class EnviaMail
    {
    
        const string fromPassword = "katyporras1723.";
        const string subject = "Mail de confirmacion";
      
        public void MailConfirmacion(string para, string cuerpo)
        {
            //var fromAddress = new MailAddress("katip095.kp@gmail.com", "From Name");
            //var toAddress = new MailAddress(para, "To Name");
            // string body = cuerpo;
            //var smtp = new SmtpClient
            //{
            //    Host = "smtp.gmail.com",
            //    Port = 587,
            //    EnableSsl = true,
            //    DeliveryMethod = SmtpDeliveryMethod.Network,
            //    Credentials = new NetworkCredential(fromAddress.Address, fromPassword),
            //    Timeout = 20000
            //};
            //using (var message = new MailMessage(fromAddress, toAddress)
            //{
            //    Subject = subject,
            //    Body = body
            //})
            //{
            //    smtp.Send(message);
            //}

            SmtpMail oMail = new SmtpMail("TryIt");
            SmtpClient oSmtp = new SmtpClient();

            // Your gmail email address
            oMail.From = "finbank@gmail.com";

            // Set recipient email address
            oMail.To = para;

            // Set email subject
            oMail.Subject = "Mail de confirmacion";
            String _body = " <html> <body>" +
                             "<table style='width: 373px;'>" +
                        "<tbody>" +
                        "<tr style='height: 15px;'>" +
                        "<td style='width: 369px; height: 15px; font-size: 10px;'>" + "<strong> Estimado,</strong> &nbsp; </td>" +
                               "</tr>" +
                               "<tr style='height: 18px;'>" +
                               "<td style='width: 369px; height: 18px; font-size: 10px;'>Cliente el usuario fue creado con exito.</td>" +
                                 "</tr>" +
                                 "<tr style='height: 26px;'>" +
                                 "<td style='width: 369px; height: 26px; font-size: 10px;'> Debe ingresar al link para activar tu cuenta.</td>" +
                                   "</tr>" +
                                   "<tr style='height: 20px;'>" +
                                   "<td style='width: 369px; height: 20px; font-size: 10px;'>" + "<a href='http://localhost:49736/Login/ConfirmacionCuenta?key="+cuerpo+"'>Activar Cuenta</a> </td>" +
                                       "</tr>" +
                                       "<tr style='height: 20px;'>" +
                                       "<td style='width: 369px; height: 20px; font-size: 10px;'>" + "<span style='color: #003366;'>Atentamente FinBank.</span></td>" +
                                 "</tr>" +
                          "</tbody>" +
                           "</table>"+
                      " </body> </html>";
            // Set email body
            oMail.HtmlBody = _body;
            // Gmail SMTP server address
            SmtpServer oServer = new SmtpServer("smtp.gmail.com");

            // Set 587 port, if you want to use 25 port, please change 587 5o 25
            oServer.Port = 587;

            // detect SSL/TLS automatically
            oServer.ConnectType = SmtpConnectType.ConnectSSLAuto;

            // Gmail user authentication
            // For example: your email is "gmailid@gmail.com", then the user should be the same
            oServer.User = "katip095.kp@gmail.com";
            oServer.Password = "katyporras1723.";
            try
            {

      
                Console.WriteLine("start to send email over SSL ...");
                oSmtp.SendMail(oServer, oMail);
                Console.WriteLine("email was sent successfully!");
            }
            catch (Exception ep)
            {
                Console.WriteLine("failed to send email with the following error:");
                Console.WriteLine(ep.Message);
            }
        }
    }
}