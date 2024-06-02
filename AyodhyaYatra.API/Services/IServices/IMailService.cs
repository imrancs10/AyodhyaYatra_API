using AyodhyaYatra.API.Dto.Request;
using AyodhyaYatra.API.Constants;
using System.Threading.Tasks;

namespace AyodhyaYatra.API.Services
{
    public interface IMailService
    {
        Task SendEmailAsync(MailRequest mailRequest);
        Task<string> GetMailTemplete(EmailTemplateEnum emailTemplateEnum);
    }
}
