using System.Threading.Tasks;

namespace Emailer.Services
{
    public interface IEmailer
    {
        Task SendAsync();
    }
}