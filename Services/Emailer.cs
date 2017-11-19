using System.Diagnostics;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Emailer.Services
{
    public class Mailer
    {
        private const string username = "camposa22";
        private const string password = "*Zbl2726501";

        public Mailer()
        {
        }

        public async Task SendAsync()
        {
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

            var subject = "Testing from .net core";
            var body = "this is just a test";
            var message = new MailMessage("camposa22@gmail.com","camposa22@gmail.com", subject, body)
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
