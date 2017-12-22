using System.Threading.Tasks;
using Emailer.Models;

namespace Emailer.Services
{
    public interface IEmailer
    {
        Task SendAsync(EmailInputModel emailInfo);
    }
}