
using Notify.Models;
using System.Threading.Tasks;

namespace Notify.Services.Interfaces
{
    public interface IEmailService
    {
        bool SendEmail(ClientMessage message);
    }
}
