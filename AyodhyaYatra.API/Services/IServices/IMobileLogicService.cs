using AyodhyaYatra.API.DTO.Response;
using AyodhyaYatra.API.Models;

namespace AyodhyaYatra.API.Services
{
    public interface IMobileLogicService
    {
        Task<List<AttractionMobileResponse>> GetAttractionList();
    }
}
