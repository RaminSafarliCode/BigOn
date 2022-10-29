using Microsoft.Extensions.Options;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace BigOn.Domain.AppCode.Services
{
    public class EmailService
    {
        private readonly EmailServiceOptions options;

        public EmailService(IOptions<EmailServiceOptions> options)
        {
            this.options = options.Value;
        }

        public async Task<bool> SendMailAsync(string toEmail, string subject, string messageText)
        {

            try
            {
                string login = options.UserName;
                string displayName = options.DisplayName;
                string password = options.Password;
                string smtpHostName = options.SmtpServer;
                int smtpPort = options.SmtpPort;

                SmtpClient client = new SmtpClient(smtpHostName, smtpPort);
                client.Credentials = new NetworkCredential(login, password);
                client.EnableSsl = true;

                MailAddress from = new MailAddress(login, displayName);
                MailAddress to = new MailAddress(toEmail);

                MailMessage msg = new MailMessage(from, to);
                msg.Subject = subject;
                msg.Body = messageText;
                msg.IsBodyHtml = true;

                await client.SendMailAsync(msg);

                return true;
            }
            catch (System.Exception)
            {

                return false;
            }
        }
    }

    public class EmailServiceOptions
    {
        public string DisplayName { get; set; }
        public string SmtpServer { get; set; }
        public int SmtpPort { get; set; }
        public bool EnableSsl { get; set; }
        public string UserName { get; set; }
        public string AccountPassword { get; set; }
        public string Password { get; set; }
        public string Cc { get; set; }
    }
}
