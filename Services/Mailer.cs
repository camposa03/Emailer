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

            var storeNameMapped = MessageManager.toStoreName(emailInfo.StoreName);

            var emailAddressRecipient = MessageManager.EmailAddress(storeNameMapped);

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
            //var message = new MailMessage(emailSettings.From, emailSettings.To, subject, body)
            var message = new MailMessage(emailSettings.From, emailAddressRecipient, subject, body)
            {
                BodyEncoding = UTF8Encoding.UTF8,
                DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure
            };

            message.CC.Add(emailSettings.To);

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
