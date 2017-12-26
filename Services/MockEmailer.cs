using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Emailer.Models;
using Microsoft.Extensions.Options;

namespace Emailer.Services
{
    public class MockEmailer : IEmailer
    {
        private readonly EmailSettings emailSettings;
        public MockEmailer(IOptionsSnapshot<EmailSettings> emailSettings)
        {
            this.emailSettings = emailSettings.Value;
        }
        public async Task SendAsync(EmailInputModel emailInfo)
        {
            if (emailInfo == null)
            {
                throw new ArgumentNullException(nameof(emailInfo));
            }
        
            Debug.WriteLine("Sending fake email...");
            Debug.WriteLine($"Sending to {emailSettings.To} from {emailSettings.From}");

            await Task.FromResult(0);
        }
    }
}