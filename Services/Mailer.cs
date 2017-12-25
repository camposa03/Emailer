using System;
using System.Diagnostics;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using Emailer.Models;

namespace Emailer.Services
{
    public class Mailer: IEmailer
    {
        private const string username = "";
        private const string password = "";
        private const string from = "";
        private const string to = "";

        public Mailer()
        {
        }

        public async Task SendAsync(EmailInputModel emailInfo)
        {
            if (emailInfo == null)
            {
                throw new ArgumentNullException(nameof(emailInfo));
            }

            var client = new SmtpClient()
            {
                Port = 587,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                EnableSsl = true,
                Timeout = 5000,
                Host = "smtp.gmail.com",
                Credentials = new NetworkCredential(username, password)

            };

            var subject = $"Oasis Application:TEST - {emailInfo.CustomerFirstName} {emailInfo.CustomerLastName}";
            var body = emailInfo.CustomerInformation;
            var message = new MailMessage(from, to, subject, body)
            {
                BodyEncoding = UTF8Encoding.UTF8,
                DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure
            };

            using (client)
            {
                try
                {
                    await client.SendMailAsync(message);
                }
                catch (SmtpException e)
                {
                    Debug.WriteLine(e.Message);
                    throw;
                }
                
                
            }

        }
    }
}
