using System;
using System.Diagnostics;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using Emailer.Models;
using Microsoft.Extensions.Options;
using System.Collections.Generic;

namespace Emailer.Services
{
    public class Mailer : IEmailer
    {
        private Dictionary<string, string> emailMapping = new Dictionary<string, string>();

        private readonly EmailSettings emailSettings;
        public Mailer(IOptionsSnapshot<EmailSettings> emailSettings)
        {
            this.emailSettings = emailSettings.Value;
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
                Credentials = new NetworkCredential(emailSettings.Username, emailSettings.Password)

            };

            var subject = $"Oasis Application:TEST - {emailInfo.CustomerFirstName} {emailInfo.CustomerLastName}";
            var body = emailInfo.CustomerInformation;
            var message = new MailMessage(emailSettings.From, emailSettings.To, subject, body)
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
