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
            oMail.From = "katip095.kp@gmail.com";

            // Set recipient email address
            oMail.To = para;

            // Set email subject
            oMail.Subject = "Mail de confirmacion";

            // Set email body
            oMail.TextBody = cuerpo;
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