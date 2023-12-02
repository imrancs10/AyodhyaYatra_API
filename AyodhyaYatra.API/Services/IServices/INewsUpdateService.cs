using AyodhyaYatra.API.DTO.Request;
using AyodhyaYatra.API.DTO.Request.Common;
using AyodhyaYatra.API.DTO.Request.NewsUpdate;
using AyodhyaYatra.API.DTO.Response;
using AyodhyaYatra.API.DTO.Response.Common;
using AyodhyaYatra.API.DTO.Response.MasterData;
using AyodhyaYatra.API.Enums;
using AyodhyaYatra.API.Models;

namespace AyodhyaYatra.API.Services.IServices
{
    public interface INewsUpdateService
    {
        Task<List<NewsUpdateResponse>> GetNewsUpdate();
        Task<NewsUpdateResponse> GetNewsUpdateById(int Id);
        Task<NewsUpdateResponse> AddNewsUpdate(NewsUpdateRequest request);
        Task<int> UpdateNewsUpdate(NewsUpdateRequest request);
        Task<bool> DeleteNewsUpdate(int id);
    }
}
