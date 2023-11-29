using KaashiYatra.API.DTO.Request;
using KaashiYatra.API.DTO.Request.Common;
using KaashiYatra.API.DTO.Request.NewsUpdate;
using KaashiYatra.API.DTO.Response;
using KaashiYatra.API.DTO.Response.Common;
using KaashiYatra.API.DTO.Response.MasterData;
using KaashiYatra.API.Enums;
using KaashiYatra.API.Models;

namespace KaashiYatra.API.Services.IServices
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
