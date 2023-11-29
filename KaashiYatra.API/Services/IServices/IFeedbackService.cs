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
    public interface IFeedbackService
    {
        Task<List<FeedbackResponse>> GetFeedback();
        Task<DashboardResponse> GetDashboardCount();
        Task<NewsUpdateResponse> GetNewsUpdateById(int Id);
        Task<FeedbackResponse> AddFeedback(FeedbackRequest request);
        Task<bool> DeleteNewsUpdate(int id);
    }
}
