using System.Threading.Tasks;

namespace EFMongoDemo.Web.Services
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}
