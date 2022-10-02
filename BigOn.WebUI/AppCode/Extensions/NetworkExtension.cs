using Microsoft.Extensions.Configuration;
using System;
using System.Net;
using System.Net.Mail;

namespace BigOn.WebUI.AppCode.Extensions
{
    public static partial class Extension
    {
        static public bool SendMail(this IConfiguration configuration,string toEmail, string textBody, string textSubject)
        {
            try
            {
                string login = configuration["eEmailAccount:userName"];
                string displayName = configuration["eEmailAccount:displayName"];
                string password = configuration["eEmailAccount:password"];
                string smtpHostName = configuration["eEmailAccount:smtpServer"];
                int smtpPort = Convert.ToInt32(configuration["eEmailAccount:smtpPort"]);

                SmtpClient client = new SmtpClient(smtpHostName, smtpPort);
                client.Credentials = new NetworkCredential(login, password);
                client.EnableSsl = true;

                MailAddress from = new MailAddress(login, displayName);
                MailAddress to = new MailAddress(toEmail);

                MailMessage msg = new MailMessage(from, to);
                msg.Subject = textSubject;
                msg.Body = textBody;
                msg.IsBodyHtml = true;

                client.Send(msg);

                return true;
            }
            catch (System.Exception)
            {

                return false;
            }
        }
    }
}
