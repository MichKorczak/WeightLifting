using System.Threading.Tasks;
using Services.Services.Interfaces;

namespace Services.Services.Implementations
{
    public class UserServices : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string message)
        {
            return Task.CompletedTask;
        }
    }
}
