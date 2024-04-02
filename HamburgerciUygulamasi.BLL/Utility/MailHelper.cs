using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace HamburgerciUygulamasi.BLL.Utility
{
    public static class MailHelper
    {
        public static void SendMail(string to, string subject, string mailBody, string? cc, string? bcc, string from = "merveproje9@gmail.com")
        {
            try
            {
                MailMessage message = new MailMessage(from, to);
                message.IsBodyHtml = true;
                message.Subject = subject;
                message.BodyEncoding = UTF8Encoding.UTF8;
                message.Body = mailBody;

                if (!string.IsNullOrWhiteSpace(cc))
                {

                    var ccList = cc.Split(";");
                    foreach (var _cc in ccList)
                    {
                        message.CC.Add(_cc);
                    }

                }

                if (!string.IsNullOrWhiteSpace(bcc))
                {

                    var bccList = bcc.Split(";");
                    foreach (var _bcc in bccList)
                    {
                        message.Bcc.Add(_bcc);
                    }

                }

                SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                client.EnableSsl = true;
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential("merveproje9@gmail.com", "030921Mf");

                client.Send(message);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
