using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Emailer.Models;

namespace Emailer.Services
{
    public class MockEmailer : IEmailer
    {
        public async Task SendAsync(EmailInputModel emailInfo)
        {
            if (emailInfo == null)
            {
                throw new ArgumentNullException(nameof(emailInfo));
            }

            await Task.FromResult(0);
            Debug.WriteLine("Sending fake email...");
        }
    }
}