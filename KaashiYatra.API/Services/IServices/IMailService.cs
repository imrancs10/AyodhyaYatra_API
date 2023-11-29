using KaashiYatra.API.Dto.Request;
using KaashiYatra.API.Constants;
using System.Threading.Tasks;

namespace KaashiYatra.API.Services.Interfaces
{
    public interface IMailService
    {
        Task SendEmailAsync(MailRequest mailRequest);
        Task<string> GetMailTemplete(EmailTemplateEnum emailTemplateEnum);
    }
}
