using System.Diagnostics;
using System.Threading.Tasks;

namespace Emailer.Services
{
    public class MockEmailer : IEmailer
    {
        public async Task SendAsync()
        {
            await Task.FromResult(0);
            Debug.WriteLine("Sending fake email...");
        }
    }
}